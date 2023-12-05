<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebAdmIngrediente.aspx.cs" Inherits="VeterinarySmiles_Web.WebAdmIngrediente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <div class="form-box">
            <h1>Información Nutricional del Alimento</h1>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label runat="server" Text="Nombre del Alimento:" />
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
                </div>
                <div class="col-md-6">
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
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Imagen:" />
                <asp:FileUpload ID="fileUploadImagen" runat="server" />
            </div>

            <div class="row">
                <div class="col-md-10">
                    <asp:Label Text="" ID="lblControlFinal" runat="server" />
                </div>
            </div>
            <asp:Button ID="btnGuardar" Text="Guardar" runat="server" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
            <div class="row">
                <div class="col-md-12">
                    <div class="box-body">
                        <asp:GridView runat="server" ID="gridData" class="table table-borderless table-hover">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>

</asp:Content>
