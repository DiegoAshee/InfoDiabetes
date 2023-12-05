<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuCrud.aspx.cs" Inherits="VeterinarySmiles_Web.MenuCrud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box-body">
                    <div class=form-group>
                        <asp:Label Text="Marca:" runat="server" />
                    </div>
                    <div class=form-group>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Label Text="" ID="lblcontrol" runat="server"/>
                    </div>
                    <div class=form-group>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Label Text="" ID="Label1" runat="server"/>
                    </div>
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
                <asp:Button ID="btnUpdate" Text="Modificar" runat="server" class='btn btn-sm btn-info' OnClick="BtnUpdate_Click" />
        
        </div>
        <div class=form-group>
            <asp:Label Text="" ID="lblControlFianl" runat="server"/>
        </div>
    </section>
</form>




</asp:Content>
