function F = GRET1FitFunction(x, xdata)
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
    % Filename:  GRET1FitFunction.m
    % Created:  6/3/2011
    % Description:  Objective function
    F = x(2)*(1-exp(-xdata(2,:)/x(1)))./(1-cos(xdata(1,:)).*exp(-xdata(2,:)/x(1))).*sin(xdata(1,:));
end