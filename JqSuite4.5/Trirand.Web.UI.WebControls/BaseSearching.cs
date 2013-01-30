using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
namespace Trirand.Web.UI.WebControls
{
	internal class BaseSearching
	{
		private JQGrid _grid;
		private bool IsToolBarSearch
		{
			get
			{
				NameValueCollection queryString = this._grid.Page.Request.QueryString;
				string value = queryString["filters"];
				string value2 = queryString["searchField"];
				string arg_39_0 = queryString["searchString"];
				string arg_45_0 = queryString["searchOper"];
				return (!string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value2)) && string.IsNullOrEmpty(value) && this._grid.ToolBarSettings.ShowSearchToolBar;
			}
		}
		public BaseSearching(JQGrid grid)
		{
			this._grid = grid;
		}
		protected SearchOperation GetSearchOperationFromString(string searchOperation)
		{
			switch (searchOperation)
			{
			case "eq":
				return SearchOperation.IsEqualTo;
			case "ne":
				return SearchOperation.IsNotEqualTo;
			case "lt":
				return SearchOperation.IsLessThan;
			case "le":
				return SearchOperation.IsLessOrEqualTo;
			case "gt":
				return SearchOperation.IsGreaterThan;
			case "ge":
				return SearchOperation.IsGreaterOrEqualTo;
			case "in":
				return SearchOperation.IsIn;
			case "ni":
				return SearchOperation.IsNotIn;
			case "bw":
				return SearchOperation.BeginsWith;
			case "bn":
				return SearchOperation.DoesNotBeginWith;
			case "ew":
				return SearchOperation.EndsWith;
			case "en":
				return SearchOperation.DoesNotEndWith;
			case "cn":
				return SearchOperation.Contains;
			case "nc":
				return SearchOperation.DoesNotContain;
			}
			return SearchOperation.IsEqualTo;
		}
		public string GetStringFromSearchOperation(SearchOperation operation)
		{
			switch (operation)
			{
			case SearchOperation.IsEqualTo:
				return "eq";
			case SearchOperation.IsNotEqualTo:
				return "ne";
			case SearchOperation.IsLessThan:
				return "lt";
			case SearchOperation.IsLessOrEqualTo:
				return "le";
			case SearchOperation.IsGreaterThan:
				return "gt";
			case SearchOperation.IsGreaterOrEqualTo:
				return "ge";
			case SearchOperation.IsIn:
				return "in";
			case SearchOperation.IsNotIn:
				return "ni";
			case SearchOperation.BeginsWith:
				return "bw";
			case SearchOperation.DoesNotBeginWith:
				return "bn";
			case SearchOperation.EndsWith:
				return "ew";
			case SearchOperation.DoesNotEndWith:
				return "en";
			case SearchOperation.Contains:
				return "cn";
			case SearchOperation.DoesNotContain:
				return "nc";
			default:
				return "eq";
			}
		}
		protected string ConstructFilterExpression(DataView view, JQGridSearchEventArgs args)
		{
			DataFiltering dataFiltering = new DataFiltering();
			if (view != null)
			{
				return dataFiltering.GetFilterExpression(args.SearchOperation, args.SearchColumn, args.SearchString, view.ToTable().Columns[args.SearchColumn].DataType);
			}
			JQGridColumn jQGridColumn = this._grid.Columns.FromDataField(args.SearchColumn);
			Guard.IsNull(jQGridColumn, "SearchColumn", string.Format("Colunm {0} not found in grid - search cannot proceed.", args.SearchColumn));
			Guard.IsNull(jQGridColumn.DataType, "DataType", "DataType for the respective column must be set in order to get custom search string (where clause)");
			return dataFiltering.GetFilterExpression(args.SearchOperation, args.SearchColumn, args.SearchString, jQGridColumn.DataType);
		}
		private string ConstructLinqFilterExpression(DataView view, JQGridSearchEventArgs args)
		{
			DataFiltering dataFiltering = new DataFiltering();
			if (view != null)
			{
				return dataFiltering.GetLinqFilterExpression(args.SearchOperation, args.SearchColumn, args.SearchString, view.ToTable().Columns[args.SearchColumn].DataType);
			}
			JQGridColumn jQGridColumn = this._grid.Columns.FromDataField(args.SearchColumn);
			Guard.IsNull(jQGridColumn, "SearchColumn", string.Format("Colunm {0} not found in grid - search cannot proceed.", args.SearchColumn));
			Guard.IsNull(jQGridColumn.DataType, "DataType", "DataType for the respective column must be set in order to get custom search string (where clause)");
			return dataFiltering.GetLinqFilterExpression(args.SearchOperation, args.SearchColumn, args.SearchString, jQGridColumn.DataType);
		}
		public string GetWhereClause(DataView view, bool isLinq)
		{
			string text = isLinq ? " && " : " AND ";
			new Hashtable();
			string text2 = string.Empty;
			foreach (JQGridColumn jQGridColumn in this._grid.Columns)
			{
				string text3 = "";
				if (this.IsToolBarSearch)
				{
					text3 = this._grid.Page.Request[jQGridColumn.DataField];
				}
				else
				{
					if (this._grid.Page.Request["searchField"] == jQGridColumn.DataField)
					{
						text3 = this._grid.Page.Request.QueryString["searchString"];
					}
				}
				if (!string.IsNullOrEmpty(text3))
				{
					JQGridSearchEventArgs jQGridSearchEventArgs = new JQGridSearchEventArgs
					{
						SearchColumn = jQGridColumn.DataField,
						SearchString = text3,
						SearchOperation = jQGridColumn.SearchToolBarOperation
					};
					this._grid.OnSearching(jQGridSearchEventArgs);
					if (!jQGridSearchEventArgs.Cancel)
					{
						string str = (text2.Length > 0) ? text : "";
						string str2 = isLinq ? this.ConstructLinqFilterExpression(view, jQGridSearchEventArgs) : this.ConstructFilterExpression(view, jQGridSearchEventArgs);
						text2 = text2 + str + str2;
					}
					this._grid.OnSearched(new EventArgs());
				}
			}
			return text2;
		}
		private bool ExpressionNeedsQuotes(Type t)
		{
			return t == typeof(string) || t == typeof(DateTime);
		}
	}
}
