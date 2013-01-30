using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
namespace Trirand.Web.UI.WebControls
{
	internal class DataTypeTypeConverter : TypeConverter
	{
		private ArrayList _values;
		public DataTypeTypeConverter()
		{
			this._values = new ArrayList(new string[]
			{
				"String",
				"Int",
				"Decimal",
				"Float",
				"DateTime"
			});
		}
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new TypeConverter.StandardValuesCollection(this._values);
		}
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value.GetType() == typeof(string))
			{
				string text = ((string)value).ToLower();
				string a;
				if ((a = text) != null)
				{
					if (a == "string")
					{
						return typeof(string);
					}
					if (a == "int")
					{
						return typeof(int);
					}
					if (a == "decimal")
					{
						return typeof(decimal);
					}
					if (a == "float")
					{
						return typeof(float);
					}
					if (a == "datetime")
					{
						return typeof(DateTime);
					}
				}
				return typeof(string);
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
