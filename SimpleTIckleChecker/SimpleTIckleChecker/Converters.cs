using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SimpleTIckleChecker
{
    public class ColorStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as string;

            if (string.IsNullOrWhiteSpace(val)) { return Colors.DeepPink; }
            if (!val.StartsWith("#")) { return Colors.DeepPink; }

            var a = byte.Parse(val.Substring(1, 2), NumberStyles.AllowHexSpecifier);
            var r = byte.Parse(val.Substring(3, 2), NumberStyles.AllowHexSpecifier);
            var g = byte.Parse(val.Substring(5, 2), NumberStyles.AllowHexSpecifier);
            var b = byte.Parse(val.Substring(7, 2), NumberStyles.AllowHexSpecifier);

            return Color.FromArgb(a, r, g, b);
        }

        public object ConvertBack(object value, Type targeType, object parameter, CultureInfo culture)
        {
            var val = (Color)value;

            return $"#{val.A:X2}{val.R:X2}{val.G:X2}{val.B:X2}";
        }
    }

    public class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (bool)value;

            return val ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
