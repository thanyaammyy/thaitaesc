using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class ClientSideEvents : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Client-Side Events"), DefaultValue(""), Description("This event fires before requesting data from client to server."), NotifyParentProperty(true)]
		public string BeforeAjaxRequest
		{
			get
			{
				return this.GetEvent("BeforeAjaxRequest");
			}
			set
			{
				this.SetEvent("BeforeAjaxRequest", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event fires when the user clicks on the row, but before actual row selection. "), NotifyParentProperty(true)]
		public string BeforeRowSelect
		{
			get
			{
				return this.GetEvent("BeforeRowSelect");
			}
			set
			{
				this.SetEvent("BeforeRowSelect", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event fires after the data is loaded into the grid and all other init processes are complete. "), NotifyParentProperty(true)]
		public string GridInitialized
		{
			get
			{
				return this.GetEvent("GridInitialized");
			}
			set
			{
				this.SetEvent("GridInitialized", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event is executed immediately after every server request. "), NotifyParentProperty(true)]
		public string LoadComplete
		{
			get
			{
				return this.GetEvent("LoadComplete");
			}
			set
			{
				this.SetEvent("LoadComplete", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event is called if the request to the server fails for any reason."), NotifyParentProperty(true)]
		public string LoadDataError
		{
			get
			{
				return this.GetEvent("LoadDataError");
			}
			set
			{
				this.SetEvent("LoadDataError", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("Fires when we click on particular cell in the grid. Note that this event fires only if inline cell editing is NOT enabled."), NotifyParentProperty(true)]
		public string CellSelect
		{
			get
			{
				return this.GetEvent("CellSelect");
			}
			set
			{
				this.SetEvent("CellSelect", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("Fires immediately after row was double clicked."), NotifyParentProperty(true)]
		public string RowDoubleClick
		{
			get
			{
				return this.GetEvent("RowDoubleClick");
			}
			set
			{
				this.SetEvent("RowDoubleClick", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event fires after click on [page button] and before populating the data. Also works when the user enters a new page number in the page input box (and presses [Enter]) and when the number of requested records is changed via the select box. "), NotifyParentProperty(true)]
		public string BeforePageChange
		{
			get
			{
				return this.GetEvent("BeforePageChange");
			}
			set
			{
				this.SetEvent("BeforePageChange", value);
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("Raised immediately after row was right clicked with the mouse. Can be used for showing context menus."), NotifyParentProperty(true)]
		public string RowRightClick
		{
			get
			{
				return this.GetEvent("RowRightClick");
			}
			set
			{
				this.SetEvent("RowRightClick", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("Raised immediately after row was clicked. "), NotifyParentProperty(true)]
		public string RowSelect
		{
			get
			{
				return this.GetEvent("RowSelect");
			}
			set
			{
				this.SetEvent("RowSelect", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("Raised immediately after sortable column was clicked and before sorting the data. "), NotifyParentProperty(true)]
		public string ColumnSort
		{
			get
			{
				return this.GetEvent("ColumnSort");
			}
			set
			{
				this.SetEvent("ColumnSort", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("The event is raised just before expanding the grid. When set, this event should return true or false. If it returns false the subgrid row is not expanded and the subgrid is not opened."), NotifyParentProperty(true)]
		public string SubGridBeforeRowExpand
		{
			get
			{
				return this.GetEvent("SubGridBeforeRowExpand");
			}
			set
			{
				this.SetEvent("SubGridBeforeRowExpand", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("Called upon expanding the grid hierarchy (click on the plus sign)."), NotifyParentProperty(true)]
		public string SubGridRowExpanded
		{
			get
			{
				return this.GetEvent("SubGridRowExpanded");
			}
			set
			{
				this.SetEvent("SubGridRowExpanded", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event is raised when the user clicks on the minus icon. The event should return true or false; when the returned value is false the row will not be collapsed."), NotifyParentProperty(true)]
		public string SubGridRowCollapsed
		{
			get
			{
				return this.GetEvent("SubGridRowCollapsed");
			}
			set
			{
				this.SetEvent("SubGridRowCollapsed", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event applies only to a cell that is editable; this event fires after the edited cell is edited - i.e. after the element is inserted into the DOM"), NotifyParentProperty(true)]
		public string AfterEditCell
		{
			get
			{
				return this.GetEvent("AfterEditCell");
			}
			set
			{
				this.SetEvent("AfterEditCell", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event applies only to a cell that is editable; this event fires after the cell has been successfully saved. This is the ideal place to change other content."), NotifyParentProperty(true)]
		public string AfterSaveCell
		{
			get
			{
				return this.GetEvent("AfterSaveCell");
			}
			set
			{
				this.SetEvent("AfterSaveCell", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event applies only to a cell that is editable; the event fires after the cell and other data is posted to the server."), NotifyParentProperty(true)]
		public string AfterSubmitCell
		{
			get
			{
				return this.GetEvent("AfterSubmitCell");
			}
			set
			{
				this.SetEvent("AfterSubmitCell", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event applies only to a cell that is editable; this event fires before the edited cell is edited."), NotifyParentProperty(true)]
		public string BeforeEditCell
		{
			get
			{
				return this.GetEvent("BeforeEditCell");
			}
			set
			{
				this.SetEvent("BeforeEditCell", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event applies only to a cell that is editable; this event fires before validation of values if any. This event can return the new value which value can replace the edited one."), NotifyParentProperty(true)]
		public string BeforeSaveCell
		{
			get
			{
				return this.GetEvent("BeforeSaveCell");
			}
			set
			{
				this.SetEvent("BeforeSaveCell", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event applies only to a cell that is editable; this event fires before submit the cell content to the serv"), NotifyParentProperty(true)]
		public string BeforeSubmitCell
		{
			get
			{
				return this.GetEvent("BeforeSubmitCell");
			}
			set
			{
				this.SetEvent("BeforeSubmitCell", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string EditError
		{
			get
			{
				return this.GetEvent("EditError");
			}
			set
			{
				this.SetEvent("EditError", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description("This event applies only to a cell that is editable; this event allows formatting the cell content before editing, and returns the formatted value."), NotifyParentProperty(true)]
		public string EditCellFormat
		{
			get
			{
				return this.GetEvent("EditCellFormat");
			}
			set
			{
				this.SetEvent("EditCellFormat", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string BeforeEditDialogShown
		{
			get
			{
				return this.GetEvent("BeforeEditDialogShown");
			}
			set
			{
				this.SetEvent("BeforeEditDialogShown", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string AfterEditDialogShown
		{
			get
			{
				return this.GetEvent("AfterEditDialogShown");
			}
			set
			{
				this.SetEvent("AfterEditDialogShown", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string AfterEditDialogRowInserted
		{
			get
			{
				return this.GetEvent("AfterEditDialogRowInserted");
			}
			set
			{
				this.SetEvent("AfterEditDialogRowInserted", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string BeforeAddDialogShown
		{
			get
			{
				return this.GetEvent("BeforeAddDialogShown");
			}
			set
			{
				this.SetEvent("BeforeAddDialogShown", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string AfterAddDialogShown
		{
			get
			{
				return this.GetEvent("AfterAddDialogShown");
			}
			set
			{
				this.SetEvent("AfterAddDialogShown", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string AfterAddDialogRowInserted
		{
			get
			{
				return this.GetEvent("AfterAddDialogRowInserted");
			}
			set
			{
				this.SetEvent("AfterAddDialogRowInserted", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string BeforeDeleteDialogShown
		{
			get
			{
				return this.GetEvent("BeforeDeleteDialogShown");
			}
			set
			{
				this.SetEvent("BeforeDeleteDialogShown", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string AfterDeleteDialogShown
		{
			get
			{
				return this.GetEvent("AfterDeleteDialogShown");
			}
			set
			{
				this.SetEvent("AfterDeleteDialogShown", value);
			}
		}
		[Category("Client-Side Events"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string AfterDeleteDialogRowDeleted
		{
			get
			{
				return this.GetEvent("AfterDeleteDialogRowDeleted");
			}
			set
			{
				this.SetEvent("AfterDeleteDialogRowDeleted", value);
			}
		}
		bool IStateManager.IsTrackingViewState
		{
			get
			{
				return this._isTracking;
			}
		}
		private StateBag ViewState
		{
			get
			{
				return this._viewState;
			}
		}
		private string GetEvent(string eventName)
		{
			object obj = this.ViewState[eventName];
			if (obj == null)
			{
				return "";
			}
			return (string)obj;
		}
		private void SetEvent(string eventName, string value)
		{
			this.ViewState[eventName] = value;
		}
		void IStateManager.LoadViewState(object state)
		{
			if (state != null)
			{
				((IStateManager)this.ViewState).LoadViewState(state);
			}
		}
		object IStateManager.SaveViewState()
		{
			return ((IStateManager)this.ViewState).SaveViewState();
		}
		void IStateManager.TrackViewState()
		{
			this._isTracking = true;
			((IStateManager)this.ViewState).TrackViewState();
		}
		public override string ToString()
		{
			return string.Empty;
		}
	}
}
