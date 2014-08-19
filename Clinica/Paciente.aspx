<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paciente.aspx.cs" Inherits="Clinica.Cliente" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        
        a:link
        {
           color: #034af3;
           text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <table class="style1">
            
                <tr>
                    <td style="width:150px;">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="wf_Paciente_Modificar.aspx" ForeColor="Blue">Modificar Paciente</asp:HyperLink>
                    </td>
                </tr>
            
                <tr>
                    <td style="width:150px;">
                        Nombres:</td>
                    <td>
            <asp:TextBox ID="tb_nombres" runat="server" Width="200px" MaxLength="40"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombres" runat="server" ControlToValidate="tb_nombres" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar los nombres del paciente!!!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Apellidos:</td>
                    <td>
            <asp:TextBox ID="tb_apellidos" runat="server" Width="200px" MaxLength="40"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_apellidos" runat="server" ControlToValidate="tb_apellidos" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar los apellidos del paciente!!!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fecha Nacimiento:</td>
                    <td>
            <asp:TextBox ID="tb_fechaNacimiento" runat="server"  ></asp:TextBox>
            <asp:CalendarExtender ID="ce_fecha" runat="server" Format="dd/MM/yyyy" TargetControlID="tb_fechaNacimiento" ></asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="me_fecha"  TargetControlID="tb_fechaNacimiento" Mask="99/99/9999" MaskType="Date" UserDateFormat="DayMonthYear" runat="server"> </asp:MaskedEditExtender>
                        <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ControlToValidate="tb_fechaNacimiento" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar la fecha de nacimiento del paciente!!!"></asp:RequiredFieldValidator>

                           
                    </td>
                </tr>
                <tr>
                    <td>
                        Dirección:</td>
                    <td>
            <asp:TextBox ID="tb_direccion" runat="server" TextMode="MultiLine" Width="200px" 
                            MaxLength="150"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_direccion" runat="server" ControlToValidate="tb_direccion" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar la dirección del paciente!!!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Celular:</td>
                    <td>
            <asp:TextBox ID="tb_celular" runat="server" MaxLength="8"></asp:TextBox>
                        <asp:RangeValidator ID="rv_celular" runat="server" ControlToValidate="tb_celular" Type="Integer" ForeColor="Red"
                            ErrorMessage="Número de celular inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Teléfono:</td>
                    <td>
            <asp:TextBox ID="tb_telefono" runat="server" MaxLength="8"></asp:TextBox>
                        <asp:RangeValidator ID="rv_telefono" runat="server" ControlToValidate="tb_telefono" Type="Integer" ForeColor="Red"
                            ErrorMessage="Número de teléfono inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
            <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" onclick="btn_Guardar_Click" />
            <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar" CausesValidation="false" 
                            onclick="btn_Cancelar_Click" />
    
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        </td>
                    <td class="style1">
                        <asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:CustomValidator ID="cv_informacion" runat="server" ForeColor="Red" Text="*"> </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:ValidationSummary ID="vs_errores" runat="server" ForeColor="red" Font-Size="Smaller" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>

    
</asp:Content>
