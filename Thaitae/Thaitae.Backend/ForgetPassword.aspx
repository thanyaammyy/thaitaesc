<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="ForgetPassword.aspx.cs" Inherits="Thaitae.Backend.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Forget password</h2>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
        <div>
            Please enter email :
            <asp:TextBox ID="txtEmail" runat="server" Width="200px">
            </asp:TextBox>
            <asp:RegularExpressionValidator ID="validatorCheckValidEmail" runat="server" CssClass="IconValidationNew"
                ErrorMessage="RegularExpressionValidator" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Please enter valid email.</asp:RegularExpressionValidator>
        </div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Send" OnClick="btnSubmit_Click" />
        </div>
        <div>
            <asp:Label ID="lblResult" runat="server" Text="Email has been sent." Visible="False">
            </asp:Label>
        </div>
    </asp:Panel>
</asp:Content>