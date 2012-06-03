<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Thaitae.CenterControl.Header" %>
<div align="center">
	<table width="1000" border="0" cellpadding="3" cellspacing="5">
		<tr>
			<td colspan="3" align="center" bgcolor="#000000">
				<img src="../Styles/images/Header.jpg" width="1000" height="238" />
			</td>
		</tr>
		<tr>
			<td colspan="3">
				<div id="menu">
					<ul class="menu">
						<li><a href="../Index.aspx" id="indexH"><span>&nbsp;Home&nbsp;</span></a></li>
						<li><a href="../AboutUs.aspx" id="aboutUsH"><span>&nbsp;About us&nbsp;</span></a></li>
						<li><a href="../News.aspx" id="newsH"><span>&nbsp;News&nbsp;</span></a></li>
						<li><a href="../PricePromotion.aspx" id="pricePromotionH"><span>&nbsp;Price & Promotion&nbsp;</span></a></li>
						<li><a href="#" class="parent"><span>League</span></a>
							<div>
								<ul>
									<li><a href="#" id="Premier.html"><span>Premier</span></a></li>
									<li><a href="#" id="Championship.html"><span>Championship</span></a></li>
									<li><a href="#" id="Division1.html"><span>Division1</span></a></li>
									<li><a href="#" id="Division2.html"><span>Division2</span></a></li>
									<li><a href="#" id="Division3.html"><span>Division3</span></a></li>
									<li><a href="#" id="Division4.html"><span>Division4</span></a></li>
								</ul>
							</div>
						</li>
						<li><a href="../ChampionLeague.aspx" id="championsLeague"><span>&nbsp;Champions League&nbsp;</span></a></li>
						<li><a href="../FACup.aspx" id="faCup"><span>&nbsp;FA Cup&nbsp;</span></a></li>
						<li><a href="../Gallery.aspx" id="galleryH"><span>&nbsp;Gallery&nbsp;</span></a></li>
						<li class="last"><a href="../ContactUs.aspx" id="contactUsH"><span>&nbsp;Contact us&nbsp;</span></a></li>
					</ul>
				</div>
			</td>
		</tr>
	</table>
</div>
