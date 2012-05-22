<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="MatchManagement.aspx.cs" Inherits="Thaitae.Backend.MatchManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:JQGrid ID="JqgridMatch1" runat="server" DataSourceID="objectMatchData" AutoWidth="True">
        <Columns>
            <cc1:JQGridColumn DataField="MatchId" PrimaryKey="True" Visible="False" />
            <cc1:JQGridColumn DataField="SeasonId" Visible="False" />
            <cc1:JQGridColumn HeaderText="Edit Actions" EditActionIconsColumn="true" Width="50"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Match Date" DataType="DateTime" DataFormatString="{0:dd-MM-yyyy}"
                EditorControlID="MatchDate1" DataField="MatchDate" EditType="DatePicker" Editable="True"
                TextAlign="Center" />
        </Columns>
        <AddDialogSettings CloseAfterAdding="True" />
        <EditDialogSettings CloseAfterEditing="True" />
        <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
            ShowRefreshButton="True" ShowSearchButton="True" />
        <AppearanceSettings ShowRowNumbers="true" />
    </cc1:JQGrid>
    <cc1:JQDatePicker runat="server" ID="MatchDate1" DateFormat="dd/MM/yyyy" DisplayMode="ControlEditor"
        ShowOn="Both" ChangeMonth="True" ChangeYear="True" />
    <asp:ObjectDataSource ID="objectMatchData" runat="server" DataObjectTypeName="thaitae.lib.Match"
        SelectMethod="SelectItems" TypeName="thaitae.lib.Page.MatchHelper"></asp:ObjectDataSource>
</asp:Content>