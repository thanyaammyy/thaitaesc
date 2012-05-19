using System.Web.Script.Serialization;
using System;

namespace IConcepts.Net.Serialization
{
    public static class JsonHelper
    {
        public static T JsonToObject<T>(string pStrJson){
            JavaScriptSerializer objJSSerializer = new JavaScriptSerializer();
            return objJSSerializer.Deserialize<T>(pStrJson);
        }

        public static string ObjectToJson<T>(T pAnyObject)
        {
            JavaScriptSerializer objJSSerializer = new JavaScriptSerializer();
            return objJSSerializer.Serialize(pAnyObject);
        }
    }
}