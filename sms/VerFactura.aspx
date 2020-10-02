<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerFactura.aspx.cs" Inherits="TelcomVentures.Ar.EnvioComprobantes.Download.sms.VerFactura" %>
<html class="no-js" lang="es" dir="ltr">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">      
        <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap-glyphicons.css" rel="stylesheet">
    <link rel="stylesheet" href="../css/VerFactura.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
        </div>
        <div style="height: 500px;">   
        <img src="../img/logo.png" style="width: 35%" />
          <div id="loader"  style="height: 300px;">
              <div class="row">
     <div class="col-sm-12" align="center"><img src="../img/loader.gif" alt="" /></div>
  </div>
              <div class="row">
     <div class="col-sm-12" align="center">descargando comprobante...</div>
  </div>  
        </div>
            <div class="divBody" id="divExito" style="height: 300px;">                  
            <div>
                <div id="LiteralTemplate"></div>                
            </div>
        </div>
      
        <div class="divBody" id="divError" style="height: 300px;">                  
        <div class="row" >
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <div class="alert alert-danger" role="alert">
                        <b>Error en la descarga: </b>                         
                            <div id="divTextoError">
                                No se encontro el Comprobante!
                            </div>
                        
                        <p><br /></p>
                        <p>De continuar el inconveniente comuniquese con</p>
                        <p>Atención al cliente</p>
                        <p><span class="glyphicon glyphicon-earphone"></span> <a href="tel:01152999200">5299-9200</a></p>
                        <p><span class="glyphicon glyphicon-envelope"></span> <a href="atencionalcliente@antina.com.ar">atencionalcliente@antina.com.ar</a></p>
                        
                    </div></div>
                    <div class="col-md-1"></div>
                </div>
            </div>
            </div>

       
       
       <div class="divfooter">
            El titular de los datos personales tiene la facultad de ejercer el derecho de acceso a los mismos en forma gratuita a intervalos no inferiores a seis meses, salvo que se acredite un inter&eacute;s leg&iacute;timo al efecto conforme lo establecido en el art&iacute;culo 14, inciso 3 de la Ley N&deg; 25.326. La DIRECCION NACIONAL DE PROTECCION DE DATOS PERSONALES, &oacute;rgano de Control de la Ley N&deg; 25.326, tiene la atribuci&oacute;n de atender las denuncias y reclamos que se interpongan con relaci&oacute;n al incumplimiento de las normas sobre protecci&oacute;n de datos personales. Art. 27, Inc. 3 de la Ley 25.326: ;El titular podr&aacute; en cualquier momento solicitar el retiro o bloqueo de su nombre de los bancos de datos a los que se refiere el presente art&iacute;culo&quot;. Art. 27, 3er p&aacute;rrafo del Decreto 1558/0: &quot;En toda comunicaci&oacute;n con fines de publicidad que se realice por correo, tel&eacute;fono, correo electr&oacute;nico, Internet u otro medio a distancia a conocer, se deber&aacute; indicar, en forma expresa y destacada, la posibilidad del titular del dato de solicitar el retiro o bloqueo, total o parcial, de su nombre de la base de datos. A pedido del interesado, se deber&aacute; informar el nombre del responsable o usuario del banco de datos que provey&oacute; la informaci&oacute;n&quot;.
        </div>
    </form>
     <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-latest.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="../js/VerFactura.js" type="text/javascript"></script>
</body>
</html>