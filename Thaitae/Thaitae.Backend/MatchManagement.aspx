<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true"
    CodeBehind="MatchManagement.aspx.cs" Inherits="Thaitae.Backend.MatchManagement" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
        });
    </script>
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <cc1:jqgrid id="JqgridMatch1" runat="server" datasourceid="objectMatchData" autowidth="True">
        <columns>
            <cc1:JQGridColumn DataField="MatchId" PrimaryKey="True" Width="55" Visible="False" />
            <cc1:JQGridColumn HeaderText="Edit Actions" EditActionIconsColumn="true" Width="50"
                TextAlign="Center" />
            <cc1:JQGridColumn HeaderText="Match Date" DataType="DateTime" DataFormatString="{0:dd-MM-yyyy}" EditorControlID="MatchDate1" DataField="MatchDate"
                EditType="DatePicker" Editable="True" TextAlign="Center" />
        </columns>
        <adddialogsettings closeafteradding="False" />
        <editdialogsettings closeafterediting="True" />
        <toolbarsettings showeditbutton="True" showdeletebutton="true" showaddbutton="True"
            showrefreshbutton="True" showsearchbutton="True" />
        <appearancesettings showrownumbers="true" />
    </cc1:jqgrid>
    <cc1:jqdatepicker runat="server" id="MatchDate1" dateformat="dd/MM/yyyy" displaymode="ControlEditor"
        showon="Both" changemonth="True" changeyear="True" />
    <asp:objectdatasource id="objectMatchData" runat="server" dataobjecttypename="thaitae.lib.Match"
        insertmethod="Insert" updatemethod="Update" deletemethod="Delete" selectmethod="SelectItems"
        typename="thaitae.lib.Page.MatchHelper"></asp:objectdatasource>
</asp:content>