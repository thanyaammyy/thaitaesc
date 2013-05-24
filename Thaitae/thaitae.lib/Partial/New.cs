using System.Configuration;

namespace thaitae.lib
{
    public partial class New
    {
        partial void OnCreated()
        {
            newsTopic = "";
            newsContent = "";
            picture = "/NewsImages/noImage.jpg";
        }

        public string NewsTypeName
        {
            get
            {
                if (newsType == 1)
                {
                    return "Hot News";
                }
                return "Scoop";
            }
        }

        public string NewsBrief
        {
            get
            {
                if (newsContent.Length >= 120)
                {
                    return newsContent.Substring(0, 120);
                }
                return newsContent;
            }
        }

        public string NewsThumb
        {
            get
            {
                var front = picture.Replace("/NewsImages/", "/NewsImages/Thumbs/");
                var thumb = front.Replace(".jpg", "_thumb.jpg");
                return thumb;
            }
        }

        public string NewsImageTopicContent
        {
            get
            {
                return "<div style='cursor:pointer;'><h2>" + newsTopic + "</h2><br/>" + NewsBrief + "</div>";
            }
        }

        public string NewsPicture
        {
            get { return "<div style='cursor:pointer;'><img width='100px' height='74px' src='" + NewsThumb + "'/></div>"; }
        }

        public string ShowPictureThumb
        {
            get { return "<img width='100px' height='74px' src='" + NewsThumb + "'/></div>"; }
        }
    }
}