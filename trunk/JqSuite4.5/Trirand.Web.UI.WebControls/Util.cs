using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal static class Util
	{
		internal class SearchArguments
		{
			public string SearchColumn
			{
				get;
				set;
			}
			public string SearchString
			{
				get;
				set;
			}
			public SearchOperation SearchOperation
			{
				get;
				set;
			}
		}
		internal static JsonResponse PrepareJsonResponse(JsonResponse response, JQGrid grid, DataTable dt)
		{
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				string[] array = new string[grid.Columns.Count];
				for (int j = 0; j < grid.Columns.Count; j++)
				{
					JQGridColumn jQGridColumn = grid.Columns[j];
					string text = "";
					if (!string.IsNullOrEmpty(jQGridColumn.DataField))
					{
						Guard.IsNull(dt.Columns[jQGridColumn.DataField], "The column with DataField=" + jQGridColumn.DataField + " does not exist in the datasource.");
						int ordinal = dt.Columns[jQGridColumn.DataField].Ordinal;
						text = (string.IsNullOrEmpty(jQGridColumn.DataFormatString) ? dt.Rows[i].ItemArray[ordinal].ToString() : jQGridColumn.FormatDataValue(dt.Rows[i].ItemArray[ordinal], jQGridColumn.HtmlEncode));
					}
					array[j] = text;
				}
				string text2 = array[Util.GetPrimaryKeyIndex(grid)];
				for (int k = 0; k < grid.Columns.Count; k++)
				{
					JQGridCellBindEventArgs jQGridCellBindEventArgs = new JQGridCellBindEventArgs(array[k], k, i, text2, dt.Rows[i].ItemArray);
					grid.OnCellBinding(jQGridCellBindEventArgs);
					array[k] = jQGridCellBindEventArgs.CellHtml;
					grid.OnCellBound(jQGridCellBindEventArgs);
				}
				JsonRow jsonRow = new JsonRow();
				jsonRow.id = text2;
				jsonRow.cell = array;
				response.rows[i] = jsonRow;
			}
			return response;
		}
		internal static JsonTreeResponse PrepareJsonTreeResponse(JsonTreeResponse response, JQGrid grid, DataTable dt)
		{
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				response.rows[i] = new Hashtable();
				for (int j = 0; j < grid.Columns.Count; j++)
				{
					JQGridColumn jQGridColumn = grid.Columns[j];
					string value = "";
					if (!string.IsNullOrEmpty(jQGridColumn.DataField))
					{
						Guard.IsNull(dt.Columns[jQGridColumn.DataField], "The column with DataField=" + jQGridColumn.DataField + " does not exist in the datasource.");
						int ordinal = dt.Columns[jQGridColumn.DataField].Ordinal;
						value = (string.IsNullOrEmpty(jQGridColumn.DataFormatString) ? dt.Rows[i].ItemArray[ordinal].ToString() : jQGridColumn.FormatDataValue(dt.Rows[i].ItemArray[ordinal], jQGridColumn.HtmlEncode));
					}
					response.rows[i].Add(jQGridColumn.DataField, value);
				}
				try
				{
					response.rows[i].Add("tree_level", dt.Rows[i]["tree_level"] as int?);
				}
				catch
				{
				}
				try
				{
					response.rows[i].Add("tree_parent", Convert.ToString(dt.Rows[i]["tree_parent"]));
				}
				catch
				{
				}
				try
				{
					response.rows[i].Add("tree_leaf", Convert.ToBoolean(dt.Rows[i]["tree_leaf"]));
				}
				catch
				{
				}
				try
				{
					response.rows[i].Add("tree_expanded", Convert.ToBoolean(dt.Rows[i]["tree_expanded"]));
				}
				catch
				{
				}
				try
				{
					response.rows[i].Add("tree_loaded", Convert.ToBoolean(dt.Rows[i]["tree_loaded"]));
				}
				catch
				{
				}
				try
				{
					response.rows[i].Add("tree_icon", Convert.ToString(dt.Rows[i]["tree_icon"]));
				}
				catch
				{
				}
			}
			return response;
		}
		internal static string ConvertToJson(JsonResponse response, JQGrid grid, DataTable dt)
		{
			object obj;
			if (response.records == 0)
			{
				obj = new object[0];
			}
			else
			{
				obj = Util.PrepareJsonResponse(response, grid, dt);
			}
			return new JavaScriptSerializer().Serialize(obj);
		}
		internal static string ConvertToTreeJson(JsonTreeResponse response, JQGrid grid, DataTable dt)
		{
			object obj = Util.PrepareJsonTreeResponse(response, grid, dt);
			return new JavaScriptSerializer().Serialize(obj);
		}
		public static int GetPrimaryKeyIndex(JQGrid grid)
		{
			foreach (JQGridColumn jQGridColumn in grid.Columns)
			{
				if (jQGridColumn.PrimaryKey)
				{
					return grid.Columns.IndexOf(jQGridColumn);
				}
			}
			return 0;
		}
		public static string GetPrimaryKeyField(JQGrid grid)
		{
			int primaryKeyIndex = Util.GetPrimaryKeyIndex(grid);
			return grid.Columns[primaryKeyIndex].DataField;
		}
		public static Hashtable GetFooterInfo(JQGrid grid)
		{
			Hashtable hashtable = new Hashtable();
			if (grid.AppearanceSettings.ShowFooter)
			{
				foreach (JQGridColumn jQGridColumn in grid.Columns)
				{
					hashtable[jQGridColumn.DataField] = jQGridColumn.FooterValue;
				}
			}
			return hashtable;
		}
		public static string GetWhereClause(JQGrid grid)
		{
			string text = " && ";
			string text2 = "";
			new Hashtable();
			foreach (JQGridColumn jQGridColumn in grid.Columns)
			{
				string text3 = HttpContext.Current.Request[jQGridColumn.DataField];
				if (!string.IsNullOrEmpty(text3))
				{
					Util.SearchArguments args = new Util.SearchArguments
					{
						SearchColumn = jQGridColumn.DataField,
						SearchString = text3,
						SearchOperation = jQGridColumn.SearchToolBarOperation
					};
					string str = (text2.Length > 0) ? text : "";
					string str2 = Util.ConstructLinqFilterExpression(args);
					text2 = text2 + str + str2;
				}
			}
			return text2;
		}
		private static string ConstructLinqFilterExpression(Util.SearchArguments args)
		{
			string filterExpressionCompare = "{0} {1} \"{2}\"";
			return Util.GetLinqExpression(filterExpressionCompare, args);
		}
		internal static string ConstructLinqFilterExpression(JQAutoComplete autoComplete, Util.SearchArguments args)
		{
			Guard.IsNull(autoComplete.DataTextField, "DataField", "must be set in order to perform search operations.");
			string filterExpressionCompare = "{0} {1} \"{2}\"";
			return Util.GetLinqExpression(filterExpressionCompare, args);
		}
		private static string GetLinqExpression(string filterExpressionCompare, Util.SearchArguments args)
		{
			switch (args.SearchOperation)
			{
			case SearchOperation.IsEqualTo:
				return string.Format(filterExpressionCompare, args.SearchColumn, "=", args.SearchString);
			case SearchOperation.IsLessThan:
				return string.Format(filterExpressionCompare, args.SearchColumn, "<", args.SearchString);
			case SearchOperation.IsLessOrEqualTo:
				return string.Format(filterExpressionCompare, args.SearchColumn, "<=", args.SearchString);
			case SearchOperation.IsGreaterThan:
				return string.Format(filterExpressionCompare, args.SearchColumn, ">", args.SearchString);
			case SearchOperation.IsGreaterOrEqualTo:
				return string.Format(filterExpressionCompare, args.SearchColumn, ">=", args.SearchString);
			case SearchOperation.BeginsWith:
				return string.Format("{0}.StartsWith(\"{1}\")", args.SearchColumn, args.SearchString);
			case SearchOperation.DoesNotBeginWith:
				return string.Format("!{0}.StartsWith(\"{1}\")", args.SearchColumn, args.SearchString);
			case SearchOperation.EndsWith:
				return string.Format("{0}.EndsWith(\"{1}\")", args.SearchColumn, args.SearchString);
			case SearchOperation.DoesNotEndWith:
				return string.Format("!{0}.EndsWith(\"{1}\")", args.SearchColumn, args.SearchString);
			case SearchOperation.Contains:
				return string.Format("{0}.Contains(\"{1}\")", args.SearchColumn, args.SearchString);
			case SearchOperation.DoesNotContain:
				return string.Format("!{0}.Contains(\"{1}\")", args.SearchColumn, args.SearchString);
			}
			throw new Exception("Invalid search operation.");
		}
		private static SearchOperation GetSearchOperationFromString(string searchOperation)
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
				return SearchOperation.DoesNotEndWith;
			case "ew":
				return SearchOperation.EndsWith;
			case "en":
				return SearchOperation.DoesNotEndWith;
			case "cn":
				return SearchOperation.Contains;
			case "nc":
				return SearchOperation.DoesNotContain;
			}
			throw new Exception("Search operation not known: " + searchOperation);
		}
	}
}
