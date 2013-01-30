using System;
using System.Data;
namespace Trirand.Web.UI.WebControls
{
	internal class ToolBarSearching : BaseSearching
	{
		private JQGrid _grid;
		public ToolBarSearching(JQGrid grid) : base(grid)
		{
			this._grid = grid;
		}
		public void PerformSearch(DataView view)
		{
			try
			{
				view.RowFilter = base.GetWhereClause(view, false);
			}
			catch (Exception)
			{
			}
		}
	}
}
