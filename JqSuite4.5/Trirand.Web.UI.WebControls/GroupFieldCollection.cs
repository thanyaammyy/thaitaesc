using System;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class GroupFieldCollection : BaseItemCollection<JQGrid, GroupField>
	{
		protected override object CreateKnownType(int index)
		{
			return new GroupField();
		}
	}
}
