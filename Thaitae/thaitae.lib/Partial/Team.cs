using System;

namespace thaitae.lib
{
    public partial class Team
    {
        partial void OnCreated()
        {
            TeamName = "";
            TeamDesc = "";
            Active = 1;
        }

        public string ActiveName
        {
            get
            {
                return Active == 1 ? "Active" : "Inactive";
            }
        }

        public Guid Guid { get; set; }
    }
}