<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="FundaVida.Inicio" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbPrueba" runat="server" Text="No se Pudo ingresar"></asp:Label>
    </form>
</body>
</html>
