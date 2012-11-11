using System.Collections.Generic;
using System.Linq;

namespace thaitae.lib.Page
{
    public static class FAMatchHelper
    {
        public static IEnumerable<FAMatch> SelectItems()
        {
            var dc = ThaitaeDataDataContext.Create();
            return dc.FAMatches.OrderByDescending(item => item.FAMatchId).ToList();
        }
    }
}