using System;
using System.Text;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal class JQDropDownListRenderer
	{
		private JQDropDownList _model;
		public JQDropDownListRenderer(JQDropDownList model)
		{
			this._model = model;
		}
		internal string RenderHtml()
		{
			if (DateTime.Now > CompiledOn.CompilationDate.AddDays(45.0))
			{
				return "This is a 30-day trial version of jqSuite for ASP.NET WebForms which has expired.<br> Please, contact sales@trirand.net for purchasing the product or for trial extension.";
			}
			Guard.IsNotNullOrEmpty(this._model.ID, "ID", "You need to set ID for this JQDropDownList instance.");
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("<span id='{0}'></span>", this._model.ClientID);
			return stringBuilder.ToString();
		}
		internal string RenderJavaScript()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("<span id='{0}'></span>", this._model.ID);
			stringBuilder.Append("<script type='text/javascript'>\n");
			stringBuilder.Append("jQuery(document).ready(function() {");
			stringBuilder.AppendFormat("jQuery('#{0}').jqDropDownList({{", this._model.ID);
			stringBuilder.Append(this.GetStartupOptions());
			stringBuilder.Append("});");
			stringBuilder.Append("});");
			stringBuilder.Append("</script>");
			return stringBuilder.ToString();
		}
		private string GetStartupOptions()
		{
			StringBuilder stringBuilder = new StringBuilder();
			JQDropDownList model = this._model;
			DropDownListClientSideEvents clientSideEvents = this._model.ClientSideEvents;
			stringBuilder.AppendFormat("id:'{0}'", model.ID);
			stringBuilder.AppendFormat(",width:{0}", model.Width.ToString());
			stringBuilder.AppendFormat(",height:{0}", model.Height.ToString());
			if (model.DropDownWidth.HasValue)
			{
				stringBuilder.AppendFormat(",dropDownWidth:{0}", model.DropDownWidth.ToString());
			}
			if (model.TabIndex != 0)
			{
				stringBuilder.AppendFormat(",tabIndex:{0}", model.TabIndex.ToString());
			}
			if (model.Items.Count > 0)
			{
				stringBuilder.AppendFormat(",items:{0}", new JavaScriptSerializer().Serialize(model.SerializeItems(model.Items)));
			}
			if (!string.IsNullOrEmpty(model.ItemTemplateID))
			{
				stringBuilder.AppendFormat(",itemTemplateID:'{0}'", model.ItemTemplateID);
			}
			if (!string.IsNullOrEmpty(model.HeaderTemplateID))
			{
				stringBuilder.AppendFormat(",headerTemplateID:'{0}'", model.HeaderTemplateID);
			}
			if (!string.IsNullOrEmpty(model.FooterTemplateID))
			{
				stringBuilder.AppendFormat(",footerTemplateID:'{0}'", model.FooterTemplateID);
			}
			if (!string.IsNullOrEmpty(model.ToggleImageCssClass))
			{
				stringBuilder.AppendFormat(",toggleImageCssClass:'{0}'", model.ToggleImageCssClass);
			}
			if (!string.IsNullOrEmpty(clientSideEvents.Show))
			{
				stringBuilder.AppendFormat(",onShow:{0}", clientSideEvents.Show);
			}
			if (!string.IsNullOrEmpty(clientSideEvents.Hide))
			{
				stringBuilder.AppendFormat(",onHide:{0}", clientSideEvents.Hide);
			}
			if (!string.IsNullOrEmpty(clientSideEvents.MouseOut))
			{
				stringBuilder.AppendFormat(",onMouseOut:{0}", clientSideEvents.MouseOut);
			}
			if (!string.IsNullOrEmpty(clientSideEvents.MouseOver))
			{
				stringBuilder.AppendFormat(",onMouseOver:{0}", clientSideEvents.MouseOver);
			}
			if (!string.IsNullOrEmpty(clientSideEvents.Select))
			{
				stringBuilder.AppendFormat(",onSelect:{0}", clientSideEvents.Select);
			}
			if (!string.IsNullOrEmpty(clientSideEvents.Select))
			{
				stringBuilder.AppendFormat(",onInitialized:{0}", clientSideEvents.Initialized);
			}
			if (!string.IsNullOrEmpty(clientSideEvents.Select))
			{
				stringBuilder.AppendFormat(",onKeyDown:{0}", clientSideEvents.KeyDown);
			}
			return stringBuilder.ToString();
		}
		private string GetButtonText()
		{
			string text = "";
			foreach (JQListItem jQListItem in this._model.Items)
			{
				if (jQListItem.Selected)
				{
					text = jQListItem.Text;
					break;
				}
			}
			if (string.IsNullOrEmpty(text) && this._model.Items.Count > 0)
			{
				text = this._model.Items[0].Text;
			}
			return text;
		}
	}
}
