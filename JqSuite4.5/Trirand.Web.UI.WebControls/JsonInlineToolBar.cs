using System;
using System.Collections;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal class JsonInlineToolBar
	{
		private ToolBarSettings _s;
		public JsonInlineToolBar(ToolBarSettings settings)
		{
			this._s = settings;
		}
		internal bool IsEmpty()
		{
			return !this._s.ShowInlineCancelButton && !this._s.ShowInlineAddButton && !this._s.ShowInlineDeleteButton && !this._s.ShowInlineEditButton;
		}
		internal Hashtable ToHashtable()
		{
			Hashtable hashtable = new Hashtable();
			if (this._s.ShowInlineAddButton)
			{
				hashtable.Add("add", true);
			}
			if (this._s.ShowInlineDeleteButton)
			{
				hashtable.Add("del", true);
			}
			if (this._s.ShowInlineEditButton)
			{
				hashtable.Add("edit", true);
			}
			if (this._s.ShowInlineCancelButton)
			{
				hashtable.Add("cancel", true);
			}
			Hashtable hashtable2 = new Hashtable();
			hashtable2.Add("keys", true);
			Hashtable hashtable3 = new Hashtable();
			hashtable3.Add("keys", true);
			hashtable.Add("addParams", new Hashtable
			{

				{
					"keys",
					true
				},

				{
					"useFormatter",
					false
				},

				{
					"addRowParams",
					hashtable3
				}
			});
			hashtable.Add("editParams", hashtable2);
			return hashtable;
		}
		internal string ToJSON()
		{
			return new JavaScriptSerializer().Serialize(this.ToHashtable());
		}
	}
}
