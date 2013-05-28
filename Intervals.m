function [zeroIntervals, nonZeroIntervals] = Intervals(dataset)
    % MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    % Copyright (C) 2002-2013, Michigan State University
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
    % Filename:  Intervals.m
    % Created:  2002
    % Description:  Takes an array and determines the index values that
    % mark the boundaries between contiguous regions of zero values and
    % regions of non-zero values.  The function is intended to operate on
    % logical arrays.
    %
    % Usage:
    % [zeroIntervals, nonZeroIntervals] = Intervals(dataset) 
    % computes two matrices that delimit the bounds between contiguous 
    % regions where dataset==0 (zeroIntervals) and regions where 
    % dataset~=0 (nonZeroIntervals).  The intervals are expressed as a 
    % matrix in which each row contains two components.  The first 
    % component in a row indicates the index of the start of the interval 
    % and the second indicates the index of the end of the interval.
    zeroIntervals(1,1) = NaN;
    zeroIntervals(1,2) = NaN;
    nonZeroIntervals(1,1) = NaN;
    nonZeroIntervals(1,2) = NaN;

    current = dataset(1) ~= 0;
    if(current)
        n = 1;
        z = 0;
        nonZeroIntervals(n, 1) = 1;
    else
        n = 0;
        z = 1;
        zeroIntervals(z, 1) = 1;
    end

    for q = 1:length(dataset)
        if((dataset(q) ~= 0) ~= current)
            if(current)
                nonZeroIntervals(n, 2) = q-1;
                z = z+1;
                zeroIntervals(z, 1) = q;
                current = 0;
            else
                zeroIntervals(z, 2) = q-1;
                n = n+1;
                nonZeroIntervals(n, 1) = q;
                current = 1;
            end
        end
    end

    if(current)
        nonZeroIntervals(n, 2) = length(dataset);
    else
        zeroIntervals(z, 2) = length(dataset);
    end
end