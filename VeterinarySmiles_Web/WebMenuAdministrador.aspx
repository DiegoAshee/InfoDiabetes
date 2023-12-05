<%@ Page Title="Ayuda para la Diabetes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebMenuAdministrador.aspx.cs" Inherits="VeterinarySmiles_Web.WebMenuAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f8f8f8; /* Color de fondo suave */
            font-family: 'Arial', sans-serif; /* Fuente principal */
            color: #333; /* Color de texto principal */
            margin: 0;
            padding: 0;
        }

        #MainContent {
            max-width: 800px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #007bff; /* Color azul brillante para el encabezado principal */
        }

        #lblError {
            color: #d9534f; /* Color de texto rojo para mensajes de error */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>¡Bienvenido al Centro de Ayuda para la Diabetes!</h1>
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</asp:Content>
