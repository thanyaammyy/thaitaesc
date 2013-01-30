using System;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class HierarchySettings : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Appearance"), DefaultValue(HierarchyMode.None), Description("Determines the position of the grid in the Hierarchy. Possible values are Parent, ParentAndChild and Child."), NotifyParentProperty(true)]
		public HierarchyMode HierarchyMode
		{
			get
			{
				object obj = this.ViewState["HierarchyMode"];
				if (obj == null)
				{
					return HierarchyMode.None;
				}
				return (HierarchyMode)obj;
			}
			set
			{
				this.ViewState["HierarchyMode"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The CSS class applied to the plus icon"), NotifyParentProperty(true)]
		public string PlusIcon
		{
			get
			{
				object obj = this.ViewState["PlusIcon"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["PlusIcon"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The CSS class applied to the minus icon"), NotifyParentProperty(true)]
		public string MinusIcon
		{
			get
			{
				object obj = this.ViewState["MinusIcon"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["MinusIcon"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The CSS class applied to the open icon"), NotifyParentProperty(true)]
		public string OpenIcon
		{
			get
			{
				object obj = this.ViewState["OpenIcon"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["OpenIcon"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("When set to true make it so that all rows will be expanded automatically when a new set of data is loaded."), NotifyParentProperty(true)]
		public bool ExpandOnLoad
		{
			get
			{
				object obj = this.ViewState["ExpandOnLoad"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ExpandOnLoad"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Selects the row on expanding."), NotifyParentProperty(true)]
		public bool SelectOnExpand
		{
			get
			{
				object obj = this.ViewState["SelectOnExpand"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["SelectOnExpand"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(true), Description("If the grid should be reloaded on expand."), NotifyParentProperty(true)]
		public bool ReloadOnExpand
		{
			get
			{
				object obj = this.ViewState["ReloadOnExpand"];
				return obj == null || (bool)obj;
			}
			set
			{
				this.ViewState["ReloadOnExpand"] = value;
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
		internal Hashtable GetSubGridOptions()
		{
			Hashtable hashtable = new Hashtable();
			if (!string.IsNullOrEmpty(this.PlusIcon))
			{
				hashtable["plusicon"] = this.PlusIcon;
			}
			if (!string.IsNullOrEmpty(this.MinusIcon))
			{
				hashtable["minusicon"] = this.MinusIcon;
			}
			if (!string.IsNullOrEmpty(this.OpenIcon))
			{
				hashtable["openicon"] = this.OpenIcon;
			}
			if (this.ExpandOnLoad)
			{
				hashtable["expandOnLoad"] = true;
			}
			if (this.SelectOnExpand)
			{
				hashtable["selectOnExpand"] = true;
			}
			if (!this.ReloadOnExpand)
			{
				hashtable["reloadOnExpand"] = false;
			}
			return hashtable;
		}
		internal string GetSubGridOptionsJSON()
		{
			return new JavaScriptSerializer().Serialize(this.GetSubGridOptions());
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
