<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wf_Citas_Modificar.aspx.cs" Inherits="Clinica.wf_Citas_Modificar" %>

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
                <asp:TextBox ID="tb_fechafiltro" runat="server"></asp:TextBox>
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
                <asp:DropDownList ID="ddl_paciente" runat="server" AppendDataBoundItems="true" Enabled ="false">
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_fecha"
                    ErrorMessage="Debe digitar la fecha!!!"></asp:RequiredFieldValidator>
                    <asp:CalendarExtender ID="ce_fecha" Format="dd/MM/yyyy" TargetControlID="tb_fecha"  runat="server"></asp:CalendarExtender>
                <asp:MaskedEditExtender ID="me_fecha" Mask="99/99/9999" TargetControlID="tb_fecha" MaskType="Date" UserDateFormat="DayMonthYear"  runat="server">
                </asp:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Hora:</td>
            <td>
                <asp:TextBox ID="tb_hora" runat="server" Enabled ="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_hora" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_hora" 
                    ErrorMessage="Debe digitar la hora!!!"></asp:RequiredFieldValidator>
                <asp:MaskedEditExtender ID="me_hora"  Mask="99:99" AcceptAMPM="true" MaskType="Time" TargetControlID="tb_hora" runat="server">
                </asp:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Motivo:</td>
            <td>
                <asp:DropDownList ID="ddl_motivo" runat="server" AppendDataBoundItems="true" Enabled="false" >
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_motivo" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_motivo" InitialValue="0"
                    ErrorMessage="Debe seleccionar el motivo!!!"></asp:RequiredFieldValidator>
            </td>
            </tr>
        <tr>
            <td class="style2">
                Estado:</td>
            <td>
                <asp:RadioButton ID="rb_activa" runat="server" Text="Activa" GroupName="estado" Enabled="false"/>
                <asp:RadioButton ID="rb_cancelada" runat="server" Text="Cancelada" GroupName="estado" Enabled="false"/>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_modificar" runat="server" Text="Modificar" 
                    CausesValidation="false" Enabled ="false" onclick="btn_modificar_Click"/>
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
                &nbsp;</td>
            <td>
                <asp:GridView ID="gv_citas" AutoGenerateSelectButton="True" PageSize="2"
                    DataKeyNames="IdCita" AllowPaging="True" runat="server" OnPageIndexChanging="gv_citas_PageIndexChanging"
                    onselectedindexchanged="gv_citas_SelectedIndexChanged" BackColor="White" 
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    GridLines="Horizontal">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
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
