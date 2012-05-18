<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="MatchManagement.aspx.cs" Inherits="Thaitae.Backend.MatchManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#test1').datetimepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:JQDropDownList ID="Jqdropdownlist1" runat="server" Width="100">
    </cc1:JQDropDownList>
    <cc1:JQDropDownList ID="Jqdropdownlist2" runat="server" Width="150">
    </cc1:JQDropDownList>
    <cc1:JQGrid ID="JqgridMatch1" runat="server" AutoWidth="True" OnRowEditing="JqgridMatch1_RowEditing"
        OnRowDeleting="JqgridMatch1_RowDeleting" OnRowAdding="JqgridMatch1_RowAdding">
        <Columns>
            <cc1:JQGridColumn DataField="MatchId" PrimaryKey="True" Width="55" Visible="False" />
            <cc1:JQGridColumn HeaderText="Edit Actions" EditActionIconsColumn="true" Width="50"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Home Team " DataField="TeamHomeId" Editable="True"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Away Team " DataField="TeamAwayId" Editable="True"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Match Date" EditorControlID="MatchDate1" DataField="MatchDate"
                Editable="True" EditType="DatePicker" TextAlign="Center" />
        </Columns>
        <AddDialogSettings CloseAfterAdding="False" />
        <EditDialogSettings CloseAfterEditing="True" />
        <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
            ShowRefreshButton="True" ShowSearchButton="True" />
        <AppearanceSettings ShowRowNumbers="true" />
    </cc1:JQGrid>
    <input type="text" id="test1" />
    <cc1:JQDatePicker runat="server" ID="MatchDate1" DateFormat="dd/MM/yyy H:mm:ss" DisplayMode="ControlEditor"
        ShowOn="Both" />
</asp:Content>