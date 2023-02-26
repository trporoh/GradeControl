using Avalonia.Data.Converters;
using Avalonia.Data;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTable.Converters
{
    public class ScoreToSolidColorBrushConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is ushort mark)
            {
                if (targetType.IsAssignableTo(typeof(IBrush)))
                {
                    switch (mark)
                    {
                        case 0: return new SolidColorBrush(Colors.Red);
                        case 1: return new SolidColorBrush(Colors.Yellow);
                        case 2: return new SolidColorBrush(Colors.Green);
                        default: break;
                    }
                }
            }
            if (value is float average_mark)
            {
                if (targetType.IsAssignableTo(typeof(IBrush)))
                {
                    if (average_mark < 1) return new SolidColorBrush(Colors.Red);
                    if (average_mark < 1.5) return new SolidColorBrush(Colors.Yellow);
                    else return new SolidColorBrush(Colors.Green);
                }
            }
            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
