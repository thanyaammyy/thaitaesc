using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class SortSettings : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Behavior"), DefaultValue(""), Description("The column (datafield) to be used as a default sorting column on initial page load."), NotifyParentProperty(true)]
		public string InitialSortColumn
		{
			get
			{
				if (this.ViewState["InitialSortColumn"] != null)
				{
					return (string)this.ViewState["InitialSortColumn"];
				}
				return "";
			}
			set
			{
				this.ViewState["InitialSortColumn"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(SortDirection.Asc), Description("The sort direction to be used on initial page load. Worksonly if InitialSortColumn is set. Asc (ascending) by default."), NotifyParentProperty(true)]
		public SortDirection InitialSortDirection
		{
			get
			{
				if (this.ViewState["InitialSortDirection"] != null)
				{
					return (SortDirection)this.ViewState["InitialSortDirection"];
				}
				return SortDirection.Asc;
			}
			set
			{
				this.ViewState["InitialSortDirection"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(SortIconsPosition.Vertical), Description("The visual appearance of sorting icons in the column header. Default is Vertical."), NotifyParentProperty(true)]
		public SortIconsPosition SortIconsPosition
		{
			get
			{
				object obj = this.ViewState["SortIconsPosition"];
				if (obj == null)
				{
					return SortIconsPosition.Vertical;
				}
				return (SortIconsPosition)obj;
			}
			set
			{
				this.ViewState["SortIconsPosition"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(SortAction.ClickOnHeader), Description("Determines when the sorting action takes place. Default is ClickOnHeader"), NotifyParentProperty(true)]
		public SortAction SortAction
		{
			get
			{
				object obj = this.ViewState["SortAction"];
				if (obj == null)
				{
					return SortAction.ClickOnHeader;
				}
				return (SortAction)obj;
			}
			set
			{
				this.ViewState["SortAction"] = value;
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
