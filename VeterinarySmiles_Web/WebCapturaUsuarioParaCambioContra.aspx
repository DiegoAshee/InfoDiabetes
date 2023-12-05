<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCapturaUsuarioParaCambioContra.aspx.cs" Inherits="VeterinarySmiles_Web.WebCapturaUsuarioParaCambioContra" %>

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

        form {
            max-width: 600px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .content {
            padding: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        input[type="text"] {
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
    </style>


</head>
<body>
        <form id="form1" runat="server">
            <section class="content">
                <div class="row">
                    <div class="col-md-6">
                        <div class="box-body">
                            <div class="form-group">
                                <asp:Label Text="Usuario:" runat="server" />
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" OnLostFocus="txtDescription_LostFocus" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">   
                    <asp:Button ID="btnIngresa" Text="Ingresa" runat="server" class='btn btn-sm btn-info' onClick="btnIngresa_Click"/>
                </div>
            </section>
        </form>

</body>
</html>
