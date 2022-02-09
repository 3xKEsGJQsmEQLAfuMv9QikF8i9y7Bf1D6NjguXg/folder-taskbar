using System;

namespace FolderTaskbarFW.DataTypes
{
    internal class FolderWindow
    {
        public IntPtr HWnd { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public FolderWindow()
        {
        }

        public FolderWindow(IntPtr hWnd, string name, string path)
        {
            HWnd = hWnd;
            Name = name;
            Path = path;
        }
    }
}
