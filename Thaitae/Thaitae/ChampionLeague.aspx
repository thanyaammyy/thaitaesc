<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
	CodeBehind="ChampionLeague.aspx.cs" Inherits="Thaitae.ChampionLeague" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<title>Champions League l www.thaitaesc.com</title>
	<script type="text/javascript">
		$(document).ready(function () {
			$('#datepicker').datepicker({
				inline: true
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table align="center">
		<tr>
			<td height="427" colspan="3" align="center">
				<div style="font-size: 14px;" align="center">
					<p>ตารางคะแนน <span style="font-size: 14px">Champions League</span></p>
				</div>
				<br />
				<table width="900" style="border-color: #d7e5ef">
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
					ดาวซัลโว Champions League</div>
				<br />
				<table width="900" border="0">
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
						<th align="center">
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
		</tr>
		<tr>
			<td height="202" colspan="2" align="center">
				<br />
				<br />
				<div style="font-size: 14px" align="center">
					ตารางการแข่งขัน Champions League</div>
				<br />
				<table width="600" border="0">
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
			<td width="288" align="center">
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
</asp:Content>
