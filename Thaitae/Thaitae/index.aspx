<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
	CodeBehind="index.aspx.cs" Inherits="Thaitae.index" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#tabs').tabs();
			$('#datepicker').datepicker({
				inline: true
			});
		});



		function tabClick(a) {
			var id = a.id;
			$("#GetLeague1").val(id);
			$("#PostButton1").click();
		}
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
						ประจำวันที่
						<%=DateTime.Now.ToString("dd MMM yyyy", new CultureInfo("th-TH")) %></p>
					<p align="center" style="font-size: 12px">
						&nbsp;</p>
					<asp:UpdatePanel ID="UpdatePanelMatchResult" UpdateMode="Always" runat="server">
						<ContentTemplate>
							<cc1:JQGrid ID="JQGridMatchResult" AutoWidth="True" runat="server" Height="100%">
								<Columns>
									<cc1:JQGridColumn DataField="TeamSeasonId" PrimaryKey="True" Visible="False" />
									<cc1:JQGridColumn HeaderText="ทีม" DataField="TeamName" TextAlign="Center" />
									<cc1:JQGridColumn HeaderText="คะแนน" DataField="TeamPts" TextAlign="Center" />
								</Columns>
								<ToolBarSettings ShowRefreshButton="True" />
								<AppearanceSettings ShowRowNumbers="true" />
							</cc1:JQGrid>
						</ContentTemplate>
					</asp:UpdatePanel>
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
							<%foreach (var league in ListLeague)%>
							<%{%>
							<li><a href="#fixTab" id="<%=league.LeagueId%>" onclick="tabClick(this)">
								<%=league.LeagueName%>
							</a></li>
							<%}%>
						</ul>
						<div id="fixTab">
							<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
								<ContentTemplate>
									<div style="font-size: 14px;" align="center">
										ตารางคะแนน
										<asp:Label ID="lbMatchResult" runat="server">
										</asp:Label>
									</div>
									<br />
									<asp:HiddenField ID="GetLeague1" ClientIDMode="Static" runat="server" />
									<div style="display: none">
										<asp:Button ID="PostButton1" ClientIDMode="Static" runat="server" OnClick="PostButton1_Click" />
									</div>
									<cc1:JQGrid ID="JQGridMatchFullResult" AutoWidth="True" runat="server" Height="100%">
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
									<br />
									<br />
									<div style="font-size: 14px" align="center">
										ดาวซัลโว
										<asp:Label ID="lbSulvoStar" runat="server"> </asp:Label>
									</div>
									<br />
									<cc1:JQGrid ID="JQGridSulvoStar" AutoWidth="True" runat="server" Height="100%">
										<Columns>
											<cc1:JQGridColumn DataField="PlayerId" PrimaryKey="True" Visible="False" />
											<cc1:JQGridColumn HeaderText="ชื่อ" DataField="PlayerName" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="ทีม" DataField="PlayerTeamIdName" TextAlign="Center" />
											<cc1:JQGridColumn HeaderText="ประตู" DataField="PlayerGoal" TextAlign="Center" />
										</Columns>
										<ToolBarSettings ShowRefreshButton="True" />
										<AppearanceSettings ShowRowNumbers="true" />
									</cc1:JQGrid>
									<table width="985">
										<tr>
											<td width="728">
												<br />
												<br />
												<div style="font-size: 14px" align="center">
													ตารางการแข่งขัน
													<asp:Label ID="lbMatch" runat="server"></asp:Label>
												</div>
												<br />
												<cc1:JQGrid ID="JQGridMatches" AutoWidth="True" runat="server" Height="100%">
													<Columns>
														<cc1:JQGridColumn DataField="MatchId" PrimaryKey="True" Visible="False" />
														<cc1:JQGridColumn HeaderText="ทีมเหย้า" DataField="TeamHomeIdName" TextAlign="Center" />
														<cc1:JQGridColumn HeaderText="ทีมเยือน" DataField="TeamAwayIdName" TextAlign="Center" />
														<cc1:JQGridColumn HeaderText="วันที่" DataType="DateTime" DataFormatString="{0:dd/MM/yyyy}"
															DataField="MatchDate" TextAlign="Center" />
														<cc1:JQGridColumn HeaderText="เวลา" DataType="DateTime" DataFormatString="{0:HH:mm}"
															DataField="MatchDate" TextAlign="Center" />
													</Columns>
													<ToolBarSettings ShowRefreshButton="True" />
													<AppearanceSettings ShowRowNumbers="true" />
												</cc1:JQGrid>
								</ContentTemplate>
							</asp:UpdatePanel>
						</div>
					</div>
				</td>
				<td width="244" align="center">
					<!-- Datepicker -->
					<h2 class="demoHeaders">
						ปฎิทินการแข่งขัน</h2>
					<p>
						&nbsp;</p>
					<div id="datepicker">
					</div>
				</td>
			</tr>
		</table>
	</div>
</asp:Content>
