using System;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class GroupField : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		public string DataField
		{
			get;
			set;
		}
		public string HeaderText
		{
			get;
			set;
		}
		public bool ShowGroupColumn
		{
			get;
			set;
		}
		public SortDirection GroupSortDirection
		{
			get;
			set;
		}
		public bool ShowGroupSummary
		{
			get;
			set;
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
		public GroupField()
		{
			this.DataField = "";
			this.HeaderText = "<b>{0}</b>";
			this.ShowGroupColumn = true;
			this.GroupSortDirection = SortDirection.Asc;
			this.ShowGroupSummary = false;
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
	}
}
