using System;
using System.Collections;
using System.ComponentModel;
namespace Trirand.Web.UI.WebControls
{
	public class JQGridHeaderGroup : BaseItem
	{
		[Category("Header Groups"), DefaultValue(""), Description("The name (datafield) of the column from which the grouping header begin, including the same field")]
		public string StartColumnName
		{
			get
			{
				object obj = base.ViewState["StartColumnName"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				base.ViewState["StartColumnName"] = value;
			}
		}
		[Category("Header Groups"), DefaultValue(""), Description("The text for the title of the group. The text can contain html tags")]
		public string TitleText
		{
			get
			{
				object obj = base.ViewState["TitleText"];
				if (obj == null)
				{
					return "";
				}
				return (string)obj;
			}
			set
			{
				base.ViewState["TitleText"] = value;
			}
		}
		[Category("Header Groups"), DefaultValue(1), Description("The number of columns that are included in this group. Note that the number starts from the startColumnName. If the column is hidden it is skipped and as result the group does not contain the field, but the method counts it.")]
		public int NumberOfColumns
		{
			get
			{
				object obj = base.ViewState["NumberOfColumns"];
				if (obj == null)
				{
					return 1;
				}
				return (int)obj;
			}
			set
			{
				base.ViewState["NumberOfColumns"] = value;
			}
		}
		public JQGridHeaderGroup()
		{
			this.StartColumnName = "";
			this.NumberOfColumns = 1;
			this.TitleText = "";
		}
		internal Hashtable ToHashtable()
		{
			Hashtable hashtable = new Hashtable();
			if (!string.IsNullOrEmpty(this.StartColumnName))
			{
				hashtable["startColumnName"] = this.StartColumnName;
			}
			hashtable["numberOfColumns"] = this.NumberOfColumns;
			if (!string.IsNullOrEmpty(this.TitleText))
			{
				hashtable["titleText"] = this.TitleText;
			}
			return hashtable;
		}
	}
}
