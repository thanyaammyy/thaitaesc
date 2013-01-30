using System;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridColumnSearchOptionCollection : BaseItemCollection<JQGridColumn, JQGridColumnSearchOption>
	{
		private static readonly Type[] _knownTypes;
		static JQGridColumnSearchOptionCollection()
		{
			JQGridColumnSearchOptionCollection._knownTypes = new Type[]
			{
				typeof(JQGridColumnSearchOption)
			};
		}
		protected override object CreateKnownType(int index)
		{
			if (index == 0)
			{
				return new JQGridColumnSearchOption();
			}
			throw new ArgumentOutOfRangeException("index");
		}
		protected override Type[] GetKnownTypes()
		{
			return JQGridColumnSearchOptionCollection._knownTypes;
		}
	}
}
