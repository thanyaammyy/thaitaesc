using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Trirand.Web.UI.WebControls
{
	[ToolboxData("<{0}:jqdatepicker runat=server></{0}:jqgrid>")]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQDatePicker : WebControl
	{
		[Category("Functionality"), DefaultValue(true), Description("Enables (true) or disabled (false) the datepicker. Can be set when initialising (first creating) the datepicker. Default is true")]
		public new bool Enabled
		{
			get
			{
				object obj = this.ViewState["Enabled"];
				return obj == null || (bool)obj;
			}
			set
			{
				this.ViewState["Enabled"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(""), Description("The jQuery selector for another field that is to be updated with the selected date from the datepicker. Use the AltFormat setting to change the format of the date within this field. Leave as blank for no alternate field")]
		public string AltField
		{
			get
			{
				object obj = this.ViewState["AltField"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["AltField"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(""), Description("The dateFormat to be used for the AltField option. This allows one date format to be shown to the user for selection purposes, while a different format is actually sent behind the scenes. For a full list of the possible formats see the formatDate function")]
		public string AltFormat
		{
			get
			{
				object obj = this.ViewState["AltFormat"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["AltFormat"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(""), Description("The text to display after each date field, e.g. to show the required format.")]
		public string AppendText
		{
			get
			{
				object obj = this.ViewState["AppendText"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["AppendText"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(false), Description("Set to true to automatically resize the input field to accomodate dates in the current DateFormat. Default is false")]
		public bool AutoSize
		{
			get
			{
				object obj = this.ViewState["AutoSize"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["AutoSize"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(""), Description("The URL for the popup button image. If set, ButtonText becomes the alt value and is not directly displayed.")]
		public string ButtonImage
		{
			get
			{
				object obj = this.ViewState["ButtonImage"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["ButtonImage"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(false), Description("Set to true to place an image after the field to use as the trigger without it appearing on a button. Default is false.")]
		public bool ButtonImageOnly
		{
			get
			{
				object obj = this.ViewState["ButtonImageOnly"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ButtonImageOnly"] = value;
			}
		}
		[Category("Functionality"), DefaultValue("..."), Description("The text to display on the trigger button. Use in conjunction with ShowOn equal to 'Button' or 'Both'. Default is '...'")]
		public string ButtonText
		{
			get
			{
				object obj = this.ViewState["ButtonText"];
				if (obj == null)
				{
					return "...";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["ButtonText"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(false), Description("Allows you to change the month by selecting from a drop-down list. You can enable this feature by setting the attribute to true. Default is false.")]
		public bool ChangeMonth
		{
			get
			{
				object obj = this.ViewState["ChangeMonth"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ChangeMonth"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(false), Description("Allows you to change the year by selecting from a drop-down list. You can enable this feature by setting the attribute to true. Use the YearRange option to control which years are made available for selection. Default is false.")]
		public bool ChangeYear
		{
			get
			{
				object obj = this.ViewState["ChangeYear"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ChangeYear"] = value;
			}
		}
		[Category("Functionality"), DefaultValue("Done"), Description("The text to display for the close link. This attribute is one of the regionalisation attributes. Use the ShowButtonPanel to display this button. Default is 'Done'.")]
		public string CloseText
		{
			get
			{
				object obj = this.ViewState["CloseText"];
				if (obj == null)
				{
					return "Done";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["CloseText"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(true), Description("When true entry in the input field is constrained to those characters allowed by the current DateFormat. Default is true.")]
		public bool ConstrainInput
		{
			get
			{
				object obj = this.ViewState["ConstrainInput"];
				return obj == null || (bool)obj;
			}
			set
			{
				this.ViewState["ConstrainInput"] = value;
			}
		}
		[Category("Functionality"), DefaultValue("Today"), Description("The text to display for the current day link. This attribute is one of the regionalisation attributes. Use the ShowButtonPanel to display this button. Default is 'Today'.")]
		public string CurrentText
		{
			get
			{
				object obj = this.ViewState["CurrentText"];
				if (obj == null)
				{
					return "Today";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["CurrentText"] = value;
			}
		}
		[Category("Functionality"), DefaultValue("yyyy/MM/dd"), Description("The format for parsed and displayed dates. This attribute is one of the regionalisation attributes. Default is yyyy/MM/dd")]
		public string DateFormat
		{
			get
			{
				object obj = this.ViewState["DateFormat"];
				if (obj == null)
				{
					return "yyyy/MM/dd";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["DateFormat"] = value;
			}
		}
		public List<string> DayNames
		{
			get;
			set;
		}
		public List<string> DayNamesMin
		{
			get;
			set;
		}
		public List<string> DayNamesShort
		{
			get;
			set;
		}
		public DatePickerDisplayMode DisplayMode
		{
			get;
			set;
		}
		public DateTime? DefaultDate
		{
			get;
			set;
		}
		public int Duration
		{
			get;
			set;
		}
		public int FirstDay
		{
			get;
			set;
		}
		public bool GotoCurrent
		{
			get;
			set;
		}
		public bool HideIfNoPrevNext
		{
			get;
			set;
		}
		public new string ID
		{
			get;
			set;
		}
		public bool IsRTL
		{
			get;
			set;
		}
		public DateTime? MaxDate
		{
			get;
			set;
		}
		public DateTime? MinDate
		{
			get;
			set;
		}
		public List<string> MonthNames
		{
			get;
			set;
		}
		public List<string> MonthNamesShort
		{
			get;
			set;
		}
		public bool NavigationAsDateFormat
		{
			get;
			set;
		}
		public string NextText
		{
			get;
			set;
		}
		public string PrevText
		{
			get;
			set;
		}
		public bool ShowButtonPanel
		{
			get;
			set;
		}
		public bool ShowMonthAfterYear
		{
			get;
			set;
		}
		public ShowOn ShowOn
		{
			get;
			set;
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override string AccessKey
		{
			get
			{
				return base.AccessKey;
			}
			set
			{
				base.AccessKey = value;
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override Color BorderColor
		{
			get
			{
				return base.BorderColor;
			}
			set
			{
				base.BorderColor = value;
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override BorderStyle BorderStyle
		{
			get
			{
				return base.BorderStyle;
			}
			set
			{
				base.BorderStyle = value;
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override Unit BorderWidth
		{
			get
			{
				return base.BorderWidth;
			}
			set
			{
				base.BorderWidth = value;
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override string CssClass
		{
			get
			{
				return base.CssClass;
			}
			set
			{
				base.CssClass = value;
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override FontInfo Font
		{
			get
			{
				return base.Font;
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override short TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				base.TabIndex = value;
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToolTip
		{
			get
			{
				return base.ToolTip;
			}
			set
			{
				base.ToolTip = value;
			}
		}
		public JQDatePicker()
		{
			this.Enabled = true;
			this.AltField = "";
			this.AltFormat = "";
			this.AppendText = "";
			this.AutoSize = false;
			this.ButtonImage = "";
			this.ButtonImageOnly = false;
			this.ButtonText = "...";
			this.ChangeMonth = false;
			this.ChangeYear = false;
			this.CloseText = "Done";
			this.ConstrainInput = true;
			this.CurrentText = "Today";
			this.DateFormat = "yyyy/MM/dd";
			this.DayNames = new List<string>();
			this.DayNamesMin = new List<string>();
			this.DayNamesShort = new List<string>();
			this.DisplayMode = DatePickerDisplayMode.Standalone;
			this.DefaultDate = null;
			this.Duration = 500;
			this.FirstDay = 0;
			this.GotoCurrent = false;
			this.HideIfNoPrevNext = false;
			this.IsRTL = false;
			this.MaxDate = null;
			this.MinDate = null;
			this.MonthNames = new List<string>();
			this.MonthNamesShort = new List<string>();
			this.NavigationAsDateFormat = false;
			this.NextText = "Next";
			this.PrevText = "Prev";
			this.ShowButtonPanel = false;
			this.ShowMonthAfterYear = false;
			this.ShowOn = ShowOn.Both;
		}
		protected override void Render(HtmlTextWriter writer)
		{
			if (!base.DesignMode)
			{
				if (DateTime.Now > CompiledOn.CompilationDate.AddDays(45.0))
				{
					writer.Write("This is a trial version of jqSuite for ASP.NET which has expired.<br> Please, contact sales@trirand.net for purchasing the product or for trial extension.");
					return;
				}
				Guard.IsNullOrEmpty(this.ID, "ID", "You need to set ID for this JQDatePicker instance.");
				JQDatePickerRenderer jQDatePickerRenderer = new JQDatePickerRenderer(this);
				writer.Write(jQDatePickerRenderer.RenderHtml());
			}
		}
		internal string GetID()
		{
			if (this.DisplayMode != DatePickerDisplayMode.ControlEditor)
			{
				return this.ClientID;
			}
			return this.ID;
		}
	}
}
