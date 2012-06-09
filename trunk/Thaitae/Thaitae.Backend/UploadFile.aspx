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
        <asp:FileUpload ID="FileUpload1" runat="server" Width="250px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1"
            Display="Dynamic" ErrorMessage="Please specify an image file." SetFocusOnError="True"
            ValidationGroup="Group1">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1"
            ErrorMessage="Please specify an image file." SetFocusOnError="True" ValidationExpression="^.+\.((jpg)|(JPG)|(GIF)|(PNG)|(JPEG)|(BMP)|(gif)|(jpeg)|(png)|(bmp))$"
            Display="Dynamic" ValidationGroup="Group1">
        </asp:RegularExpressionValidator>
        <asp:Label ID="lblMessage" runat="server" Width="416px" Font-Size="10" font-name="verdana">
        </asp:Label><br />
        <asp:Button ID="btnSave" runat="server" Text="Upload" ValidationGroup="Group1" OnClick="btnSave_Click">
        </asp:Button>
    </div>
    </form>
</body>
</html>