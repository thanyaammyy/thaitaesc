using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class ExportSettings : IStateManager
	{
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Settings"), DefaultValue(","), Description("The separator used for CSV export. Defaults to comma."), NotifyParentProperty(true)]
		public string CSVSeparator
		{
			get
			{
				if (this.ViewState["CSVSeparator"] != null)
				{
					return (string)this.ViewState["CSVSeparator"];
				}
				return ",";
			}
			set
			{
				this.ViewState["CSVSeparator"] = value;
			}
		}
		[Category("Settings"), DefaultValue(true), Description("Gets or sets a boolean controlling if the headers of the grid should be exported or not. Defaults to true."), NotifyParentProperty(true)]
		public bool ExportHeaders
		{
			get
			{
				object obj = this.ViewState["ExportHeaders"];
				return obj == null || (bool)obj;
			}
			set
			{
				this.ViewState["ExportHeaders"] = value;
			}
		}
		[Category("Settings"), DefaultValue(ExportDataRange.All), Description("Gets or sets a boolean controlling if the headers of the grid should be exported or not. Defaults to true."), NotifyParentProperty(true)]
		public ExportDataRange ExportDataRange
		{
			get
			{
				if (this.ViewState["ExportDataRange"] == null)
				{
					return ExportDataRange.All;
				}
				return (ExportDataRange)this.ViewState["ExportDataRange"];
			}
			set
			{
				this.ViewState["ExportDataRange"] = value;
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
