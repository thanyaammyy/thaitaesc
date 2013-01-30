using System;
using System.Text;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal class JQAutoCompleteRenderer
	{
		private JQAutoComplete _autoComplete;
		public JQAutoCompleteRenderer(JQAutoComplete autoComplete)
		{
			this._autoComplete = autoComplete;
		}
		internal string RenderHtml()
		{
			if (this._autoComplete.DisplayMode == AutoCompleteDisplayMode.Standalone)
			{
				return this.GetStandaloneJavascript();
			}
			return this.GetControlEditorJavascript();
		}
		internal string GetStandaloneJavascript()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("<input type='text' id='{0}' name='{0}' />", this._autoComplete.GetID());
			stringBuilder.Append("<script type='text/javascript'>\n");
			stringBuilder.Append("jQuery(document).ready(function() {");
			stringBuilder.AppendFormat("jQuery('#{0}').autocomplete({{", this._autoComplete.GetID());
			stringBuilder.Append(this.GetStartupOptions());
			stringBuilder.Append("});");
			stringBuilder.Append("});");
			stringBuilder.Append("</script>");
			return stringBuilder.ToString();
		}
		private string GetControlEditorJavascript()
		{
			return string.Format("<script type='text/javascript'>var {0}_acid = {{ {1} }};</script>", this._autoComplete.GetID(), this.GetStartupOptions());
		}
		private string GetStartupOptions()
		{
			new JavaScriptSerializer();
			StringBuilder stringBuilder = new StringBuilder();
			string arg = (this._autoComplete.DataUrl.IndexOf("?") > 0) ? "&" : "?";
			string arg2 = string.Format("{0}{1}jqAutoCompleteID={2}", this._autoComplete.DataUrl, arg, this._autoComplete.GetID());
			stringBuilder.AppendFormat("id: '{0}'", this._autoComplete.GetID());
			stringBuilder.AppendFormat(",source: '{0}'", arg2);
			stringBuilder.AppendFormatIfTrue(this._autoComplete.Delay != 300, ",delay: {0}", new object[]
			{
				this._autoComplete.Delay
			});
			stringBuilder.AppendIfFalse(this._autoComplete.Enabled, ",disabled: true");
			stringBuilder.AppendFormatIfTrue(this._autoComplete.MinLength != 1, ",minLength: {0}", new object[]
			{
				this._autoComplete.MinLength
			});
			return stringBuilder.ToString();
		}
	}
}
