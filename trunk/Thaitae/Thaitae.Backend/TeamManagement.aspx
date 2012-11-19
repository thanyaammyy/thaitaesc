<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="TeamManagement.aspx.cs" Inherits="Thaitae.Backend.TeamManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Team Management</h2>
    <asp:UpdatePanel ID="updateTeamPanel" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:DropDownList runat="server" ID="ddlLeague" DataSourceID="LeagueDataSource" DataTextField="LeagueName"
                DataValueField="LeagueId" AutoPostBack="True" OnSelectedIndexChanged="ddlLeague_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlSeason" DataSourceID="SeasonDataSource" DataTextField="SeasonName"
                DataValueField="SeasonId" AutoPostBack="True" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Button ID="GenTeam" ClientIDMode="Static" Visible="False" runat="server" OnClick="GenTeam_Click"
                Text="Generate 16 Teams Champion League"></asp:Button>
            <cc1:JQGrid ID="JqgridTeam" AutoWidth="True" runat="server" OnRowDeleting="JqgridTeam_RowDeleting"
                Height="100%" OnRowEditing="JqgridTeam_RowEditing" OnRowAdding="JqgridTeam_RowAdding">
                <Columns>
                    <cc1:JQGridColumn DataField="TeamId" Visible="False" />
                    <cc1:JQGridColumn DataField="SeasonId" Visible="False" />
                    <cc1:JQGridColumn DataField="TeamSeasonId" PrimaryKey="True" Visible="False" />
                    <cc1:JQGridColumn HeaderText="Name" DataField="TeamName" Editable="True" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Description" DataField="TeamDesc" Editable="True" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Status" DataField="ActiveName" Editable="True" EditType="DropDown"
                        EditValues="1:Active;0:InActive" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="P" DataField="TeamMatchPlayed" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="W" DataField="TeamWon" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="D" DataField="TeamDrew" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="L" DataField="TeamLoss" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="F" DataField="TeamGoalFor" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="A" DataField="TeamGoalAgainst" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="GD" DataField="TeamGoalDiff" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Yellow.C" DataField="TeamYellowCard" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Red.C" DataField="TeamRedCard" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Pts" DataField="TeamPts" TextAlign="Center" />
                </Columns>
                <AddDialogSettings CloseAfterAdding="True" />
                <EditDialogSettings CloseAfterEditing="True" />
                <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
                    ShowRefreshButton="True" ShowSearchButton="True" />
                <AppearanceSettings ShowRowNumbers="true" />
                <DeleteDialogSettings LeftOffset="497" TopOffset="241"></DeleteDialogSettings>
                <AddDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterAdding="True" Caption="Add Team" ClearAfterAdding="True"></AddDialogSettings>
                <EditDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterEditing="True" Caption="Edit Team"></EditDialogSettings>
                <PagerSettings PageSize="20"></PagerSettings>
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="LeagueDataSource" DataObjectTypeName="thaitae.lib.League"
        SelectMethod="SelectLeagueItems" TypeName="thaitae.lib.Page.LeagueHelper" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SeasonDataSource" DataObjectTypeName="thaitae.lib.Season"
        SelectMethod="ListSeasonItems" TypeName="thaitae.lib.Page.SeasonHelper" runat="server">
        <SelectParameters>
            <asp:SessionParameter Name="LeagueId" SessionField="LeagueId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>