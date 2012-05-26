<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
	CodeBehind="index.aspx.cs" Inherits="Thaitae.index" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		$(function () {
			$('#tabs').tabs();
			$('#date-tab1').datepicker({
				inline: true
			});
			$('#date-tab2').datepicker({
				inline: true
			});
			$('#date-tab3').datepicker({
				inline: true
			});
			$('#date-tab4').datepicker({
				inline: true
			});
			$('#date-tab5').datepicker({
				inline: true
			});
			$('#date-tab6').datepicker({
				inline: true
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div align="center">
		<table>
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
					<<%--div id="jslidernews2" class="lof-slidecontent" style="width: 650px; height: 330px;">
						<div class="preload">
							<div>
							</div>
						</div>
						<div class="button-previous">
							Previous</div>
						<!-- MAIN CONTENT -->
						<div class="main-slider-content" style="width: 650px; height: 330px;">
							<ul class="sliders-wrap-inner">
								<li>
									<img src="images/thumbl_455x330.png" title="Newsflash 2">
									<div class="slider-description">
										<div class="slider-meta">
											<a target="_parent" title="Newsflash 1" href="#Category-1">/ Newsflash 1 /</a> <i>—
												Monday, February 15, 2010 12:42</i></div>
										<h4>
											Content of Newsflash 1</h4>
										<p>
											The one thing about a Web site, it always changes! Joomla! makes it easy to add
											Articles, content,... <a class="readmore" href="#">Read more </a>
										</p>
									</div>
								</li>
								<li>
									<img src="images/thumbl_980x340_002.png" title="Newsflash 1">
									<div class="slider-description">
										<div class="slider-meta">
											<a target="_parent" title="Newsflash 2" href="#Category-2">/ Newsflash 2 /</a> <i>—
												Monday, February 15, 2010 12:42</i></div>
										<h4>
											Content of Newsflash 2</h4>
										<p>
											Joomla! makes it easy to launch a Web site of any kind. Whether you want a brochure
											site or you are... <a class="readmore" href="#">Read more </a>
										</p>
									</div>
								</li>
								<li>
									<img src="images/thumbl_980x340_003.png" title="Newsflash 3">
									<div class="slider-description">
										<div class="slider-meta">
											<a target="_parent" title="Newsflash 3" href="#Category-3">/ Newsflash 3 /</a> <i>—
												Monday, February 15, 2010 12:42</i></div>
										<h4>
											Content of Newsflash 3</h4>
										<p>
											With a library of thousands of free Extensions, you can add what you need as your
											site grows. Don't... <a class="readmore" href="#">Read more </a>
										</p>
									</div>
								</li>
								<li>
									<img src="images/thumbl_980x340_004.png" title="Newsflash 5" />
									<div class="slider-description">
										<div class="slider-meta">
											<a target="_parent" title="Newsflash 4" href="#Category-4">/ Newsflash 4 /</a> <i>—
												Monday, February 15, 2010 12:42</i></div>
										<h4>
											Content of Newsflash 4</h4>
										<p>
											Joomla! 1.5 - 'Experience the Freedom'!. It has never been easier to create your
											own dynamic Web... <a class="readmore" href="#">Read more </a>
										</p>
									</div>
								</li>
								<li>
									<img src="images/thumbl_980x340_005.png" title="Newsflash 5">
									<div class="slider-description">
										<div class="slider-meta">
											<a target="_parent" title="Newsflash 5" href="#">/ Newsflash 5 /</a> <i>— Monday, February
												15, 2010 12:42</i></div>
										<h4>
											Content of Newsflash 5</h4>
										<p>
											Joomla! 1.5 - 'Experience the Freedom'!. It has never been easier to create your
											own dynamic Web... <a class="readmore" href="#">Read more </a>
										</p>
									</div>
								</li>
								<li>
									<img src="images/thumbl_980x340_006.png" title="Newsflash 5">
									<div class="slider-description">
										<div class="slider-meta">
											<a target="_parent" title="Newsflash 6" href="#">/ Newsflash 6 /</a> <i>— Monday, February
												15, 2010 12:42</i></div>
										<h4>
											Content of Newsflash 6</h4>
										<p>
											Joomla! 1.5 - 'Experience the Freedom'!. It has never been easier to create your
											own dynamic Web... <a class="readmore" href="#">Read more </a>
										</p>
									</div>
								</li>
							</ul>
						</div>
						<!-- END MAIN CONTENT -->
						<!-- NAVIGATOR -->
						<div class="navigator-content">
							<div class="navigator-wrapper">
								<ul class="navigator-wrap-inner">
									<li>
										<div>
											<img src="images/lofthumbs/791902news3.jpg" />
											<h3>
												NewsFlash 1
											</h3>
											<span>20.01.2010</span> - ทดสอบ Hilight News...
										</div>
									</li>
									<li>
										<div>
											<img src="images/lofthumbs/435576news10.jpg" />
											<h3>
												NewsFlash 2
											</h3>
											<span>20.01.2010</span> -In id, mauris viverra asperiores, bibendum in id. Eu molestie.
											Ac sit eu. ..
										</div>
									</li>
									<li>
										<div>
											<img src="images/lofthumbs/641906img1.jpg" />
											<h3>
												NewsFlash 3
											</h3>
											<span>20.01.2010</span> - In id, mauris viverra asperiores, bibendum in id. Eu molestie.
											Ac sit eu. ..
										</div>
									</li>
									<li>
										<div>
											<img src="images/lofthumbs/416719news7.jpg" />
											<h3>
												NewsFlash 4</h3>
											<span>20.01.2010</span> - In id, mauris viverra asperiores, bibendum in id. Eu molestie.
											Ac sit eu. ..
										</div>
									</li>
									<li>
										<div>
											<img src="images/lofthumbs/641906img1.jpg" />
											<h3>
												NewsFlash 5</h3>
											<span>20.01.2010</span> -In id, mauris viverra asperiores, bibendum in id. Eu molestie.
											Ac sit eu. ..
										</div>
									</li>
									<li>
										<div>
											<img src="images/lofthumbs/416719news7.jpg" />
											<h3>
												NewsFlash 6</h3>
											<span>20.01.2010</span> - In id, mauris viverra asperiores, bibendum in id. Eu molestie.
											Ac sit eu. ..
										</div>
									</li>
								</ul>
							</div>
						</div>
						<!----------------- END OF NAVIGATOR --------------------->
						<div class="button-next">
							Next</div>
						<!-- BUTTON PLAY-STOP -->
						<div class="button-control">
							<span></span>
						</div>
						<!-- END OF BUTTON PLAY-STOP -->
					</div>--%>
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
					<p align="center" style="font-size: 16px">
						&nbsp;</p>
					<p align="center" style="font-size: 16px">
						ผลการแข่งขัน Premier
					</p>
					<p align="center" style="font-size: 12px">
						ประจำวันที่ 00 พ.ค. 55</p>
					<p align="center" style="font-size: 12px">
						&nbsp;</p>
					<table width="100%" border="0">
						<colgroup span="3" style="background-color: #c8dceb;">
						</colgroup>
						<tr>
							<th align="center" style="font-size: 14px">
								ทีม
							</th>
							<th align="center" style="font-size: 14px">
								คะแนน
							</th>
						</tr>
						<tr>
							<th align="center" style="font-size: 14px">
								-
							</th>
							<th align="center" style="font-size: 14px">
								-
							</th>
						</tr>
						<tr>
							<th align="center" style="font-size: 14px">
								-
							</th>
							<th align="center" style="font-size: 14px">
								-
							</th>
						</tr>
						<tr>
							<th align="center" style="font-size: 14px">
								-
							</th>
							<th align="center" style="font-size: 14px">
								-
							</th>
						</tr>
						<tr>
							<th align="center" style="font-size: 14px">
								-
							</th>
							<th align="center" style="font-size: 14px">
								-
							</th>
						</tr>
						<tr>
							<th align="center" style="font-size: 14px">
								-
							</th>
							<th align="center" style="font-size: 14px">
								-
							</th>
						</tr>
						<tr>
							<th align="center" style="font-size: 14px">
								-
							</th>
							<th align="center" style="font-size: 14px">
								-
							</th>
						</tr>
					</table>
					<a href="#">
						<p align="right" style="font-size: 12px">
							view all</p>
					</a>
					<p>
						&nbsp;</p>
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
							<li><a href="#tabs-1">Premier</a></li>
							<li><a href="#tabs-2">Championship</a></li>
							<li><a href="#tabs-3">Division1</a></li>
							<li><a href="#tabs-4">Division2</a></li>
							<li><a href="#tabs-5">Division3</a></li>
							<li><a href="#tabs-6">Division4</a></li>
						</ul>
						<div id="tabs-1">
							<div style="font-size: 14px;" align="center">
								ตารางคะแนน Premier
							</div>
							<br />
							<asp:UpdatePanel ID="updateTeamPanel" UpdateMode="Conditional" runat="server">
								<ContentTemplate>
									<cc1:JQGrid ID="JQGridMatchResult" AutoWidth="True" runat="server" Height="100%">
										<Columns>
											<cc1:JQGridColumn DataField="TeamSeasonId" PrimaryKey="True" Visible="False" />
											<cc1:JQGridColumn HeaderText="ทีม" DataField="TeamName" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="แข่ง" DataField="TeamMatchPlayed" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="ชนะ" DataField="TeamWon" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="เสมอ" DataField="TeamDrew" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="ได้" DataField="TeamGoalFor" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="เสีย" DataField="TeamGoalAgainst" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="แต้ม" DataField="TeamPts" TextAlign="Center" />
										</Columns>
										<ToolBarSettings ShowRefreshButton="True" />
										<AppearanceSettings ShowRowNumbers="true" />
									</cc1:JQGrid>
								</ContentTemplate>
							</asp:UpdatePanel>
							<br />
							<br />
							<div style="font-size: 14px" align="center">
								ดาวซัลโว Premier
							</div>
							<br />
							<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
								<ContentTemplate>
									<cc1:JQGrid ID="JQGridSulvoStar" AutoWidth="True" runat="server" Height="100%">
										<Columns>
											<cc1:JQGridColumn DataField="TeamSeasonId" PrimaryKey="True" Visible="False" />
											<cc1:JQGridColumn HeaderText="ชื่อ" DataField="TeamId" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="ทีม" DataField="TeamMatchPlayed" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="ประตู" DataField="TeamWon" TextAlign="Center" />
										</Columns>
										<ToolBarSettings ShowRefreshButton="True" />
										<AppearanceSettings ShowRowNumbers="true" Caption="อันดับ" />
									</cc1:JQGrid>
								</ContentTemplate>
							</asp:UpdatePanel>
							<table width="985">
								<tr>
									<td width="728">
										<br />
										<br />
										<div style="font-size: 14px" align="center">
											ตารางการแข่งขัน Premier
										</div>
										<br />
										<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
											<ContentTemplate>
												<cc1:JQGrid ID="JQGridMatches" AutoWidth="True" runat="server" Height="100%">
													<Columns>
														<cc1:JQGridColumn DataField="TeamSeasonId" PrimaryKey="True" Visible="False" />
														<cc1:JQGridColumn HeaderText="ทีม" DataField="TeamName" TextAlign="Center" />
														<cc1:JQGridColumn HeaderText="วันที่" DataField="TeamMatchPlayed" TextAlign="Center" />
														<cc1:JQGridColumn HeaderText="เวลา" DataField="TeamWon" TextAlign="Center" />
													</Columns>
													<ToolBarSettings ShowRefreshButton="True" />
													<AppearanceSettings ShowRowNumbers="true" Caption="อันดับ" />
												</cc1:JQGrid>
											</ContentTemplate>
										</asp:UpdatePanel>
									</td>
									<td width="244" align="center">
										<!-- Datepicker -->
										<h2 class="demoHeaders">
											ปฎิทินการแข่งขัน</h2>
										<p>
											&nbsp;</p>
										<div id="date-tab1">
										</div>
									</td>
								</tr>
							</table>
						</div>
						<div id="tabs-2">
							<div style="font-size: 14px;" align="center">
								ตารางคะแนน Championship
							</div>
							<br />
							<table width="100%" style="border-color: #d7e5ef">
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup span="7" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										อันดับ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										แข่ง
									</th>
									<th align="center" style="font-size: 14px">
										ชนะ
									</th>
									<th align="center" style="font-size: 14px">
										เสมอ
									</th>
									<th align="center" style="font-size: 14px">
										ได้
									</th>
									<th align="center" style="font-size: 14px">
										เสีย
									</th>
									<th align="center" style="font-size: 14px">
										แต้ม
									</th>
								</tr>
								<tr>
									<td align="center">
										1
									</td>
									<td align="center">
										ไทยเตะซ็อคเกอร์คลับ
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										2
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										3
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										4
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										5
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										6
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										7
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										8
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										9
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										11
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										12
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										13
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										14
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										15
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										16
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										17
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										18
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										19
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										20
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
							</table>
							<br />
							<br />
							<div style="font-size: 14px" align="center">
								ดาวซัลโว Championship
							</div>
							<br />
							<table width="100%" border="0">
								<colgroup span="3" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										ชื่อ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										ประตู
									</th>
								</tr>
								<tr>
									<th height="21" align="center">
										-
									</th>
									<th align="center">
										-
									</th>
									<th align="center">
										-
									</th>
								</tr>
							</table>
							<table width="985">
								<tr>
									<td width="728">
										<br />
										<br />
										<div style="font-size: 14px" align="center">
											ตารางการแข่งขัน Championship
										</div>
										<br />
										<table width="100%" border="0">
											<colgroup span="3" style="background-color: #d7e5ef;">
											</colgroup>
											<tr>
												<th align="center" style="font-size: 14px">
													ทีม
												</th>
												<th align="center" style="font-size: 14px">
													วันที่
												</th>
												<th align="center" style="font-size: 14px">
													เวลา
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="21" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
										</table>
									</td>
									<td width="244" align="center">
										<!-- Datepicker -->
										<h2 class="demoHeaders">
											ปฎิทินการแข่งขัน</h2>
										<p>
											&nbsp;</p>
										<div id="date-tab2">
										</div>
									</td>
								</tr>
							</table>
						</div>
						<div id="tabs-3">
							<div style="font-size: 14px;" align="center">
								ตารางคะแนน Division1
							</div>
							<br />
							<table width="100%" style="border-color: #d7e5ef">
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup span="7" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										อันดับ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										แข่ง
									</th>
									<th align="center" style="font-size: 14px">
										ชนะ
									</th>
									<th align="center" style="font-size: 14px">
										เสมอ
									</th>
									<th align="center" style="font-size: 14px">
										ได้
									</th>
									<th align="center" style="font-size: 14px">
										เสีย
									</th>
									<th align="center" style="font-size: 14px">
										แต้ม
									</th>
								</tr>
								<tr>
									<td align="center">
										1
									</td>
									<td align="center">
										ไทยเตะซ็อคเกอร์คลับ
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										2
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										3
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										4
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										5
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										6
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										7
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										8
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										9
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										11
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										12
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										13
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										14
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										15
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										16
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										17
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										18
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										19
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										20
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
							</table>
							<br />
							<br />
							<div style="font-size: 14px" align="center">
								ดาวซัลโว Division1
							</div>
							<br />
							<table width="100%" border="0">
								<colgroup span="3" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										ชื่อ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										ประตู
									</th>
								</tr>
								<tr>
									<th height="21" align="center">
										-
									</th>
									<th align="center">
										-
									</th>
									<th align="center">
										-
									</th>
								</tr>
							</table>
							<table width="985">
								<tr>
									<td width="728">
										<br />
										<br />
										<div style="font-size: 14px" align="center">
											ตารางการแข่งขัน Division1
										</div>
										<br />
										<table width="100%" border="0">
											<colgroup span="3" style="background-color: #d7e5ef;">
											</colgroup>
											<tr>
												<th align="center" style="font-size: 14px">
													ทีม
												</th>
												<th align="center" style="font-size: 14px">
													วันที่
												</th>
												<th align="center" style="font-size: 14px">
													เวลา
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="21" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
										</table>
									</td>
									<td width="244" align="center">
										<!-- Datepicker -->
										<h2 class="demoHeaders">
											ปฎิทินการแข่งขัน</h2>
										<p>
											&nbsp;</p>
										<div id="date-tab3">
										</div>
									</td>
								</tr>
							</table>
						</div>
						<div id="tabs-4">
							<div style="font-size: 14px;" align="center">
								ตารางคะแนน Division2
							</div>
							<br />
							<table width="100%" style="border-color: #d7e5ef">
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup span="7" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										อันดับ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										แข่ง
									</th>
									<th align="center" style="font-size: 14px">
										ชนะ
									</th>
									<th align="center" style="font-size: 14px">
										เสมอ
									</th>
									<th align="center" style="font-size: 14px">
										ได้
									</th>
									<th align="center" style="font-size: 14px">
										เสีย
									</th>
									<th align="center" style="font-size: 14px">
										แต้ม
									</th>
								</tr>
								<tr>
									<td align="center">
										1
									</td>
									<td align="center">
										ไทยเตะซ็อคเกอร์คลับ
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										2
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										3
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										4
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										5
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										6
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										7
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										8
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										9
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										11
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										12
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										13
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										14
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										15
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										16
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										17
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										18
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										19
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										20
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
							</table>
							<br />
							<br />
							<div style="font-size: 14px" align="center">
								ดาวซัลโว Division2
							</div>
							<br />
							<table width="100%" border="0">
								<colgroup span="3" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										ชื่อ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										ประตู
									</th>
								</tr>
								<tr>
									<th height="21" align="center">
										-
									</th>
									<th align="center">
										-
									</th>
									<th align="center">
										-
									</th>
								</tr>
							</table>
							<table width="985">
								<tr>
									<td width="728">
										<br />
										<br />
										<div style="font-size: 14px" align="center">
											ตารางการแข่งขัน Division2
										</div>
										<br />
										<table width="100%" border="0">
											<colgroup span="3" style="background-color: #d7e5ef;">
											</colgroup>
											<tr>
												<th align="center" style="font-size: 14px">
													ทีม
												</th>
												<th align="center" style="font-size: 14px">
													วันที่
												</th>
												<th align="center" style="font-size: 14px">
													เวลา
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="21" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
										</table>
									</td>
									<td width="244" align="center">
										<!-- Datepicker -->
										<h2 class="demoHeaders">
											ปฎิทินการแข่งขัน</h2>
										<p>
											&nbsp;</p>
										<div id="date-tab4">
										</div>
									</td>
								</tr>
							</table>
						</div>
						<div id="tabs-5">
							<div style="font-size: 14px;" align="center">
								ตารางคะแนน Division3
							</div>
							<br />
							<table width="100%" style="border-color: #d7e5ef">
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup span="7" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										อันดับ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										แข่ง
									</th>
									<th align="center" style="font-size: 14px">
										ชนะ
									</th>
									<th align="center" style="font-size: 14px">
										เสมอ
									</th>
									<th align="center" style="font-size: 14px">
										ได้
									</th>
									<th align="center" style="font-size: 14px">
										เสีย
									</th>
									<th align="center" style="font-size: 14px">
										แต้ม
									</th>
								</tr>
								<tr>
									<td align="center">
										1
									</td>
									<td align="center">
										ไทยเตะซ็อคเกอร์คลับ
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										2
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										3
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										4
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										5
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										6
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										7
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										8
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										9
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										11
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										12
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										13
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										14
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										15
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										16
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										17
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										18
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										19
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										20
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
							</table>
							<br />
							<br />
							<div style="font-size: 14px" align="center">
								ดาวซัลโว Division3
							</div>
							<br />
							<table width="100%" border="0">
								<colgroup span="3" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										ชื่อ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										ประตู
									</th>
								</tr>
								<tr>
									<th height="21" align="center">
										-
									</th>
									<th align="center">
										-
									</th>
									<th align="center">
										-
									</th>
								</tr>
							</table>
							<table width="985">
								<tr>
									<td width="728">
										<br />
										<br />
										<div style="font-size: 14px" align="center">
											ตารางการแข่งขัน Division3
										</div>
										<br />
										<table width="100%" border="0">
											<colgroup span="3" style="background-color: #d7e5ef;">
											</colgroup>
											<tr>
												<th align="center" style="font-size: 14px">
													ทีม
												</th>
												<th align="center" style="font-size: 14px">
													วันที่
												</th>
												<th align="center" style="font-size: 14px">
													เวลา
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="21" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
										</table>
									</td>
									<td width="244" align="center">
										<!-- Datepicker -->
										<h2 class="demoHeaders">
											ปฎิทินการแข่งขัน</h2>
										<p>
											&nbsp;</p>
										<div id="date-tab5">
										</div>
									</td>
								</tr>
							</table>
						</div>
						<div id="tabs-6">
							<div style="font-size: 14px;" align="center">
								ตารางคะแนน Division4
							</div>
							<br />
							<table width="100%" style="border-color: #d7e5ef">
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup style="background-color: #d7e5ef;">
								</colgroup>
								<colgroup span="7" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										อันดับ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										แข่ง
									</th>
									<th align="center" style="font-size: 14px">
										ชนะ
									</th>
									<th align="center" style="font-size: 14px">
										เสมอ
									</th>
									<th align="center" style="font-size: 14px">
										ได้
									</th>
									<th align="center" style="font-size: 14px">
										เสีย
									</th>
									<th align="center" style="font-size: 14px">
										แต้ม
									</th>
								</tr>
								<tr>
									<td align="center">
										1
									</td>
									<td align="center">
										ไทยเตะซ็อคเกอร์คลับ
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										2
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										3
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										4
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										5
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										6
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										7
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										8
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										9
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										11
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										12
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										13
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										14
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										15
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										16
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										17
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										18
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										19
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
								<tr>
									<td align="center">
										20
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
									<td align="center">
										-
									</td>
								</tr>
							</table>
							<br />
							<br />
							<div style="font-size: 14px" align="center">
								ดาวซัลโว Division4
							</div>
							<br />
							<table width="100%" border="0">
								<colgroup span="3" style="background-color: #d7e5ef;">
								</colgroup>
								<tr>
									<th align="center" style="font-size: 14px">
										ชื่อ
									</th>
									<th align="center" style="font-size: 14px">
										ทีม
									</th>
									<th align="center" style="font-size: 14px">
										ประตู
									</th>
								</tr>
								<tr>
									<th height="21" align="center">
										-
									</th>
									<th align="center">
										-
									</th>
									<th align="center">
										-
									</th>
								</tr>
							</table>
							<table width="985">
								<tr>
									<td width="728">
										<br />
										<br />
										<div style="font-size: 14px" align="center">
											ตารางการแข่งขัน Division4
										</div>
										<br />
										<table width="100%" border="0">
											<colgroup span="3" style="background-color: #d7e5ef;">
											</colgroup>
											<tr>
												<th align="center" style="font-size: 14px">
													ทีม
												</th>
												<th align="center" style="font-size: 14px">
													วันที่
												</th>
												<th align="center" style="font-size: 14px">
													เวลา
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="21" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
											<tr>
												<th height="20" align="center">
													-
												</th>
												<th align="center">
													-
												</th>
												<th align="center">
													-
												</th>
											</tr>
										</table>
									</td>
									<td width="244" align="center">
										<!-- Datepicker -->
										<h2 class="demoHeaders">
											ปฎิทินการแข่งขัน</h2>
										<p>
											&nbsp;</p>
										<div id="date-tab6">
										</div>
									</td>
								</tr>
							</table>
						</div>
					</div>
				</td>
			</tr>
		</table>
	</div>
</asp:Content>
