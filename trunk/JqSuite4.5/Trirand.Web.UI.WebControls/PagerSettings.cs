using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class PagerSettings : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Appearance"), DefaultValue(10), Description("The page size (number of rows per page). Default is 10."), NotifyParentProperty(true)]
		public int PageSize
		{
			get
			{
				object obj = this.ViewState["PageSize"];
				if (obj == null)
				{
					return 10;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["PageSize"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(1), Description("Current starting page. Default is 1."), NotifyParentProperty(true)]
		public int CurrentPage
		{
			get
			{
				object obj = this.ViewState["CurrentPage"];
				if (obj == null)
				{
					return 1;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["CurrentPage"] = value;
			}
		}
		[Category("Appearance"), DefaultValue("[10,20,30]"), Description("The page-size options in the dropdown. Should be string in square brackers, comma separated. Default is [10,20,30]."), NotifyParentProperty(true)]
		public string PageSizeOptions
		{
			get
			{
				object obj = this.ViewState["PageSizeOptions"];
				if (obj == null)
				{
					return "[10,20,30]";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["PageSizeOptions"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The message that will be shown when there are no rows in the grid."), NotifyParentProperty(true)]
		public string NoRowsMessage
		{
			get
			{
				object obj = this.ViewState["NoRowsMessage"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["NoRowsMessage"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Enables a special paging mode - paging with scrollbar (virtual scrolling). Default is false;"), NotifyParentProperty(true)]
		public bool ScrollBarPaging
		{
			get
			{
				object obj = this.ViewState["ScrollBarPaging"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ScrollBarPaging"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The message that is shown while the grid is paging."), NotifyParentProperty(true)]
		public string PagingMessage
		{
			get
			{
				object obj = this.ViewState["PagingMessage"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["PagingMessage"] = value;
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
