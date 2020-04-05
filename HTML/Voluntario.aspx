<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Voluntario.aspx.cs" Inherits="FundaVida.Voluntario1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoFundacion" runat="server">

    <form id="form1" runat="server">


        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label1" runat="server" Text="Cedula"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
         <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                     <asp:ImageButton ID="imgBtn" runat="server" ImageUrl="~/Imagenes/calendar.png" OnClick="imgBtn_Click" />
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>


        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Calendar ID="caleFecha" runat="server" BackColor="White" BorderColor="White" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="65px" Width="211px" BorderWidth="1px" NextPrevFormat="FullMonth" OnSelectionChanged="caleFecha_SelectionChanged">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle VerticalAlign="Bottom" Font-Bold="True" Font-Size="8pt" ForeColor="#333333" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" Font-Bold="True" BorderWidth="4px" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label2" runat="server" Text="Universidad"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddUniversidad" runat="server"></asp:DropDownList>
                </div>
                 <div class="col-md-3">
                    <asp:Button ID="btnNuevaUniversidad" runat="server" OnClick="OpenWindow" Text="Nueva Universidad" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:CheckBox ID="cbActivo" runat="server" />
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label3" runat="server" Text="Activo"></asp:Label>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-1">
                    <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnRefrescar" runat="server" OnClick="btnRefrescar_Click" Text="Refrescar" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnExcel" runat="server" OnClick="btnExcel_Click" Text="Exportar" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblVal" runat="server" Text="."></asp:Label>
                </div>
            </div>
        </div>


        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>



        <asp:GridView ID="gVDatos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="idPersona" HeaderText="Cedula" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido1" HeaderText="Primer Apellido" />
                <asp:BoundField DataField="Apellido2" HeaderText="Segundo Apellido" />
                <asp:BoundField DataField="Activo" HeaderText="Activo" />
                <asp:BoundField DataField="Fecha_ingreso" HeaderText="Fecha de ingreso" />
                <asp:BoundField DataField="idUniversidad" HeaderText="idUniversidad" />
                <asp:BoundField DataField="Descripcion" HeaderText="Universidad" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>



    </form>
</asp:Content>
