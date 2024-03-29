﻿using System.Linq;

namespace thaitae.lib
{
    public partial class PlayerMatch
    {
        partial void OnCreated()
        {
            PlayerGoal = 0;
            PlayerRedCard = 0;
            PlayerYellowCard = 0;
        }

        public string PlayerCondition
        {
            get
            {
                if (PlayerGoal == 1)
                    return "Goal Player";
                if (PlayerRedCard == 1)
                    return "RedCard Player";
                return "YellowCard Player";
            }
        }

        public string PlayerConditionThai
        {
            get
            {
                if (PlayerGoal == 1)
                    return "ผู้ทำประตู";
                if (PlayerRedCard == 1)
                    return "โดนใบแดง";
                return "โดนใบเหลือง";
            }
        }

        public string PlayerNumber
        {
            get
            {
                if (PlayerId == null)
                    return "";
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var playerNumber = dc.Players.Single(item => item.PlayerId == PlayerId).PlayerNumber;
                    return playerNumber.ToString();
                }
            }
        }

        public string PlayerName
        {
            get
            {
                if (PlayerId == null)
                    return "";
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var playerName = dc.Players.Single(item => item.PlayerId == PlayerId).PlayerName;
                    return playerName;
                }
            }
        }
    }
}