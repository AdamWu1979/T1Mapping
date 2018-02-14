function details = MyGetFileDetails(filename)

% Get details about the file to read.
details = dir(filename);

% Get the actual name of the file.
if (isempty(details))

    % Look for the file with a different extension.
    file = dicom_create_file_struct;
    file.Filename = filename;
    file = dicom_get_msg(file);
  
    if (isempty(file.Filename))
        error(message('images:dicominfo:noFileOrMessagesFound', filename));
    end

    filename = file.Filename;

    fid = fopen(filename);
    filename = fopen(fid);
    fclose(fid);
    
    details = dir(filename);
    details.name = filename;
    
else
    details.name = filename;
end