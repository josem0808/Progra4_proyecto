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
    public partial class alumno : System.Web.UI.Page
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

        public void ingresarAlumno()
        {
         
            String query = "INSERT INTO Niño(Persona_idPersona, Fecha_ingreso, Activo)" +
                "VALUES(@Persona_idPersona, @Fecha_ingreso, @Activo)";
            establecerConexion();
            cmd = new SqlCommand(query, cnx);
            cmd.Parameters.AddWithValue("@Persona_idPersona", Convert.ToInt32(txtCedula.Text));
            cmd.Parameters.AddWithValue("@Fecha_ingreso", Convert.ToDateTime(calFecha.SelectedDate));
            cmd.Parameters.AddWithValue("@Activo", CheckActivo.Checked);
            cmd.ExecuteNonQuery();
      
        }

        public void consultarAlumno()
        {

            SqlDataAdapter da = new SqlDataAdapter(" SELECT P.idPersona, P.Nombre,P.Apellido1,P.Apellido2, Ñ.Activo, Ñ.Fecha_ingreso FROM Niño Ñ JOIN Persona P on P.idPersona = Ñ.Persona_idPersona", cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dgAlumn.DataSource = dt;
            dgAlumn.DataBind();




        }


        protected void Page_Load(object sender, EventArgs e)
        {
            establecerConexion();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ingresarAlumno();
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarAlumno();
        }
    }
}