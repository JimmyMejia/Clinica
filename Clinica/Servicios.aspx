<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="Clinica.Servicios" MasterPageFile="~/Site.Master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
    .style1
    {
        height: 21px;
    }
</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <table style="width:100%;">
            <tr>
                <td style="width:200px;">
                    Descripción del Servicio:</td>
                <td >
                    <asp:TextBox ID="tb_descripcion" runat="server" Width="300px" MaxLength="50" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_descripcion" runat="server" ControlToValidate="tb_descripcion" ForeColor="Red"
                        ErrorMessage="Debe digitar la descripción!!!">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="tb_id" runat="server" Enabled="False" Height="21px"  Visible="false"
                         Width="70px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Precio:</td>
                <td style="margin-left: 40px">
                    <asp:TextBox ID="tb_precio" runat="server" Width="81px" MaxLength="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_precio" runat="server" ControlToValidate="tb_precio" ForeColor="Red"
                        ErrorMessage="Debe digitar el precio!!!" Text="*"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rv_precio" runat="server" ForeColor="Red" Type="Integer" MaximumValue="999" MinimumValue="1" 
                        ControlToValidate="tb_precio" ErrorMessage="Debe digitar números!!!" Text="*"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="btn_buscar" runat="server" onclick="btn_buscar_Click" 
                        Text="Buscar" CausesValidation="false" Visible="false" />
                </td>
                <td class="style1">
                    <asp:Button ID="btn_guardar" runat="server" onclick="btn_guardar_Click" 
                        Text="Guardar" />
                    <asp:Button ID="btn_Eliminar" runat="server" Text="Eliminar" CausesValidation="false" Enabled="false"
                        onclick="btn_Eliminar_Click" />
                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" 
                        CausesValidation="false" onclick="btn_cancelar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td style="margin-left: 40px">
                    <asp:Label ID="lb_mensajes" runat="server" Font-Size="Medium" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:CustomValidator ID="cv_wfServicios" runat="server" ForeColor="Red" Text="*" ></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="vs_wfServicios" runat="server" DisplayMode="List" ForeColor="Red" Font-Size="Smaller" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="gv_servicios" AutoGenerateSelectButton="True"
                        AllowPaging="true" PageSize="10" 
                       DataKeyNames="IdServicio" 
                        runat="server" BackColor="White" 
                        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Horizontal" 
                        onselectedindexchanged="gv_servicios_SelectedIndexChanged" 
                        onpageindexchanging="gv_servicios_PageIndexChanging">
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
        </table>
    
   </asp:Content>
