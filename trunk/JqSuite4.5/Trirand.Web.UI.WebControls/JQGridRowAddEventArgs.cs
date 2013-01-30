using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridRowAddEventArgs : CancelEventArgs
	{
		private NameValueCollection _rowData;
		private string _parentRowKey;
		public NameValueCollection RowData
		{
			get
			{
				return this._rowData;
			}
			set
			{
				this._rowData = value;
			}
		}
		public string ParentRowKey
		{
			get
			{
				return this._parentRowKey;
			}
			set
			{
				this._parentRowKey = value;
			}
		}
	}
}
