using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExamSearchBank.Convertor
{
    class HourConvertor:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TimeSpan tm = (TimeSpan)value;
            return string.Format("{0}", tm.Hours);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string temp = (string)value;
            TimeSpan tm = new TimeSpan(Int32.Parse(temp), 0, 0);
            return tm;
        }
    }
}
