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
    public partial class Persona : System.Web.UI.Page
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

        public void ingresarPersona()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            String query = "INSERT INTO Persona(idPersona, Nombre, Apellido1, Apellido2, Fecha_Nacimiento, Genero_idGenero)"+ 
                "VALUES(@idPersona, @Nombre, @Apellido1, @Apellido2, @Fecha_Nacimiento, @Genero_idGenero)";
            establecerConexion();
            cmd = new SqlCommand(query, cnx);
            cmd.Parameters.AddWithValue("@idPersona", Convert.ToInt32(txtIdPersona.Text));
            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@Apellido1", txtApellido1.Text);
            cmd.Parameters.AddWithValue("@Apellido2", txtApellido2.Text);
            cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Convert.ToDateTime(txtFechaNacimiento.Text));
            cmd.Parameters.AddWithValue("@Genero_idGenero", Convert.ToInt32(txtGenero.Text));
            cmd.ExecuteNonQuery();
            
        }


        public void cargarPersona()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT* FROM Persona", cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.gVDatos.DataSource = dt;
            gVDatos.DataBind();
        }

        public void buscarPersona() {
            SqlDataAdapter da = new SqlDataAdapter("SELECT* FROM Persona WHERE idPersona LIKE '" + TxtBuscar.Text + "%'", cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.gVDatos.DataSource = dt;
            gVDatos.DataBind();

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarPersona();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            establecerConexion();
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresarPersona();
            establecerConexion();
        }

        protected void gVDatos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargarPersona();
        }
    }
}