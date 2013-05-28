function [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak, options)
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
    % Filename:  ComputeT1NoiseThreshold.m
    % Created:  July 2011
    % Description:  Performs an analysis of the histogram of an image
    % volume and determines a threshold value to exclude the first peak of
    % the histogram, which arises primarily from low-valued noise voxels in
    % the air outside of the subject.
    %
    % Usage:
    %   [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    %   
    %   Computes a threshold value to separate low-valued noise voxels 
    %   from voxels with signal present that should be included in 
    %   subsequent processing.  A copy of the 3D matrix (volume) that is
    %   produced from the inputSlab is also returned for convenience in
    %   further processing to produce the desired 3D mask to filter the
    %   computed T1 maps.  inputSlab is in the format specified in
    %   ClearCanvasToT1MatlabBridge.cs (located in the
    %   ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    %   parameter that should be between zero and one that determines the
    %   fraction of the difference in height between the first peak of the
    %   histogram and the first valley, starting from the peak, at which
    %   the threshold should be set.  This value is adjusted to ensure that
    %   the threshold values adequately remove noise voxels without being 
    %   overly agressive and filtering out valid signal.
    
    volume = zeros(horzcat(size( ...
        inputSlab.Slice{1}.MultidimensionalPixelData(:,:,:,1)), ...
        [1 inputSlab.SliceCount]));
    for i = 1:(inputSlab.SliceCount)
        volume(:,:,1,i) = double( ...
            inputSlab.Slice{i}.MultidimensionalPixelData(:,:,:,1));
    end
    
    maximumVoxelIntensity = max(reshape(volume, 1, []));
    numberOfBins = maximumVoxelIntensity/4;
    [frequencyCounts, binLocations] = hist(reshape(volume, 1, []), numberOfBins);
    frequencyCounts = frequencyCounts(2:end);
    binLocations = binLocations(2:end);
    frequencyCountsLogarithm = log(frequencyCounts);
    frequencyCountsLogarithm(~isfinite(frequencyCountsLogarithm)) = 0;
    xx = linspace(0, maximumVoxelIntensity, maximumVoxelIntensity+1);
    secondinterval = linspace(maximumVoxelIntensity/8, maximumVoxelIntensity/2, 10);
    thirdinterval = linspace(maximumVoxelIntensity/2, maximumVoxelIntensity+100, 6);
    breaks = [linspace(-100, maximumVoxelIntensity/8, 20) secondinterval(2:end) thirdinterval(2:end)];

    numberOfFitPoints = 5;
    leadingLineFit = polyfit(1:numberOfFitPoints, frequencyCountsLogarithm(1:numberOfFitPoints), 1);
    trailingIndices = length(frequencyCountsLogarithm)*ones(1, numberOfFitPoints) - (numberOfFitPoints:-1:1);
    trailingValue = mean(frequencyCountsLogarithm(trailingIndices));

    % The headPoints and tailPoints are included in order to constrain
    % the behavior of the spline at the ends of the interval.
    headPoints = (-100:5:0);
    tailPoints = (0:5:100) + maximumVoxelIntensity;
    pp = splinefit([headPoints binLocations tailPoints], ...
        [max(leadingLineFit(1)*headPoints+leadingLineFit(2), ...
        zeros(1, length(headPoints))) frequencyCountsLogarithm trailingValue*ones(1, ...
        length(tailPoints))], ...
        breaks, 'r');
    fittedhist = ppval(pp, xx);
    qq = ppdiff(pp, 1);
    rr = ppdiff(pp, 2);
    firstderiv = ppval(qq, xx);
    
    % In order to handle the case where the object being imaged is
    % very uniform (such as when imaging a liquid phantom), we will only 
    % search the bottom 1/8th of the range of recorded pixel intensities 
    % for the noise peak.  This ensures that we find the noise peak 
    % instead of mistakenly selecting a peak that represents a large and 
    % very uniform, but nonetheless real, feature in the data.  If we 
    % restrict the search to the bottom of the range of pixel intensities,
    % we will generally be able to avoid being overly agressive in masking 
    % out noise pixels.
    [peakval, peakindex] = max(fittedhist(1:round(length(fittedhist)/8)));
    
    [fdnegative, fdpositive] = Intervals(firstderiv>=0);
    
    if(firstderiv(peakindex)<0)
        [intervalNumber successFlag] = ContainingInterval(peakindex, fdnegative);
        if(successFlag)
            valleyindex = min(fdnegative(intervalNumber, 2)+1, length(xx));
        else
            error(['First derivative is negative at index, but is not in the negative' ...
                'interval list.']);
        end
    else
        [intervalNumber successFlag] = ContainingInterval(peakindex, fdpositive);
        if(successFlag)
            nextInterval = intervalNumber+1;
            if(nextInterval <= length(fdpositive))
                valleyindex = fdpositive(nextInterval, 1);
            else
                valleyindex = min(fdnegative(intervalNumber, 2)+1, length(xx));
            end
        end
    end
    
    % The valley should be somewhere in the lower half of the histogram.
    % If we don't find it there, then the peak decays to a long shelf (and
    % could even be monotonically decreasing for the entire interval after
    % the peak).  To prevent being overly aggressive in the masking of
    % noise pixels, we just take the value of the histogram at the midpoint
    % instead of the computed value.
    if(valleyindex > (maximumVoxelIntensity/2))
        valleyindex = floor(maximumVoxelIntensity/2);
    end
    
    valleyval = fittedhist(valleyindex);
    upperbound = max(frequencyCountsLogarithm);
    lowerbound = min(frequencyCountsLogarithm);
    peakval = min(peakval, upperbound);
    valleyval = max(valleyval, lowerbound);
    height = peakval - valleyval;
    target = peakval - descentFromPeak*height;
    [ltt ~] = Intervals(fittedhist(peakindex:valleyindex)>target);
    threshold = peakindex+ltt(1, 1);

    firstderivsign = firstderiv;
    firstderivsign(firstderiv>=0) = 1;
    firstderivsign(firstderiv<0) = -1;
    
    if(options.SoftwareDiagnostics)
        figure(4), plot(binLocations, frequencyCountsLogarithm, 'g.', xx, [ppval(pp, xx); firstderivsign]);
        hold on;
        line([threshold threshold], [0 max(frequencyCountsLogarithm)], 'Color','k');
        hold off;
    end
end

