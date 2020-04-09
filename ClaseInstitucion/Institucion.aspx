<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Institucion.aspx.cs" Inherits="FundaVida.Institucion" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
         <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtIdInstitucion" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label2" runat="server" Text="Institucion"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtNombreInstitucion" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-1">
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar"  CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnEliminar_Click" />
                </div>

                <div class="col-md-1">
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEditar_Click" />
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
    </form>
</body>
</html>
