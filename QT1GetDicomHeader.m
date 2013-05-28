function [successFlag header] = QT1GetDicomHeader( filename )
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
    % Filename:  QT1GetDicomHeader.m
    % Description:  Wrapper function that performs error checking to make
    % sure the filename is valid, the file exists, and the file is a valid
    % DICOM file and then calls MATLAB's dicominfo function to retrieve the
    % header information for the file.

    header = struct([]);
    successFlag = false;
    
    if (ischar(filename) && exist(filename, 'file') && isdicom(filename))
        header = dicominfo(filename);
        successFlag = true;
    else
        disp(['GetDicomHeader failed on image file:  ' filename]);
    end
end