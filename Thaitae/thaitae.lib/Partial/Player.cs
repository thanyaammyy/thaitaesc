﻿using System.Linq;

namespace thaitae.lib
{
    public partial class Player
    {
        partial void OnCreated()
        {
            PlayerName = "unknown";
            PlayerGoal = 0;
            PlayerRedCard = 0;
            PlayerYellowCard = 0;
        }

        public string PlayerTeamIdName
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamName = dc.Teams.SingleOrDefault(item => item.TeamId == TeamId);
                    if (teamName != null) return teamName.TeamName;
                    return "Not Found";
                }
            }
        }
    }
}