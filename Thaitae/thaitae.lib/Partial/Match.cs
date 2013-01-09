using System.Linq;

namespace thaitae.lib
{
    public partial class Match
    {
        public string TeamHomeIdNameExtend
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamName = dc.Teams.Single(item => item.TeamId == TeamHomeId);
                    var teamMatchEdited = dc.TeamMatches.Single(item => item.TeamId == TeamHomeId && item.MatchId == MatchId).TeamEdited;
                    string teamAdded = "";
                    if (teamMatchEdited == 1)
                    {
                        teamAdded = "<span style='color: red'>[ใส่ผลแล้ว]</span>";
                    }
                    return teamName.TeamName + teamAdded;
                }
            }
        }

        public string TeamAwayIdNameExtend
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamName = dc.Teams.Single(item => item.TeamId == TeamAwayId);
                    var teamMatchEdited = dc.TeamMatches.Single(item => item.TeamId == TeamAwayId && item.MatchId == MatchId).TeamEdited;
                    string teamAdded = "";
                    if (teamMatchEdited == 1)
                    {
                        teamAdded = "<span style='color: red'>[ใส่ผลแล้ว]</span>";
                    }
                    return teamName.TeamName + teamAdded;
                }
            }
        }

        public string TeamHomeIdName
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamName = dc.Teams.Single(item => item.TeamId == TeamHomeId);
                    return teamName.TeamName;
                }
            }
        }

        public string TeamAwayIdName
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamName = dc.Teams.Single(item => item.TeamId == TeamAwayId);
                    return teamName.TeamName;
                }
            }
        }

        public int TeamHomeScore
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var team = dc.TeamMatches.Single(item => item.TeamId == TeamHomeId && item.MatchId == MatchId);
                    return team.TeamGoalFor ?? 0;
                }
            }
        }

        public int TeamHomePScore
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var team = dc.TeamMatches.Single(item => item.TeamId == TeamHomeId && item.MatchId == MatchId);
                    return team.TeamGoalPenalty ?? 0;
                }
            }
        }

        public int TeamAwayScore
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var team = dc.TeamMatches.Single(item => item.TeamId == TeamAwayId && item.MatchId == MatchId);
                    return team.TeamGoalFor ?? 0;
                }
            }
        }

        public int TeamAwayPScore
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var team = dc.TeamMatches.Single(item => item.TeamId == TeamAwayId && item.MatchId == MatchId);
                    return team.TeamGoalPenalty ?? 0;
                }
            }
        }

        public string Dash
        {
            get { return " - "; }
        }

        public string MatchScore
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamAwayGoal = dc.TeamMatches.Single(item => item.TeamId == TeamAwayId && item.MatchId == MatchId).TeamGoalFor;
                    var teamHomeGaol = dc.TeamMatches.Single(item => item.TeamId == TeamHomeId && item.MatchId == MatchId).TeamGoalFor;
                    return teamHomeGaol + " - " + teamAwayGoal;
                }
            }
        }
    }
}