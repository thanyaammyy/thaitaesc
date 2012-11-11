<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
    CodeBehind="LeagueTemplate.aspx.cs" Inherits="Thaitae.LeagueTemplate" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function setNameLabel() {
            var name = $("td[aria-describedby=ContentPlaceHolder1_JQGridMatchFullResult_leagueName]").html();
            $("label[class=setNameLabel]").html(name);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div style="font-size: 14px;" align="center">
                ตารางคะแนน
                <label class="setNameLabel" id="lbMatchResult">
                </label>
            </div>
            <br />
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
</asp:Content>