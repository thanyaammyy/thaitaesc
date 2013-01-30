using System;
using System.IO;
namespace Trirand.Web.UI.WebControls
{
	public class JQChartExportData
	{
		public int Width
		{
			get;
			set;
		}
		public string Type
		{
			get;
			set;
		}
		public MemoryStream SvgStream
		{
			get;
			set;
		}
		public string FileName
		{
			get;
			set;
		}
		public bool ExportActive
		{
			get;
			set;
		}
		public JQChartExportData()
		{
			this.Width = 300;
			this.Type = "";
			this.SvgStream = null;
			this.FileName = "";
			this.ExportActive = false;
		}
	}
}
