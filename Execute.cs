using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Milky.WpfApi
{
    public static class Execute
    {
        public static void OnUiThread(this Action action)
        {
            Application.Current.Dispatcher.Invoke(() => { action?.Invoke(); });
        }
		
        public static void ToUiThread(this Action action)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { action?.Invoke(); }), DispatcherPriority.Normal);
        }
    }
}
