function [intervalNumber, successFlag] = ContainingInterval(index, intervalList)
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
    % Filename:  ContainingInterval.m
    % Created:  July 2011
    % Description:  Given an index and a list of intervals, in the format
    % produced by the Intervals function, this function will determine if
    % the specified index falls within any of the intervals in the
    % intervalList and, if so, indicate which of the intervals contains the
    % specified index.
    %
    % Usage:
    % [intervalNumber, successFlag] = ContainingInverval(index,
    %   intervalList)
    % Finds the index in the intervals described by the intervalList if the
    % index is within any of the intervals defined by intervalList and, if
    % so, returns an intervalNumber such that intervalList(intervalNumber)
    % specifies the interval that contains index.  If the index was found
    % in one of the intervals, the successFlag is set.  Otherwise the
    % successFlag is false, indicating failure to find the index in one of
    % the intervals in intervalList.
    successFlag = false;
    intervalNumber = -1;
    for i = 1:length(intervalList)
        if(index >= intervalList(i, 1) && index <= intervalList(i, 2))
            intervalNumber = i;
            successFlag = true;
            return;
        end
    end
end