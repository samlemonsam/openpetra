//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       timop
//
// Copyright 2004-2010 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using GNU.Gettext;
using Ict.Common;

namespace Ict.Tools.PatchTool
{
/// <summary>
/// Main program
/// </summary>
    public class Program
    {
        /// <summary>
        /// static main function
        /// </summary>
        public static void Main(string[] args)
        {
            try
            {
                // check command line
                TAppSettingsManager appOpts = new TAppSettingsManager(false);
                string TempPath = appOpts.GetValue("OpenPetra.PathTemp").
                                  Replace("{userappdata}",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

                new TLogging(TempPath + Path.DirectorySeparatorChar + "PetraPatch.log");

                if (!appOpts.HasValue("action"))
                {
                    System.Console.WriteLine(
                        "patch creation:    patchtool -action:create -OpenPetra.PathTemp:u:/tmp/patch -deliverypath:u:/delivery -oldversion:0.0.8-0 -newversion:0.0.10-0");
                    System.Console.WriteLine(
                        "patch application: patchtool -action:apply -OpenPetra.PathTemp:u:/tmp/patch -diffzip:u:/tmp/patch/Patch2.2.3-5_2.2.4-3.zip -apppath:c:/Programme/OpenPetra.org -datpath:c:/Programme/OpenPetra.org/data30");
                    return;
                }

                String action = appOpts.GetValue("action");

                if (action.Equals("create"))
                {
                    PatchCreation.CreateDiff(TempPath,
                        appOpts.GetValue("deliverypath"),
                        appOpts.GetValue("appname"),
                        appOpts.GetValue("oldversion"),
                        appOpts.GetValue("newversion"));
                }
                else
                {
                    if (action.Equals("preparePatch"))
                    {
                        // to be called before installing the patch;
                        // will only copy the files if there is a new patch available
                        TPetraPatchTools patchTools = new TPetraPatchTools(appOpts.GetValue("OpenPetra.Path"),
                            TempPath,
                            "",
                            "",
                            appOpts.GetValue("OpenPetra.Path.Patches"),
                            "");

                        if (patchTools.CheckForRecentPatch())
                        {
                            patchTools.CopyLatestPatchProgram(appOpts.GetValue("OpenPetra.PathTemp"));
                        }
                        else
                        {
                            System.Console.WriteLine(Catalog.GetString("There is no new patch to be installed."));
                            System.Environment.Exit(-1);
                        }
                    }
                    else if (action.Equals("patchRemote"))
                    {
                        // basically the same as patchFiles, but will use the status window.
                        PatchApplication.PatchRemoteInstallation(appOpts);
                    }
                    else if (action.Equals("patchFiles"))
                    {
                        // need to call first preparePatch;
                        // and then run the patch from TmpPatchPath so that the files can be overwritten
                        // this will patch the application files
                        TPetraPatchTools patchTools = new TPetraPatchTools(appOpts.GetValue("OpenPetra.Path"),
                            TempPath,
                            appOpts.GetValue("OpenPetra.Path.Dat"),
                            "",
                            appOpts.GetValue("OpenPetra.Path.Patches"),
                            "");

                        if (patchTools.CheckForRecentPatch())
                        {
                            if (!patchTools.PatchTheFiles())
                            {
                                System.Console.WriteLine(Catalog.GetString("There was a problem installing the patch."));
                                System.Environment.Exit(-1);
                            }
                        }
                        else
                        {
                            if ((!patchTools.GetCurrentPatchVersion().Equals(patchTools.GetLatestPatchVersion())))
                            {
                                System.Console.WriteLine(Catalog.GetString(
                                        "You don't have all patches that are necessary for patching to the latest patch."));
                                System.Environment.Exit(-1);
                            }
                            else
                            {
                                System.Console.WriteLine(Catalog.GetString("There is no new patch to be installed."));
                                System.Environment.Exit(-1);
                            }
                        }
                    }
                    else if (action.Equals("patchDatabase"))
                    {
                        // this should only be called after patchFiles;
                        // this will possibly change the database structure, and modify database content
                        TPetraPatchTools patchTools = new TPetraPatchTools(appOpts.GetValue("OpenPetra.Path"),
                            TempPath,
                            "",
                            "",
                            appOpts.GetValue("OpenPetra.Path.Patches"),
                            "");

                        patchTools.RunDBPatches();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                TLogging.Log(e.Message, TLoggingType.ToLogfile);
                TLogging.Log(e.StackTrace, TLoggingType.ToLogfile);
            }
        }
    }
}