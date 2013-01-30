using System;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQListItem : BaseItem
	{
		private JQListItemOptionCollection _options;
		[Category(""), DefaultValue(""), Description("")]
		public string Text
		{
			get
			{
				if (base.ViewState["Text"] != null)
				{
					return (string)base.ViewState["Text"];
				}
				return "";
			}
			set
			{
				base.ViewState["Text"] = value;
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
		[Category(""), DefaultValue(true), Description("")]
		public bool Enabled
		{
			get
			{
				return base.ViewState["Enabled"] == null || (bool)base.ViewState["Enabled"];
			}
			set
			{
				base.ViewState["Enabled"] = value;
			}
		}
		[Category(""), DefaultValue(false), Description("")]
		public bool Selected
		{
			get
			{
				return base.ViewState["Selected"] != null && (bool)base.ViewState["Selected"];
			}
			set
			{
				base.ViewState["Selected"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string Url
		{
			get
			{
				if (base.ViewState["Url"] != null)
				{
					return (string)base.ViewState["Url"];
				}
				return "";
			}
			set
			{
				base.ViewState["Url"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string ImageUrl
		{
			get
			{
				if (base.ViewState["ImageUrl"] != null)
				{
					return (string)base.ViewState["ImageUrl"];
				}
				return "";
			}
			set
			{
				base.ViewState["ImageUrl"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string ItemTemplateID
		{
			get
			{
				if (base.ViewState["ItemTemplateID"] != null)
				{
					return (string)base.ViewState["ItemTemplateID"];
				}
				return "";
			}
			set
			{
				base.ViewState["ItemTemplateID"] = value;
			}
		}
		[Category("Options"), DefaultValue(null), Description("The custom attributes (options) for each item. Available on the client-side."), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public JQListItemOptionCollection Options
		{
			get
			{
				if (this._options == null)
				{
					this._options = new JQListItemOptionCollection();
				}
				return this._options;
			}
		}
		public string ToJSON()
		{
			return new JavaScriptSerializer().Serialize(this.ToHashtable());
		}
		internal Hashtable ToHashtable()
		{
			Hashtable hashtable = new Hashtable();
			if (!string.IsNullOrEmpty(this.Text))
			{
				hashtable.Add("text", this.Text);
			}
			if (!string.IsNullOrEmpty(this.Value))
			{
				hashtable.Add("value", this.Value);
			}
			if (!this.Enabled)
			{
				hashtable.Add("enabled", false);
			}
			if (this.Selected)
			{
				hashtable.Add("selected", true);
			}
			if (!string.IsNullOrEmpty(this.Url))
			{
				hashtable.Add("url", this.Url);
			}
			if (!string.IsNullOrEmpty(this.ImageUrl))
			{
				hashtable.Add("imageUrl", this.ImageUrl);
			}
			if (!string.IsNullOrEmpty(this.ItemTemplateID))
			{
				hashtable.Add("itemTemplateID", this.ItemTemplateID);
			}
			foreach (JQListItemOption jQListItemOption in this.Options)
			{
				hashtable.Add(jQListItemOption.Name, jQListItemOption.Value);
			}
			return hashtable;
		}
	}
}
