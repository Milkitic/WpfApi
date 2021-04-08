using System;
using System.Windows.Markup;

namespace Milki.Utils.WPF
{
    public class GenericType : MarkupExtension
    {
        public Type BaseType { get; set; }
        public Type[] InnerTypes { get; set; }

        public GenericType() { }
        public GenericType(Type baseType, params Type[] innerTypes)
        {
            BaseType = baseType;
            InnerTypes = innerTypes;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            Type result = BaseType.MakeGenericType(InnerTypes);
            return result;
        }
    }
}