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
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container">
        <div class="row">
            <div class="col-md-2">     
                <p class="text-left"> Fecha de la Cita:</p>
            </div>
            <div class="col-md-10">
                <asp:TextBox ID="tb_fechafiltro" runat="server"
                    ontextchanged="tb_fechafiltro_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fechafiltro" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_fechafiltro"
                    ErrorMessage="Debe digitar la fecha!!!"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="ce_fechafiltro" Format="dd/MM/yyyy" TargetControlID="tb_fechafiltro"  runat="server"></asp:CalendarExtender>
                <asp:MaskedEditExtender ID="me_fechafiltro" Mask="99/99/9999" TargetControlID="tb_fechafiltro" MaskType="Date" UserDateFormat="DayMonthYear"  runat="server">
                </asp:MaskedEditExtender>                
                <asp:Button ID="btn_filtrar" runat="server" Text="Filtrar" CausesValidation="false" CssClass="btn btn-success btn-sm"
                    onclick="btn_filtrar_Click" />
             </div>
        </div>

        <div class="row">
             <div class="col-md-2">     
                 <p class="text-left">Paciente:</p>
             </div> 
             <div class="col-md-10">   
                  <asp:DropDownList ID="ddl_paciente" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                        onselectedindexchanged="ddl_paciente_SelectedIndexChanged">
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="rfv_paciente" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_paciente" InitialValue="0" 
                        ErrorMessage="Debe seleccionar el paciente!!!"></asp:RequiredFieldValidator>
             </div>
        </div>

        <div class="row">        
            <div class="col-md-2">  
                <p class="text-left">Fecha:</p>
             </div>
            <div class="col-md-10">
                <asp:TextBox ID="tb_fecha" runat="server" Enabled ="false"></asp:TextBox>
                <asp:MaskedEditExtender ID="me_fecha" Mask="99/99/9999" TargetControlID="tb_fecha" MaskType="Date" UserDateFormat="DayMonthYear"  
                runat="server"></asp:MaskedEditExtender>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-2">
                <p class="text-left">Hora:</p>
            </div>
            <div class="col-md-10">
                <asp:TextBox ID="tb_hora" runat="server" Enabled ="false" Height="22px"></asp:TextBox>
                <asp:MaskedEditExtender ID="me_hora"  Mask="99:99" AcceptAMPM="true" MaskType="Time" TargetControlID="tb_hora" 
                runat="server"></asp:MaskedEditExtender>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <p class="text-left">Motivo:</p>
           </div>
            <div class="col-md-10">
                <%--<asp:RequiredFieldValidator ID="rfv_motivo" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_motivo" InitialValue="0"
                    ErrorMessage="Debe seleccionar el motivo!!!"></asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="tb_motivo" runat="server" Enabled ="false"></asp:TextBox>            
            </div>
            <br />             
            <br />
        </div>

        <div class="row">
            <div class="col-md-3 col-md-offset-2">
                <asp:Button ID="btn_atender" runat="server" Text="Atender"  CssClass="btn btn-primary" CausesValidation="false" Enabled ="false" />
           
                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" OnClick="btn_cancelar_Click" CausesValidation="false"/>
            </div>
            <br />
            <br />
        </div>

        <div class="row">
            <div class="col-md-2">
                <p class="text-left">Observaciones:</p>
            </div>
            <div class="col-md-10">
                <asp:TextBox ID="tb_observaciones" TextMode="MultiLine" Rows="10" Width="500px" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                 <p>
                    <asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium"></asp:Label>                
                 </p>
            </div>
        </div> 
        
         <div class="row">
            <div class="col-md-12">
                 <p>    
                    <asp:CustomValidator ID="cv_informacion" runat="server" Text="*" ForeColor="red"></asp:CustomValidator>
                </p>
            </div>
            <div class="col-md-12">
                <asp:ValidationSummary ID="vs_errores" runat="server" ForeColor="red" Font-Size="Smaller"/>
             </div>                
         </div>

</asp:Content>
