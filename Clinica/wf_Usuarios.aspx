<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wf_Usuarios.aspx.cs" Inherits="Clinica.wf_Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 175px;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container">    

        <div class="row">
            <div class="form-group">            
            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
                <p>Nombre:</p>
            </div>
            <div class="col-xs-12 col-sm-5 col-md-5 col-lg-5">                
                <asp:TextBox ID="tb_nombre" runat="server" MaxLength="80"  CssClass="form-control"
                    ToolTip="Nombre de usuario"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ErrorMessage="Debe digitar el nombre!!!" Text="*" 
                ControlToValidate="tb_nombre" ForeColor="Red" ></asp:RequiredFieldValidator>
            </div>
            </div>
        </div>

        <div class="row">
            <div class="form-group">            
            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
                <p>Usuario:</p>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-2">                
                <asp:TextBox ID="tb_usuario" runat="server" MaxLength="10"  CssClass="form-control"
                    ToolTip="Nombre de usuario"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" ErrorMessage="Debe digitar el usuario!!!" Text="*" 
                ControlToValidate="tb_usuario" ForeColor="Red" ></asp:RequiredFieldValidator>
            </div>
            </div>
        </div>

        <div class="row">
            <div class="form-group">
            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
                    <p>Contraseña:</p>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-2">
                    <asp:TextBox ID="tb_contrasenia" runat="server" TextMode="Password" CssClass="form-control"
                        ToolTip="Digite la contraseña"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_contra" runat="server" ErrorMessage="Debe verificar la contraseña!!!" Text="*" 
                    ControlToValidate="tb_contrasenia" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            </div>
        </div>

        <div class="row">
            <div class="form-group">
            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
                <p>Verifique la Contraseña:</p>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-2">
                <asp:TextBox ID="tb_contraseniaverificacion" runat="server" TextMode="Password" CssClass="form-control"
                    ToolTip="Verifique la contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_contraveri" runat="server" ErrorMessage="Debe digitar la contraseña!!!" Text="*" 
                ControlToValidate="tb_contraseniaverificacion" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv_contrasenias" runat="server" Text="*" ForeColor="Red" ErrorMessage="Las contraseñas deben ser iguales!!!"
                    ControlToValidate="tb_contraseniaverificacion" ControlToCompare="tb_contrasenia" Display="Dynamic" Type="String" 
                    Operator="Equal"></asp:CompareValidator>
            </div>                
            </div>
        </div>

        <div class="row">
            <div class="form-group">
            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
                    <p><asp:Label ID="lb_rol" runat="server" Text="Rol:"></asp:Label></p>
            </div>
            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-2">
                    <asp:DropDownList ID="ddl_rol" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                </asp:DropDownList>
            </div>                
            </div>
        </div>
        </br>

        <div class="row">
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-3 col-md-offset-2 col-lg-8">
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-primary"
                    onclick="btn_guardar_Click" />
                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar"  CssClass="btn btn-primary"
                    CausesValidation="false" onclick="btn_cancelar_Click"/>
            </div>            
        </div>

        <div class="row">
            <p>
                <asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium"></asp:Label>
            </p>
        </div>
        
        <div class="row">
            <p>
                <asp:CustomValidator ID="cv_datos" runat="server" ForeColor="Red"></asp:CustomValidator>
            </p>
        </div>

        <div class="row">
            <p>
                <asp:ValidationSummary ID="vs_errores" ForeColor="Red" Font-Size="Smaller" runat="server" />
            </p>
        </div>         

    </div>

</asp:Content>
