<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wf_Citas_Atender.aspx.cs" Inherits="Clinica.wf_Citas_Atender" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 167px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<table class="style1">
        <tr>
            <td class="style2">
                Fecha de la Cita:</td>
            <td>
                <asp:TextBox ID="tb_fechafiltro" runat="server" 
                    ontextchanged="tb_fechafiltro_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fechafiltro" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_fechafiltro"
                    ErrorMessage="Debe digitar la fecha!!!"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="ce_fechafiltro" Format="dd/MM/yyyy" TargetControlID="tb_fechafiltro"  runat="server"></asp:CalendarExtender>
                <asp:MaskedEditExtender ID="me_fechafiltro" Mask="99/99/9999" TargetControlID="tb_fechafiltro" MaskType="Date" UserDateFormat="DayMonthYear"  runat="server">
                </asp:MaskedEditExtender>
                
                <asp:Button ID="btn_filtrar" runat="server" Text="Filtrar" CausesValidation="false"
                    onclick="btn_filtrar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Paciente:</td>
            <td>
                <asp:DropDownList ID="ddl_paciente" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                    onselectedindexchanged="ddl_paciente_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_paciente" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_paciente" InitialValue="0" 
                    ErrorMessage="Debe seleccionar el paciente!!!"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td class="style2">
                Fecha:</td>
            <td>
                <asp:TextBox ID="tb_fecha" runat="server" Enabled ="false"></asp:TextBox>
                <asp:MaskedEditExtender ID="me_fecha" Mask="99/99/9999" TargetControlID="tb_fecha" MaskType="Date" UserDateFormat="DayMonthYear"  
                runat="server"></asp:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Hora:</td>
            <td>
                <asp:TextBox ID="tb_hora" runat="server" Enabled ="false" Height="22px"></asp:TextBox>
                <asp:MaskedEditExtender ID="me_hora"  Mask="99:99" AcceptAMPM="true" MaskType="Time" TargetControlID="tb_hora" 
                runat="server"></asp:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Motivo:</td>
            <td>
                <%--<asp:RequiredFieldValidator ID="rfv_motivo" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_motivo" InitialValue="0"
                    ErrorMessage="Debe seleccionar el motivo!!!"></asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="tb_motivo" runat="server" Enabled ="false"></asp:TextBox>
            </td>
            </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_atender" runat="server" Text="Atender" 
                    CausesValidation="false" Enabled ="false" />
                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CausesValidation="false"/>
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
                <asp:CustomValidator ID="cv_informacion" runat="server" Text="*" ForeColor="red"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="vs_errores" runat="server" ForeColor="red" Font-Size="Smaller"/>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Observaciones:</td>
            <td>
                <asp:TextBox ID="tb_observaciones" TextMode="MultiLine" Rows="10" Width="500px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
