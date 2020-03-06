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
    public partial class Voluntario : System.Web.UI.Page
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

            public void ingresarVoluntario()
            {
            
                String query = "INSERT INTO Voluntario(Persona_idPersona)" +
                    "VALUES(@Persona_idPersona)";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@idPersona", Convert.ToInt32(txtIdPersona.Text));
                cmd.ExecuteNonQuery();

            }


            public void cargarVoluntario()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT P.idPersona, P.Nombre,P.Apellido1,P.Apellido2, V.Activo, V.Fecha_ingreso" +
                                 " FROM Voluntario V" +
                                "JOIN persona P on P.idPersona = V.Persona_idPersona", cnx);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.gVDatos.DataSource = dt;
                gVDatos.DataBind();
            }

            public void buscarVoluntario()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT* FROM Voluntario WHERE Persona_idPersona LIKE '" + TxtBuscar.Text + "%'", cnx);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.gVDatos.DataSource = dt;
                gVDatos.DataBind();

            }

            protected void btnBuscar_Click(object sender, EventArgs e)
            {
                buscarVoluntario();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                establecerConexion();

            }

            protected void btnIngresar_Click(object sender, EventArgs e)
            {
                ingresarVoluntario();
                establecerConexion();
            }

            protected void gVDatos_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            protected void btnRefrescar_Click(object sender, EventArgs e)
            {
                cargarVoluntario();
            }
        }
    }
