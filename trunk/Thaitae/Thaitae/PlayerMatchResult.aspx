<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlayerMatchResult.aspx.cs"
    Inherits="Thaitae.PlayerMatchResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 350px">
    <form id="form1" runat="server">
    <div>
        <table style="width: 350px; border: 2px brown solid">
            <tr>
                <td style="border: 1px brown solid; text-align: center; vertical-align: top">
                    <span style="font-weight: bold">
                        <%=TeamHome%></span>
                    <br />
                    <span style="font-weight: bold">--------------</span>
                    <%foreach (var playerHome in PlayerHomeList)%>
                    <%{%>
                    <br />
                    <%=playerHome.PlayerConditionThai%>
                    :
                    <%=playerHome.PlayerNumber%>
                    <%}%>
                </td>
                <td style="border: 1px brown solid; text-align: center; vertical-align: top">
                    <span style="font-weight: bold">
                        <%=TeamAway%></span>
                    <br />
                    <span style="font-weight: bold">--------------</span>
                    <% foreach (var playerAway in PlayerAwayList)%>
                    <%{%>
                    <br />
                    <%=playerAway.PlayerConditionThai%>
                    :
                    <%=playerAway.PlayerNumber%>
                    <%}%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>