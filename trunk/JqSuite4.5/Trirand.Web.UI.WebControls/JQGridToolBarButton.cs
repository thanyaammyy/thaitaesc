using System;
using System.ComponentModel;
namespace Trirand.Web.UI.WebControls
{
	public class JQGridToolBarButton : BaseItem
	{
		[Category("Toolbar Buttons"), DefaultValue(" "), Description("The caption of the button, can be a empty string.")]
		public string Text
		{
			get
			{
				string text = (string)base.ViewState["Text"];
				if (string.IsNullOrEmpty(text))
				{
					return " ";
				}
				return text;
			}
			set
			{
				base.ViewState["Text"] = value;
			}
		}
		[Category("Toolbar Buttons"), DefaultValue(""), Description("The ui icon name from UI theme icon set. If this option is set to “” only the text appear.")]
		public string ButtonIcon
		{
			get
			{
				if (base.ViewState["ButtonIcon"] != null)
				{
					return (string)base.ViewState["ButtonIcon"];
				}
				return "";
			}
			set
			{
				base.ViewState["ButtonIcon"] = value;
			}
		}
		[Category("Toolbar Buttons"), DefaultValue(""), Description("Javascript function event - action to be performed when the button is clicked.")]
		public string OnClick
		{
			get
			{
				if (base.ViewState["OnClick"] != null)
				{
					return (string)base.ViewState["OnClick"];
				}
				return "";
			}
			set
			{
				base.ViewState["OnClick"] = value;
			}
		}
		[Category("Toolbar Buttons"), DefaultValue(ToolBarButtonPosition.Last), Description("First or Last -> the position where the button will be added (i.e., before or after the standard buttons)")]
		public ToolBarButtonPosition Position
		{
			get
			{
				if (base.ViewState["Position"] != null)
				{
					return (ToolBarButtonPosition)base.ViewState["Position"];
				}
				return ToolBarButtonPosition.Last;
			}
			set
			{
				base.ViewState["Position"] = value;
			}
		}
		[Category("Toolbar Buttons"), DefaultValue(""), Description("The tooltip of the button")]
		public string ToolTip
		{
			get
			{
				if (base.ViewState["ToolTip"] != null)
				{
					return (string)base.ViewState["ToolTip"];
				}
				return "";
			}
			set
			{
				base.ViewState["ToolTip"] = value;
			}
		}
	}
}
