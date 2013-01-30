using System;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridEditFieldAttributeCollection : BaseItemCollection<JQGridColumn, JQGridEditFieldAttribute>
	{
		private static readonly Type[] _knownTypes;
		static JQGridEditFieldAttributeCollection()
		{
			JQGridEditFieldAttributeCollection._knownTypes = new Type[]
			{
				typeof(JQGridEditFieldAttribute)
			};
		}
		protected override object CreateKnownType(int index)
		{
			if (index == 0)
			{
				return new JQGridEditFieldAttribute();
			}
			throw new ArgumentOutOfRangeException("index");
		}
		protected override Type[] GetKnownTypes()
		{
			return JQGridEditFieldAttributeCollection._knownTypes;
		}
	}
}
