<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="Thaitae.index" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>ไทยเตะซ็อกเกอร์คลับ l www.thaitaesc.com</title>
    <script type="text/javascript">
        var currentImage;
        var currentIndex = -1;
        var interval;
        var myTimer;
        function showImage(index) {
            if (index < $('ul.slideshow li').length) {
                var indexImage = $('ul.slideshow li')[index];
                if (currentImage) {
                    if (currentImage != indexImage) {
                        $(currentImage).animate({ opacity: 0.0 }, 1000).removeClass('show');
                        clearTimeout(myTimer);
                        myTimer = setTimeout("showNext()", 8000);
                    }
                }
                $(indexImage).animate({ opacity: 1.0 }, 1000).addClass('show');
                $('#slideshow-caption h3').html($(indexImage).find('img').attr('title'));
                $('#slideshow-caption p').html($(indexImage).find('img').attr('alt'));
                $('#slideshow-caption').slideToggle(300, function () {
                    $('#slideshow-caption').slideToggle(500);
                });
                currentImage = indexImage;
                currentIndex = index;
                $('ul.thumbs li').removeClass('show');
                $($('ul.thumbs li')[index]).addClass('show');
            }
        }

        function showNext() {
            var len = $('ul.slideshow li').length;
            var next = currentIndex < (len - 2) ? currentIndex + 1 : 0;
            showImage(next);
        }

        function NewsTemplateRender(div) {
            var url = "NewsTemplate.aspx?newsId=" + div.id;
            window.open(url, '_blank');
        }

        $(document).ready(function () {
            $('#tabs').tabs();
            var cookie = $.cookie("LeagueId");
            if (cookie != null) {
                $('#tabs ul li').removeClass("ui-tabs-selected ui-state-active");
                var a = $('#tabs ul li').find('a[id=' + cookie + ']');
                a.parent("li").addClass("ui-tabs-selected ui-state-active");
            }
            myTimer = setTimeout("showNext()", 8000);
            $('ul.slideshow li').css({ opacity: 0.0 });
            $('ul.slideshow li:first').css({ opacity: 1.0 }).addClass('show');
            $('ul.slideshow').append('<li id="slideshow-caption" class="caption"><div class="slideshow-caption-container"><h3></h3><p></p></div></li>');
            $('#slideshow-caption h3').html($('ul.slideshow li.show').find('img').attr('title'));
            $('#slideshow-caption p').html($('ul.slideshow li.show').find('img').attr('alt'));
            showNext(); //loads first image
            $('ul.thumbs li').bind('click', function (e) {
                var count = $(this).attr('rel');
                showImage(parseInt(count) - 1);
            });
        });

        function setNameLabel() {
            var name = $("td[aria-describedby=ContentPlaceHolder1_JQGridMatchFullResult_leagueName]").html();
            $("label[class=setNameLabel]").html(name);
        }

        function tabClick(a) {
            $.cookie("LeagueId", a.id, { expires: 7 });
            $("#PostButton1").click();
            setNameLabel();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table width="1000px" style="background-color: white">
            <tr>
                <td style="vertical-align: top" colspan="2" rowspan="4">
                    <div id="hotnewsBlog">
                        <h1 style="text-align: center">
                            <strong>เกาะติด ขอบสนาม</strong>
                            <!------------------------------------- THE CONTENT ------------------------------------------------->
                        </h1>
                        <ul class="slideshow">
                            <li class="show" rel="1">
                                <img src="http://admin.thaitaesc.com/NewsImages/1.jpg" title="Slide 1" alt="Short Description1" /></li>
                            <li rel="2">
                                <img src="http://admin.thaitaesc.com/NewsImages/2.jpg" title="Slide 2" alt="Short Description2" /></li>
                            <li rel="3">
                                <img src="http://admin.thaitaesc.com/NewsImages/3.jpg" title="Slide 3" alt="Short Description3" /></li>
                            <li rel="4">
                                <img src="http://admin.thaitaesc.com/NewsImages/4.jpg" title="Slide 4" alt="Short Description4" /></li>
                            <li rel="5">
                                <img src="http://admin.thaitaesc.com/NewsImages/5.jpg" title="Slide 5" alt="Short Description5" /></li>
                            <li rel="6">
                                <img src="http://admin.thaitaesc.com/NewsImages/6.jpg" title="Slide 6" alt="Short Description6" /></li>
                            <li rel="7">
                                <img src="http://admin.thaitaesc.com/NewsImages/7.jpg" title="Slide 7" alt="Short Description7" /></li>
                            <li rel="8">
                                <img src="http://admin.thaitaesc.com/NewsImages/8.jpg" title="Slide 8" alt="Short Description8" /></li>
                            <li rel="9">
                                <img src="http://admin.thaitaesc.com/NewsImages/9.jpg" title="Slide 9" alt="Short Description9" /></li>
                            <li rel="10">
                                <img src="http://admin.thaitaesc.com/NewsImages/10.jpg" title="Slide 10" alt="Short Description10" /></li>
                        </ul>
                        <ul class="thumbs">
                            <li class="show" rel="1">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/1_thumb.jpg" title="Slide 1"
                                    alt="Short Description1" /></li>
                            <li rel="2">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/2_thumb.jpg" title="Slide 2"
                                    alt="Short Description2" /></li>
                            <li rel="3">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/3_thumb.jpg" title="Slide 3"
                                    alt="Short Description3" /></li>
                            <li rel="4">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/4_thumb.jpg" title="Slide 4"
                                    alt="Short Description4" /></li>
                            <li rel="5">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/5_thumb.jpg" title="Slide 5"
                                    alt="Short Description5" /></li>
                            <li rel="6">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/6_thumb.jpg" title="Slide 6"
                                    alt="Short Description6" /></li>
                            <li rel="7">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/7_thumb.jpg" title="Slide 7"
                                    alt="Short Description7" /></li>
                            <li rel="8">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/8_thumb.jpg" title="Slide 8"
                                    alt="Short Description8" /></li>
                            <li rel="9">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/9_thumb.jpg" title="Slide 9"
                                    alt="Short Description9" /></li>
                            <li rel="10">
                                <img src="http://admin.thaitaesc.com/NewsImages/Thumbs/10_thumb.jpg" title="Slide 10"
                                    alt="Short Description10" /></li>
                        </ul>
                    </div>
                    <div style="margin: auto" id="ScoopeBlog">
                        <h1 style="text-align: center">
                            <strong>ข่าวเด่นอื่นๆ</strong>
                            <!------------------------------------- THE CONTENT ------------------------------------------------->
                        </h1>
                        <%foreach (var scoope in ListScoope)%>
                        <%{%>
                        <div id="<%=scoope.newsId%>" onclick="NewsTemplateRender(this)" class="Scoope">
                            <table class="tableScoope">
                                <tr>
                                    <td colspan="2">
                                        <span class="headingScoope">
                                            <%=scoope.newsTopic%></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img class="imgScoope" width="100" height="74" src="<%=scoope.picture%>" />
                                    </td>
                                    <td valign="top" style="word-break: break-all">
                                        <%=scoope.NewsBrief%>
                                        ....
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%}%>
                    </div>
                </td>
                <td style="text-align: center">
                    <a href="https://www.facebook.com/pages/Red-Seed-Fan-Page/191171527608027?ref=ts&amp;sk=wall">
                        <img src="/Styles/images/B-Redseed.png" width="200" height="75" align="middle" /></a>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <a href="http://www.tamudosports.com/">
                        <img src="/Styles/images/B-tamudo.png" width="220" height="75" align="middle" /></a>
                </td>
            </tr>
            <tr>
                <td style="text-align: center" height="77">
                    <a href="http://www.b-ingready.com/">
                        <img src="/Styles/images/B-Bing.png" width="220" height="75" /></a>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <div style="width: 260px;" class="fb-like-box" data-href="https://www.facebook.com/pages/%E0%B8%AA%E0%B8%99%E0%B8%B2%E0%B8%A1%E0%B8%9F%E0%B8%B8%E0%B8%95%E0%B8%9A%E0%B8%AD%E0%B8%A5%E0%B9%84%E0%B8%97%E0%B8%A2%E0%B9%80%E0%B8%95%E0%B8%B0/471760466173117"
                        data-width="250" data-show-faces="true" data-border-color="#8B1209" data-stream="true"
                        data-header="true">
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
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
                                <img src="<%=league.Picture%>" width="70px" height="66px" /><br />
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