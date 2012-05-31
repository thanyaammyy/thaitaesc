<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="TestUpload.aspx.cs" Inherits="Thaitae.Backend.TestUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$("#<%=FileUpload1.ClientID%>").uploadify({
				'uploader': 'testUploadify/uploadify.swf',
				'script': 'Upload.ashx',
				'cancelImg': 'testUploadify/cancel.png',
				'folder': 'uploads',
				'auto': true
			});

		});		
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:FileUpload ID="FileUpload1" runat="server" />
</asp:Content>
