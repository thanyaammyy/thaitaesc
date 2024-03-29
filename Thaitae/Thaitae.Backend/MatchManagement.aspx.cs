﻿using System;
using System.Collections.Generic;
using System.Linq;
using thaitae.lib;
using thaitae.lib.Helper;
using thaitae.lib.Page;
using Trirand.Web.UI.WebControls;

namespace Thaitae.Backend
{
    public partial class MatchManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["seasonid"] != null && Session["leagueid"] != null)
                {
                    if ((string)Session["leagueid"] != "14" && (string)Session["leagueid"] != "31")
                    {
                        ddlLeague.SelectedValue = (string)Session["leagueid"];
                        ddlSeason.SelectedValue = (string)Session["seasonid"];
                        JqgridMatchBinding(Convert.ToInt32(Session["seasonid"]));
                    }
                }
            }
        }

        protected void ddlLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeague.SelectedValue == "") return;
            Session["leagueid"] = ddlLeague.SelectedValue;
            Session.Remove("seasonid");
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSeason.SelectedValue == "") return;
            Session["seasonid"] = ddlSeason.SelectedValue;
        }

        protected void JqgridMatch1_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var match = dc.Matches.Single(item => item.MatchId == Convert.ToInt32(e.RowKey));
                match.MatchDate = Convert.ToDateTime(e.RowData["MatchDate"]);
                dc.SubmitChanges();
            }
        }

        private void JqgridMatchBinding(int seasonId)
        {
            var dc = ThaitaeDataDataContext.Create().Matches;
            var matchSeasonList = dc.Where(item => item.SeasonId == seasonId).ToList();
            JqgridMatch1.DataSource = matchSeasonList;
            JqgridMatch1.DataBind();
        }

        protected void JqgridAwayTeam_DataRequesting(object sender, JQGridDataRequestEventArgs e)
        {
            var teamAwayMatchList = ThaitaeDataDataContext.Create().TeamMatches.Where(item => item.MatchId == Convert.ToInt32(e.ParentRowKey) && item.TeamHome == 0).ToList();
            JqgridAwayTeam.DataSource = teamAwayMatchList;
            JqgridAwayTeam.DataBind();
        }

        protected void JqgridHomeTeam_DataRequesting(object sender, JQGridDataRequestEventArgs e)
        {
            var teamHomeMatchList = ThaitaeDataDataContext.Create().TeamMatches.Where(item => item.MatchId == Convert.ToInt32(e.ParentRowKey) && item.TeamHome == 1).ToList();
            JqgridHomeTeam.DataSource = teamHomeMatchList;
            JqgridHomeTeam.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["seasonid"] == null) return;
            if (Convert.ToInt32(Session["seasonid"]) == 0) return;
            GenerateMatch(Convert.ToInt32(Session["seasonid"]));
        }

        public void GenerateMatch(int seasonId)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var isChampionLeagueFinal = dc.Leagues.Any(item => item.LeagueId == Convert.ToInt32(Session["leagueid"]) && (item.LeagueType == 1 || item.LeagueType == 2));
                if (!isChampionLeagueFinal)
                {
                    var teamSeasonList =
                        dc.TeamSeasons.Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId,
                                            (teamSeason, team) => new { teamSeason.SeasonId, team.TeamId })
                          .Where(teamSeason => teamSeason.SeasonId == seasonId)
                          .ToList();
                    for (var i = 0; i < teamSeasonList.Count; i++)
                    {
                        for (var j = 0; j < teamSeasonList.Count; j++)
                        {
                            if (teamSeasonList[i].TeamId != teamSeasonList[j].TeamId)
                            {
                                Match match = null;
                                var matchExist = dc.Matches.Count(
                                    item =>
                                    item.SeasonId == seasonId && item.TeamHomeId == teamSeasonList[i].TeamId &&
                                    item.TeamAwayId == teamSeasonList[j].TeamId);
                                if (matchExist == 0)
                                {
                                    match = new Match
                                        {
                                            SeasonId = seasonId,
                                            MatchDate = DateTime.Now,
                                            TeamHomeId = teamSeasonList[i].TeamId,
                                            TeamAwayId = teamSeasonList[j].TeamId
                                        };
                                    dc.Matches.InsertOnSubmit(match);
                                    dc.SubmitChanges();
                                }
                                else
                                {
                                    match = dc.Matches.Single(
                                        item =>
                                        item.SeasonId == seasonId && item.TeamHomeId == teamSeasonList[i].TeamId &&
                                        item.TeamAwayId == teamSeasonList[j].TeamId);
                                }
                                var teamHomeExist =
                                    dc.TeamMatches.Count(
                                        item => item.MatchId == match.MatchId && item.TeamId == match.TeamHomeId);
                                if (teamHomeExist == 0)
                                {
                                    var teamHomeMatch = new TeamMatch
                                        {
                                            MatchId = match.MatchId,
                                            TeamId = match.TeamHomeId,
                                            TeamHome = 1,
                                            SeasonId = match.SeasonId
                                        };
                                    dc.TeamMatches.InsertOnSubmit(teamHomeMatch);
                                    dc.SubmitChanges();
                                }
                                var teamAwayExist =
                                    dc.TeamMatches.Count(
                                        item => item.MatchId == match.MatchId && item.TeamId == match.TeamAwayId);
                                if (teamAwayExist == 0)
                                {
                                    var teamAwayMatch = new TeamMatch
                                        {
                                            MatchId = match.MatchId,
                                            TeamId = match.TeamAwayId,
                                            TeamHome = 0,
                                            SeasonId = match.SeasonId
                                        };
                                    dc.TeamMatches.InsertOnSubmit(teamAwayMatch);
                                    dc.SubmitChanges();
                                }
                            }
                        }
                    }
                }
                else
                {
                    var isFinished = SeasonHelper.CheckGroupSeasonIsFinnish(seasonId);
                }
            }
        }

        protected void JqgridMatch1_Searching(object sender, JQGridSearchEventArgs e)
        {
            if (e.SearchString == "[All]")
                e.Cancel = true;
        }

        protected void JqgridHomePlayer_DataRequesting(object sender, JQGridDataRequestEventArgs e)
        {
            List<PlayerMatch> playerTeamList;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                int teamMatchid = Convert.ToInt32(e.ParentRowKey);
                var team = dc.TeamMatches.Single(item => item.TeamMatchId == teamMatchid);
                playerTeamList = ThaitaeDataDataContext.Create().PlayerMatches.Where(
                        item => item.TeamId == team.TeamId && item.MatchId == team.MatchId && item.SeasonId == team.SeasonId).ToList();
            }
            JqgridHomePlayer.DataSource = playerTeamList;
            JqgridHomePlayer.DataBind();
        }

        protected void JqgridAwayPlayer_DataRequesting(object sender, JQGridDataRequestEventArgs e)
        {
            List<PlayerMatch> playerTeamList;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                int teamMatchid = Convert.ToInt32(e.ParentRowKey);
                var team = dc.TeamMatches.Single(item => item.TeamMatchId == teamMatchid);
                playerTeamList = ThaitaeDataDataContext.Create().PlayerMatches.Where(
                        item => item.TeamId == team.TeamId && item.MatchId == team.MatchId && item.SeasonId == team.SeasonId).ToList();
            }
            JqgridAwayPlayer.DataSource = playerTeamList;
            JqgridAwayPlayer.DataBind();
        }

        protected void JqgridHomeTeam_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var team = dc.TeamMatches.Single(item => item.TeamMatchId == Convert.ToInt32(e.RowKey));
                team.TeamGoalFor = Convert.ToInt32(e.RowData["TeamGoalFor"]);
                team.TeamRedCard = Convert.ToInt32(e.RowData["TeamRedCard"]);
                team.TeamYellowCard = Convert.ToInt32(e.RowData["TeamYellowCard"]);
                if (team.TeamGoalFor == -1 && team.TeamRedCard == -1 && team.TeamYellowCard == -1)
                {
                    team.TeamEdited = 0;
                    team.TeamStatus = 0;
                    team.TeamGoalAgainst = 0;
                    team.TeamGoalFor = 0;
                    team.TeamRedCard = 0;
                    team.TeamYellowCard = 0;
                }
                else
                {
                    team.TeamEdited = 1;
                    var teamAgainst = dc.TeamMatches.Single(item => item.MatchId == Convert.ToInt32(e.ParentRowKey) && item.TeamHome == 0);
                    teamAgainst.TeamGoalAgainst = Convert.ToInt32(e.RowData["TeamGoalFor"]);
                    if (teamAgainst.TeamEdited == 1)
                    {
                        if (team.TeamGoalFor < teamAgainst.TeamGoalFor)
                        {
                            team.TeamStatus = 3;
                            teamAgainst.TeamStatus = 1;
                        }
                        else if (team.TeamGoalFor > teamAgainst.TeamGoalFor)
                        {
                            team.TeamStatus = 1;
                            teamAgainst.TeamStatus = 3;
                        }
                        else
                        {
                            team.TeamStatus = 2;
                            teamAgainst.TeamStatus = 2;
                        }
                        dc.SubmitChanges();
                        CalculateTeamResult(team, teamAgainst, Convert.ToInt32(Session["seasonid"]));
                    }
                }
                dc.SubmitChanges();
                var removePlayerList =
                dc.PlayerMatches.Where(item => item.TeamId == team.TeamId && item.MatchId == team.MatchId && item.SeasonId == team.SeasonId);
                dc.PlayerMatches.DeleteAllOnSubmit(removePlayerList);
                dc.SubmitChanges();
                for (int i = 0; i < team.TeamGoalFor; i++)
                {
                    var player = new PlayerMatch { PlayerGoal = 1, TeamId = team.TeamId, MatchId = team.MatchId, SeasonId = team.SeasonId };
                    dc.PlayerMatches.InsertOnSubmit(player);
                    dc.SubmitChanges();
                }
                for (int i = 0; i < team.TeamRedCard; i++)
                {
                    var player = new PlayerMatch { PlayerRedCard = 1, TeamId = team.TeamId, MatchId = team.MatchId, SeasonId = team.SeasonId };
                    dc.PlayerMatches.InsertOnSubmit(player);
                    dc.SubmitChanges();
                }
                for (int i = 0; i < team.TeamYellowCard; i++)
                {
                    var player = new PlayerMatch { PlayerYellowCard = 1, TeamId = team.TeamId, MatchId = team.MatchId, SeasonId = team.SeasonId };
                    dc.PlayerMatches.InsertOnSubmit(player);
                    dc.SubmitChanges();
                }
            }
        }

        protected void JqgridAwayTeam_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var team = dc.TeamMatches.Single(item => item.TeamMatchId == Convert.ToInt32(e.RowKey));
                team.TeamGoalFor = Convert.ToInt32(e.RowData["TeamGoalFor"]);
                team.TeamRedCard = Convert.ToInt32(e.RowData["TeamRedCard"]);
                team.TeamYellowCard = Convert.ToInt32(e.RowData["TeamYellowCard"]);
                if (team.TeamGoalFor == -1 && team.TeamRedCard == -1 && team.TeamYellowCard == -1)
                {
                    team.TeamEdited = 0;
                    team.TeamStatus = 0;
                    team.TeamGoalAgainst = 0;
                    team.TeamGoalFor = 0;
                    team.TeamRedCard = 0;
                    team.TeamYellowCard = 0;
                }
                else
                {
                    team.TeamEdited = 1;
                    var teamAgainst = dc.TeamMatches.Single(item => item.MatchId == Convert.ToInt32(e.ParentRowKey) && item.TeamHome == 1);
                    teamAgainst.TeamGoalAgainst = Convert.ToInt32(e.RowData["TeamGoalFor"]);
                    if (teamAgainst.TeamEdited == 1)
                    {
                        if (team.TeamGoalFor < teamAgainst.TeamGoalFor)
                        {
                            team.TeamStatus = 3;
                            teamAgainst.TeamStatus = 1;
                        }
                        else if (team.TeamGoalFor > teamAgainst.TeamGoalFor)
                        {
                            team.TeamStatus = 1;
                            teamAgainst.TeamStatus = 3;
                        }
                        else
                        {
                            team.TeamStatus = 2;
                            teamAgainst.TeamStatus = 2;
                        }
                        dc.SubmitChanges();
                        CalculateTeamResult(team, teamAgainst, Convert.ToInt32(Session["seasonid"]));
                    }
                }
                dc.SubmitChanges();
                var removePlayerList =
                    dc.PlayerMatches.Where(item => item.TeamId == team.TeamId && item.MatchId == team.MatchId && item.SeasonId == team.SeasonId);
                dc.PlayerMatches.DeleteAllOnSubmit(removePlayerList);
                dc.SubmitChanges();
                for (int i = 0; i < team.TeamGoalFor; i++)
                {
                    var player = new PlayerMatch { PlayerGoal = 1, TeamId = team.TeamId, MatchId = team.MatchId, SeasonId = team.SeasonId };
                    dc.PlayerMatches.InsertOnSubmit(player);
                    dc.SubmitChanges();
                }
                for (int i = 0; i < team.TeamRedCard; i++)
                {
                    var player = new PlayerMatch { PlayerRedCard = 1, TeamId = team.TeamId, MatchId = team.MatchId, SeasonId = team.SeasonId };
                    dc.PlayerMatches.InsertOnSubmit(player);
                    dc.SubmitChanges();
                }
                for (int i = 0; i < team.TeamYellowCard; i++)
                {
                    var player = new PlayerMatch { PlayerYellowCard = 1, TeamId = team.TeamId, MatchId = team.MatchId, SeasonId = team.SeasonId };
                    dc.PlayerMatches.InsertOnSubmit(player);
                    dc.SubmitChanges();
                }
            }
        }

        protected void JqgridAwayPlayer_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            var playerMatchId = Convert.ToInt32(e.RowKey);
            var playerNumber = Convert.ToInt32(e.RowData["PlayerNumber"]);
            var playerName = e.RowData["PlayerName"];
            var player = CalculatePlayerMatch(playerMatchId, playerNumber, playerName);
            CalculatePlayerResult(player);
        }

        protected void JqgridHomePlayer_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            var playerMatchId = Convert.ToInt32(e.RowKey);
            var playerNumber = Convert.ToInt32(e.RowData["PlayerNumber"]);
            var playerName = e.RowData["PlayerName"];
            var player = CalculatePlayerMatch(playerMatchId, playerNumber, playerName);
            CalculatePlayerResult(player);
        }

        public Player CalculatePlayerMatch(int playerMatchId, int playerNumber, string playerName)
        {
            Player playerUpdate;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var playerMatch = dc.PlayerMatches.Single(item => item.PlayerMatchId == playerMatchId);
                var playerCheck =
                    dc.Players.Count(
                        item =>
                        item.SeasonId == playerMatch.SeasonId && item.TeamId == playerMatch.TeamId &&
                        item.PlayerNumber == playerNumber);
                if (playerCheck == 0)
                {
                    var player = new Player
                    {
                        PlayerNumber = playerNumber,
                        PlayerName = playerName,
                        TeamId = playerMatch.TeamId,
                        SeasonId = playerMatch.SeasonId
                    };
                    dc.Players.InsertOnSubmit(player);
                    dc.SubmitChanges();
                    playerMatch.PlayerId = player.PlayerId;
                    dc.SubmitChanges();
                    playerUpdate = player;
                }
                else
                {
                    var player =
                    dc.Players.Single(
                        item =>
                        item.SeasonId == playerMatch.SeasonId && item.TeamId == playerMatch.TeamId &&
                        item.PlayerNumber == playerNumber);
                    playerMatch.PlayerId = player.PlayerId;
                    playerMatch.PlayerId = player.PlayerId;
                    if (!string.IsNullOrEmpty(playerName))
                    {
                        player.PlayerName = playerName;
                    }
                    dc.SubmitChanges();
                    playerUpdate = player;
                }
            }
            return playerUpdate;
        }

        public void CalculateTeamResult(TeamMatch team, TeamMatch teamAgainst, int seasonId)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var teamUpdate = dc.TeamSeasons.Single(item => item.TeamId == team.TeamId && item.SeasonId == seasonId);
                teamUpdate.TeamMatchPlayed = dc.TeamMatches.Count(item => item.TeamId == team.TeamId && item.TeamStatus != 0);
                teamUpdate.TeamDrew = dc.TeamMatches.Count(item => item.TeamId == team.TeamId && item.TeamStatus == 2);
                var teamgoalAgainstSum =
                    dc.TeamMatches.Where(item => item.TeamId == team.TeamId && item.SeasonId == seasonId && item.TeamStatus != 0).Sum(
                        item => item.TeamGoalAgainst);
                if (teamgoalAgainstSum != null)
                    teamUpdate.TeamGoalAgainst = (int)teamgoalAgainstSum;

                var teamgoalForSum =
                    dc.TeamMatches.Where(item => item.TeamId == team.TeamId && item.SeasonId == seasonId && item.TeamStatus != 0).Sum(
                        item => item.TeamGoalFor);
                if (teamgoalForSum != null)
                    teamUpdate.TeamGoalFor = (int)teamgoalForSum;
                teamUpdate.TeamGoalDiff = teamUpdate.TeamGoalFor - teamUpdate.TeamGoalAgainst;
                teamUpdate.TeamLoss = dc.TeamMatches.Count(item => item.TeamId == team.TeamId && item.SeasonId == seasonId && item.TeamStatus == 3);
                teamUpdate.TeamWon = dc.TeamMatches.Count(item => item.TeamId == team.TeamId && item.SeasonId == seasonId && item.TeamStatus == 1);
                teamUpdate.TeamPts = (teamUpdate.TeamWon * 3) + (teamUpdate.TeamDrew);

                var teamUpdateYellowCard = 0;
                var teamUpdateRedCard = 0;
                var playersUpdate = dc.Players.Where(item => item.TeamId == teamUpdate.TeamId && item.SeasonId == teamUpdate.SeasonId);
                if (playersUpdate.Count() != 0)
                {
                    teamUpdateYellowCard = playersUpdate.Sum(item => item.PlayerYellowCard);
                    teamUpdateRedCard = playersUpdate.Sum(item => item.PlayerRedCard);
                }

                teamUpdate.TeamYellowCard = teamUpdateYellowCard;
                teamUpdate.TeamRedCard = teamUpdateRedCard;
                var teamAgainstUpdate = dc.TeamSeasons.Single(item => item.TeamId == teamAgainst.TeamId && item.SeasonId == seasonId);
                teamAgainstUpdate.TeamMatchPlayed = dc.TeamMatches.Count(item => item.TeamId == teamAgainst.TeamId && item.SeasonId == seasonId && item.TeamStatus != 0);
                teamAgainstUpdate.TeamDrew = dc.TeamMatches.Count(item => item.TeamId == teamAgainst.TeamId && item.SeasonId == seasonId && item.TeamStatus == 2);
                var teamAgainstgoalAgainstSum =
                    dc.TeamMatches.Where(item => item.TeamId == teamAgainst.TeamId && item.SeasonId == seasonId && item.TeamStatus != 0).Sum(
                        item => item.TeamGoalAgainst);
                if (teamAgainstgoalAgainstSum != null)
                    teamAgainstUpdate.TeamGoalAgainst = (int)teamAgainstgoalAgainstSum;

                var teamAgainstgoalForSum =
                    dc.TeamMatches.Where(item => item.TeamId == teamAgainst.TeamId && item.SeasonId == seasonId && item.TeamStatus != 0).Sum(
                        item => item.TeamGoalFor);
                if (teamAgainstgoalForSum != null)
                    teamAgainstUpdate.TeamGoalFor = (int)teamAgainstgoalForSum;
                teamAgainstUpdate.TeamGoalDiff = teamAgainstUpdate.TeamGoalFor - teamAgainstUpdate.TeamGoalAgainst;
                teamAgainstUpdate.TeamLoss = dc.TeamMatches.Count(item => item.TeamId == teamAgainst.TeamId && item.SeasonId == seasonId && item.TeamStatus == 3);
                teamAgainstUpdate.TeamWon = dc.TeamMatches.Count(item => item.TeamId == teamAgainst.TeamId && item.SeasonId == seasonId && item.TeamStatus == 1);
                teamAgainstUpdate.TeamPts = (teamAgainstUpdate.TeamWon * 3) + (teamAgainstUpdate.TeamDrew);

                var teamAgainstYellowCard = 0;
                var teamAgainstRedCard = 0;
                var playersAgainst =
                    dc.Players.Where(
                        item => item.TeamId == teamAgainstUpdate.TeamId && item.SeasonId == teamAgainstUpdate.SeasonId);
                if (playersAgainst.Count() != 0)
                {
                    teamAgainstYellowCard = playersAgainst.Sum(item => item.PlayerYellowCard);
                    teamAgainstRedCard = playersAgainst.Sum(item => item.PlayerRedCard);
                }

                teamAgainstUpdate.TeamYellowCard = teamAgainstYellowCard;
                teamAgainstUpdate.TeamRedCard = teamAgainstRedCard;
                dc.SubmitChanges();
            }
        }

        public void ForceUpdateTeamResult(int seasonId)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var teamSeasonList = dc.TeamSeasons.Where(item => item.SeasonId == seasonId).ToList();
                foreach (var teamSeason in teamSeasonList)
                {
                    var teamUpdate = dc.TeamSeasons.Single(item => item.TeamId == teamSeason.TeamId && item.SeasonId == seasonId);
                    teamUpdate.TeamMatchPlayed = dc.TeamMatches.Count(item => item.TeamId == teamSeason.TeamId && item.SeasonId == seasonId && item.TeamStatus != 0);
                    teamUpdate.TeamDrew = dc.TeamMatches.Count(item => item.TeamId == teamSeason.TeamId && item.SeasonId == seasonId && item.TeamStatus == 2);
                    var teamgoalAgainstSum =
                        dc.TeamMatches.Where(item => item.TeamId == teamSeason.TeamId && item.SeasonId == seasonId && item.TeamStatus != 0).Sum(
                            item => item.TeamGoalAgainst);
                    if (teamgoalAgainstSum != null)
                        teamUpdate.TeamGoalAgainst = (int)teamgoalAgainstSum;

                    var teamgoalForSum =
                        dc.TeamMatches.Where(item => item.TeamId == teamSeason.TeamId && item.SeasonId == seasonId && item.TeamStatus != 0).Sum(
                            item => item.TeamGoalFor);
                    if (teamgoalForSum != null)
                        teamUpdate.TeamGoalFor = (int)teamgoalForSum;
                    teamUpdate.TeamGoalDiff = teamUpdate.TeamGoalFor - teamUpdate.TeamGoalAgainst;
                    teamUpdate.TeamLoss = dc.TeamMatches.Count(item => item.TeamId == teamSeason.TeamId && item.SeasonId == seasonId && item.TeamStatus == 3);
                    teamUpdate.TeamWon = dc.TeamMatches.Count(item => item.TeamId == teamSeason.TeamId && item.SeasonId == seasonId && item.TeamStatus == 1);
                    var teamUpdateYellowCard = 0;
                    var teamUpdateRedCard = 0;
                    var playersAgainst =
                        dc.Players.Where(
                            item => item.TeamId == teamUpdate.TeamId && item.SeasonId == teamUpdate.SeasonId);
                    if (playersAgainst.Count() != 0)
                    {
                        teamUpdateYellowCard = playersAgainst.Sum(item => item.PlayerYellowCard);
                        teamUpdateRedCard = playersAgainst.Sum(item => item.PlayerRedCard);
                    }
                    teamUpdate.TeamYellowCard = teamUpdateYellowCard;
                    teamUpdate.TeamRedCard = teamUpdateRedCard;
                    teamUpdate.TeamPts = (teamUpdate.TeamWon * 3) + (teamUpdate.TeamDrew);
                    dc.SubmitChanges();
                }
            }
        }

        public void CalculatePlayerResult(Player playerInput)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var playerTeamList =
                    dc.Players.Where(item => item.SeasonId == playerInput.SeasonId && item.TeamId == playerInput.TeamId).ToList();
                foreach (var player in playerTeamList)
                {
                    var playerUpdate = dc.Players.Single(item => item.PlayerId == player.PlayerId);
                    playerUpdate.PlayerGoal =
                        dc.PlayerMatches.Count(
                            item =>
                            item.PlayerGoal == 1 && item.PlayerId == player.PlayerId && item.TeamId == player.TeamId && item.SeasonId == player.SeasonId);
                    playerUpdate.PlayerRedCard =
                        dc.PlayerMatches.Count(
                            item =>
                            item.PlayerRedCard == 1 && item.PlayerId == player.PlayerId && item.TeamId == player.TeamId && item.SeasonId == player.SeasonId);
                    playerUpdate.PlayerYellowCard =
                        dc.PlayerMatches.Count(
                            item =>
                            item.PlayerYellowCard == 1 && item.PlayerId == player.PlayerId && item.TeamId == player.TeamId && item.SeasonId == player.SeasonId);
                    dc.SubmitChanges();
                }
            }
        }

        protected void ForceUpdateClick(object sender, EventArgs e)
        {
            if (Session["seasonid"] == null) return;
            if (Convert.ToInt32(Session["seasonid"]) == 0) return;
            var seasonId = Convert.ToInt32(Session["seasonid"]);
            ForceUpdateTeamResult(seasonId);
        }
    }
}