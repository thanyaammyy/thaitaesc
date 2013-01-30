using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Script.Serialization;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	public class ChartGradientColor
	{
		private GradientStopCollection _stops;
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartLinearGradient LinearGradient
		{
			get;
			set;
		}
		[Category("Settings"), DefaultValue(null), Description("Categories"), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual GradientStopCollection Stops
		{
			get
			{
				if (this._stops == null)
				{
					this._stops = new GradientStopCollection();
				}
				return this._stops;
			}
		}
		public ChartGradientColor()
		{
			this.LinearGradient = new ChartLinearGradient();
		}
		internal string ToJSON()
		{
			return new JavaScriptSerializer().Serialize(this.ToHashtable());
		}
		internal Hashtable ToHashtable()
		{
			Hashtable hashtable = new Hashtable();
			List<object> list = new List<object>();
			string[] value = new string[]
			{
				this.LinearGradient.FromX.ToString(),
				this.LinearGradient.FromY.ToString(),
				this.LinearGradient.ToX.ToString(),
				this.LinearGradient.ToY.ToString()
			};
			int num = 0;
			foreach (GradientStop gradientStop in this.Stops)
			{
				object[] item = new object[]
				{
					num++,
					gradientStop.Value
				};
				list.Add(item);
			}
			hashtable.Add("linearGradient", value);
			hashtable.Add("stops", list);
			return hashtable;
		}
		internal bool IsSet()
		{
			return this.Stops.Count > 0;
		}
	}
}
