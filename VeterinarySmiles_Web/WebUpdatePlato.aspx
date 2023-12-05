<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebUpdatePlato.aspx.cs" Inherits="VeterinarySmiles_Web.WebUpdatePlato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <form id="form1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box-body">
                    <div class=form-group>
                        <asp:Label Text="Nombre:" runat="server" />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" OnLostFocus="txtDescription_LostFocus" />
                    </div>
                    <div class=form-group>
                        <asp:Label Text="" ID="lblcontrol1" runat="server"/>
                    </div>
                    <div class=form-group>
                        <asp:Label Text="Descripcion:" runat="server" />
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
                    </div>
                    <div class=form-group>
                        <asp:Label Text="" ID="lblcontrol2" runat="server"/>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box-body">
                     <div class="form-group">
                        <asp:Label Text="Menu:" runat="server" />
                        <asp:DropDownList ID="cbMenu" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <div class="row">   
                <asp:Button ID="btnUpdate" Text="Modificar" runat="server" class='btn btn-sm btn-info' OnClick="btnUpdate_Click"/>
        </div>
    </section>
</form>








</asp:Content>
