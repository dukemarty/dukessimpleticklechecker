using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

    public class ElementTypeSymbolConverter : IValueConverter
    {
        private static readonly BitmapImage SymbolUnknown = new BitmapImage(new Uri("pack://application:,,,/SimpleTIckleChecker;component/Resources/2674089 - emotion essential object sad ui web.png"));
        private static readonly BitmapImage SymbolFile = new BitmapImage(new Uri("pack://application:,,,/SimpleTIckleChecker;component/Resources/2674100 - document essential object ui web.png"));
        private static readonly BitmapImage SymbolDirectory = new BitmapImage(new Uri("pack://application:,,,/SimpleTIckleChecker;component/Resources/2674093 - essential folder object ui web.png"));
        private static readonly BitmapImage SymbolLink = new BitmapImage(new Uri("pack://application:,,,/SimpleTIckleChecker;component/Resources/2674058 - bookmark essential object ui web.png"));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (ElementType)value;

            object res = null;
            switch (val)
            {
                case ElementType.File:
                    res = SymbolFile;
                    break;
                case ElementType.Directory:
                    res = SymbolDirectory;
                    break;
                case ElementType.Link:
                    res = SymbolLink;
                    break;
                case ElementType.Unknown:
                    res = SymbolUnknown;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
