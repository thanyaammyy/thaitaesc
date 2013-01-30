using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class LinkFormatter : JQGridColumnFormatter
	{
		[DefaultValue(""), Description("If specified, set target for the link (e.g. '_blank', name of frame/iframe, etc")]
		public string Target
		{
			get;
			set;
		}
	}
}
