using System;
using System.Collections;
namespace Trirand.Web.UI.WebControls
{
	public static class PublicListExtensions
	{
		public static ChartPointCollection FromCollection(this ChartPointCollection points, ICollection collection)
		{
			ChartPointCollection chartPointCollection = new ChartPointCollection();
			foreach (object current in collection)
			{
				double? x;
				if (current == null)
				{
					x = null;
				}
				else
				{
					x = new double?(Convert.ToDouble(current));
				}
				chartPointCollection.Add(new ChartPoint(x));
			}
			return chartPointCollection;
		}
	}
}
