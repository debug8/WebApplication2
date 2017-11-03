<%@Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebApplication2.WebUserControl1" %>
<asp:Panel ID="Panel11" runat="server"  BorderWidth ="0" Height="36px" Width="496px">
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="118px">
        <asp:ListItem>Position 1</asp:ListItem>
        <asp:ListItem>Position 2</asp:ListItem>
        <asp:ListItem>Position 3</asp:ListItem>
        <asp:ListItem>Position 4</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;
    <asp:Button ID="AddButton" runat="server"  Text="Add" Width="42px"/>
    &nbsp;&nbsp;
    <asp:Button ID="DeleteButton"  runat="server"  Text="Delete" Width="57px" />
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="197px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</asp:Panel>

