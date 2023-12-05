<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteSegunDatosPersona.aspx.cs" Inherits="VeterinarySmiles_Web.ReporteSegunDatosPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




    <form id="form1" runat="server">
    <div class="container">
        <h1>Búsqueda de Personas</h1>

        <div class="row">
            <div class="col-md-10">



            </div>

            <div class="col-md-2">

                <asp:Button ID="btnImprimeInforme" runat="server" Text="Imprime" onClick="btnImprimeInforme_Click" CssClass="btn btn-primary" style="text-align:right" />

            </div>
        </div>
        
        
        <div class="form-group">
            <h3>Búsqueda por Nombre</h3>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese nombre"></asp:TextBox>
            <asp:Button ID="btnBuscarNombre" runat="server" Text="Buscar por Nombre" OnClick="btnBuscarNombre_Click" CssClass="btn btn-primary" />
        </div>

        
        <div class="form-group">
            <h3>Búsqueda por CI</h3>
            <asp:TextBox ID="txtCI" runat="server" CssClass="form-control" placeholder="Ingrese CI"></asp:TextBox>
            <asp:Button ID="btnBuscarCI" runat="server" Text="Buscar por CI" OnClick="btnBuscarCI_Click" CssClass="btn btn-primary" />
        </div>

       
        

        
        <div class="row">
            <div class="col-md-12">
                <div class="box-body">
                    <asp:GridView runat="server" ID="gridData" CssClass="table table-borderless table-hover">
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblResultadoReporte" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</form>
















</asp:Content>
