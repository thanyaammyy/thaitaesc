using System;
using System.ComponentModel;
using System.Globalization;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridColumn : BaseItem
	{
		private JQGridColumnFormatterCollection _formatterCollection;
		private JQGridEditClientSideValidatorCollection _editClientSideValidatorCollection;
		private JQGridEditFieldAttributeCollection _editFieldAttributeCollection;
		private JQGridColumnSearchOptionCollection _searchOptions;
		[Category("Functionality"), DefaultValue(null), Description("The formatter (client-side template) that will be applied to cells of this column."), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public JQGridColumnFormatterCollection Formatter
		{
			get
			{
				if (this._formatterCollection == null)
				{
					this._formatterCollection = new JQGridColumnFormatterCollection();
				}
				return this._formatterCollection;
			}
		}
		[Category("Editing"), DefaultValue(null), Description("The client-side validators that will be applied to the cell value upon editing."), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public JQGridEditClientSideValidatorCollection EditClientSideValidators
		{
			get
			{
				if (this._editClientSideValidatorCollection == null)
				{
					this._editClientSideValidatorCollection = new JQGridEditClientSideValidatorCollection();
				}
				return this._editClientSideValidatorCollection;
			}
		}
		[Category("Editing"), DefaultValue(null), Description("The HTML attributes (name/value pairs) that will be applied to the edit field of the respective column."), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public JQGridEditFieldAttributeCollection EditFieldAttributes
		{
			get
			{
				if (this._editFieldAttributeCollection == null)
				{
					this._editFieldAttributeCollection = new JQGridEditFieldAttributeCollection();
				}
				return this._editFieldAttributeCollection;
			}
		}
		[Category("Searching"), DefaultValue(null), Description("The search options in the search dialog dropdown."), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public JQGridColumnSearchOptionCollection SearchOptions
		{
			get
			{
				if (this._searchOptions == null)
				{
					this._searchOptions = new JQGridColumnSearchOptionCollection();
				}
				return this._searchOptions;
			}
		}
		[Category("Editing"), DefaultValue(false), Description("Shows edit/save/cancel icons in the columns and forces the row in the respective edit actions based on end-user selection"), MergableProperty(false)]
		public bool EditActionIconsColumn
		{
			get
			{
				return base.ViewState["EditActionIconsColumn"] != null && (bool)base.ViewState["EditActionIconsColumn"];
			}
			set
			{
				base.ViewState["EditActionIconsColumn"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(true), Description("Controls if the edit button will be shown in inline editing when EditActionIconsColumn = true")]
		public bool EditActionIconsEditEnabled
		{
			get
			{
				return base.ViewState["EditActionIconsEditEnabled"] == null || (bool)base.ViewState["EditActionIconsEditEnabled"];
			}
			set
			{
				base.ViewState["EditActionIconsEditEnabled"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(true), Description("Controls if the delete button will be shown in inline editing when EditActionIconsColumn = true")]
		public bool EditActionIconsDeleteEnabled
		{
			get
			{
				return base.ViewState["EditActionIconsDeleteEnabled"] == null || (bool)base.ViewState["EditActionIconsDeleteEnabled"];
			}
			set
			{
				base.ViewState["EditActionIconsDeleteEnabled"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(false), Description("Controls if the edit button will launch edit dialog instead of inline editing when EditActionIconsColumn = true")]
		public bool EditActionIconsEditDialogEnabled
		{
			get
			{
				return base.ViewState["EditActionIconsEditDialogEnabled"] != null && (bool)base.ViewState["EditActionIconsEditDialogEnabled"];
			}
			set
			{
				base.ViewState["EditActionIconsEditDialogEnabled"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(150), Description("The width of the column. Supports integers only. Default is 150.")]
		public int Width
		{
			get
			{
				if (base.ViewState["Width"] != null)
				{
					return (int)base.ViewState["Width"];
				}
				return 150;
			}
			set
			{
				base.ViewState["Width"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(true), Description("Controls if the columns can be sorted by clicking on the header. Default is true.")]
		public bool Sortable
		{
			get
			{
				return base.ViewState["Sortable"] == null || (bool)base.ViewState["Sortable"];
			}
			set
			{
				base.ViewState["Sortable"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(true), Description("Controls if the columns can be resized. Default is true.")]
		public bool Resizable
		{
			get
			{
				return base.ViewState["Resizable"] == null || (bool)base.ViewState["Resizable"];
			}
			set
			{
				base.ViewState["Resizable"] = value;
			}
		}
		[Category("Editing"), DefaultValue(false), Description("Determines if the column is editable. Default is false.")]
		public bool Editable
		{
			get
			{
				return base.ViewState["Editable"] != null && (bool)base.ViewState["Editable"];
			}
			set
			{
				base.ViewState["Editable"] = value;
			}
		}
		[Category("Frozen Columns"), DefaultValue(false), Description("Determines if the column is frozen. Default is false.")]
		public bool Frozen
		{
			get
			{
				return base.ViewState["Frozen"] != null && (bool)base.ViewState["Frozen"];
			}
			set
			{
				base.ViewState["Frozen"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(false), Description("Sets the column as a primary key")]
		public bool PrimaryKey
		{
			get
			{
				return base.ViewState["PrimaryKey"] != null && (bool)base.ViewState["PrimaryKey"];
			}
			set
			{
				base.ViewState["PrimaryKey"] = value;
			}
		}
		[Category("Editing"), DefaultValue(EditType.TextBox), Description("The type of the editing field for this column - TextBox, TextArea, DropDown, CheckBox, etc")]
		public EditType EditType
		{
			get
			{
				if (base.ViewState["EditType"] != null)
				{
					return (EditType)base.ViewState["EditType"];
				}
				return EditType.TextBox;
			}
			set
			{
				base.ViewState["EditType"] = value;
			}
		}
		[Category("Editing"), DefaultValue(""), Description("The name of the javascript function that will create the element when EditType = EditType.Custom")]
		public string EditTypeCustomCreateElement
		{
			get
			{
				if (base.ViewState["EditTypeCustomCreateElement"] != null)
				{
					return (string)base.ViewState["EditTypeCustomCreateElement"];
				}
				return "";
			}
			set
			{
				base.ViewState["EditTypeCustomCreateElement"] = value;
			}
		}
		[Category("Editing"), DefaultValue(""), Description(" The name of the javascript function that will get the value from the custom element        ")]
		public string EditTypeCustomGetValue
		{
			get
			{
				if (base.ViewState["EditTypeCustomGetValue"] != null)
				{
					return (string)base.ViewState["EditTypeCustomGetValue"];
				}
				return "";
			}
			set
			{
				base.ViewState["EditTypeCustomGetValue"] = value;
			}
		}
		[Category("Editing"), DefaultValue(""), Description("The list of values when EditType = DropDown. Name/value pairs separated with ':', e.g. 'TNT:TNT;DHL:DHL;UPS:UPS'")]
		public string EditValues
		{
			get
			{
				if (base.ViewState["EditValues"] != null)
				{
					return (string)base.ViewState["EditValues"];
				}
				return "";
			}
			set
			{
				base.ViewState["EditValues"] = value;
			}
		}
		[Category("Editing"), DefaultValue(""), Description("The ID of the server-side asp:dropdownlist to be used for editing"), IDReferenceProperty]
		public string EditorControlID
		{
			get
			{
				if (base.ViewState["EditDropDownListControlID"] != null)
				{
					return (string)base.ViewState["EditDropDownListControlID"];
				}
				return "";
			}
			set
			{
				base.ViewState["EditDropDownListControlID"] = value;
			}
		}
		[Category("Searching"), DefaultValue(SearchType.TextBox), Description("The type of the control to be used for searching - TextBox or DropDown")]
		public SearchType SearchType
		{
			get
			{
				if (base.ViewState["SearchType"] != null)
				{
					return (SearchType)base.ViewState["SearchType"];
				}
				return SearchType.TextBox;
			}
			set
			{
				base.ViewState["SearchType"] = value;
			}
		}
		[Obsolete("SearchDataType is now obsolete. Use DataType instead. At runtime set as JQGridColumn.DataType = typeof(string).", true)]
		public SearchDataType SearchDataType
		{
			get;
			set;
		}
		[Category("Searching"), DefaultValue(null), Description("The type of the data. Need to set it in order to use the auto-search functionality of the grid."), TypeConverter(typeof(DataTypeTypeConverter))]
		public Type DataType
		{
			get
			{
				if (base.ViewState["DataType"] != null)
				{
					return (Type)base.ViewState["DataType"];
				}
				return null;
			}
			set
			{
				base.ViewState["DataType"] = value;
			}
		}
		[Category("Searching"), DefaultValue(""), Description("The list of values when SearchType = DropDown. Name/value pairs separated with ':', e.g. 'TNT:TNT;DHL:DHL;UPS:UPS'")]
		public string SearchValues
		{
			get
			{
				if (base.ViewState["SearchValues"] != null)
				{
					return (string)base.ViewState["SearchValues"];
				}
				return "";
			}
			set
			{
				base.ViewState["SearchValues"] = value;
			}
		}
		[Category("Searching"), DefaultValue(""), Description("The ID of the server-side asp:dropdownlist to be used for searching"), IDReferenceProperty]
		public string SearchControlID
		{
			get
			{
				if (base.ViewState["SearchControlID"] != null)
				{
					return (string)base.ViewState["SearchControlID"];
				}
				return "";
			}
			set
			{
				base.ViewState["SearchControlID"] = value;
			}
		}
		[Category("Editing"), DefaultValue(0), Description("The column in which the edit field for this column will be shown in the Edit Dialog")]
		public int EditDialogColumnPosition
		{
			get
			{
				if (base.ViewState["EditDialogColumnPosition"] != null)
				{
					return (int)base.ViewState["EditDialogColumnPosition"];
				}
				return 0;
			}
			set
			{
				base.ViewState["EditDialogColumnPosition"] = value;
			}
		}
		[Category("Editing"), DefaultValue(0), Description("The row in which the edit field for this column will be shown in the Edit Dialog")]
		public int EditDialogRowPosition
		{
			get
			{
				if (base.ViewState["EditDialogRowPosition"] != null)
				{
					return (int)base.ViewState["EditDialogRowPosition"];
				}
				return 0;
			}
			set
			{
				base.ViewState["EditDialogRowPosition"] = value;
			}
		}
		[Category("Editing"), DefaultValue(""), Description("The label of the editing field in edit dialog. Default to the column DataField if not set")]
		public string EditDialogLabel
		{
			get
			{
				if (base.ViewState["EditDialogLabel"] != null)
				{
					return (string)base.ViewState["EditDialogLabel"];
				}
				return "";
			}
			set
			{
				base.ViewState["EditDialogLabel"] = value;
			}
		}
		[Category("Editing"), DefaultValue(""), Description("Text shown before the editing field in the Edit Dialog. Default is none ('')")]
		public string EditDialogFieldPrefix
		{
			get
			{
				if (base.ViewState["EditDialogFieldPrefix"] != null)
				{
					return (string)base.ViewState["EditDialogFieldPrefix"];
				}
				return "";
			}
			set
			{
				base.ViewState["EditDialogFieldPrefix"] = value;
			}
		}
		[Category("Editing"), DefaultValue(""), Description("Text shown after the editing field in the Edit Dialog. Default is none ('').")]
		public string EditDialogFieldSuffix
		{
			get
			{
				if (base.ViewState["EditDialogFieldSuffix"] != null)
				{
					return (string)base.ViewState["EditDialogFieldSuffix"];
				}
				return "";
			}
			set
			{
				base.ViewState["EditDialogFieldSuffix"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(""), Description("The field from the datasource mapped to this column.")]
		public string DataField
		{
			get
			{
				if (base.ViewState["DataField"] != null)
				{
					return (string)base.ViewState["DataField"];
				}
				return "";
			}
			set
			{
				base.ViewState["DataField"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(""), Description("The format applied to the column value for displaying. Uses the standard String.Format syntax.")]
		public string DataFormatString
		{
			get
			{
				if (base.ViewState["DataFormatString"] != null)
				{
					return (string)base.ViewState["DataFormatString"];
				}
				return "";
			}
			set
			{
				base.ViewState["DataFormatString"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The text of the column header. If empty (default) the DataField value is used")]
		public string HeaderText
		{
			get
			{
				if (base.ViewState["HeaderText"] != null)
				{
					return (string)base.ViewState["HeaderText"];
				}
				return "";
			}
			set
			{
				base.ViewState["HeaderText"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(TextAlign.Left), Description("The alignment of the cell text in the column. Default is left")]
		public TextAlign TextAlign
		{
			get
			{
				if (base.ViewState["TextAlign"] != null)
				{
					return (TextAlign)base.ViewState["TextAlign"];
				}
				return TextAlign.Left;
			}
			set
			{
				base.ViewState["TextAlign"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(true), Description("If the column should be visible. You may want to have column non-visible, but editable for example")]
		public bool Visible
		{
			get
			{
				return base.ViewState["Visible"] == null || (bool)base.ViewState["Visible"];
			}
			set
			{
				base.ViewState["Visible"] = value;
			}
		}
		[Category("Searching"), DefaultValue(true), Description("Determines if the column should be searchable. Default is true.")]
		public bool Searchable
		{
			get
			{
				return base.ViewState["Searchable"] == null || (bool)base.ViewState["Searchable"];
			}
			set
			{
				base.ViewState["Searchable"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(true), Description("Determines if the text in the column cell should be HtmlEncdoed. Default is true.")]
		public bool HtmlEncode
		{
			get
			{
				return base.ViewState["HtmlEncode"] == null || (bool)base.ViewState["HtmlEncode"];
			}
			set
			{
				base.ViewState["HtmlEncode"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(true), Description("Determines if the DataFormatString should be HtmlEncoded. Default is true.")]
		public bool HtmlEncodeFormatString
		{
			get
			{
				return base.ViewState["HtmlEncodeFormatString"] == null || (bool)base.ViewState["HtmlEncodeFormatString"];
			}
			set
			{
				base.ViewState["HtmlEncodeFormatString"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(true), Description("Determines if empty string should be converted to null.")]
		public bool ConvertEmptyStringToNull
		{
			get
			{
				return base.ViewState["ConvertEmptyStringToNull"] == null || (bool)base.ViewState["ConvertEmptyStringToNull"];
			}
			set
			{
				base.ViewState["ConvertEmptyStringToNull"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(""), Description("What to display if the cell value is null. Default is nothing ('')")]
		public string NullDisplayText
		{
			get
			{
				if (base.ViewState["NullDisplayText"] != null)
				{
					return (string)base.ViewState["NullDisplayText"];
				}
				return "";
			}
			set
			{
				base.ViewState["NullDisplayText"] = value;
			}
		}
		[Category("Searching"), DefaultValue(SearchOperation.Contains), Description("The default search function for this column when toolbar searching is enabled. Default is Contains.")]
		public SearchOperation SearchToolBarOperation
		{
			get
			{
				if (base.ViewState["SearchToolBarOperation"] != null)
				{
					return (SearchOperation)base.ViewState["SearchToolBarOperation"];
				}
				return SearchOperation.Contains;
			}
			set
			{
				base.ViewState["SearchToolBarOperation"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("What to display in the column footer. AppearanceSettings.ShowFooter must be set to True for this to have effect.")]
		public string FooterValue
		{
			get
			{
				if (base.ViewState["FooterValue"] != null)
				{
					return (string)base.ViewState["FooterValue"];
				}
				return "";
			}
			set
			{
				base.ViewState["FooterValue"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("Custom CssClass to apply to column cells.")]
		public string CssClass
		{
			get
			{
				if (base.ViewState["CssClass"] != null)
				{
					return (string)base.ViewState["CssClass"];
				}
				return "";
			}
			set
			{
				base.ViewState["CssClass"] = value;
			}
		}
		[Category("Grouping"), DefaultValue(GroupSummaryType.None), Description("The grouping function applied for this column")]
		public GroupSummaryType GroupSummaryType
		{
			get
			{
				if (base.ViewState["GroupSummaryType"] != null)
				{
					return (GroupSummaryType)base.ViewState["GroupSummaryType"];
				}
				return GroupSummaryType.None;
			}
			set
			{
				base.ViewState["GroupSummaryType"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(true), Description("Determines if the tooltip of the cell should be shown. Defaults to true.")]
		public bool ShowToolTip
		{
			get
			{
				return base.ViewState["ShowToolTip"] == null || (bool)base.ViewState["ShowToolTip"];
			}
			set
			{
				base.ViewState["ShowToolTip"] = value;
			}
		}
		[Category("Functionality"), DefaultValue(false), Description("Determines if column with should have fixed (constant) size of grid/browser resize")]
		public bool FixedWidth
		{
			get
			{
				return base.ViewState["FixedWidth"] != null && (bool)base.ViewState["FixedWidth"];
			}
			set
			{
				base.ViewState["FixedWidth"] = value;
			}
		}
		[Category("Grouping"), DefaultValue("{0}"), Description("The template applied to the grouping.")]
		public string GroupTemplate
		{
			get
			{
				if (base.ViewState["GroupTemplate"] != null)
				{
					return (string)base.ViewState["GroupTemplate"];
				}
				return "{0}";
			}
			set
			{
				base.ViewState["GroupTemplate"] = value;
			}
		}
		internal virtual string FormatDataValue(object dataValue, bool encode)
		{
			if (this.IsNull(dataValue))
			{
				return this.NullDisplayText;
			}
			string text = dataValue.ToString();
			string dataFormatString = this.DataFormatString;
			int length = text.Length;
			if (!this.HtmlEncodeFormatString)
			{
				if (length > 0 && encode)
				{
					text = HttpUtility.HtmlEncode(text);
				}
				if (length == 0 && this.ConvertEmptyStringToNull)
				{
					return this.NullDisplayText;
				}
				if (dataFormatString.Length == 0)
				{
					return text;
				}
				if (encode)
				{
					return string.Format(CultureInfo.CurrentCulture, dataFormatString, new object[]
					{
						text
					});
				}
				return string.Format(CultureInfo.CurrentCulture, dataFormatString, new object[]
				{
					dataValue
				});
			}
			else
			{
				if (length == 0 && this.ConvertEmptyStringToNull)
				{
					return this.NullDisplayText;
				}
				if (!string.IsNullOrEmpty(dataFormatString))
				{
					text = string.Format(CultureInfo.CurrentCulture, dataFormatString, new object[]
					{
						dataValue
					});
				}
				if (!string.IsNullOrEmpty(text) && encode)
				{
					text = HttpUtility.HtmlEncode(text);
				}
				return text;
			}
		}
		internal bool IsNull(object value)
		{
			return value == null || Convert.IsDBNull(value);
		}
	}
}
