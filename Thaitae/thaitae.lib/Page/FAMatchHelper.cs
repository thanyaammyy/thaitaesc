using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib.Page
{
    public static class FAMatchHelper
    {
        public static IEnumerable<FAMatch> SelectItems()
        {
            var dc = new ThaitaeDataDataContext();
            return dc.FAMatches.OrderByDescending(item => item.FAMatchId).ToList();
        }
    }
}