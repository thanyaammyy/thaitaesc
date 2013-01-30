using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class SearchDialogSettings : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Appearance"), DefaultValue(0), Description("The top (Y) offset of the dialog window, relative to the grid upper left corner. Accepts negative values."), NotifyParentProperty(true)]
		public int TopOffset
		{
			get
			{
				object obj = this.ViewState["TopOffset"];
				if (obj == null)
				{
					return 0;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["TopOffset"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(0), Description("The left (X) offset of the dialog window, relative to the grid upper left corner. Accepts negative values. "), NotifyParentProperty(true)]
		public int LeftOffset
		{
			get
			{
				object obj = this.ViewState["LeftOffset"];
				if (obj == null)
				{
					return 0;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["LeftOffset"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(300), Description("The width of the search dialog. Default is 300. Accepts only integer numbers."), NotifyParentProperty(true)]
		public int Width
		{
			get
			{
				object obj = this.ViewState["Width"];
				if (obj == null)
				{
					return 300;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["Width"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(300), Description("The height of the search dialog. Default is 300. Accepts only integer numbers."), NotifyParentProperty(true)]
		public int Height
		{
			get
			{
				object obj = this.ViewState["Height"];
				if (obj == null)
				{
					return 300;
				}
				return (int)obj;
			}
			set
			{
				this.ViewState["Height"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Determines if the search dialog should be modal or not. Default is false."), NotifyParentProperty(true)]
		public bool Modal
		{
			get
			{
				object obj = this.ViewState["Modal"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["Modal"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(true), Description("Determines if the search dialog window should be draggable. Default is true."), NotifyParentProperty(true)]
		public bool Draggable
		{
			get
			{
				object obj = this.ViewState["Draggable"];
				return obj == null || (bool)obj;
			}
			set
			{
				this.ViewState["Draggable"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The text label of the 'Find' button in search dialog. Defaults to current localization settings, setting it will override localization default."), NotifyParentProperty(true)]
		public string FindButtonText
		{
			get
			{
				object obj = this.ViewState["FindButtonText"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["FindButtonText"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The text label of the 'Reset' button in search dialog. Defaults to current localization settings, setting it will override localization default."), NotifyParentProperty(true)]
		public string ResetButtonText
		{
			get
			{
				object obj = this.ViewState["ResetButtonText"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["ResetButtonText"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Sets multiple search mode on. Multiple search adds the ability to search based on multiple criteria."), NotifyParentProperty(true)]
		public bool MultipleSearch
		{
			get
			{
				object obj = this.ViewState["MultipleSearch"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["MultipleSearch"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(false), Description("Determines if validation should be applied to search fields prior to submitting to server."), NotifyParentProperty(true)]
		public bool ValidateInput
		{
			get
			{
				object obj = this.ViewState["ValidateInput"];
				return obj != null && (bool)obj;
			}
			set
			{
				this.ViewState["ValidateInput"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(true), Description("Gets or sets a boolean property controlling if the search dialog window is resizable."), NotifyParentProperty(true)]
		public bool Resizable
		{
			get
			{
				object obj = this.ViewState["Resizable"];
				return obj == null || (bool)obj;
			}
			set
			{
				this.ViewState["Resizable"] = value;
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
