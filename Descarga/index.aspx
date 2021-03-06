﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TelcomVentures.Ar.EnvioComprobantes.Download.descarga.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link rel="stylesheet" href="../js/bootstrap-4.4.1-dist/css/bootstrap.min.css" />

    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap-glyphicons.css" rel="stylesheet">
+
    <link rel="stylesheet" href="../css/style.css" />

    <title>Descarga de Comprobantes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
        </div>
        <img src="../img/logo.png" style="width: 35%" />
        <div style="height: 470px;">
            <div id="loader" style="height: 300px;">
                <div class="row">
                    <div class="col-sm-12" align="center">
                        <img src="../img/loader.gif" alt="" /></div>
                </div>
                <div class="row">
                    <div class="col-sm-12" align="center">Descargando Comprobante...</div>
                </div>

            </div>


            <div class="row" id="divError" style="height: 300px;">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <div class="alert alert-danger" role="alert">
                       <p class="h3"> <b>Error en la descarga: </b></p>
                        <br />
                        <br />
                        <p class="h3" id="divTextoError"> 
                            No se encontro el Comprobante!                       
                        </p>
                            <br />
                      
                        <p class="h3">De continuar el inconveniente comuniquese con</p>
                        <p class="h3">Atención al cliente</p>
                        <p class="h3"><span class="glyphicon glyphicon-earphone"></span> <a href="tel:01152999200">5299-9200</a></p>
                        <p class="h3"><span class="glyphicon glyphicon-envelope"></span> <a href="mailto: atencionalcliente@antina.com.ar">atencionalcliente@antina.com.ar</a></p>

                    </div>
                    <div class="col-md-1"></div>
                </div>
            </div>



            <div class="row" id="divExito" style="height: 300px;">
                <div class="col-md-1"></div>
                <div class="col-md-10 text-center">
                    <br />
                    <br />
                    <p class="h3">La descarga se realizó correctamente.</p>
                    <p class="h3">Si no puede visualizar el comprobante<a href="#" target="_blank" id="myLink"> haga click aquí</a></p>
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            </div>



        </div>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10 text-center">
                Copyright © 2020 Antina. Todos los derechos reservados.
            </div>
        </div>
    </form>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-latest.js"></script>
    <script src="../js/jquery-latest.js"></script>

    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="../js/bootstrap-4.4.1-dist/js/bootstrap.min.js"></script>

    <script src="../js/index.js" type="text/javascript"></script>
</body>
</html>
