using System;
using System.Collections;
using System.Text;
using System.Web.UI.WebControls;
namespace Trirand.Web.UI.WebControls
{
	internal class JsonColModel
	{
		private Hashtable _jsonValues;
		private JQGrid _grid;
		public Hashtable JsonValues
		{
			get
			{
				return this._jsonValues;
			}
			set
			{
				this._jsonValues = value;
			}
		}
		public JsonColModel(JQGrid grid)
		{
			this._jsonValues = new Hashtable();
			this._grid = grid;
		}
		public JsonColModel(JQGridColumn column, JQGrid grid) : this(grid)
		{
			this.FromColumn(column);
		}
		public void FromColumn(JQGridColumn column)
		{
			string value;
			if (!string.IsNullOrEmpty(column.DataField))
			{
				value = column.DataField;
			}
			else
			{
				if (!string.IsNullOrEmpty(column.HeaderText))
				{
					value = column.HeaderText;
				}
				else
				{
					value = this._grid.Columns.IndexOf(column).ToString() + "_template";
				}
			}
			this._jsonValues["index"] = (this._jsonValues["name"] = value);
			if (column.Width != 150)
			{
				this._jsonValues["width"] = column.Width;
			}
			if (!column.Sortable)
			{
				this._jsonValues["sortable"] = false;
			}
			if (column.PrimaryKey)
			{
				this._jsonValues["key"] = true;
			}
			if (!column.Visible)
			{
				this._jsonValues["hidden"] = true;
			}
			if (!column.Searchable)
			{
				this._jsonValues["search"] = false;
			}
			if (column.TextAlign != TextAlign.Left)
			{
				this._jsonValues["align"] = column.TextAlign.ToString().ToLower();
			}
			if (!column.Resizable)
			{
				this._jsonValues["resizable"] = false;
			}
			if (column.Frozen)
			{
				this._jsonValues["frozen"] = true;
			}
			if (column.FixedWidth)
			{
				this._jsonValues["fixed"] = true;
			}
			if (!column.ShowToolTip)
			{
				this._jsonValues["title"] = false;
			}
			if (!string.IsNullOrEmpty(column.CssClass))
			{
				this._jsonValues["classes"] = column.CssClass;
			}
			if (column.GroupSummaryType != GroupSummaryType.None)
			{
				switch (column.GroupSummaryType)
				{
				case GroupSummaryType.Min:
					this._jsonValues["summaryType"] = "min";
					break;
				case GroupSummaryType.Max:
					this._jsonValues["summaryType"] = "max";
					break;
				case GroupSummaryType.Sum:
					this._jsonValues["summaryType"] = "sum";
					break;
				case GroupSummaryType.Avg:
					this._jsonValues["summaryType"] = "avg";
					break;
				case GroupSummaryType.Count:
					this._jsonValues["summaryType"] = "count";
					break;
				}
			}
			if (!string.IsNullOrEmpty(column.GroupTemplate))
			{
				this._jsonValues["summaryTpl"] = column.GroupTemplate;
			}
			if (column.Formatter != null)
			{
				this.ApplyFormatterOptions(column);
			}
			if (column.EditActionIconsColumn)
			{
				this._jsonValues["formatter"] = "actions";
				Hashtable hashtable = new Hashtable();
				if (!column.EditActionIconsDeleteEnabled)
				{
					hashtable["delbutton"] = false;
				}
				if (!column.EditActionIconsEditEnabled)
				{
					hashtable["editbutton"] = false;
				}
				if (column.EditActionIconsEditDialogEnabled)
				{
					hashtable["editformbutton"] = true;
				}
				if (hashtable.Count > 0)
				{
					this._jsonValues["formatoptions"] = hashtable;
				}
			}
			if (column.Searchable)
			{
				Hashtable hashtable2 = new Hashtable();
				if (column.SearchType == SearchType.DropDown)
				{
					this._jsonValues["stype"] = "select";
				}
				if (!column.Visible)
				{
					hashtable2["searchhidden"] = true;
				}
				if (!string.IsNullOrEmpty(column.SearchValues))
				{
					hashtable2["value"] = column.SearchValues;
					this._jsonValues["searchoptions"] = hashtable2;
				}
				if (column.SearchType == SearchType.DropDown && !string.IsNullOrEmpty(column.SearchControlID))
				{
					DropDownList dropDownList = this._grid.FindControlRecursive(this._grid.Page, column.SearchControlID) as DropDownList;
					if (dropDownList == null)
					{
						throw new Exception("Cannot find a DropDownList control with ID = " + column.SearchControlID);
					}
					if (!string.IsNullOrEmpty(dropDownList.DataSourceID) || dropDownList.DataSource != null)
					{
						dropDownList.DataBind();
					}
					StringBuilder stringBuilder = new StringBuilder();
					foreach (ListItem listItem in dropDownList.Items)
					{
						stringBuilder.AppendFormat("{0}:{1}", listItem.Value, listItem.Text);
						if (dropDownList.Items.IndexOf(listItem) < dropDownList.Items.Count - 1)
						{
							stringBuilder.Append(";");
						}
					}
					dropDownList.Visible = false;
					hashtable2["value"] = stringBuilder.ToString();
				}
				if (column.SearchType == SearchType.DatePicker || column.SearchType == SearchType.AutoComplete)
				{
					hashtable2["dataInit"] = "attachSearchControlsScript" + column.DataField;
				}
				if (column.SearchOptions.Count > 0)
				{
					hashtable2["sopt"] = this.GetSearchOptionsArray(column.SearchOptions);
				}
				this._jsonValues["searchoptions"] = hashtable2;
			}
			if (column.Editable)
			{
				Hashtable hashtable3 = new Hashtable();
				this._jsonValues["editable"] = true;
				if (column.EditType == EditType.CheckBox)
				{
					hashtable3["value"] = "true:false";
				}
				if (column.EditType != EditType.TextBox)
				{
					this._jsonValues["edittype"] = this.GetEditType(column.EditType);
				}
				if (column.EditType == EditType.Custom)
				{
					Guard.IsNullOrEmpty(column.EditTypeCustomCreateElement, "JQGridColumn.EditTypeCustomCreateElement", " should be set to the name of the javascript function creating the element when EditType = EditType.Custom");
					Guard.IsNullOrEmpty(column.EditTypeCustomGetValue, "JQGridColumn.EditTypeCustomGetValue", " should be set to the name of the javascript function getting the value from the element when EditType = EditType.Custom");
					hashtable3["custom_element"] = column.EditTypeCustomCreateElement;
					hashtable3["custom_value"] = column.EditTypeCustomGetValue;
				}
				foreach (JQGridEditFieldAttribute jQGridEditFieldAttribute in column.EditFieldAttributes)
				{
					hashtable3[jQGridEditFieldAttribute.Name] = jQGridEditFieldAttribute.Value;
				}
				if (column.EditType == EditType.DatePicker || column.EditType == EditType.AutoComplete)
				{
					hashtable3["dataInit"] = "attachEditControlsScript" + column.DataField;
				}
				if (!string.IsNullOrEmpty(column.EditValues))
				{
					hashtable3["value"] = column.EditValues;
				}
				if (column.EditType == EditType.DropDown && !string.IsNullOrEmpty(column.EditorControlID))
				{
					DropDownList dropDownList2 = this._grid.FindControlRecursive(this._grid.Page, column.EditorControlID) as DropDownList;
					if (dropDownList2 == null)
					{
						throw new Exception("Cannot find a DropDownList control with ID = " + column.EditorControlID);
					}
					if (!string.IsNullOrEmpty(dropDownList2.DataSourceID) || dropDownList2.DataSource != null)
					{
						dropDownList2.DataBind();
					}
					StringBuilder stringBuilder2 = new StringBuilder();
					foreach (ListItem listItem2 in dropDownList2.Items)
					{
						stringBuilder2.AppendFormat("{0}:{1}", listItem2.Value, listItem2.Text);
						if (dropDownList2.Items.IndexOf(listItem2) < dropDownList2.Items.Count - 1)
						{
							stringBuilder2.Append(";");
						}
					}
					dropDownList2.Visible = false;
					hashtable3["value"] = stringBuilder2.ToString();
				}
				if (hashtable3.Count > 0)
				{
					this._jsonValues["editoptions"] = hashtable3;
				}
				Hashtable hashtable4 = new Hashtable();
				if (column.EditDialogColumnPosition != 0)
				{
					hashtable4["colpos"] = column.EditDialogColumnPosition;
				}
				if (column.EditDialogRowPosition != 0)
				{
					hashtable4["rowpos"] = column.EditDialogRowPosition;
				}
				if (!string.IsNullOrEmpty(column.EditDialogLabel))
				{
					hashtable4["label"] = column.EditDialogLabel;
				}
				if (!string.IsNullOrEmpty(column.EditDialogFieldPrefix))
				{
					hashtable4["elmprefix"] = column.EditDialogFieldPrefix;
				}
				if (!string.IsNullOrEmpty(column.EditDialogFieldSuffix))
				{
					hashtable4["elmsuffix"] = column.EditDialogFieldSuffix;
				}
				if (hashtable4.Count > 0)
				{
					this._jsonValues["formoptions"] = hashtable4;
				}
				Hashtable hashtable5 = new Hashtable();
				if (!column.Visible && column.Editable)
				{
					hashtable5["edithidden"] = true;
				}
				if (column.EditClientSideValidators != null)
				{
					foreach (JQGridEditClientSideValidator jQGridEditClientSideValidator in column.EditClientSideValidators)
					{
						if (jQGridEditClientSideValidator is DateValidator)
						{
							hashtable5["date"] = true;
						}
						if (jQGridEditClientSideValidator is EmailValidator)
						{
							hashtable5["email"] = true;
						}
						if (jQGridEditClientSideValidator is IntegerValidator)
						{
							hashtable5["integer"] = true;
						}
						if (jQGridEditClientSideValidator is MaxValueValidator)
						{
							hashtable5["maxValue"] = ((MaxValueValidator)jQGridEditClientSideValidator).MaxValue;
						}
						if (jQGridEditClientSideValidator is MinValueValidator)
						{
							hashtable5["minValue"] = ((MinValueValidator)jQGridEditClientSideValidator).MinValue;
						}
						if (jQGridEditClientSideValidator is NumberValidator)
						{
							hashtable5["number"] = true;
						}
						if (jQGridEditClientSideValidator is RequiredValidator)
						{
							hashtable5["required"] = true;
						}
						if (jQGridEditClientSideValidator is TimeValidator)
						{
							hashtable5["time"] = true;
						}
						if (jQGridEditClientSideValidator is UrlValidator)
						{
							hashtable5["url"] = true;
						}
						if (jQGridEditClientSideValidator is CustomValidator)
						{
							hashtable5["custom"] = true;
							hashtable5["custom_func"] = ((CustomValidator)jQGridEditClientSideValidator).ValidationFunction;
						}
					}
				}
				if (hashtable5.Count > 0)
				{
					this._jsonValues["editrules"] = hashtable5;
				}
			}
		}
		private void ApplyFormatterOptions(JQGridColumn column)
		{
			if (column.Formatter.Count > 0 && column.Formatter[0] != null)
			{
				JQGridColumnFormatter jQGridColumnFormatter = column.Formatter[0];
				Hashtable hashtable = new Hashtable();
				if (jQGridColumnFormatter is LinkFormatter)
				{
					LinkFormatter linkFormatter = (LinkFormatter)jQGridColumnFormatter;
					this._jsonValues["formatter"] = "link";
					if (!string.IsNullOrEmpty(linkFormatter.Target))
					{
						hashtable["target"] = linkFormatter.Target;
					}
				}
				if (jQGridColumnFormatter is EmailFormatter)
				{
					this._jsonValues["formatter"] = "email";
				}
				if (jQGridColumnFormatter is IntegerFormatter)
				{
					IntegerFormatter integerFormatter = (IntegerFormatter)jQGridColumnFormatter;
					this._jsonValues["formatter"] = "integer";
					if (!string.IsNullOrEmpty(integerFormatter.ThousandsSeparator))
					{
						hashtable["thousandsSeparator"] = integerFormatter.ThousandsSeparator;
					}
					if (!string.IsNullOrEmpty(integerFormatter.DefaultValue))
					{
						hashtable["defaultValue"] = integerFormatter.DefaultValue;
					}
				}
				if (jQGridColumnFormatter is NumberFormatter)
				{
					NumberFormatter numberFormatter = (NumberFormatter)jQGridColumnFormatter;
					this._jsonValues["formatter"] = "integer";
					if (!string.IsNullOrEmpty(numberFormatter.ThousandsSeparator))
					{
						hashtable["thousandsSeparator"] = numberFormatter.ThousandsSeparator;
					}
					if (!string.IsNullOrEmpty(numberFormatter.DefaultValue))
					{
						hashtable["defaultValue"] = numberFormatter.DefaultValue;
					}
					if (!string.IsNullOrEmpty(numberFormatter.DecimalSeparator))
					{
						hashtable["decimalSeparator"] = numberFormatter.DecimalSeparator;
					}
					if (numberFormatter.DecimalPlaces != -1)
					{
						hashtable["decimalPlaces"] = numberFormatter.DecimalPlaces;
					}
				}
				if (jQGridColumnFormatter is CurrencyFormatter)
				{
					CurrencyFormatter currencyFormatter = (CurrencyFormatter)jQGridColumnFormatter;
					this._jsonValues["formatter"] = "currency";
					if (!string.IsNullOrEmpty(currencyFormatter.ThousandsSeparator))
					{
						hashtable["thousandsSeparator"] = currencyFormatter.ThousandsSeparator;
					}
					if (!string.IsNullOrEmpty(currencyFormatter.DefaultValue))
					{
						hashtable["defaultValue"] = currencyFormatter.DefaultValue;
					}
					if (!string.IsNullOrEmpty(currencyFormatter.DecimalSeparator))
					{
						hashtable["decimalSeparator"] = currencyFormatter.DecimalSeparator;
					}
					if (currencyFormatter.DecimalPlaces != -1)
					{
						hashtable["decimalPlaces"] = currencyFormatter.DecimalPlaces;
					}
					if (!string.IsNullOrEmpty(currencyFormatter.Prefix))
					{
						hashtable["prefix"] = currencyFormatter.Prefix;
					}
					if (!string.IsNullOrEmpty(currencyFormatter.Prefix))
					{
						hashtable["suffix"] = currencyFormatter.Suffix;
					}
				}
				if (jQGridColumnFormatter is CheckBoxFormatter)
				{
					CheckBoxFormatter checkBoxFormatter = (CheckBoxFormatter)jQGridColumnFormatter;
					this._jsonValues["formatter"] = "checkbox";
					if (checkBoxFormatter.Enabled)
					{
						hashtable["disabled"] = false;
					}
				}
				if (jQGridColumnFormatter is CustomFormatter)
				{
					CustomFormatter customFormatter = (CustomFormatter)jQGridColumnFormatter;
					if (!string.IsNullOrEmpty(customFormatter.FormatFunction))
					{
						this._jsonValues["formatter"] = customFormatter.FormatFunction;
					}
					if (!string.IsNullOrEmpty(customFormatter.UnFormatFunction))
					{
						this._jsonValues["unformat"] = customFormatter.UnFormatFunction;
					}
				}
				if (hashtable.Count > 0)
				{
					this._jsonValues["formatoptions"] = hashtable;
				}
			}
		}
		public static string RemoveQuotesForJavaScriptMethods(string input, JQGrid grid)
		{
			string text = input;
			foreach (JQGridColumn jQGridColumn in grid.Columns)
			{
				if (jQGridColumn.Formatter != null && jQGridColumn.Formatter.Count > 0 && jQGridColumn.Formatter[0] != null)
				{
					JQGridColumnFormatter jQGridColumnFormatter = jQGridColumn.Formatter[0];
					if (jQGridColumnFormatter is CustomFormatter)
					{
						CustomFormatter customFormatter = (CustomFormatter)jQGridColumnFormatter;
						string oldValue = string.Format("\"formatter\":\"{0}\"", customFormatter.FormatFunction);
						string newValue = string.Format("\"formatter\":{0}", customFormatter.FormatFunction);
						text = text.Replace(oldValue, newValue);
						oldValue = string.Format("\"unformat\":\"{0}\"", customFormatter.UnFormatFunction);
						newValue = string.Format("\"unformat\":{0}", customFormatter.UnFormatFunction);
						text = text.Replace(oldValue, newValue);
					}
				}
				foreach (JQGridEditClientSideValidator jQGridEditClientSideValidator in jQGridColumn.EditClientSideValidators)
				{
					if (jQGridEditClientSideValidator is CustomValidator)
					{
						CustomValidator customValidator = (CustomValidator)jQGridEditClientSideValidator;
						string oldValue2 = string.Format("\"custom_func\":\"{0}\"", customValidator.ValidationFunction);
						string newValue2 = string.Format("\"custom_func\":{0}", customValidator.ValidationFunction);
						text = text.Replace(oldValue2, newValue2);
					}
				}
				if (jQGridColumn.EditType == EditType.Custom)
				{
					string oldValue3 = string.Format("\"custom_element\":\"{0}\"", jQGridColumn.EditTypeCustomCreateElement);
					string newValue3 = string.Format("\"custom_element\":{0}", jQGridColumn.EditTypeCustomCreateElement);
					text = text.Replace(oldValue3, newValue3);
					oldValue3 = string.Format("\"custom_value\":\"{0}\"", jQGridColumn.EditTypeCustomGetValue);
					newValue3 = string.Format("\"custom_value\":{0}", jQGridColumn.EditTypeCustomGetValue);
					text = text.Replace(oldValue3, newValue3);
				}
				if ((jQGridColumn.Editable && jQGridColumn.EditType == EditType.DatePicker) || jQGridColumn.EditType == EditType.AutoComplete)
				{
					string attachEditorsFunction = GridUtil.GetAttachEditorsFunction(grid, jQGridColumn.EditType.ToString().ToLower(), jQGridColumn.EditorControlID);
					text = text.Replace(string.Concat(new object[]
					{
						'"',
						"attachEditControlsScript",
						jQGridColumn.DataField,
						'"'
					}), attachEditorsFunction);
					text = text.Replace('"' + "dataInit" + '"', "dataInit");
				}
				if ((jQGridColumn.Searchable && jQGridColumn.SearchType == SearchType.DatePicker) || jQGridColumn.SearchType == SearchType.AutoComplete)
				{
					string attachEditorsFunction2 = GridUtil.GetAttachEditorsFunction(grid, jQGridColumn.SearchType.ToString().ToLower(), jQGridColumn.SearchControlID);
					text = text.Replace(string.Concat(new object[]
					{
						'"',
						"attachSearchControlsScript",
						jQGridColumn.DataField,
						'"'
					}), attachEditorsFunction2);
					text = text.Replace('"' + "dataInit" + '"', "dataInit");
				}
			}
			return text;
		}
		private string GetEditType(EditType type)
		{
			switch (type)
			{
			case EditType.TextBox:
				return "text";
			case EditType.CheckBox:
				return "checkbox";
			case EditType.DropDown:
				return "select";
			case EditType.TextArea:
				return "textarea";
			case EditType.Password:
				return "password";
			case EditType.Custom:
				return "custom";
			default:
				return "text";
			}
		}
		private ArrayList GetSearchOptionsArray(JQGridColumnSearchOptionCollection options)
		{
			ArrayList arrayList = new ArrayList();
			BaseSearching baseSearching = new BaseSearching(this._grid);
			foreach (JQGridColumnSearchOption jQGridColumnSearchOption in options)
			{
				arrayList.Add(baseSearching.GetStringFromSearchOperation(jQGridColumnSearchOption.SearchOperation));
			}
			return arrayList;
		}
	}
}
