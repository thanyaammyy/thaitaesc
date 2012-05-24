<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="MatchManagement.aspx.cs" Inherits="Thaitae.Backend.MatchManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function bindCalendarDialog() {
            $('input[id][name$="MatchDate"]').datetimepicker();
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
                DataValueField="TeamId" AutoPostBack="True">
            </asp:DropDownList>
            <cc1:JQGrid ID="JqgridMatch1" runat="server" AutoWidth="True" OnRowAdding="JqgridMatch1_RowAdding"
                OnRowDeleting="JqgridMatch1_RowDeleting" OnRowEditing="JqgridMatch1_RowEditing">
                <Columns>
                    <cc1:JQGridColumn DataField="MatchId" PrimaryKey="True" Visible="False" />
                    <cc1:JQGridColumn DataField="SeasonId" Visible="False" />
                    <cc1:JQGridColumn HeaderText="Edit Actions" EditActionIconsColumn="true" Width="50"
                        TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Home Team" DataType="String" DataField="TeamHomeIdName"
                        EditType="DropDown" EditorControlID="ddlTeam" Editable="True" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Away Team" DataType="String" DataField="TeamAwayIdName"
                        EditType="DropDown" EditorControlID="ddlTeam" Editable="True" TextAlign="Center" />
                    <cc1:JQGridColumn HeaderText="Match Date" DataType="DateTime" DataFormatString="{0:dd/MM/yyyy HH:mm}"
                        DataField="MatchDate" EditType="TextBox" Editable="True" TextAlign="Center" />
                </Columns>
                <AddDialogSettings CloseAfterAdding="True" />
                <EditDialogSettings CloseAfterEditing="True" />
                <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
                    ShowRefreshButton="True" ShowSearchButton="True" />
                <AppearanceSettings ShowRowNumbers="true" />
                <ClientSideEvents AfterAddDialogShown="bindCalendarDialog" RowSelect="bindCalendarDialog">
                </ClientSideEvents>
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