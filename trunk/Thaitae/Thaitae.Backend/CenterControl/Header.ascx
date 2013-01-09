<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Thaitae.Backend.CenterControl.Header" %>
<div style="background-color: rgb(74, 81, 85)" align="center">
    <asp:LoginView runat="server" EnableViewState="False">
        <AnonymousTemplate>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div align="right">
                <span class="LoginHeader">Welcome :
                    <asp:LoginName ID="HeadLoginName" runat="server" />
                    <%--<asp:HyperLink ID="hplChangePassword" ForeColor="White" runat="server" NavigateUrl="~/ForgetPassword.aspx"
                        Text="change password"></asp:HyperLink>--%>
                    [<asp:HyperLink ID="hplLogout" ForeColor="Red" runat="server" NavigateUrl="~/Logout.aspx"
                        Text="logout"></asp:HyperLink>] </span>
            </div>
            <div id="menu">
                <ul class="menu">
                    <li><a href="/News.aspx" class="parent"><span>News</span></a></li>
                    <li><a href="/League.aspx" class="parent"><span>League</span></a></li>
                    <li><a href="/Season.aspx" class="parent"><span>Season</span></a></li>
                    <li><a href="/TeamManagement.aspx" class="parent"><span>Team</span></a></li>
                    <li><a href="/MatchManagement.aspx" class="parent"><span>Normal Match</span></a></li>
                    <li><a href="/CustomMatchManagement.aspx" class="parent"><span>Champion & Europa Match</span></a></li>
                    <li><a href="/MatchFAManagement.aspx" class="parent"><span>FA Match</span></a></li>
                </ul>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</div>