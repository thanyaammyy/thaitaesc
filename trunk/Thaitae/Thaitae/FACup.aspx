<%@ Page Title="" Language="C#" MasterPageFile="~/Thaitae.Master" AutoEventWireup="true"
    CodeBehind="FACup.aspx.cs" Inherits="Thaitae.FACup" %>

<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>FA Cup l www.thaitaesc.com</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        ผลการแข่งขัน FA Cup</h3>
    <cc1:JQGrid ID="JqgridMatch1" runat="server" AutoWidth="True" Height="100%">
        <Columns>
            <cc1:JQGridColumn DataField="FAMatchId" PrimaryKey="True" Visible="False" />
            <cc1:JQGridColumn HeaderText="Home Team" DataType="String" DataField="TeamHomeName"
                TextAlign="Center" Editable="False" />
            <cc1:JQGridColumn HeaderText="Home Score" DataType="Int" DataField="TeamHomeScore"
                TextAlign="Center" Editable="False" NullDisplayText="0" />
            <cc1:JQGridColumn HeaderText=" " Width="10" DataType="Int" DataField="Dash" TextAlign="Center"
                Editable="false" />
            <cc1:JQGridColumn HeaderText="Away Score" DataType="Int" DataField="TeamAwayScore"
                TextAlign="Center" Editable="False" NullDisplayText="0" />
            <cc1:JQGridColumn HeaderText="Away Team" DataType="String" DataField="TeamAwayName"
                TextAlign="Center" Editable="False" />
            <cc1:JQGridColumn HeaderText="Team Win" DataType="String" DataField="TeamWin" TextAlign="Center"
                Editable="False" />
            <cc1:JQGridColumn HeaderText="Match Date" DataType="DateTime" DataFormatString="{0:dd/MM/yyyy HH:mm}"
                DataField="FAMatchDate" EditType="TextBox" Editable="False" TextAlign="Center" />
        </Columns>
        <PagerSettings PageSize="100" />
        <AppearanceSettings ShowRowNumbers="true" />
    </cc1:JQGrid>
</asp:Content>