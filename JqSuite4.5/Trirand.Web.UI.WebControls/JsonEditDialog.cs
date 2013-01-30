using System;
using System.Collections;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal class JsonEditDialog
	{
		private Hashtable _jsonValues;
		private JQGrid _grid;
		public JsonEditDialog(JQGrid grid)
		{
			this._jsonValues = new Hashtable();
			this._grid = grid;
		}
		public string Process()
		{
			EditDialogSettings editDialogSettings = this._grid.EditDialogSettings;
			if (editDialogSettings.TopOffset != 0)
			{
				this._jsonValues["top"] = editDialogSettings.TopOffset;
			}
			if (editDialogSettings.LeftOffset != 0)
			{
				this._jsonValues["left"] = editDialogSettings.LeftOffset;
			}
			if (editDialogSettings.Width != 300)
			{
				this._jsonValues["width"] = editDialogSettings.Width;
			}
			if (editDialogSettings.Height != 300)
			{
				this._jsonValues["height"] = editDialogSettings.Height;
			}
			if (editDialogSettings.Modal)
			{
				this._jsonValues["modal"] = true;
			}
			if (!editDialogSettings.Draggable)
			{
				this._jsonValues["drag"] = false;
			}
			if (!editDialogSettings.Resizable)
			{
				this._jsonValues["resize"] = false;
			}
			if (!string.IsNullOrEmpty(editDialogSettings.Caption))
			{
				this._jsonValues["editCaption"] = editDialogSettings.Caption;
			}
			if (!string.IsNullOrEmpty(editDialogSettings.SubmitText))
			{
				this._jsonValues["bSubmit"] = editDialogSettings.SubmitText;
			}
			if (!string.IsNullOrEmpty(editDialogSettings.CancelText))
			{
				this._jsonValues["bCancel"] = editDialogSettings.CancelText;
			}
			if (!string.IsNullOrEmpty(editDialogSettings.LoadingMessageText))
			{
				this._jsonValues["processData"] = editDialogSettings.LoadingMessageText;
			}
			if (editDialogSettings.CloseAfterEditing)
			{
				this._jsonValues["closeAfterEdit"] = true;
			}
			if (!editDialogSettings.ReloadAfterSubmit)
			{
				this._jsonValues["reloadAfterSubmit"] = false;
			}
			this._jsonValues["recreateForm"] = true;
			string json = new JavaScriptSerializer().Serialize(this._jsonValues);
			ClientSideEvents clientSideEvents = this._grid.ClientSideEvents;
			json = JsonUtil.RenderClientSideEvent(json, "beforeShowForm", clientSideEvents.BeforeEditDialogShown);
			json = JsonUtil.RenderClientSideEvent(json, "afterShowForm", clientSideEvents.AfterEditDialogShown);
			json = JsonUtil.RenderClientSideEvent(json, "afterComplete", clientSideEvents.AfterEditDialogRowInserted);
			return JsonUtil.RenderClientSideEvent(json, "errorTextFormat", "function(data) { return 'Error: ' + data.responseText }");
		}
	}
}
