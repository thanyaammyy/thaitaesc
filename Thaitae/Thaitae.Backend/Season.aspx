<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
	CodeBehind="Season.aspx.cs" Inherits="Thaitae.Backend.Season" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h2>
		Season Management</h2>
	<asp:UpdatePanel ID="updatepanel1" UpdateMode="Conditional" runat="server">
		<ContentTemplate>
			<asp:DropDownList runat="server" ID="ddlLeague" DataSourceID="LeagueDataSource" AppendDataBoundItems="True"
				DataTextField="LeagueName" DataValueField="LeagueId" AutoPostBack="True" OnSelectedIndexChanged="ddlLeague_SelectedIndexChanged">
				<asp:ListItem Value="0">Select League</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList runat="server" ID="ddlLeagueEdit" DataSourceID="LeagueDataSource"
				DataTextField="LeagueName" DataValueField="LeagueId" >
			</asp:DropDownList>
			<cc1:JQGrid ID="JqgridSeason" AutoWidth="True" DataSourceID="SeasonDataSource" runat="server">
				<Columns>
					<cc1:JQGridColumn DataField="SeasonId" PrimaryKey="True" Width="55" Visible="False" />
					<cc1:JQGridColumn DataField="LeagueId" Editable="True" EditType="DropDown" EditorControlID="ddlLeagueEdit" Width="55" Visible="False" />
					<cc1:JQGridColumn HeaderText="Edit Actions" EditActionIconsColumn="true" Width="50"
						TextAlign="Center" />
					<cc1:JQGridColumn HeaderText="Season Name" DataField="SeasonName" Editable="True"
						TextAlign="Center" />
					<cc1:JQGridColumn HeaderText="Description" DataField="SeasonDesc" Editable="True"
						TextAlign="Center" />
				</Columns>
				<AddDialogSettings CloseAfterAdding="False" />
				<EditDialogSettings CloseAfterEditing="True" />
				<ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
					ShowRefreshButton="True" ShowSearchButton="True" />
				<AppearanceSettings ShowRowNumbers="true" />
			</cc1:JQGrid>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:ObjectDataSource ID="LeagueDataSource" DataObjectTypeName="thaitae.lib.League"
		SelectMethod="SelectLeagueItems" TypeName="thaitae.lib.Page.LeagueHelper" runat="server">
	</asp:ObjectDataSource>
	<asp:ObjectDataSource DataObjectTypeName="thaitae.lib.Season" ID="SeasonDataSource"
		 InsertMethod="InsertSeason" UpdateMethod="UpdateSeason" DeleteMethod="DeleteSeason"
		runat="server" SelectMethod="SelectSeasonItems" TypeName="thaitae.lib.Page.SeasonHelper">
		<SelectParameters>
			<asp:SessionParameter Name="LeagueId" SessionField="LeagueId" Type="Int32" />
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>
