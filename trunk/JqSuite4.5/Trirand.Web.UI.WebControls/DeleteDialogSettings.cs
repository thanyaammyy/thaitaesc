using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class DeleteDialogSettings : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Appearance"), DefaultValue(0), Description("The top (y) offset of the dialog window, relative to the grid upper left corner. Accepts negative values. "), NotifyParentProperty(true)]
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
		[Category("Appearance"), DefaultValue(0), Description("The left (x) offset of the dialog window, relative to the grid upper left corner. Accepts negative values. "), NotifyParentProperty(true)]
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
		[Category("Appearance"), DefaultValue(300), Description("The width of the edit dialog. Default is 300. Accepts only integer numbers."), NotifyParentProperty(true)]
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
		[Category("Appearance"), DefaultValue(300), Description("The height of the edit dialog. Default is 300. Accepts only integer numbers."), NotifyParentProperty(true)]
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
		[Category("Appearance"), DefaultValue(false), Description("Determines if the dialog should be modal or not. Default is false."), NotifyParentProperty(true)]
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
		[Category("Appearance"), DefaultValue(true), Description("Determines if the dialog window should be draggable. Default is true."), NotifyParentProperty(true)]
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
		[Category("Appearance"), DefaultValue(true), Description("Determines if the dialog window should be resizable. Default is true."), NotifyParentProperty(true)]
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
		[Category("Appearance"), DefaultValue(""), Description("The text label of the 'Submit' button in delete dialog. Defaults to current localization settings, setting it will override localization default."), NotifyParentProperty(true)]
		public string SubmitText
		{
			get
			{
				object obj = this.ViewState["SubmitText"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["SubmitText"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The text label of the 'Cancel' button in edit dialog. Defaults to current localization settings, setting it will override localization default."), NotifyParentProperty(true)]
		public string CancelText
		{
			get
			{
				object obj = this.ViewState["CancelText"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["CancelText"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The text message the will be displayed while server on deleting. Defaults to current localization settings, setting it will override localization default."), NotifyParentProperty(true)]
		public string LoadingMessageText
		{
			get
			{
				object obj = this.ViewState["LoadingMessageText"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["LoadingMessageText"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The message that will be displayed as a confirmation question in the delete dialog."), NotifyParentProperty(true)]
		public string DeleteMessage
		{
			get
			{
				object obj = this.ViewState["DeleteMessage"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["DeleteMessage"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("The caption of the dialog. Defaults to localization settings."), NotifyParentProperty(true)]
		public string Caption
		{
			get
			{
				object obj = this.ViewState["DeleteCaption"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				this.ViewState["DeleteCaption"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(true), Description("Specifies if the grid should be reloaded after deleting. Default is true."), NotifyParentProperty(true)]
		public bool ReloadAfterSubmit
		{
			get
			{
				object obj = this.ViewState["ReloadAfterSubmit"];
				return obj == null || (bool)obj;
			}
			set
			{
				this.ViewState["ReloadAfterSubmit"] = value;
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
