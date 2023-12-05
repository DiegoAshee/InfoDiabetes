<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebAdmMuestraClientes.aspx.cs" Inherits="VeterinarySmiles_Web.WebAdmMuestraClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




    <form id="form1" runat="server">

    <div class="form-box">

        <section class="content-header">
            <h1 style="text-align:center">Administracion de Clientes</h1>
        </section>
        <section class="content">

            

                    <div>
                        <asp:Button ID="btnInsert" Text="Insertar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' OnClick="btnInsert_Click" />
                        
                        
                    </div>

           

            <div class="row">

                <div class="col-md-12">


                    <div class="box-body">

                        
                        <asp:Label ID="Label1" style="color:#690404" runat="server" Text=""></asp:Label>



                            <div class="box-body">
                                <br /><br />
                                 <asp:GridView ID="gridData" runat="server" CssClass="table table-bordered table-striped dataTable dtr-inline">
                             
                                 </asp:GridView>                 

                            </div>
                     </div>


               </div>

            </div>


         

            

       </section>




    </div>
</form>




 <script>
     function ConfirmDelete() {
         return confirm('¿Estás seguro de que deseas eliminar este elemento?');
     }
</script>



















</asp:Content>
