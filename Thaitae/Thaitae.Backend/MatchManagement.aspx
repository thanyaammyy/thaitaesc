﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="MatchManagement.aspx.cs" Inherits="Thaitae.Backend.MatchManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function setGridCss() {
            $(".ui-jqgrid-bdiv").css("overflow-x", "hidden");
        }
        function bindCalendarDialog() {
            $('input[id][name$="MatchDate"]').blur();
            $('input[id][name$="MatchDate"]').datetimepicker();
        }
        function showHomePlayerGrid(subgrid_id, row_id) {
            showSubGrid_JqgridHomePlayer(subgrid_id, row_id, "", "JqgridHomePlayer");
            $("#p_" + subgrid_id + "_tJqgridHomePlayer").hide();
            setGridCss();
        }

        function showAwayPlayerGrid(subgrid_id, row_id) {
            showSubGrid_JqgridAwayPlayer(subgrid_id, row_id, "", "JqgridAwayPlayer");
            $("#p_" + subgrid_id + "_tJqgridAwayPlayer").hide();
            setGridCss();
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
            setGridCss();
            grid_id = subgrid_id;
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
            <asp:DropDownList runat="server" ID="ddlTeam" DataSourceID="TeamDataSource" DataTextField="TeamName"
                DataValueField="TeamName">
            </asp:DropDownList>
            <asp:Button ID="GenMatch" ClientIDMode="Static" runat="server" OnClick="Button1_Click"
                Text="Generate Match"></asp:Button>
            <cc1:JQGrid ID="JqgridMatch1" runat="server" Width="1000" OnRowEditing="JqgridMatch1_RowEditing"
                OnSearching="JqgridMatch1_Searching" Height="100%">
                <Columns>
                    <cc1:JQGridColumn DataField="MatchId" PrimaryKey="True" Visible="False" />
                    <cc1:JQGridColumn DataField="SeasonId" Visible="False" />
                    <cc1:JQGridColumn HeaderText="Set Date" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                        Width="30" TextAlign="Center" Searchable="False" />
                    <cc1:JQGridColumn HeaderText="Home Team" DataType="String" DataField="TeamHomeIdName"
                        TextAlign="Center" Searchable="True" SearchType="DropDown" SearchControlID="ddlTeam"
                        SearchToolBarOperation="Contains" />
                    <cc1:JQGridColumn HeaderText="Away Team" DataType="String" DataField="TeamAwayIdName"
                        TextAlign="Center" Searchable="True" SearchType="DropDown" SearchControlID="ddlTeam"
                        SearchToolBarOperation="Contains" />
                    <cc1:JQGridColumn HeaderText="Match Date" DataType="DateTime" DataFormatString="{0:dd/mm/yyyy HH:mm}"
                        DataField="MatchDate" EditType="TextBox" Editable="True" TextAlign="Center" Searchable="False" />
                </Columns>
                <ToolBarSettings ShowRefreshButton="True" ShowSearchToolBar="True" />
                <AppearanceSettings ShowRowNumbers="true" />
                <ClientSideEvents RowSelect="bindCalendarDialog" SubGridRowExpanded="showSubGrids"
                    LoadComplete="setGridCss" />
                <HierarchySettings HierarchyMode="Parent" />
            </cc1:JQGrid>
            <cc1:JQGrid ID="JqgridHomeTeam" runat="server" OnDataRequesting="JqgridHomeTeam_DataRequesting"
                Height="100%" Width="465" OnRowEditing="JqgridHomeTeam_RowEditing" EditInlineCellSettings="">
                <Columns>
                    <cc1:JQGridColumn DataField="TeamMatchId" PrimaryKey="True" Visible="False" DataType="Int" />
                    <cc1:JQGridColumn HeaderText="Edit" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                        Width="40" TextAlign="Center" Searchable="False" />
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
                <HierarchySettings HierarchyMode="ParentAndChild" />
                <ClientSideEvents RowSelect="editHomeTeamRow" SubGridRowExpanded="showHomePlayerGrid">
                </ClientSideEvents>
            </cc1:JQGrid>
            <cc1:JQGrid ID="JqgridHomePlayer" runat="server" OnDataRequesting="JqgridHomePlayer_DataRequesting"
                Height="100%" OnRowEditing="JqgridHomePlayer_RowEditing">
                <Columns>
                    <cc1:JQGridColumn DataField="PlayerMatchId" PrimaryKey="True" Visible="False" DataType="Int" />
                    <cc1:JQGridColumn HeaderText="Edit" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                        Width="40" TextAlign="Center" Searchable="False" />
                    <cc1:JQGridColumn HeaderText="Player Condition" DataField="PlayerCondition" DataType="String"
                        TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Player Number" DataField="PlayerName" DataType="Int"
                        Editable="True" TextAlign="Center" />
                </Columns>
                <HierarchySettings HierarchyMode="Child" />
            </cc1:JQGrid>
            <cc1:JQGrid ID="JqgridAwayTeam" runat="server" OnDataRequesting="JqgridAwayTeam_DataRequesting"
                Height="100%" Width="465" OnRowEditing="JqgridAwayTeam_RowEditing">
                <Columns>
                    <cc1:JQGridColumn DataField="TeamMatchId" PrimaryKey="True" Visible="False" DataType="Int" />
                    <cc1:JQGridColumn HeaderText="Edit" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                        Width="40" TextAlign="Center" Searchable="False" />
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
                <ClientSideEvents RowSelect="editAwayTeamRow" SubGridRowExpanded="showAwayPlayerGrid">
                </ClientSideEvents>
                <HierarchySettings HierarchyMode="ParentAndChild" />
            </cc1:JQGrid>
            <cc1:JQGrid ID="JqgridAwayPlayer" runat="server" OnDataRequesting="JqgridAwayPlayer_DataRequesting"
                Height="100%" OnRowEditing="JqgridAwayPlayer_RowEditing">
                <Columns>
                    <cc1:JQGridColumn DataField="PlayerMatchId" PrimaryKey="True" Visible="False" DataType="Int" />
                    <cc1:JQGridColumn HeaderText="Edit" EditActionIconsColumn="true" EditActionIconsDeleteEnabled="False"
                        Width="40" TextAlign="Center" Searchable="False" />
                    <cc1:JQGridColumn HeaderText="Player Condition" DataField="PlayerCondition" DataType="String"
                        Editable="True" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Player Number" DataField="PlayerName" DataType="Int"
                        Editable="True" TextAlign="Center" />
                </Columns>
                <HierarchySettings HierarchyMode="Child" />
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
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