using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQTreeViewNodesRequestedEventArgs : CancelEventArgs
	{
		private string _parentNodeValue;
		private JQTreeNodeCollection _parentNodeCollection;
		public string ParentNodeValue
		{
			get
			{
				return this._parentNodeValue;
			}
			set
			{
				this._parentNodeValue = value;
			}
		}
		public JQTreeNodeCollection ParentNodes
		{
			get
			{
				return this._parentNodeCollection;
			}
			set
			{
				this._parentNodeCollection = value;
			}
		}
		public JQTreeViewNodesRequestedEventArgs(string parentNodeValue)
		{
			this._parentNodeValue = parentNodeValue;
			this._parentNodeCollection = new JQTreeNodeCollection();
		}
	}
}
