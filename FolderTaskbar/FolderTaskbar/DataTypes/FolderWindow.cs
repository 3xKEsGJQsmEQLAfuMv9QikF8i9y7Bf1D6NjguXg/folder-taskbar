using System;

namespace FolderTaskbar.DataTypes
{
    internal record FolderWindow(IntPtr HWnd, string Name, string Path);
}
