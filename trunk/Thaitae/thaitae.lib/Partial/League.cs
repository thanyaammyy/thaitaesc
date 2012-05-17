using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib
{
    public partial class League
    {
        partial void OnCreated()
        {
            LeagueName = "";
            LeagueDesc = "";
            Active = 1;
        }
        public string LeagueTypeName
        {
            get
            {
                if(LeagueType == 4)
                {
                    return "Normal League";
                }
                else if (LeagueType == 8)
                {
                    return "Champion League";
                }
                else if (LeagueType == 12)
                {
                    return "FA Cup";
                }
                else
                {
                    return "Custom League";
                }
            }
        }
        public string ActiveName
        {
            get
            {
                if (Active == 1)
                {
                    return "Active";
                }
                else
                {
                    return "Inactive";
                }
            }
        }
    }
}
