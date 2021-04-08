using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Milki.Utils.WPF
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

        [Obsolete("use OnUiThreadAsync() instead", true)]
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

        //public static async Task OnUiThreadAsync(this Func<Task> action)
        //{
        //    if (_uiContext == null)
        //    {
        //        if (Application.Current?.Dispatcher != null)
        //        {
        //            await Application.Current.Dispatcher.InvokeAsync(action);
        //        }
        //        else
        //        {
        //            try
        //            {
        //                if (action != null) await action();
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("UiContext execute error: " + ex.Message);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        _uiContext.Send(obj => { action?.Invoke(); }, null);
        //    }
        //}

        [Obsolete("use OnUiThreadAsync() instead", true)]
        public static void ToUiThread(this Action action, Action callBack = null)
        {
            if (Application.Current?.Dispatcher != null)
            {
                object executed = false;
                object @lock = new object();
                var result = Application.Current?.Dispatcher?.BeginInvoke(action, DispatcherPriority.Normal);

                result.Completed += (sender, e) =>
                {
                    lock (@lock)
                    {
                        if ((bool)executed) return;
                        executed = true;
                    }

                    callBack?.Invoke();
                };

                if (result.Status == DispatcherOperationStatus.Completed)
                {
                    lock (@lock)
                    {
                        if ((bool)executed) return;
                        executed = true;
                    }

                    callBack?.Invoke();
                }
            }
            else
            {
                try
                {
                    action?.BeginInvoke(ar => callBack?.Invoke(), null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UiContext execute error: " + ex.Message);
                }
            }
        }
    }
}
