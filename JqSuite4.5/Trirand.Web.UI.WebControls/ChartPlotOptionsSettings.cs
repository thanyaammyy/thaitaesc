using System;
using System.Collections;
using System.ComponentModel;
using System.Web.Script.Serialization;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	public class ChartPlotOptionsSettings
	{
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartAreaSettings Area
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartAreaSplineSettings AreaSpline
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartBarSettings Bar
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartColumnSettings Column
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartLineSettings Line
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartPieSettings Pie
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartSeriesPlotSettings Series
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartScatterSettings Scatter
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartSplineSettings Spline
		{
			get;
			set;
		}
		public ChartPlotOptionsSettings()
		{
			this.Area = new ChartAreaSettings();
			this.AreaSpline = new ChartAreaSplineSettings();
			this.Bar = new ChartBarSettings();
			this.Column = new ChartColumnSettings();
			this.Line = new ChartLineSettings();
			this.Pie = new ChartPieSettings();
			this.Series = new ChartSeriesPlotSettings();
			this.Scatter = new ChartScatterSettings();
			this.Spline = new ChartSplineSettings();
		}
		internal string ToJSON(JQChart chart)
		{
			return new JavaScriptSerializer().Serialize(this.ToHashtable(chart));
		}
		internal Hashtable ToHashtable(JQChart chart)
		{
			return new Hashtable
			{

				{
					"area",
					this.Area.ToHashtable(chart)
				},

				{
					"areaspline",
					this.AreaSpline.ToHashtable(chart)
				},

				{
					"bar",
					this.Bar.ToHashtable(chart)
				},

				{
					"column",
					this.Column.ToHashtable(chart)
				},

				{
					"line",
					this.Line.ToHashtable(chart)
				},

				{
					"pie",
					this.Pie.ToHashtable(chart)
				},

				{
					"series",
					this.Series.ToHashtable()
				},

				{
					"scatter",
					this.Scatter.ToHashtable(chart)
				},

				{
					"spline",
					this.Spline.ToHashtable(chart)
				}
			};
		}
	}
}
