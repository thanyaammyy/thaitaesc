<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="Thaitae.index" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>ไทยเตะซ็อกเกอร์คลับ l www.thaitaesc.com</title>
    <script type="text/javascript">
        $(document).ready(function () {
            slideShow(5000);
            $('#tabs').tabs();
            $('.thumbs li').bind('click', function (e) {
                var count = $(this).attr('rel');
                $('.thumbs li').removeClass('show');
                $(this).addClass('show');
                $('.slideshow li').removeClass('show');
                $($('.slideshow li')[count-1]).addClass('show');
            });
        });
        function slideShow(speed) {

            //append a LI item to the UL list for displaying caption
            $('ul.slideshow').append('<li id="slideshow-caption" class="caption"><div class="slideshow-caption-container"><h3></h3><p></p></div></li>');

            //Set the opacity of all images to 0
            $('ul.slideshow li').css({ opacity: 0.0 });

            //Get the first image and display it (set it to full opacity)
            $('ul.slideshow li:first').css({ opacity: 1.0 }).addClass('show');

            //Get the caption of the first image from REL attribute and display it
            $('#slideshow-caption h3').html($('ul.slideshow li.show').find('img').attr('title'));
            $('#slideshow-caption p').html($('ul.slideshow li.show').find('img').attr('alt'));

            //Display the caption
            $('#slideshow-caption').css({ opacity: 0.7, bottom: 0 });

            //Call the gallery function to run the slideshow
            var timer = setInterval('gallery()', speed);

            //pause the slideshow on mouse over
            $('ul.slideshow').hover(
                function () {
                    clearInterval(timer);
                },
                function () {
                    timer = setInterval('gallery()', speed);
                }
            );

        }

        function gallery() {

            //if no IMGs have the show class, grab the first image
            var current = ($('ul.slideshow li.show') ? $('ul.slideshow li.show') : $('#ul.slideshow li:first'));

            //trying to avoid speed issue
            if (current.queue('fx').length == 0) {

                //Get next image, if it reached the end of the slideshow, rotate it back to the first image
                var next = ((current.next().length) ? ((current.next().attr('id') == 'slideshow-caption') ? $('ul.slideshow li:first') : current.next()) : $('ul.slideshow li:first'));

                //Get next image caption
                var title = next.find('img').attr('title');
                var desc = next.find('img').attr('alt');

                //Set the fade in effect for the next image, show class has higher z-index
                next.css({ opacity: 0.0 }).addClass('show').animate({ opacity: 1.0 }, 1000);

                //Hide the caption first, and then set and display the caption
                $('#slideshow-caption').slideToggle(300, function () {
                    $('#slideshow-caption h3').html(title);
                    $('#slideshow-caption p').html(desc);
                    $('#slideshow-caption').slideToggle(500);
                });

                //Hide the current image
                current.animate({ opacity: 0.0 }, 1000).removeClass('show');

            }

        }

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
                    <h1>
                        <strong>THAITAE HOT NEWS</strong>
                        <!------------------------------------- THE CONTENT ------------------------------------------------->
                    </h1>
                    <ul class="slideshow">
                        <li class="show"><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/1.jpg" title="Slide 1" alt="Short Description1" /></a></li>
                        <li><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/2.jpg" title="Slide 2" alt="Short Description2" /></a></li>
                        <li><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/3.jpg" title="Slide 3" alt="Short Description3" /></a></li>
                        <li><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/4.jpg" title="Slide 4" alt="Short Description4" /></a></li>
                        <li><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/5.jpg" title="Slide 5" alt="Short Description5" /></a></li>
                        <li><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/6.jpg" title="Slide 6" alt="Short Description6" /></a></li>
                        <li><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/7.jpg" title="Slide 7" alt="Short Description7" /></a></li>
                        <li><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/8.jpg" title="Slide 8" alt="Short Description8" /></a></li>
                        <li><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/9.jpg" title="Slide 9" alt="Short Description9" /></a></li>
                        <li><a href="#">
                            <img src="http://admin.thaitaesc.com/NewsImages/10.jpg" title="Slide 10" alt="Short Description10" /></a></li>
                    </ul>
                    <ul class="thumbs">
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