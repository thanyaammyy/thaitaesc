using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridEditFieldAttribute : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Behavior"), DefaultValue(""), Description("The name of the HTML attribute"), NotifyParentProperty(true)]
		public string Name
		{
			get
			{
				if (this.ViewState["Name"] != null)
				{
					return (string)this.ViewState["Name"];
				}
				return "";
			}
			set
			{
				this.ViewState["Name"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(""), Description(""), NotifyParentProperty(true)]
		public string Value
		{
			get
			{
				if (this.ViewState["Value"] != null)
				{
					return (string)this.ViewState["Value"];
				}
				return "";
			}
			set
			{
				this.ViewState["Value"] = value;
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
