using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class TreeGridSettings : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Settings"), DefaultValue(false), Description("Gets or sets the visibility of the edit button (pencil) in the grid toolbar."), NotifyParentProperty(true)]
		public bool Enabled
		{
			get
			{
				object obj = this.ViewState["Enabled"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["Enabled"] = value;
			}
		}
		[Category("Settings"), DefaultValue(""), Description("Sets the expanded icon CSS style. Must use CSS class names from jQuery UI."), NotifyParentProperty(true)]
		public string CollapsedIcon
		{
			get
			{
				object obj = this.ViewState["CollapsedIcon"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["CollapsedIcon"] = value;
			}
		}
		[Category("Settings"), DefaultValue(""), Description("Sets the expanded icon CSS style. Must use CSS class names from jQuery UI."), NotifyParentProperty(true)]
		public string ExpandedIcon
		{
			get
			{
				object obj = this.ViewState["ExpandedIcon"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["ExpandedIcon"] = value;
			}
		}
		[Category("Settings"), DefaultValue(""), Description("Sets the leaf icon CSS style. Must use CSS class names from jQuery UI."), NotifyParentProperty(true)]
		public string LeafIcon
		{
			get
			{
				object obj = this.ViewState["LeafIcon"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["LeafIcon"] = value;
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
