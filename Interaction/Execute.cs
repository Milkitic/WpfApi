using System;
using System.Threading.Tasks;
using System.Windows;

namespace Milki.Utils.WPF.Interaction
{
    public static class Execute
    {
        public static async Task OnUiThreadAsync(Func<Task> asyncAction)
        {
            if (Application.Current?.Dispatcher != null)
            {
                await Application.Current.Dispatcher.InvokeAsync(asyncAction);
            }
            else
            {
                try
                {
                    if (asyncAction != null) await asyncAction.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UiContext execute error: " + ex.Message);
                }
            }
        }

        public static async Task OnUiThreadAsync(Action action)
        {
            if (Application.Current?.Dispatcher != null)
            {
                await Application.Current.Dispatcher.InvokeAsync(action);
            }
            else
            {
                try
                {
                    action?.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UiContext execute error: " + ex.Message);
                }
            }
        }

        public static void OnUiThread(this Action action)
        {
            if (Application.Current?.Dispatcher != null)
            {
                Application.Current.Dispatcher.Invoke(action);
            }
            else
            {
                try
                {
                    action?.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UiContext execute error: " + ex.Message);
                }
            }
        }
    }
}
