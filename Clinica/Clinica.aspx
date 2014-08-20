<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clinica.aspx.cs" Inherits="Clinica.Clinica" MasterPageFile="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 755px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
        <table class="style1">
            <tr>
                <td style="width:200px;">
                    Nombre de la clinica:</td>
                <td>
                    <asp:TextBox ID="tb_clinica" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_clinica" runat="server" ForeColor="red" ControlToValidate="tb_clinica" Text="*"
                        ErrorMessage="Nombre de la clinica es requerido!!!"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Dirección:</td>
                <td>
                    <asp:TextBox ID="tb_direccion" runat="server" TextMode="MultiLine" 
                        Width="200px" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_direccion" runat="server" ForeColor="red" ControlToValidate="tb_direccion" Text="*"
                        ErrorMessage="Dirección es requerida!!!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Email:</td>
                <td>
                    <asp:TextBox ID="tb_email" runat="server" Width="200px" MaxLength="40"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rev_email" runat="server" ControlToValidate="tb_email" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                        ErrorMessage="Email inválido!!!" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Teléfono:</td>
                <td>
                    <asp:TextBox ID="tb_telefono" runat="server" MaxLength="8"></asp:TextBox>
                    <asp:RangeValidator ID="rvTelefono" runat="server" ControlToValidate="tb_telefono" Type="Integer" ForeColor="Red" Text="*"
                        ErrorMessage="Número de teléfono inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Celular:</td>
                <td>
                    <asp:TextBox ID="tb_celular" runat="server" MaxLength="8"></asp:TextBox>
                    <asp:RangeValidator ID="rv_celular" runat="server" ControlToValidate="tb_celular" Type="Integer" ForeColor="Red" Text="*"
                        ErrorMessage="Número de celular inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Logo:</td>
                <td>
                    <asp:FileUpload ID="fu_logo" runat="server" Width="250px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:CheckBox ID="chk_activa" runat="server" Text="Activa" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="tn_guardar" runat="server" Text="Guardar" 
                        onclick="tn_guardar_Click" />
                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" 
                        onclick="btn_cancelar_Click"  CausesValidation="false"  />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:CustomValidator ID="cv_Datos" runat="server" Text="*" ForeColor="red"></asp:CustomValidator>
                    <asp:CustomValidator ID="cv_Satisfactorio" runat="server"  ForeColor="green"></asp:CustomValidator>
                    <asp:ValidationSummary ID="vs_Errores"  ForeColor="Red" Font-Size="Smaller" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="gv_clinicas" runat="server" Width="500px">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
</asp:Content>