using System;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQListItemOption : BaseItem
	{
		[Category(""), DefaultValue(""), Description("")]
		public string Name
		{
			get
			{
				if (base.ViewState["Name"] != null)
				{
					return (string)base.ViewState["Name"];
				}
				return "";
			}
			set
			{
				base.ViewState["Name"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string Value
		{
			get
			{
				if (base.ViewState["Value"] != null)
				{
					return (string)base.ViewState["Value"];
				}
				return "";
			}
			set
			{
				base.ViewState["Value"] = value;
			}
		}
		public string ToJSON()
		{
			return new JavaScriptSerializer().Serialize(this.ToHashtable());
		}
		internal Hashtable ToHashtable()
		{
			Hashtable hashtable = new Hashtable();
			if (!string.IsNullOrEmpty(this.Name))
			{
				hashtable.Add("text", this.Value);
			}
			if (!string.IsNullOrEmpty(this.Value))
			{
				hashtable.Add("value", this.Value);
			}
			return hashtable;
		}
	}
}
