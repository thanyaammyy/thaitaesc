<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="MatchManagement.aspx.cs" Inherits="Thaitae.Backend.MatchManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:JQDropDownList ID="Jqdropdownlist1" runat="server" Width="100" >
    </cc1:JQDropDownList>
    <cc1:JQDropDownList ID="Jqdropdownlist2" runat="server" Width="150">
    </cc1:JQDropDownList>
</asp:Content>
