<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Thaitae.CenterControl.Header" %>
<div align="center">
    <table width="1000" border="0" cellpadding="3" cellspacing="5">
        <tr>
            <td colspan="3" align="right" style="width: 1000px; height: 238px; background-image: url(../Styles/images/Header.jpg)">
                <a href="http://www.dafabet.com/th.html">
                    <img src="../Styles/images/th.gif" /></a>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div id="menu">
                    <ul class="menu">
                        <li><a href="../Index.aspx" id="indexH"><span>&nbsp;Home&nbsp;</span></a></li>
                        <li><a href="../AboutUs.aspx" id="aboutUsH"><span>&nbsp;About us&nbsp;</span></a></li>
                        <li><a href="../News.aspx" id="newsH"><span>&nbsp;News&nbsp;</span></a></li>
                        <li><a href="../PricePromotion.aspx" id="pricePromotionH"><span>Price & Promotion</span></a></li>
                        <li><a href="#" class="parent"><span>League</span></a>
                            <div>
                                <ul>
                                    <%foreach (var league in ListLeague)%>
                                    <%{%>
                                    <li><a href="javascript:void(0);" id="<%=league.LeagueId%>" rel="<%=league.LeagueName%>"
                                        onclick="window.location='LeagueTemplate.aspx?leagueId=<%=league.LeagueId%>'">
                                        <%=league.LeagueName%>
                                    </a></li>
                                    <%}%>
                                </ul>
                            </div>
                        </li>
                        <li><a href="../ChampionLeague.aspx" id="championsLeague"><span>Champions League</span></a></li>
                        <li><a href="../FACup.aspx" id="faCup"><span>FA Cup</span></a></li>
                        <li><a href="../Gallery.aspx" id="galleryH"><span>&nbsp;Gallery&nbsp;</span></a></li>
                        <li class="last"><a href="../ContactUs.aspx" id="contactUsH"><span>&nbsp;Contact us&nbsp;</span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
</div>