using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridRowSelectEventArgs : CancelEventArgs
	{
		private string _rowKey;
		public string RowKey
		{
			get
			{
				return this._rowKey;
			}
			set
			{
				this._rowKey = value;
			}
		}
	}
}
