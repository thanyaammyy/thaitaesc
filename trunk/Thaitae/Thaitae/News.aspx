<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
    CodeBehind="News.aspx.cs" Inherits="Thaitae.News" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>ติดตามข่าวสารไทยเตะได้ที่นี่ l www.thaitaesc.com</title>
    <script type="text/javascript">
        function loadComplete() {
            $('.ui-jqgrid-hdiv').hide();
            //$('tr[role=row]').removeClass('jqgrow ui-row-ltr');
        }

        function renderNews() {
            var grid = $("#<%=JQGridNews.ClientID%>");
            var newsId = grid.jqGrid('getGridParam', 'selrow');
            var url = "NewsTemplate.aspx?newsId=" + newsId;
            window.open(url, '_blank');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:JQGrid ID="JQGridNews" AutoWidth="True" runat="server" Height="100%">
        <Columns>
            <cc1:JQGridColumn DataField="newsId" PrimaryKey="True" Visible="False" />
            <cc1:JQGridColumn Width="20" DataField="NewsPicture" TextAlign="Center" />
            <cc1:JQGridColumn DataField="NewsImageTopicContent" TextAlign="Left" />
        </Columns>
        <ToolBarSettings ShowRefreshButton="True" />
        <AppearanceSettings ShowRowNumbers="true" />
        <PagerSettings PageSize="20"></PagerSettings>
        <ClientSideEvents RowSelect="renderNews" LoadComplete="loadComplete"></ClientSideEvents>
    </cc1:JQGrid>
</asp:Content>