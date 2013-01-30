using System;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridColumnFormatterCollection : BaseItemCollection<JQGridColumn, JQGridColumnFormatter>
	{
		private static readonly Type[] _knownTypes;
		static JQGridColumnFormatterCollection()
		{
			JQGridColumnFormatterCollection._knownTypes = new Type[]
			{
				typeof(IntegerFormatter),
				typeof(LinkFormatter),
				typeof(EmailFormatter),
				typeof(CheckBoxFormatter),
				typeof(CurrencyFormatter),
				typeof(NumberFormatter),
				typeof(CustomFormatter)
			};
		}
		protected override object CreateKnownType(int index)
		{
			switch (index)
			{
			case 0:
				return new IntegerFormatter();
			case 1:
				return new LinkFormatter();
			case 2:
				return new EmailFormatter();
			case 3:
				return new CheckBoxFormatter();
			case 4:
				return new CurrencyFormatter();
			case 5:
				return new NumberFormatter();
			case 6:
				return new CustomFormatter();
			default:
				throw new ArgumentOutOfRangeException("index");
			}
		}
		protected override Type[] GetKnownTypes()
		{
			return JQGridColumnFormatterCollection._knownTypes;
		}
	}
}
