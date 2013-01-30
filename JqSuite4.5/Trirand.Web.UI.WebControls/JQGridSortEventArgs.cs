using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridSortEventArgs : CancelEventArgs
	{
		private SortDirection _sortDirection;
		private string _sortExpression;
		public SortDirection SortDirection
		{
			get
			{
				return this._sortDirection;
			}
			set
			{
				this._sortDirection = value;
			}
		}
		public string SortExpression
		{
			get
			{
				return this._sortExpression;
			}
			set
			{
				this._sortExpression = value;
			}
		}
		public string NewSortExpression
		{
			get;
			set;
		}
		public JQGridSortEventArgs(string sortExpression, string sortDirection)
		{
			this._sortExpression = sortExpression;
			if (sortDirection != null)
			{
				this._sortDirection = ((sortDirection.ToLower() == "asc") ? SortDirection.Asc : SortDirection.Desc);
				return;
			}
			this._sortDirection = SortDirection.Asc;
		}
	}
}
