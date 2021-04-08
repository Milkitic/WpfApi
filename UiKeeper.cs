using System;
using System.Windows;

namespace Milki.Utils.WPF
{
    /// <summary>
    /// 可保持主线程，防止应用程序退出
    /// </summary>
    public class UiKeeper : IDisposable
    {
        private readonly Window _tempWin;

        public UiKeeper()
        {
            _tempWin = new Window
            {
                WindowStyle = WindowStyle.None,
                Left = -400,
                Top = -400,
                ShowInTaskbar = false,
                Width = 0,
                Height = 0,
                Visibility = Visibility.Hidden
            };
            _tempWin.Show();
        }

        public void Dispose()
        {
            _tempWin?.Close();
        }
    }
}