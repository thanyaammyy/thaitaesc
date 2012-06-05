using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib
{
    public partial class New
    {
        partial void OnCreated()
        {
            newsTopic = "";
            newsContent = "";
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
				if(newsContent.Length>=140)
				{
					return newsContent.Substring(0, 140);
				}
				return newsContent;
    		}
    	}

    	public string NewsThumb
    	{
    		get
    		{
    			var front = picture.Replace("http://admin.thaitaesc.com/NewsImages", "http://admin.thaitaesc.com/NewsImages/Thumbs/");
				var thumb = front.Replace(".jpg", "_thumb.jpg");
    			return thumb;
    		}
    	}
    }
}