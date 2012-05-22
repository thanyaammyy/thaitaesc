﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="TeamManagement.aspx.cs" Inherits="Thaitae.Backend.TeamManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Team Management</h2>
    <asp:UpdatePanel ID="updateTeamPanel" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:DropDownList runat="server" ID="ddlLeague" DataSourceID="LeagueDataSource" DataTextField="LeagueName"
                DataValueField="LeagueId" AutoPostBack="True" OnSelectedIndexChanged="ddlLeague_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlSeason" DataSourceID="SeasonDataSource" DataTextField="SeasonName"
                DataValueField="SeasonId" AutoPostBack="True" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged">
            </asp:DropDownList>
            <cc1:JQGrid ID="JqgridTeam" AutoWidth="True" runat="server" onrowdeleting="JqgridTeam_RowDeleting"
                onrowediting="JqgridTeam_RowEditing" OnRowAdding="JqgridTeam_RowAdding">
                <columns>
					<cc1:JQGridColumn DataField="TeamId" Visible="False" />
					<cc1:JQGridColumn DataField="SeasonId" Visible="False" />
					<cc1:JQGridColumn DataField="TeamSeasonId" PrimaryKey="True" Visible="False" />
					<cc1:JQGridColumn HeaderText="Edit" EditActionIconsColumn="true" Width="100"
						TextAlign="Center" />
					<cc1:JQGridColumn HeaderText="Name" DataField="TeamName" Editable="True"
						TextAlign="Center"/>
					<cc1:JQGridColumn HeaderText="Description" DataField="TeamDesc" Editable="True"
						TextAlign="Center"/>
						 <cc1:JQGridColumn HeaderText="Status" DataField="ActiveName" Editable="True" EditType="DropDown" EditValues="1:Active;0:InActive" TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="P" DataField="TeamMatchPlayed"
						TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="W" DataField="TeamWon"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="D" DataField="TeamDrew"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="L" DataField="TeamLoss"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="F" DataField="TeamGoalFor"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="A" DataField="TeamGoalAgainst"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="GD" DataField="TeamGoalDiff"
					    TextAlign="Center"/>
                    <cc1:JQGridColumn HeaderText="Pts" DataField="TeamPts"
					    TextAlign="Center"/>
				</columns>
                <adddialogsettings closeafteradding="False" />
                <editdialogsettings closeafterediting="True" />
                <toolbarsettings showeditbutton="True" showdeletebutton="true" showaddbutton="True"
                    showrefreshbutton="True" showsearchbutton="True" />
                <appearancesettings showrownumbers="true" />
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="LeagueDataSource" DataObjectTypeName="thaitae.lib.League"
        SelectMethod="SelectLeagueItems" TypeName="thaitae.lib.Page.LeagueHelper" runat="server">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SeasonDataSource" DataObjectTypeName="thaitae.lib.Season"
        SelectMethod="ListSeasonItems" TypeName="thaitae.lib.Page.SeasonHelper" runat="server">
        <SelectParameters>
            <asp:SessionParameter Name="LeagueId" SessionField="LeagueId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>