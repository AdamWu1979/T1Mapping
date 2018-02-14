if(~exist(studyPath, 'dir'))
    [status, message, messageId] = mkdir(studyPath);
    if(~status)
        error(messageId, message);
    end
    removeStudyPathOnError = true;
else
    removeStudyPathOnError = false;
end

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

imageHeader = currentSlice.MetaData{1}.Header;

t1FileName = sprintf('T1MAP%06d', uint16(sliceCount - 1));
t1FilePath = fullfile(t1SeriesPath, t1FileName);
WriteT1MapAsDicom(filteredT1Map, sliceCount, ...
    t1SeriesUid, t1SeriesNumber, ...
    options.T1MapSeriesDescription, imageHeader, ...
    t1FilePath);

s0FileName = sprintf('S0MAP%06d', uint16(sliceCount - 1));
s0FilePath = fullfile(t1SeriesPath, s0FileName);
WriteS0MapAsDicom(filteredS0Map, sliceCount, ...
    s0SeriesUid, s0SeriesNumber, ...
    options.S0MapSeriesDescription, imageHeader, ...
    s0FilePath, mask(:,:,sliceCount));