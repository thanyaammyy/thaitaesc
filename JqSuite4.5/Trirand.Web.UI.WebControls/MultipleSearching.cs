using System;
using System.Data;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal class MultipleSearching : BaseSearching
	{
		private JQGrid _grid;
		private string _searchFilters;
		public MultipleSearching(JQGrid grid, string searchFilters) : base(grid)
		{
			this._grid = grid;
			this._searchFilters = searchFilters;
		}
		public void PerformSearch(DataView view)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			JsonMultipleSearch jsonMultipleSearch = javaScriptSerializer.Deserialize<JsonMultipleSearch>(this._searchFilters);
			string text = "";
			foreach (MultipleSearchRule current in jsonMultipleSearch.rules)
			{
				JQGridSearchEventArgs jQGridSearchEventArgs = new JQGridSearchEventArgs
				{
					SearchColumn = current.field,
					SearchString = current.data,
					SearchOperation = base.GetSearchOperationFromString(current.op)
				};
				this._grid.OnSearching(jQGridSearchEventArgs);
				if (!jQGridSearchEventArgs.Cancel)
				{
					string str = (text.Length > 0) ? (" " + jsonMultipleSearch.groupOp + " ") : "";
					text = text + str + base.ConstructFilterExpression(view, jQGridSearchEventArgs);
				}
				view.RowFilter = text;
				this._grid.OnSearched(new EventArgs());
			}
		}
	}
}
