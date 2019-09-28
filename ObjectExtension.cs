using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Milky.WpfApi
{
    public static class ObjectExtension
    {
        public static T GetParentObjectByName<T>(this DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);
            while (parent != null)
            {
                if (parent is T && (((T)parent).Name == name || string.IsNullOrEmpty(name)))
                {
                    return (T)parent;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        public static FrameworkElement GetParentObject(this FrameworkElement obj, params Type[] types)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);
            while (parent != null)
            {
                if (parent is FrameworkElement fe)
                {
                    var type = fe.GetType();
                    if (types.Any(k => type.IsSubclassOf(k)))
                    {
                        return fe;
                    }
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }
}