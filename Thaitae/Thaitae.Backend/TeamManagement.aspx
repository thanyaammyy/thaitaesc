<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="TeamManagement.aspx.cs" Inherits="Thaitae.Backend.TeamManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <h2>
        Team Management</h2>
    <asp:updatepanel id="updateTeamPanel" updatemode="Conditional" runat="server">
        <contenttemplate>
            <asp:DropDownList runat="server" ID="ddlLeague" DataSourceID="LeagueDataSource"
				DataTextField="LeagueName" DataValueField="LeagueId" AutoPostBack="True" OnSelectedIndexChanged="ddlLeague_SelectedIndexChanged">
			</asp:DropDownList>
			<asp:DropDownList runat="server" ID="ddlSeason" DataSourceID="SeasonDataSource"
				DataTextField="SeasonName" DataValueField="SeasonId" AutoPostBack="True"
				onselectedindexchanged="ddlSeason_SelectedIndexChanged">
			</asp:DropDownList>
			<cc1:JQGrid ID="JqgridTeam" AutoWidth="True" runat="server" onrowdeleting="JqgridTeam_RowDeleting"
				onrowediting="JqgridTeam_RowEditing">
				<Columns>
					<cc1:JQGridColumn DataField="TeamId" Visible="False" />
					<cc1:JQGridColumn DataField="SeasonId" Visible="False" />
					<cc1:JQGridColumn DataField="TeamSeasonId" PrimaryKey="True" Visible="False" />
					<cc1:JQGridColumn HeaderText="Edit" EditActionIconsColumn="true" Width="100"
						TextAlign="Center" />
					<cc1:JQGridColumn HeaderText="Name" DataField="TeamName" Editable="True"
						TextAlign="Center"/>
					<cc1:JQGridColumn HeaderText="Description" DataField="TeamDesc" Editable="True"
						TextAlign="Center"/>
						 <cc1:JQGridColumn HeaderText="Status" DataField="ActiveName" Editable="True" EditType="DropDown" EditValues="0:InActive;1:Active" TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="P" DataField="TeamMatchPlayed"
						TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="W" DataField="TeamWon"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="D" DataField="TeamDrew"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="L" DataField="TeamLoss"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="F" DataField="TeamGoalFor"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="A" DataField="TeamGoalAgainst"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="GD" DataField="TeamGoalDiff"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="Pts" DataField="TeamPts"
					    TextAlign="Center"/>
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
    <asp:objectdatasource id="SeasonDataSource" dataobjecttypename="thaitae.lib.Season"
        selectmethod="ListSeasonItems" typename="thaitae.lib.Page.SeasonHelper" runat="server">
        <selectparameters>
			<asp:SessionParameter Name="LeagueId" SessionField="LeagueId" Type="Int32" />
		</selectparameters>
    </asp:objectdatasource>
</asp:content>