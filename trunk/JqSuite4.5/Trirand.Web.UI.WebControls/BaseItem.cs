using System;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class BaseItem : IStateManager, INamingContainer
	{
		private object _dataItem;
		private bool _isTrackingViewState;
		private StateBag _statebag = new StateBag();
		protected virtual bool IsTrackingViewState
		{
			get
			{
				return this._isTrackingViewState;
			}
		}
		protected StateBag ViewState
		{
			get
			{
				return this._statebag;
			}
		}
		bool IStateManager.IsTrackingViewState
		{
			get
			{
				return this.IsTrackingViewState;
			}
		}
		internal void SetDirty()
		{
			this.ViewState.SetDirty(true);
		}
		protected virtual void LoadViewState(object savedState)
		{
			object[] array = (object[])savedState;
			if (array.Length != 1)
			{
				throw new ArgumentException("Invalid View State");
			}
			((IStateManager)this.ViewState).LoadViewState(array[0]);
		}
		protected virtual object SaveViewState()
		{
			object[] array = new object[1];
			if (this.ViewState != null)
			{
				array[0] = ((IStateManager)this.ViewState).SaveViewState();
			}
			return array;
		}
		protected virtual void TrackViewState()
		{
			this._isTrackingViewState = true;
			if (this.ViewState != null)
			{
				((IStateManager)this.ViewState).TrackViewState();
			}
		}
		void IStateManager.LoadViewState(object state)
		{
			this.LoadViewState(state);
		}
		object IStateManager.SaveViewState()
		{
			return this.SaveViewState();
		}
		void IStateManager.TrackViewState()
		{
			this.TrackViewState();
		}
	}
}
