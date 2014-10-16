<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wf_Reportes.aspx.cs" Inherits="Clinica.wf_Reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container">
        <div class="row">
            <div class = "col-xs-12 col-sm-11 col-md-11 col-lg-11">
                <rsweb:ReportViewer ID="rv_reportes" runat="server" Height="100%" Width="100%">
                </rsweb:ReportViewer>
            </div>
        </div>
    </div>
    
</asp:Content>
