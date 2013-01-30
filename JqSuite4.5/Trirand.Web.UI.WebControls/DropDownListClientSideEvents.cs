using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class DropDownListClientSideEvents : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category(""), DefaultValue(""), Description("")]
		public string Show
		{
			get
			{
				if (this.ViewState["Show"] != null)
				{
					return (string)this.ViewState["Show"];
				}
				return "";
			}
			set
			{
				this.ViewState["Show"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string Hide
		{
			get
			{
				if (this.ViewState["Hide"] != null)
				{
					return (string)this.ViewState["Hide"];
				}
				return "";
			}
			set
			{
				this.ViewState["Hide"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string Select
		{
			get
			{
				if (this.ViewState["Select"] != null)
				{
					return (string)this.ViewState["Select"];
				}
				return "";
			}
			set
			{
				this.ViewState["Select"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string MouseOver
		{
			get
			{
				if (this.ViewState["MouseOver"] != null)
				{
					return (string)this.ViewState["MouseOver"];
				}
				return "";
			}
			set
			{
				this.ViewState["MouseOver"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string MouseOut
		{
			get
			{
				if (this.ViewState["MouseOut"] != null)
				{
					return (string)this.ViewState["MouseOut"];
				}
				return "";
			}
			set
			{
				this.ViewState["MouseOut"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string Initialized
		{
			get
			{
				if (this.ViewState["Initialized"] != null)
				{
					return (string)this.ViewState["Initialized"];
				}
				return "";
			}
			set
			{
				this.ViewState["Initialized"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string KeyDown
		{
			get
			{
				if (this.ViewState["KeyDown"] != null)
				{
					return (string)this.ViewState["KeyDown"];
				}
				return "";
			}
			set
			{
				this.ViewState["KeyDown"] = value;
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
