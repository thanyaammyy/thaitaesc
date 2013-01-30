using System;
using System.ComponentModel;
using System.Globalization;
namespace Trirand.Web.UI.WebControls.TypeConverters
{
	public class PointConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				double num = Convert.ToDouble((string)value);
				return num;
			}
			return base.ConvertFrom(context, culture, value);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return Convert.ToString((double)value);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
