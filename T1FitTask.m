function theresult = T1FitTask(m)
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
    % Filename:  T1FitTask.m
    % Description:  

    thejob = getCurrentJob;
    jd = get(thejob, 'JobData');
    srcimg = jd.srcimg;
    y = jd.y;
    rows = jd.rows;
    cols = jd.cols;
    fitOptions = jd.fitOptions;
    lb = jd.lb;
    ub = jd.ub;
    theta = jd.theta;
    numberOfFlipAngles = jd.numberOfFlipAngles;
    sliceCount = jd.sliceCount;
    tr = jd.tr;
    
    out = zeros(1, cols, 1, 9);
    theresiduals = zeros(numberOfFlipAngles, 1, cols);
    
    for n = 1:cols
        % Nonlinear curve fitting - the order of the variables in x0 is
        % T1 in milliseconds, followed by S0 in arbitrary units
        x0 = [800.0 500.0];

        [x, resnorm, residual, exitflag, output] = lsqcurvefit( ...
            @GRET1FitFunction, x0, [theta; tr*ones(1, numberOfFlipAngles)], ...
            reshape(y(m,n,1,1:numberOfFlipAngles), 1, numberOfFlipAngles), ...
            lb, ub, fitOptions);

        out(1,n,1,3) = x(1);    % T1 map
        out(1,n,1,4) = x(2);    % S0 map
        out(1,n,1,6) = resnorm; % squared 2-norm of residuals
        theresiduals(1:numberOfFlipAngles,1,n) = residual(1:numberOfFlipAngles);

        % exitflag > 0 means convergence was achieved
        % exitflag = 0 means maxfuneval or maxiter exceeded
        % exitflag < 0 means failure to converge
        out(1,n,1,7) = exitflag;
        out(1,n,1,8) = output.iterations;   % number of iterations taken
        out(1,n,1,9) = output.funcCount;    % number of function evaluations
    end
    
    theresult.out = out;
    theresult.theresiduals = theresiduals;
    return;
end

