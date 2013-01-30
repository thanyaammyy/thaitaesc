using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Trirand.Web.UI.WebControls
{
	[ToolboxData("<{0}:jqchart runat=server></{0}:jqgrid>")]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQChart : WebControl
	{
		[Category("Settings"), Description("Various settings related to the Title of the chart."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartTitleSettings Title
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartTitleSettings SubTitle
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public List<ChartXAxisSettings> XAxis
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public List<ChartYAxisSettings> YAxis
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartLegendSettings Legend
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public List<ChartSeriesSettings> Series
		{
			get;
			set;
		}
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartPlotOptionsSettings PlotOptions
		{
			get;
			set;
		}
		public bool AlignTicks
		{
			get;
			set;
		}
		public bool Animation
		{
			get;
			set;
		}
		public string BackgroundColor
		{
			get;
			set;
		}
		public new string BorderColor
		{
			get;
			set;
		}
		public int BorderRadius
		{
			get;
			set;
		}
		public new int BorderWidth
		{
			get;
			set;
		}
		public string ClassName
		{
			get;
			set;
		}
		public new int Height
		{
			get;
			set;
		}
		public bool IgnoreHiddenSeries
		{
			get;
			set;
		}
		public bool Inverted
		{
			get;
			set;
		}
		public int MarginTop
		{
			get;
			set;
		}
		public int MarginRight
		{
			get;
			set;
		}
		public int MarginBottom
		{
			get;
			set;
		}
		public int MarginLeft
		{
			get;
			set;
		}
		public string PlotBackgroundColor
		{
			get;
			set;
		}
		public string PlotBackgroundImage
		{
			get;
			set;
		}
		public string PlotBorderColor
		{
			get;
			set;
		}
		public int PlotBorderWidth
		{
			get;
			set;
		}
		public bool PlotShadow
		{
			get;
			set;
		}
		public bool Reflow
		{
			get;
			set;
		}
		public bool Shadow
		{
			get;
			set;
		}
		public bool ShowAxes
		{
			get;
			set;
		}
		public int SpacingTop
		{
			get;
			set;
		}
		public int SpacingRight
		{
			get;
			set;
		}
		public int SpacingBottom
		{
			get;
			set;
		}
		public int SpacingLeft
		{
			get;
			set;
		}
		[Category("Settings"), Description("Setting related to the tooltip of the chart datapoints."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public ChartToolTipSettings ToolTips
		{
			get;
			set;
		}
		public ChartType Type
		{
			get;
			set;
		}
		public new int Width
		{
			get;
			set;
		}
		public ChartZoomType ZoomType
		{
			get;
			set;
		}
		internal NameValueCollection ReplaceTable
		{
			get;
			set;
		}
		public JQChart()
		{
			this.AlignTicks = true;
			this.Animation = true;
			this.BackgroundColor = "#FFFFFF";
			this.BorderColor = "#4572A7";
			this.BorderRadius = 5;
			this.BorderWidth = 0;
			this.ClassName = "";
			this.Height = 350;
			this.ID = "";
			this.IgnoreHiddenSeries = true;
			this.Inverted = false;
			this.MarginTop = 0;
			this.MarginRight = 50;
			this.MarginBottom = 70;
			this.MarginLeft = 80;
			this.PlotBackgroundColor = "";
			this.PlotBackgroundImage = "";
			this.PlotBorderColor = "#C0C0C0";
			this.PlotBorderWidth = 0;
			this.PlotShadow = true;
			this.Reflow = true;
			this.SpacingBottom = 15;
			this.SpacingLeft = 10;
			this.SpacingRight = 10;
			this.SpacingTop = 10;
			this.ToolTips = new ChartToolTipSettings();
			this.Type = ChartType.Line;
			this.Width = 350;
			this.ZoomType = ChartZoomType.None;
			this.Title = new ChartTitleSettings();
			this.SubTitle = new ChartTitleSettings();
			this.XAxis = new List<ChartXAxisSettings>();
			this.YAxis = new List<ChartYAxisSettings>();
			this.Legend = new ChartLegendSettings();
			this.PlotOptions = new ChartPlotOptionsSettings();
			this.Series = new List<ChartSeriesSettings>();
			this.ReplaceTable = new NameValueCollection();
		}
		internal void AddJsonReplacement(string key, string value)
		{
			if (this.ReplaceTable[key] == null)
			{
				this.ReplaceTable.Add(key, value);
			}
		}
		internal string ToJSON()
		{
			Hashtable hashtable = new Hashtable();
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			hashtable.Add("renderTo", this.ID);
			if (!this.AlignTicks)
			{
				hashtable.Add("alignKeys", false);
			}
			if (!this.Animation)
			{
				hashtable.Add("animation", false);
			}
			if (this.BackgroundColor != "#FFFFFF")
			{
				hashtable.Add("backgroundColor", this.BackgroundColor);
			}
			if (this.BorderColor != "#4572A7")
			{
				hashtable.Add("borderColor", this.BorderColor);
			}
			if (this.BorderRadius != 5)
			{
				hashtable.Add("borderRadius", this.BorderRadius);
			}
			if (this.BorderWidth != 0)
			{
				hashtable.Add("borderWidth", this.BorderWidth);
			}
			if (!string.IsNullOrEmpty(this.ClassName))
			{
				hashtable.Add("className", this.ClassName);
			}
			if (this.Height != 0)
			{
				hashtable.Add("height", this.Height);
			}
			if (!this.IgnoreHiddenSeries)
			{
				hashtable.Add("IgnoreHiddenSeries", false);
			}
			if (this.Inverted)
			{
				hashtable.Add("inverted", true);
			}
			if (this.MarginBottom != 70)
			{
				hashtable.Add("marginBottom", this.MarginBottom);
			}
			if (this.MarginLeft != 80)
			{
				hashtable.Add("marginLeft", this.MarginLeft);
			}
			if (this.MarginRight != 50)
			{
				hashtable.Add("marginRight", this.MarginRight);
			}
			if (this.MarginTop != 0)
			{
				hashtable.Add("marginTop", this.MarginTop);
			}
			if (!string.IsNullOrEmpty(this.PlotBackgroundColor))
			{
				hashtable.Add("plotBackgroundColor", this.PlotBackgroundColor);
			}
			if (!string.IsNullOrEmpty(this.PlotBackgroundImage))
			{
				hashtable.Add("plotBackgroundImage", this.PlotBackgroundImage);
			}
			if (this.PlotBorderColor != "#C0C0C0")
			{
				hashtable.Add("plotBorderColor", this.PlotBorderColor);
			}
			if (this.PlotBorderWidth != 0)
			{
				hashtable.Add("plotBorderWidth", this.PlotBorderWidth);
			}
			if (!this.PlotShadow)
			{
				hashtable.Add("plotShadow", false);
			}
			if (!this.Reflow)
			{
				hashtable.Add("reflow", false);
			}
			if (this.Shadow)
			{
				hashtable.Add("shadow", true);
			}
			if (this.SpacingBottom != 15)
			{
				hashtable.Add("spacingBottom", this.SpacingBottom);
			}
			if (this.SpacingLeft != 10)
			{
				hashtable.Add("spacingLeft", this.SpacingLeft);
			}
			if (this.SpacingRight != 10)
			{
				hashtable.Add("spacingRight", this.SpacingRight);
			}
			if (this.SpacingTop != 10)
			{
				hashtable.Add("spacingTop", this.SpacingTop);
			}
			hashtable.Add("defaultSeriesType", this.Type.ToString().ToLower());
			if (this.Width != 0)
			{
				hashtable.Add("width", this.Width);
			}
			if (this.ZoomType != ChartZoomType.None)
			{
				hashtable.Add("zoomType", this.ZoomType.ToString().ToLower());
			}
			return javaScriptSerializer.Serialize(hashtable);
		}
		internal string SeriesToJSON()
		{
			List<Hashtable> list = new List<Hashtable>();
			foreach (ChartSeriesSettings current in this.Series)
			{
				Hashtable hashtable = current.ToHashtable(this);
				if (current.Data.Count > 0)
				{
					List<object> list2 = new List<object>();
					foreach (ChartPoint chartPoint in current.Data)
					{
						if (!chartPoint.Y.HasValue)
						{
							list2.Add(chartPoint.X);
						}
						else
						{
							list2.Add(chartPoint.ToHashtable(this));
						}
					}
					hashtable.Add("data", list2);
				}
				list.Add(hashtable);
			}
			return new JavaScriptSerializer().Serialize(list);
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			JQChartRenderer jQChartRenderer = new JQChartRenderer(this);
			string startupJavascript = jQChartRenderer.GetStartupJavascript();
			ScriptManager.RegisterStartupScript(this, typeof(JQChart), "_jqchart_startup" + this.ClientID, startupJavascript, false);
		}
		protected override void Render(HtmlTextWriter writer)
		{
			JQChartRenderer jQChartRenderer = new JQChartRenderer(this);
			writer.Write(jQChartRenderer.RenderHtml());
			base.Render(writer);
		}
		public JQChartExportData GetExportData()
		{
			NameValueCollection form = HttpContext.Current.Request.Form;
			JQChartExportData jQChartExportData = new JQChartExportData();
			if (form["type"] != null)
			{
				jQChartExportData.Type = form["type"];
			}
			if (form["width"] != null)
			{
				jQChartExportData.Width = Convert.ToInt32(form["width"]);
			}
			if (form["filename"] != null)
			{
				jQChartExportData.FileName = form["filename"];
			}
			if (form["svg"] != null)
			{
				jQChartExportData.SvgStream = new MemoryStream(Encoding.ASCII.GetBytes(form["svg"]));
				jQChartExportData.ExportActive = true;
			}
			return jQChartExportData;
		}
	}
}
