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
    public partial class Institucion : System.Web.UI.Page
    {

        #region "Variables globales"
        SqlConnection cnx; //Declarando el objeto no lo inicializo
        SqlCommand cmd; //Declarado
        SqlDataReader dr;
        SqlDataAdapter sda;
        Inicio instancia = new Inicio();
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

        public void ingresarInstitucion()
        {
            try
            {
                String query = "INSERT INTO Institucion(idInstitucion, Descripcion)" +
                   "VALUES(@idInstitucion, @Descripcion)";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                if (txtIdInstitucion.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar todos los datos')", true);
                    cnx.Close();
                    cnx.Dispose();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idInstitucion", Convert.ToInt32(txtIdInstitucion.Text));
                    cmd.Parameters.AddWithValue("@Descripcion", txtNombreInstitucion.Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Institucion ingresado correctamente')", true);
                    cnx.Close();
                    cnx.Dispose();

                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('No se pudo guardar el registro')", true);

            }

        }

        public void editarInstitucion()
        {

            try
            {

                String query = "UPDATE Institucion SET idInstitucion = @idInstitucion , Descripcion = @Descripcion";
                establecerConexion();
                int validar = 0;
                cmd = new SqlCommand(query, cnx);
                if (txtIdInstitucion.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar todos los datos')", true);
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    cnx.Dispose();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idInstitucion", Convert.ToInt32(txtIdInstitucion.Text));
                    cmd.Parameters.AddWithValue("@Descripcion", txtNombreInstitucion.Text);
                    cmd.ExecuteNonQuery();
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

        public void eliminarInstitucion()
        {

            try
            {
                String query = "DELETE FROM Institucion WHERE idInstitucion = @idInstitucion";
                establecerConexion();
                int validar = 0;
                cmd = new SqlCommand(query, cnx);
                if (txtIdInstitucion.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar el numero de registro para eliminar')", true);
                    cnx.Close();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idInstitucion", txtIdInstitucion.Text);
                    validar = cmd.ExecuteNonQuery();
                    if (validar == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Institucion eliminada del registro')", true);
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
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresarInstitucion();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarInstitucion();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            editarInstitucion();
        }
    }
}