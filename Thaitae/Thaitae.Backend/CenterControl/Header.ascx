<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Thaitae.Backend.CenterControl.Header" %>
<div style="background-color: black" align="center">
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
		</LoggedInTemplate>
	</asp:LoginView>
</div>
