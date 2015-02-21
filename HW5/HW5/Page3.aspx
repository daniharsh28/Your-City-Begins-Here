<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="HW5.Page3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <!-- Bootstrap core CSS -->
    <link href="http://getbootstrap.com/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Bootstrap theme -->
    <link href="http://getbootstrap.com/dist/css/bootstrap-theme.min.css" rel="stylesheet"/>

    <!-- Custom styles for this template -->
    <link href="http://getbootstrap.com/examples/theme/theme.css" rel="stylesheet"/>

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="./Theme Template for Bootstrap_files/ie-emulation-modes-warning.js"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Hi,
        <asp:Label ID="Label1" runat="server"  CssClass="label label-primary"></asp:Label>
        <br />
        <br />
        Some places to hang around
        <asp:Label ID="Label2" runat="server"></asp:Label> :
        <br />
        <br />
         <asp:Label ID="Place1" runat="server" Text="" ></asp:Label><br /> <br />
            <asp:Label ID="Place2" runat="server" Text="" ></asp:Label><br /> <br />
            <asp:Label ID="Place3" runat="server" Text="" ></asp:Label><br /> <br />
            <asp:Label ID="Place4" runat="server" Text="" ></asp:Label><br /> <br />
            <asp:Label ID="Place5" runat="server" Text="" ></asp:Label><br /> <br />
            <asp:Label ID="Place6" runat="server" Text="" ></asp:Label><br /> <br />
            <asp:Label ID="Place7" runat="server" Text="" ></asp:Label><br /> <br />
            <asp:Label ID="Place8" runat="server" Text="" ></asp:Label><br /> <br />
            <asp:Label ID="Place9" runat="server" Text="" ></asp:Label><br /> <br />
            <asp:Label ID="Place10" runat="server" Text="" ></asp:Label><br /> <br />
        <br />
        <br />
        Do you want to proceed further?<br />
        <asp:Button ID="Button1" runat="server" Text="Proceed Further" OnClick="Button1_Click" class="btn btn-primary"/> &nbsp;&nbsp;&nbsp;
    
        <asp:Button ID="Button2" runat="server" Text="Exit" OnClick="Button2_Click" class="btn btn-primary"/>
    
    </div>
    </form>
</body>
</html>
