<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Thaitae.Backend.Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrator Login Page</title>
    <link href="Styles/backend.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 16% auto auto auto; width: 300px">
        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
            <LayoutTemplate>
                <div style="background-color: #F7F6F3; border-style: solid; border-width: 1px; font-size: 15px;
                    font-family: Verdana; width: 280px;">
                    <div style="padding: 3px">
                        <div style="text-align: center; background-color: darkgreen; color: white">
                            <b>Log In</b></div>
                        <table>
                            <tr>
                                <td style="width: 100px; text-align: right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="120px" ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="120px" ID="Password" runat="server" CssClass="passwordEntry"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:CheckBox ID="RememberMe" runat="server" />
                                    <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe">Remember me.</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div style="text-align: center">
                            <asp:Button BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                                Font-Names="Verdana" Font-Size="13px" ForeColor="#284775" ID="LoginButton" runat="server"
                                CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup" />
                        </div>
                    </div>
                    <span class="failureNotification" style="color: red">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ForeColor="red" ID="LoginUserValidationSummary" runat="server"
                        CssClass="failureNotification" ValidationGroup="LoginUserValidationGroup" />
                    <%--<div style="width: 305px; text-align: center">
            <asp:hyperlink id="hplForgetPassword" runat="server" navigateurl="~/ForgetPassword.aspx">Forgot Password?</asp:hyperlink>
            </div>--%>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div>
    </form>
</body>
</html>