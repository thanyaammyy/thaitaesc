using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class CheckBoxFormatter : JQGridColumnFormatter, IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Behavior"), DefaultValue(false), Description("Determines if the checkbox should be enabled. Default is false (read-only mode)."), NotifyParentProperty(true)]
		public bool Enabled
		{
			get
			{
				return this.ViewState["Enabled"] != null && (bool)this.ViewState["Enabled"];
			}
			set
			{
				this.ViewState["Enabled"] = value;
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
	}
}
