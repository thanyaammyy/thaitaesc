﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="League.aspx.cs" Inherits="Thaitae.Backend.League" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
		<script type="text/javascript">
			function createFile(value, editOptions) {
				var file = $("<input>", { type: "file", id: "filePicture", width: "200px", value: value });
				return file;
			}
			function getFileValue(elem) {
				return $(elem).val();
			}
		</script>
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <h2>
        League Management</h2>
    <cc1:JQGrid ID="JqgridLeague1" runat="server" AutoWidth="True" OnRowEditing="JqgridLeague1_RowEditing" Height="100%"
        OnRowDeleting="JqgridLeague1_RowDeleting" OnRowAdding="JqgridLeague1_RowAdding">
        <Columns>
            <cc1:JQGridColumn DataField="LeagueId" PrimaryKey="True" Width="55" Visible="False" />
           <cc1:JQGridColumn HeaderText="League Name" DataField="LeagueName" Editable="True"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="League Type" EditType="DropDown" DataField="LeagueTypeName"
                EditValues="4:Normal" Editable="True"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Description" DataField="LeagueDesc" Editable="True"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Status" DataField="ActiveName" Editable="True" EditType="DropDown"
                EditValues="0:InActive;1:Active" TextAlign="Center" />
			<cc1:JQGridColumn HeaderText="Icon" DataField="Picture" Editable="True" Visible="True"
                EditType="Custom" EditTypeCustomCreateElement="createFile" EditTypeCustomGetValue="getFileValue"
                TextAlign="Center" />
        </Columns>
        <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
            ShowRefreshButton="True" ShowSearchButton="True" />
        <AppearanceSettings ShowRowNumbers="true" />
		<DeleteDialogSettings Width="516" LeftOffset="497" TopOffset="241" DeleteMessage="ถ้าคุณลบ League ข้อมูล team, season, match ของลีคนี้จะถูกลบทั้งหมด คุณยังต้องการลบ League นี้หรือไม่"></DeleteDialogSettings>
		<AddDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
			CloseAfterAdding="True" Caption="Add League" ClearAfterAdding="True"></AddDialogSettings>
		<EditDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
			CloseAfterEditing="True" Caption="Edit League"></EditDialogSettings>
    </cc1:JQGrid>
</asp:content>