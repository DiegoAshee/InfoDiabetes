<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCambioContraOlvidada.aspx.cs" Inherits="VeterinarySmiles_Web.WebCambioContraOlvidada" %>

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

.login-box {
    max-width: 400px;
    margin: 50px auto;
}

.card {
    border: 1px solid #d2d2d2;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.login-card-body {
    padding: 20px;
}

.login-box-msg {
    font-weight: bold;
    margin-bottom: 20px;
}

.input-group {
    margin-bottom: 15px;
}

.input-group-text {
    background-color: #ffffff;
    border: 1px solid #d2d2d2;
}

.form-control {
    box-shadow: none;
    border-radius: 4px;
}

.btn-secondary {
    background-color: #2a3547;
    color: #ffffff;
    border: 1px solid #222d3d;
}

.btn-secondary:hover {
    background-color: #1f2b38;
    border: 1px solid #1a2533;
}

.row {
    margin: 0;
}

.col-12 {
    text-align: center;
}

.col-5 {
    text-align: center;
}

.col-12 a {
    color: #2a3547;
    text-decoration: none;
}

.col-12 a:hover {
    text-decoration: underline;
}

#lblError {
    color: #690404;
}

    </style>


</head>
<body>
     <div class="login-box">
  <div class="login-logo">
    
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg"><b>Cambio De Contarseña</b></p>

      <form id="formLogin" runat="server">
          
        
        <div class="input-group mb-3">
          <asp:TextBox ID="txtPasswordNueva" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña Nueva"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>

          <div class="input-group mb-3">
          <asp:TextBox ID="txtRepetirPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña Nueva"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          
          <!-- /.col -->
          <div class="col-12" style="text-align:center">
            
              <asp:Button ID="btnCambiar" class='btn btn-secondary' style='background-color:#2a3547' Text="Cambiar" runat="server" OnClick="btnCambiar_Click"/><br />
             
          </div>
          <!-- /.col -->
        </div>
          <div class="row">
          
          <!-- /.col -->
          <div class="col-12" style="text-align:center">
            
              <div class="row">
                  <div class="col-5" style="text-align:center">
                      <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
                </div>

                 <div class="col-12" style="text-align:right">
                     <asp:HyperLink ID="linkLogin" runat="server" Text="Volver a Login" NavigateUrl="Default.aspx"></asp:HyperLink>
                   </div>
            </div>
               
               
          </div>
          <!-- /.col -->
        </div>
      </form>
      <!-- /.social-auth-links -->

      
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
</body>
</html>
