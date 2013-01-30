using System;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridDataRequestEventArgs : EventArgs
	{
		private SortDirection _sortDirection;
		private string _sortExpression;
		private string _searchExpression;
		private int _newPageIndex;
		private int _totalRows;
		private string _parentRowKey;
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
		public string SearchExpression
		{
			get
			{
				return this._searchExpression;
			}
			set
			{
				this._searchExpression = value;
			}
		}
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
		public JQGridDataRequestEventArgs(string sortExpression, string sortDirection, int newPageIndex, string searchExpression, string parentRowKey)
		{
			this._sortExpression = sortExpression;
			this._newPageIndex = newPageIndex;
			this._searchExpression = searchExpression;
			this._parentRowKey = parentRowKey;
			if (sortDirection == null)
			{
				sortDirection = string.Empty;
			}
			this._sortDirection = ((sortDirection.ToLower() == "asc") ? SortDirection.Asc : SortDirection.Desc);
		}
	}
}
