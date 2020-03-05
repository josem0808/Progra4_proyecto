using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace FundaVida
{
    public partial class Inicio : System.Web.UI.Page
    {
        #region "Variables globales"
        SqlConnection cnx; //Declarando el objeto no lo inicializo
        SqlCommand cmd; //Declarado
        SqlDataReader dr;
        SqlDataAdapter sda;
        #endregion


        private bool establecerConexion()
        {
            try
            {
                cnx = new SqlConnection();
                cnx.ConnectionString = ConfigurationManager.ConnectionStrings["conexionProduccion"].ConnectionString;
                cnx.Open();
                if (cnx.State == ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }


        public void logear(String usuario, String contraseña)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
                String query = "SELECT Persona_idPersona, Rol_idRol FROM Usuario WHERE Nombre_usuario = @Nombre_usuario AND Contraseña = @Contraseña";
                establecerConexion();
                cmd = new SqlCommand(query,cnx);
                cmd.Parameters.AddWithValue("@Nombre_usuario", usuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                DataTable dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                Response.Redirect("Login.aspx");
            }
                



            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            logear(txtUsuario.Text.Trim(),txtContraseña.Text.Trim());
            establecerConexion();
        }
    }
}