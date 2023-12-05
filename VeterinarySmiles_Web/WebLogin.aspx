<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="VeterinarySmiles_Web.WebLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




     <form id="formLogin" runat="server">

        <div class="form-box">

            <section class="content-header">
                <h1 style="text-align:center; color: black">LOGIN</h1>
            </section>
            <section class="content">

                <div class="row">


                    <div class="col-md-5">

                        <div class="box-body">

                            <div class="form=group">
                                <asp:Label runat="server">Login :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form=group">
                                <asp:Label runat="server">Password :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>


                            <div class="box-body">

                            <asp:Button ID="btnIngresar" class='btn btn-secondary' style='background-color:#2a3547' Text="Ingresar" runat="server" OnClick="btnIngresar_OnClick" /><br />
                            <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
                        </div>
                        </div>
                    </div>          
                </div>
            </section>     
        </div>
    </form>















</asp:Content>
