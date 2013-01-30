using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Trirand.Web.UI.WebControls
{
	[Designer("Trirand.Web.UI.WebControls.Design.JQGridDesigner"), ToolboxData("<{0}:jqgrid runat=server></{0}:jqgrid>")]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGrid : CompositeDataBoundControl, IPostBackDataHandler, IPostBackEventHandler
	{
		public delegate void JQGridSortEventHandler(object sender, JQGridSortEventArgs e);
		public delegate void JQGridSearchEventHandler(object sender, JQGridSearchEventArgs e);
		public delegate void JQGridRowAddEventHandler(object sender, JQGridRowAddEventArgs e);
		public delegate void JQGridRowEditEventHandler(object sender, JQGridRowEditEventArgs e);
		public delegate void JQGridRowDeleteEventHandler(object sender, JQGridRowDeleteEventArgs e);
		public delegate void JQGridRowSelectEventHandler(object sender, JQGridRowSelectEventArgs e);
		public delegate void JQGridCellBindEventHandler(object sender, JQGridCellBindEventArgs e);
		public delegate void JQGridDataRequestEventHandler(object sender, JQGridDataRequestEventArgs e);
		public delegate void JQGridDataRequestedEventHandler(object sender, JQGridDataRequestedEventArgs e);
		private JavaScriptSerializer _sr;
		private JQGridColumnCollection _columnCollection;
		private AjaxCallBackMode _ajaxCallBackMode;
		private int _totalRows;
		private DataSourceSelectArguments _selectArguments;
		private bool _dataSourceSorted;
		private NameValueCollection _queryString;
		private JQGridState _filteredGridState;
		private string _filteredExportFileName;
		private bool _exportActive;
		private AddDialogSettings _addDialogSettings;
		private EditDialogSettings _editDialogSettings;
		private DeleteDialogSettings _deleteDialogSettings;
		private SearchDialogSettings _searchDialogSettings;
		private SearchToolBarSettings _searchToolBarSettings;
		private ViewRowDetailsDialogSettings _viewRowDetailsDialogSettings;
		private PagerSettings _pagerSettings;
		private ToolBarSettings _toolBarSettings;
		private SortSettings _sortSettings;
		private AppearanceSettings _appearanceSettings;
		private HierarchySettings _hierarchySettings;
		private ClientSideEvents _clientSideEvents;
		private EditInlineCellSettings _editInlineCellSettings;
		private GroupSettings _groupSettings;
		private TreeGridSettings _treeGridSettings;
		private ExportSettings _exportSettings;
		private JQGridHeaderGroupCollection _headerGroups;
		private static readonly object EventSorted;
		private static readonly object EventSorting;
		private static readonly object EventSearching;
		private static readonly object EventSearched;
		private static readonly object EventRowAdding;
		private static readonly object EventRowAdded;
		private static readonly object EventRowEditing;
		private static readonly object EventRowEdited;
		private static readonly object EventRowDeleting;
		private static readonly object EventRowDeleted;
		private static readonly object EventRowSelecting;
		private static readonly object EventCellBinding;
		private static readonly object EventCellBound;
		private static readonly object EventDataRequesting;
		private static readonly object EventDataRequested;
		private bool _filteredCSVExportActive;
		private bool _filteredExcelExportActive;
		private bool _filteredExportActive;
		internal JQGridExportDataCallBack _filteredExportCallBack;
		[Category("Action"), Description("GridView_OnSorting")]
		public event JQGrid.JQGridSortEventHandler Sorting
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventSorting, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventSorting, value);
			}
		}
		[Category("Action"), Description("GridView_OnSorted")]
		public event EventHandler Sorted
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventSorted, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventSorted, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearching")]
		public event JQGrid.JQGridSearchEventHandler Searching
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventSearching, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventSearching, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearched")]
		public event EventHandler Searched
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventSearched, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventSearched, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearching")]
		public event JQGrid.JQGridRowAddEventHandler RowAdding
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventRowAdding, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventRowAdding, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearched")]
		public event EventHandler RowAdded
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventRowAdded, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventRowAdded, value);
			}
		}
		[Category("Action"), Description("RowEditing")]
		public event JQGrid.JQGridRowEditEventHandler RowEditing
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventRowEditing, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventRowEditing, value);
			}
		}
		[Category("Action"), Description("RowEdited")]
		public event JQGrid.JQGridRowEditEventHandler RowEdited
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventRowEdited, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventRowEdited, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearching")]
		public event JQGrid.JQGridRowDeleteEventHandler RowDeleting
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventRowDeleting, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventRowDeleting, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearched")]
		public event EventHandler RowDeleted
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventRowDeleted, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventRowDeleted, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearching")]
		public event JQGrid.JQGridRowSelectEventHandler RowSelecting
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventRowSelecting, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventRowSelecting, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearching")]
		public event JQGrid.JQGridCellBindEventHandler CellBinding
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventCellBinding, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventCellBinding, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearched")]
		public event JQGrid.JQGridCellBindEventHandler CellBound
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventCellBound, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventCellBound, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearched")]
		public event JQGrid.JQGridDataRequestEventHandler DataRequesting
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventDataRequesting, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventDataRequesting, value);
			}
		}
		[Category("Action"), Description("GridView_OnSearched")]
		public event JQGrid.JQGridDataRequestedEventHandler DataRequested
		{
			add
			{
				base.Events.AddHandler(JQGrid.EventDataRequested, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQGrid.EventDataRequested, value);
			}
		}
		internal bool IsRowSelectingDefined
		{
			get
			{
				JQGrid.JQGridRowSelectEventHandler jQGridRowSelectEventHandler = (JQGrid.JQGridRowSelectEventHandler)base.Events[JQGrid.EventRowSelecting];
				return jQGridRowSelectEventHandler != null;
			}
		}
		internal bool ShowToolBar
		{
			get
			{
				return this.ToolBarSettings.ShowAddButton || this.ToolBarSettings.ShowDeleteButton || this.ToolBarSettings.ShowEditButton || this.ToolBarSettings.ShowRefreshButton || this.ToolBarSettings.ShowSearchButton || this.ToolBarSettings.ShowViewRowDetailsButton || this.ToolBarSettings.ShowInlineAddButton || this.ToolBarSettings.ShowInlineCancelButton || this.ToolBarSettings.ShowInlineDeleteButton || this.ToolBarSettings.ShowInlineEditButton || this.ToolBarSettings.CustomButtons.Count > 0;
			}
		}
		public AjaxCallBackMode AjaxCallBackMode
		{
			get
			{
				return this.ResolveAjaxCallBackMode();
			}
		}
		private NameValueCollection QueryString
		{
			get
			{
				if (this._queryString == null)
				{
					return HttpContext.Current.Request.QueryString;
				}
				return this._queryString;
			}
			set
			{
				this._queryString = value;
			}
		}
		[DefaultValue(RenderingMode.Default), Description("The rendering mode of the grid. Default is 'Default'. Optimized may speed the grid up, but does not support all functionality.")]
		public RenderingMode RenderingMode
		{
			get
			{
				object obj = this.ViewState["RenderingMode"];
				if (obj == null)
				{
					return RenderingMode.Default;
				}
				return (RenderingMode)obj;
			}
			set
			{
				this.ViewState["RenderingMode"] = value;
			}
		}
		[DefaultValue(false), Description("Whether or not columns re-ordering is enabled. Default is false.")]
		public bool ColumnReordering
		{
			get
			{
				object obj = this.ViewState["ColumnReordering"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ColumnReordering"] = value;
			}
		}
		[DefaultValue(false)]
		public bool AutoWidth
		{
			get
			{
				object obj = this.ViewState["AutoWidth"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["AutoWidth"] = value;
			}
		}
		[DefaultValue(true), Obsolete("Property obsolete. Please, use JQGrid.ApperanceSettings.ShrinkToFit.", true)]
		public bool ShrinkToFit
		{
			get
			{
				object obj = this.ViewState["ShrinkToFit"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShrinkToFit"] = true;
			}
		}
		[DefaultValue(true)]
		public bool KeyboardNavigation
		{
			get
			{
				object obj = this.ViewState["KeyboardNavigation"];
				return obj == null || (bool)obj;
			}
			set
			{
				this.ViewState["KeyboardNavigation"] = value;
			}
		}
		[DefaultValue(false)]
		public bool MultiSelect
		{
			get
			{
				object obj = this.ViewState["MultiSelect"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["MultiSelect"] = value;
			}
		}
		[DefaultValue(MultiSelectMode.SelectOnRowClick)]
		public MultiSelectMode MultiSelectMode
		{
			get
			{
				object obj = this.ViewState["MultiSelectMode"];
				if (obj == null)
				{
					return MultiSelectMode.SelectOnRowClick;
				}
				return (MultiSelectMode)obj;
			}
			set
			{
				this.ViewState["MultiSelectMode"] = value;
			}
		}
		[DefaultValue(MultiSelectKey.None)]
		public MultiSelectKey MultiSelectKey
		{
			get
			{
				object obj = this.ViewState["MultiSelectKey"];
				if (obj == null)
				{
					return MultiSelectKey.None;
				}
				return (MultiSelectKey)obj;
			}
			set
			{
				this.ViewState["MultiSelectKey"] = value;
			}
		}
		[Category("ToolBar"), DefaultValue("")]
		public string SelectedRow
		{
			get
			{
				object obj = this.ViewState["SelectedRow"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["SelectedRow"] = value;
			}
		}
		[Category(""), DefaultValue("")]
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
		[Category(""), DefaultValue("")]
		public string EditUrl
		{
			get
			{
				object obj = this.ViewState["EditUrl"];
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
				this.ViewState["EditUrl"] = value;
			}
		}
		[Category("Default"), DefaultValue(null), Description("DataControls_Columns"), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual JQGridColumnCollection Columns
		{
			get
			{
				if (this._columnCollection == null)
				{
					this._columnCollection = new JQGridColumnCollection();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._columnCollection).TrackViewState();
					}
				}
				return this._columnCollection;
			}
		}
		[Category("Settings"), Description("Settings related to UI/Functionality of the Edit Dialog in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual EditDialogSettings EditDialogSettings
		{
			get
			{
				if (this._editDialogSettings == null)
				{
					this._editDialogSettings = new EditDialogSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._editDialogSettings).TrackViewState();
					}
				}
				return this._editDialogSettings;
			}
		}
		[Category("Settings"), Description("Settings related to UI/Functionality of the View Row Details Dialog in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual ViewRowDetailsDialogSettings ViewRowDetailsDialogSettings
		{
			get
			{
				if (this._viewRowDetailsDialogSettings == null)
				{
					this._viewRowDetailsDialogSettings = new ViewRowDetailsDialogSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._viewRowDetailsDialogSettings).TrackViewState();
					}
				}
				return this._viewRowDetailsDialogSettings;
			}
		}
		[Category("Settings"), Description("Settings related to UI/Functionality of the Add Dialog in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual AddDialogSettings AddDialogSettings
		{
			get
			{
				if (this._addDialogSettings == null)
				{
					this._addDialogSettings = new AddDialogSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._addDialogSettings).TrackViewState();
					}
				}
				return this._addDialogSettings;
			}
		}
		[Category("Settings"), Description("Settings related to UI/Functionality of the Delete Dialog in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual DeleteDialogSettings DeleteDialogSettings
		{
			get
			{
				if (this._deleteDialogSettings == null)
				{
					this._deleteDialogSettings = new DeleteDialogSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._deleteDialogSettings).TrackViewState();
					}
				}
				return this._deleteDialogSettings;
			}
		}
		[Category("Settings"), Description("Settings related to UI/Functionality of the Search Dialog in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual SearchDialogSettings SearchDialogSettings
		{
			get
			{
				if (this._searchDialogSettings == null)
				{
					this._searchDialogSettings = new SearchDialogSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._searchDialogSettings).TrackViewState();
					}
				}
				return this._searchDialogSettings;
			}
		}
		[Category("Settings"), Description("Settings related to UI/Functionality of the Search ToolBar in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual SearchToolBarSettings SearchToolBarSettings
		{
			get
			{
				if (this._searchToolBarSettings == null)
				{
					this._searchToolBarSettings = new SearchToolBarSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._searchToolBarSettings).TrackViewState();
					}
				}
				return this._searchToolBarSettings;
			}
		}
		[Category("Settings"), Description("Settings related to UI/Functionality of paging in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual PagerSettings PagerSettings
		{
			get
			{
				if (this._pagerSettings == null)
				{
					this._pagerSettings = new PagerSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._pagerSettings).TrackViewState();
					}
				}
				return this._pagerSettings;
			}
		}
		[Category("Settings"), Description("Settings related to UI/Functionality of the ToolBar in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual ToolBarSettings ToolBarSettings
		{
			get
			{
				if (this._toolBarSettings == null)
				{
					this._toolBarSettings = new ToolBarSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._toolBarSettings).TrackViewState();
					}
				}
				return this._toolBarSettings;
			}
		}
		[Category("Settings"), Description("Settings related to UI/Functionality of sorting in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual SortSettings SortSettings
		{
			get
			{
				if (this._sortSettings == null)
				{
					this._sortSettings = new SortSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._sortSettings).TrackViewState();
					}
				}
				return this._sortSettings;
			}
		}
		[Category("Settings"), Description("Settings related to appearance in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual AppearanceSettings AppearanceSettings
		{
			get
			{
				if (this._appearanceSettings == null)
				{
					this._appearanceSettings = new AppearanceSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._appearanceSettings).TrackViewState();
					}
				}
				return this._appearanceSettings;
			}
		}
		[Category("Settings"), Description("Settings related to Hierarchy in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual HierarchySettings HierarchySettings
		{
			get
			{
				if (this._hierarchySettings == null)
				{
					this._hierarchySettings = new HierarchySettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._hierarchySettings).TrackViewState();
					}
				}
				return this._hierarchySettings;
			}
		}
		[Category("Settings"), Description("Settings related to Inline Cell Editing in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual EditInlineCellSettings EditInlineCellSettings
		{
			get
			{
				if (this._editInlineCellSettings == null)
				{
					this._editInlineCellSettings = new EditInlineCellSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._editInlineCellSettings).TrackViewState();
					}
				}
				return this._editInlineCellSettings;
			}
		}
		[Category("Settings"), DefaultValue(null), Description("Settings related to Grouping"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), MergableProperty(false), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual GroupSettings GroupSettings
		{
			get
			{
				if (this._groupSettings == null)
				{
					this._groupSettings = new GroupSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._groupSettings).TrackViewState();
					}
				}
				return this._groupSettings;
			}
		}
		[Category("Settings"), DefaultValue(null), Description("Settings related to TreeGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), MergableProperty(false), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual TreeGridSettings TreeGridSettings
		{
			get
			{
				if (this._treeGridSettings == null)
				{
					this._treeGridSettings = new TreeGridSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._treeGridSettings).TrackViewState();
					}
				}
				return this._treeGridSettings;
			}
		}
		[Category("Settings"), DefaultValue(null), Description("Settings related to exporting"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), MergableProperty(false), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual ExportSettings ExportSettings
		{
			get
			{
				if (this._exportSettings == null)
				{
					this._exportSettings = new ExportSettings();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._exportSettings).TrackViewState();
					}
				}
				return this._exportSettings;
			}
		}
		[Category("Client-side events"), Description("Defines client-side events in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual ClientSideEvents ClientSideEvents
		{
			get
			{
				if (this._clientSideEvents == null)
				{
					this._clientSideEvents = new ClientSideEvents();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._clientSideEvents).TrackViewState();
					}
				}
				return this._clientSideEvents;
			}
		}
		[Category("Header Groups"), Description("Specifies header groups in the grid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual JQGridHeaderGroupCollection HeaderGroups
		{
			get
			{
				if (this._headerGroups == null)
				{
					this._headerGroups = new JQGridHeaderGroupCollection();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._headerGroups).TrackViewState();
					}
				}
				return this._headerGroups;
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
		static JQGrid()
		{
			JQGrid.EventSorted = new object();
			JQGrid.EventSorting = new object();
			JQGrid.EventSearched = new object();
			JQGrid.EventSearching = new object();
			JQGrid.EventRowAdding = new object();
			JQGrid.EventRowAdded = new object();
			JQGrid.EventRowEditing = new object();
			JQGrid.EventRowEdited = new object();
			JQGrid.EventRowDeleting = new object();
			JQGrid.EventRowDeleted = new object();
			JQGrid.EventRowSelecting = new object();
			JQGrid.EventCellBinding = new object();
			JQGrid.EventCellBound = new object();
			JQGrid.EventDataRequesting = new object();
			JQGrid.EventDataRequested = new object();
		}
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this._sr = new JavaScriptSerializer();
		}
		public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			string[] array = postCollection[postDataKey].Split(new char[]
			{
				','
			});
			string text = array[0];
			string value = array[1];
			if (!string.IsNullOrEmpty(text))
			{
				this.SelectedRow = text;
			}
			if (!string.IsNullOrEmpty(value))
			{
				this.PagerSettings.CurrentPage = Convert.ToInt32(value);
			}
			return false;
		}
		public void RaisePostDataChangedEvent()
		{
		}
		public void RaisePostBackEvent(string eventArgument)
		{
			this.SelectedRow = eventArgument;
			this.OnRowSelecting(new JQGridRowSelectEventArgs
			{
				RowKey = eventArgument
			});
		}
		protected override void LoadViewState(object savedState)
		{
			if (savedState != null)
			{
				object[] array = (object[])savedState;
				base.LoadViewState(array[0]);
				if (array[1] != null)
				{
					((IStateManager)this.ToolBarSettings).LoadViewState(array[1]);
				}
				if (array[2] != null)
				{
					((IStateManager)this.EditDialogSettings).LoadViewState(array[2]);
				}
				if (array[3] != null)
				{
					((IStateManager)this.SearchDialogSettings).LoadViewState(array[3]);
				}
				if (array[4] != null)
				{
					((IStateManager)this.PagerSettings).LoadViewState(array[4]);
				}
				if (array[5] != null)
				{
					((IStateManager)this.SortSettings).LoadViewState(array[5]);
				}
				if (array[6] != null)
				{
					((IStateManager)this.AppearanceSettings).LoadViewState(array[6]);
				}
				if (array[7] != null)
				{
					((IStateManager)this.AddDialogSettings).LoadViewState(array[7]);
				}
				if (array[8] != null)
				{
					((IStateManager)this.DeleteDialogSettings).LoadViewState(array[8]);
				}
				if (array[9] != null)
				{
					((IStateManager)this.EditInlineCellSettings).LoadViewState(array[9]);
				}
				if (array[10] != null)
				{
					((IStateManager)this.GroupSettings).LoadViewState(array[10]);
				}
				if (array[11] != null)
				{
					((IStateManager)this.SearchToolBarSettings).LoadViewState(array[11]);
				}
				if (array[12] != null)
				{
					((IStateManager)this.TreeGridSettings).LoadViewState(array[12]);
				}
				if (array[13] != null)
				{
					((IStateManager)this.ExportSettings).LoadViewState(array[13]);
				}
				if (array[14] != null)
				{
					((IStateManager)this.ViewRowDetailsDialogSettings).LoadViewState(array[14]);
					return;
				}
			}
			else
			{
				base.LoadViewState(null);
			}
		}
		protected override object SaveViewState()
		{
			object obj = base.SaveViewState();
			object obj2 = (this._toolBarSettings != null) ? ((IStateManager)this._toolBarSettings).SaveViewState() : null;
			object obj3 = (this._editDialogSettings != null) ? ((IStateManager)this._editDialogSettings).SaveViewState() : null;
			object obj4 = (this._searchDialogSettings != null) ? ((IStateManager)this._searchDialogSettings).SaveViewState() : null;
			object obj5 = (this._pagerSettings != null) ? ((IStateManager)this._pagerSettings).SaveViewState() : null;
			object obj6 = (this._sortSettings != null) ? ((IStateManager)this._sortSettings).SaveViewState() : null;
			object obj7 = (this._appearanceSettings != null) ? ((IStateManager)this._appearanceSettings).SaveViewState() : null;
			object obj8 = (this._addDialogSettings != null) ? ((IStateManager)this._addDialogSettings).SaveViewState() : null;
			object obj9 = (this._deleteDialogSettings != null) ? ((IStateManager)this._deleteDialogSettings).SaveViewState() : null;
			object obj10 = (this._editInlineCellSettings != null) ? ((IStateManager)this._editInlineCellSettings).SaveViewState() : null;
			object obj11 = (this._groupSettings != null) ? ((IStateManager)this._groupSettings).SaveViewState() : null;
			object obj12 = (this._searchToolBarSettings != null) ? ((IStateManager)this._searchToolBarSettings).SaveViewState() : null;
			object obj13 = (this._treeGridSettings != null) ? ((IStateManager)this._treeGridSettings).SaveViewState() : null;
			object obj14 = (this._exportSettings != null) ? ((IStateManager)this._exportSettings).SaveViewState() : null;
			object obj15 = (this._viewRowDetailsDialogSettings != null) ? ((IStateManager)this._viewRowDetailsDialogSettings).SaveViewState() : null;
			return new object[]
			{
				obj,
				obj2,
				obj3,
				obj4,
				obj5,
				obj6,
				obj7,
				obj8,
				obj9,
				obj10,
				obj11,
				obj12,
				obj13,
				obj14,
				obj15
			};
		}
		protected override void TrackViewState()
		{
			base.TrackViewState();
			if (this._toolBarSettings != null)
			{
				((IStateManager)this._toolBarSettings).TrackViewState();
			}
			if (this._editDialogSettings != null)
			{
				((IStateManager)this._editDialogSettings).TrackViewState();
			}
			if (this._searchDialogSettings != null)
			{
				((IStateManager)this._searchDialogSettings).TrackViewState();
			}
			if (this._searchToolBarSettings != null)
			{
				((IStateManager)this._searchToolBarSettings).TrackViewState();
			}
			if (this._pagerSettings != null)
			{
				((IStateManager)this._pagerSettings).TrackViewState();
			}
			if (this._sortSettings != null)
			{
				((IStateManager)this._sortSettings).TrackViewState();
			}
			if (this._appearanceSettings != null)
			{
				((IStateManager)this._appearanceSettings).TrackViewState();
			}
			if (this._addDialogSettings != null)
			{
				((IStateManager)this._addDialogSettings).TrackViewState();
			}
			if (this._deleteDialogSettings != null)
			{
				((IStateManager)this._deleteDialogSettings).TrackViewState();
			}
			if (this._toolBarSettings != null)
			{
				((IStateManager)this._toolBarSettings).TrackViewState();
			}
			if (this._editInlineCellSettings != null)
			{
				((IStateManager)this._editInlineCellSettings).TrackViewState();
			}
			if (this._groupSettings != null)
			{
				((IStateManager)this._groupSettings).TrackViewState();
			}
			if (this._treeGridSettings != null)
			{
				((IStateManager)this._treeGridSettings).TrackViewState();
			}
			if (this._exportSettings != null)
			{
				((IStateManager)this._exportSettings).TrackViewState();
			}
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
			switch (this.AjaxCallBackMode)
			{
			case AjaxCallBackMode.RequestData:
			case AjaxCallBackMode.Search:
				this.PerformRequestData(retrievedData);
				return;
			case AjaxCallBackMode.EditRow:
				this.PerformRowEdit();
				return;
			case AjaxCallBackMode.AddRow:
				this.PerformRowAdd();
				return;
			case AjaxCallBackMode.DeleteRow:
				this.PerformRowDelete();
				return;
			default:
				return;
			}
		}
		private void PerformRequestData(IEnumerable retrievedData)
		{
			DataView defaultView = this.GetDataTableFromIEnumerable(retrievedData).DefaultView;
			int num = Convert.ToInt32(this.QueryString["page"]);
			int num2 = Convert.ToInt32(this.QueryString["rows"]);
			string sortExpression = this.QueryString["sidx"];
			string sortDirection = this.QueryString["sord"];
			string search = this.QueryString["_search"];
			if (this._totalRows > 0)
			{
				this._selectArguments.TotalRowCount = this._totalRows;
			}
			if (this._filteredGridState != null && this.ExportSettings.ExportDataRange != ExportDataRange.FilteredAndPaged)
			{
				num = 1;
			}
			this.PerformSearch(defaultView, search);
			int num3 = (this._selectArguments.TotalRowCount > -1) ? this._selectArguments.TotalRowCount : defaultView.Count;
			int totalPagesCount = (int)Math.Ceiling((double)((float)num3 / (float)num2));
			if (!this._dataSourceSorted)
			{
				this.PerformSort(defaultView, sortExpression, sortDirection);
			}
			else
			{
				new JQGridSortEventArgs(sortExpression, sortDirection);
				this.OnSorted(new EventArgs());
			}
			DataTable dataTable = defaultView.ToTable();
			DataTable dataTable2 = dataTable;
			if ((num - 1) * num2 >= num3 && num > 1)
			{
				num--;
			}
			int startIndex = (num - 1) * num2;
			int num4 = (num - 1) * num2 + num2;
			if (num4 > num3)
			{
				num4 = num3;
			}
			if (num4 <= dataTable.Rows.Count)
			{
				dataTable2 = this.GetPagedDataTable(startIndex, num4, dataTable);
			}
			JQGrid.JQGridDataRequestedEventHandler jQGridDataRequestedEventHandler = (JQGrid.JQGridDataRequestedEventHandler)base.Events[JQGrid.EventDataRequested];
			if (jQGridDataRequestedEventHandler != null)
			{
				this.OnDataRequested(new JQGridDataRequestedEventArgs(dataTable2));
			}
			if (this.IsGridExportActive())
			{
				DataTable dataSource = dataTable;
				if (this.ExportSettings.ExportDataRange == ExportDataRange.FilteredAndPaged)
				{
					dataSource = dataTable2;
				}
				if (this._filteredExcelExportActive)
				{
					this.DoExportToExcel(this._filteredExportFileName, this._filteredGridState, dataSource);
				}
				if (this._filteredCSVExportActive)
				{
					this.DoExportToCSV(this._filteredExportFileName, this._filteredGridState, dataSource);
				}
				if (this._filteredExportActive)
				{
					this.DoExportGridData(this._filteredGridState, dataSource);
				}
				return;
			}
			if (this.TreeGridSettings.Enabled)
			{
				JsonTreeResponse response = new JsonTreeResponse(num, totalPagesCount, num3, num2, dataTable2.Rows.Count, Util.GetFooterInfo(this));
				HttpContext.Current.Response.SendResponse(Util.ConvertToTreeJson(response, this, dataTable));
				return;
			}
			JsonResponse response2 = new JsonResponse(num, totalPagesCount, num3, num2, dataTable2.Rows.Count, Util.GetFooterInfo(this));
			HttpContext.Current.Response.SendResponse(Util.ConvertToJson(response2, this, dataTable2));
		}
		private Hashtable GetFooterInfo()
		{
			Hashtable hashtable = new Hashtable();
			if (this.AppearanceSettings.ShowFooter)
			{
				foreach (JQGridColumn jQGridColumn in this.Columns)
				{
					hashtable[jQGridColumn.DataField] = jQGridColumn.FooterValue;
				}
			}
			return hashtable;
		}
		private DataTable GetPagedDataTable(int startIndex, int endIndex, DataTable dt)
		{
			DataTable dataTable = new DataTable();
			foreach (DataColumn dataColumn in dt.Columns)
			{
				dataTable.Columns.Add(dataColumn.ColumnName, dataColumn.DataType);
			}
			for (int i = startIndex; i < endIndex; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				for (int j = 0; j < dt.Columns.Count; j++)
				{
					dataRow[j] = dt.Rows[i][j];
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
		private void PerformSort(DataView view, string sortExpression, string sortDirection)
		{
			if (!string.IsNullOrEmpty(sortExpression))
			{
				JQGridSortEventArgs jQGridSortEventArgs = new JQGridSortEventArgs(sortExpression, sortDirection);
				this.OnSorting(jQGridSortEventArgs);
				if (!string.IsNullOrEmpty(jQGridSortEventArgs.NewSortExpression))
				{
					view.Sort = jQGridSortEventArgs.NewSortExpression;
				}
				else
				{
					if (!jQGridSortEventArgs.Cancel && view.Count > 0)
					{
						view.Sort = this.GetSortExpression(sortExpression, sortDirection);
					}
				}
				this.OnSorted(new EventArgs());
			}
		}
		private void PerformSearch(DataView view, string search)
		{
			if (!string.IsNullOrEmpty(search) && Convert.ToBoolean(search))
			{
				string text = this.QueryString["filters"];
				string text2 = this.QueryString["searchField"];
				string searchString = this.QueryString["searchString"];
				string searchOperation = this.QueryString["searchOper"];
				if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
				{
					new Searching(this, text2, searchString, searchOperation).PerformSearch(view, search);
					return;
				}
				if (!string.IsNullOrEmpty(text))
				{
					new MultipleSearching(this, text).PerformSearch(view);
					return;
				}
				if (this.ToolBarSettings.ShowSearchToolBar)
				{
					new ToolBarSearching(this).PerformSearch(view);
				}
			}
		}
		private void PerformRowAdd()
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			foreach (string name in HttpContext.Current.Request.Form.Keys)
			{
				nameValueCollection[name] = HttpContext.Current.Request.Form[name];
			}
			JQGridRowAddEventArgs jQGridRowAddEventArgs = new JQGridRowAddEventArgs();
			jQGridRowAddEventArgs.RowData = nameValueCollection;
			string text = this.QueryString["parentRowID"];
			if (!string.IsNullOrEmpty(text))
			{
				jQGridRowAddEventArgs.ParentRowKey = text;
			}
			this.OnRowAdding(jQGridRowAddEventArgs);
			if (!jQGridRowAddEventArgs.Cancel)
			{
				this.HandleInsert(jQGridRowAddEventArgs);
			}
			this.OnRowAdded(new EventArgs());
		}
		private void HandleInsert(JQGridRowAddEventArgs e)
		{
			if (base.IsBoundUsingDataSourceID)
			{
				OrderedDictionary orderedDictionary = new OrderedDictionary();
				DataSourceView data = this.GetData();
				if (data == null)
				{
					throw new HttpException("DataSource is null in edit mode (on update)");
				}
				foreach (string text in e.RowData.Keys)
				{
					orderedDictionary.Add(text, e.RowData[text]);
				}
				data.Insert(orderedDictionary, new DataSourceViewOperationCallback(this.HandleInsertCallback));
			}
		}
		private bool HandleInsertCallback(int affectedRows, Exception ex)
		{
			if (ex != null)
			{
				throw ex;
			}
			return true;
		}
		private void PerformRowEdit()
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			foreach (string text in HttpContext.Current.Request.Form.Keys)
			{
				if (text != "oper")
				{
					nameValueCollection[text] = HttpContext.Current.Request.Form[text];
				}
			}
			string text2 = string.Empty;
			foreach (JQGridColumn jQGridColumn in this.Columns)
			{
				if (jQGridColumn.PrimaryKey)
				{
					text2 = jQGridColumn.DataField;
					break;
				}
			}
			if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(nameValueCollection["id"]))
			{
				nameValueCollection[text2] = nameValueCollection["id"];
			}
			JQGridRowEditEventArgs jQGridRowEditEventArgs = new JQGridRowEditEventArgs();
			jQGridRowEditEventArgs.RowData = nameValueCollection;
			jQGridRowEditEventArgs.RowKey = nameValueCollection["id"];
			string text3 = this.QueryString["parentRowID"];
			if (!string.IsNullOrEmpty(text3))
			{
				jQGridRowEditEventArgs.ParentRowKey = text3;
			}
			this.OnRowEditing(jQGridRowEditEventArgs);
			if (!jQGridRowEditEventArgs.Cancel)
			{
				this.HandleUpdate(jQGridRowEditEventArgs);
			}
			this.OnRowEdited(jQGridRowEditEventArgs);
		}
		private void HandleUpdate(JQGridRowEditEventArgs e)
		{
			if (base.IsBoundUsingDataSourceID)
			{
				OrderedDictionary orderedDictionary = new OrderedDictionary();
				OrderedDictionary orderedDictionary2 = new OrderedDictionary();
				OrderedDictionary oldValues = new OrderedDictionary();
				DataSourceView data = this.GetData();
				if (data == null)
				{
					throw new HttpException("DataSource is null in edit mode (on update)");
				}
				foreach (JQGridColumn jQGridColumn in this.Columns)
				{
					if (jQGridColumn.PrimaryKey)
					{
						orderedDictionary.Add(jQGridColumn.DataField, e.RowData[jQGridColumn.DataField]);
					}
					if (jQGridColumn.Editable)
					{
						orderedDictionary2.Add(jQGridColumn.DataField, e.RowData[jQGridColumn.DataField]);
					}
				}
				data.Update(orderedDictionary, orderedDictionary2, oldValues, new DataSourceViewOperationCallback(this.HandleUpdateCallback));
			}
		}
		private bool HandleUpdateCallback(int affectedRows, Exception ex)
		{
			if (ex != null)
			{
				throw ex;
			}
			return true;
		}
		private void PerformRowDelete()
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			foreach (string name in HttpContext.Current.Request.Form.Keys)
			{
				nameValueCollection[name] = HttpContext.Current.Request.Form[name];
			}
			JQGridRowDeleteEventArgs jQGridRowDeleteEventArgs = new JQGridRowDeleteEventArgs();
			jQGridRowDeleteEventArgs.RowKey = nameValueCollection["id"];
			this.OnRowDeleting(jQGridRowDeleteEventArgs);
			if (!jQGridRowDeleteEventArgs.Cancel)
			{
				this.HandleDelete(jQGridRowDeleteEventArgs);
			}
			this.OnRowDeleted(new EventArgs());
		}
		private void HandleDelete(JQGridRowDeleteEventArgs e)
		{
			if (base.IsBoundUsingDataSourceID)
			{
				OrderedDictionary orderedDictionary = new OrderedDictionary();
				OrderedDictionary oldValues = new OrderedDictionary();
				new OrderedDictionary();
				DataSourceView data = this.GetData();
				if (data == null)
				{
					throw new HttpException("DataSource is null in edit mode (on update)");
				}
				foreach (JQGridColumn jQGridColumn in this.Columns)
				{
					if (jQGridColumn.PrimaryKey)
					{
						orderedDictionary.Add(jQGridColumn.DataField, e.RowKey);
					}
				}
				data.Delete(orderedDictionary, oldValues, new DataSourceViewOperationCallback(this.HandleDeleteCallback));
			}
		}
		private bool HandleDeleteCallback(int affectedRows, Exception ex)
		{
			if (ex != null)
			{
				throw ex;
			}
			return true;
		}
		private void ProcessCallBack()
		{
			int num = Convert.ToInt32(this.QueryString["page"]);
			int pageSize = Convert.ToInt32(this.QueryString["rows"]);
			string sortExpression = this.QueryString["sidx"];
			string sortDirection = this.QueryString["sord"];
			string search = this.QueryString["_search"];
			string parentRowKey = this.QueryString["parentRowID"];
			if (this._filteredGridState != null && this.ExportSettings.ExportDataRange != ExportDataRange.FilteredAndPaged)
			{
				num = 1;
				pageSize = 1000000;
			}
			this.PagerSettings.CurrentPage = num;
			this.PagerSettings.PageSize = pageSize;
			JQGrid.JQGridDataRequestEventHandler jQGridDataRequestEventHandler = (JQGrid.JQGridDataRequestEventHandler)base.Events[JQGrid.EventDataRequesting];
			if (jQGridDataRequestEventHandler != null)
			{
				string whereClause = this.GetWhereClause(search, false);
				JQGridDataRequestEventArgs jQGridDataRequestEventArgs = new JQGridDataRequestEventArgs(sortExpression, sortDirection, num, whereClause, parentRowKey);
				this.OnDataRequesting(jQGridDataRequestEventArgs);
				if (jQGridDataRequestEventArgs.TotalRows > 0)
				{
					this._totalRows = jQGridDataRequestEventArgs.TotalRows;
				}
			}
			if (this.IsGridRequest())
			{
				this._selectArguments = this.CreateDataSourceSelectArguments();
				this.GetData().Select(this._selectArguments, new DataSourceViewSelectCallback(this.OnDataSourceViewSelectCallback));
			}
		}
		internal void FilterDataSource(JQGridState gridState)
		{
			this.QueryString = gridState.QueryString;
			this.ProcessCallBack();
		}
		protected override DataSourceSelectArguments CreateDataSourceSelectArguments()
		{
			Convert.ToInt32(this.QueryString["page"]);
			Convert.ToInt32(this.QueryString["rows"]);
			string text = this.QueryString["sidx"];
			string sortDirection = this.QueryString["sord"];
			string search = this.QueryString["_search"];
			string arg_6F_0 = this.QueryString["parentRowID"];
			if (this._filteredGridState != null)
			{
				ExportDataRange arg_85_0 = this.ExportSettings.ExportDataRange;
			}
			DataSourceSelectArguments dataSourceSelectArguments = new DataSourceSelectArguments();
			DataSourceView data = this.GetData();
			if (data is LinqDataSourceView)
			{
				LinqDataSourceView linqDataSourceView = data as LinqDataSourceView;
				linqDataSourceView.Where = this.GetWhereClause(search, true);
			}
			if (data.CanSort && !string.IsNullOrEmpty(text))
			{
				JQGridSortEventArgs jQGridSortEventArgs = new JQGridSortEventArgs(text, sortDirection);
				this.OnSorting(jQGridSortEventArgs);
				this._dataSourceSorted = true;
				if (!jQGridSortEventArgs.Cancel)
				{
					dataSourceSelectArguments.SortExpression = this.GetSortExpression(text, sortDirection);
				}
			}
			if (data.CanPage)
			{
				if (data.CanRetrieveTotalRowCount)
				{
					dataSourceSelectArguments.RetrieveTotalRowCount = true;
					dataSourceSelectArguments.MaximumRows = this.PagerSettings.PageSize;
				}
				else
				{
					dataSourceSelectArguments.MaximumRows = -1;
				}
				dataSourceSelectArguments.StartRowIndex = this.PagerSettings.PageSize * (this.PagerSettings.CurrentPage - 1);
			}
			return dataSourceSelectArguments;
		}
		private string GetSortExpression(string sortExpression, string sortDirection)
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<string> list = sortExpression.Split(new char[]
			{
				','
			}).ToList<string>();
			foreach (string current in list)
			{
				if (current.Trim().Length == 0)
				{
					break;
				}
				List<string> list2 = current.Trim().Split(new char[]
				{
					' '
				}).ToList<string>();
				string arg = list2[0];
				string arg2 = sortDirection;
				if (list2.Count > 1)
				{
					arg2 = list2[1];
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.AppendFormat("{0} {1}", arg, arg2);
			}
			return stringBuilder.ToString();
		}
		private string GetWhereClause(string search, bool isLinq)
		{
			string result = string.Empty;
			if (!string.IsNullOrEmpty(search) || Convert.ToBoolean(search))
			{
				result = new BaseSearching(this).GetWhereClause(null, isLinq);
			}
			return result;
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			if (this.Page != null)
			{
				if (this.IsGridRequest() && !this.IsGridExportActive())
				{
					this.ProcessCallBack();
					return;
				}
				this.EnforceColumnContraints();
				JQGridRenderer jQGridRenderer = new JQGridRenderer(this);
				string script = (this.HierarchySettings.HierarchyMode == HierarchyMode.Child || this.HierarchySettings.HierarchyMode == HierarchyMode.ParentAndChild) ? jQGridRenderer.GetChildSubGridJavaScript() : jQGridRenderer.GetStartupJavascript();
				ScriptManager.RegisterStartupScript(this, typeof(JQGrid), "_jqrid_startup" + this.ClientID, script, false);
			}
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
				Guard.IsNullOrEmpty(this.ID, "ID", "You need to set ID for this JQGrid instance.");
				JQGridRenderer jQGridRenderer = new JQGridRenderer(this);
				jQGridRenderer.RenderHtml(writer);
			}
		}
		private int GetPrimaryKeyIndex()
		{
			foreach (JQGridColumn jQGridColumn in this.Columns)
			{
				if (jQGridColumn.PrimaryKey)
				{
					return this.Columns.IndexOf(jQGridColumn);
				}
			}
			return 0;
		}
		private void EnforceColumnContraints()
		{
			string message = "Columns should be explicitly defined with at least DataField set to the respective datasource field, e.g. \r\n                                        <trirand:jqGrid ...>\r\n                                             <Columns>\r\n                                                <trirand:JQGridColumn DataField='OrderID' PrimaryKey='True' />\r\n                                                <trirand:JQGridColumn DataField='Freight' Editable='true' Sortable='false'  />\r\n                                                <trirand:JQGridColumn DataField='OrderDate' DataFormatString='{0:d}' />\r\n                                                <trirand:JQGridColumn DataField='ShipCity' />\r\n                                            </Columns>\r\n                                            ...";
			if (this.Columns.Count == 0)
			{
				throw new Exception(message);
			}
		}
		private DataTable GetDataTableFromIEnumerable(IEnumerable en)
		{
			DataTable result = new DataTable();
			DataView dataView = en as DataView;
			if (dataView != null)
			{
				result = dataView.ToTable();
			}
			else
			{
				if (en != null)
				{
					result = this.ObtainDataTableFromIEnumerable(en);
				}
			}
			return result;
		}
		private DataTable ObtainDataTableFromIEnumerable(IEnumerable ien)
		{
			DataTable dataTable = new DataTable();
			foreach (object current in ien)
			{
				if (current is DbDataRecord)
				{
					DbDataRecord dbDataRecord = current as DbDataRecord;
					if (dataTable.Columns.Count == 0)
					{
						foreach (JQGridColumn jQGridColumn in this.Columns)
						{
							dataTable.Columns.Add(jQGridColumn.DataField);
						}
					}
					DataRow dataRow = dataTable.NewRow();
					foreach (JQGridColumn jQGridColumn2 in this.Columns)
					{
						dataRow[jQGridColumn2.DataField] = dbDataRecord[jQGridColumn2.DataField];
					}
					dataTable.Rows.Add(dataRow);
				}
				else
				{
					Type type = current.GetType();
					PropertyInfo[] properties = type.GetProperties();
					if (dataTable.Columns.Count == 0)
					{
						PropertyInfo[] array = properties;
						for (int i = 0; i < array.Length; i++)
						{
							PropertyInfo propertyInfo = array[i];
							Type type2 = propertyInfo.PropertyType;
							if (type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(Nullable<>))
							{
								type2 = Nullable.GetUnderlyingType(type2);
							}
							dataTable.Columns.Add(propertyInfo.Name, type2);
						}
					}
					DataRow dataRow2 = dataTable.NewRow();
					PropertyInfo[] array2 = properties;
					for (int j = 0; j < array2.Length; j++)
					{
						PropertyInfo propertyInfo2 = array2[j];
						object value = propertyInfo2.GetValue(current, null);
						if (value != null)
						{
							dataRow2[propertyInfo2.Name] = value;
						}
						else
						{
							dataRow2[propertyInfo2.Name] = DBNull.Value;
						}
					}
					dataTable.Rows.Add(dataRow2);
				}
			}
			return dataTable;
		}
		private bool IsGridRequest()
		{
			string text = this.QueryString["jqGridID"];
			return !string.IsNullOrEmpty(text) && text == this.ClientID;
		}
		private bool IsGridExportActive()
		{
			return this._filteredExcelExportActive || this._filteredCSVExportActive || this._filteredExportActive;
		}
		internal Control FindControlRecursive(Control root, string id)
		{
			if (root.ID == id)
			{
				return root;
			}
			foreach (Control root2 in root.Controls)
			{
				Control control = this.FindControlRecursive(root2, id);
				if (control != null)
				{
					return control;
				}
			}
			return null;
		}
		protected virtual void OnSorting(JQGridSortEventArgs e)
		{
			bool arg_06_0 = base.IsBoundUsingDataSourceID;
			JQGrid.JQGridSortEventHandler jQGridSortEventHandler = (JQGrid.JQGridSortEventHandler)base.Events[JQGrid.EventSorting];
			if (jQGridSortEventHandler != null)
			{
				jQGridSortEventHandler(this, e);
			}
		}
		public virtual bool IsBindableType(Type type)
		{
			if (type == null)
			{
				return false;
			}
			Type underlyingType = Nullable.GetUnderlyingType(type);
			if (underlyingType != null)
			{
				type = underlyingType;
			}
			return type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) || type == typeof(decimal) || type == typeof(Guid) || type == typeof(DateTimeOffset) || type == typeof(TimeSpan);
		}
		public void ShowEditValidationMessage(string errorMessage)
		{
			try
			{
				HttpContext.Current.Response.Clear();
				HttpContext.Current.Response.StatusCode = 500;
				HttpContext.Current.Response.StatusDescription = errorMessage;
				HttpContext.Current.Response.Write(errorMessage);
				HttpContext.Current.Response.Flush();
				HttpContext.Current.Response.SuppressContent = true;
			}
			catch (Exception)
			{
			}
		}
		private AjaxCallBackMode ResolveAjaxCallBackMode()
		{
			if (this.IsGridRequest())
			{
				string text = HttpContext.Current.Request.Form["oper"];
				string value = this.QueryString["editMode"];
				string value2 = this.QueryString["_search"];
				this._ajaxCallBackMode = AjaxCallBackMode.RequestData;
				string a;
				if (!string.IsNullOrEmpty(text) && (a = text) != null)
				{
					if (a == "add")
					{
						this._ajaxCallBackMode = AjaxCallBackMode.AddRow;
						return this._ajaxCallBackMode;
					}
					if (a == "edit")
					{
						this._ajaxCallBackMode = AjaxCallBackMode.EditRow;
						return this._ajaxCallBackMode;
					}
					if (a == "del")
					{
						this._ajaxCallBackMode = AjaxCallBackMode.DeleteRow;
						return this._ajaxCallBackMode;
					}
				}
				if (!string.IsNullOrEmpty(value))
				{
					this._ajaxCallBackMode = AjaxCallBackMode.EditRow;
				}
				if (!string.IsNullOrEmpty(value2) && Convert.ToBoolean(value2))
				{
					this._ajaxCallBackMode = AjaxCallBackMode.Search;
				}
			}
			return this._ajaxCallBackMode;
		}
		private void HandleUpdate()
		{
			bool isBoundUsingDataSourceID = base.IsBoundUsingDataSourceID;
			if (isBoundUsingDataSourceID && this.GetData() == null)
			{
				throw new HttpException("DataSource is null in edit mode (on update)");
			}
		}
		protected virtual void OnSorted(EventArgs e)
		{
			EventHandler eventHandler = (EventHandler)base.Events[JQGrid.EventSorted];
			if (eventHandler != null)
			{
				eventHandler(this, e);
			}
		}
		protected internal virtual void OnSearching(JQGridSearchEventArgs e)
		{
			JQGrid.JQGridSearchEventHandler jQGridSearchEventHandler = (JQGrid.JQGridSearchEventHandler)base.Events[JQGrid.EventSearching];
			if (jQGridSearchEventHandler != null)
			{
				jQGridSearchEventHandler(this, e);
			}
		}
		protected internal virtual void OnSearched(EventArgs e)
		{
			EventHandler eventHandler = (EventHandler)base.Events[JQGrid.EventSearched];
			if (eventHandler != null)
			{
				eventHandler(this, e);
			}
		}
		protected internal virtual void OnRowAdding(JQGridRowAddEventArgs e)
		{
			JQGrid.JQGridRowAddEventHandler jQGridRowAddEventHandler = (JQGrid.JQGridRowAddEventHandler)base.Events[JQGrid.EventRowAdding];
			if (jQGridRowAddEventHandler != null)
			{
				jQGridRowAddEventHandler(this, e);
			}
		}
		protected internal virtual void OnRowAdded(EventArgs e)
		{
			EventHandler eventHandler = (EventHandler)base.Events[JQGrid.EventRowAdded];
			if (eventHandler != null)
			{
				eventHandler(this, e);
			}
		}
		protected internal virtual void OnRowEditing(JQGridRowEditEventArgs e)
		{
			JQGrid.JQGridRowEditEventHandler jQGridRowEditEventHandler = (JQGrid.JQGridRowEditEventHandler)base.Events[JQGrid.EventRowEditing];
			if (jQGridRowEditEventHandler != null)
			{
				jQGridRowEditEventHandler(this, e);
			}
		}
		protected internal virtual void OnRowEdited(JQGridRowEditEventArgs e)
		{
			JQGrid.JQGridRowEditEventHandler jQGridRowEditEventHandler = (JQGrid.JQGridRowEditEventHandler)base.Events[JQGrid.EventRowEdited];
			if (jQGridRowEditEventHandler != null)
			{
				jQGridRowEditEventHandler(this, e);
			}
		}
		protected internal virtual void OnRowDeleting(JQGridRowDeleteEventArgs e)
		{
			JQGrid.JQGridRowDeleteEventHandler jQGridRowDeleteEventHandler = (JQGrid.JQGridRowDeleteEventHandler)base.Events[JQGrid.EventRowDeleting];
			if (jQGridRowDeleteEventHandler != null)
			{
				jQGridRowDeleteEventHandler(this, e);
			}
		}
		protected internal virtual void OnRowDeleted(EventArgs e)
		{
			EventHandler eventHandler = (EventHandler)base.Events[JQGrid.EventRowDeleted];
			if (eventHandler != null)
			{
				eventHandler(this, e);
			}
		}
		protected internal virtual void OnRowSelecting(JQGridRowSelectEventArgs e)
		{
			JQGrid.JQGridRowSelectEventHandler jQGridRowSelectEventHandler = (JQGrid.JQGridRowSelectEventHandler)base.Events[JQGrid.EventRowSelecting];
			if (jQGridRowSelectEventHandler != null)
			{
				jQGridRowSelectEventHandler(this, e);
			}
		}
		protected internal virtual void OnCellBinding(JQGridCellBindEventArgs e)
		{
			JQGrid.JQGridCellBindEventHandler jQGridCellBindEventHandler = (JQGrid.JQGridCellBindEventHandler)base.Events[JQGrid.EventCellBinding];
			if (jQGridCellBindEventHandler != null)
			{
				jQGridCellBindEventHandler(this, e);
			}
		}
		protected internal virtual void OnCellBound(JQGridCellBindEventArgs e)
		{
			JQGrid.JQGridCellBindEventHandler jQGridCellBindEventHandler = (JQGrid.JQGridCellBindEventHandler)base.Events[JQGrid.EventCellBound];
			if (jQGridCellBindEventHandler != null)
			{
				jQGridCellBindEventHandler(this, e);
			}
		}
		protected internal virtual void OnDataRequesting(JQGridDataRequestEventArgs e)
		{
			JQGrid.JQGridDataRequestEventHandler jQGridDataRequestEventHandler = (JQGrid.JQGridDataRequestEventHandler)base.Events[JQGrid.EventDataRequesting];
			if (jQGridDataRequestEventHandler != null)
			{
				jQGridDataRequestEventHandler(this, e);
			}
		}
		protected internal virtual void OnDataRequested(JQGridDataRequestedEventArgs e)
		{
			JQGrid.JQGridDataRequestedEventHandler jQGridDataRequestedEventHandler = (JQGrid.JQGridDataRequestedEventHandler)base.Events[JQGrid.EventDataRequested];
			if (jQGridDataRequestedEventHandler != null)
			{
				jQGridDataRequestedEventHandler(this, e);
			}
		}
		public JQGridTreeExpandData GetTreeExpandData()
		{
			JQGridTreeExpandData jQGridTreeExpandData = new JQGridTreeExpandData();
			if (HttpContext.Current.Request["nodeid"] != null)
			{
				jQGridTreeExpandData.ParentID = HttpContext.Current.Request["nodeid"];
			}
			if (HttpContext.Current.Request["n_level"] != null)
			{
				jQGridTreeExpandData.ParentLevel = Convert.ToInt32(HttpContext.Current.Request["n_level"]);
			}
			return jQGridTreeExpandData;
		}
		private DataGrid GetExportGrid()
		{
			DataGrid dataGrid = new DataGrid();
			this.Controls.Add(dataGrid);
			dataGrid.AutoGenerateColumns = false;
			dataGrid.ID = this.ID + "_exportGrid";
			foreach (JQGridColumn jQGridColumn in this.Columns)
			{
				if (jQGridColumn.Visible)
				{
					BoundColumn boundColumn = new BoundColumn();
					boundColumn.DataField = jQGridColumn.DataField;
					string headerText = string.IsNullOrEmpty(jQGridColumn.HeaderText) ? jQGridColumn.DataField : jQGridColumn.HeaderText;
					boundColumn.HeaderText = headerText;
					boundColumn.DataFormatString = jQGridColumn.DataFormatString;
					boundColumn.FooterText = jQGridColumn.FooterValue;
					dataGrid.Columns.Add(boundColumn);
				}
			}
			return dataGrid;
		}
		public JQGridState GetState()
		{
			return new JQGridState
			{
				QueryString = HttpContext.Current.Request.QueryString
			};
		}
		public void ExportToCSV(string fileName)
		{
			DataGrid exportGrid = this.GetExportGrid();
			exportGrid.DataSource = this.DataSource;
			exportGrid.DataSourceID = this.DataSourceID;
			exportGrid.DataBind();
			this.RenderCSVToStream(exportGrid, fileName);
		}
		public void ExportToCSV(string fileName, JQGridState gridState)
		{
			this._filteredExportFileName = fileName;
			this._filteredGridState = gridState;
			this._filteredCSVExportActive = true;
			this.FilterDataSource(gridState);
		}
		private void DoExportToCSV(string fileName, JQGridState gridState, DataTable dataSource)
		{
			DataGrid exportGrid = this.GetExportGrid();
			exportGrid.DataSource = dataSource;
			exportGrid.DataBind();
			this.RenderCSVToStream(exportGrid, fileName);
			this._exportActive = true;
		}
		private void RenderCSVToStream(DataGrid grid, string fileName)
		{
			if (!this._exportActive)
			{
				HttpContext.Current.Response.ClearContent();
				HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
				HttpContext.Current.Response.ContentType = "application/excel";
				HttpContext.Current.Response.ContentEncoding = Encoding.Default;
				StringBuilder stringBuilder = new StringBuilder();
				if (this.ExportSettings.ExportHeaders)
				{
					foreach (BoundColumn boundColumn in grid.Columns)
					{
						stringBuilder.AppendFormat("{0}{1}", this.QuoteText(boundColumn.HeaderText), this.ExportSettings.CSVSeparator);
					}
				}
				stringBuilder.Append("\n");
				foreach (DataGridItem dataGridItem in grid.Items)
				{
					for (int i = 0; i < this.Columns.Count; i++)
					{
						if (this.Columns[i].Visible)
						{
							stringBuilder.AppendFormat("{0}{1}", this.QuoteText(dataGridItem.Cells[i].Text), this.ExportSettings.CSVSeparator);
						}
					}
					stringBuilder.Append("\n");
				}
				HttpContext.Current.Response.SendResponse(stringBuilder.ToString());
			}
		}
		private string QuoteText(string input)
		{
			return string.Format("\"{0}\"", input.Replace("\"", "\"\""));
		}
		public void ExportToExcel(string fileName)
		{
			DataGrid exportGrid = this.GetExportGrid();
			exportGrid.DataSource = this.DataSource;
			exportGrid.DataSourceID = this.DataSourceID;
			exportGrid.DataBind();
			this.RenderExcelToStream(exportGrid, fileName);
		}
		public void ExportToExcel(string fileName, JQGridState gridState)
		{
			this._filteredExportFileName = fileName;
			this._filteredGridState = gridState;
			this._filteredExcelExportActive = true;
			this.FilterDataSource(gridState);
		}
		private void DoExportToExcel(string fileName, JQGridState gridState, DataTable dataSource)
		{
			DataGrid exportGrid = this.GetExportGrid();
			exportGrid.DataSource = dataSource;
			exportGrid.DataBind();
			this.RenderExcelToStream(exportGrid, fileName);
			this._exportActive = true;
		}
		private void RenderExcelToStream(DataGrid grid, string fileName)
		{
			if (!this._exportActive)
			{
				HttpContext.Current.Response.ClearContent();
				HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
				HttpContext.Current.Response.ContentType = "application/excel";
				StringWriter stringWriter = new StringWriter();
				HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
				grid.RenderControl(writer);
				HttpContext.Current.Response.SendResponse(stringWriter.ToString());
			}
		}
		public DataTable GetExportData()
		{
			DataGrid exportGrid = this.GetExportGrid();
			exportGrid.DataSource = this.DataSource;
			exportGrid.DataSourceID = this.DataSourceID;
			exportGrid.DataBind();
			return this.ConvertDataGridToDataTable(exportGrid);
		}
		public void GetExportData(JQGridState gridState, JQGridExportDataCallBack callBack)
		{
			this._filteredExportActive = true;
			this._filteredGridState = gridState;
			this._filteredExportCallBack = callBack;
			this.FilterDataSource(gridState);
		}
		private void DoExportGridData(JQGridState gridState, DataTable dataSource)
		{
			this._exportActive = true;
			this._filteredExportCallBack(dataSource);
		}
		private DataTable ConvertDataGridToDataTable(DataGrid grid)
		{
			DataTable dataTable = new DataTable();
			foreach (DataGridColumn dataGridColumn in grid.Columns)
			{
				dataTable.Columns.Add(dataGridColumn.HeaderText);
			}
			foreach (DataGridItem dataGridItem in grid.Items)
			{
				DataRow dataRow = dataTable.NewRow();
				for (int i = 0; i < grid.Columns.Count; i++)
				{
					dataRow[i] = dataGridItem.Cells[i].Text;
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
	}
}
