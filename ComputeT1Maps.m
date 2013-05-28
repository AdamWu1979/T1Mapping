function ComputeT1Maps(data, options)
    % MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    % Copyright (C) 2011-2013, Michigan State University
    % Author:  Matt Latourette
    %
    % This software modifies the ClearCanvas RIS/PACS open source project.
    %
    % This program is free software: you can redistribute it and/or modify
    % it under the terms of the GNU General Public License as published by
    % the Free Software Foundation, either version 3 of the License, or
    % (at your option) any later version.
    %
    % This program is distributed in the hope that it will be useful,
    % but WITHOUT ANY WARRANTY; without even the implied warranty of
    % MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    % GNU General Public License for more details.
    %
    % You should have received a copy of the GNU General Public License
    % along with this program.  If not, see <http://www.gnu.org/licenses/>.
    %
    %
    % Filename:  ComputeT1Maps.m
    % Created:  8/18/2011
    % Description:  Computes T1 maps from a set of gradient-recalled echo
    % acquisitions in which the flip angle is varied.  Source images are 
    % in DICOM format.
    %
    % Usage:
    % ComputeT1Maps(data, options)
    %   where data is in the hierarchical MATLAB struct format defined in
    %   ClearCanvasToT1MatlabBridge.cs in the ClearCanvas.MSU.SeriesSelector
    %   project
    error(nargchk(1, 2, nargin, 'struct'));
    save(fullfile('F:\MATLAB\T1Mapping', 'T1_debug.mat'), 'data', 'options', ...
        '-mat', '-v7.3');
    
    options = SetDefaultOptions(options);
    
    if(options.DisplayProgressBar)
        progressBarHandle = waitbar(0.0, 'Creating top level folder...');
        progressBarPatchHandle = findobj(progressBarHandle, 'Type', 'Patch');
        set(progressBarPatchHandle, 'EdgeColor', [0 0.7 0], 'FaceColor', ...
            [0 0.9 0]);
        waitbar(0.05, progressBarHandle);
    end
    
    [status, message, messageId] = mkdir(options.DirectoryPath, 'T1Maps');
    if(~status)
        error(messageId, message);
    end
    
    if(options.DisplayProgressBar)
        waitbar(0.10, progressBarHandle, 'Creating study level folder...');
    end
    
    try
        studyInstanceUid = data.GeometricSubspace{1}.Slab{1}.Slice{1}. ...
            MetaData{1}.Header.StudyInstanceUID;
    catch exception
        switch exception.identifier
            case 'MATLAB:nonStrucReference'
                exception = addCause(exception, MException( ...
                    'T1Mapping:ComputeT1Maps:invalidInput', ...
                    ['The image data was not organized in the required format.' ...
                    '  Input data must be arranged as a struct.']));
                rethrow(exception);
            otherwise
                rethrow(exception);
        end            
    end
    
    if(options.DisplayProgressBar)
        waitbar(0.20, progressBarHandle);
    end
    
    studyPath = fullfile(options.DirectoryPath, 'T1Maps', studyInstanceUid);
    
    if(~exist(studyPath, 'dir'))
        [status, message, messageId] = mkdir(studyPath);
        if(~status)
            error(messageId, message);
        end
        removeStudyPathOnError = true;
    else
        removeStudyPathOnError = false;
    end
    
    if(options.DisplayProgressBar)
        waitbar(0.30, progressBarHandle, 'Writing source images to disk...');
    end
        
    try
        save(fullfile(studyPath, 'T1_input.mat'), 'data', 'options', ...
            '-mat', '-v7.3');
    catch exception
        if(removeStudyPathOnError)
            rmdir(studyPath);
        end
        exception = addCause(exception, MException(...
            'T1Mapping:ComputeT1Maps:ioError', ['Unable to write input ' ...
            'data to disk.']));
        rethrow(exception);
    end
    
    if(options.DisplayProgressBar)
        waitbar(1.00, progressBarHandle, 'Initializing...');
    end
    
    processingErrorFlag = false;
    
    % Start the timer to measure performance of the program over the course
    % of a whole study
    tic
    
    for subspaceCount = 1:(data.GeometricSubspaceCount)
        currentSubspace = data.GeometricSubspace{subspaceCount};
        
        for slabCount = 1:(currentSubspace.SlabCount)
            currentSlab = currentSubspace.Slab{slabCount};
            
            t1SeriesUid = dicomuid;
            
            t1SeriesPath = fullfile(studyPath, t1SeriesUid);
            
            if(~exist(t1SeriesPath, 'dir'))
                [status, message, messageId] = mkdir(t1SeriesPath);
                if(~status)
                    error(messageId, message);
                end
                removeT1SeriesPathOnError = true;
            else
                removeT1SeriesPathOnError = false;
            end
            
            seriesHeader = currentSlab.Slice{1}.MetaData{1}.Header;
            t1SeriesNumber = 68200;
            if (isfield(seriesHeader, 'SeriesNumber') && isnumeric(seriesHeader.SeriesNumber))
                t1SeriesNumber = t1SeriesNumber + mod(seriesHeader.SeriesNumber, 100);
            end
            
            s0SeriesUid = dicomuid;
            s0SeriesNumber = 68300;
            if (isfield(seriesHeader, 'SeriesNumber') && ...
                    isnumeric(seriesHeader.SeriesNumber))
                s0SeriesNumber = s0SeriesNumber + mod(seriesHeader.SeriesNumber, 100);
            end
            
            try
                [threshold, lowestFlipAngleVolume] = ComputeT1NoiseThreshold(currentSlab, 0.5, options);
            catch exception
                exception = addCause(exception, MException(...
                    'T1Mapping:ComputeT1Maps:noiseThresholdComputationError', ...
                    ['Failed to compute a noise threshold for masking out ' ...
                    'the image background.']));
                rethrow(exception);
            end
            
            mask = squeeze(lowestFlipAngleVolume)>threshold;
            mask = imclose(mask, strel('disk', 2, 0));
            mask = imfill(mask, 6, 'holes');
            
            if(options.DisplayProgressBar)
                waitbar(0, progressBarHandle, 'Computing T1 maps...');
            end
            
            for sliceCount = 1:(currentSlab.SliceCount)
                currentSlice = currentSlab.Slice{sliceCount};
                numberOfFlipAngles = currentSlice.ImageCount;
                
                imageHeader = currentSlice.MetaData{1}.Header;
                
                for count = 1:numberOfFlipAngles
                    if(count == 1)
                        srcimg = currentSlice.MultidimensionalPixelData(:,:,1,1);
                    else
                        srcimg = cat(4, srcimg, currentSlice.MultidimensionalPixelData(:,:,1,count));
                    end
                end
                
                for count = 1:numberOfFlipAngles
                    if(count == 1)
                        theta = currentSlice.MetaData{count}.Header.FlipAngle;
                    else
                        theta = cat(2, theta, currentSlice. ...
                            MetaData{count}.Header.FlipAngle);
                    end
                end
                
                % Convert flip angles from degrees to radians
                theta = theta*pi/180;
                
                % TR in milliseconds (the T1 results will be in
                % milliseconds also)
                tr = currentSlice.MetaData{1}.Header.RepetitionTime;
                
                y = double(srcimg(:,:,1,:));
                
                fitOptions = optimset('lsqcurvefit');
                fitOptions.Display = 'off';
                fitOptions.TolFun = 1e-6;
                fitOptions.TolX = 1e-6;

                % Set the maximum number of iterations allowed to 30 as a
                % compromise to ensure convergence is achieved when it is
                % achievable in regions where the data is valid and not
                % waste time on voxels where the data strongly deviates
                % from the model due to presence of air or imaging
                % artifacts, etc.
                fitOptions.MaxIter = 30;
                
                rows = size(srcimg, 1);
                cols = size(srcimg, 2);
                
                % Pre-allocate arrays to prevent having to resize them
                % multiple times
                theresiduals = zeros(1, rows, cols);
                out = zeros(rows, cols, 1, 9);
                
                lb = [0 0];
                ub = [7000.0 100000.0];
                
                disp('Looking for job manager');
                if(options.UseLocalJobManager)
                    jobMgr = findResource('scheduler', 'type', 'local');
                    set(jobMgr, 'ClusterSize', 8);
                else
                    jobMgr = findResource('scheduler', 'type', 'jobmanager', ...
                        'name', 'YourJobManager', 'LookupURL', 'yourjobmanagerhostname');
                end
                
                if(~isempty(jobMgr))
                    disp('Found job manager');
                else
                    error('Could not find job manager');
                    % TODO:  Work on handling this situation more
                    % gracefully
                end
                
                disp('Creating a job');
                job = createJob(jobMgr);
                disp('Job created');
                
                jd.cols = cols;
                jd.fitOptions = fitOptions;
                jd.lb = lb;
                jd.ub = ub;
                jd.theta = theta;
                jd.tr = tr;
                jd.numberOfFlipAngles = numberOfFlipAngles;
                
                disp('Initializing job data');
                set(job, 'JobData', jd);
                
                if(~options.UseLocalJobManager)
                    set(job, 'MaximumNumberOfWorkers', 16);
                    set(job, 'MinimumNumberOfWorkers', 8);
                    set(job, 'Timeout', 200000);
                    set(job, 'RestartWorker', options.ResetWorkersOnCluster);
                end
                set(job, 'FileDependencies', {'GRET1FitFunction.m', 'T1RowFit.m'});
                
                try
                    for m = 1:rows
                        theargs = {squeeze(y(m,:,1,:))};
                        obj(m) = createTask(job, @T1RowFit, 1, theargs);
                        
                        if(~options.UseLocalJobManager)
                            set(obj(m), 'FinishedFcn', {@taskFinish, m});
                            set(obj(m), 'Timeout', 5000);
                        end
                    end
                catch exception
                    disp('Failure:  killing job now');
                    cancel(job);
                    destroy(job);
                    rethrow(exception);
                end
                
                disp('Submitting job');
                submit(job);
                disp('Job submitted');
                
                disp('Waiting for finish state');
                waitForState(job, 'finished');
                disp('Finished');
                
                results = getAllOutputArguments(job);
                errmsgs = get(job.Tasks, {'ErrorMessage'});
                nonempty = ~cellfun(@isempty, errmsgs);
                celldisp(errmsgs(nonempty));
                
                for m = 1:rows
                    m2 = m;
                    temp = results{m2};
                    out(m,:,:,:) = temp.out;
                    theresiduals(1:numberOfFlipAngles, m, :) = temp.theresiduals;
                end
                
                ex_nans = isnan(out);
                ex_infs = isinf(out);
                ex_negs = out<0;
                excluded = ex_nans | ex_infs | ex_negs;
                out(excluded) = 0;
                
                T1Fit = out(:,:,1,3);
                
                disp('Destroying job');
                destroy(job);
                disp('Job destroyed');
                
                rawT1Map = uint16(T1Fit);
                filteredT1Map = zeros(size(rawT1Map));
                filteredT1Map(mask(:,:,sliceCount)) = rawT1Map(mask(:,:,sliceCount));
                
                rawS0Map = uint16(out(:,:,1,4));
                filteredS0Map = zeros(size(rawS0Map));
                filteredS0Map(mask(:,:,sliceCount)) = rawS0Map(mask(:,:,sliceCount));

                try
                    save(fullfile(t1SeriesPath, ['T1Output_' ...
                        num2str(sliceCount) '.mat']), '-mat', '-v7.3');
                    
                    if(options.DisplayProgressBar)
                        waitbar(((sliceCount-1)*3+1)/(currentSlab.SliceCount ...
                            * 3), progressBarHandle, 'Computing T1 maps...');
                    end

                    t1FileName = sprintf('T1MAP%06d', ...
                        uint16(sliceCount - 1));
                    t1FilePath = fullfile(t1SeriesPath, t1FileName);
                    WriteT1MapAsDicom(filteredT1Map, sliceCount, ...
                        t1SeriesUid, t1SeriesNumber, ...
                        options.T1MapSeriesDescription, imageHeader, ...
                        t1FilePath);

                    if(options.DisplayProgressBar)
                        waitbar(((sliceCount-1)*3+2)/(currentSlab.SliceCount ...
                            * 3), progressBarHandle, 'Computing T1 maps...');
                    end
                    
                    % Images have been written to disk in the t1SeriesPath,
                    % so cleanup of the file folder on an error condition 
                    % is no longer relevant.
                    removeT1SeriesPathOnError = false;
                    
                    if(options.SaveS0Maps == true)
                        s0FileName = sprintf('S0MAP%06d', uint16(sliceCount - 1));
                        s0FilePath = fullfile(t1SeriesPath, s0FileName);
                        WriteS0MapAsDicom(filteredS0Map, sliceCount, ...
                            s0SeriesUid, s0SeriesNumber, ...
                            options.S0MapSeriesDescription, imageHeader, ...
                            s0FilePath, mask(:,:,sliceCount));
                    end
                    
                    if(options.DisplayProgressBar)
                        waitbar(((sliceCount-1)*3+3)/(currentSlab.SliceCount ...
                            * 3), progressBarHandle, 'Computing T1 maps...');
                    end
                catch exception
                    if(removeT1SeriesPathOnError)
                        rmdir(t1SeriesPath);
                    end
                    exception = addCause(exception, MException( ...
                        'T1Mapping:ComputeT1Maps:ioError', ...
                        'Unable to write computed images to disk'));
                    rethrow(exception);
                end
                
                
                if (options.DisplayComputedImages == true)
                    DisplayOriginalAndMaskedImages(rawT1Map, filteredT1Map, ...
                        [0 2000], 'T1 Map', 1, 800, 450);
                    
                    s0WindowCenter = uint16(mean(double(reshape( ...
                        filteredS0Map(mask(:,:, sliceCount)), 1, []))));
                    s0WindowWidth = uint16(2*std(double(reshape( ...
                        filteredS0Map(mask(:,:, sliceCount)), 1, []))));
                    s0RangeMin = max(0, s0WindowCenter - s0WindowWidth);
                    s0RangeMax = s0WindowCenter+s0WindowWidth;
                    s0Range = [s0RangeMin s0RangeMax];
                        
                    DisplayOriginalAndMaskedImages(rawS0Map, filteredS0Map, ...
                        s0Range, 'S0 Map', 2, 800, 450);
                end
                
                if (options.PauseAtEachSlice == true)
                    menu('Press OK to continue', 'OK');
                end
            end
        end
    end
    
    % Stop the performance timer for the study and print the value
    disp('Total computation time');
    toc
    
    if(processingErrorFlag == true)
        warndlg('Some T1 maps could not be computed');
    end
    if(options.DisplayProgressBar)
        close(progressBarHandle);
    end
    
    function taskFinish(taskObj, eventData, tasknum)
        disp(['Task ' num2str(tasknum) ' completed']);
    end
end