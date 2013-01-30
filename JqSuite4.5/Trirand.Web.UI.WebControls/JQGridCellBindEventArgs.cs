using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQGridCellBindEventArgs : CancelEventArgs
	{
		private string _cellHtml;
		private int _columnIndex;
		private int _rowIndex;
		private string _rowKey;
		private object[] _rowValues;
		public string CellHtml
		{
			get
			{
				return this._cellHtml;
			}
			set
			{
				this._cellHtml = value;
			}
		}
		public int ColumnIndex
		{
			get
			{
				return this._columnIndex;
			}
			set
			{
				this._columnIndex = value;
			}
		}
		public int RowIndex
		{
			get
			{
				return this._rowIndex;
			}
			set
			{
				this._rowIndex = value;
			}
		}
		public string RowKey
		{
			get
			{
				return this._rowKey;
			}
			set
			{
				this._rowKey = value;
			}
		}
		public object[] RowValues
		{
			get
			{
				return this._rowValues;
			}
			set
			{
				this._rowValues = value;
			}
		}
		public JQGridCellBindEventArgs(string cellHtml, int columnIndex, int rowIndex, string rowKey, object[] rowValues)
		{
			this._cellHtml = cellHtml;
			this._columnIndex = columnIndex;
			this._rowIndex = rowIndex;
			this._rowKey = rowKey;
			this._rowValues = rowValues;
		}
	}
}
