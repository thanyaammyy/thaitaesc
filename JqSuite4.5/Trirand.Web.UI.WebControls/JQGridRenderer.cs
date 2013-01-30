using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	internal class JQGridRenderer
	{
		private JQGrid _grid;
		public JQGridRenderer(JQGrid grid)
		{
			this._grid = grid;
		}
		public void RenderHtml(HtmlTextWriter writer)
		{
			this.RenderGridHtml(writer);
			if (this._grid.ToolBarSettings.ToolBarPosition != ToolBarPosition.Hidden)
			{
				this.RenderPagerHtml(writer);
			}
			this.RenderHidden(writer);
		}
		private void RenderGridHtml(HtmlTextWriter writer)
		{
			writer.WriteBeginTag("table");
			writer.WriteAttribute("id", this._grid.ClientID);
			writer.Write('>');
			writer.WriteEndTag("table");
		}
		private void RenderHidden(HtmlTextWriter writer)
		{
			writer.WriteBeginTag("input");
			writer.WriteAttribute("id", this._grid.ClientID + "_SelectedRow");
			writer.WriteAttribute("name", this._grid.UniqueID);
			writer.WriteAttribute("type", "hidden");
			writer.Write('>');
			writer.WriteEndTag("input");
			writer.WriteBeginTag("input");
			writer.WriteAttribute("id", this._grid.ClientID + "_CurrentPage");
			writer.WriteAttribute("name", this._grid.UniqueID);
			writer.WriteAttribute("type", "hidden");
			writer.Write('>');
			writer.WriteEndTag("input");
		}
		private void RenderPagerHtml(HtmlTextWriter writer)
		{
			writer.WriteBeginTag("div");
			writer.WriteAttribute("id", this._grid.ClientID + "_pager");
			writer.Write('>');
			writer.WriteEndTag("div");
		}
		internal string GetStartupJavascript()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<script type='text/javascript'>\n");
			stringBuilder.Append("jQuery(document).ready(function() {");
			stringBuilder.Append(this.GetStartupOptions(false));
			stringBuilder.Append("});");
			stringBuilder.Append("</script>");
			return stringBuilder.ToString();
		}
		internal string GetChildSubGridJavaScript()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<script type='text/javascript'>\n");
			stringBuilder.AppendFormat("function showSubGrid_{0}(subgrid_id, row_id, message, suffix) {{", this._grid.ID);
			stringBuilder.Append("var subgrid_table_id, pager_id, toppager_id;\r\n\t\t                subgrid_table_id = subgrid_id+'_t';\r\n\t\t                pager_id = 'p_'+ subgrid_table_id;\r\n                        toppager_id = subgrid_table_id + '_toppager';\r\n                        if (suffix) { subgrid_table_id += suffix; pager_id += suffix;  }\r\n                        if (message) jQuery('#'+subgrid_id).append(message);                        \r\n\t\t                jQuery('#'+subgrid_id).append('<table id=' + subgrid_table_id + ' class=scroll></table><div id=' + pager_id + ' class=scroll></div>');\r\n                ");
			stringBuilder.Append(this.GetStartupOptions(true));
			stringBuilder.Append("}");
			stringBuilder.Append("</script>");
			return stringBuilder.ToString();
		}
		private string GetStartupOptions(bool subGrid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string arg = subGrid ? "jQuery('#' + subgrid_table_id)" : string.Format("jQuery('#{0}')", this._grid.ClientID);
			string arg2 = subGrid ? "jQuery('#' + pager_id)" : string.Format("jQuery('#{0}')", this._grid.ClientID + "_pager");
			string pagerSelectorID = subGrid ? "'#' + pager_id" : string.Format("'#{0}'", this._grid.ClientID + "_pager");
			string text = subGrid ? "&parentRowID=' + encodeURIComponent(row_id) + '" : string.Empty;
			string text2 = (this._grid.DataUrl.IndexOf("?") > 0) ? "&" : "?";
			string text3 = (this._grid.EditUrl.IndexOf("?") > 0) ? "&" : "?";
			string arg3 = string.Format("{0}{1}jqGridID={2}{3}", new object[]
			{
				this._grid.DataUrl,
				text2,
				this._grid.ClientID,
				text
			});
			string arg4 = string.Format("{0}{1}jqGridID={2}&editMode=1{3}", new object[]
			{
				this._grid.EditUrl,
				text3,
				this._grid.ClientID,
				text
			});
			if (this._grid.Columns.Count > 0 && this._grid.Columns[0].Frozen)
			{
				this._grid.AppearanceSettings.ShrinkToFit = false;
			}
			stringBuilder.AppendFormat("{0}.jqGrid({{", arg);
			stringBuilder.AppendFormat("url: '{0}'", arg3);
			stringBuilder.AppendFormat(",editurl: '{0}'", arg4);
			stringBuilder.AppendFormat(",datatype: 'json'", new object[0]);
			stringBuilder.AppendFormat(",page: {0}", this._grid.PagerSettings.CurrentPage);
			stringBuilder.AppendFormat(",colNames: {0}", this.GetColNames());
			stringBuilder.AppendFormat(",colModel: {0}", this.GetColModel());
			stringBuilder.AppendFormat(",viewrecords: true", new object[0]);
			stringBuilder.AppendFormat(",scrollrows: false", new object[0]);
			stringBuilder.AppendFormat(",postBackUrl: \"{0}\"", this._grid.Page.ClientScript.GetPostBackEventReference(this._grid, "jqGridParams"));
			stringBuilder.AppendFormat(",editDialogOptions: {0}", this.GetEditOptions());
			stringBuilder.AppendFormat(",addDialogOptions: {0}", this.GetAddOptions());
			stringBuilder.AppendFormat(",delDialogOptions: {0}", this.GetDelOptions());
			stringBuilder.AppendFormat(",searchDialogOptions: {0}", this.GetSearchOptions());
			stringBuilder.AppendFormat(",viewRowDetailsDialogOptions: {0}", this.GetViewRowsOptions());
			string format;
			if (this._grid.TreeGridSettings.Enabled)
			{
				format = ",jsonReader: {{ id: \"{0}\", repeatitems:false,subgrid:{{repeatitems:false}} }}";
			}
			else
			{
				format = ",jsonReader: {{ id: \"{0}\" }}";
			}
			stringBuilder.AppendFormat(format, this._grid.Columns[Util.GetPrimaryKeyIndex(this._grid)].DataField);
			stringBuilder.AppendFormat(",rowNum: {0}", this._grid.PagerSettings.PageSize.ToString());
			stringBuilder.AppendFormat(",rowList: {0}", this._grid.PagerSettings.PageSizeOptions.ToString());
			stringBuilder.AppendFormat(",sortorder: '{0}'", this._grid.SortSettings.InitialSortDirection.ToString().ToLower());
			stringBuilder.AppendFormat(",hidegrid: {0}", this._grid.AppearanceSettings.ShowCaptionGridToggleButton.ToString().ToLower());
			if (!this._grid.Width.IsEmpty)
			{
				stringBuilder.AppendFormat(",width: '{0}'", this._grid.Width.ToString().Replace("px", ""));
			}
			if (!this._grid.Height.IsEmpty)
			{
				stringBuilder.AppendFormat(",height: '{0}'", this._grid.Height.ToString().Replace("px", ""));
			}
			if (this._grid.ColumnReordering)
			{
				stringBuilder.Append(",sortable: true");
			}
			if (this._grid.AutoWidth)
			{
				stringBuilder.Append(",autowidth: true");
			}
			stringBuilder.Append(",headertitles: true");
			if (!this._grid.AppearanceSettings.HighlightRowsOnHover)
			{
				stringBuilder.Append(",hoverrows: false");
			}
			if (this._grid.AppearanceSettings.AlternateRowBackground)
			{
				stringBuilder.Append(",altRows: true");
			}
			if (this._grid.AppearanceSettings.ShowRowNumbers)
			{
				stringBuilder.Append(",rownumbers: true");
			}
			if (this._grid.AppearanceSettings.RowNumbersColumnWidth != 25)
			{
				stringBuilder.AppendFormat(",rownumWidth: {0}", this._grid.AppearanceSettings.RowNumbersColumnWidth.ToString());
			}
			if (!this._grid.AppearanceSettings.ShrinkToFit)
			{
				stringBuilder.Append(",shrinkToFit: false");
			}
			if (this._grid.AppearanceSettings.ScrollBarOffset != 18)
			{
				stringBuilder.AppendFormat(",scrollOffset: {0}", this._grid.AppearanceSettings.ScrollBarOffset);
			}
			if (this._grid.AppearanceSettings.RightToLeft)
			{
				stringBuilder.Append(",direction: 'rtl'");
			}
			if (!string.IsNullOrEmpty(this._grid.AppearanceSettings.Caption))
			{
				stringBuilder.AppendFormat(",caption: '{0}'", this._grid.AppearanceSettings.Caption);
			}
			if (this._grid.AppearanceSettings.ShowFooter)
			{
				stringBuilder.Append(",footerrow: true");
				stringBuilder.Append(",userDataOnFooter: true");
			}
			if (this._grid.ToolBarSettings.ToolBarPosition == ToolBarPosition.Bottom || this._grid.ToolBarSettings.ToolBarPosition == ToolBarPosition.TopAndBottom)
			{
				stringBuilder.AppendFormat(",pager: {0}", arg2);
			}
			if (this._grid.ToolBarSettings.ToolBarPosition == ToolBarPosition.Top || this._grid.ToolBarSettings.ToolBarPosition == ToolBarPosition.TopAndBottom)
			{
				stringBuilder.Append(",toppager: true");
			}
			if (this._grid.PagerSettings.ScrollBarPaging)
			{
				stringBuilder.AppendFormat(",scroll: 1", new object[0]);
			}
			if (!string.IsNullOrEmpty(this._grid.PagerSettings.NoRowsMessage))
			{
				stringBuilder.AppendFormat(",emptyrecords: '{0}'", this._grid.PagerSettings.NoRowsMessage.ToString());
			}
			if (this._grid.RenderingMode == RenderingMode.Optimized)
			{
				stringBuilder.Append(",gridview: true");
			}
			if (!string.IsNullOrEmpty(this._grid.SortSettings.InitialSortColumn))
			{
				stringBuilder.AppendFormat(",sortname: '{0}'", this._grid.SortSettings.InitialSortColumn);
			}
			stringBuilder.AppendFormat(",viewsortcols: [{0},'{1}',{2}]", "false", this._grid.SortSettings.SortIconsPosition.ToString().ToLower(), (this._grid.SortSettings.SortAction == SortAction.ClickOnHeader) ? "true" : "false");
			if (this._grid.HierarchySettings.HierarchyMode == HierarchyMode.Parent || this._grid.HierarchySettings.HierarchyMode == HierarchyMode.ParentAndChild)
			{
				stringBuilder.Append(",subGrid: true");
				Hashtable subGridOptions = this._grid.HierarchySettings.GetSubGridOptions();
				if (subGridOptions.Count > 0)
				{
					stringBuilder.AppendFormat(",subGridOptions:{0}", this._grid.HierarchySettings.GetSubGridOptionsJSON());
				}
			}
			if (this._grid.MultiSelect)
			{
				stringBuilder.Append(",multiselect: true");
				if (this._grid.MultiSelectMode == MultiSelectMode.SelectOnCheckBoxClickOnly)
				{
					stringBuilder.AppendFormat(",multiboxonly: true", this._grid.MultiSelect.ToString().ToLower());
				}
				if (this._grid.MultiSelectKey != MultiSelectKey.None)
				{
					stringBuilder.AppendFormat(",multikey: '{0}'", this.GetMultiKeyString(this._grid.MultiSelectKey));
				}
			}
			if (this._grid.EditInlineCellSettings.Enabled)
			{
				stringBuilder.Append(",cellEdit:true");
				stringBuilder.Append(",cellsubmit:'remote'");
				stringBuilder.AppendFormat(",cellurl:'{0}'", arg4);
			}
			if (this._grid.GroupSettings.GroupFields.Count > 0)
			{
				stringBuilder.Append(this._grid.GroupSettings.ToJSON());
			}
			this.RenderClientSideEvents(stringBuilder, this._grid.ClientSideEvents);
			if (this._grid.TreeGridSettings.Enabled)
			{
				stringBuilder.AppendFormat(",treeGrid: true", new object[0]);
				stringBuilder.AppendFormat(",treedatatype: 'json'", new object[0]);
				stringBuilder.AppendFormat(",treeGridModel: 'adjacency'", new object[0]);
				string arg5 = "{ level_field: 'tree_level', parent_id_field: 'tree_parent', leaf_field: 'tree_leaf', expanded_field: 'tree_expanded', loaded: 'tree_loaded', icon_field: 'tree_icon' }";
				stringBuilder.AppendFormat(",treeReader: {0}", arg5);
				stringBuilder.AppendFormat(",ExpandColumn: '{0}'", this.GetFirstVisibleDataField(this._grid));
				Hashtable hashtable = new Hashtable();
				if (!string.IsNullOrEmpty(this._grid.TreeGridSettings.CollapsedIcon))
				{
					hashtable.Add("plus", this._grid.TreeGridSettings.CollapsedIcon);
				}
				if (!string.IsNullOrEmpty(this._grid.TreeGridSettings.ExpandedIcon))
				{
					hashtable.Add("minus", this._grid.TreeGridSettings.ExpandedIcon);
				}
				if (!string.IsNullOrEmpty(this._grid.TreeGridSettings.LeafIcon))
				{
					hashtable.Add("leaf", this._grid.TreeGridSettings.LeafIcon);
				}
				if (hashtable.Count > 0)
				{
					stringBuilder.AppendFormat(",treeIcons: {0}", new JavaScriptSerializer().Serialize(hashtable));
				}
			}
			stringBuilder.AppendFormat("}})", new object[0]);
			stringBuilder.Append(this.GetToolBarOptions(subGrid, pagerSelectorID));
			if (!this._grid.PagerSettings.ScrollBarPaging && this._grid.KeyboardNavigation)
			{
				stringBuilder.AppendFormat(".bindKeys()", new object[0]);
			}
			JsonInlineToolBar jsonInlineToolBar = new JsonInlineToolBar(this._grid.ToolBarSettings);
			if (!jsonInlineToolBar.IsEmpty())
			{
				stringBuilder.AppendFormat(".inlineNav({0},{1})", this.GetToolBarID(), jsonInlineToolBar.ToJSON());
			}
			stringBuilder.Append(";");
			stringBuilder.Append(this.GetLoadErrorHandler());
			stringBuilder.Append(";");
			if (this._grid.HeaderGroups.Count > 0)
			{
				List<Hashtable> list = new List<Hashtable>();
				foreach (JQGridHeaderGroup jQGridHeaderGroup in this._grid.HeaderGroups)
				{
					list.Add(jQGridHeaderGroup.ToHashtable());
				}
				stringBuilder.AppendFormat("{0}.setGroupHeaders( {{ useColSpanStyle:true,groupHeaders:{1} }});", arg, new JavaScriptSerializer().Serialize(list));
			}
			if (!subGrid)
			{
				stringBuilder.Append(this.GetJQuerySubmit());
				stringBuilder.Append(this.GetSelectedRowPostBack());
				stringBuilder.Append(this.RestoreSelectedState());
			}
			if (this._grid.ToolBarSettings.ShowSearchToolBar)
			{
				stringBuilder.AppendFormat("{0}.filterToolbar({1});", arg, new JsonSearchToolBar(this._grid).Process());
			}
			if (this._grid.Columns.Count > 0 && this._grid.Columns[0].Frozen)
			{
				stringBuilder.AppendFormat("{0}.setFrozenColumns();", arg);
			}
			return stringBuilder.ToString();
		}
		private void RenderClientSideEvents(StringBuilder sb, ClientSideEvents e)
		{
			this.RenderClientSideEvent(sb, e.BeforeAjaxRequest, "beforeRequest");
			this.RenderClientSideEvent(sb, e.BeforeRowSelect, "beforeSelectRow");
			this.RenderClientSideEvent(sb, e.GridInitialized, "gridComplete");
			this.RenderClientSideEvent(sb, e.LoadComplete, "loadComplete");
			this.RenderClientSideEvent(sb, e.LoadDataError, "loadError");
			this.RenderClientSideEvent(sb, e.CellSelect, "onCellSelect");
			this.RenderClientSideEvent(sb, e.RowDoubleClick, "ondblClickRow");
			this.RenderClientSideEvent(sb, e.BeforePageChange, "onPaging");
			this.RenderClientSideEvent(sb, e.RowRightClick, "onRightClickRow");
			this.RenderClientSideEvent(sb, e.RowSelect, "onSelectRow");
			this.RenderClientSideEvent(sb, e.ColumnSort, "onSortCol");
			this.RenderClientSideEvent(sb, e.SubGridBeforeRowExpand, "subGridBeforeExpand");
			this.RenderClientSideEvent(sb, e.SubGridRowExpanded, "subGridRowExpanded");
			this.RenderClientSideEvent(sb, e.SubGridRowCollapsed, "subGridRowColapsed");
			this.RenderClientSideEvent(sb, e.AfterEditCell, "afterEditCell");
			this.RenderClientSideEvent(sb, e.AfterSaveCell, "afterSaveCell");
			this.RenderClientSideEvent(sb, e.AfterSubmitCell, "afterSubmitCell");
			this.RenderClientSideEvent(sb, e.BeforeEditCell, "beforeEditCell");
			this.RenderClientSideEvent(sb, e.BeforeSaveCell, "beforeSaveCell");
			this.RenderClientSideEvent(sb, e.BeforeSubmitCell, "beforeSubmitCell");
			this.RenderClientSideEvent(sb, e.BeforeSubmitCell, "beforeSubmitCell");
			this.RenderClientSideEvent(sb, e.EditCellFormat, "formatCell");
			this.RenderClientSideEvent(sb, e.EditError, "errorCell");
			if (string.IsNullOrEmpty(e.LoadDataError))
			{
				this.RenderClientSideEvent(sb, "jqGrid_aspnet_loadErrorHandler", "loadError");
			}
		}
		private void RenderClientSideEvent(StringBuilder sb, string eventName, string jsName)
		{
			if (!string.IsNullOrEmpty(eventName))
			{
				sb.AppendFormat(",{0}:{1}", jsName, eventName);
			}
		}
		private string GetJQuerySubmit()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("\r\n                        var _theForm = document.getElementsByTagName('FORM')[0];\r\n                        jQuery(_theForm).submit( function() \r\n                        {{  \r\n                            jQuery('#{0}').attr('value', jQuery('#{1}').getGridParam('selrow'));\r\n                        }});\r\n                       ", this._grid.ClientID + "_SelectedRow", this._grid.ClientID, this._grid.ClientID + "_CurrentPage");
			return stringBuilder.ToString();
		}
		private string GetSelectedRowPostBack()
		{
			if (this._grid.IsRowSelectingDefined)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("\r\n                    jQuery('#{0}').bind('click', function() {{\r\n                        var grid = jQuery('#{0}');\r\n                        var rowKey = grid.getGridParam('selrow');\r\n                        var postBackScript = grid.getGridParam('postBackUrl').replace(/jqGridParams/g, rowKey);\r\n                        jQuery('#{0}_CurrentPage').attr('value', grid.getGridParam('page'));\r\n                        jQuery('#{0}_SelectedRow').attr('value', grid.getGridParam('selrow'));\r\n                        eval(postBackScript);\r\n                    }});\r\n                ", this._grid.ClientID);
				return stringBuilder.ToString();
			}
			return string.Empty;
		}
		private string RestoreSelectedState()
		{
			if (!string.IsNullOrEmpty(this._grid.SelectedRow))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("\r\n                        jQuery('#{0}').setGridParam( {{ gridComplete: function() \r\n                        {{                            \r\n                            var grid = jQuery('#{0}');\r\n                            grid.setSelection('{1}',false);\r\n                        }}\r\n                     }});\r\n\r\n                ", this._grid.ClientID, this._grid.SelectedRow);
				return stringBuilder.ToString();
			}
			return string.Empty;
		}
		private string GetToolBarID()
		{
			if (this._grid.HierarchySettings.HierarchyMode == HierarchyMode.Child || this._grid.HierarchySettings.HierarchyMode == HierarchyMode.ParentAndChild)
			{
				return "'#' + pager_id";
			}
			return "'#" + this._grid.ClientID + "_pager'";
		}
		private string GetToolBarOptions(bool subGrid, string pagerSelectorID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			if (this._grid.ShowToolBar)
			{
				JsonToolBar obj = new JsonToolBar(this._grid.ToolBarSettings);
				if (!subGrid)
				{
					stringBuilder.AppendFormat(".navGrid({0},{1},{2},{3},{4},{5},{6} )", new object[]
					{
						this.GetToolBarID(),
						javaScriptSerializer.Serialize(obj),
						string.Format("jQuery('#{0}').getGridParam('editDialogOptions')", this._grid.ClientID),
						string.Format("jQuery('#{0}').getGridParam('addDialogOptions')", this._grid.ClientID),
						string.Format("jQuery('#{0}').getGridParam('delDialogOptions')", this._grid.ClientID),
						string.Format("jQuery('#{0}').getGridParam('searchDialogOptions')", this._grid.ClientID),
						string.Format("jQuery('#{0}').getGridParam('viewRowDetailsDialogOptions')", this._grid.ClientID)
					});
				}
				else
				{
					stringBuilder.AppendFormat(".navGrid('#' + pager_id,{0},{1},{2},{3},{4},{5} )", new object[]
					{
						javaScriptSerializer.Serialize(obj),
						"jQuery('#' + subgrid_table_id).getGridParam('editDialogOptions')",
						"jQuery('#' + subgrid_table_id).getGridParam('addDialogOptions')",
						"jQuery('#' + subgrid_table_id).getGridParam('delDialogOptions')",
						"jQuery('#' + subgrid_table_id).getGridParam('searchDialogOptions')",
						"jQuery('#' + subgrid_table_id).getGridParam('viewRowDetailsDialogOptions')"
					});
				}
				foreach (JQGridToolBarButton button in this._grid.ToolBarSettings.CustomButtons)
				{
					if (this._grid.ToolBarSettings.ToolBarPosition == ToolBarPosition.Bottom || this._grid.ToolBarSettings.ToolBarPosition == ToolBarPosition.TopAndBottom)
					{
						JsonCustomButton jsonCustomButton = new JsonCustomButton(button);
						stringBuilder.AppendFormat(".navButtonAdd({0},{1})", pagerSelectorID, jsonCustomButton.Process());
					}
					if (this._grid.ToolBarSettings.ToolBarPosition == ToolBarPosition.TopAndBottom || this._grid.ToolBarSettings.ToolBarPosition == ToolBarPosition.Top)
					{
						JsonCustomButton jsonCustomButton2 = new JsonCustomButton(button);
						stringBuilder.AppendFormat(".navButtonAdd({0},{1})", pagerSelectorID.Replace("pager", "toppager"), jsonCustomButton2.Process());
					}
				}
				return stringBuilder.ToString();
			}
			return string.Empty;
		}
		private string GetEditOptions()
		{
			JsonEditDialog jsonEditDialog = new JsonEditDialog(this._grid);
			return jsonEditDialog.Process();
		}
		private string GetAddOptions()
		{
			JsonAddDialog jsonAddDialog = new JsonAddDialog(this._grid);
			return jsonAddDialog.Process();
		}
		private string GetDelOptions()
		{
			JsonDelDialog jsonDelDialog = new JsonDelDialog(this._grid);
			return jsonDelDialog.Process();
		}
		private string GetSearchOptions()
		{
			JsonSearchDialog jsonSearchDialog = new JsonSearchDialog(this._grid);
			return jsonSearchDialog.Process();
		}
		private string GetViewRowsOptions()
		{
			JsonViewRowDetailsDialog jsonViewRowDetailsDialog = new JsonViewRowDetailsDialog(this._grid);
			return jsonViewRowDetailsDialog.Process();
		}
		private string GetColNames()
		{
			string[] array = new string[this._grid.Columns.Count];
			for (int i = 0; i < this._grid.Columns.Count; i++)
			{
				JQGridColumn jQGridColumn = this._grid.Columns[i];
				array[i] = (string.IsNullOrEmpty(jQGridColumn.HeaderText) ? jQGridColumn.DataField : jQGridColumn.HeaderText);
			}
			return new JavaScriptSerializer().Serialize(array);
		}
		private string GetColModel()
		{
			Hashtable[] array = new Hashtable[this._grid.Columns.Count];
			for (int i = 0; i < this._grid.Columns.Count; i++)
			{
				JsonColModel jsonColModel = new JsonColModel(this._grid.Columns[i], this._grid);
				array[i] = jsonColModel.JsonValues;
			}
			string input = new JavaScriptSerializer().Serialize(array);
			return JsonColModel.RemoveQuotesForJavaScriptMethods(input, this._grid);
		}
		private JQGridColumn GetColumnFromDataTable(string columnName)
		{
			foreach (JQGridColumn jQGridColumn in this._grid.Columns)
			{
				if (jQGridColumn.DataField == columnName)
				{
					return jQGridColumn;
				}
			}
			return null;
		}
		private string GetMultiKeyString(MultiSelectKey key)
		{
			switch (key)
			{
			case MultiSelectKey.Shift:
				return "shiftKey";
			case MultiSelectKey.Ctrl:
				return "ctrlKey";
			case MultiSelectKey.Alt:
				return "altKey";
			default:
				throw new Exception("Should not be here.");
			}
		}
		private string GetLoadErrorHandler()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\n\rfunction jqGrid_aspnet_loadErrorHandler(xht, st, handler) {");
			stringBuilder.Append("jQuery(document.body).css('font-size','100%'); jQuery(document.body).html(xht.responseText);");
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
		private string GetFirstVisibleDataField(JQGrid grid)
		{
			foreach (JQGridColumn jQGridColumn in grid.Columns)
			{
				if (jQGridColumn.Visible)
				{
					return jQGridColumn.DataField;
				}
			}
			return grid.Columns[0].DataField;
		}
	}
}
