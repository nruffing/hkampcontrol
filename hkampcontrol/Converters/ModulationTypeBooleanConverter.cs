using hkampcontrol.Models;
using System;
using Windows.UI.Xaml.Data;

namespace hkampcontrol.Converters
{
    public sealed class ModulationTypeBooleanConverter :  IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Enum.Parse(typeof(ModulationType), parameter as string).Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Enum.Parse(typeof(ModulationType), parameter as string);
        }
    }
}