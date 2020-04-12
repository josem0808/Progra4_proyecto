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
    public partial class Encargado : System.Web.UI.Page
    {
        #region "Variables globales"
        SqlConnection cnx; //Declarando el objeto no lo inicializo
        SqlCommand cmd; //Declarado
        SqlDataReader dr;
        SqlDataAdapter sda;
        Inicio insInicio = new Inicio();
        Menu insMenu = new Menu();
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

        public void limpiarControles()
        {
            txtCedula.Text = string.Empty;
        }

        public void ingresarAlumno()
        {
            try
            {
                String query = "INSERT INTO Encargado(Persona_idPersona)" +
                "VALUES(@Persona_idPersona)";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                if (txtCedula.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar todos los datos')", true);
                    cnx.Close();
                    cnx.Dispose();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Persona_idPersona", Convert.ToInt32(txtCedula.Text));
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Encargado ingresado correctamente')", true);
                    cnx.Close();
                    cnx.Dispose();

                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('No se pudo guardar el registro')", true);

            }
        }

        public void Eliminar()
        {
            try
            {
                String query = "DELETE FROM Encargado WHERE Persona_idPersona = @Persona_idPersona";
                establecerConexion();
                int validar = 0;
                cmd = new SqlCommand(query, cnx);
                if (txtCedula.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar el numero de registro a eliminar')", true);
                    cnx.Close();
                    cnx.Dispose();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Persona_idPersona", txtCedula.Text);
                    validar = cmd.ExecuteNonQuery();
                    if (validar == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Encargado eliminado del registro')", true);
                        cnx.Close();
                        cnx.Dispose();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('No se encontro el registro')", true);
                        cnx.Close();
                        cnx.Dispose();

                    }
                }
            }
            catch (Exception e)
            {

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Error el registro esta vinculado con otros registros')", true);
            }
        }

        public void Editar()
        {

            try
            {
                String query = "UPDATE Encargado SET Persona_idPersona = @Persona_idPersona WHERE Persona_idPersona = @Persona_idPersona ";
                establecerConexion();
                int validar = 0;
                cmd = new SqlCommand(query, cnx);
                if (txtCedula.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar el numero de registro a editar')", true);
                    cnx.Close();
                    cnx.Dispose();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Persona_idPersona", Convert.ToInt32(txtCedula.Text));
                    validar = cmd.ExecuteNonQuery();
                    if (validar == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Registro editado correctamente')", true);
                        cnx.Close();
                        cnx.Dispose();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('No se pudo encontrar el registro a editar')", true);
                        cnx.Close();
                        cnx.Dispose();
                    }

                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('No se pudo editar el regitro')", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresarAlumno();
            limpiarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            limpiarControles();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
            limpiarControles();
        }
    }
}