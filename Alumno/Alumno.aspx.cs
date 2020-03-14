using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FundaVida
{
    public partial class Alumno : System.Web.UI.Page
    {

        #region "Variables globales"
        SqlConnection cnx; //Declarando el objeto no lo inicializo
        SqlCommand cmd; //Declarado
        SqlDataReader dr;
        SqlDataAdapter sda;
        #endregion



        #region "Metodos"

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
            
                String query = "INSERT INTO Niño(Persona_idPersona, Activo , Institucion_idInstitucion, Grado_idGrado, Encargado_Persona_idPersona,Recogen, Cede_idCede )" +
                  "VALUES(@Persona_idPersona, @Activo, @Institucion_idInstitucion, @Grado_idGrado, @Encargado_Persona_idPersona, @Recogen, @Cede_idCede )";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@Persona_idPersona", Convert.ToInt32(txtCedula.Text));
                cmd.Parameters.AddWithValue("@Activo", cbActivo.Checked);
                cmd.Parameters.AddWithValue("@Institucion_idInstitucion", txtInstitucion.Text);
                cmd.Parameters.AddWithValue("@Grado_idGrado", Convert.ToInt32(ddGrado.SelectedValue));
                cmd.Parameters.AddWithValue("@Encargado_Persona_idPersona", Convert.ToInt32(ddEncargado.SelectedValue));
                cmd.Parameters.AddWithValue("@Recogen", cbRecogen.Checked);
                cmd.Parameters.AddWithValue("@Cede_idCede", Convert.ToInt32(ddSede.SelectedValue));

                cmd.ExecuteNonQuery();


        }

        public void cargarAlumno()
        {
            try
            {
                establecerConexion();
                SqlDataAdapter da = new SqlDataAdapter("SELECT P.idPersona, P.Nombre, P.Apellido1, P.Apellido2, N.Activo, N.Institucion_idInstitucion, N.Grado_idGrado, N.Encargado_Persona_idPersona N.Recogen, N.Cede_idCede FROM Niño N JOIN persona P on P.idPersona = N.Persona_idPersona", cnx);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.gVDatos.DataSource = dt;
                gVDatos.DataBind();
            }
            catch (Exception e)
            {
                lblValidar.Text = e.ToString();
                
            }
            
        }

        public void buscarAlumno()
        {

            
                establecerConexion();
                SqlDataAdapter da = new SqlDataAdapter("SELECT P.idPersona, P.Nombre, P.Apellido1, P.Apellido2, N.Activo, N.Institucion_idInstitucion, N.Grado_idGrado, N.Encargado_Persona_idPersona, N.Recogen, N.Cede_idCede FROM Niño N JOIN persona P on P.idPersona = N.Persona_idPersona where idPersona LIKE'" + txtBuscar.Text + "%'", cnx);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.gVDatos.DataSource = dt;
                gVDatos.DataBind();

      
            

        }

        public void Eliminar()
        {

            try
            {
                String query = "DELETE FROM Niño WHERE Persona_idPersona = @Persona_idPersona";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@Persona_idPersona", txtCedula.Text);
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            catch (Exception e)
            {
                lblValidar.Text = e.ToString();

            }
            
        }

        public void Editar()
        {

            try
            {
                String query = "UPDATE Niño SET  Activo = @Activo, Institucion_idInstitucion=@Institucion_idInstitucion, Grado_idGrado = @Grado_idGrado, Encargado_Persona_idPersona = @Encargado_Persona_idPersona, Recogen = @Recogen, Cede_idCede = @Cede_idCede  WHERE Persona_idPersona = @Persona_idPersona ";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@Persona_idPersona", Convert.ToInt32(txtCedula.Text));
                cmd.Parameters.AddWithValue("@Activo", cbActivo.Checked);
                cmd.Parameters.AddWithValue("@Institucion_idInstitucion", txtInstitucion.Text);
                cmd.Parameters.AddWithValue("@Grado_idGrado", Convert.ToInt32(ddGrado.SelectedValue));
                cmd.Parameters.AddWithValue("@Encargado_Persona_idPersona", Convert.ToInt32(ddEncargado.SelectedValue));
                cmd.Parameters.AddWithValue("@Recogen", cbRecogen.Checked);
                cmd.Parameters.AddWithValue("@Cede_idCede", Convert.ToInt32(ddSede.SelectedValue));
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            catch (Exception e)
            {

                lblValidar.Text = e.ToString();
            }
            
        }

        public void seleccionarEncargado() {

            String query = "Select Persona_idPersona from Encargado";
            establecerConexion();
            cmd = new SqlCommand(query, cnx);
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {
                ddEncargado.Items.Add(registro["Persona_idPersona"].ToString());
            }

        }

        public void seleccionarAlumno()
        {

            String query = "Select idGrado from Grado";
            establecerConexion();
            cmd = new SqlCommand(query, cnx);
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {
                ddGrado.Items.Add(registro["idGrado"].ToString());
            }

        }


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            seleccionarAlumno();
            seleccionarEncargado();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresarAlumno();
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            buscarAlumno();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarAlumno();
        }

        protected void ddSede_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}