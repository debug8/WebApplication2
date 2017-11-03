<!DOCTYPE html>

<%@ Page language="C#" Trace="true" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1"%>
<%@ Register src="WebUserControl1.ascx" tagname="WebUserControl1" tagprefix="uc1" %>
<%@ Register assembly="ClassLibrary1" namespace="ClassLibrary1" tagprefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" dir="rtl">
        .floatLeft {
            float: left;
            padding-right:inherit;
            background-color:aquamarine;
            font-weight:bold
        }

        .buttonStyle {
            background-color:inherit;
            float:right;
        }
        #form1 {
            height: 280px;
        }
    </style>
</head>
<body style="height: 287px">
    <form id="form1" runat="server">       
        <asp:Panel ID="Panel1" runat="server" Height="220px" Width="760px" Direction="LeftToRight" ScrollBars="Vertical" CssClass="floatLeft" DefaultButton="SaveButton">
            <asp:Button ID="SaveButton" runat="server" CssClass="buttonStyle" Height="30px" OnClick="SaveButton_Click" Text="Save" Width="60px" />
        </asp:Panel>       
    </form>
    
        </body>
</html>
