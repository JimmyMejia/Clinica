<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_Login.aspx.cs" Inherits="Clinica.wf_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="~/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Login.css" rel="stylesheet" type="text/css" />
    <link href="/Images/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
   
    <div class="container1">
	<section id="content">

        <div class="row">
        <%--<div class="table-responsive">
            <table class="table">--%>
		        <form action="" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
			                <h1>Iniciar Sesión</h1>
                        </div>
			                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
				                <input type="text" placeholder="Username" required="required" id="username" runat="server" />
			                </div>                        
                    </div>

                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
				            <input type="password" placeholder="Password" required="required" id="password" runat="server" />
                        </div>
			        </div>

                    <div class="row">
                        <div class="form-group"> 
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <p><asp:Label ID="lb_mensajes" runat="server"></asp:Label></p>
                        </div>
                        </div> 
			        </div>

			        <div class="row">
                        <div class="col-xs-5 col-sm-3 col-md-3 col-lg-3">
                            <asp:Button ID="btn_entrar" runat="server" Text="Entrar" 
                                onclick="btn_entrar_Click"></asp:Button>
				            <!--<input type="submit" value="Entrar" />-->
                        </div> 
                    </div>      
                    <div class="row">             
                        <div class="form-group">           
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
				              <p><a href="#" CssClass="btn btn-link">Olvidó su contraseña?</a></p>
                         </div>    
                         <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
				               <p><a href="wf_Usuarios.aspx" CssClass="btn btn-link">Registrarse</a></p>
                         </div>
                         </div>
                    </div>

			            <br />                        
                        <asp:CustomValidator ID="cv_datos" runat="server"></asp:CustomValidator>

			        </div>
		        </form>
            <%--</table>
        </div>--%>
    </div>
        <!-- form -->
		<!--<div class="button">
			<a href="#">Download source file</a>
		</div><!-- button -->
	</section><!-- content -->
</div><!-- container -->
</body>
</html>
