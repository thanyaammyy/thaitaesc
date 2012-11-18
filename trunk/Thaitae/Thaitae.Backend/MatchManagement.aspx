﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="MatchManagement.aspx.cs" Inherits="Thaitae.Backend.MatchManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function bindCalendarDialog() {
            $('input[id][name$="MatchDate"]').blur();
            $('input[id][name$="MatchDate"]').datetimepicker();
        }
        function showHomePlayerGrid(subgrid_id, row_id) {
            showSubGrid_JqgridHomePlayer(subgrid_id, row_id, "", "JqgridHomePlayer");
            $("#p_" + subgrid_id + "_tJqgridHomePlayer").hide();
        }

        function showAwayPlayerGrid(subgrid_id, row_id) {
            showSubGrid_JqgridAwayPlayer(subgrid_id, row_id, "", "JqgridAwayPlayer");
            $("#p_" + subgrid_id + "_tJqgridAwayPlayer").hide();
        }

        function showSubGrids(subgrid_id, row_id) {
            // the "showSubGrid_JQGrid2" function is autogenerated and available globally on the page by the second child grid.
            // Calling it will place the child grid below the parent expanded row and will call the OnDataRequesting event
            // of the child grid, with ID equal to the ID of the parent expanded row
            showSubGrid_JqgridHomeTeam(subgrid_id, row_id, "", "JqgridHomeTeam");
            showSubGrid_JqgridAwayTeam(subgrid_id, row_id, "", "JqgridAwayTeam");
            $("#gbox_" + subgrid_id + "_tJqgridHomeTeam").css("float", "left");
            $("#gbox_" + subgrid_id + "_tJqgridAwayTeam").css("float", "left");
            $("#p_" + subgrid_id + "_tJqgridHomeTeam").hide();
            $("#p_" + subgrid_id + "_tJqgridAwayTeam").hide();
            var teamHome = $("#" + row_id).find("td[aria-describedby*='TeamHomeIdName']").html();
            var teamAway = $("#" + row_id).find("td[aria-describedby*='TeamAwayIdName']").html();
            $("#gbox_" + subgrid_id + "_tJqgridHomeTeam th.ui-th-column-header").html(teamHome);
            $("#gbox_" + subgrid_id + "_tJqgridAwayTeam th.ui-th-column-header").html(teamAway);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Match Management</h2>
    <asp:UpdatePanel ID="updateTeamPanel" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:DropDownList runat="server" ID="ddlLeague" DataSourceID="LeagueDataSource" DataTextField="LeagueName"
                DataValueField="LeagueId" AutoPostBack="True" OnSelectedIndexChanged="ddlLeague_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlSeason" DataSourceID="SeasonDataSource" DataTextField="SeasonName"
                DataValueField="SeasonId" AutoPostBack="True" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Button ID="GenMatch" ClientIDMode="Static" runat="server" OnClick="Button1_Click"
                Text="Generate Match"></asp:Button>
            <asp:Button ID="ForceUpdate" ClientIDMode="Static" runat="server" OnClick="ForceUpdate_Click"
                Text="Force Calculate Match"></asp:Button>
            <cc1:JQGrid ID="JqgridMatch1" runat="server" AutoWidth="True" OnRowEditing="JqgridMatch1_RowEditing"
                OnSearching="JqgridMatch1_Searching" Height="100%">
                <Columns>
                    <cc1:JQGridColumn DataField="MatchId" PrimaryKey="True" Visible="False" />
                    <cc1:JQGridColumn DataField="SeasonId" Visible="False" />
                    <cc1:JQGridColumn HeaderText="Set Date" Width="30" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                        TextAlign="Center" Searchable="False" />
                    <cc1:JQGridColumn HeaderText="Home Team" DataType="String" DataField="TeamHomeIdNameExtend"
                        TextAlign="Center" Searchable="True" SearchType="DropDown" SearchControlID="ddlTeam"
                        SearchToolBarOperation="Contains" />
                    <cc1:JQGridColumn HeaderText="Away Team" DataType="String" DataField="TeamAwayIdNameExtend"
                        TextAlign="Center" Searchable="True" SearchType="DropDown" SearchControlID="ddlTeam"
                        SearchToolBarOperation="Contains" />
                    <cc1:JQGridColumn HeaderText="Match Date" DataType="DateTime" DataFormatString="{0:dd/MM/yyyy HH:mm}"
                        DataField="MatchDate" EditType="TextBox" Editable="True" TextAlign="Center" Searchable="false" />
                </Columns>
                <ToolBarSettings ShowRefreshButton="True" ShowSearchToolBar="True" />
                <SearchToolBarSettings SearchToolBarAction="SearchOnEnter"></SearchToolBarSettings>
                <AppearanceSettings ShowRowNumbers="true" />
                <ClientSideEvents RowSelect="bindCalendarDialog" SubGridRowExpanded="showSubGrids" />
                <HierarchySettings HierarchyMode="Parent" />
                <PagerSettings PageSize="100"></PagerSettings>
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:DropDownList runat="server" ID="ddlTeam" DataSourceID="TeamDataSource" DataTextField="TeamName"
        DataValueField="TeamName">
    </asp:DropDownList>
    <cc1:JQGrid ID="JqgridHomeTeam" runat="server" OnDataRequesting="JqgridHomeTeam_DataRequesting"
        Height="100%" Width="465" OnRowEditing="JqgridHomeTeam_RowEditing">
        <Columns>
            <cc1:JQGridColumn DataField="TeamMatchId" PrimaryKey="True" Visible="False" DataType="Int" />
            <cc1:JQGridColumn HeaderText="Edit value" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                Width="80" TextAlign="Center" Searchable="False" />
            <cc1:JQGridColumn HeaderText="Team Goal" DataField="TeamGoalFor" DataType="Int" Editable="True"
                TextAlign="Center" EditType="TextBox" />
            <cc1:JQGridColumn HeaderText="Team Yellow Card" DataField="TeamYellowCard" DataType="Int"
                Editable="True" EditType="TextBox" TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Team Red Card" DataField="TeamRedCard" DataType="Int"
                Editable="True" TextAlign="Center" EditType="TextBox" />
        </Columns>
        <HeaderGroups>
            <cc1:JQGridHeaderGroup StartColumnName="TeamGoalFor" NumberOfColumns="3" TitleText="TeamHome" />
        </HeaderGroups>
        <AppearanceSettings ShrinkToFit="True" />
        <HierarchySettings HierarchyMode="ParentAndChild" />
        <ClientSideEvents SubGridRowExpanded="showHomePlayerGrid"></ClientSideEvents>
    </cc1:JQGrid>
    <cc1:JQGrid ID="JqgridHomePlayer" runat="server" OnDataRequesting="JqgridHomePlayer_DataRequesting"
        Height="100%" Width="420" OnRowEditing="JqgridHomePlayer_RowEditing">
        <Columns>
            <cc1:JQGridColumn DataField="PlayerMatchId" PrimaryKey="True" Visible="False" DataType="Int" />
            <cc1:JQGridColumn HeaderText="Edit" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                Width="80" TextAlign="Center" Searchable="False" />
            <cc1:JQGridColumn HeaderText="Player Condition" DataField="PlayerCondition" DataType="String"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Number" DataField="PlayerNumber" DataType="Int" Editable="True"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Name" DataField="PlayerName" DataType="String" Editable="True"
                TextAlign="Center" />
        </Columns>
        <HierarchySettings HierarchyMode="Child" />
        <PagerSettings PageSize="100"></PagerSettings>
    </cc1:JQGrid>
    <cc1:JQGrid ID="JqgridAwayTeam" runat="server" OnDataRequesting="JqgridAwayTeam_DataRequesting"
        Height="100%" Width="465" OnRowEditing="JqgridAwayTeam_RowEditing">
        <Columns>
            <cc1:JQGridColumn DataField="TeamMatchId" PrimaryKey="True" Visible="False" DataType="Int" />
            <cc1:JQGridColumn HeaderText="Edit" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                Width="80" TextAlign="Center" Searchable="False" />
            <cc1:JQGridColumn HeaderText="Team Goal" DataField="TeamGoalFor" DataType="Int" Editable="True"
                TextAlign="Center" EditType="TextBox" />
            <cc1:JQGridColumn HeaderText="Team Yellow Card" DataField="TeamYellowCard" DataType="Int"
                Editable="True" TextAlign="Center" EditType="TextBox" />
            <cc1:JQGridColumn HeaderText="Team Red Card" DataField="TeamRedCard" DataType="Int"
                Editable="True" TextAlign="Center" EditType="TextBox" />
        </Columns>
        <HeaderGroups>
            <cc1:JQGridHeaderGroup StartColumnName="TeamGoalFor" NumberOfColumns="3" TitleText="TeamAway" />
        </HeaderGroups>
        <ClientSideEvents SubGridRowExpanded="showAwayPlayerGrid"></ClientSideEvents>
        <HierarchySettings HierarchyMode="ParentAndChild" />
    </cc1:JQGrid>
    <cc1:JQGrid ID="JqgridAwayPlayer" runat="server" OnDataRequesting="JqgridAwayPlayer_DataRequesting"
        Height="100%" Width="420" OnRowEditing="JqgridAwayPlayer_RowEditing">
        <Columns>
            <cc1:JQGridColumn DataField="PlayerMatchId" PrimaryKey="True" Visible="False" DataType="Int" />
            <cc1:JQGridColumn HeaderText="Edit" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                Width="80" TextAlign="Center" Searchable="False" />
            <cc1:JQGridColumn HeaderText="Player Condition" DataField="PlayerCondition" DataType="String"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Player Number" DataField="PlayerNumber" DataType="Int"
                Editable="True" TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Player Name" DataField="PlayerName" DataType="String"
                Editable="True" TextAlign="Center" />
        </Columns>
        <HierarchySettings HierarchyMode="Child" />
        <PagerSettings PageSize="100"></PagerSettings>
    </cc1:JQGrid>
    <asp:ObjectDataSource ID="LeagueDataSource" DataObjectTypeName="thaitae.lib.League"
        SelectMethod="SelectLeagueItems" TypeName="thaitae.lib.Page.LeagueHelper" runat="server">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TeamDataSource" DataObjectTypeName="" SelectMethod="ListTeamItems"
        TypeName="thaitae.lib.Page.TeamHelper" runat="server">
        <SelectParameters>
            <asp:SessionParameter Name="SeasonId" SessionField="SeasonId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SeasonDataSource" DataObjectTypeName="thaitae.lib.Season"
        SelectMethod="ListSeasonItems" TypeName="thaitae.lib.Page.SeasonHelper" runat="server">
        <SelectParameters>
            <asp:SessionParameter Name="LeagueId" SessionField="LeagueId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>