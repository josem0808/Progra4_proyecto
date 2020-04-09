<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="FundaVida.Inicio" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <script defer src="script.js"></script>
    <script src="https://unpkg.com/swup@latest/dist/swup.min.js"></script>  
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
    <%--<link href="estilo.css" rel="stylesheet" />--%>
    <link rel="stylesheet" type="text/css" href="estilo1.css"/>

   
 
    <title>Inicio</title>
</head>

    <div class="top"></div>	
            <div class="header">	
				<div class="head">					
					    <div class="logo">
						
                            <h1>Funda Vida</h1>

					</div>
				
		        </div>
            </div>
<body>
   
    
<div class="iniSession">

        <h1>Iniciar Sesion</h1>
    </div>
    <div class="middle">
     <button class="btnLog" data-modal-target="#modal">

         <h1>Login</h1>
     </button>  <%--data-modal-target = selector que apunta al modal--%>
        </div>
  <div class="modal" id="modal"> <%-- contenedor de la ventana log in  --%>
      
    <div class="modal-header"> <%--header del contenedor--%>
      <div class="title">
            LOGIN
          <%--<h1>Log in</h1>--%>
      </div>
        
      <button data-close-button="#modal" class="close-button">&times;</button>  <%--&times = entity html X--%>
       
    </div>
    <div class="modal-body"> <%-- body del contenedor --%>
        <form class="form" id="formLogIn" runat="server"> <%--form del login--%>
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        
        <asp:TextBox Class="txtLog" ID="txtUsuario" runat="server" placeholder="Usuario"></asp:TextBox>
      <%--  <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>--%>
           
        <br />
        <br />
       
        <asp:TextBox Class="txtLog" ID="txtContraseña" runat="server" placeholder="Contraseña" TextMode="Password" ></asp:TextBox>
<%--        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>--%>
            
        <br />
        <br />
        <br />
        <asp:Button ID="btnIngresar" class="btnIngresarLog"  runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
    <%--  --%>
        <asp:Label ID="lbPrueba" runat="server"></asp:Label>
            
       
    </form>
            
    </div>
  </div>

    <div class="modal-footer">




    </div>
  <div id="overlay"></div> <%--para oscurecer el fondo --%>



</body>
</html>