<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="League.aspx.cs" Inherits="Thaitae.Backend.League" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function bindFileUpload() {
            $('#ShowPictureThumb').bind('click', function () {
                var grid = $("#<%=JqgridLeague1.ClientID%>");
                var rowid = grid.jqGrid('getGridParam', 'selrow');
                var page = 'UploadFile.aspx?leagueid=' + rowid;
                var $dialog = $('<div></div>')
                .html('<iframe scrolling="no" style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: false,
                    height: 200,
                    width: 300,
                    title: "Upload File"
                });
                $dialog.dialog('open');
            });
        }

        function disableFileUpload() {
            $('#ShowPictureThumb').hide();
        }

        function createFile(value, editOptions) {
            var file = $("<input>", { type: "button", id: "filePicture", value: "Upload File" });
            return file;
        }
        function getFileValue(elem) {
            return $(elem).val();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        League Management</h2>
    <cc1:JQGrid ID="JqgridLeague1" runat="server" AutoWidth="True" OnRowEditing="JqgridLeague1_RowEditing"
        Height="100%" OnRowDeleting="JqgridLeague1_RowDeleting" OnRowAdding="JqgridLeague1_RowAdding">
        <Columns>
            <cc1:JQGridColumn DataField="LeagueId" PrimaryKey="True" Width="55" Visible="False" />
            <cc1:JQGridColumn HeaderText="League Name" DataField="LeagueName" Editable="True"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="League Type" EditType="DropDown" DataField="LeagueTypeName"
                EditValues="4:Normal" Editable="True" TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Description" DataField="LeagueDesc" Editable="True"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Status" DataField="ActiveName" Editable="True" EditType="DropDown"
                EditValues="0:InActive;1:Active" TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Icon" DataField="ShowPictureThumb" Editable="True"
                Visible="True" EditType="Custom" EditTypeCustomCreateElement="createFile" EditTypeCustomGetValue="getFileValue"
                TextAlign="Center" />
        </Columns>
        <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
            ShowRefreshButton="True" ShowSearchButton="True" />
        <AppearanceSettings ShowRowNumbers="true" />
        <DeleteDialogSettings Width="516" LeftOffset="497" TopOffset="241" DeleteMessage="ถ้าคุณลบ League ข้อมูล team, season, match ของลีคนี้จะถูกลบทั้งหมด คุณยังต้องการลบ League นี้หรือไม่">
        </DeleteDialogSettings>
        <AddDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
            CloseAfterAdding="True" Caption="Add League" ClearAfterAdding="True"></AddDialogSettings>
        <EditDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
            CloseAfterEditing="True" Caption="Edit League"></EditDialogSettings>
        <ClientSideEvents AfterEditDialogShown="bindFileUpload" AfterAddDialogShown="disableFileUpload">
        </ClientSideEvents>
    </cc1:JQGrid>
</asp:Content>