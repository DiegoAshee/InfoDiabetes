<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebAdmPlato.aspx.cs" Inherits="VeterinarySmiles_Web.WebAdmPlato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



            <form id="form1" runat="server">
    <div class="form-box"> 
        <section class="content-header"> 
            <h1 style="text-align:center">Platos</h1>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="box-body">
                        <div class=form-group>
                            <asp:Label Text="Nombre:" runat="server" />
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" OnLostFocus="txtDescription_LostFocus"/>
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
                            <asp:DropDownList ID="cbxMenu" runat="server" CssClass="form-control"></asp:DropDownList>
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
                <div class="col-md-10">
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
