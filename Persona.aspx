<%@ Page Language="C#"   AutoEventWireup="true" CodeBehind="Persona.aspx.cs" Inherits="FundaVida.Persona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="estilo1.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
    <script  src="alertas.js"></script>
    <title></title>
</head>
<body>

      

    <form id="form1" runat="server">
        <div>
            <br />
            <asp:TextBox class="txt" placeholder="Cedula" ID="txtCedula" runat="server"></asp:TextBox>
            <%--<asp:Label ID="Label1" runat="server" Text="Cedula"></asp:Label>--%>
            <br />
            <br />
            <asp:TextBox class="txt" placeholder="Nombre" ID="txtNombre" runat="server"></asp:TextBox>
            <%--<asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>--%>
            <br />
            <br />
            <asp:TextBox class="txt" placeholder="Primer Apellido" ID="txtApellido_1" runat="server"></asp:TextBox>
            <%--<asp:Label ID="lblApellido1" runat="server" Text="Primer apellido"></asp:Label>--%>
            <br />
            <br />
            <asp:TextBox class="txt" placeholder="Segundo Apellido" ID="txtApellido_2" runat="server"></asp:TextBox>
            <%--<asp:Label ID="lblApellido2" runat="server" Text="Segundo apellido"></asp:Label>--%>
            <br />
            <br />
            <br />
            <br />
            <asp:Calendar ID="caleFecha" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="141px" Width="233px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
            <br />
            <asp:DropDownList class="ddList" ID="ddGenero" runat="server" OnSelectedIndexChanged="ddGenero_SelectedIndexChanged">
                <asp:ListItem Value="1">Femenino</asp:ListItem>
                <asp:ListItem Value="2">Masculino</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button class="btns" ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button class="btns" ID="btnRefrescar" runat="server" OnClick="btnRefrescar_Click" Text="Refrescar" />
&nbsp;
            <asp:Button class="btns" ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button  class="btns" ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblVal" runat="server" Text="."></asp:Label>
            <br />
            <br />
            <asp:Button class="btns" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
            <asp:TextBox class="txt" placeholder="Numero de cedula" ID="txtBuscar" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="gVDatos" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
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
