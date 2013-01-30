using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class NumberFormatter : JQGridColumnFormatter, IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Behavior"), DefaultValue(""), Description("The separator for thousands, defaults to localization values."), NotifyParentProperty(true)]
		public string ThousandsSeparator
		{
			get
			{
				if (this.ViewState["ThousandsSeparator"] != null)
				{
					return (string)this.ViewState["ThousandsSeparator"];
				}
				return "";
			}
			set
			{
				this.ViewState["ThousandsSeparator"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(""), Description("The default value of the cell, if cell value is not specified."), NotifyParentProperty(true)]
		public string DefaultValue
		{
			get
			{
				if (this.ViewState["DefaultValue"] != null)
				{
					return (string)this.ViewState["DefaultValue"];
				}
				return "";
			}
			set
			{
				this.ViewState["DefaultValue"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(""), Description("The decimal separator. Defaults to localization settings."), NotifyParentProperty(true)]
		public string DecimalSeparator
		{
			get
			{
				if (this.ViewState["DecimalSeparator"] != null)
				{
					return (string)this.ViewState["DecimalSeparator"];
				}
				return "";
			}
			set
			{
				this.ViewState["DecimalSeparator"] = value;
			}
		}
		[Category("Behavior"), DefaultValue(-1), Description("The number of decimal places. Defaults to localization settings."), NotifyParentProperty(true)]
		public int DecimalPlaces
		{
			get
			{
				if (this.ViewState["DecimalPlaces"] != null)
				{
					return (int)this.ViewState["DecimalPlaces"];
				}
				return -1;
			}
			set
			{
				this.ViewState["DecimalPlaces"] = value;
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
