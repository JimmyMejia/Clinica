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
    
    <div class="container">    
        <div class="row">
            <div class="col-md-2">   
                <p class="text-left">Nombre de la clinica:</p>                     
            </div>
            <div class="col-md-10">
                        <asp:TextBox ID="tb_clinica" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_clinica" runat="server" ForeColor="red" ControlToValidate="tb_clinica" Text="*"
                            ErrorMessage="Nombre de la clinica es requerido!!!"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">   
               <p class="text-left">Dirección: </p>         
            </div> 
            <div class="col-md-10">
                 <asp:TextBox ID="tb_direccion" runat="server" TextMode="MultiLine" Width="200px" MaxLength="100"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfv_direccion" runat="server" ForeColor="red" ControlToValidate="tb_direccion" Text="*"
                            ErrorMessage="Dirección es requerida!!!"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">   
                <p class="text-left">Email:</p>
            </div> 
            <div class="col-md-10">
                <asp:TextBox ID="tb_email" runat="server" Width="200px" MaxLength="40"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rev_email" runat="server" ControlToValidate="tb_email" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                            ErrorMessage="Email inválido!!!" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
             </div>
        </div>

        <div class="row">
            <div class="col-md-2">   
               <p class="text-left">Teléfono:</p>
            </div> 
            <div class="col-md-10">
                <asp:TextBox ID="tb_telefono" runat="server" MaxLength="8"></asp:TextBox>
                <asp:RangeValidator ID="rvTelefono" runat="server" ControlToValidate="tb_telefono" Type="Integer" ForeColor="Red" Text="*"
                            ErrorMessage="Número de teléfono inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>
            </div>
        </div>

         <div class="row">
            <div class="col-md-2">   
               <p class="text-left">Celular:</p>
            </div> 
            <div class="col-md-10">
                 <asp:TextBox ID="tb_celular" runat="server" MaxLength="8"></asp:TextBox>
                 <asp:RangeValidator ID="rv_celular" runat="server" ControlToValidate="tb_celular" Type="Integer" ForeColor="Red" Text="*"
                            ErrorMessage="Número de celular inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>
             </div>
        </div>

        <div class="row">
            <div class="col-md-2">   
               <p class="text-left">Logo:</p>
            </div> 
            <div class="col-md-10">
                <div class="form-group">
                    <asp:FileUpload ID="fu_logo" runat="server" Width="250px" />
                </div>             
            </div>
        </div>

        <div class="row">
            <div class="col-md-2 col-md-offset-1">   
                <div class="checkbox">
                    <asp:CheckBox ID="chk_activa" runat="server" Text="Activa" />
                </div>                    
            </div> 
        </div>

        <div class="row">
            <div class="col-md-3 col-md-offset-2">  
                 <asp:Button ID="tn_guardar" runat="server" Text="Guardar" CssClass="btn btn-primary" onclick="tn_guardar_Click" />
                  <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" onclick="btn_cancelar_Click"  CausesValidation="false"  />
            </div>
        </div>
           
        <div class="row">
            <div class="col-md-12"> 
                 <asp:CustomValidator ID="cv_Datos" runat="server" Text="*" ForeColor="red"></asp:CustomValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12"> 
                 <asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12"> 
                 <asp:ValidationSummary ID="vs_Errores"  ForeColor="Red" Font-Size="Smaller" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-10"> 
                <div class="table-responsive">
                    <table class="table">                
                        <asp:GridView ID="gv_clinicas" runat="server" BackColor="White" 
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
                    </table>
                </div>
            </div>          
        </div>
          
   </div>
    
</asp:Content>