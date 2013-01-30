using System;
using System.Data;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridDataRequestedEventArgs : EventArgs
	{
		public DataTable _dt;
		public DataTable DataTable
		{
			get
			{
				return this._dt;
			}
			set
			{
				this._dt = value;
			}
		}
		public JQGridDataRequestedEventArgs(DataTable dt)
		{
			this._dt = dt;
		}
	}
}
