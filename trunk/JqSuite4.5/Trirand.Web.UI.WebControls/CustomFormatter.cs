using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class CustomFormatter : JQGridColumnFormatter, IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Behavior"), DefaultValue(""), Description("The javascript function that will format the value. The first parameter is the cell value."), NotifyParentProperty(true)]
		public string FormatFunction
		{
			get
			{
				if (this.ViewState["FormatFunction"] != null)
				{
					return (string)this.ViewState["FormatFunction"];
				}
				return "";
			}
			set
			{
				this.ViewState["FormatFunction"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(""), Description("The javascript function that will unformat the value upon editing. The first parameter is the formatted value."), NotifyParentProperty(true)]
		public string UnFormatFunction
		{
			get
			{
				if (this.ViewState["UnFormatFunction"] != null)
				{
					return (string)this.ViewState["UnFormatFunction"];
				}
				return "";
			}
			set
			{
				this.ViewState["UnFormatFunction"] = value;
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
