<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Traffic Service<br />
        <br />
        This webservice returns the news about traffic such as which lanes are closed due to construction, etc. with their start and endtime.<br />
        <br />
        This service has input parameter zipcode and output parameter as which roads are closed due to construction etc with their expected start and endtime.<br />
        <br />
        Please Enter ZipCode Here: &nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="19px" OnClick="Button1_Click" Text="Invoke Service" Width="140px" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
