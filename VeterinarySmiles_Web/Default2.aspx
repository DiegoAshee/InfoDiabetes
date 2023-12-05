<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="VeterinarySmiles_Web.Web_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="formLogin" runat="server">

        <div class="form-box">

            <section class="content-header">
                <h1 style="text-align:center">LOGIN</h1>
            </section>
            <section class="content" style="text-align:center">

                <div class="row">


                    <div class="col-md-5">

                        <div class="box-body">

                            <div class="form=group">
                                <asp:Label runat="server" style="text-align:left">Login :</asp:Label>
                            </div>

                            <div class="form=group">
                               <!--<asp:TextBox ID="txtLogin" runat="server" CssClass="form-control"></asp:TextBox>-->
                            </div>

                            <div class="form=group">
                                <asp:Label runat="server">Password :</asp:Label>
                            </div>

                            <div class="form=group">
                               <!--<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>-->
                            </div>


                            <div class="box-body">

                            <asp:Button ID="btnIngresar" style="text-align:center" Text="Ingresar" runat="server" OnClick="btnIngresar_OnClick" /><br />
                            <asp:Label ID="lblError" style="color:red" runat="server" Text=""></asp:Label>
                        </div>
                        </div>
                    </div>          
                </div>
            </section>     
        </div>
    </form>
</body>
</html>
