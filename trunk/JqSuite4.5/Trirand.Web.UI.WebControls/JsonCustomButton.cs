using System;
using System.Collections;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal class JsonCustomButton
	{
		private Hashtable _jsonValues;
		private JQGridToolBarButton _button;
		private JavaScriptSerializer _jsonSerializer;
		public JsonCustomButton(JQGridToolBarButton button)
		{
			this._jsonSerializer = new JavaScriptSerializer();
			this._jsonValues = new Hashtable();
			this._button = button;
		}
		public string Process()
		{
			string value = string.IsNullOrEmpty(this._button.Text) ? " " : this._button.Text;
			if (!string.IsNullOrEmpty(this._button.Text))
			{
				this._jsonValues["caption"] = value;
			}
			if (!string.IsNullOrEmpty(this._button.ButtonIcon))
			{
				this._jsonValues["buttonicon"] = this._button.ButtonIcon;
			}
			this._jsonValues["position"] = this._button.Position.ToString().ToLower();
			if (!string.IsNullOrEmpty(this._button.ToolTip))
			{
				this._jsonValues["title"] = this._button.ToolTip;
			}
			string json = new JavaScriptSerializer().Serialize(this._jsonValues);
			return JsonUtil.RenderClientSideEvent(json, "onClickButton", this._button.OnClick);
		}
	}
}
