using System;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace DoListy.ViewModel
{

    public class ColorNameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color temp = Colors.Blue;
            if (value is string colorName)
            {
                if (!string.IsNullOrEmpty(colorName))
                {
                    switch (colorName)
                    {
                        case "Blue":
                            temp = Colors.Blue;
                            break;
                        case "Red":
                            temp = Colors.Red;
                            break;
                        case "Green":
                            temp = Colors.Green;
                            break;
                        case "Orange":
                            temp = Colors.Orange;
                            break;
                        case "Purple":
                            temp = Colors.Purple;
                            break;
                        default:
                            temp = Colors.Blue;
                            break;
                    }
                }
            }
            return temp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
