using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	public class ChartPoint : BaseItem
	{
		public double? X
		{
			get;
			set;
		}
		public double? Y
		{
			get;
			set;
		}
		public DateTime? XDate
		{
			get;
			set;
		}
		public DateTime? YDate
		{
			get;
			set;
		}
		public string Text
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartMarkerSettings Marker
		{
			get;
			set;
		}
		public bool Sliced
		{
			get;
			set;
		}
		public bool Selected
		{
			get;
			set;
		}
		public string Color
		{
			get;
			set;
		}
		public ChartPoint()
		{
			this.X = null;
			this.Y = null;
			this.XDate = null;
			this.YDate = null;
			this.Text = null;
			this.Marker = new ChartMarkerSettings();
			this.Sliced = false;
			this.Selected = false;
			this.Color = "";
		}
		public ChartPoint(double? x) : this()
		{
			this.X = x;
		}
		public ChartPoint(double? x, double? y) : this()
		{
			this.X = x;
			this.Y = y;
		}
		internal object GetXJson(JQChart chart)
		{
			if (this.XDate.HasValue)
			{
				string text = string.Format("Date.UTC({0},{1},{2})", this.XDate.Value.Year, this.XDate.Value.Month - 1, this.XDate.Value.Day);
				chart.AddJsonReplacement(string.Format("\"{0}\"", text), text);
				return text;
			}
			if (!string.IsNullOrEmpty(this.Text))
			{
				return this.Text;
			}
			return this.X;
		}
		internal object GetYJson(JQChart chart)
		{
			if (this.YDate.HasValue)
			{
				string text = string.Format("Date.UTC({0},{1},{2})", this.YDate.Value.Year, this.YDate.Value.Month - 1, this.YDate.Value.Day);
				chart.AddJsonReplacement(string.Format("\"{0}\"", text), text);
				return text;
			}
			return this.Y;
		}
		internal Hashtable ToHashtable(JQChart chart)
		{
			Hashtable hashtable = new Hashtable();
			if (this.X.HasValue || this.XDate.HasValue || this.Text != null)
			{
				hashtable.Add("x", this.GetXJson(chart));
				hashtable.Add("name", this.GetXJson(chart));
			}
			if (this.Y.HasValue)
			{
				hashtable.Add("y", this.GetYJson(chart));
			}
			if (this.Marker.IsSet())
			{
				hashtable.Add("marker", this.Marker.ToHashtable());
			}
			if (this.Sliced)
			{
				hashtable.Add("sliced", true);
			}
			if (this.Selected)
			{
				hashtable.Add("selected", true);
			}
			if (!string.IsNullOrEmpty(this.Color))
			{
				hashtable.Add("color", this.Color);
			}
			return hashtable;
		}
	}
}
