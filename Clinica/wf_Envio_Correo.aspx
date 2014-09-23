<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wf_Envio_Correo.aspx.cs" Inherits="Clinica.wf_Envio_Correo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
//    $(document).ready(function () {
        function OcultarLabel() {
            setInterval(function () {
                $("#<%= Label1.ClientID %>").hide(2000)
            }, 5000);
        });
        </script>

    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
                <p>Para:</p>
            </div>
            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">                
                <asp:TextBox ID="tb_para" runat="server" CssClass="form-control"></asp:TextBox>
            </div>            
        </div>
        </br>

        <div class="row">
            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
             <p>Asunto:</p>
            </div>
            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                <asp:TextBox ID="tb_asunto" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        </br>

        <div class="row">
            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
             <p>Contenido:</p>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <asp:TextBox ID="tb_contenido" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        </br>

        <div class="row">
            <div class="col-md-3 col-md-offset-2">
                <asp:Button ID="btn_enviar" runat="server" Text="Enviar" 
                    CssClass="btn btn-primary" onclick="btn_enviar_Click" />
            </div>            
        </div>
        </br>

        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-10 col-lg-10">
                <asp:Label ID="lb_mensaje" runat="server"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Este label desaparecerá!!!"></asp:Label>
            </div>  
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
                <asp:CustomValidator ID="cv_Datos" runat="server" ></asp:CustomValidator>
            </div>  
        </div>

    </div>        

</asp:Content>
