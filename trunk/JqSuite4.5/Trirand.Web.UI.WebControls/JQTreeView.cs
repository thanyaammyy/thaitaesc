using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Trirand.Web.UI.WebControls
{
	[ToolboxData("<{0}:jqtreeview runat=server></{0}:jqtreeview>")]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class JQTreeView : WebControl, IPostBackDataHandler
	{
		public delegate void JQTreeViewNodesRequestedEventHandler(object sender, JQTreeViewNodesRequestedEventArgs e);
		private TreeViewClientSideEvents _clientSideEvents;
		private JQTreeNodeCollection _nodeCollection;
		private static readonly object EventNodesRequested;
		[Category("Action"), Description("Fires when the treeview requests nodes on demand.")]
		public event JQTreeView.JQTreeViewNodesRequestedEventHandler NodesRequested
		{
			add
			{
				base.Events.AddHandler(JQTreeView.EventNodesRequested, value);
			}
			remove
			{
				base.Events.RemoveHandler(JQTreeView.EventNodesRequested, value);
			}
		}
		public JQTreeNodeCollection SelectedNodes
		{
			get
			{
				JQTreeNodeCollection jQTreeNodeCollection = new JQTreeNodeCollection();
				JQTreeNodeCollection allNodesFlat = this.GetAllNodesFlat(this.Nodes);
				foreach (JQTreeNode jQTreeNode in allNodesFlat)
				{
					if (jQTreeNode.Selected)
					{
						jQTreeNodeCollection.Add(jQTreeNode);
					}
				}
				return jQTreeNodeCollection;
			}
		}
		public JQTreeNodeCollection ExpandedNodes
		{
			get
			{
				JQTreeNodeCollection jQTreeNodeCollection = new JQTreeNodeCollection();
				JQTreeNodeCollection allNodesFlat = this.GetAllNodesFlat(this.Nodes);
				foreach (JQTreeNode jQTreeNode in allNodesFlat)
				{
					if (jQTreeNode.Expanded)
					{
						jQTreeNodeCollection.Add(jQTreeNode);
					}
				}
				return jQTreeNodeCollection;
			}
		}
		public JQTreeNodeCollection CheckedNodes
		{
			get
			{
				JQTreeNodeCollection jQTreeNodeCollection = new JQTreeNodeCollection();
				JQTreeNodeCollection allNodesFlat = this.GetAllNodesFlat(this.Nodes);
				foreach (JQTreeNode jQTreeNode in allNodesFlat)
				{
					if (jQTreeNode.Checked)
					{
						jQTreeNodeCollection.Add(jQTreeNode);
					}
				}
				return jQTreeNodeCollection;
			}
		}
		[Category("Default"), DefaultValue(null), Description("DataControls_Columns"), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual JQTreeNodeCollection Nodes
		{
			get
			{
				if (this._nodeCollection == null)
				{
					this._nodeCollection = new JQTreeNodeCollection();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._nodeCollection).TrackViewState();
					}
				}
				return this._nodeCollection;
			}
		}
		[Category(""), DefaultValue("")]
		public string DataUrl
		{
			get
			{
				object obj = this.ViewState["DataUrl"];
				if (obj != null)
				{
					return (string)obj;
				}
				if (base.DesignMode)
				{
					return "";
				}
				return HttpContext.Current.Request.Url.PathAndQuery;
			}
			set
			{
				this.ViewState["DataUrl"] = value;
			}
		}
		[Category(""), DefaultValue(true), Description("")]
		public bool HoverOnMouseOver
		{
			get
			{
				return this.ViewState["HoverOnMouseOver"] == null || (bool)this.ViewState["HoverOnMouseOver"];
			}
			set
			{
				this.ViewState["HoverOnMouseOver"] = value;
			}
		}
		[Category(""), DefaultValue(false), Description("")]
		public bool CheckBoxes
		{
			get
			{
				return this.ViewState["CheckBoxes"] != null && (bool)this.ViewState["CheckBoxes"];
			}
			set
			{
				this.ViewState["CheckBoxes"] = value;
			}
		}
		[Category(""), DefaultValue(false), Description("")]
		public bool MultipleSelect
		{
			get
			{
				return this.ViewState["MultipleSelect"] != null && (bool)this.ViewState["MultipleSelect"];
			}
			set
			{
				this.ViewState["MultipleSelect"] = value;
			}
		}
		[Category("Client-side events"), Description("Defines client-side events in jqGrid"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public virtual TreeViewClientSideEvents ClientSideEvents
		{
			get
			{
				if (this._clientSideEvents == null)
				{
					this._clientSideEvents = new TreeViewClientSideEvents();
					if (base.IsTrackingViewState)
					{
						((IStateManager)this._clientSideEvents).TrackViewState();
					}
				}
				return this._clientSideEvents;
			}
		}
		static JQTreeView()
		{
			JQTreeView.EventNodesRequested = new object();
		}
		public void DataBind(JQTreeNodeCollection nodes)
		{
			string text = new JavaScriptSerializer().Serialize(this.SerializeNodes(nodes));
			HttpContext.Current.Response.SendResponse(text);
		}
		internal List<Hashtable> SerializeNodes(JQTreeNodeCollection nodes)
		{
			List<Hashtable> list = new List<Hashtable>();
			foreach (JQTreeNode jQTreeNode in nodes)
			{
				list.Add(jQTreeNode.ToHashtable());
			}
			return list;
		}
		public JQTreeNodeCollection GetAllNodesFlat(JQTreeNodeCollection nodes)
		{
			JQTreeNodeCollection jQTreeNodeCollection = new JQTreeNodeCollection();
			foreach (JQTreeNode jQTreeNode in nodes)
			{
				jQTreeNodeCollection.Add(jQTreeNode);
				if (jQTreeNode.Nodes.Count > 0)
				{
					this.GetNodesFlat(jQTreeNode.Nodes, jQTreeNodeCollection);
				}
			}
			return jQTreeNodeCollection;
		}
		private void GetNodesFlat(JQTreeNodeCollection nodes, JQTreeNodeCollection result)
		{
			foreach (JQTreeNode jQTreeNode in nodes)
			{
				result.Add(jQTreeNode);
				if (jQTreeNode.Nodes.Count > 0)
				{
					this.GetNodesFlat(jQTreeNode.Nodes, result);
				}
			}
		}
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (!string.IsNullOrEmpty(HttpContext.Current.Request["parentNodeValue"]))
			{
				JQTreeViewNodesRequestedEventArgs jQTreeViewNodesRequestedEventArgs = new JQTreeViewNodesRequestedEventArgs(HttpContext.Current.Request["parentNodeValue"]);
				this.OnNodesRequested(jQTreeViewNodesRequestedEventArgs);
				HttpContext.Current.Response.SendResponse(new JavaScriptSerializer().Serialize(this.SerializeNodes(jQTreeViewNodesRequestedEventArgs.ParentNodes)));
			}
		}
		protected override void OnPreRender(EventArgs e)
		{
			JQTreeViewRenderer jQTreeViewRenderer = new JQTreeViewRenderer(this);
			ScriptManager.RegisterStartupScript(this, typeof(JQTreeView), "_jqrid_startup" + this.ClientID, jQTreeViewRenderer.RenderJavaScript(), false);
			base.OnPreRender(e);
		}
		protected override void Render(HtmlTextWriter writer)
		{
			if (!base.DesignMode)
			{
				JQTreeViewRenderer jQTreeViewRenderer = new JQTreeViewRenderer(this);
				writer.Write(jQTreeViewRenderer.RenderHtml());
				return;
			}
			base.Render(writer);
		}
		public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			string text = postCollection[this.ClientID + "_selectedState"];
			string text2 = postCollection[this.ClientID + "_checkedState"];
			string text3 = postCollection[this.ClientID + "_expandedState"];
			if (!string.IsNullOrEmpty(text))
			{
				this.RestoreSelectedState(text);
			}
			if (!string.IsNullOrEmpty(text2))
			{
				this.RestoreCheckedState(text2);
			}
			if (!string.IsNullOrEmpty(text3))
			{
				this.RestoreExpandedState(text3);
			}
			return false;
		}
		public void RaisePostDataChangedEvent()
		{
		}
		private void RestoreSelectedState(string selectedState)
		{
			List<JQTreeNode> list = new JavaScriptSerializer().Deserialize<List<JQTreeNode>>(selectedState);
			JQTreeNodeCollection allNodesFlat = this.GetAllNodesFlat(this.Nodes);
			IEnumerator enumerator = allNodesFlat.GetEnumerator();
			try
			{
				JQTreeNode node;
				while (enumerator.MoveNext())
				{
					node = (JQTreeNode)enumerator.Current;
					JQTreeNode jQTreeNode = list.Find((JQTreeNode selectedNode) => selectedNode.Text == node.Text && selectedNode.Value == node.Value);
					if (jQTreeNode != null)
					{
						node.Selected = true;
					}
					else
					{
						node.Selected = false;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		private void RestoreExpandedState(string expandedState)
		{
			List<JQTreeNode> list = new JavaScriptSerializer().Deserialize<List<JQTreeNode>>(expandedState);
			JQTreeNodeCollection allNodesFlat = this.GetAllNodesFlat(this.Nodes);
			IEnumerator enumerator = allNodesFlat.GetEnumerator();
			try
			{
				JQTreeNode node;
				while (enumerator.MoveNext())
				{
					node = (JQTreeNode)enumerator.Current;
					JQTreeNode jQTreeNode = list.Find((JQTreeNode expandedNode) => expandedNode.Text == node.Text && expandedNode.Value == node.Value);
					if (jQTreeNode != null)
					{
						node.Expanded = true;
					}
					else
					{
						node.Expanded = false;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		private void RestoreCheckedState(string checkedState)
		{
			List<JQTreeNode> list = new JavaScriptSerializer().Deserialize<List<JQTreeNode>>(checkedState);
			JQTreeNodeCollection allNodesFlat = this.GetAllNodesFlat(this.Nodes);
			IEnumerator enumerator = allNodesFlat.GetEnumerator();
			try
			{
				JQTreeNode node;
				while (enumerator.MoveNext())
				{
					node = (JQTreeNode)enumerator.Current;
					JQTreeNode jQTreeNode = list.Find((JQTreeNode checkedNode) => checkedNode.Text == node.Text && checkedNode.Value == node.Value);
					if (jQTreeNode != null)
					{
						node.Checked = true;
					}
					else
					{
						node.Checked = false;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		protected virtual void OnNodesRequested(JQTreeViewNodesRequestedEventArgs e)
		{
			JQTreeView.JQTreeViewNodesRequestedEventHandler jQTreeViewNodesRequestedEventHandler = (JQTreeView.JQTreeViewNodesRequestedEventHandler)base.Events[JQTreeView.EventNodesRequested];
			if (jQTreeViewNodesRequestedEventHandler != null)
			{
				jQTreeViewNodesRequestedEventHandler(this, e);
			}
		}
	}
}
