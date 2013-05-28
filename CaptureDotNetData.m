function CaptureDotNetData( foldername, passed_args )
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
    % Filename:  CaptureDotNetData.m
    % Description:  Saves a copy of all the variables in the workspace in
    % order to facilitate troubleshooting of any bugs occurring within the 
    % MATLAB-based portion of the program code.  The developer may simply
    % make a copy to preserve the archived state information in
    % passed_data.mat, load this data into the workspace of an interactive
    % MATLAB session, and call ComputeT1Maps with the preserved data and 
    % options variables.
    path = fullfile(foldername, 'passed_data.mat');
    save(path, 'passed_args', '-mat');
end