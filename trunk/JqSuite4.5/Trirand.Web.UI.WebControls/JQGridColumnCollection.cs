using System;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridColumnCollection : BaseItemCollection<JQGrid, JQGridColumn>
	{
		protected override object CreateKnownType(int index)
		{
			return new JQGridColumn();
		}
		public JQGridColumn FromDataField(string dataField)
		{
			for (int i = 0; i < base.Count; i++)
			{
				JQGridColumn jQGridColumn = base[i];
				if (jQGridColumn.DataField == dataField)
				{
					return jQGridColumn;
				}
			}
			return null;
		}
	}
}
