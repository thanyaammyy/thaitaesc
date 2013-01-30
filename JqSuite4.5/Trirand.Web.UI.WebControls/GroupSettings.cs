using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class GroupSettings : IStateManager
	{
		private GroupFieldCollection _groupFields;
		private bool _isTracking;
		private StateBag _viewState = new StateBag();
		[Category("Behavior"), DefaultValue(null), Description("The list of fields that take part in grouping"), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public GroupFieldCollection GroupFields
		{
			get
			{
				if (this._groupFields == null)
				{
					this._groupFields = new GroupFieldCollection();
					((IStateManager)this._groupFields).TrackViewState();
				}
				return this._groupFields;
			}
		}
		[Category("Behavior"), DefaultValue(false), Description("The initial state of the groups - collapsed or expanded."), NotifyParentProperty(true)]
		public bool CollapseGroups
		{
			get
			{
				return this.ViewState["CollapseGroups"] != null && (bool)this.ViewState["CollapseGroups"];
			}
			set
			{
				this.ViewState["CollapseGroups"] = value;
			}
		}
		[Category("Show or hide the summary (footer) row when we collapse the group."), DefaultValue(false), Description("The initial state of the groups - collapsed or expanded."), NotifyParentProperty(true)]
		public bool ShowSummaryOnHide
		{
			get
			{
				return this.ViewState["ShowSummaryOnHide"] != null && (bool)this.ViewState["ShowSummaryOnHide"];
			}
			set
			{
				this.ViewState["ShowSummaryOnHide"] = value;
			}
		}
		bool IStateManager.IsTrackingViewState
		{
			get
			{
				return this._isTracking;
			}
		}
		private StateBag ViewState
		{
			get
			{
				return this._viewState;
			}
		}
		internal string ToJSON()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (this.GroupFields.Count > 0)
			{
				stringBuilder.Append(",grouping:true");
				stringBuilder.Append(",groupingView: {");
				stringBuilder.AppendFormat("groupField: {0}", this.GetDataFields());
				stringBuilder.AppendFormat(",groupColumnShow: {0}", this.GetGroupColumnShow());
				stringBuilder.AppendFormat(",groupText: {0}", this.GetHeaderText());
				stringBuilder.AppendFormat(",groupOrder: {0}", this.GetGroupSortDirection());
				stringBuilder.AppendFormat(",groupSummary: {0}", this.GetGroupShowGroupSummary());
				stringBuilder.AppendFormat(",groupCollapse: {0}", this.CollapseGroups.ToString().ToLower());
				stringBuilder.AppendFormat(",groupDataSorted: true", new object[0]);
				if (this.ShowSummaryOnHide)
				{
					stringBuilder.Append(",showSummaryOnHide: true");
				}
				stringBuilder.Append("}");
			}
			return stringBuilder.ToString();
		}
		private string GetDataFields()
		{
			List<string> list = new List<string>();
			foreach (GroupField groupField in this.GroupFields)
			{
				list.Add(groupField.DataField);
			}
			return new JavaScriptSerializer().Serialize(list);
		}
		private string GetGroupColumnShow()
		{
			List<bool> list = new List<bool>();
			foreach (GroupField groupField in this.GroupFields)
			{
				list.Add(groupField.ShowGroupColumn);
			}
			return new JavaScriptSerializer().Serialize(list);
		}
		private string GetHeaderText()
		{
			List<string> list = new List<string>();
			foreach (GroupField groupField in this.GroupFields)
			{
				list.Add(groupField.HeaderText);
			}
			return new JavaScriptSerializer().Serialize(list);
		}
		private string GetGroupSortDirection()
		{
			List<string> list = new List<string>();
			foreach (GroupField groupField in this.GroupFields)
			{
				list.Add(groupField.GroupSortDirection.ToString().ToLower());
			}
			return new JavaScriptSerializer().Serialize(list);
		}
		private string GetGroupShowGroupSummary()
		{
			List<bool> list = new List<bool>();
			foreach (GroupField groupField in this.GroupFields)
			{
				list.Add(groupField.ShowGroupSummary);
			}
			return new JavaScriptSerializer().Serialize(list);
		}
		void IStateManager.LoadViewState(object state)
		{
			if (state != null)
			{
				((IStateManager)this.ViewState).LoadViewState(state);
			}
		}
		object IStateManager.SaveViewState()
		{
			return ((IStateManager)this.ViewState).SaveViewState();
		}
		void IStateManager.TrackViewState()
		{
			this._isTracking = true;
			((IStateManager)this.ViewState).TrackViewState();
		}
		public override string ToString()
		{
			return string.Empty;
		}
	}
}
