<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="MatchFAManagement.aspx.cs" Inherits="Thaitae.Backend.MatchFAManagement" %>

<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function bindCalendarDialog() {
            $('input[name$="FAMatchDate"]').blur();
            $('input[name$="FAMatchDate"]').datetimepicker();
        }

        function bindCalendarDialog2() {
            $('input#FAMatchDate').blur();
            $('input#FAMatchDate').datetimepicker();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        FA Match Management</h2>
    <cc1:JQGrid ID="JqgridMatch1" runat="server" AutoWidth="True" OnRowEditing="JqgridMatch1_RowEditing"
        OnRowDeleting="JqgridMatch1_RowDeleting" OnRowAdding="JqgridMatch1_RowAdding"
        Height="100%">
        <Columns>
            <cc1:JQGridColumn DataField="FAMatchId" PrimaryKey="True" Visible="False" />
            <cc1:JQGridColumn HeaderText="Edit" Width="40" TextAlign="Center" EditActionIconsColumn="True" />
            <cc1:JQGridColumn HeaderText="Home Team" DataType="String" DataField="TeamHomeName"
                TextAlign="Center" Editable="True" />
            <cc1:JQGridColumn HeaderText="Home Score" DataType="Int" DataField="TeamHomeScore"
                TextAlign="Center" Editable="True" NullDisplayText="0" />
            <cc1:JQGridColumn HeaderText=" " Width="10" DataType="Int" DataField="Dash" TextAlign="Center"
                Editable="false" />
            <cc1:JQGridColumn HeaderText="Away Score" DataType="Int" DataField="TeamAwayScore"
                TextAlign="Center" Editable="True" NullDisplayText="0" />
            <cc1:JQGridColumn HeaderText="Away Team" DataType="String" DataField="TeamAwayName"
                TextAlign="Center" Editable="True" />
            <cc1:JQGridColumn HeaderText="Match Date" DataType="DateTime" DataFormatString="{0:dd/MM/yyyy HH:mm}"
                DataField="FAMatchDate" EditType="TextBox" Editable="True" TextAlign="Center" />
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
</asp:Content>