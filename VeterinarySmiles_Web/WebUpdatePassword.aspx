<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogin1.Master" AutoEventWireup="true" CodeBehind="WebUpdatePassword.aspx.cs" Inherits="VeterinarySmiles_Web.WebUpdatePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function alertaPass() {
            confirm('Se cambio la contraseña correctamente');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    

 <div class="login-box">
  <div class="login-logo">
    
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg"><b>Cambio De Contarseña</b></p>

      <form id="formLogin" runat="server">
          
        <div class="input-group mb-3">
          <asp:TextBox ID="txtpasswordActual" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña Actual"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
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

    

</asp:Content>
