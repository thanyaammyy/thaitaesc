<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Backend.Master"
    AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Thaitae.Backend.News" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function bindFileUpload() {
            $('#ShowPictureThumb').bind('click', function () {
                var grid = $("#<%=JqgridNews.ClientID%>");
                var rowid = grid.jqGrid('getGridParam', 'selrow');
                var page = 'UploadFile.aspx?newsid=' + rowid;
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

        function createTextArea(value, editOptions) {
            var textarea = $("<textarea>", { id: "newsCont", cols: "100", rows: "10", value: value });
            return textarea;
        }

        function getTextAreaValue(elem) {
            return $(elem).val();
        }
        function createFile(value, editOptions) {
            var file = $("<input>", { type: "button", id: "filePicture", value: "Upload File" });
            return file;
        }

        function getFileValue(elem) {
            return $(elem).val();
        }
        function createTextbox(value, editOptions) {
            var textbox = $("<input>", { type: "text", id: "topic", width: "300px", value: value });
            return textbox;
        }

        function getTextboxValue(elem) {
            return $(elem).val();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        News Management
    </h2>
    <cc1:JQGrid ID="JqgridNews" runat="server" AutoWidth="True" OnRowAdding="JqgridNews_RowAdding"
        OnRowDeleting="JqgridNews_RowDeleting" OnRowEditing="JqgridNews_RowEditing" Height="100%">
        <Columns>
            <cc1:JQGridColumn DataField="NewsId" PrimaryKey="True" Width="55" Visible="False" />
            <cc1:JQGridColumn HeaderText="News Type" EditType="DropDown" DataField="NewsTypeName"
                EditValues="1:Hot News;2:Scoop" Editable="True" TextAlign="Center" Width="30" />
            <cc1:JQGridColumn HeaderText="Topic" DataField="NewsTopic" EditType="Custom" EditTypeCustomCreateElement="createTextbox"
                EditTypeCustomGetValue="getTextboxValue" Editable="True" Width="90" TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Contents" EditType="Custom" EditTypeCustomCreateElement="createTextArea"
                EditTypeCustomGetValue="getTextAreaValue" DataField="NewsContent" Editable="True" />
            <cc1:JQGridColumn HeaderText="Picture" DataField="ShowPictureThumb" Editable="True"
                Visible="True" EditType="Custom" EditTypeCustomCreateElement="createFile" EditTypeCustomGetValue="getFileValue"
                TextAlign="Center" />
        </Columns>
        <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
            ShowRefreshButton="True" ShowSearchButton="True" />
        <AppearanceSettings ShowRowNumbers="true" />
        <DeleteDialogSettings LeftOffset="497" TopOffset="241"></DeleteDialogSettings>
        <AddDialogSettings Width="700" ClearAfterAdding="True" Modal="True" TopOffset="180"
            LeftOffset="300" Height="300" CloseAfterAdding="True" Caption="Add News"></AddDialogSettings>
        <EditDialogSettings Width="700" Modal="True" TopOffset="180" LeftOffset="300" Height="300"
            CloseAfterEditing="True" Caption="Edit News"></EditDialogSettings>
        <ClientSideEvents AfterEditDialogShown="bindFileUpload" AfterAddDialogShown="disableFileUpload">
        </ClientSideEvents>
    </cc1:JQGrid>
</asp:Content>