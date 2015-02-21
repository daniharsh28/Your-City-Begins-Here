<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="HW5.Homepage" %>

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
    <div  >
        
       <h2 class="text-center"> Explore Your City </h2><br />
        <h4 class="text-center">Application that finds weather, News, traffic, famous places to hang around and hospitals in your city for you!</h4>
       <br />
       <br />
       Please Enter your Name : &nbsp;&nbsp;&nbsp; <asp:TextBox runat="server" ID="TextBox1"/> 
       <br />
       <br />
       Please enter the zipcode of the city you want to Explore: &nbsp;&nbsp;&nbsp; <asp:TextBox runat="server" ID="TextBox2" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" CssClass="label label-primary"></asp:Label>
       <br />
       <br />
       <asp:Button runat ="server" ID="Button1" Text="Proceed Further" OnClick="Button1_Click" class="btn btn-primary"/> &nbsp;&nbsp;&nbsp; <asp:Button runat="server" ID="Button2" Text="Exit" OnClick="Button2_Click" class="btn btn-primary" />
        
    </div>
    </form>
</body>
</html>
