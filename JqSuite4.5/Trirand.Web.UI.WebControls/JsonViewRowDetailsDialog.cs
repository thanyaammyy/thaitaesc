using System;
using System.Collections;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal class JsonViewRowDetailsDialog
	{
		private Hashtable _jsonValues;
		private JQGrid _grid;
		public JsonViewRowDetailsDialog(JQGrid grid)
		{
			this._jsonValues = new Hashtable();
			this._grid = grid;
		}
		public string Process()
		{
			ViewRowDetailsDialogSettings viewRowDetailsDialogSettings = this._grid.ViewRowDetailsDialogSettings;
			if (viewRowDetailsDialogSettings.TopOffset != 0)
			{
				this._jsonValues["top"] = viewRowDetailsDialogSettings.TopOffset;
			}
			if (viewRowDetailsDialogSettings.LeftOffset != 0)
			{
				this._jsonValues["left"] = viewRowDetailsDialogSettings.LeftOffset;
			}
			if (viewRowDetailsDialogSettings.Width != 300)
			{
				this._jsonValues["width"] = viewRowDetailsDialogSettings.Width;
			}
			if (viewRowDetailsDialogSettings.Height != 300)
			{
				this._jsonValues["height"] = viewRowDetailsDialogSettings.Height;
			}
			if (viewRowDetailsDialogSettings.Modal)
			{
				this._jsonValues["modal"] = true;
			}
			if (!viewRowDetailsDialogSettings.Draggable)
			{
				this._jsonValues["drag"] = false;
			}
			if (!viewRowDetailsDialogSettings.Resizable)
			{
				this._jsonValues["resize"] = false;
			}
			if (!string.IsNullOrEmpty(viewRowDetailsDialogSettings.Caption))
			{
				this._jsonValues["editCaption"] = viewRowDetailsDialogSettings.Caption;
			}
			if (!string.IsNullOrEmpty(viewRowDetailsDialogSettings.SubmitText))
			{
				this._jsonValues["bSubmit"] = viewRowDetailsDialogSettings.SubmitText;
			}
			if (!string.IsNullOrEmpty(viewRowDetailsDialogSettings.CancelText))
			{
				this._jsonValues["bCancel"] = viewRowDetailsDialogSettings.CancelText;
			}
			return new JavaScriptSerializer().Serialize(this._jsonValues);
		}
	}
}
