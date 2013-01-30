using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class ToolBarSettings : IStateManager
	{
		private JQGridToolBarButtonCollection _customButtonsCollection;
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Custom Buttons"), DefaultValue(null), Description("DataControls_Columns"), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public JQGridToolBarButtonCollection CustomButtons
		{
			get
			{
				if (this._customButtonsCollection == null)
				{
					this._customButtonsCollection = new JQGridToolBarButtonCollection();
					if (((IStateManager)this).IsTrackingViewState)
					{
						((IStateManager)this._customButtonsCollection).TrackViewState();
					}
				}
				return this._customButtonsCollection;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the edit button (pencil) in the grid toolbar for dialog editing."), NotifyParentProperty(true)]
		public bool ShowEditButton
		{
			get
			{
				object obj = this.ViewState["ShowEditButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowEditButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the edit button (pencil) in the grid toolbar for inline editing."), NotifyParentProperty(true)]
		public bool ShowInlineEditButton
		{
			get
			{
				object obj = this.ViewState["ShowInlineEditButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowInlineEditButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the edit button (plus) in the grid toolbar for dialog editing."), NotifyParentProperty(true)]
		public bool ShowAddButton
		{
			get
			{
				object obj = this.ViewState["ShowAddButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowAddButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the edit button (plus) in the grid toolbar for inline editing."), NotifyParentProperty(true)]
		public bool ShowInlineAddButton
		{
			get
			{
				object obj = this.ViewState["ShowInlineAddButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowInlineAddButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the delete button (recycle bin) in the grid toolbar for dialog editing."), NotifyParentProperty(true)]
		public bool ShowDeleteButton
		{
			get
			{
				object obj = this.ViewState["ShowDeleteButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowDeleteButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the delete button (recycle bin) in the grid toolbar for inline editing."), NotifyParentProperty(true)]
		public bool ShowInlineDeleteButton
		{
			get
			{
				object obj = this.ViewState["ShowInlineDeleteButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowInlineDeleteButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the cancel button in the grid toolbar for inline editing."), NotifyParentProperty(true)]
		public bool ShowInlineCancelButton
		{
			get
			{
				object obj = this.ViewState["ShowInlineCancelButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowInlineCancelButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the search button (magnifying glass) in the grid toolbar."), NotifyParentProperty(true)]
		public bool ShowSearchButton
		{
			get
			{
				object obj = this.ViewState["ShowSearchButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowSearchButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the search button (circle) in the grid toolbar."), NotifyParentProperty(true)]
		public bool ShowRefreshButton
		{
			get
			{
				object obj = this.ViewState["ShowRefreshButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowRefreshButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Gets or sets the visibility of the view row details button in the grid toolbar."), NotifyParentProperty(true)]
		public bool ShowViewRowDetailsButton
		{
			get
			{
				object obj = this.ViewState["ShowViewRowDetailsButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowViewRowDetailsButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Determines if the grid search/filter toolbar should be shown on top of the grid."), NotifyParentProperty(true)]
		public bool ShowSearchToolBar
		{
			get
			{
				object obj = this.ViewState["ShowSearchToolBar"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowSearchToolBar"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(ToolBarAlign.Left), Description("Alignment of the toolbar - left, center, right."), NotifyParentProperty(true)]
		public ToolBarAlign ToolBarAlign
		{
			get
			{
				if (this.ViewState["ToolBarAlign"] != null)
				{
					return (ToolBarAlign)this.ViewState["ToolBarAlign"];
				}
				return ToolBarAlign.Left;
			}
			set
			{
				this.ViewState["ToolBarAlign"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(ToolBarPosition.Bottom), Description("Top, Bottom, TopAndBottom"), NotifyParentProperty(true)]
		public ToolBarPosition ToolBarPosition
		{
			get
			{
				if (this.ViewState["ToolBarPosition"] != null)
				{
					return (ToolBarPosition)this.ViewState["ToolBarPosition"];
				}
				return ToolBarPosition.Bottom;
			}
			set
			{
				this.ViewState["ToolBarPosition"] = value;
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
