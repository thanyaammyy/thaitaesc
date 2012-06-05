<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="Thaitae.Backend.UploadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            width: 249px;
            height: 65px;
        }
    </style>
</head>
<body style="width: 249px; height: 64px">
    <form id="form1" runat="server">
    <div>
        <input id="fileUpload" type="file" Runat="server" NAME="fileUpload"/><br/>
        <asp:label id="lblMessage" runat="server" Width="416px" Font-Size="10" Font-Name="verdana"></asp:label><br/> 
        <asp:button id="btnSave" runat="server" Text="Upload" onclick="btnSave_Click"></asp:button>
    </div>
    </form>
</body>
</html>
