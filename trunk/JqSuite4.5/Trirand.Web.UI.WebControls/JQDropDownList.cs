using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Trirand.Web.UI.WebControls
{
	[ToolboxData("<{0}:jqdropdownlist runat=server></{0}:jqdropdownlist>")]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQDropDownList : WebControl
	{
		private JQListItemCollection _itemCollection;
		private DropDownListClientSideEvents _clientSideEvents;
		[Category("Default"), DefaultValue(null), Description("Items in the DropDownList"), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual JQListItemCollection Items
		{
			get
			{
				if (this._itemCollection == null)
				{
					this._itemCollection = new JQListItemCollection();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._itemCollection).TrackViewState();
					}
				}
				return this._itemCollection;
			}
		}
		[Category("Default"), DefaultValue(100), Description("The height of the dropdown.")]
		public new int Height
		{
			get
			{
				if (this.ViewState["Height"] != null)
				{
					return (int)this.ViewState["Height"];
				}
				return 100;
			}
			set
			{
				this.ViewState["Height"] = value;
			}
		}
		[Category("Default"), DefaultValue(100), Description("The width of the dropdown.")]
		public new int Width
		{
			get
			{
				if (this.ViewState["Width"] != null)
				{
					return (int)this.ViewState["Width"];
				}
				return 100;
			}
			set
			{
				this.ViewState["Width"] = value;
			}
		}
		[Category("Default"), DefaultValue(null), Description("The width of the dropdown, if different from the default")]
		public int? DropDownWidth
		{
			get
			{
				if (this.ViewState["DropDownWidth"] != null)
				{
					return (int?)this.ViewState["DropDownWidth"];
				}
				return null;
			}
			set
			{
				this.ViewState["DropDownWidth"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string ItemTemplateID
		{
			get
			{
				if (this.ViewState["ItemTemplateID"] != null)
				{
					return (string)this.ViewState["ItemTemplateID"];
				}
				return "";
			}
			set
			{
				this.ViewState["ItemTemplateID"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string HeaderTemplateID
		{
			get
			{
				if (this.ViewState["HeaderTemplateID"] != null)
				{
					return (string)this.ViewState["HeaderTemplateID"];
				}
				return "";
			}
			set
			{
				this.ViewState["HeaderTemplateID"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string FooterTemplateID
		{
			get
			{
				if (this.ViewState["FooterTemplateID"] != null)
				{
					return (string)this.ViewState["FooterTemplateID"];
				}
				return "";
			}
			set
			{
				this.ViewState["FooterTemplateID"] = value;
			}
		}
		[Category(""), DefaultValue(""), Description("")]
		public string ToggleImageCssClass
		{
			get
			{
				if (this.ViewState["ToggleImageCssClass"] != null)
				{
					return (string)this.ViewState["ToggleImageCssClass"];
				}
				return "";
			}
			set
			{
				this.ViewState["ToggleImageCssClass"] = value;
			}
		}
		[Category("Client-side events"), Description("Defines client-side events in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual DropDownListClientSideEvents ClientSideEvents
		{
			get
			{
				if (this._clientSideEvents == null)
				{
					this._clientSideEvents = new DropDownListClientSideEvents();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._clientSideEvents).TrackViewState();
					}
				}
				return this._clientSideEvents;
			}
		}
		protected override void OnPreRender(EventArgs e)
		{
			JQDropDownListRenderer jQDropDownListRenderer = new JQDropDownListRenderer(this);
			ScriptManager.RegisterStartupScript(this, typeof(JQDropDownListRenderer), "_jqdropdownlist_startup" + this.ClientID, jQDropDownListRenderer.RenderJavaScript(), false);
			base.OnPreRender(e);
		}
		protected override void Render(HtmlTextWriter writer)
		{
			if (!base.DesignMode)
			{
				JQDropDownListRenderer jQDropDownListRenderer = new JQDropDownListRenderer(this);
				writer.Write(jQDropDownListRenderer.RenderHtml());
				return;
			}
			base.Render(writer);
		}
		internal List<Hashtable> SerializeItems(JQListItemCollection items)
		{
			List<Hashtable> list = new List<Hashtable>();
			foreach (JQListItem jQListItem in items)
			{
				list.Add(jQListItem.ToHashtable());
			}
			return list;
		}
	}
}
