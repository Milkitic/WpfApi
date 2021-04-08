using System;
using System.Windows;
using System.Windows.Markup;
using System.Xaml;

namespace Milki.Utils.WPF
{
    [MarkupExtensionReturnType(typeof(FrameworkElement))]
    public class RootObject : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var rootObjectProvider = (IRootObjectProvider)serviceProvider.GetService(typeof(IRootObjectProvider));
            return rootObjectProvider?.RootObject;
        }
    }
}