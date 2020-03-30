<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="Voluntario.aspx.cs" Inherits="FundaVida.Voluntario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
            <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label1" runat="server" Text="Cedula"></asp:Label>
            <br />
            <br />
            <asp:Calendar ID="caleFecha" runat="server" BackColor="White" BorderColor="White" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" BorderWidth="1px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:DropDownList ID="ddUniversidad" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label4" runat="server" Text="Universidad"></asp:Label>
            <br />
            <asp:CheckBox ID="cbActivo" runat="server" />
            <asp:Label ID="Label3" runat="server" Text="Activo"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRefrescar" runat="server" Text="Refrescar" OnClick="btnRefrescar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnExcel" runat="server" OnClick="btnExcel_Click" Text="Exportar" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblValidacion" runat="server" Text="."></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" ForeColor="#666666" />
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
            <br />
            <br />
                <div>   

                    <asp:GridView ID="gVDatos" runat="server">
                    </asp:GridView>

                </div>  
            
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
       
    </form>
</body>
</html>
