<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebAdmUser.aspx.cs" Inherits="VeterinarySmiles_Web.WebAdmUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <form id="form1" runat="server">

    <div class="form-box">

        <section class="content-header">
            <h1 style="text-align:center">Registro Usuarios</h1>
        </section>
        <section class="content">

            <div class="row">


                <div class="col-md-5">

                    <div class="box-body">

                        <div class="form=group">
                            <asp:Label runat="server">CI :</asp:Label>
                        </div>

                        <div class="form=group">
                           <asp:TextBox ID="txtCI" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                       
                        <div class="form=group">
                            <asp:Label runat="server">Primer Apellido :</asp:Label>
                        </div>

                        <div class="form=group">
                           <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="row">

                           <div class="col-md-6">
                                <div class="form=group">
                                    <asp:Label runat="server">Fecha de Nacimiento :</asp:Label>
                                </div>

                                <div class="form=group">
                                    <asp:TextBox ID="txtBirthDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                                                       
                        </div>
                        
                    </div>

                </div>
                <div class="col-md-5">

                     <div class="form=group">
                            <asp:Label runat="server">Nombre :</asp:Label>
                        </div>

                        <div class="form=group">
                           <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form=group">
                                <asp:Label runat="server">Segundo Apellido :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtSecondLastName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                       
                    <div class="form=group">
                            <asp:Label runat="server">Usuario :</asp:Label>
                        </div>

                        <div class="form=group">
                           <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    <div class="form=group">
                            <asp:Label runat="server">Contraseña :</asp:Label>
                        </div>

                        <div class="form=group">
                           <asp:TextBox ID="txtContrsenia" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                     
                        <br />
                                                           
                </div>
                <div class="col-md-2">
                    <div class="form=group">
                            <asp:Label runat="server">Genero :</asp:Label>
                    </div>

                    <div class="form=group">
                           <!--<asp:TextBox ID="txtGender" runat="server" CssClass="form-control"></asp:TextBox>-->
                        <asp:DropDownList ID="selGender" runat="server" class="box">
                            <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                
                            </asp:DropDownList>
                    </div>

                        <br />

                    <div>
                        <asp:Button ID="btnInsert" Text="Insertar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' OnClick="btnInsert_Click" />
                                              
                </div>

            </div>

            <br />

            <div class="row">
                <div class="col-md-12">
                   
                   <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>

                </div>
            </div>

            <div class="row">

                <div class="col-md-12">

                    <div class="box-body">
                       
                        <asp:Label ID="Label1" style="color:#690404" runat="server" Text=""></asp:Label>
                     
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
