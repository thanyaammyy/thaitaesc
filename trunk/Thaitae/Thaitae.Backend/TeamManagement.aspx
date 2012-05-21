<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="TeamManagement.aspx.cs" Inherits="Thaitae.Backend.TeamManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h2>
		Team Management</h2>
	<asp:UpdatePanel ID="updateTeamPanel" UpdateMode="Conditional" runat="server">
		<ContentTemplate>
			<asp:DropDownList runat="server" ID="ddlSeason" DataSourceID="SeasonDataSource" AppendDataBoundItems="True"
				DataTextField="SeasonName" DataValueField="SeasonId" AutoPostBack="True" 
				onselectedindexchanged="ddlSeason_SelectedIndexChanged">
				<asp:ListItem Value="0">Select Season</asp:ListItem>
			</asp:DropDownList>
			<cc1:JQGrid ID="JqgridTeam" AutoWidth="True" runat="server" 
				onrowadding="JqgridTeam_RowAdding" onrowdeleting="JqgridTeam_RowDeleting" 
				onrowediting="JqgridTeam_RowEditing">
				<Columns>
					<cc1:JQGridColumn DataField="TeamId" Width="55" Visible="False" />
					<cc1:JQGridColumn DataField="SeasonId" Width="55" Visible="False" />
					<cc1:JQGridColumn DataField="TeamSeasonId" PrimaryKey="True" Width="55" Visible="False" />
					<cc1:JQGridColumn HeaderText="Edit Actions" EditActionIconsColumn="true" Width="50"
						TextAlign="Center" />
					<cc1:JQGridColumn HeaderText="Name" DataField="TeamName" Editable="True"
						TextAlign="Center" />
					<cc1:JQGridColumn HeaderText="Description" DataField="TeamDesc" Editable="True"
						TextAlign="Center" />
						 <cc1:JQGridColumn HeaderText="Status" DataField="ActiveName" Editable="True" EditType="DropDown" EditValues="0:InActive;1:Active" TextAlign="Center"/>
				</Columns>
				<AddDialogSettings CloseAfterAdding="False" />
				<EditDialogSettings CloseAfterEditing="True" />
				<ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
					ShowRefreshButton="True" ShowSearchButton="True" />
				<AppearanceSettings ShowRowNumbers="true" />
			</cc1:JQGrid>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:ObjectDataSource ID="SeasonDataSource" DataObjectTypeName="thaitae.lib.Season"
		SelectMethod="ListSeasonItems" TypeName="thaitae.lib.Page.SeasonHelper" runat="server">
	</asp:ObjectDataSource>
</asp:Content>
