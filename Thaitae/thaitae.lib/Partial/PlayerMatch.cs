using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public string PlayerNumber
        {
            get
            {
                if (PlayerId == null)
                    return "Enter Number";
                return PlayerId.ToString();
            }
        }
    }
}