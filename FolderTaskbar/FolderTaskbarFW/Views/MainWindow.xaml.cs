using FolderTaskbarFW.DataTypes;
using FolderTaskbarFW.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FolderTaskbarFW.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI(ShellUtil.EnumFolders());
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                UpdateUI(ShellUtil.EnumFolders());
            }
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateUI(ShellUtil.EnumFolders());
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TaskButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = sender as Button;

                if (btn is null ||
                    btn.Tag is null)
                {
                    return;
                }

                var h = (IntPtr)btn.Tag;

                if (Keyboard.Modifiers ==
                    (ModifierKeys.Control | ModifierKeys.Shift))
                {
                    WindowUtil.CloseWindow(h);

                    UpdateUI(ShellUtil.EnumFolders());
                }
                else
                {
                    WindowUtil.ActivateWindow(h);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            if (150 < Left &&
                Width < Left)
            {
                Left -= Width;
            }
            else
            {
                Left += Width;
            }
        }

        private void UpdateUI(in List<FolderWindow> folders)
        {
            Container.Children.Clear();
            foreach (var folder in folders)
            {
                var btn = new Button
                {
                    Content = folder.Name,
                    Tag = folder.HWnd,
                    ToolTip = folder.Path,
                };

                Container.Children.Add(btn);
            }
            SizeToContent = SizeToContent.Height;
        }

    }
}
