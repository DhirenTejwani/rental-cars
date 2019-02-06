<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>


<html>

<head>

  <meta charset="UTF-8">

  <title>Login Form</title>

    <style>

body{
	margin: 0;
	padding: 0;
	background: #fff;

	color: #fff;
	font-family: Calibri;
	font-size: 12px;
}

.body{
	position: absolute;
	top: -20px;
	left: -20px;
	right: -40px;
	bottom: -40px;
	width: auto;
	height: auto;
	background-image: url(Image.png);
	background-size:cover;
	-webkit-filter:  blur(2px);
	z-index: 0;
}

.grad{
	position: absolute;
	top: -20px;
	left: -20px;
	right: -40px;
	bottom: -40px;
	width: auto;
	height: auto;
	background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(0,0,0,0)), color-stop(100%,rgba(0,0,0,0.65)));
	z-index: 1;
	opacity: 1;
}

.header{
	position: absolute;
	top: calc(50% - 50px);
	left: calc(45% - 270px);
	z-index: 2;
}

.header div{
	float: left;
	color: blue;
	font-family: Calibri;
	font-size: 45px;
	font-weight: 200;
}

.header div span{
	color: white !important;
}

.login{
	position: absolute;
	top: calc(50% - 75px);
	left: calc(45% - 50px);
	height: 150px;
	width: 350px;
	padding: 10px;
	z-index: 2;
}

.login input[type=text]{
	width: 250px;
	height: 30px;
	background: transparent;
	border: 1px solid rgba(255,255,255,0.6);
	border-radius: 2px;
	color: #fff;
	font-family: Calibri;
	font-size: 16px;
	font-weight: 400;
	padding: 4px;
}

.login input[type=password]{
	width: 250px;
	height: 30px;
	background: transparent;
	border: 1px solid rgba(255,255,255,0.6);
	border-radius: 2px;
	color: #fff;
	font-family: Calibri;
	font-size: 16px;
	font-weight: 400;
	padding: 4px;
	margin-top: 10px;
}

.login input[type=button]{
	width: 285px;
	height: 132px;
	background: #fff;
	border: 1px solid #fff;
	cursor: pointer;
	border-radius: 2px;
	color: #a18d6c;
	font-family: Calibri;
	font-size: 16px;
	font-weight: 400;
	padding: 6px;
	margin-top: 10px;
}



.login input[type=button]:hover{
	opacity: 0.8;
}

.login input[type=button]:active{
	opacity: 0.6;
}

.login input[type=text]:focus{
	outline: none;
	border: 1px solid rgba(255,255,255,0.9);
}

.login input[type=password]:focus{
	outline: none;
	border: 1px solid rgba(255,255,255,0.9);
}

.login input[type=button]:focus{
	outline: none;
}

::-webkit-input-placeholder{
   color: rgba(255,255,255,0.6);
}

::-moz-input-placeholder{
   color: rgba(255,255,255,0.6);
}
</style>

    <%--<script src="js/prefixfree.min.js"></script>--%>

</head>
    
<body>

    <form id="form1" runat="server">

  <div class="body"></div>
		<div class="grad"></div>
		<div class="header">
			<div>Rental<span>Cars</span></div>
		</div>
		<br>
		<div class="login">
				<asp:TextBox placeholder="username" name="user" id="uid" runat="server"></asp:TextBox>
				<asp:TextBox placeholder="password" name="password" id="pid" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Visible="False">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                    </Columns>
                </asp:GridView>
            
				<asp:Button value="Login" onclick="Login_Func" runat="server" Height="32px" Text="Login" Width="87px"/>
            
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database %>" SelectCommand="SELECT * FROM [Table]"></asp:SqlDataSource>
                <%--<input type="button" value="Exit" style="background-color: #FF6060; color: #000000;"><br >--%>
            <%--<asp:Button ID="Button1" runat="server" Text="Button" />--%>
		</div>

    
  <%--<script src='http://codepen.io/assets/libs/fullpage/jquery.js'></script>--%>

    </form>

</body>

</html>
