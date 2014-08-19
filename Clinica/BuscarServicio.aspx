<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarServicio.aspx.cs" Inherits="Clinica.BuscarServicio" MasterPageFile="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <% Negocio.serviciosNegocio dc = new Negocio.serviciosNegocio();
   List<Entidad.Cat_Servicio> cs = null;
        if (tb_descripcion.Text != "")
           cs = dc.BuscarDescripcionServicio(tb_descripcion.Text.Trim());
   
     %>

    <table class="style1">
        <tr>
            <td style="width:100px;">
                Servicio:</td>
            <td>
                <asp:TextBox ID="tb_descripcion" runat="server"></asp:TextBox>
                <asp:TextBox ID="tb_id" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="cv_validacion" runat="server" Text="*" ForeColor="Red"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="rfv_id" runat="server" ForeColor="Red" ControlToValidate="tb_descripcion" Text="*"
                    ErrorMessage="Digite el servicio a buscar!!!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="tb_precio" runat="server" Enabled="False"></asp:TextBox>
                <asp:DropDownList ID="ddl_CatServicios" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddl_CatServicios_SelectedIndexChanged" AppendDataBoundItems="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:GridView ID="gv_CatServicios" runat="server" 
                    onselectedindexchanged="gv_CatServicios_SelectedIndexChanged" AutoGenerateSelectButton="true" DataKeyNames="IdServicio" >
                </asp:GridView>
                <table>
                <tr><td>ID</td><td>Descripcion</td><td>Precio</td></tr>
                <% if (cs != null)
                   {
                       foreach (var item in cs)
                       {%>
                       <tr><td><%=item.IdServicio %></td><td><%=item.Descripcion %></td><td><%=item.Precio %></td></tr>   
                       <% }
                   } %>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_buscar" runat="server" Text="Buscar" 
                    onclick="btn_buscar_Click" />
                <asp:Button ID="btn_filtrar" runat="server" onclick="btn_filtrar_Click" 
                    Text="Filtrar" CausesValidation="false"/>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Atras" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="vs_validacion" runat="server" DisplayMode="List" Font-Size="Smaller" ForeColor="Red"  />
            </td>
        </tr>
    </table>


</asp:Content>
