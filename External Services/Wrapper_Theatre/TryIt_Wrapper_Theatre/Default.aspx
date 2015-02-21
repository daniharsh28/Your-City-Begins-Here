<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Wrapper Service<br />
        <br />
        This service will fetch top-5 movie theatres for given city.<br />
        <br />
        Method name is GetTheatres. Input parameter is string which determines city and output parameter is Theateres which contain Name of theatre and its address.<br />
        <br />
        Enter Name of your city:&nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Invoke Service" />
&nbsp;&nbsp
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
    
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
