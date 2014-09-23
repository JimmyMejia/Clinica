<%@ Page Title="Catálogo de Médicos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wf_Medicos.aspx.cs" Inherits="Clinica.wf_Medicos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">

        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">
                <p>Número de Cedula:</p>
            </div>
            <div class="col-xs-9 col-sm-4 col-md-3 col-lg-2">
                <asp:TextBox ID="tb_cedula" runat="server" MaxLength="16" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_cedula" runat="server" ControlToValidate="tb_cedula" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar la cedula del médico!!!"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">
                <p>Nombres:</p>
            </div>
            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                <asp:TextBox ID="tb_nombres" runat="server" MaxLength="40" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_nombres" runat="server" ControlToValidate="tb_nombres" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar los nombres del médico!!!"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">
                <p>Apellidos:</p>
            </div>
            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                <asp:TextBox ID="tb_apellidos" runat="server" MaxLength="40" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_apellidos" runat="server" ControlToValidate="tb_apellidos" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar los apellidos del médico!!!"></asp:RequiredFieldValidator>                    
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-11 col-md-2 col-lg-2">
                <p class="text-left">Fecha de Nacimiento:</p>
            </div>
            <div class="col-xs-8 col-sm-2 col-md-2 col-lg-2">
                <asp:TextBox ID="tb_fechaNacimiento" runat="server" CssClass="form-control" ></asp:TextBox>
                <asp:CalendarExtender ID="ce_fecha" runat="server" Format="dd/MM/yyyy" TargetControlID="tb_fechaNacimiento"></asp:CalendarExtender>
                <asp:MaskedEditExtender ID="me_fecha"  TargetControlID="tb_fechaNacimiento" Mask="99/99/9999" MaskType="Date" UserDateFormat="DayMonthYear" runat="server"> </asp:MaskedEditExtender>
                <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ControlToValidate="tb_fechaNacimiento" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar la fecha de nacimiento del médico!!!"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">
                <p>Dirección:</p>
            </div>
            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                <asp:TextBox ID="tb_direccion" runat="server" TextMode="MultiLine" MaxLength="150" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_direccion" runat="server" ControlToValidate="tb_direccion" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar la dirección del médico!!!"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-11 col-md-2 col-lg-2">
                <p>Celular:</p>
            </div>
            <div class="col-xs-8 col-sm-2 col-md-2 col-lg-2">
                <asp:TextBox ID="tb_celular" runat="server" MaxLength="8" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_celular" runat="server" ControlToValidate="tb_celular" Text="*" ForeColor="red"
                            ErrorMessage="Debe digitar el número de celular del médico!!!"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rv_celular" runat="server" ControlToValidate="tb_celular" Type="Integer" ForeColor="Red"
                            ErrorMessage="Número de celular inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-11 col-md-2 col-lg-2">
                <p>Teléfono:</p>
            </div>
            <div class="col-xs-8 col-sm-2 col-md-2 col-lg-2">
                <asp:TextBox ID="tb_telefono" runat="server" MaxLength="8" CssClass="form-control"></asp:TextBox>
                <asp:RangeValidator ID="rv_telefono" runat="server" ControlToValidate="tb_telefono" Type="Integer" ForeColor="Red"
                            ErrorMessage="Número de teléfono inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>                                       
            </div>
        </div>

        <div class="row">
            <div class="col-md-3 col-md-offset-2">
                <asp:Button ID="btn_Guardar" runat="server" Text="Guardar"  
                    CssClass="btn btn-primary" onclick="btn_Guardar_Click" />
                <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar" 
                    CausesValidation="false" CssClass="btn btn-primary" 
                    onclick="btn_Cancelar_Click"/>
             </div>
         </div>
    
         <div class="row">
            <div class="col-md-12">
                  <asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium" ></asp:Label>
            </div>
         </div>
         
         <div class="row">
            <div class="col-md-12">
                 <asp:CustomValidator ID="cv_datos" runat="server" ForeColor="Red" Text="*"> </asp:CustomValidator>
            </div>
          </div>

          <div class="row">
            <div class="col-md-12">
                 <asp:ValidationSummary ID="vs_errores" runat="server" ForeColor="red" Font-Size="Smaller" />
            </div>
          </div>

    </div>
</asp:Content>
