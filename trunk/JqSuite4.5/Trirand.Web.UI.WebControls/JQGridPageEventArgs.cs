using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridPageEventArgs : CancelEventArgs
	{
		private int _newPageIndex;
		private int _totalRows;
		public int NewPageIndex
		{
			get
			{
				return this._newPageIndex;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._newPageIndex = value;
			}
		}
		public int TotalRows
		{
			get
			{
				return this._totalRows;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._totalRows = value;
			}
		}
		public JQGridPageEventArgs(int newPageIndex)
		{
			this._newPageIndex = newPageIndex;
		}
	}
}
