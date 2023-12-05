<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVeterinario.Master" AutoEventWireup="true" CodeBehind="WebPrueba.aspx.cs" Inherits="VeterinarySmiles_Web.WebPrueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
    <div class="form-box">
        <h1>Ingredientes del plato</h1>
        
            
       
       

        <div class="row">
            <div class="col-md-10">
                <asp:Label Text="" ID="lblControlFinal" runat="server" />
            </div>
        </div>
       
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
