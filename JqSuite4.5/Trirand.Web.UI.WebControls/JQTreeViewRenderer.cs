using System;
using System.Text;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal class JQTreeViewRenderer
	{
		private JQTreeView _model;
		public JQTreeViewRenderer(JQTreeView model)
		{
			this._model = model;
		}
		public string RenderHtml()
		{
			if (DateTime.Now > CompiledOn.CompilationDate.AddDays(45.0))
			{
				return "This is a 30-day trial version of jqSuite for ASP.NET MVC which has expired.<br> Please, contact sales@trirand.net for purchasing the product or for trial extension.";
			}
			Guard.IsNotNullOrEmpty(this._model.ID, "ID", "You need to set ID for this JQTree instance.");
			Guard.IsNotNullOrEmpty(this._model.DataUrl, "DataUrl", "You need to set DataUrl to the Action of the tree returning nodes.");
			return this.DoRenderHtml() + this.RenderHidden();
		}
		public string RenderJavaScript()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<script type='text/javascript'>\n");
			stringBuilder.Append("jQuery(document).ready(function() {");
			stringBuilder.AppendFormat("jQuery('#{0}').jqTreeView({{", this._model.ClientID);
			stringBuilder.Append(this.GetStartupOptions());
			stringBuilder.Append("});");
			stringBuilder.Append("});");
			stringBuilder.Append("</script>");
			return stringBuilder.ToString();
		}
		private string RenderHidden()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("<input type='hidden' id='{0}' name='{1}' />", this._model.UniqueID, this._model.UniqueID);
			return stringBuilder.ToString();
		}
		private string DoRenderHtml()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("<div id='{0}_wrapper' class='ui-widget ui-jqtreeview-wrapper' style='width:{1}; height:{2}'>", this._model.ClientID, this._model.Width.ToString(), this._model.Height.ToString());
			stringBuilder.AppendFormat("<ul id='{0}'></ul>", this._model.ClientID);
			stringBuilder.Append("</div>");
			return stringBuilder.ToString();
		}
		private string GetStartupOptions()
		{
			StringBuilder stringBuilder = new StringBuilder();
			JQTreeView model = this._model;
			TreeViewClientSideEvents clientSideEvents = model.ClientSideEvents;
			stringBuilder.AppendFormat("id: '{0}'", model.ClientID);
			stringBuilder.AppendFormat(",dataUrl: '{0}'", model.DataUrl);
			if (!model.HoverOnMouseOver)
			{
				stringBuilder.AppendFormat(",hoverOnMouseOver:false", new object[0]);
			}
			if (model.CheckBoxes)
			{
				stringBuilder.Append(",checkBoxes:true");
			}
			if (model.MultipleSelect)
			{
				stringBuilder.Append(",multipleSelect:true");
			}
			if (model.Nodes.Count > 0)
			{
				stringBuilder.AppendFormat(",nodes:{0}", new JavaScriptSerializer().Serialize(model.SerializeNodes(model.Nodes)));
			}
			if (!string.IsNullOrEmpty(clientSideEvents.Check))
			{
				stringBuilder.AppendFormat(",onCheck:{0}", clientSideEvents.Check);
			}
			if (!string.IsNullOrEmpty(clientSideEvents.Collapse))
			{
				stringBuilder.AppendFormat(",onCollapse:{0}", clientSideEvents.Collapse);
			}
			if (!string.IsNullOrEmpty(clientSideEvents.Expand))
			{
				stringBuilder.AppendFormat(",onExpand:{0}", clientSideEvents.Expand);
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
			return stringBuilder.ToString();
		}
	}
}
