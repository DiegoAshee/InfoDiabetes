<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebAdmMenu.aspx.cs" Inherits="VeterinarySmiles_Web.WebAdmMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<form id="form1" runat="server">
    <div class="form-box"> 
        <section class="content-header"> 
            <h1 style="text-align:center">Menus</h1>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="box-body">
                        <div class=form-group>
                            <asp:Label Text="Nombre:" runat="server" />
                        </div>
                        <div class=form-group>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                            <asp:Label Text="" ID="lblcontrol" runat="server"/>
                        </div>
                        <asp:Label Text="Descripcion:" runat="server" />
                        <div class=form-group>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
                            <asp:Label Text="" ID="Label1" runat="server"/>
                        </div>
                        <asp:Label Text="Tipo de Menu:" runat="server" />
                        <div class="form-group">
                            <asp:DropDownList ID="cmbTipoMenu" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Bajo Peso" Value="Bajo Peso" />
                                <asp:ListItem Text="Normal" Value="Normal" />
                                <asp:ListItem Text="Sobre Peso" Value="Sobre Peso" />
                                <asp:ListItem Text="Obeso" Value="Obeso" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="box-body">
                    <asp:Button ID="btnInsert" Text="Insertar" runat="server" class='btn btn-sm btn-success' OnClick="btnInsert_Click" />
                </div>
                
            </div>
            <div class=form-group>
                            <asp:Label Text="" ID="lblControlFinal" runat="server"/>
                        </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="box-body">
                        <asp:GridView runat="server" ID="gridData" class="table table-borderless table-hover">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </section>
    </div>
</form>
















</asp:Content>
