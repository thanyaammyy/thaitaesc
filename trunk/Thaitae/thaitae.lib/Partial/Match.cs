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

        private string _TeamHomeNameWithStatus;

        public string TeamHomeNameWithStatus
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamName = dc.Teams.Single(item => item.TeamId == TeamHomeId);
                    var mirrorMatchId =
                        dc.Matches.Single(
                            item =>
                            item.TeamHomeId == TeamAwayId && item.TeamAwayId == TeamHomeId && item.SeasonId == SeasonId).MatchId;
                    var teamMatchHomeEdited =
                        dc.TeamMatches.Where(item => item.TeamId == TeamHomeId && (item.MatchId == MatchId || item.MatchId == mirrorMatchId) && item.TeamEdited == 1).ToArray();
                    string teamStatus = "";
                    if (teamMatchHomeEdited.Length == 2)
                    {
                        if (teamMatchHomeEdited[1].TeamStatus == 1)
                            teamStatus = "<span style='color: red'>[เข้ารอบ]</span>";
                    }
                    return teamName.TeamName + teamStatus;
                }
            }
        }

        public string TeamAwayNameWithStatus
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamName = dc.Teams.Single(item => item.TeamId == TeamAwayId);
                    var mirrorMatchId =
                        dc.Matches.Single(
                            item =>
                            item.TeamHomeId == TeamAwayId && item.TeamAwayId == TeamHomeId && item.SeasonId == SeasonId).MatchId;
                    var teamMatchAwayEdited =
                        dc.TeamMatches.Where(item => item.TeamId == TeamAwayId && (item.MatchId == MatchId || item.MatchId == mirrorMatchId) && item.TeamEdited == 1).ToArray();
                    string teamStatus = "";
                    if (teamMatchAwayEdited.Length == 2)
                    {
                        if (teamMatchAwayEdited[0].TeamStatus == 1)
                            teamStatus = "<span style='color: red'>[เข้ารอบ]</span>";
                    }
                    return teamName.TeamName + teamStatus;
                }
            }
        }

        public string TeamHomeScore1
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamHome = dc.TeamMatches.Single(item => item.TeamId == TeamHomeId && item.MatchId == MatchId);
                    return teamHome.TeamEdited == 1 ? teamHome.TeamGoalFor.ToString() : "-";
                }
            }
        }

        public string TeamAwayScore1
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var teamHome = dc.TeamMatches.Single(item => item.TeamId == TeamAwayId && item.MatchId == MatchId);
                    return teamHome.TeamEdited == 1 ? teamHome.TeamGoalFor.ToString() : "-";
                }
            }
        }

        public string TeamHomeScore2
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var mirrorMatchId =
                        dc.Matches.Single(
                            item =>
                            item.TeamHomeId == TeamAwayId && item.TeamAwayId == TeamHomeId && item.SeasonId == SeasonId)
                          .MatchId;
                    var teamHome = dc.TeamMatches.Single(item => item.TeamId == TeamHomeId && item.MatchId == mirrorMatchId);
                    var pWin = (teamHome.TeamGoalPenalty != 0 && teamHome.TeamStatus == 1) ? "<span style='color: red'>[P]</span>" : "";
                    return teamHome.TeamEdited == 1 ? teamHome.TeamGoalFor.ToString() + pWin : "-";
                }
            }
        }

        public string TeamAwayScore2
        {
            get
            {
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var mirrorMatchId =
                        dc.Matches.Single(
                            item =>
                            item.TeamHomeId == TeamAwayId && item.TeamAwayId == TeamHomeId && item.SeasonId == SeasonId)
                          .MatchId;
                    var teamHome = dc.TeamMatches.Single(item => item.TeamId == TeamAwayId && item.MatchId == mirrorMatchId);
                    var pWin = (teamHome.TeamGoalPenalty != 0 && teamHome.TeamStatus == 1) ? "<span style='color: red'>[P]</span>" : "";
                    return teamHome.TeamEdited == 1 ? teamHome.TeamGoalFor.ToString() + pWin : "-";
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