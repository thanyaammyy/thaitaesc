using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridSearchEventArgs : CancelEventArgs
	{
		private string _searchColumn;
		private string _searchString;
		private SearchOperation _searchOperation;
		public string SearchColumn
		{
			get
			{
				return this._searchColumn;
			}
			set
			{
				this._searchColumn = value;
			}
		}
		public string SearchString
		{
			get
			{
				return this._searchString;
			}
			set
			{
				this._searchString = value;
			}
		}
		public SearchOperation SearchOperation
		{
			get
			{
				return this._searchOperation;
			}
			set
			{
				this._searchOperation = value;
			}
		}
		public JQGridSearchEventArgs()
		{
		}
		public JQGridSearchEventArgs(string searchColumn, string searchString, SearchOperation searchOperation) : this()
		{
			this._searchColumn = searchColumn;
			this._searchString = searchString;
			this._searchOperation = searchOperation;
		}
	}
}
