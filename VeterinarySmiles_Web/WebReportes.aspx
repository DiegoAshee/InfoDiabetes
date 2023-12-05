<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebReportes.aspx.cs" Inherits="VeterinarySmiles_Web.WebReportesaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        /* Estilos para los botones */
        .btn {
            display: block;
            margin-bottom: 10px;
            padding: 10px;
            text-align: center;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s;
            width: 200px;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        /* Estilos para los contenedores de texto */
        .info {
            font-size: 18px;
            font-weight: bold;
            margin-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <form id="form1" runat="server">
        <div>
            <div class="info">Reporte segun Diabetes</div>
            <button type="button" class="btn" onclick="location.href='ReporteSegunDiabetes.aspx';">Reporte</button>
            

            <div class="info">Reporte segun IMC</div>
            <button type="button" class="btn" onclick="location.href='ReporteSegunIMC.aspx';">Reporte</button>
            

            <div class="info">Reporte segun Diabetes segun Daos Personales de los clientes</div>
            <button type="button" class="btn" onclick="location.href='ReporteSegunDatosPersona.aspx';">Reporte</button>


            <div class="info">Reporte segun la edad de los clientes</div>
            <button type="button" class="btn" onclick="location.href='ReporteSegunEdad.aspx';">Reporte</button>
            
        </div>
    </form>





</asp:Content>
