/*
* MATLAB Compiler: 4.16 (R2011b)
* Date: Mon Jan 20 16:06:19 2014
* Arguments: "-B" "macro_default" "-W"
* "dotnet:edu.msu.rad.T1Mapping,MLT1Mapping,2.0,private" "-T" "link:lib" "-d"
* "F:\MATLAB\T1Mapping\edu.msu.rad.T1Mapping\src" "-N" "-p" "distcomp" "-p" "images" "-p"
* "optim" "-w" "enable:specified_file_mismatch" "-w" "enable:repeated_file" "-w"
* "enable:switch_ignored" "-w" "enable:missing_lib_sentinel" "-w" "enable:demo_license"
* "-v"
* "class{MLT1Mapping:F:\MATLAB\T1Mapping\CaptureDotNetData.m,F:\MATLAB\T1Mapping\ComputeT1
* Maps.m,F:\MATLAB\T1Mapping\ComputeT1NoiseThreshold.m,F:\MATLAB\T1Mapping\ContainingInter
* val.m,F:\MATLAB\T1Mapping\DisplayOriginalAndMaskedImages.m,F:\MATLAB\T1Mapping\GRET1FitF
* unction.m,F:\MATLAB\T1Mapping\Intervals.m,F:\MATLAB\T1Mapping\QT1GetDicomHeader.m,F:\MAT
* LAB\T1Mapping\SetDefaultOptions.m,F:\MATLAB\T1Mapping\T1RowFit.m,F:\MATLAB\T1Mapping\Wri
* teS0MapAsDicom.m,F:\MATLAB\T1Mapping\WriteT1MapAsDicom.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace edu.msu.rad.T1Mapping
{

  /// <summary>
  /// The MLT1Mapping class provides a CLS compliant, MWArray interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\CaptureDotNetData.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\ComputeT1Maps.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\ComputeT1NoiseThreshold.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\ContainingInterval.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\DisplayOriginalAndMaskedImages.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\GRET1FitFunction.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\Intervals.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\QT1GetDicomHeader.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\SetDefaultOptions.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\T1RowFit.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\WriteS0MapAsDicom.m
  /// <newpara></newpara>
  /// F:\MATLAB\T1Mapping\WriteT1MapAsDicom.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 2.0
  /// </remarks>
  public class MLT1Mapping : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static MLT1Mapping()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        string ctfFileName = "T1Mapping.ctf";

        Stream embeddedCtfStream = null;

        String[] resourceStrings = assembly.GetManifestResourceNames();

        foreach (String name in resourceStrings)
        {
          if (name.Contains(ctfFileName))
          {
            embeddedCtfStream = assembly.GetManifestResourceStream(name);
            break;
          }
        }
        mcr= new MWMCR("",
                       ctfFilePath, embeddedCtfStream, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the MLT1Mapping class.
    /// </summary>
    public MLT1Mapping()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~MLT1Mapping()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the CaptureDotNetData
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  CaptureDotNetData.m
    /// Description:  Saves a copy of all the variables in the workspace in
    /// order to facilitate troubleshooting of any bugs occurring within the 
    /// MATLAB-based portion of the program code.  The developer may simply
    /// make a copy to preserve the archived state information in
    /// passed_data.mat, load this data into the workspace of an interactive
    /// MATLAB session, and call ComputeT1Maps with the preserved data and 
    /// options variables.
    /// </remarks>
    ///
    public void CaptureDotNetData()
    {
      mcr.EvaluateFunction(0, "CaptureDotNetData", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the CaptureDotNetData
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  CaptureDotNetData.m
    /// Description:  Saves a copy of all the variables in the workspace in
    /// order to facilitate troubleshooting of any bugs occurring within the 
    /// MATLAB-based portion of the program code.  The developer may simply
    /// make a copy to preserve the archived state information in
    /// passed_data.mat, load this data into the workspace of an interactive
    /// MATLAB session, and call ComputeT1Maps with the preserved data and 
    /// options variables.
    /// </remarks>
    /// <param name="foldername">Input argument #1</param>
    ///
    public void CaptureDotNetData(MWArray foldername)
    {
      mcr.EvaluateFunction(0, "CaptureDotNetData", foldername);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the CaptureDotNetData
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  CaptureDotNetData.m
    /// Description:  Saves a copy of all the variables in the workspace in
    /// order to facilitate troubleshooting of any bugs occurring within the 
    /// MATLAB-based portion of the program code.  The developer may simply
    /// make a copy to preserve the archived state information in
    /// passed_data.mat, load this data into the workspace of an interactive
    /// MATLAB session, and call ComputeT1Maps with the preserved data and 
    /// options variables.
    /// </remarks>
    /// <param name="foldername">Input argument #1</param>
    /// <param name="passed_args">Input argument #2</param>
    ///
    public void CaptureDotNetData(MWArray foldername, MWArray passed_args)
    {
      mcr.EvaluateFunction(0, "CaptureDotNetData", foldername, passed_args);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the CaptureDotNetData
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  CaptureDotNetData.m
    /// Description:  Saves a copy of all the variables in the workspace in
    /// order to facilitate troubleshooting of any bugs occurring within the 
    /// MATLAB-based portion of the program code.  The developer may simply
    /// make a copy to preserve the archived state information in
    /// passed_data.mat, load this data into the workspace of an interactive
    /// MATLAB session, and call ComputeT1Maps with the preserved data and 
    /// options variables.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CaptureDotNetData(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "CaptureDotNetData", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the CaptureDotNetData
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  CaptureDotNetData.m
    /// Description:  Saves a copy of all the variables in the workspace in
    /// order to facilitate troubleshooting of any bugs occurring within the 
    /// MATLAB-based portion of the program code.  The developer may simply
    /// make a copy to preserve the archived state information in
    /// passed_data.mat, load this data into the workspace of an interactive
    /// MATLAB session, and call ComputeT1Maps with the preserved data and 
    /// options variables.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="foldername">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CaptureDotNetData(int numArgsOut, MWArray foldername)
    {
      return mcr.EvaluateFunction(numArgsOut, "CaptureDotNetData", foldername);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the CaptureDotNetData
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  CaptureDotNetData.m
    /// Description:  Saves a copy of all the variables in the workspace in
    /// order to facilitate troubleshooting of any bugs occurring within the 
    /// MATLAB-based portion of the program code.  The developer may simply
    /// make a copy to preserve the archived state information in
    /// passed_data.mat, load this data into the workspace of an interactive
    /// MATLAB session, and call ComputeT1Maps with the preserved data and 
    /// options variables.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="foldername">Input argument #1</param>
    /// <param name="passed_args">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CaptureDotNetData(int numArgsOut, MWArray foldername, MWArray 
                                 passed_args)
    {
      return mcr.EvaluateFunction(numArgsOut, "CaptureDotNetData", foldername, passed_args);
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the ComputeT1Maps M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1Maps.m
    /// Created:  8/18/2011
    /// Description:  Computes T1 maps from a set of gradient-recalled echo
    /// acquisitions in which the flip angle is varied.  Source images are 
    /// in DICOM format.
    /// Usage:
    /// ComputeT1Maps(data, options)
    /// where data is in the hierarchical MATLAB struct format defined in
    /// ClearCanvasToT1MatlabBridge.cs in the ClearCanvas.MSU.SeriesSelector
    /// project
    /// </remarks>
    ///
    public void ComputeT1Maps()
    {
      mcr.EvaluateFunction(0, "ComputeT1Maps", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the ComputeT1Maps M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1Maps.m
    /// Created:  8/18/2011
    /// Description:  Computes T1 maps from a set of gradient-recalled echo
    /// acquisitions in which the flip angle is varied.  Source images are 
    /// in DICOM format.
    /// Usage:
    /// ComputeT1Maps(data, options)
    /// where data is in the hierarchical MATLAB struct format defined in
    /// ClearCanvasToT1MatlabBridge.cs in the ClearCanvas.MSU.SeriesSelector
    /// project
    /// </remarks>
    /// <param name="data">Input argument #1</param>
    ///
    public void ComputeT1Maps(MWArray data)
    {
      mcr.EvaluateFunction(0, "ComputeT1Maps", data);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the ComputeT1Maps M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1Maps.m
    /// Created:  8/18/2011
    /// Description:  Computes T1 maps from a set of gradient-recalled echo
    /// acquisitions in which the flip angle is varied.  Source images are 
    /// in DICOM format.
    /// Usage:
    /// ComputeT1Maps(data, options)
    /// where data is in the hierarchical MATLAB struct format defined in
    /// ClearCanvasToT1MatlabBridge.cs in the ClearCanvas.MSU.SeriesSelector
    /// project
    /// </remarks>
    /// <param name="data">Input argument #1</param>
    /// <param name="options">Input argument #2</param>
    ///
    public void ComputeT1Maps(MWArray data, MWArray options)
    {
      mcr.EvaluateFunction(0, "ComputeT1Maps", data, options);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the ComputeT1Maps M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1Maps.m
    /// Created:  8/18/2011
    /// Description:  Computes T1 maps from a set of gradient-recalled echo
    /// acquisitions in which the flip angle is varied.  Source images are 
    /// in DICOM format.
    /// Usage:
    /// ComputeT1Maps(data, options)
    /// where data is in the hierarchical MATLAB struct format defined in
    /// ClearCanvasToT1MatlabBridge.cs in the ClearCanvas.MSU.SeriesSelector
    /// project
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ComputeT1Maps(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "ComputeT1Maps", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the ComputeT1Maps M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1Maps.m
    /// Created:  8/18/2011
    /// Description:  Computes T1 maps from a set of gradient-recalled echo
    /// acquisitions in which the flip angle is varied.  Source images are 
    /// in DICOM format.
    /// Usage:
    /// ComputeT1Maps(data, options)
    /// where data is in the hierarchical MATLAB struct format defined in
    /// ClearCanvasToT1MatlabBridge.cs in the ClearCanvas.MSU.SeriesSelector
    /// project
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="data">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ComputeT1Maps(int numArgsOut, MWArray data)
    {
      return mcr.EvaluateFunction(numArgsOut, "ComputeT1Maps", data);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the ComputeT1Maps M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1Maps.m
    /// Created:  8/18/2011
    /// Description:  Computes T1 maps from a set of gradient-recalled echo
    /// acquisitions in which the flip angle is varied.  Source images are 
    /// in DICOM format.
    /// Usage:
    /// ComputeT1Maps(data, options)
    /// where data is in the hierarchical MATLAB struct format defined in
    /// ClearCanvasToT1MatlabBridge.cs in the ClearCanvas.MSU.SeriesSelector
    /// project
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="data">Input argument #1</param>
    /// <param name="options">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ComputeT1Maps(int numArgsOut, MWArray data, MWArray options)
    {
      return mcr.EvaluateFunction(numArgsOut, "ComputeT1Maps", data, options);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the ComputeT1NoiseThreshold
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1NoiseThreshold.m
    /// Created:  July 2011
    /// Description:  Performs an analysis of the histogram of an image
    /// volume and determines a threshold value to exclude the first peak of
    /// the histogram, which arises primarily from low-valued noise voxels in
    /// the air outside of the subject.
    /// Usage:
    /// [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    /// Computes a threshold value to separate low-valued noise voxels 
    /// from voxels with signal present that should be included in 
    /// subsequent processing.  A copy of the 3D matrix (volume) that is
    /// produced from the inputSlab is also returned for convenience in
    /// further processing to produce the desired 3D mask to filter the
    /// computed T1 maps.  inputSlab is in the format specified in
    /// ClearCanvasToT1MatlabBridge.cs (located in the
    /// ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    /// parameter that should be between zero and one that determines the
    /// fraction of the difference in height between the first peak of the
    /// histogram and the first valley, starting from the peak, at which
    /// the threshold should be set.  This value is adjusted to ensure that
    /// the threshold values adequately remove noise voxels without being 
    /// overly agressive and filtering out valid signal.
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray ComputeT1NoiseThreshold()
    {
      return mcr.EvaluateFunction("ComputeT1NoiseThreshold", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the ComputeT1NoiseThreshold
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1NoiseThreshold.m
    /// Created:  July 2011
    /// Description:  Performs an analysis of the histogram of an image
    /// volume and determines a threshold value to exclude the first peak of
    /// the histogram, which arises primarily from low-valued noise voxels in
    /// the air outside of the subject.
    /// Usage:
    /// [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    /// Computes a threshold value to separate low-valued noise voxels 
    /// from voxels with signal present that should be included in 
    /// subsequent processing.  A copy of the 3D matrix (volume) that is
    /// produced from the inputSlab is also returned for convenience in
    /// further processing to produce the desired 3D mask to filter the
    /// computed T1 maps.  inputSlab is in the format specified in
    /// ClearCanvasToT1MatlabBridge.cs (located in the
    /// ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    /// parameter that should be between zero and one that determines the
    /// fraction of the difference in height between the first peak of the
    /// histogram and the first valley, starting from the peak, at which
    /// the threshold should be set.  This value is adjusted to ensure that
    /// the threshold values adequately remove noise voxels without being 
    /// overly agressive and filtering out valid signal.
    /// </remarks>
    /// <param name="inputSlab">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray ComputeT1NoiseThreshold(MWArray inputSlab)
    {
      return mcr.EvaluateFunction("ComputeT1NoiseThreshold", inputSlab);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the ComputeT1NoiseThreshold
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1NoiseThreshold.m
    /// Created:  July 2011
    /// Description:  Performs an analysis of the histogram of an image
    /// volume and determines a threshold value to exclude the first peak of
    /// the histogram, which arises primarily from low-valued noise voxels in
    /// the air outside of the subject.
    /// Usage:
    /// [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    /// Computes a threshold value to separate low-valued noise voxels 
    /// from voxels with signal present that should be included in 
    /// subsequent processing.  A copy of the 3D matrix (volume) that is
    /// produced from the inputSlab is also returned for convenience in
    /// further processing to produce the desired 3D mask to filter the
    /// computed T1 maps.  inputSlab is in the format specified in
    /// ClearCanvasToT1MatlabBridge.cs (located in the
    /// ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    /// parameter that should be between zero and one that determines the
    /// fraction of the difference in height between the first peak of the
    /// histogram and the first valley, starting from the peak, at which
    /// the threshold should be set.  This value is adjusted to ensure that
    /// the threshold values adequately remove noise voxels without being 
    /// overly agressive and filtering out valid signal.
    /// </remarks>
    /// <param name="inputSlab">Input argument #1</param>
    /// <param name="descentFromPeak">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray ComputeT1NoiseThreshold(MWArray inputSlab, MWArray descentFromPeak)
    {
      return mcr.EvaluateFunction("ComputeT1NoiseThreshold", inputSlab, descentFromPeak);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the ComputeT1NoiseThreshold
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1NoiseThreshold.m
    /// Created:  July 2011
    /// Description:  Performs an analysis of the histogram of an image
    /// volume and determines a threshold value to exclude the first peak of
    /// the histogram, which arises primarily from low-valued noise voxels in
    /// the air outside of the subject.
    /// Usage:
    /// [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    /// Computes a threshold value to separate low-valued noise voxels 
    /// from voxels with signal present that should be included in 
    /// subsequent processing.  A copy of the 3D matrix (volume) that is
    /// produced from the inputSlab is also returned for convenience in
    /// further processing to produce the desired 3D mask to filter the
    /// computed T1 maps.  inputSlab is in the format specified in
    /// ClearCanvasToT1MatlabBridge.cs (located in the
    /// ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    /// parameter that should be between zero and one that determines the
    /// fraction of the difference in height between the first peak of the
    /// histogram and the first valley, starting from the peak, at which
    /// the threshold should be set.  This value is adjusted to ensure that
    /// the threshold values adequately remove noise voxels without being 
    /// overly agressive and filtering out valid signal.
    /// </remarks>
    /// <param name="inputSlab">Input argument #1</param>
    /// <param name="descentFromPeak">Input argument #2</param>
    /// <param name="options">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray ComputeT1NoiseThreshold(MWArray inputSlab, MWArray descentFromPeak, 
                                     MWArray options)
    {
      return mcr.EvaluateFunction("ComputeT1NoiseThreshold", inputSlab, descentFromPeak, options);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the ComputeT1NoiseThreshold
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1NoiseThreshold.m
    /// Created:  July 2011
    /// Description:  Performs an analysis of the histogram of an image
    /// volume and determines a threshold value to exclude the first peak of
    /// the histogram, which arises primarily from low-valued noise voxels in
    /// the air outside of the subject.
    /// Usage:
    /// [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    /// Computes a threshold value to separate low-valued noise voxels 
    /// from voxels with signal present that should be included in 
    /// subsequent processing.  A copy of the 3D matrix (volume) that is
    /// produced from the inputSlab is also returned for convenience in
    /// further processing to produce the desired 3D mask to filter the
    /// computed T1 maps.  inputSlab is in the format specified in
    /// ClearCanvasToT1MatlabBridge.cs (located in the
    /// ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    /// parameter that should be between zero and one that determines the
    /// fraction of the difference in height between the first peak of the
    /// histogram and the first valley, starting from the peak, at which
    /// the threshold should be set.  This value is adjusted to ensure that
    /// the threshold values adequately remove noise voxels without being 
    /// overly agressive and filtering out valid signal.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ComputeT1NoiseThreshold(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "ComputeT1NoiseThreshold", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the ComputeT1NoiseThreshold
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1NoiseThreshold.m
    /// Created:  July 2011
    /// Description:  Performs an analysis of the histogram of an image
    /// volume and determines a threshold value to exclude the first peak of
    /// the histogram, which arises primarily from low-valued noise voxels in
    /// the air outside of the subject.
    /// Usage:
    /// [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    /// Computes a threshold value to separate low-valued noise voxels 
    /// from voxels with signal present that should be included in 
    /// subsequent processing.  A copy of the 3D matrix (volume) that is
    /// produced from the inputSlab is also returned for convenience in
    /// further processing to produce the desired 3D mask to filter the
    /// computed T1 maps.  inputSlab is in the format specified in
    /// ClearCanvasToT1MatlabBridge.cs (located in the
    /// ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    /// parameter that should be between zero and one that determines the
    /// fraction of the difference in height between the first peak of the
    /// histogram and the first valley, starting from the peak, at which
    /// the threshold should be set.  This value is adjusted to ensure that
    /// the threshold values adequately remove noise voxels without being 
    /// overly agressive and filtering out valid signal.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputSlab">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ComputeT1NoiseThreshold(int numArgsOut, MWArray inputSlab)
    {
      return mcr.EvaluateFunction(numArgsOut, "ComputeT1NoiseThreshold", inputSlab);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the ComputeT1NoiseThreshold
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1NoiseThreshold.m
    /// Created:  July 2011
    /// Description:  Performs an analysis of the histogram of an image
    /// volume and determines a threshold value to exclude the first peak of
    /// the histogram, which arises primarily from low-valued noise voxels in
    /// the air outside of the subject.
    /// Usage:
    /// [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    /// Computes a threshold value to separate low-valued noise voxels 
    /// from voxels with signal present that should be included in 
    /// subsequent processing.  A copy of the 3D matrix (volume) that is
    /// produced from the inputSlab is also returned for convenience in
    /// further processing to produce the desired 3D mask to filter the
    /// computed T1 maps.  inputSlab is in the format specified in
    /// ClearCanvasToT1MatlabBridge.cs (located in the
    /// ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    /// parameter that should be between zero and one that determines the
    /// fraction of the difference in height between the first peak of the
    /// histogram and the first valley, starting from the peak, at which
    /// the threshold should be set.  This value is adjusted to ensure that
    /// the threshold values adequately remove noise voxels without being 
    /// overly agressive and filtering out valid signal.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputSlab">Input argument #1</param>
    /// <param name="descentFromPeak">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ComputeT1NoiseThreshold(int numArgsOut, MWArray inputSlab, MWArray 
                                       descentFromPeak)
    {
      return mcr.EvaluateFunction(numArgsOut, "ComputeT1NoiseThreshold", inputSlab, descentFromPeak);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the ComputeT1NoiseThreshold
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1NoiseThreshold.m
    /// Created:  July 2011
    /// Description:  Performs an analysis of the histogram of an image
    /// volume and determines a threshold value to exclude the first peak of
    /// the histogram, which arises primarily from low-valued noise voxels in
    /// the air outside of the subject.
    /// Usage:
    /// [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    /// Computes a threshold value to separate low-valued noise voxels 
    /// from voxels with signal present that should be included in 
    /// subsequent processing.  A copy of the 3D matrix (volume) that is
    /// produced from the inputSlab is also returned for convenience in
    /// further processing to produce the desired 3D mask to filter the
    /// computed T1 maps.  inputSlab is in the format specified in
    /// ClearCanvasToT1MatlabBridge.cs (located in the
    /// ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    /// parameter that should be between zero and one that determines the
    /// fraction of the difference in height between the first peak of the
    /// histogram and the first valley, starting from the peak, at which
    /// the threshold should be set.  This value is adjusted to ensure that
    /// the threshold values adequately remove noise voxels without being 
    /// overly agressive and filtering out valid signal.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputSlab">Input argument #1</param>
    /// <param name="descentFromPeak">Input argument #2</param>
    /// <param name="options">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ComputeT1NoiseThreshold(int numArgsOut, MWArray inputSlab, MWArray 
                                       descentFromPeak, MWArray options)
    {
      return mcr.EvaluateFunction(numArgsOut, "ComputeT1NoiseThreshold", inputSlab, descentFromPeak, options);
    }


    /// <summary>
    /// Provides an interface for the ComputeT1NoiseThreshold function in which the input
    /// and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ComputeT1NoiseThreshold.m
    /// Created:  July 2011
    /// Description:  Performs an analysis of the histogram of an image
    /// volume and determines a threshold value to exclude the first peak of
    /// the histogram, which arises primarily from low-valued noise voxels in
    /// the air outside of the subject.
    /// Usage:
    /// [threshold, volume] = ComputeT1NoiseThreshold(inputSlab, descentFromPeak)
    /// Computes a threshold value to separate low-valued noise voxels 
    /// from voxels with signal present that should be included in 
    /// subsequent processing.  A copy of the 3D matrix (volume) that is
    /// produced from the inputSlab is also returned for convenience in
    /// further processing to produce the desired 3D mask to filter the
    /// computed T1 maps.  inputSlab is in the format specified in
    /// ClearCanvasToT1MatlabBridge.cs (located in the
    /// ClearCanvas.MSU.SeriesSelector project).  descentFromPeak is a
    /// parameter that should be between zero and one that determines the
    /// fraction of the difference in height between the first peak of the
    /// histogram and the first valley, starting from the peak, at which
    /// the threshold should be set.  This value is adjusted to ensure that
    /// the threshold values adequately remove noise voxels without being 
    /// overly agressive and filtering out valid signal.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void ComputeT1NoiseThreshold(int numArgsOut, ref MWArray[] argsOut, MWArray[] 
                              argsIn)
    {
      mcr.EvaluateFunction("ComputeT1NoiseThreshold", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the ContainingInterval
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ContainingInterval.m
    /// Created:  July 2011
    /// Description:  Given an index and a list of intervals, in the format
    /// produced by the Intervals function, this function will determine if
    /// the specified index falls within any of the intervals in the
    /// intervalList and, if so, indicate which of the intervals contains the
    /// specified index.
    /// Usage:
    /// [intervalNumber, successFlag] = ContainingInverval(index,
    /// intervalList)
    /// Finds the index in the intervals described by the intervalList if the
    /// index is within any of the intervals defined by intervalList and, if
    /// so, returns an intervalNumber such that intervalList(intervalNumber)
    /// specifies the interval that contains index.  If the index was found
    /// in one of the intervals, the successFlag is set.  Otherwise the
    /// successFlag is false, indicating failure to find the index in one of
    /// the intervals in intervalList.
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray ContainingInterval()
    {
      return mcr.EvaluateFunction("ContainingInterval", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the ContainingInterval
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ContainingInterval.m
    /// Created:  July 2011
    /// Description:  Given an index and a list of intervals, in the format
    /// produced by the Intervals function, this function will determine if
    /// the specified index falls within any of the intervals in the
    /// intervalList and, if so, indicate which of the intervals contains the
    /// specified index.
    /// Usage:
    /// [intervalNumber, successFlag] = ContainingInverval(index,
    /// intervalList)
    /// Finds the index in the intervals described by the intervalList if the
    /// index is within any of the intervals defined by intervalList and, if
    /// so, returns an intervalNumber such that intervalList(intervalNumber)
    /// specifies the interval that contains index.  If the index was found
    /// in one of the intervals, the successFlag is set.  Otherwise the
    /// successFlag is false, indicating failure to find the index in one of
    /// the intervals in intervalList.
    /// </remarks>
    /// <param name="index">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray ContainingInterval(MWArray index)
    {
      return mcr.EvaluateFunction("ContainingInterval", index);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the ContainingInterval
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ContainingInterval.m
    /// Created:  July 2011
    /// Description:  Given an index and a list of intervals, in the format
    /// produced by the Intervals function, this function will determine if
    /// the specified index falls within any of the intervals in the
    /// intervalList and, if so, indicate which of the intervals contains the
    /// specified index.
    /// Usage:
    /// [intervalNumber, successFlag] = ContainingInverval(index,
    /// intervalList)
    /// Finds the index in the intervals described by the intervalList if the
    /// index is within any of the intervals defined by intervalList and, if
    /// so, returns an intervalNumber such that intervalList(intervalNumber)
    /// specifies the interval that contains index.  If the index was found
    /// in one of the intervals, the successFlag is set.  Otherwise the
    /// successFlag is false, indicating failure to find the index in one of
    /// the intervals in intervalList.
    /// </remarks>
    /// <param name="index">Input argument #1</param>
    /// <param name="intervalList">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray ContainingInterval(MWArray index, MWArray intervalList)
    {
      return mcr.EvaluateFunction("ContainingInterval", index, intervalList);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the ContainingInterval
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ContainingInterval.m
    /// Created:  July 2011
    /// Description:  Given an index and a list of intervals, in the format
    /// produced by the Intervals function, this function will determine if
    /// the specified index falls within any of the intervals in the
    /// intervalList and, if so, indicate which of the intervals contains the
    /// specified index.
    /// Usage:
    /// [intervalNumber, successFlag] = ContainingInverval(index,
    /// intervalList)
    /// Finds the index in the intervals described by the intervalList if the
    /// index is within any of the intervals defined by intervalList and, if
    /// so, returns an intervalNumber such that intervalList(intervalNumber)
    /// specifies the interval that contains index.  If the index was found
    /// in one of the intervals, the successFlag is set.  Otherwise the
    /// successFlag is false, indicating failure to find the index in one of
    /// the intervals in intervalList.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ContainingInterval(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "ContainingInterval", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the ContainingInterval
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ContainingInterval.m
    /// Created:  July 2011
    /// Description:  Given an index and a list of intervals, in the format
    /// produced by the Intervals function, this function will determine if
    /// the specified index falls within any of the intervals in the
    /// intervalList and, if so, indicate which of the intervals contains the
    /// specified index.
    /// Usage:
    /// [intervalNumber, successFlag] = ContainingInverval(index,
    /// intervalList)
    /// Finds the index in the intervals described by the intervalList if the
    /// index is within any of the intervals defined by intervalList and, if
    /// so, returns an intervalNumber such that intervalList(intervalNumber)
    /// specifies the interval that contains index.  If the index was found
    /// in one of the intervals, the successFlag is set.  Otherwise the
    /// successFlag is false, indicating failure to find the index in one of
    /// the intervals in intervalList.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="index">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ContainingInterval(int numArgsOut, MWArray index)
    {
      return mcr.EvaluateFunction(numArgsOut, "ContainingInterval", index);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the ContainingInterval
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ContainingInterval.m
    /// Created:  July 2011
    /// Description:  Given an index and a list of intervals, in the format
    /// produced by the Intervals function, this function will determine if
    /// the specified index falls within any of the intervals in the
    /// intervalList and, if so, indicate which of the intervals contains the
    /// specified index.
    /// Usage:
    /// [intervalNumber, successFlag] = ContainingInverval(index,
    /// intervalList)
    /// Finds the index in the intervals described by the intervalList if the
    /// index is within any of the intervals defined by intervalList and, if
    /// so, returns an intervalNumber such that intervalList(intervalNumber)
    /// specifies the interval that contains index.  If the index was found
    /// in one of the intervals, the successFlag is set.  Otherwise the
    /// successFlag is false, indicating failure to find the index in one of
    /// the intervals in intervalList.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="index">Input argument #1</param>
    /// <param name="intervalList">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ContainingInterval(int numArgsOut, MWArray index, MWArray 
                                  intervalList)
    {
      return mcr.EvaluateFunction(numArgsOut, "ContainingInterval", index, intervalList);
    }


    /// <summary>
    /// Provides an interface for the ContainingInterval function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  ContainingInterval.m
    /// Created:  July 2011
    /// Description:  Given an index and a list of intervals, in the format
    /// produced by the Intervals function, this function will determine if
    /// the specified index falls within any of the intervals in the
    /// intervalList and, if so, indicate which of the intervals contains the
    /// specified index.
    /// Usage:
    /// [intervalNumber, successFlag] = ContainingInverval(index,
    /// intervalList)
    /// Finds the index in the intervals described by the intervalList if the
    /// index is within any of the intervals defined by intervalList and, if
    /// so, returns an intervalNumber such that intervalList(intervalNumber)
    /// specifies the interval that contains index.  If the index was found
    /// in one of the intervals, the successFlag is set.  Otherwise the
    /// successFlag is false, indicating failure to find the index in one of
    /// the intervals in intervalList.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void ContainingInterval(int numArgsOut, ref MWArray[] argsOut, MWArray[] 
                         argsIn)
    {
      mcr.EvaluateFunction("ContainingInterval", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DisplayOriginalAndMaskedImages()
    {
      return mcr.EvaluateFunction("DisplayOriginalAndMaskedImages", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="originalImage">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DisplayOriginalAndMaskedImages(MWArray originalImage)
    {
      return mcr.EvaluateFunction("DisplayOriginalAndMaskedImages", originalImage);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DisplayOriginalAndMaskedImages(MWArray originalImage, MWArray 
                                            maskedImage)
    {
      return mcr.EvaluateFunction("DisplayOriginalAndMaskedImages", originalImage, maskedImage);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DisplayOriginalAndMaskedImages(MWArray originalImage, MWArray 
                                            maskedImage, MWArray windowSetting)
    {
      return mcr.EvaluateFunction("DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting);
    }


    /// <summary>
    /// Provides a single output, 4-input MWArrayinterface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <param name="imageTitle">Input argument #4</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DisplayOriginalAndMaskedImages(MWArray originalImage, MWArray 
                                            maskedImage, MWArray windowSetting, MWArray 
                                            imageTitle)
    {
      return mcr.EvaluateFunction("DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting, imageTitle);
    }


    /// <summary>
    /// Provides a single output, 5-input MWArrayinterface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <param name="imageTitle">Input argument #4</param>
    /// <param name="figureNumber">Input argument #5</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DisplayOriginalAndMaskedImages(MWArray originalImage, MWArray 
                                            maskedImage, MWArray windowSetting, MWArray 
                                            imageTitle, MWArray figureNumber)
    {
      return mcr.EvaluateFunction("DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting, imageTitle, figureNumber);
    }


    /// <summary>
    /// Provides a single output, 6-input MWArrayinterface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <param name="imageTitle">Input argument #4</param>
    /// <param name="figureNumber">Input argument #5</param>
    /// <param name="figureWidth">Input argument #6</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DisplayOriginalAndMaskedImages(MWArray originalImage, MWArray 
                                            maskedImage, MWArray windowSetting, MWArray 
                                            imageTitle, MWArray figureNumber, MWArray 
                                            figureWidth)
    {
      return mcr.EvaluateFunction("DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting, imageTitle, figureNumber, figureWidth);
    }


    /// <summary>
    /// Provides a single output, 7-input MWArrayinterface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <param name="imageTitle">Input argument #4</param>
    /// <param name="figureNumber">Input argument #5</param>
    /// <param name="figureWidth">Input argument #6</param>
    /// <param name="figureHeight">Input argument #7</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray DisplayOriginalAndMaskedImages(MWArray originalImage, MWArray 
                                            maskedImage, MWArray windowSetting, MWArray 
                                            imageTitle, MWArray figureNumber, MWArray 
                                            figureWidth, MWArray figureHeight)
    {
      return mcr.EvaluateFunction("DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting, imageTitle, figureNumber, figureWidth, figureHeight);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DisplayOriginalAndMaskedImages(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "DisplayOriginalAndMaskedImages", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="originalImage">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DisplayOriginalAndMaskedImages(int numArgsOut, MWArray originalImage)
    {
      return mcr.EvaluateFunction(numArgsOut, "DisplayOriginalAndMaskedImages", originalImage);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DisplayOriginalAndMaskedImages(int numArgsOut, MWArray 
                                              originalImage, MWArray maskedImage)
    {
      return mcr.EvaluateFunction(numArgsOut, "DisplayOriginalAndMaskedImages", originalImage, maskedImage);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DisplayOriginalAndMaskedImages(int numArgsOut, MWArray 
                                              originalImage, MWArray maskedImage, MWArray 
                                              windowSetting)
    {
      return mcr.EvaluateFunction(numArgsOut, "DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <param name="imageTitle">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DisplayOriginalAndMaskedImages(int numArgsOut, MWArray 
                                              originalImage, MWArray maskedImage, MWArray 
                                              windowSetting, MWArray imageTitle)
    {
      return mcr.EvaluateFunction(numArgsOut, "DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting, imageTitle);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <param name="imageTitle">Input argument #4</param>
    /// <param name="figureNumber">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DisplayOriginalAndMaskedImages(int numArgsOut, MWArray 
                                              originalImage, MWArray maskedImage, MWArray 
                                              windowSetting, MWArray imageTitle, MWArray 
                                              figureNumber)
    {
      return mcr.EvaluateFunction(numArgsOut, "DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting, imageTitle, figureNumber);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <param name="imageTitle">Input argument #4</param>
    /// <param name="figureNumber">Input argument #5</param>
    /// <param name="figureWidth">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DisplayOriginalAndMaskedImages(int numArgsOut, MWArray 
                                              originalImage, MWArray maskedImage, MWArray 
                                              windowSetting, MWArray imageTitle, MWArray 
                                              figureNumber, MWArray figureWidth)
    {
      return mcr.EvaluateFunction(numArgsOut, "DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting, imageTitle, figureNumber, figureWidth);
    }


    /// <summary>
    /// Provides the standard 7-input MWArray interface to the
    /// DisplayOriginalAndMaskedImages M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="originalImage">Input argument #1</param>
    /// <param name="maskedImage">Input argument #2</param>
    /// <param name="windowSetting">Input argument #3</param>
    /// <param name="imageTitle">Input argument #4</param>
    /// <param name="figureNumber">Input argument #5</param>
    /// <param name="figureWidth">Input argument #6</param>
    /// <param name="figureHeight">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] DisplayOriginalAndMaskedImages(int numArgsOut, MWArray 
                                              originalImage, MWArray maskedImage, MWArray 
                                              windowSetting, MWArray imageTitle, MWArray 
                                              figureNumber, MWArray figureWidth, MWArray 
                                              figureHeight)
    {
      return mcr.EvaluateFunction(numArgsOut, "DisplayOriginalAndMaskedImages", originalImage, maskedImage, windowSetting, imageTitle, figureNumber, figureWidth, figureHeight);
    }


    /// <summary>
    /// Provides an interface for the DisplayOriginalAndMaskedImages function in which
    /// the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  DisplayOriginalAndMaskedImages.m
    /// Description:  Displays both the original image without any masking
    /// applied and a masked image where pixels that were lower than the 
    /// noise threshold in the specified source image are set to zero and
    /// shown as black pixels.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void DisplayOriginalAndMaskedImages(int numArgsOut, ref MWArray[] argsOut, 
                                     MWArray[] argsIn)
    {
      mcr.EvaluateFunction("DisplayOriginalAndMaskedImages", numArgsOut, ref argsOut, 
                                     argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the GRET1FitFunction
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  GRET1FitFunction.m
    /// Created:  6/3/2011
    /// Description:  Objective function
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray GRET1FitFunction()
    {
      return mcr.EvaluateFunction("GRET1FitFunction", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the GRET1FitFunction
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  GRET1FitFunction.m
    /// Created:  6/3/2011
    /// Description:  Objective function
    /// </remarks>
    /// <param name="x">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray GRET1FitFunction(MWArray x)
    {
      return mcr.EvaluateFunction("GRET1FitFunction", x);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the GRET1FitFunction
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  GRET1FitFunction.m
    /// Created:  6/3/2011
    /// Description:  Objective function
    /// </remarks>
    /// <param name="x">Input argument #1</param>
    /// <param name="xdata">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray GRET1FitFunction(MWArray x, MWArray xdata)
    {
      return mcr.EvaluateFunction("GRET1FitFunction", x, xdata);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the GRET1FitFunction
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  GRET1FitFunction.m
    /// Created:  6/3/2011
    /// Description:  Objective function
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GRET1FitFunction(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "GRET1FitFunction", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the GRET1FitFunction
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  GRET1FitFunction.m
    /// Created:  6/3/2011
    /// Description:  Objective function
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="x">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GRET1FitFunction(int numArgsOut, MWArray x)
    {
      return mcr.EvaluateFunction(numArgsOut, "GRET1FitFunction", x);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the GRET1FitFunction
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  GRET1FitFunction.m
    /// Created:  6/3/2011
    /// Description:  Objective function
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="x">Input argument #1</param>
    /// <param name="xdata">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GRET1FitFunction(int numArgsOut, MWArray x, MWArray xdata)
    {
      return mcr.EvaluateFunction(numArgsOut, "GRET1FitFunction", x, xdata);
    }


    /// <summary>
    /// Provides an interface for the GRET1FitFunction function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  GRET1FitFunction.m
    /// Created:  6/3/2011
    /// Description:  Objective function
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void GRET1FitFunction(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("GRET1FitFunction", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the Intervals M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2002-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  Intervals.m
    /// Created:  2002
    /// Description:  Takes an array and determines the index values that
    /// mark the boundaries between contiguous regions of zero values and
    /// regions of non-zero values.  The function is intended to operate on
    /// logical arrays.
    /// Usage:
    /// [zeroIntervals, nonZeroIntervals] = Intervals(dataset) 
    /// computes two matrices that delimit the bounds between contiguous 
    /// regions where dataset==0 (zeroIntervals) and regions where 
    /// dataset~=0 (nonZeroIntervals).  The intervals are expressed as a 
    /// matrix in which each row contains two components.  The first 
    /// component in a row indicates the index of the start of the interval 
    /// and the second indicates the index of the end of the interval.
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Intervals()
    {
      return mcr.EvaluateFunction("Intervals", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the Intervals M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2002-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  Intervals.m
    /// Created:  2002
    /// Description:  Takes an array and determines the index values that
    /// mark the boundaries between contiguous regions of zero values and
    /// regions of non-zero values.  The function is intended to operate on
    /// logical arrays.
    /// Usage:
    /// [zeroIntervals, nonZeroIntervals] = Intervals(dataset) 
    /// computes two matrices that delimit the bounds between contiguous 
    /// regions where dataset==0 (zeroIntervals) and regions where 
    /// dataset~=0 (nonZeroIntervals).  The intervals are expressed as a 
    /// matrix in which each row contains two components.  The first 
    /// component in a row indicates the index of the start of the interval 
    /// and the second indicates the index of the end of the interval.
    /// </remarks>
    /// <param name="dataset">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Intervals(MWArray dataset)
    {
      return mcr.EvaluateFunction("Intervals", dataset);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the Intervals M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2002-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  Intervals.m
    /// Created:  2002
    /// Description:  Takes an array and determines the index values that
    /// mark the boundaries between contiguous regions of zero values and
    /// regions of non-zero values.  The function is intended to operate on
    /// logical arrays.
    /// Usage:
    /// [zeroIntervals, nonZeroIntervals] = Intervals(dataset) 
    /// computes two matrices that delimit the bounds between contiguous 
    /// regions where dataset==0 (zeroIntervals) and regions where 
    /// dataset~=0 (nonZeroIntervals).  The intervals are expressed as a 
    /// matrix in which each row contains two components.  The first 
    /// component in a row indicates the index of the start of the interval 
    /// and the second indicates the index of the end of the interval.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Intervals(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Intervals", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the Intervals M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2002-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  Intervals.m
    /// Created:  2002
    /// Description:  Takes an array and determines the index values that
    /// mark the boundaries between contiguous regions of zero values and
    /// regions of non-zero values.  The function is intended to operate on
    /// logical arrays.
    /// Usage:
    /// [zeroIntervals, nonZeroIntervals] = Intervals(dataset) 
    /// computes two matrices that delimit the bounds between contiguous 
    /// regions where dataset==0 (zeroIntervals) and regions where 
    /// dataset~=0 (nonZeroIntervals).  The intervals are expressed as a 
    /// matrix in which each row contains two components.  The first 
    /// component in a row indicates the index of the start of the interval 
    /// and the second indicates the index of the end of the interval.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="dataset">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Intervals(int numArgsOut, MWArray dataset)
    {
      return mcr.EvaluateFunction(numArgsOut, "Intervals", dataset);
    }


    /// <summary>
    /// Provides an interface for the Intervals function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2002-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  Intervals.m
    /// Created:  2002
    /// Description:  Takes an array and determines the index values that
    /// mark the boundaries between contiguous regions of zero values and
    /// regions of non-zero values.  The function is intended to operate on
    /// logical arrays.
    /// Usage:
    /// [zeroIntervals, nonZeroIntervals] = Intervals(dataset) 
    /// computes two matrices that delimit the bounds between contiguous 
    /// regions where dataset==0 (zeroIntervals) and regions where 
    /// dataset~=0 (nonZeroIntervals).  The intervals are expressed as a 
    /// matrix in which each row contains two components.  The first 
    /// component in a row indicates the index of the start of the interval 
    /// and the second indicates the index of the end of the interval.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void Intervals(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("Intervals", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the QT1GetDicomHeader
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  QT1GetDicomHeader.m
    /// Description:  Wrapper function that performs error checking to make
    /// sure the filename is valid, the file exists, and the file is a valid
    /// DICOM file and then calls MATLAB's dicominfo function to retrieve the
    /// header information for the file.
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray QT1GetDicomHeader()
    {
      return mcr.EvaluateFunction("QT1GetDicomHeader", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the QT1GetDicomHeader
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  QT1GetDicomHeader.m
    /// Description:  Wrapper function that performs error checking to make
    /// sure the filename is valid, the file exists, and the file is a valid
    /// DICOM file and then calls MATLAB's dicominfo function to retrieve the
    /// header information for the file.
    /// </remarks>
    /// <param name="filename">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray QT1GetDicomHeader(MWArray filename)
    {
      return mcr.EvaluateFunction("QT1GetDicomHeader", filename);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the QT1GetDicomHeader
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  QT1GetDicomHeader.m
    /// Description:  Wrapper function that performs error checking to make
    /// sure the filename is valid, the file exists, and the file is a valid
    /// DICOM file and then calls MATLAB's dicominfo function to retrieve the
    /// header information for the file.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] QT1GetDicomHeader(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "QT1GetDicomHeader", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the QT1GetDicomHeader
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  QT1GetDicomHeader.m
    /// Description:  Wrapper function that performs error checking to make
    /// sure the filename is valid, the file exists, and the file is a valid
    /// DICOM file and then calls MATLAB's dicominfo function to retrieve the
    /// header information for the file.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="filename">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] QT1GetDicomHeader(int numArgsOut, MWArray filename)
    {
      return mcr.EvaluateFunction(numArgsOut, "QT1GetDicomHeader", filename);
    }


    /// <summary>
    /// Provides an interface for the QT1GetDicomHeader function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  QT1GetDicomHeader.m
    /// Description:  Wrapper function that performs error checking to make
    /// sure the filename is valid, the file exists, and the file is a valid
    /// DICOM file and then calls MATLAB's dicominfo function to retrieve the
    /// header information for the file.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void QT1GetDicomHeader(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("QT1GetDicomHeader", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the SetDefaultOptions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  SetDefaultOptions.m
    /// Description:  Provides default values for any program options that
    /// were not explicitly set by the user.
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray SetDefaultOptions()
    {
      return mcr.EvaluateFunction("SetDefaultOptions", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the SetDefaultOptions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  SetDefaultOptions.m
    /// Description:  Provides default values for any program options that
    /// were not explicitly set by the user.
    /// </remarks>
    /// <param name="explicitOptions">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray SetDefaultOptions(MWArray explicitOptions)
    {
      return mcr.EvaluateFunction("SetDefaultOptions", explicitOptions);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the SetDefaultOptions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  SetDefaultOptions.m
    /// Description:  Provides default values for any program options that
    /// were not explicitly set by the user.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] SetDefaultOptions(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "SetDefaultOptions", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the SetDefaultOptions
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  SetDefaultOptions.m
    /// Description:  Provides default values for any program options that
    /// were not explicitly set by the user.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="explicitOptions">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] SetDefaultOptions(int numArgsOut, MWArray explicitOptions)
    {
      return mcr.EvaluateFunction(numArgsOut, "SetDefaultOptions", explicitOptions);
    }


    /// <summary>
    /// Provides an interface for the SetDefaultOptions function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  SetDefaultOptions.m
    /// Description:  Provides default values for any program options that
    /// were not explicitly set by the user.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void SetDefaultOptions(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("SetDefaultOptions", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the T1RowFit M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  T1RowFit.m
    /// Created:  2011
    /// Description:  Fits the pixel data for one row of a slice to the
    /// signal model.
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray T1RowFit()
    {
      return mcr.EvaluateFunction("T1RowFit", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the T1RowFit M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  T1RowFit.m
    /// Created:  2011
    /// Description:  Fits the pixel data for one row of a slice to the
    /// signal model.
    /// </remarks>
    /// <param name="y">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray T1RowFit(MWArray y)
    {
      return mcr.EvaluateFunction("T1RowFit", y);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the T1RowFit M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  T1RowFit.m
    /// Created:  2011
    /// Description:  Fits the pixel data for one row of a slice to the
    /// signal model.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] T1RowFit(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "T1RowFit", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the T1RowFit M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  T1RowFit.m
    /// Created:  2011
    /// Description:  Fits the pixel data for one row of a slice to the
    /// signal model.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="y">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] T1RowFit(int numArgsOut, MWArray y)
    {
      return mcr.EvaluateFunction(numArgsOut, "T1RowFit", y);
    }


    /// <summary>
    /// Provides an interface for the T1RowFit function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  T1RowFit.m
    /// Created:  2011
    /// Description:  Fits the pixel data for one row of a slice to the
    /// signal model.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void T1RowFit(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("T1RowFit", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    ///
    public void WriteS0MapAsDicom()
    {
      mcr.EvaluateFunction(0, "WriteS0MapAsDicom", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    ///
    public void WriteS0MapAsDicom(MWArray image)
    {
      mcr.EvaluateFunction(0, "WriteS0MapAsDicom", image);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    ///
    public void WriteS0MapAsDicom(MWArray image, MWArray instanceNumber)
    {
      mcr.EvaluateFunction(0, "WriteS0MapAsDicom", image, instanceNumber);
    }


    /// <summary>
    /// Provides a void output, 3-input MWArrayinterface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    ///
    public void WriteS0MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid)
    {
      mcr.EvaluateFunction(0, "WriteS0MapAsDicom", image, instanceNumber, seriesUid);
    }


    /// <summary>
    /// Provides a void output, 4-input MWArrayinterface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    ///
    public void WriteS0MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid, MWArray seriesNumber)
    {
      mcr.EvaluateFunction(0, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber);
    }


    /// <summary>
    /// Provides a void output, 5-input MWArrayinterface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    ///
    public void WriteS0MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid, MWArray seriesNumber, MWArray seriesDescription)
    {
      mcr.EvaluateFunction(0, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription);
    }


    /// <summary>
    /// Provides a void output, 6-input MWArrayinterface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    ///
    public void WriteS0MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid, MWArray seriesNumber, MWArray seriesDescription, 
                            MWArray headerTemplate)
    {
      mcr.EvaluateFunction(0, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate);
    }


    /// <summary>
    /// Provides a void output, 7-input MWArrayinterface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    /// <param name="fileName">Input argument #7</param>
    ///
    public void WriteS0MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid, MWArray seriesNumber, MWArray seriesDescription, 
                            MWArray headerTemplate, MWArray fileName)
    {
      mcr.EvaluateFunction(0, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate, fileName);
    }


    /// <summary>
    /// Provides a void output, 8-input MWArrayinterface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    /// <param name="fileName">Input argument #7</param>
    /// <param name="imageMask">Input argument #8</param>
    ///
    public void WriteS0MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid, MWArray seriesNumber, MWArray seriesDescription, 
                            MWArray headerTemplate, MWArray fileName, MWArray imageMask)
    {
      mcr.EvaluateFunction(0, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate, fileName, imageMask);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteS0MapAsDicom(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteS0MapAsDicom", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteS0MapAsDicom(int numArgsOut, MWArray image)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteS0MapAsDicom", image);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteS0MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteS0MapAsDicom", image, instanceNumber);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteS0MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteS0MapAsDicom", image, instanceNumber, seriesUid);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteS0MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid, MWArray seriesNumber)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteS0MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid, MWArray seriesNumber, 
                                 MWArray seriesDescription)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteS0MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid, MWArray seriesNumber, 
                                 MWArray seriesDescription, MWArray headerTemplate)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate);
    }


    /// <summary>
    /// Provides the standard 7-input MWArray interface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    /// <param name="fileName">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteS0MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid, MWArray seriesNumber, 
                                 MWArray seriesDescription, MWArray headerTemplate, 
                                 MWArray fileName)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate, fileName);
    }


    /// <summary>
    /// Provides the standard 8-input MWArray interface to the WriteS0MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    /// <param name="fileName">Input argument #7</param>
    /// <param name="imageMask">Input argument #8</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteS0MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid, MWArray seriesNumber, 
                                 MWArray seriesDescription, MWArray headerTemplate, 
                                 MWArray fileName, MWArray imageMask)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteS0MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate, fileName, imageMask);
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    ///
    public void WriteT1MapAsDicom()
    {
      mcr.EvaluateFunction(0, "WriteT1MapAsDicom", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    ///
    public void WriteT1MapAsDicom(MWArray image)
    {
      mcr.EvaluateFunction(0, "WriteT1MapAsDicom", image);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    ///
    public void WriteT1MapAsDicom(MWArray image, MWArray instanceNumber)
    {
      mcr.EvaluateFunction(0, "WriteT1MapAsDicom", image, instanceNumber);
    }


    /// <summary>
    /// Provides a void output, 3-input MWArrayinterface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    ///
    public void WriteT1MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid)
    {
      mcr.EvaluateFunction(0, "WriteT1MapAsDicom", image, instanceNumber, seriesUid);
    }


    /// <summary>
    /// Provides a void output, 4-input MWArrayinterface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    ///
    public void WriteT1MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid, MWArray seriesNumber)
    {
      mcr.EvaluateFunction(0, "WriteT1MapAsDicom", image, instanceNumber, seriesUid, seriesNumber);
    }


    /// <summary>
    /// Provides a void output, 5-input MWArrayinterface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    ///
    public void WriteT1MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid, MWArray seriesNumber, MWArray seriesDescription)
    {
      mcr.EvaluateFunction(0, "WriteT1MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription);
    }


    /// <summary>
    /// Provides a void output, 6-input MWArrayinterface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    ///
    public void WriteT1MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid, MWArray seriesNumber, MWArray seriesDescription, 
                            MWArray headerTemplate)
    {
      mcr.EvaluateFunction(0, "WriteT1MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate);
    }


    /// <summary>
    /// Provides a void output, 7-input MWArrayinterface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    /// <param name="fileName">Input argument #7</param>
    ///
    public void WriteT1MapAsDicom(MWArray image, MWArray instanceNumber, MWArray 
                            seriesUid, MWArray seriesNumber, MWArray seriesDescription, 
                            MWArray headerTemplate, MWArray fileName)
    {
      mcr.EvaluateFunction(0, "WriteT1MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate, fileName);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteT1MapAsDicom(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteT1MapAsDicom", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteT1MapAsDicom(int numArgsOut, MWArray image)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteT1MapAsDicom", image);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteT1MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteT1MapAsDicom", image, instanceNumber);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteT1MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteT1MapAsDicom", image, instanceNumber, seriesUid);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteT1MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid, MWArray seriesNumber)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteT1MapAsDicom", image, instanceNumber, seriesUid, seriesNumber);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteT1MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid, MWArray seriesNumber, 
                                 MWArray seriesDescription)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteT1MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteT1MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid, MWArray seriesNumber, 
                                 MWArray seriesDescription, MWArray headerTemplate)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteT1MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate);
    }


    /// <summary>
    /// Provides the standard 7-input MWArray interface to the WriteT1MapAsDicom
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// MSU T1 Map Tool plug-in for ClearCanvas ImageViewer
    /// Copyright (C) 2011-2013, Michigan State University
    /// Author:  Matt Latourette
    /// This software modifies the ClearCanvas RIS/PACS open source project.
    /// This program is free software: you can redistribute it and/or modify
    /// it under the terms of the GNU General Public License as published by
    /// the Free Software Foundation, either version 3 of the License, or
    /// (at your option) any later version.
    /// This program is distributed in the hope that it will be useful,
    /// but WITHOUT ANY WARRANTY; without even the implied warranty of
    /// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    /// GNU General Public License for more details.
    /// You should have received a copy of the GNU General Public License
    /// along with this program.  If not, see &lt;http://www.gnu.org/licenses/>.
    /// Filename:  WriteT1AsDicom.m
    /// Created:  2011
    /// Description:  Writes the specified image as a DICOM file, including
    /// attributes that are appropriate for a T1 map, and taking any 
    /// attributes that are to remain unchanged from the source images from 
    /// the supplied header template.  The series instance UID and the 
    /// series number to be used for the new image are specified by the 
    /// caller.
    /// Usage:
    /// WriteT1AsDicom(image, instanceNumber, seriesUid, seriesNumber, ...
    /// seriesDescription, headerTemplate, fileName)
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="image">Input argument #1</param>
    /// <param name="instanceNumber">Input argument #2</param>
    /// <param name="seriesUid">Input argument #3</param>
    /// <param name="seriesNumber">Input argument #4</param>
    /// <param name="seriesDescription">Input argument #5</param>
    /// <param name="headerTemplate">Input argument #6</param>
    /// <param name="fileName">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] WriteT1MapAsDicom(int numArgsOut, MWArray image, MWArray 
                                 instanceNumber, MWArray seriesUid, MWArray seriesNumber, 
                                 MWArray seriesDescription, MWArray headerTemplate, 
                                 MWArray fileName)
    {
      return mcr.EvaluateFunction(numArgsOut, "WriteT1MapAsDicom", image, instanceNumber, seriesUid, seriesNumber, seriesDescription, headerTemplate, fileName);
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
