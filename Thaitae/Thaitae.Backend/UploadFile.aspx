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
        <asp:fileupload id="FileUpload1" runat="server" width="250px" />
        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="FileUpload1"
            display="Dynamic" errormessage="Please specify an image file." setfocusonerror="True"
            validationgroup="Group1">
        </asp:requiredfieldvalidator>
        <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" controltovalidate="FileUpload1"
            errormessage="Please specify an image file." setfocusonerror="True" validationexpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp))$"
            display="Dynamic" validationgroup="Group1">
        </asp:regularexpressionvalidator>
        <asp:label id="lblMessage" runat="server" width="416px" font-size="10" font-name="verdana">
        </asp:label><br />
        <asp:button id="btnSave" runat="server" text="Upload" validationgroup="Group1" onclick="btnSave_Click">
        </asp:button>
    </div>
    </form>
</body>
</html>