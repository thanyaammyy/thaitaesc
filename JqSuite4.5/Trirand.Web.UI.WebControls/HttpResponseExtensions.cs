using System;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	internal static class HttpResponseExtensions
	{
		internal static void SendResponse(this HttpResponse response, string text)
		{
			try
			{
				response.Clear();
				response.Write(text);
				response.Flush();
				response.SuppressContent = true;
			}
			catch (Exception)
			{
			}
		}
	}
}
