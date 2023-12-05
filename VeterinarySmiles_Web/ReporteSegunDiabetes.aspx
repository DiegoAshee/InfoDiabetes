<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteSegunDiabetes.aspx.cs" Inherits="VeterinarySmiles_Web.Reportes.ReporteSegunDiabetes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



  
<form id="form1" runat="server">
    <div class="container">
        <h1>Reporte según Grado de Diabetes</h1>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlGradoDiabetes">Grado de Diabetes:</asp:Label>
            <asp:DropDownList ID="ddlGradoDiabetes" runat="server" CssClass="form-control">
                <asp:ListItem Text="Nula" Value="Nula"></asp:ListItem>
                <asp:ListItem Text="Muy Bajo" Value="Muy Bajo"></asp:ListItem>
                <asp:ListItem Text="Bajo" Value="Bajo"></asp:ListItem>
                <asp:ListItem Text="Medio" Value="Medio"></asp:ListItem>
                <asp:ListItem Text="Alto" Value="Alto"></asp:ListItem>
                <asp:ListItem Text="Muy Alto" Value="Muy Alto"></asp:ListItem>
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
