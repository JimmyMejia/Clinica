<%@ Page Title="Registro de Cita" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wf_Citas.aspx.cs" Inherits="Clinica.wf_Citas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 153px;
        }
        a:link
        {
            text-decoration: none;
            color: Blue;
        }
        a:hover
        {
            color:Black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <div class="row">        
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/wf_Citas_Modificar.aspx" Font-Size="Small">Modificar Cita</asp:HyperLink>
            </div>       
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/wf_Citas_Atender.aspx" Font-Size="Small">Atender Cita</asp:HyperLink>
            </div>
        </div>

        <div class="row">        
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">
                <p>Paciente:</p>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                <asp:DropDownList ID="ddl_paciente" runat="server" AppendDataBoundItems="true" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_paciente" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_paciente" InitialValue="0" 
                    ErrorMessage="Debe seleccionar el paciente!!!"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">        
            <div class="col-xs-12 col-sm-11 col-md-2 col-lg-2">
                <p>Fecha:</p>
            </div>
            <div class="col-xs-8 col-sm-2 col-md-2 col-lg-2">
                <asp:TextBox ID="tb_fecha" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_fecha"
                    ErrorMessage="Debe digitar la fecha!!!"></asp:RequiredFieldValidator>
                    <asp:CalendarExtender ID="ce_fecha" Format="dd/MM/yyyy" TargetControlID="tb_fecha"  runat="server"></asp:CalendarExtender>
                <asp:MaskedEditExtender ID="me_fecha" Mask="99/99/9999" TargetControlID="tb_fecha" MaskType="Date" UserDateFormat="DayMonthYear"  runat="server">
                </asp:MaskedEditExtender>
            </div>
        </div>

        <div class="row">        
            <div class="col-xs-12 col-sm-11 col-md-2 col-lg-2">
                <p>Hora:</p>
            </div>
            <div class="col-xs-8 col-sm-2 col-md-2 col-lg-2">
                <asp:TextBox ID="tb_hora" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_hora" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_hora" 
                    ErrorMessage="Debe digitar la hora!!!"></asp:RequiredFieldValidator>
                <asp:MaskedEditExtender ID="me_hora"  Mask="99:99" AcceptAMPM="true" MaskType="Time" TargetControlID="tb_hora" runat="server">
                </asp:MaskedEditExtender>
            </div>
        </div>

        <div class="row">        
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">
                <p>Motivo:</p>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                 <asp:DropDownList ID="ddl_motivo" runat="server" AppendDataBoundItems="true" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_motivo" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_motivo" InitialValue="0"
                    ErrorMessage="Debe seleccionar el motivo!!!"></asp:RequiredFieldValidator>
            </div>
        </div>

         <div class="row">        
            <div class="col-md-3 col-md-offset-2">
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar" onclick="btn_guardar_Click"  CssClass="btn btn-primary"/>
                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CausesValidation="false" onclick="btn_cancelar_Click"  CssClass="btn btn-primary"/>
            </div>
        </div>

        <div class="row">        
            <div class="col-md-12">
                <p><asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium"></asp:Label></p>
            </div>
        </div>
        
        <div class="row">        
            <div class="col-md-12">
                <asp:CustomValidator ID="cv_informacion" runat="server" Text="*" ForeColor="red"></asp:CustomValidator>
            </div>
        </div>
        
        <div class="row">        
            <div class="col-md-12">
                <asp:ValidationSummary ID="vs_errores" runat="server" ForeColor="red" Font-Size="Smaller"/>
            </div>
        </div>

    </div>
    <%--<table class="style1">
        
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/wf_Citas_Modificar.aspx" Font-Size="Small">Modificar Cita</asp:HyperLink>
                
            &nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/wf_Citas_Atender.aspx" Font-Size="Small">Atender Cita</asp:HyperLink>
                
            </td>
        </tr>
        
        <tr>
            <td class="style2">
                Paciente:</td>
            <td>
                <asp:DropDownList ID="ddl_paciente" runat="server" AppendDataBoundItems="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_paciente" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_paciente" InitialValue="0" 
                    ErrorMessage="Debe seleccionar el paciente!!!"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td class="style2">
                Fecha:</td>
            <td>
                <asp:TextBox ID="tb_fecha" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_fecha"
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
                <asp:TextBox ID="tb_hora" runat="server"></asp:TextBox>
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
                <asp:DropDownList ID="ddl_motivo" runat="server" AppendDataBoundItems="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_motivo" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_motivo" InitialValue="0"
                    ErrorMessage="Debe seleccionar el motivo!!!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar" 
                    onclick="btn_guardar_Click" />
                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" 
                    CausesValidation="false" onclick="btn_cancelar_Click" />
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
    </table>--%>
</asp:Content>
