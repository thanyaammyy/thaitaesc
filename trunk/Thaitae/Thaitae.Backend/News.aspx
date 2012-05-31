<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="News.aspx.cs" Inherits="Thaitae.Backend.News" %>

<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web, Version=4.4.0.0, Culture=neutral, PublicKeyToken=e2819dc449af3295" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.uploadify-3.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function getUploadDify() {
            $("#Picture").uploadify({
                'swf': 'Scripts/uploadify.swf',
                'uploader': 'Upload.ashx'
            });
        }

        function uploadFile() {
            $('#Picture').uploadifyUpload();
            return false;
        }

        function createTextArea(value, editOptions) {
            var textarea = $("<textarea>", { id: "newsCont", cols: "100", rows: "10", value: value });
            return textarea;
        }

        function getTextAreaValue(elem) {
            return $(elem).val();
        }
        function createFile(value, editOptions) {
            var file = $("<input>", { type: "file", id: "filePicture" });
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
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
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
            <cc1:JQGridColumn HeaderText="Picture" DataField="Picture" Editable="True" Visible="False"
                EditType="Custom" EditTypeCustomCreateElement="createFile" EditTypeCustomGetValue="getFileValue"
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
        <ClientSideEvents AfterAddDialogShown="getUploadDify" AfterEditDialogShown="getUploadDify"
            BeforeSubmitCell="uploadFile"></ClientSideEvents>
    </cc1:JQGrid>
</asp:content>