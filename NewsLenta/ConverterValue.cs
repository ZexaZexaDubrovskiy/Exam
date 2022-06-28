using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NewsLenta
{
    public class ConverterValue : IValueConverter
    {
        public static readonly ConverterValue Instanse = new ConverterValue();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) return ((DateTime)value).ToString("dd.MM.yyyy");
            else return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        { return DependencyProperty.UnsetValue; }
    }
}
