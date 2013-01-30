using System;
using System.ComponentModel;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	public class AxisCategory : BaseItem
	{
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
		public string Text
		{
			get;
			set;
		}
		public AxisCategory()
		{
			this.Text = "";
		}
	}
}
