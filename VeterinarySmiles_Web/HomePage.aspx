<%@ Page Title="Inicio - Diabetes" Language="C#" MasterPageFile="~/SiteVeterinario.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="VeterinarySmiles_Web.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Puedes agregar aquí enlaces a tus estilos o scripts adicionales -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h1>Bienvenido a InfoDiabetes</h1>
        <p>Tu compañero en el manejo de la diabetes y el bienestar general.</p>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <h2>¿Qué es la Diabetes?</h2>
                <p>
                    La diabetes es una condición en la cual el cuerpo tiene dificultades para regular los niveles de azúcar en la sangre.
                    En Diabetes Smiles, estamos aquí para proporcionarte información, recursos y apoyo para manejar esta condición.
                </p>
            </div>
            <div class="col-md-6">
                <img src="https://pydesalud.com/wp-content/uploads/2021/01/Disen%CC%83o-sin-ti%CC%81tulo-6.png" alt="Imagen representativa de la diabetes" class="img-fluid" />
            </div>
        </div>

        <hr />

        <div class="row">
            <div class="col-md-6">
                <h2>Recursos Útiles</h2>
                <ul>
                    <li><a href="https://www.paho.org/es/temas/diabetes">Artículos sobre Diabetes</a></li>
                    <li><a href="https://www.healthline.com/health/es/ejercicios-para-la-diabetes">Ejercicios Recomendados</a></li>
                </ul>
            </div>
            <div class="col-md-6">
                <h2>Comunidad</h2>
                <p>Únete a nuestra comunidad en línea para compartir experiencias, obtener consejos y apoyo de otros que también están manejando la diabetes.</p>
                <a href="#" class="btn btn-primary">Únete a la Comunidad</a>
            </div>
        </div>
    </div>

</asp:Content>
