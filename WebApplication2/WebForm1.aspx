<!DOCTYPE html>

<%@ Page language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1"%>
<%@ Register src="WebUserControl1.ascx" tagname="WebUserControl1" tagprefix="uc1" %>
<%@ Register assembly="ClassLibrary1" namespace="ClassLibrary1" tagprefix="cc1" %>
<script runat="server">

    protected void CustomList1_ClickAdd(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CustomList1.Items.Add(new ListItem(TextBox13.Text, TextBox12.Text));
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 253px">
    <form id="form1" runat="server">
        
        <cc1:CustomList ID="CustomList1" runat="server" AutoPostBack ="false" OnClickAdd = "CustomList1_ClickAdd">

            <asp:ListItem Value="v1">t1</asp:ListItem>
            <asp:ListItem Value="Product 51">text 2</asp:ListItem>
            <asp:ListItem>description1</asp:ListItem>
            <asp:ListItem>description 2</asp:ListItem>
        </cc1:CustomList>
        <asp:Panel ID="Panel12" runat="server" Width="715px" Height="113px">
            <asp:Button ID="Button1" runat="server" Text="Add new item" OnClick="Button1_Click" />

            &nbsp;&nbsp;

            <asp:Label ID="Label1" runat="server" Text="value"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="text"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
        </asp:Panel>
    </form>
    </body>
</html>
