using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib
{
    public partial class TeamMatch
    {
        partial void OnCreated()
        {
            TeamGoalAgainst = 0;
            TeamGoalFor = 0;
            TeamRedCard = 0;
            TeamYellowCard = 0;
            TeamStatus = 0;
            TeamEdited = 0;
        }
    }
}