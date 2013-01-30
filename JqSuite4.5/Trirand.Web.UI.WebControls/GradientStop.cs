using System;
using System.ComponentModel;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	public class GradientStop : BaseItem
	{
		[Category("Settings"), Description(""), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
		public string Value
		{
			get;
			set;
		}
		public GradientStop()
		{
			this.Value = "";
		}
	}
}
