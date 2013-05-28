function options = SetDefaultOptions(explicitOptions)
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
    % Filename:  SetDefaultOptions.m
    % Description:  Provides default values for any program options that
    % were not explicitly set by the user.

    if(~exist('explicitOptions', 'var'))
        options = struct([]);
    else
        options = explicitOptions;
    end
    
    % Set defaults for any undefined options
    if(~isfield(options, 'DirectoryPath'))
        options(1).DirectoryPath = 'C:\T1';
    end
    if(~isfield(options, 'SaveS0Maps'))
        options(1).SaveS0Maps = false;
    end
    if(~isfield(options, 'ExcludeAcquisitions'))
        options(1).ExcludeAcquisitions = false;
    end
    if(~isfield(options, 'ExclusionList'))
        options(1).ExclusionList = [];
    end
    if(~isfield(options, 'DisplayComputedImages'))
        options(1).DisplayComputedImages = true;
    end
    if(~isfield(options, 'PauseAtEachSlice'))
        options(1).PauseAtEachSlice = true;
    end
    if(~isfield(options, 'SoftwareDiagnostics'))
        options(1).SoftwareDiagnostics = true;
    end
    if(~isfield(options, 'DisplayProgressBar'))
        options(1).DisplayProgressBar = true;
    end
    if(~isfield(options, 'ResetWorkersOnCluster'))
        options(1).ResetWorkersOnCluster = true;
    end
    if(~isfield(options, 'UseLocalJobManager'))
        options(1).UseLocalJobManager = false;
    end
    
    if(~isfield(options, 'T1MapSeriesDescription') || ~isfield(options, ...
            'S0MapSeriesDescription'))
        seriesDescriptions = inputdlg({'T1 map series description:', ...
            'S0 map series description:'}, 'Enter series descriptions', 1);
        if(ischar(seriesDescriptions{1}))
            options(1).T1MapSeriesDescription = seriesDescriptions{1};
        end
        if(ischar(seriesDescriptions{2}))
            options(1).S0MapSeriesDescription = seriesDescriptions{2};
        end
    end
    
    if(~isfield(options, 'T1MapSeriesDescription'))
        options(1).T1MapSeriesDescription = 'EXPERIMENTAL T1 MAP';
    end
    if(~isfield(options, 'S0MapSeriesDescription'))
        options(1).S0MapSeriesDescription = 'EXPERIMENTAL S0 MAP';
    end
end

