<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebAdmRegistroUsuNuevo.aspx.cs" Inherits="VeterinarySmiles_Web.WebAdmRegistroUsuNuevo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style>
    body {
        font-family: 'Arial', sans-serif;
        background-color: #f4f4f4;
        margin: 0;
        padding: 0;
    }

    .form-box {
        max-width: 800px;
        margin: 50px auto;
        background-color: #fff;
        padding: 20px;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    .content-header h1 {
        text-align: center;
        color: #2a3547;
    }

    .box-body {
        padding: 20px;
    }

    .form-group {
        margin-bottom: 20px;
    }

    label {
        display: block;
        font-weight: bold;
        margin-bottom: 5px;
        color: #2a3547;
    }

    input[type="text"],
    input[type="password"],
    input[type="date"],
    select {
        width: 100%;
        padding: 8px;
        box-sizing: border-box;
        border: 1px solid #ccc;
        border-radius: 4px;
    }

    .btn {
        display: inline-block;
        padding: 8px 15px;
        font-size: 14px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
        background-color: #5bc0de;
        color: #fff;
        border: 1px solid #46b8da;
        border-radius: 4px;
        cursor: pointer;
    }

    .btn:hover {
        background-color: #46b8da;
    }

    #lblError,
    #Label1 {
        color: #690404;
    }
</style>



</head>
<body>
    <form id="form1" runat="server">
    <div class="form-box">
        <section class="content-header">
            <h1 style="text-align:center">Registro Usuarios</h1>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-5">
                    <div class="box-body">
                        <div class="form-group">
                            <asp:Label runat="server">CI :</asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCI" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                       
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <asp:Label runat="server">Nombre :</asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server">Primer Apellido :</asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server">Segundo Apellido :</asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtSecondLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>


                     <div class="row">
                         <div class="col-md-6">
                             <div class="form-group">
                                 <asp:Label runat="server">Fecha de Nacimiento :</asp:Label>
                             </div>
                             <div class="form-group">
                                 <asp:TextBox ID="txtBirthDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                             </div>
                         </div>
                     </div>

                    <div class="form-group">
                        <asp:Label runat="server">Usuario :</asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server">Contraseña :</asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtContrsenia" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server">Confirmar Contraseña:</asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtPassConfirm" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label runat="server">Genero :</asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="selGender" runat="server" class="box">
                            <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div>
                        <asp:Button ID="btnInsert" Text="Registrarse" runat="server" class='btn btn-secondary' style='background-color:#2a3547' onClick="btnInsert_Click"/>
                    </div>
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

</body>
</html>
