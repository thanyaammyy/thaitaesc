using System;
using System.Web.Script.Serialization;
namespace Trirand.Web.UI.WebControls
{
	internal static class StringExtensions
	{
		internal static string RemoveQuotes(this string buffer, string expression)
		{
			new JavaScriptSerializer();
			return buffer.Replace("\\\"" + expression + "\\\"", expression);
		}
	}
}
