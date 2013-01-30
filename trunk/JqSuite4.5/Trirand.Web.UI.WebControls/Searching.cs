using System;
using System.Data;
namespace Trirand.Web.UI.WebControls
{
	internal class Searching : BaseSearching
	{
		private JQGrid _grid;
		private string _searchColunm;
		private string _searchString;
		private string _searchOperation;
		public Searching(JQGrid grid, string searchColumn, string searchString, string searchOperation) : base(grid)
		{
			this._grid = grid;
			this._searchColunm = searchColumn;
			this._searchString = searchString;
			this._searchOperation = searchOperation;
		}
		public void PerformSearch(DataView view, string search)
		{
			if (!string.IsNullOrEmpty(search) && Convert.ToBoolean(search))
			{
				JQGridSearchEventArgs jQGridSearchEventArgs = new JQGridSearchEventArgs
				{
					SearchColumn = this._searchColunm,
					SearchString = this._searchString,
					SearchOperation = base.GetSearchOperationFromString(this._searchOperation)
				};
				this._grid.OnSearching(jQGridSearchEventArgs);
				if (!jQGridSearchEventArgs.Cancel)
				{
					try
					{
						view.RowFilter = base.ConstructFilterExpression(view, jQGridSearchEventArgs);
					}
					catch (Exception)
					{
					}
				}
				this._grid.OnSearched(new EventArgs());
			}
		}
	}
}
