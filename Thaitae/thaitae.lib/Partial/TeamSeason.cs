using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib
{
    public partial class TeamSeason
    {
        partial void OnCreated()
        {
            TeamDrew = 0;
            TeamGoalAgainst = 0;
            TeamGoalDiff = 0;
            TeamGoalFor = 0;
            TeamLoss = 0;
            TeamMatchPlayed = 0;
            TeamPts = 0;
            TeamWon = 0;
        }
    }
}