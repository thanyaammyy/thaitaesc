﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib
{
    public partial class FAMatch
    {
        partial void OnCreated()
        {
            FAMatchDate = DateTime.Now;
            TeamHomeName = "";
            TeamAwayName = "";
            TeamHomeScore = 0;
            TeamAwayScore = 0;
            HasResult = 0;
            TeamWin = "";
        }

        public string Dash
        {
            get
            {
                return "-";
            }
        }
    }
}