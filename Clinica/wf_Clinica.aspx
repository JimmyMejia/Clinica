<%@ Page Title="Catálogo de Clinica" Language="C#" AutoEventWireup="true" CodeBehind="wf_Clinica.aspx.cs" Inherits="Clinica.Clinica" MasterPageFile="~/Site.Master" %>

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
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">   
                <p class="text-left">Nombre de la clinica:</p>                     
            </div>
            <div class="col-xs-12 col-sm-10 col-md-6 col-lg-4">
                <asp:TextBox ID="tb_clinica" runat="server"  MaxLength="50" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_clinica" runat="server" ForeColor="red" ControlToValidate="tb_clinica" Text="*"
                            ErrorMessage="Nombre de la clinica es requerido!!!"></asp:RequiredFieldValidator>
            </div>
        </div>        

        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">   
               <p class="text-left">Dirección: </p>         
            </div> 
            <div class="col-xs-12 col-sm-10 col-md-6 col-lg-4">
                 <asp:TextBox ID="tb_direccion" runat="server" TextMode="MultiLine" MaxLength="100" CssClass="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfv_direccion" runat="server" ForeColor="red" ControlToValidate="tb_direccion" Text="*"
                            ErrorMessage="Dirección es requerida!!!"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">   
                <p class="text-left">Email:</p>
            </div> 
            <div class="col-xs-12 col-sm-8 col-md-4 col-lg-4">
                <asp:TextBox ID="tb_email" runat="server" MaxLength="40" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rev_email" runat="server" ControlToValidate="tb_email" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                            ErrorMessage="Email inválido!!!" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
             </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2">   
               <p class="text-left">Teléfono:</p>
            </div> 
            <div class="col-xs-7 col-sm-3 col-md-2 col-lg-2">
                <asp:TextBox ID="tb_telefono" runat="server" MaxLength="8" CssClass="form-control"></asp:TextBox>
                <asp:RangeValidator ID="rvTelefono" runat="server" ControlToValidate="tb_telefono" Type="Integer" ForeColor="Red" Text="*"
                            ErrorMessage="Número de teléfono inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>
            </div>
        </div>

         <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2">   
               <p class="text-left">Celular:</p>
            </div> 
            <div class="col-xs-7 col-sm-3 col-md-2 col-lg-2">
                 <asp:TextBox ID="tb_celular" runat="server" MaxLength="8" CssClass="form-control"></asp:TextBox>
                 <asp:RangeValidator ID="rv_celular" runat="server" ControlToValidate="tb_celular" Type="Integer" ForeColor="Red" Text="*"
                            ErrorMessage="Número de celular inválido!!!" MinimumValue="1" MaximumValue="99999999"></asp:RangeValidator>
             </div>
        </div>

        <div class="row">
           <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">               
               <p class="text-left">Logo:</p>
            </div> 
            <div class="col-xs-12 col-sm-10 col-md-8 col-lg-7">                
                 <asp:FileUpload ID="fu_logo" runat="server" CssClass="form-control" />
            </div>                       
        </div>

        <div class="row">
            <div class="col-md-2 col-md-offset-1">   
                <div class="checkbox">
                    <asp:CheckBox ID="chk_previa" runat="server" Text="Previa" Visible= "false" 
                        OnCheckedChanged="chk_previa_CheckedChanged" AutoPostBack="true"/>
                </div>                    
            </div> 
        </div>

        <br />
        <div class="row">
           <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">               
               <p class="text-left"><asp:Label ID="lb_previa" runat="server" Text="Previa:" Visible="false"></asp:Label></p>
            </div> 
            <%--<div class="col-xs-12 col-sm-10 col-md-8 col-lg-7">--%>
            <asp:Image ID="Logo" runat="server" CssClass="img-responsive" Visible="false" Height="25%" Width="25%" />
           <%-- </div> --%>                      
        </div>        

        <div class="row">
            <div class="col-md-2 col-md-offset-1">   
                <div class="checkbox">
                    <asp:CheckBox ID="chk_activa" runat="server" Text="Activa"/>
                </div>                    
            </div> 
        </div>

        <div class="row">
            <div class="col-md-3 col-md-offset-2">  
                 <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-primary" onclick="btn_guardar_Click" />
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
                 <p><asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium"></asp:Label></p>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12"> 
                 <asp:ValidationSummary ID="vs_Errores"  ForeColor="Red" Font-Size="Smaller" runat="server" />
            </div>
        </div>

    </div>

        <div class="container">        
        <div class="row">
            <div class="col-xs-12 col-sm-11 col-md-11 col-lg-11">
                    <div class="table-responsive">                          
                            <asp:GridView ID="gv_clinicas" runat="server" BackColor="White" CssClass="table"
                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                GridLines="Vertical" AutoGenerateColumns="False">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#000065" />

                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-Width="30%" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" HeaderStyle-Width="30%" />
                                    <asp:BoundField DataField="Email" HeaderText="Correo" HeaderStyle-Width="30%" />
                                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" HeaderStyle-Width="30%" />
                                    <asp:BoundField DataField="Celular" HeaderText="Celular" HeaderStyle-Width="30%" />
                                    <asp:BoundField DataField="Activo" HeaderText="Estado" HeaderStyle-Width="30%" />
                                    <asp:TemplateField ItemStyle-CssClass="TemplateFieldOneColumn" HeaderText="Activa">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<% #GetLabelText(Eval("Activo")) %>' />
                                    </ItemTemplate>
                                 </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                    </div>
            </div>    
        </div>
        </div>

   
               <%--<% Negocio.clinicaNegocio dc = new Negocio.clinicaNegocio();
              List<Entidad.Clinica> clinica = null;
              clinica = dc.Clinicas(); %>
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-7 col-lg-11"> 
                    <div class="table-responsive">
                        <table class="table"> 
                            <tr><td>Id Clinica</td><td>Nombre</td><td>Dirección</td><td>Email</td><td>Teléfono</td><td>Celular</td><td>Logo</td><td>Activa</td></tr>
                            <% if (dc != null)
                               {
                                   foreach (var item in dc)
                                   {%>
                                   <tr><td><%=item.IdClinica %></td><td><%=item.Nombre %></td><td><%=item.Direccion %></td><td><%=item.Email %></td><td><%=item.Telefono %></td><td><%=item.Celular %></td><td><%=item.Logo %></td><td><%=item.Activa %></td></tr>   
                                   <% }
                               } %>
                       </table>
                   </div>
              </div>
        </div>--%>
          
   <%--</div>--%>
    
</asp:Content>