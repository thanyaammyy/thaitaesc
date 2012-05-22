﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="Season.aspx.cs" Inherits="Thaitae.Backend.Season" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <h2>
        Season Management</h2>
    <asp:updatepanel id="updatepanel1" updatemode="Conditional" runat="server">
        <contenttemplate>
			<asp:DropDownList runat="server" ID="ddlLeague" DataSourceID="LeagueDataSource"
				DataTextField="LeagueName" DataValueField="LeagueId" AutoPostBack="True" OnSelectedIndexChanged="ddlLeague_SelectedIndexChanged">
			</asp:DropDownList>
			<cc1:JQGrid ID="JqgridSeason" AutoWidth="True" runat="server" 
				onrowadding="JqgridSeason_RowAdding" onrowdeleting="JqgridSeason_RowDeleting" 
				onrowediting="JqgridSeason_RowEditing">
				<Columns>
					<cc1:JQGridColumn DataField="SeasonId" PrimaryKey="True" Width="55" Visible="False" />
					<cc1:JQGridColumn DataField="LeagueId" Visible="False" />
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
		</contenttemplate>
    </asp:updatepanel>
    <asp:objectdatasource id="LeagueDataSource" dataobjecttypename="thaitae.lib.League"
        selectmethod="SelectLeagueItems" typename="thaitae.lib.Page.LeagueHelper" runat="server">
    </asp:objectdatasource>
</asp:content>