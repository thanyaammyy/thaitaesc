using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class AxisCategoryCollection : BaseItemCollection<JQChart, AxisCategory>
	{
		protected override object CreateKnownType(int index)
		{
			return new AxisCategory();
		}
		internal List<string> ToList()
		{
			List<string> list = new List<string>();
			foreach (AxisCategory axisCategory in this)
			{
				list.Add(axisCategory.Text);
			}
			return list;
		}
	}
}
