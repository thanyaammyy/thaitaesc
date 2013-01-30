using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
namespace Trirand.Web.UI.WebControls
{
	internal static class IEnumerableExtensions
	{
		public static List<string> ToListOfString(this IEnumerable en, JQAutoComplete autoComplete)
		{
			DataTable dataTable = en.ToDataTable(autoComplete);
			List<string> list = new List<string>();
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				DataRow row;
				while (enumerator.MoveNext())
				{
					row = (DataRow)enumerator.Current;
					if (string.IsNullOrEmpty(list.Find((string s) => s == row[autoComplete.DataTextField].ToString())))
					{
						list.Add(row[autoComplete.DataTextField].ToString());
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return list;
		}
		public static DataTable ToDataTable(this IEnumerable en, JQAutoComplete autoComplete)
		{
			return en.ToDataTable(new JQGrid
			{
				Columns = 
				{
					new JQGridColumn
					{
						DataField = autoComplete.DataTextField
					}
				}
			});
		}
		public static DataTable ToDataTable(this IEnumerable en, JQGrid grid)
		{
			DataTable result = new DataTable();
			DataView dataView = en as DataView;
			if (dataView != null)
			{
				result = dataView.ToTable();
			}
			else
			{
				if (en != null)
				{
					result = IEnumerableExtensions.ObtainDataTableFromIEnumerable(en, grid);
				}
			}
			return result;
		}
		private static DataTable ObtainDataTableFromIEnumerable(IEnumerable ien, JQGrid grid)
		{
			DataTable dataTable = new DataTable();
			foreach (object current in ien)
			{
				if (current is DbDataRecord)
				{
					DbDataRecord dbDataRecord = current as DbDataRecord;
					if (dataTable.Columns.Count == 0)
					{
						foreach (JQGridColumn jQGridColumn in grid.Columns)
						{
							dataTable.Columns.Add(jQGridColumn.DataField);
						}
					}
					DataRow dataRow = dataTable.NewRow();
					foreach (JQGridColumn jQGridColumn2 in grid.Columns)
					{
						dataRow[jQGridColumn2.DataField] = dbDataRecord[jQGridColumn2.DataField];
					}
					dataTable.Rows.Add(dataRow);
				}
				else
				{
					if (current is DataRow)
					{
						DataRow dataRow2 = current as DataRow;
						if (dataTable.Columns.Count == 0)
						{
							foreach (JQGridColumn jQGridColumn3 in grid.Columns)
							{
								dataTable.Columns.Add(jQGridColumn3.DataField);
							}
						}
						DataRow dataRow3 = dataTable.NewRow();
						foreach (JQGridColumn jQGridColumn4 in grid.Columns)
						{
							dataRow3[jQGridColumn4.DataField] = dataRow2[jQGridColumn4.DataField];
						}
						dataTable.Rows.Add(dataRow3);
					}
					else
					{
						Type type = current.GetType();
						PropertyInfo[] properties = type.GetProperties();
						if (dataTable.Columns.Count == 0)
						{
							PropertyInfo[] array = properties;
							for (int i = 0; i < array.Length; i++)
							{
								PropertyInfo propertyInfo = array[i];
								Type type2 = propertyInfo.PropertyType;
								if (type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(Nullable<>))
								{
									type2 = Nullable.GetUnderlyingType(type2);
								}
								dataTable.Columns.Add(propertyInfo.Name, type2);
							}
						}
						DataRow dataRow4 = dataTable.NewRow();
						PropertyInfo[] array2 = properties;
						for (int j = 0; j < array2.Length; j++)
						{
							PropertyInfo propertyInfo2 = array2[j];
							object value = propertyInfo2.GetValue(current, null);
							if (value != null)
							{
								dataRow4[propertyInfo2.Name] = value;
							}
							else
							{
								dataRow4[propertyInfo2.Name] = DBNull.Value;
							}
						}
						dataTable.Rows.Add(dataRow4);
					}
				}
			}
			return dataTable;
		}
	}
}
