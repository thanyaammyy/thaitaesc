using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Trirand.Web.UI.WebControls
{
	public class JQAutoComplete : CompositeDataBoundControl
	{
		[Category("Functionality"), DefaultValue(SearchOperation.BeginsWith), Description("The autocomplete mode - BeginsWith or Contains. Default is BeginsWith")]
		public SearchOperation SearchOperation
		{
			get
			{
				object obj = this.ViewState["SearchOperation"];
				if (obj == null)
				{
					return SearchOperation.BeginsWith;
				}
				return (SearchOperation)obj;
			}
			set
			{
				this.ViewState["SearchOperation"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(""), Description("The data-field (column) in the datasource to search against.")]
		public string DataTextField
		{
			get
			{
				object obj = this.ViewState["DataTextField"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["DataTextField"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(""), Description("The Url the autocomplete uses to fetch its data from server")]
		public string DataUrl
		{
			get
			{
				object obj = this.ViewState["DataUrl"];
				if (obj != null)
				{
					return (string)obj;
				}
				if (base.DesignMode)
				{
					return "";
				}
				return HttpContext.Current.Request.Url.PathAndQuery;
			}
			set
			{
				this.ViewState["DataUrl"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(300), Description("The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive. Default is 300")]
		public int Delay
		{
			get
			{
				object obj = this.ViewState["Delay"];
				if (obj == null)
				{
					return 300;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["Delay"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(AutoCompleteDisplayMode.Standalone), Description("The display mode of the autocomplete control. Standalone means datepicker is used as a standalone control. ControlEditor means that the datepicker is used inside another control as field editor, for example inside JQGrid. Default is Standalone")]
		public AutoCompleteDisplayMode DisplayMode
		{
			get
			{
				object obj = this.ViewState["AutoCompleteDisplayMode"];
				if (obj == null)
				{
					return AutoCompleteDisplayMode.Standalone;
				}
				return (AutoCompleteDisplayMode)obj;
			}
			set
			{
				this.ViewState["AutoCompleteDisplayMode"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(1), Description("The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items. Default is 1.")]
		public int MinLength
		{
			get
			{
				object obj = this.ViewState["MinLength"];
				if (obj == null)
				{
					return 1;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["MinLength"] = value;
			}
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
		public JQAutoComplete()
		{
			this.SearchOperation = SearchOperation.BeginsWith;
			this.DataTextField = "";
			this.DataSource = null;
			this.DataUrl = "";
			this.Delay = 300;
			this.DisplayMode = AutoCompleteDisplayMode.Standalone;
			this.Enabled = true;
			this.ID = "";
			this.MinLength = 1;
		}
		protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
		{
			return 0;
		}
		public override void DataBind()
		{
		}
		private void OnDataSourceViewSelectCallback(IEnumerable retrievedData)
		{
			DataView defaultView = retrievedData.ToDataTable(this).DefaultView;
			string searchString = HttpContext.Current.Request.QueryString["term"];
			DataFiltering dataFiltering = new DataFiltering();
			defaultView.RowFilter = dataFiltering.GetFilterExpression(this.SearchOperation, this.DataTextField, searchString, typeof(string));
			List<string> obj = defaultView.ToListOfString(this);
			HttpContext.Current.Response.SendResponse(new JavaScriptSerializer().Serialize(obj));
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			if (this.Page != null && this.IsAutoCompleteRequest())
			{
				this.GetData().Select(new DataSourceSelectArguments(), new DataSourceViewSelectCallback(this.OnDataSourceViewSelectCallback));
			}
		}
		protected override void Render(HtmlTextWriter writer)
		{
			if (DateTime.Now > CompiledOn.CompilationDate.AddDays(45.0))
			{
				writer.Write("This is a trial version of jqSuite for ASP.NET which has expired.<br> Please, contact sales@trirand.net for purchasing the product or for trial extension.");
				return;
			}
			Guard.IsNullOrEmpty(this.ID, "You have to set ID for this JQAutoComplete instance.");
			Guard.IsNullOrEmpty(this.DataTextField, "DataTextField", "DataTextField should be set to the datafield (column) of the datasource to search in.");
			Guard.IsTrue(this.SearchOperation != SearchOperation.BeginsWith && this.SearchOperation != SearchOperation.Contains, "SearchOperation: Currently only BeginsWith and Contains are supported as valid search operations.");
			if (!base.DesignMode)
			{
				JQAutoCompleteRenderer jQAutoCompleteRenderer = new JQAutoCompleteRenderer(this);
				writer.Write(jQAutoCompleteRenderer.RenderHtml());
			}
		}
		private bool IsAutoCompleteRequest()
		{
			string text = HttpContext.Current.Request.QueryString["jqAutoCompleteID"];
			return !string.IsNullOrEmpty(text) && text == this.GetID();
		}
		internal string GetID()
		{
			if (this.DisplayMode != AutoCompleteDisplayMode.ControlEditor)
			{
				return this.ClientID;
			}
			return this.ID;
		}
	}
}
