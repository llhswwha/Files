// Copyright (c) Files Community
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace Files.App.Converters
{
	internal sealed partial class EnumToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null || parameter == null)
				return false;

			return value.ToString() == parameter.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			if (value is bool isChecked && isChecked && parameter is string enumString)
			{
				try
				{
					// Use Enum.Parse but ensure the returned value matches the expected targetType
					return Enum.Parse(targetType, enumString);
				}
				catch
				{
					return DependencyProperty.UnsetValue;
				}
			}

			// Return the existing value from the binding source to avoid triggering an update
			// that WinRT might try to unbox into the wrong type during a TwoWay binding update.
			return DependencyProperty.UnsetValue;
		}
	}
}
