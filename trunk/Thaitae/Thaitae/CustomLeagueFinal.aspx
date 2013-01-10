<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true" CodeBehind="CustomLeagueFinal.aspx.cs" Inherits="Thaitae.ChampionsLeagueFinal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .main
        {
            width: 100%;
            text-align: center;
        }

        .scorebox
        {
            background-color: darkkhaki;
            border-style: solid;
            border-width: 2px;
            border-color: darkgoldenrod;
            width: 100%;
        }

            .scorebox td
            {
                border-style: dashed;
                border-width: 1px;
                border-color: darkgoldenrod;
            }

        .header
        {
            background: maroon;
            font-weight: bold;
            font-size: 16px;
            color: white;
        }

        .borderInfo
        {
            border-width: 2px 2px 2px 2px;
            border-style: solid;
            border-color: maroon;
            width: 25%;
        }

        .info
        {
            width: 100%;
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>ผลการแข่งขัน Champion League Final</h3>
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
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="borderInfo">
                <table class="info">
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="borderInfo">
                <table class="info">
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="borderInfo">
                <table class="info">
                    <tr>
                        <td>
                            <table class="scorebox">
                                <tr>
                                    <td>team1</td>
                                    <td>2</td>
                                    <td>1</td>
                                </tr>
                                <tr>
                                    <td>tesm2</td>
                                    <td>1</td>
                                    <td>1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>