using System;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace DoListy.ViewModel
{

    public class ColorNameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string colorName)
            {
                switch (colorName.ToLower())
                {
                    case "blue":
                        return new SolidColorBrush(Colors.Blue);
                    case "red":
                        return new SolidColorBrush(Colors.Red);
                    case "green":
                        return new SolidColorBrush(Colors.Green);
                    case "orange":
                        return new SolidColorBrush(Colors.Orange);
                    case "purple":
                        return new SolidColorBrush(Colors.Purple);
                    default:
                        return new SolidColorBrush(Colors.Gray);
                }
            }

            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
