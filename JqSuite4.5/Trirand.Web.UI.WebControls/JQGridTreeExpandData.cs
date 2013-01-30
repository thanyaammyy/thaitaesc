using System;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridTreeExpandData
	{
		public int ParentLevel
		{
			get;
			set;
		}
		public string ParentID
		{
			get;
			set;
		}
		public JQGridTreeExpandData()
		{
			this.ParentLevel = -1;
			this.ParentID = null;
		}
	}
}
