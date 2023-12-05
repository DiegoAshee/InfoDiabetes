<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVeterinario.Master" AutoEventWireup="true" CodeBehind="WebMenuCliente.aspx.cs" Inherits="VeterinarySmiles_Web.WebMenuCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <h1>Actualiza Tus datos basales</h1>



        <form id="form1" runat="server">

        <div class="form-box">

            <section class="content-header">
                <h1 style="text-align:center">Actualiza Tus datos Para IMC</h1>
            </section>
            <section class="content">

                <div class="row">


                    <div class="col-md-5">

                        <div class="box-body">

                            <div class="form=group">
                                <asp:Label runat="server">Peso (kg) :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            

                            <div class="form=group">
                                <asp:Label runat="server">Altura (CM) :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtCM" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                           
                            
                            <div class="form-group">
                                <asp:Label runat="server">Alergias :</asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox ID="chkLacteo" runat="server" Text="Alergia a los lacteos" />
                            </div>
                            <div class="form-group">
                                <asp:CheckBox ID="chkMariscos" runat="server" Text="Alergia a los Mariscos" />
                            </div>
                            <div class="form-group">
                                <asp:CheckBox ID="chkFrutosSecos" runat="server" Text="Alergia a los frutos secos" />
                            </div>
                           
                           
                            

                            <div class="form=group">
                                    <asp:Label runat="server">Grado Diabetes(porcentaje) :</asp:Label>
                            </div>

                            <div class="form=group">
                                   <!--<asp:TextBox ID="txtGender" runat="server" CssClass="form-control"></asp:TextBox>-->
                                    <asp:DropDownList ID="selGradoDiabetes" runat="server" class="form-control">
                                    <asp:ListItem Text="Muy Alto" Value="Muy Alto"></asp:ListItem>
                                    <asp:ListItem Text="Alto" Value="Alto"></asp:ListItem>
                                    <asp:ListItem Text="Medio" Value="Medio"></asp:ListItem>
                                    <asp:ListItem Text="Bajo" Value="Bajo"></asp:ListItem>
                                    <asp:ListItem Text="Muy Bajo" Value="Muy Bajo"></asp:ListItem>
                                    <asp:ListItem Text="Nula" Value="Nula"></asp:ListItem>
            
                                    </asp:DropDownList>
                            </div>

                                <br />
                            

                            
                            

                        </div>

                    </div>
                    
                    <div class="col-md-6">
                        <div class="form=group">
                                <asp:Label runat="server">Genero :</asp:Label>
                        </div>

                        <div class="form=group">
                              
                            <asp:DropDownList ID="selGender" runat="server" class="form-control form-select-lg mb-3">
                                <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                    
                                </asp:DropDownList>
                        </div>

                            <br />

                        <div>
                            <asp:Button ID="btnInsert" Text="Guardar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' OnClick="btnUpdate_Click"/>
                            
                            
                    </div>

                </div>

                <br />

                <div class="row">
                    <div class="col-md-12">
                       

                        <asp:Label ID="Label1" style="color:#690404" runat="server" Text=""></asp:Label>

                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="box-body">
                            <asp:Label ID="Label2" style="color:#690404" runat="server" Text=""></asp:Label>
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
    <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
</asp:Content>
