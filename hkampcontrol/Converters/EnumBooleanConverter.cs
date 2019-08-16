using System;
using Windows.UI.Xaml.Data;

namespace hkampcontrol.Converters
{
    public abstract class EnumBooleanConverter<T> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Enum.Parse(typeof(T), parameter as string).Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Enum.Parse(typeof(T), parameter as string);
        }
    }
}