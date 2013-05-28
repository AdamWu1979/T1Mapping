function [figureNHandle, figureNSubPlot1Handle, figureNSubPlot2Handle] = ...
    DisplayOriginalAndMaskedImages(originalImage, maskedImage, ...
    windowSetting, imageTitle, figureNumber, figureWidth, figureHeight)
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
    % Filename:  DisplayOriginalAndMaskedImages.m
    % Description:  Displays both the original image without any masking
    % applied and a masked image where pixels that were lower than the 
    % noise threshold in the specified source image are set to zero and
    % shown as black pixels.
    
    primaryDisplaySize = get(0, 'ScreenSize');
    primaryDisplayLateralBorder = 0;
    primaryDisplayBottomBorder = 45;
    primaryDisplayScreenWidth = primaryDisplaySize(3);
    primaryDisplayScreenHeight = primaryDisplaySize(4);

    figureNHandle = figure(figureNumber);
    set(figureNHandle, 'Units', 'pixels');
    figureNPosition = get(figureNHandle, 'pos');
    set(figureNHandle, 'pos', [figureNPosition(1) figureNPosition(2) ...
        figureWidth figureHeight]);
    
    outerpos = get(figureNHandle, 'OuterPosition');
    left = min(primaryDisplayScreenWidth - figureWidth - ...
        primaryDisplayLateralBorder, outerpos(1));
    left = max(primaryDisplayLateralBorder, left);
    bottom = min(primaryDisplayScreenHeight - figureHeight - ...
        primaryDisplayBottomBorder, outerpos(2));
    bottom = max(primaryDisplayBottomBorder, bottom);
    set(figureNHandle, 'OuterPosition', [left bottom outerpos(3) outerpos(4)]);
    
    figureNSubPlot1Handle = subplot(1, 2, 1);
    imshow(originalImage, windowSetting);
    set(figureNSubPlot1Handle, 'pos', [0.025 0.025 0.45 0.9]);
    title(['Original ' imageTitle]);
    
    figureNSubPlot2Handle = subplot(1, 2, 2);
    imshow(maskedImage, windowSetting);
    set(figureNSubPlot2Handle, 'pos', [0.525 0.025 0.45 0.9]);
    title(['Masked ' imageTitle]);
end

