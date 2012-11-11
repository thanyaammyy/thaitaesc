namespace thaitae.lib
{
    public partial class League
    {
        partial void OnCreated()
        {
            LeagueName = "";
            LeagueDesc = "";
        }

        public string LeagueTypeName
        {
            get
            {
                if (LeagueType == 4)
                {
                    return "Normal League";
                }
                if (LeagueType == 8)
                {
                    return "Champion League";
                }
                if (LeagueType == 12)
                {
                    return "FA Cup";
                }
                return "Custom League";
            }
        }

        public string ActiveName
        {
            get
            {
                if (Active == 1)
                {
                    return "Active";
                }
                return "Inactive";
            }
        }

        public string ShowPictureThumb
        {
            get { return "<img width='70px' height='65px' src='" + Picture + "'/></div>"; }
        }
    }
}