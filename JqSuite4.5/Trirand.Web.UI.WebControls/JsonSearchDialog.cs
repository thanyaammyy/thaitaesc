using System;
using System.Collections;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal class JsonSearchDialog
	{
		private Hashtable _jsonValues;
		private JQGrid _grid;
		public JsonSearchDialog(JQGrid grid)
		{
			this._jsonValues = new Hashtable();
			this._grid = grid;
		}
		public string Process()
		{
			SearchDialogSettings searchDialogSettings = this._grid.SearchDialogSettings;
			if (searchDialogSettings.TopOffset != 0)
			{
				this._jsonValues["top"] = searchDialogSettings.TopOffset;
			}
			if (searchDialogSettings.LeftOffset != 0)
			{
				this._jsonValues["left"] = searchDialogSettings.LeftOffset;
			}
			if (searchDialogSettings.Width != 300)
			{
				this._jsonValues["width"] = searchDialogSettings.Width;
			}
			if (searchDialogSettings.Height != 300)
			{
				this._jsonValues["height"] = searchDialogSettings.Height;
			}
			if (searchDialogSettings.Modal)
			{
				this._jsonValues["modal"] = true;
			}
			if (!searchDialogSettings.Draggable)
			{
				this._jsonValues["drag"] = false;
			}
			if (!searchDialogSettings.Resizable)
			{
				this._jsonValues["resize"] = false;
			}
			if (!string.IsNullOrEmpty(searchDialogSettings.FindButtonText))
			{
				this._jsonValues["Find"] = searchDialogSettings.FindButtonText;
			}
			if (!string.IsNullOrEmpty(searchDialogSettings.ResetButtonText))
			{
				this._jsonValues["Clear"] = searchDialogSettings.ResetButtonText;
			}
			if (searchDialogSettings.MultipleSearch)
			{
				this._jsonValues["multipleSearch"] = true;
			}
			if (searchDialogSettings.ValidateInput)
			{
				this._jsonValues["checkInput"] = true;
			}
			return new JavaScriptSerializer().Serialize(this._jsonValues);
		}
	}
}
