<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Thaitae.Backend.CenterControl.Header" %>
<div style="background-color: rgb(74, 81, 85)" align="center">
	<img src="/Images/thaitae_logo.png" />
	<asp:LoginView runat="server" EnableViewState="False">
		<AnonymousTemplate>
		</AnonymousTemplate>
		<LoggedInTemplate>
			<div align="right">
				<span class="LoginHeader">Welcome :
					<asp:LoginName ID="HeadLoginName" runat="server" />
					<asp:HyperLink ID="hplChangePassword" runat="server" NavigateUrl="~/ForgetPassword.aspx"
						Text="change password"></asp:HyperLink>
					[<asp:HyperLink ID="hplLogout" runat="server" NavigateUrl="~/Logout.aspx" Text="logout"></asp:HyperLink>]
				</span>
			</div>
			<div id="menu">
						<ul class="menu">
						    <li><a href="/News.aspx" class="parent"><span>News Management</span></a></li>
							<li><a href="/League.aspx" class="parent"><span>League Management</span></a></li>
							<li><a href="/Season.aspx" class="parent"><span>Season Management</span></a></li>
							<li><a href="/TeamManagement.aspx" class="parent"><span>Team Management</span></a></li>
							<li><a href="/MatchManagement.aspx" class="parent"><span>Match Management</span></a></li>
						</ul>
					</div>
		</LoggedInTemplate>
	</asp:LoginView>
</div>
