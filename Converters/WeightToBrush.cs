using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace example_8_server.Converters {
	class WeightToBrush : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			int weight = (int)value;

			if(weight > 500) {
				return new SolidColorBrush(Colors.Red);
			} else {
				return new SolidColorBrush(Colors.Blue);
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
