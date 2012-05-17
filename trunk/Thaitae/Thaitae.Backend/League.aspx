<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="League.aspx.cs" Inherits="Thaitae.Backend.League" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <cc1:JQGrid ID="JqgridLeague1" runat="server" AutoWidth="True" OnRowEditing="JqgridLeague1_RowEditing" OnRowDeleting="JqgridLeague1_RowDeleting" OnRowAdding="JqgridLeague1_RowAdding">
        <Columns>
            <cc1:JQGridColumn HeaderText="Edit Actions"  EditActionIconsColumn="true"  Width="50" />
            <cc1:JQGridColumn DataField="LeagueId"  PrimaryKey="True" Width="55" Visible="False"/>
            <cc1:JQGridColumn DataField="LeagueName" Editable="True"/>
            <cc1:JQGridColumn DataField="LeagueTypeName" Editable="True" EditType="DropDown" EditValues="4:Normal League;8:Champion League;12:FA Cup;16:Custom League"/>
            <cc1:JQGridColumn DataField="LeagueDesc" Editable="True"/>
            <cc1:JQGridColumn DataField="ActiveName" Editable="True" EditType="DropDown" EditValues="0:InActive;1:Active"/>
        </Columns>
        <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True" ShowRefreshButton="True" ShowSearchButton="True" />
        <AppearanceSettings ShowRowNumbers="true" /> 
    </cc1:JQGrid>
</asp:content>