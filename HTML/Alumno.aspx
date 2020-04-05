<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="FundaVida.Alumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoFundacion" runat="server">

    <form id="form1" runat="server">

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label8" runat="server" Text="Cedula"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-10">
                    <asp:Label Text="Usuario: " runat="server" ID="lblUsuario" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label1" runat="server" Text="Activo"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:CheckBox ID="cbActivo" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label2" runat="server" Text="Institucion"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList runat="server" ID="ddInstitucion">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnNuevaInstitucion" runat="server" OnClick="OpenWindow" Text="Nueva Institucion" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label3" runat="server" Text="Grado"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddGrado" runat="server">
                        <asp:ListItem Value="8">Primero</asp:ListItem>
                        <asp:ListItem Value="9">Segundo</asp:ListItem>
                        <asp:ListItem Value="3">Tercero</asp:ListItem>
                        <asp:ListItem Value="4">Cuarto</asp:ListItem>
                        <asp:ListItem Value="5">Quinto</asp:ListItem>
                        <asp:ListItem Value="6">Sexto</asp:ListItem>
                        <asp:ListItem Value="7">Setimo</asp:ListItem>
                        <asp:ListItem Value="1">Octavo</asp:ListItem>
                        <asp:ListItem Value="2">Noveno</asp:ListItem>
                        <asp:ListItem Value="10">Decimo</asp:ListItem>
                        <asp:ListItem Value="11">Undecimo</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label4" runat="server" Text="Encargado"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddEncargado" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label5" runat="server" Text="Lo recogen"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:CheckBox ID="cbRecogen" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label6" runat="server" Text="Sede"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddSede" runat="server">
                        <asp:ListItem Value="1">Concepcion</asp:ListItem>
                        <asp:ListItem Value="2">25 julio</asp:ListItem>
                        <asp:ListItem Value="3">Linda Vista</asp:ListItem>
                    </asp:DropDownList>
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

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblValidar" runat="server" Text="."></asp:Label>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-1">
                    <asp:GridView ID="gVDatos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="idPersona" HeaderText="Cedula" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido1" HeaderText="Primer Apellido" />
                            <asp:BoundField DataField="Apellido2" HeaderText="Segundo Apellido" />
                            <asp:BoundField DataField="Activo" HeaderText="Activo" />
                            <asp:BoundField DataField="Institucion_idInstitucion" HeaderText="ID Institucion" />
                            <asp:BoundField DataField="DesInsti" HeaderText="Institucion" />
                            <asp:BoundField DataField="Grado_idGrado" HeaderText="ID Grado" />
                            <asp:BoundField DataField="Des" HeaderText="Grado" />
                            <asp:BoundField DataField="Encargado_Persona_idPersona" HeaderText="ID Encargado" />
                            <asp:BoundField DataField="Recogen" HeaderText="Recogen" />
                            <asp:BoundField DataField="Cede_idCede" HeaderText="Id Sede" />
                            <asp:BoundField DataField="Descricpcion" HeaderText="Sede" />

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </div>

            </div>
        </div>

    </form>

</asp:Content>
