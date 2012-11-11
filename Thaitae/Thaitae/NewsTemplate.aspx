<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
    CodeBehind="NewsTemplate.aspx.cs" Inherits="Thaitae.NewsTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="NewsTopic">
        <h2>
            <%=SelectedNews.newsTopic%></h2>
    </div>
    <br />
    <img class="NewsImage" src="<%=SelectedNews.picture%>" />
    <br />
    <br />
    <p align="justify" style="word-break: break-all; margin: auto; width: 600px">
        <%=SelectedNews.newsContent%>
    </p>
    <br />
</asp:Content>