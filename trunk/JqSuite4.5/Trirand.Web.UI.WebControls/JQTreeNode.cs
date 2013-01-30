using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQTreeNode : BaseItem
	{
		private JQTreeNodeCollection _nodeCollection;
		[Category("Default"), DefaultValue(null), Description("DataControls_Columns"), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual JQTreeNodeCollection Nodes
		{
			get
			{
				if (this._nodeCollection == null)
				{
					this._nodeCollection = new JQTreeNodeCollection();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._nodeCollection).TrackViewState();
					}
				}
				return this._nodeCollection;
			}
		}
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
		[Category(""), DefaultValue(false), Description("")]
		public bool Expanded
		{
			get
			{
				return base.ViewState["Expanded"] != null && (bool)base.ViewState["Expanded"];
			}
			set
			{
				base.ViewState["Expanded"] = value;
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
		[Category(""), DefaultValue(false), Description("")]
		public bool Checked
		{
			get
			{
				return base.ViewState["Checked"] != null && (bool)base.ViewState["Checked"];
			}
			set
			{
				base.ViewState["Checked"] = value;
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
		public string ExpandedImageUrl
		{
			get
			{
				if (base.ViewState["ExpandedImageUrl"] != null)
				{
					return (string)base.ViewState["ExpandedImageUrl"];
				}
				return "";
			}
			set
			{
				base.ViewState["ExpandedImageUrl"] = value;
			}
		}
		[Category(""), DefaultValue(false), Description("")]
		public bool LoadOnDemand
		{
			get
			{
				return base.ViewState["LoadOnDemand"] != null && (bool)base.ViewState["LoadOnDemand"];
			}
			set
			{
				base.ViewState["LoadOnDemand"] = value;
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
			if (this.Expanded)
			{
				hashtable.Add("expanded", true);
			}
			if (!this.Enabled)
			{
				hashtable.Add("enabled", false);
			}
			if (this.Selected)
			{
				hashtable.Add("selected", true);
			}
			if (this.Checked)
			{
				hashtable.Add("checked", true);
			}
			if (this.LoadOnDemand)
			{
				hashtable.Add("loadOnDemand", true);
			}
			if (!string.IsNullOrEmpty(this.Url))
			{
				hashtable.Add("url", this.Url);
			}
			if (!string.IsNullOrEmpty(this.ImageUrl))
			{
				hashtable.Add("imageUrl", this.ImageUrl);
			}
			if (!string.IsNullOrEmpty(this.ExpandedImageUrl))
			{
				hashtable.Add("expandedImageUrl", this.ExpandedImageUrl);
			}
			List<Hashtable> list = new List<Hashtable>();
			foreach (JQTreeNode jQTreeNode in this.Nodes)
			{
				list.Add(jQTreeNode.ToHashtable());
			}
			if (list.Count > 0)
			{
				hashtable.Add("nodes", list);
			}
			return hashtable;
		}
	}
}
