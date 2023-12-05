<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteSegunIMC.aspx.cs" Inherits="VeterinarySmiles_Web.ReporteSegunIMC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <form id="form1" runat="server">
    <div class="container">
        <h1>Reporte según Grado de IMC</h1>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlRangoIMC">Rango de IMC :</asp:Label>
            <asp:DropDownList ID="ddlRangoIMC" runat="server" CssClass="form-control">
                <asp:ListItem Text="Obeso Morbido" Value="ObesoMorbido"></asp:ListItem>
                <asp:ListItem Text="Obeso" Value="Obeso"></asp:ListItem>
                <asp:ListItem Text="Sobrepeso" Value="Sobrepeso"></asp:ListItem>
                <asp:ListItem Text="Normal" Value="Normal"></asp:ListItem>
                <asp:ListItem Text="Bajo Peso" Value="BajoPeso"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporte_Click" CssClass="btn btn-primary" />

         <asp:Button ID="btnImprimeReporte" runat="server" Text="Imprime Reporte Reporte" OnClick="btnImprimeReporte_Click" CssClass="btn btn-primary" />
       
        <asp:Label ID="lblResultadoReporte" runat="server"></asp:Label>

        <div class="row">
            <div class="col-md-12">
                <div class="box-body">
                    <asp:GridView runat="server" ID="gridData" CssClass="table table-borderless table-hover">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</form>
  










</asp:Content>
