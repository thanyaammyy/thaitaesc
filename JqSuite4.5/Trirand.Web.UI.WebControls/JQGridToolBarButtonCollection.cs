using System;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridToolBarButtonCollection : BaseItemCollection<ToolBarSettings, JQGridToolBarButton>
	{
		protected override object CreateKnownType(int index)
		{
			return new JQGridToolBarButton();
		}
	}
}
