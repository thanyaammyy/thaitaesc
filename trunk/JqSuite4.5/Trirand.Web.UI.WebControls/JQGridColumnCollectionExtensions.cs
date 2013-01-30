using System;
using System.Collections.Generic;
namespace Trirand.Web.UI.WebControls
{
	internal static class JQGridColumnCollectionExtensions
	{
		internal static List<JQGridColumn> AsList(this JQGridColumnCollection collection)
		{
			List<JQGridColumn> list = new List<JQGridColumn>();
			foreach (JQGridColumn item in collection)
			{
				list.Add(item);
			}
			return list;
		}
	}
}
