using System;
using System.Collections.Specialized;
namespace Trirand.Web.UI.WebControls
{
	public class JQGridState
	{
		public NameValueCollection QueryString
		{
			get;
			set;
		}
		public JQGridState()
		{
			this.QueryString = new NameValueCollection();
		}
	}
}
