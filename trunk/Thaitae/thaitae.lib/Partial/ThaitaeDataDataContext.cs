using System.Configuration;

namespace thaitae.lib
{
    public partial class ThaitaeDataDataContext
    {
        public static ThaitaeDataDataContext Create()
        {
            return new ThaitaeDataDataContext(ConfigurationManager.ConnectionStrings["ThaitaeConnection"].ConnectionString);
        }
    }
}