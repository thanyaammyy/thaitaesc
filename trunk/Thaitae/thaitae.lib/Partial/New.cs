using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib
{
    public partial class New
    {
        partial void OnCreated()
        {
            newsTopic = "";
            newsContent = "";
        }

        public string NewsTypeName
        {
            get
            {
                if (newsType == 1)
                {
                    return "Hot News";
                }
                return "Scoop";
            }
        }
    }
}