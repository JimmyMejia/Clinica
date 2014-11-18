<%@ Page Title="Factura" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wf_Factura.aspx.cs" Inherits="Clinica.wf_Factura" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">

        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2">
                <p>Fecha de la Cita:</p>
            </div>
            <div class="col-xs-8 col-sm-3 col-md-2 col-lg-2">
                <asp:TextBox ID="tb_fechafiltro" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fechafiltro" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_fechafiltro"
                    ErrorMessage="Debe digitar la fecha!!!"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="ce_fechafiltro" Format="dd/MM/yyyy" TargetControlID="tb_fechafiltro"  runat="server"></asp:CalendarExtender>
                <asp:MaskedEditExtender ID="me_fechafiltro" Mask="99/99/9999" TargetControlID="tb_fechafiltro" MaskType="Date" UserDateFormat="DayMonthYear"  runat="server">
                </asp:MaskedEditExtender>                
            </div>
            <asp:Button ID="btn_filtrar" runat="server" Text="Filtrar" 
                CausesValidation="false" CssClass="btn btn-success btn-sm" 
                onclick="btn_filtrar_Click" />
        </div>

         <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">
                <p>Paciente:</p>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                <asp:DropDownList ID="ddl_paciente" runat="server" AppendDataBoundItems="true" 
                    CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_paciente" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_paciente" InitialValue="0" 
                    ErrorMessage="Debe seleccionar el paciente!!!"></asp:RequiredFieldValidator>        
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-11 col-md-2 col-lg-2">
                <p>Fecha:</p>
            </div>
            <div class="col-xs-8 col-sm-2 col-md-2 col-lg-2">
                <asp:TextBox ID="tb_fecha" runat="server" ReadOnly="true" Enabled="false" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_fecha"
                    ErrorMessage="Debe digitar la fecha!!!"></asp:RequiredFieldValidator>
                    <asp:CalendarExtender ID="ce_fecha" Format="dd/MM/yyyy" TargetControlID="tb_fecha"  runat="server"></asp:CalendarExtender>
                <asp:MaskedEditExtender ID="me_fecha" Mask="99/99/9999" TargetControlID="tb_fecha" MaskType="Date" UserDateFormat="DayMonthYear"  runat="server">
                </asp:MaskedEditExtender>       
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-2 col-lg-2">
                <p>Servicio:</p>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                <asp:DropDownList ID="ddl_motivo" runat="server" AppendDataBoundItems="true" 
                    Enabled="false" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_motivo" runat="server" ForeColor="red" Text="*" ControlToValidate="ddl_motivo" InitialValue="0"
                    ErrorMessage="Debe seleccionar el motivo!!!"></asp:RequiredFieldValidator>  
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2">
                <p>Cantidad:</p>
            </div>
            <div class="col-xs-4 col-sm-2 col-md-1 col-lg-1">
                <asp:TextBox ID="tb_cantidad" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_cantidad" runat="server" ForeColor="red" Text="*" ControlToValidate="tb_cantidad"
                    ErrorMessage="Debe digitar la cantidad!!!"></asp:RequiredFieldValidator>  
            </div>
        </div>


        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-10 col-md-offset-2 col-lg-6 col-lg-offset-2">
                <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-primary" Enabled ="false" onclick="btn_agregar_Click"/>
                <asp:Button ID="btn_facturar" runat="server" Text="Facturar" CssClass="btn btn-primary" 
                    CausesValidation="false" Enabled ="false" onclick="btn_facturar_Click"/>
                    
                <asp:Button ID="btn_imprimir" runat="server" Text="Imprimir" CssClass="btn btn-primary" 
                    CausesValidation="false" Enabled ="false" onclick="btn_imprimir_Click"/>
                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" 
                    CausesValidation="false" onclick="btn_cancelar_Click"/>
                    
            </div>
        </div>
        
        </br>
        <div class="row">
            <div class="col-xs-12 col-sm-10 col-md-11 col-lg-11">
                <div class="table-responsive">                
                    <asp:GridView ID="gv_detalle" runat="server" BackColor="White" 
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
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HeaderStyle-Width="70%"/>
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-Width="15%"/>
                            <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" HeaderStyle-Width="15%"/>
                        </Columns>

                    </asp:GridView>
                </div>
                <asp:Label ID="Label1" runat="server" Text="Total:" Font-Bold="true" Visible="false"></asp:Label>
                <asp:Label ID="lb_moneda" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lb_total" runat="server" Visible="false"></asp:Label>
            </div>


        </div>
        
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium"></asp:Label>
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

    <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-11 col-md-11 col-lg-11">
                    <div class="table-responsive">
                        <asp:GridView ID="gv_citas" AutoGenerateSelectButton="True" PageSize="10" CssClass="table"
                            DataKeyNames="IdCita" AllowPaging="True" runat="server"  BackColor="White" 
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
                                <asp:BoundField DataField="Paciente" HeaderText="Paciente" HeaderStyle-Width="20%" />
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Médico" HeaderStyle-Width="20%" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"/>
                                <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            </Columns>
                                                     
                       </asp:GridView>
                    </div>
                </div>
            </div>
     </div>  
</asp:Content>
