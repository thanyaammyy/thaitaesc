<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="ForgetPassword.aspx.cs" Inherits="Thaitae.Backend.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <h2>
        Forget password</h2>
    <asp:panel id="Panel1" runat="server" defaultbutton="btnSubmit">
        <div>
            Please enter email :
            <asp:textbox id="txtEmail" runat="server" width="200px">
            </asp:textbox>
            <asp:regularexpressionvalidator id="validatorCheckValidEmail" runat="server" cssclass="IconValidationNew"
                errormessage="RegularExpressionValidator" controltovalidate="txtEmail" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Please enter valid email.</asp:regularexpressionvalidator>
        </div>
        <div>
            <asp:button id="btnSubmit" runat="server" text="Send" onclick="btnSubmit_Click" />
        </div>
        <div>
            <asp:label id="lblResult" runat="server" text="Email has been sent." visible="False">
            </asp:label>
        </div>
    </asp:panel>
</asp:content>