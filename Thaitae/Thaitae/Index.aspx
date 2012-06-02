<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="Thaitae.index" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>ไทยเตะซ็อกเกอร์คลับ l www.thaitaesc.com</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tabs').tabs();
        });

        function setNameLabel() {
            var name = $("td[aria-describedby=ContentPlaceHolder1_JQGridMatchFullResult_leagueName]").html();
            $("label[class=setNameLabel]").html(name);
        }

        function tabClick(a) {
            var id = a.id;

            $("#GetLeague1").val(id);
            $("#PostButton1").click();
            setNameLabel(name);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table width="1000px">
            <tr>
                <td colspan="2" rowspan="4">
                    <p>
                        <br />
                        <br />
                    </p>
                    <h1>
                        &nbsp;</h1>
                    <h1>
                        <strong>THAITAE HOT NEWS</strong>
                        <!------------------------------------- THE CONTENT ------------------------------------------------->
                    </h1>
                </td>
                <td width="224" height="84">
                    <a href="https://www.facebook.com/pages/Red-Seed-Fan-Page/191171527608027?ref=ts&amp;sk=wall">
                        <img src="/Styles/images/B-Redseed.png" width="200" height="75" align="middle" /></a>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="http://www.tamudosports.com/">
                        <img src="/Styles/images/B-tamudo.png" width="220" height="75" align="middle" /></a>
                </td>
            </tr>
            <tr>
                <td height="77">
                    <a href="http://www.b-ingready.com/">
                        <img src="/Styles/images/B-Bing.png" width="220" height="75" align="middle" /></a>
                </td>
            </tr>
            <tr>
                <td height="81" align="center">
                    <img src="/Styles/images/B-Facebook.png" width="200" height="75" />
                </td>
            </tr>
            <tr>
                <td height="329" colspan="2" align="center">
                    <%--<img src="images/test-new.png" width="655" height="230" />
					<br />
					<a href="News.html">
						<p align="right" style="font-size: 12px">
							view all</p>
					</a>--%>
                </td>
                <td valign="top">
                </td>
            </tr>
            <tr align="center">
                <td height="126" colspan="3" valign="middle">
                    <p>
                        <a href="http://www.dafabet.com/th.html">
                            <img src="/Styles/images/th.gif" width="490" height="120" align="middle" /></a></p>
                    <p>
                        &nbsp;</p>
                </td>
            </tr>
            <tr>
                <td height="397" colspan="3">
                    <div id="tabs">
                        <ul>
                            <%foreach (var league in ListLeague)%>
                            <%{%>
                            <li><a href="#fixTab" id="<%=league.LeagueId%>" rel="<%=league.LeagueName%>" onclick="tabClick(this)">
                                <%if (!string.IsNullOrEmpty(league.Picture))%>
                                <%{%>
                                <img src="<%=league.Picture%>" width="32px" height="32px" />&nbsp;
                                <%}%>
                                <%=league.LeagueName%>
                            </a></li>
                            <%}%>
                        </ul>
                        <div id="fixTab">
                            <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <div style="font-size: 14px;" align="center">
                                        ตารางคะแนน
                                        <label class="setNameLabel" id="lbMatchResult">
                                        </label>
                                    </div>
                                    <br />
                                    <asp:HiddenField ID="GetLeague1" ClientIDMode="Static" runat="server" />
                                    <div style="display: none">
                                        <asp:Button ID="PostButton1" ClientIDMode="Static" runat="server" OnClick="PostButton1_Click" />
                                    </div>
                                    <cc1:JQGrid ID="JQGridMatchFullResult" AutoWidth="True" runat="server" Height="100%">
                                        <Columns>
                                            <cc1:JQGridColumn DataField="leagueName" Visible="False" />
                                            <cc1:JQGridColumn DataField="TeamSeasonId" PrimaryKey="True" Visible="False" />
                                            <cc1:JQGridColumn HeaderText="ทีม" DataField="TeamName" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="แข่ง" DataField="TeamMatchPlayed" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="ชนะ" DataField="TeamWon" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="เสมอ" DataField="TeamDrew" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="แพ้" DataField="TeamLoss" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="ได้" DataField="TeamGoalFor" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="เสีย" DataField="TeamGoalAgainst" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="+/-" DataField="TeamGoalDiff" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="แต้ม" DataField="TeamPts" TextAlign="Center" />
                                        </Columns>
                                        <ToolBarSettings ShowRefreshButton="True" />
                                        <AppearanceSettings ShowRowNumbers="true" />
                                        <ClientSideEvents LoadComplete="setNameLabel"></ClientSideEvents>
                                        <PagerSettings PageSize="20"></PagerSettings>
                                    </cc1:JQGrid>
                                    <br />
                                    <div style="font-size: 14px" align="center">
                                        สรุปผลการแข่งขัน
                                        <label class="setNameLabel" id="lbMatch">
                                        </label>
                                    </div>
                                    <br />
                                    <cc1:JQGrid ID="JQGridMatches" AutoWidth="True" runat="server" Height="100%">
                                        <Columns>
                                            <cc1:JQGridColumn DataField="MatchId" PrimaryKey="True" Visible="False" />
                                            <cc1:JQGridColumn HeaderText="ทีมเหย้า" DataField="TeamHomeIdName" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="ผลการแข่งขัน" DataField="MatchScore" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="ทีมเยือน" DataField="TeamAwayIdName" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="วันที่" DataType="DateTime" DataFormatString="{0:dd/MM/yyyy}"
                                                DataField="MatchDate" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="เวลา" DataType="DateTime" DataFormatString="{0:HH:mm}"
                                                DataField="MatchDate" TextAlign="Center" />
                                        </Columns>
                                        <ToolBarSettings ShowRefreshButton="True" />
                                        <AppearanceSettings ShowRowNumbers="true" />
                                    </cc1:JQGrid>
                                    <br />
                                    <div style="font-size: 14px" align="center">
                                        ดาวซัลโว
                                        <label class="setNameLabel" id="lbSulvoStar">
                                        </label>
                                    </div>
                                    <br />
                                    <cc1:JQGrid ID="JQGridSulvoStar" AutoWidth="True" runat="server" Height="100%">
                                        <Columns>
                                            <cc1:JQGridColumn DataField="PlayerId" PrimaryKey="True" Visible="False" />
                                            <cc1:JQGridColumn HeaderText="หมายเลข" DataField="PlayerNumber" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="ทีม" DataField="PlayerTeamIdName" TextAlign="Center" />
                                            <cc1:JQGridColumn HeaderText="ประตู" DataField="PlayerGoal" TextAlign="Center" />
                                        </Columns>
                                        <ToolBarSettings ShowRefreshButton="True" />
                                        <AppearanceSettings ShowRowNumbers="true" />
                                    </cc1:JQGrid>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
            </tr>
        </table>
    </div>
</asp:Content>