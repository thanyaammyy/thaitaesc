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
            <asp:DropDownList runat="server" ID="ddlLeague" DataSourceID="LeagueDataSource" DataTextField="LeagueName"
                DataValueField="LeagueId" AutoPostBack="True" OnSelectedIndexChanged="ddlLeague_SelectedIndexChanged">
            </asp:DropDownList>
            <cc1:JQGrid ID="JqgridSeason" AutoWidth="True" runat="server" OnRowAdding="JqgridSeason_RowAdding"
                Height="100%" OnRowDeleting="JqgridSeason_RowDeleting" OnRowEditing="JqgridSeason_RowEditing">
                <Columns>
                    <cc1:JQGridColumn DataField="SeasonId" PrimaryKey="True" Width="55" Visible="False" />
                    <cc1:JQGridColumn DataField="LeagueId" Visible="False" />
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
                <DeleteDialogSettings LeftOffset="497" TopOffset="241"></DeleteDialogSettings>
                <AddDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterAdding="True" Caption="Add Season" ClearAfterAdding="True"></AddDialogSettings>
                <EditDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterEditing="True" Caption="Edit Season"></EditDialogSettings>
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="LeagueDataSource" DataObjectTypeName="thaitae.lib.League"
        SelectMethod="SelectLeagueItemsWithGroupingChampionsLeague" TypeName="thaitae.lib.Page.LeagueHelper"
        runat="server"></asp:ObjectDataSource>
</asp:Content>