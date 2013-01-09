<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="CustomMatchManagement.aspx.cs" Inherits="Thaitae.Backend.CustomMatchManagement" %>

<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function bindCalendarDialog() {
            $('input[name$="MatchDate"]').blur();
            $('input[name$="MatchDate"]').datetimepicker();
        }

        function bindCalendarDialog2() {
            $('input#MatchDate').blur();
            $('input#MatchDate').datetimepicker();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Custom Match Management</h2>
    <asp:UpdatePanel ID="updateTeamPanel" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:DropDownList runat="server" ID="ddlLeague" DataSourceID="LeagueDataSource" DataTextField="LeagueName"
                DataValueField="LeagueId" AutoPostBack="True" OnSelectedIndexChanged="ddlLeague_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlSeason" DataSourceID="SeasonDataSource" DataTextField="SeasonName"
                DataValueField="SeasonId" AutoPostBack="True" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged">
            </asp:DropDownList>

            <cc1:JQGrid ID="JqgridMatch1" runat="server" AutoWidth="True" OnRowEditing="JqgridMatch1_RowEditing"
                OnRowDeleting="JqgridMatch1_RowDeleting" OnRowAdding="JqgridMatch1_RowAdding"
                Height="100%">
                <Columns>
                    <cc1:JQGridColumn DataField="MatchId" PrimaryKey="True" Visible="False" />
                    <cc1:JQGridColumn DataField="SeasonId" Visible="False" />
                    <cc1:JQGridColumn HeaderText="Edit" Width="40" TextAlign="Center" EditActionIconsColumn="True" />
                    <cc1:JQGridColumn HeaderText="Home Team" DataType="String" DataField="TeamHomeIdNameExtend"
                        TextAlign="Center" EditType="DropDown" EditorControlID="ddlTeam" Editable="True" />
                    <cc1:JQGridColumn HeaderText="Home Score" DataType="Int" DataField="TeamHomeScore"
                        TextAlign="Center" Editable="True" NullDisplayText="0" />
                    <cc1:JQGridColumn HeaderText="Home P.Score" DataType="Int" DataField="TeamHomePScore"
                        TextAlign="Center" Editable="True" NullDisplayText="0" />
                    <cc1:JQGridColumn HeaderText=" " Width="10" DataType="Int" DataField="Dash" TextAlign="Center"
                        Editable="false" />
                    <cc1:JQGridColumn HeaderText="Away Score" DataType="Int" DataField="TeamAwayScore"
                        TextAlign="Center" Editable="True" NullDisplayText="0" />
                    <cc1:JQGridColumn HeaderText="Away P.Score" DataType="Int" DataField="TeamAwayPScore"
                        TextAlign="Center" Editable="True" NullDisplayText="0" />
                    <cc1:JQGridColumn HeaderText="Away Team" DataType="String" DataField="TeamAwayIdNameExtend"
                        TextAlign="Center" EditType="DropDown" EditorControlID="ddlTeam" Editable="True" />
                    <cc1:JQGridColumn HeaderText="Match Date" DataType="DateTime" DataFormatString="{0:dd/MM/yyyy HH:mm}"
                        DataField="MatchDate" EditType="TextBox" Editable="True" TextAlign="Center" />
                </Columns>
                <AddDialogSettings CloseAfterAdding="True" />
                <EditDialogSettings CloseAfterEditing="True" />
                <ToolBarSettings ShowRefreshButton="True" ShowAddButton="True" ShowDeleteButton="True"
                    ShowEditButton="True" />
                <PagerSettings PageSize="100" />
                <AppearanceSettings ShowRowNumbers="true" />
                <ClientSideEvents RowSelect="bindCalendarDialog" AfterAddDialogShown="bindCalendarDialog2"
                    AfterEditDialogShown="bindCalendarDialog2" />
            </cc1:JQGrid>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:DropDownList runat="server" ID="ddlTeam" DataSourceID="TeamDataSource" DataTextField="TeamName"
        DataValueField="TeamId">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="LeagueDataSource" DataObjectTypeName="thaitae.lib.League"
        SelectMethod="SelectCustomLeagueItems" TypeName="thaitae.lib.Page.LeagueHelper" runat="server"></asp:ObjectDataSource>
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