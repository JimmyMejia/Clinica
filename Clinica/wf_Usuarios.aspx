<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wf_Usuarios.aspx.cs" Inherits="Clinica.wf_Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 175px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container">    
            <table class="style1">
        <tr>
            <td class="style2">
                Usuario:</td>
            <td>
                <asp:TextBox ID="tb_usuario" runat="server" MaxLength="10" 
                    ToolTip="Nombre de usuario"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" ErrorMessage="Debe digitar el usuario!!!" Text="*" 
                ControlToValidate="tb_usuario" ForeColor="Red" ></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Contraseña:</td>
            <td>
                <asp:TextBox ID="tb_contrasenia" runat="server" TextMode="Password" 
                    ToolTip="Digite la contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_contra" runat="server" ErrorMessage="Debe verificar la contraseña!!!" Text="*" 
                ControlToValidate="tb_contrasenia" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Verifique la Contraseña:</td>
            <td>
                <asp:TextBox ID="tb_contraseniaverificacion" runat="server" TextMode="Password" 
                    ToolTip="Verifique la contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_contraveri" runat="server" ErrorMessage="Debe digitar la contraseña!!!" Text="*" 
                ControlToValidate="tb_contraseniaverificacion" ForeColor="Red"></asp:RequiredFieldValidator><asp:CompareValidator 
                    ID="cv_contrasenias" runat="server" Text="*" ForeColor="Red" ErrorMessage="Las contraseñas deben ser iguales!!!"
                    ControlToValidate="tb_contraseniaverificacion" ControlToCompare="tb_contrasenia" Display="Dynamic" Type="String" Operator="Equal"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar" 
                    onclick="btn_guardar_Click" />
                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar"  
                    CausesValidation="false" onclick="btn_cancelar_Click"/>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:CustomValidator ID="cv_datos" runat="server" ForeColor="Red"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="vs_errores" ForeColor="Red" Font-Size="Smaller" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
</asp:Content>
