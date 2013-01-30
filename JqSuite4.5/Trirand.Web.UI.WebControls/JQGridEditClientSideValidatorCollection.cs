using System;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridEditClientSideValidatorCollection : BaseItemCollection<JQGridColumn, JQGridEditClientSideValidator>
	{
		private static readonly Type[] _knownTypes;
		static JQGridEditClientSideValidatorCollection()
		{
			JQGridEditClientSideValidatorCollection._knownTypes = new Type[]
			{
				typeof(DateValidator),
				typeof(EmailValidator),
				typeof(IntegerValidator),
				typeof(MaxValueValidator),
				typeof(MinValueValidator),
				typeof(NumberValidator),
				typeof(RequiredValidator),
				typeof(TimeValidator),
				typeof(UrlValidator),
				typeof(CustomValidator)
			};
		}
		protected override object CreateKnownType(int index)
		{
			switch (index)
			{
			case 0:
				return new DateValidator();
			case 1:
				return new EmailValidator();
			case 2:
				return new IntegerValidator();
			case 3:
				return new MaxValueValidator();
			case 4:
				return new MinValueValidator();
			case 5:
				return new NumberValidator();
			case 6:
				return new RequiredValidator();
			case 7:
				return new TimeValidator();
			case 8:
				return new UrlValidator();
			case 9:
				return new CustomValidator();
			default:
				throw new ArgumentOutOfRangeException("index");
			}
		}
		protected override Type[] GetKnownTypes()
		{
			return JQGridEditClientSideValidatorCollection._knownTypes;
		}
	}
}
