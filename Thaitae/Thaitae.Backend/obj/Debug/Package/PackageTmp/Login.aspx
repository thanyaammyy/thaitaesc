<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Thaitae.Backend.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <div style="padding-left: 100px">
        <asp:login id="LoginUser" runat="server" enableviewstate="false" renderoutertable="false"
            onloggedin="LoginUser_LoggedIn">
            <layouttemplate>
            <div style="background-color: #F7F6F3; border-style: solid; border-width: 1px; font-size: 15px; font-family: Verdana; width: 280px;" >
            <div style="padding: 3px">
            <div style="text-align: center; background-color: darkgreen; color: white"><b>Log In</b></div>
                    <table>
                        <tr>
                            <td style="width: 100px; text-align: right">
                                <asp:Label  ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User name:</asp:Label>
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
                                <asp:TextBox Width="120px" ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                             <asp:CheckBox ID="RememberMe" runat="server"/>
                             <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe">Remember me.</asp:Label>
                             </td>
                        </tr>
                    </table>
                    <div style="text-align: center">
                            <asp:Button backcolor="#FFFBFF" bordercolor="#CCCCCC" borderstyle="Solid" borderwidth="1px"
            font-names="Verdana" font-size="13px" forecolor="#284775" ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>
            </div>
            </div>
            </div>
            <span class="failureNotification" style="color: red">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ForeColor="red" ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                 ValidationGroup="LoginUserValidationGroup"/>
        </layouttemplate>
        </asp:login>
        <asp:label id="Label1" runat="server" forecolor="Red" text="You Have no right to access any property, please contact administrator."
            visible="False"></asp:label>
        <br />
        <div style="width: 305px; text-align: center">
            <asp:hyperlink id="hplForgetPassword" runat="server" navigateurl="~/ForgetPassword.aspx">Forgot Password?</asp:hyperlink>
        </div>
    </div>
</asp:content>