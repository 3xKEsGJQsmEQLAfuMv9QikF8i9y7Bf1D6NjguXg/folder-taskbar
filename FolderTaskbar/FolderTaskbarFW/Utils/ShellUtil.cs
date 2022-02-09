using FolderTaskbarFW.DataTypes;
using System;
using System.Collections.Generic;
using IE = SHDocVw;
using SHELL = Shell32;

namespace FolderTaskbarFW.Utils
{
    internal class ShellUtil
    {
        public static List<FolderWindow> EnumFolders()
        {
            var shell = new SHELL.Shell();
            var window = shell.Windows();
            var result = new List<FolderWindow>();

            foreach (IE.IWebBrowser2 web in window)
            {
                if (System.IO.Path.GetFileName(web.FullName)
                    .ToLower() != "explorer.exe")
                {
                    continue;
                }

                result.Add(new FolderWindow(
                    (IntPtr)web.HWND,
                    web.LocationName,
                    TrimScheme(web.LocationURL)));
            }

            return result;
        }

        private static string TrimScheme(string value)
        {
            return value.Replace("file:///", "");
        }

    }
}
