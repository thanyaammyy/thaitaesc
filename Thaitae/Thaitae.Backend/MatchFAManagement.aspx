<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="MatchFAManagement.aspx.cs" Inherits="Thaitae.Backend.MatchFAManagement" %>

<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function bindCalendarDialog() {
            $('input[id][name$="MatchDate"]').blur();
            $('input[id][name$="MatchDate"]').datetimepicker();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        FA Match Management</h2>
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
        <ClientSideEvents RowSelect="bindCalendarDialog" />
    </cc1:JQGrid>
</asp:Content>