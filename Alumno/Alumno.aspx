<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="FundaVida.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Cedula"></asp:Label>
            <br />
            <asp:CheckBox ID="cbActivo" runat="server" />
            <asp:Label ID="Label2" runat="server" Text="Activo"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtInstitucion" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Institución"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <br />
            <asp:DropDownList ID="ddGrado" runat="server">
                <asp:ListItem Value="1">Octavo</asp:ListItem>
                <asp:ListItem Value="2">Noveno</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label4" runat="server" Text="Grado"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label5" runat="server" Text="Encargado"></asp:Label>
            <br />
            <asp:CheckBox ID="cbRecogen" runat="server" />
            <asp:Label ID="Label6" runat="server" Text="Lo recogen"></asp:Label>
            <br />
            <asp:DropDownList ID="ddSede" runat="server">
                <asp:ListItem Value="1">Concepcion</asp:ListItem>
                <asp:ListItem Value="2">25 julio</asp:ListItem>
                <asp:ListItem Value="3">Linda Vista</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label7" runat="server" Text="Sede"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblValidar" runat="server" Text="."></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRefrescar" runat="server" OnClick="btnRefrescar_Click" Text="Refrescar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
            <br />
            <br />
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="gVDatos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
