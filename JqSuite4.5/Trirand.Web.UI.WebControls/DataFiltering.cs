using System;
namespace Trirand.Web.UI.WebControls
{
	internal class DataFiltering
	{
		internal string GetFilterExpression(SearchOperation searchOperation, string dataField, string searchString, Type dataType)
		{
			searchString = searchString.Replace("'", "''");
			string format = this.ExpressionNeedsQuotes(dataType) ? "[{0}] {1} '{2}'" : "[{0}] {1} {2}";
			string format2 = "[{0}] {1} ({2})";
			string format3 = "[{0}] LIKE '{1}'";
			string format4 = "[{0}] NOT LIKE '{1}'";
			switch (searchOperation)
			{
			case SearchOperation.IsEqualTo:
				return string.Format(format, dataField, "=", searchString);
			case SearchOperation.IsNotEqualTo:
				return string.Format(format, dataField, "<>", searchString);
			case SearchOperation.IsLessThan:
				return string.Format(format, dataField, "<", searchString);
			case SearchOperation.IsLessOrEqualTo:
				return string.Format(format, dataField, "<=", searchString);
			case SearchOperation.IsGreaterThan:
				return string.Format(format, dataField, ">", searchString);
			case SearchOperation.IsGreaterOrEqualTo:
				return string.Format(format, dataField, ">=", searchString);
			case SearchOperation.IsIn:
				return string.Format(format2, dataField, "in", searchString);
			case SearchOperation.IsNotIn:
				return string.Format(format2, dataField, "not in", searchString);
			case SearchOperation.BeginsWith:
				return string.Format(format3, dataField, searchString + "%");
			case SearchOperation.DoesNotBeginWith:
				return string.Format(format4, dataField, searchString + "%");
			case SearchOperation.EndsWith:
				return string.Format(format3, dataField, "%" + searchString);
			case SearchOperation.DoesNotEndWith:
				return string.Format(format4, dataField, "%" + searchString);
			case SearchOperation.Contains:
				return string.Format(format3, dataField, "%" + searchString + "%");
			case SearchOperation.DoesNotContain:
				return string.Format(format4, dataField, "%" + searchString + "%");
			default:
				throw new Exception("Invalid search operation.");
			}
		}
		internal string GetLinqFilterExpression(SearchOperation searchOperation, string dataField, string searchString, Type dataType)
		{
			string format = this.ExpressionNeedsQuotes(dataType) ? "{0} {1} \"{2}\"" : "{0} {1} {2}";
			if (dataType == typeof(DateTime))
			{
				format = "{0} {1} DateTime.Parse(\"{2}\")";
			}
			switch (searchOperation)
			{
			case SearchOperation.IsEqualTo:
				return string.Format(format, dataField, "=", searchString);
			case SearchOperation.IsNotEqualTo:
				return string.Format(format, dataField, "<>", searchString);
			case SearchOperation.IsLessThan:
				return string.Format(format, dataField, "<", searchString);
			case SearchOperation.IsLessOrEqualTo:
				return string.Format(format, dataField, "<=", searchString);
			case SearchOperation.IsGreaterThan:
				return string.Format(format, dataField, ">", searchString);
			case SearchOperation.IsGreaterOrEqualTo:
				return string.Format(format, dataField, ">=", searchString);
			case SearchOperation.BeginsWith:
				return string.Format("{0}.BeginsWith(\"{1}\")", dataField, searchString);
			case SearchOperation.DoesNotBeginWith:
				return string.Format("!{0}.BeginsWith(\"{1}\")", dataField, searchString);
			case SearchOperation.EndsWith:
				return string.Format("{0}.EndsWith(\"{1}\")", dataField, searchString);
			case SearchOperation.DoesNotEndWith:
				return string.Format("!{0}.EndsWith(\"{1}\")", dataField, searchString);
			case SearchOperation.Contains:
				return string.Format("{0}.Contains(\"{1}\")", dataField, searchString);
			case SearchOperation.DoesNotContain:
				return string.Format("!{0}.Contains(\"{1}\")", dataField, searchString);
			}
			throw new Exception("Invalid search operation.");
		}
		private bool ExpressionNeedsQuotes(Type t)
		{
			return t == typeof(string) || t == typeof(DateTime);
		}
	}
}
