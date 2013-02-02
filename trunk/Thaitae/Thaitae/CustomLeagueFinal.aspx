<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true" CodeBehind="CustomLeagueFinal.aspx.cs" Inherits="Thaitae.ChampionsLeagueFinal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .main {
            width: 100%;
            text-align: center;
        }

        .scorebox {
            background-color: darkkhaki;
            border-style: solid;
            border-width: 2px;
            border-color: darkgoldenrod;
            width: 100%;
        }

            .scorebox td {
                border-style: dashed;
                border-width: 1px;
                border-color: darkgoldenrod;
            }

        .header {
            background: maroon;
            font-weight: bold;
            font-size: 16px;
            color: white;
        }

        .borderInfo {
            border-width: 2px 2px 2px 2px;
            border-style: solid;
            border-color: maroon;
            width: 25%;
        }

        .info {
            width: 100%;
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>ผลการแข่งขัน <%=League.LeagueName%></h3>
    <table class="main">
        <tr class="header">
            <td>First Knockout Round</td>
            <td>Quarter Final</td>
            <td>Semi Final</td>
            <td>Final</td>
        </tr>
        <tr>
            <td class="borderInfo">
                <table class="info">
                    <% for (int i = 0; i < 8; i++)%>
                    <%{%>
                    <%if (Match[i] != null) %>
                    <%{%>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td><%=Match[i].TeamHomeNameWithStatus%></td>
                                    <td><%=Match[i].TeamHomeScore1%></td>
                                    <td><%=Match[i].TeamHomeScore2%></td>
                                </tr>
                                <tr>
                                    <td><%=Match[i].TeamAwayNameWithStatus%></td>
                                    <td><%=Match[i].TeamAwayScore1%></td>
                                    <td><%=Match[i].TeamAwayScore2%></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%}
                      else
                      {%>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>ยังไม่มีข้อมูล</td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <td>ยังไม่มีข้อมูล</td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%}%>
                    <%}%>
                </table>
            </td>
            <td class="borderInfo">
                <table class="info">
                    <% for (int i = 8; i < 12; i++)%>
                    <%{%>
                    <%if (Match[i] != null) %>
                    <%{%>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td><%=Match[i].TeamHomeNameWithStatus%></td>
                                    <td><%=Match[i].TeamHomeScore1%></td>
                                    <td><%=Match[i].TeamHomeScore2%></td>
                                </tr>
                                <tr>
                                    <td><%=Match[i].TeamAwayNameWithStatus%></td>
                                    <td><%=Match[i].TeamAwayScore1%></td>
                                    <td><%=Match[i].TeamAwayScore2%></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%}
                      else
                      {%>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>ยังไม่มีข้อมูล</td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <td>ยังไม่มีข้อมูล</td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%}%>
                    <%}%>
                </table>
            </td>
            <td class="borderInfo">
                <table class="info">
                    <% for (int i = 12; i < 14; i++)%>
                    <%{%>
                    <%if (Match[i] != null) %>
                    <%{%>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td><%=Match[i].TeamHomeNameWithStatus%></td>
                                    <td><%=Match[i].TeamHomeScore1%></td>
                                    <td><%=Match[i].TeamHomeScore2%></td>
                                </tr>
                                <tr>
                                    <td><%=Match[i].TeamAwayNameWithStatus%></td>
                                    <td><%=Match[i].TeamAwayScore1%></td>
                                    <td><%=Match[i].TeamAwayScore2%></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%}
                      else
                      {%>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>ยังไม่มีข้อมูล</td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <td>ยังไม่มีข้อมูล</td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%}%>
                    <%}%>
                </table>
            </td>
            <td class="borderInfo">
                <table class="info">
                    <%if (Match[14] != null) %>
                    <%{%>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td><%=Match[14].TeamHomeNameWithStatus%></td>
                                    <td><%=Match[14].TeamHomeScore1%></td>
                                    <td><%=Match[14].TeamHomeScore2%></td>
                                </tr>
                                <tr>
                                    <td><%=Match[14].TeamAwayNameWithStatus%></td>
                                    <td><%=Match[14].TeamAwayScore1%></td>
                                    <td><%=Match[14].TeamAwayScore2%></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%}
                      else
                      {%>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>ยังไม่มีข้อมูล</td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <td>ยังไม่มีข้อมูล</td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%}%>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>