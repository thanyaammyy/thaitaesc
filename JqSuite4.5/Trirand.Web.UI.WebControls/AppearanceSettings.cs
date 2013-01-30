using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class AppearanceSettings : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Appearance"), DefaultValue(false), Description("Show row numbers (index) in the leftmost column of the grid"), NotifyParentProperty(true)]
		public bool ShowRowNumbers
		{
			get
			{
				object obj = this.ViewState["ShowRowNumbers"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowRowNumbers"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(25), Description("Set the width of the row numbers column (ShowRowNumbers must be true). Default is 25."), NotifyParentProperty(true)]
		public int RowNumbersColumnWidth
		{
			get
			{
				object obj = this.ViewState["RowNumbersColumnWidth"];
				if (obj == null)
				{
					return 25;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["RowNumbersColumnWidth"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Controls if the background should have alternate background for odd/even rows."), NotifyParentProperty(true)]
		public bool AlternateRowBackground
		{
			get
			{
				object obj = this.ViewState["AlternateRowBackground"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["AlternateRowBackground"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Controls if the background color of a row will change when end-users hover the mouse over it."), NotifyParentProperty(true)]
		public bool HighlightRowsOnHover
		{
			get
			{
				object obj = this.ViewState["HighlightRowsOnHover"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["HighlightRowsOnHover"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The caption of the grid. Appears on top and can collapse expand the grid by clicking on it."), NotifyParentProperty(true)]
		public string Caption
		{
			get
			{
				object obj = this.ViewState["Caption"];
				if (obj == null)
				{
					return string.Empty;
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["Caption"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Shows an expand/collapse button in the caption of the grid which toggles grid visibility."), NotifyParentProperty(true)]
		public bool ShowCaptionGridToggleButton
		{
			get
			{
				object obj = this.ViewState["ShowCaptionGridToggleButton"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowCaptionGridToggleButton"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(18), Description("The caption of the grid. Appears on top and can collapse expand the grid by clicking on it."), NotifyParentProperty(true)]
		public int ScrollBarOffset
		{
			get
			{
				object obj = this.ViewState["ScrollBarOffset"];
				if (obj == null)
				{
					return 18;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["ScrollBarOffset"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Sets the grid in RightToLeft (RTL) mode."), NotifyParentProperty(true)]
		public bool RightToLeft
		{
			get
			{
				object obj = this.ViewState["RightToLeft"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["RightToLeft"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Displayes a static footer for each grid column. You can store custom information there, like formulas, sum, count, etc."), NotifyParentProperty(true)]
		public bool ShowFooter
		{
			get
			{
				object obj = this.ViewState["ShowFooter"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ShowFooter"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(true), Description(""), NotifyParentProperty(true)]
		public bool ShrinkToFit
		{
			get
			{
				object obj = this.ViewState["ShrinkToFit"];
				return obj == null || (bool)obj;
			}
			set
			{
				this.ViewState["ShrinkToFit"] = value;
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
