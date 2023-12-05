<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVeterinario.Master" AutoEventWireup="true" CodeBehind="WebTemp.aspx.cs" Inherits="VeterinarySmiles_Web.WebMuestraPlato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8sh+Wy1QszhLvAg5gB/U5c/QCpPeYX4ZiZIweJ" crossorigin="anonymous">
    <!-- Puedes agregar aquí enlaces a tus estilos o scripts adicionales -->
    <style>
        body {
            background-color: #f8f9fa; /* Color de fondo suave */
        }

        .form-box {
            max-width: 800px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .content-header h2 {
            color: #007bff; /* Color azul brillante para el encabezado principal */
            text-align: center;
        }

        .table {
            width: 100%;
            margin-bottom: 1rem;
            color: #212529;
        }

        .table th, .table td {
            padding: 1rem;
            vertical-align: top;
            border-top: 1px solid #dee2e6;
        }

        .table thead th {
            vertical-align: bottom;
            border-bottom: 2px solid #dee2e6;
        }

        .table-striped tbody tr:nth-of-type(odd) {
            background-color: rgba(0, 0, 0, 0.05);
        }

        .table-hover tbody tr:hover {
            background-color: rgba(0, 0, 0, 0.075);
        }

        .label-error {
            color: #d9534f; /* Color de texto rojo para mensajes de error */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
</asp:Content>
