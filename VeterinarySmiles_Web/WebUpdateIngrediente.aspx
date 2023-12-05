<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebUpdateIngrediente.aspx.cs" Inherits="VeterinarySmiles_Web.WebUpdateIngrediente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <form id="form1" runat="server">
    <div class="form-box">
        <h1>Actualizar Información de Ingrediente</h1>
        <div class="form-group">
            <asp:Label runat="server" Text="Nombre del Ingrediente:" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Unidad de Medida:" />
            <asp:TextBox ID="txtUnidadMedida" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Tipo de Alimento:" />
            <asp:TextBox ID="txtTipoAlimento" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Energía:" />
            <asp:TextBox ID="txtEnergia" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Proteína:" />
            <asp:TextBox ID="txtProteina" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Grasa:" />
            <asp:TextBox ID="txtGrasa" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Porcentaje de Azúcar:" />
            <asp:TextBox ID="txtPorcentajeAzucar" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Imagen Actual:" />
            <asp:Image ID="imgImagenActual" runat="server" CssClass="img-thumbnail" style="width:100px;height:80px;"/>
            <asp:FileUpload ID="fileUploadNuevaImagen" runat="server" />
        </div>

        <div class="row">
            <div class="col-md-10">
                <asp:Label Text="" ID="lblControlFinal" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="box-body">
                    <asp:Button ID="btnActualizar" Text="Actualizar" runat="server" OnClick="btnActualizar_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</form>












</asp:Content>
