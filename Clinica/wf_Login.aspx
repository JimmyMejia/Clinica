<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_Login.aspx.cs" Inherits="Clinica.wf_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="~/Styles/Login.css" rel="stylesheet" type="text/css" />
    <link href="/Images/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
   
    <div class="container">
	<section id="content">
		<form action="" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
			<h1>Formulario de Logueo</h1>
			<div>
				<input type="text" placeholder="Username" required="required" id="username" runat="server" />
			</div>
			<div>
				<input type="password" placeholder="Password" required="required" id="password" runat="server" />
			</div>
			<div>
                <asp:Button ID="btn_entrar" runat="server" Text="Entrar" 
                    onclick="btn_entrar_Click"></asp:Button>
				<!--<input type="submit" value="Entrar" />-->
				<a href="#">Lost your password?</a>
				<a href="wf_Usuarios.aspx">Registrarse</a>
			    <br />
                <asp:Label ID="lb_mensajes" runat="server"></asp:Label>
                <asp:CustomValidator ID="cv_datos" runat="server"></asp:CustomValidator>

			</div>
		</form><!-- form -->
		<!--<div class="button">
			<a href="#">Download source file</a>
		</div><!-- button -->
	</section><!-- content -->
</div><!-- container -->
</body>
</html>
