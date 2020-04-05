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
    public partial class PopUp : System.Web.UI.Page
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

        public void ingresarUniversidad()
        {
            try
            {
                String query = "INSERT INTO Universidad(idUniversidad, Descripcion)" +
                   "VALUES(@idUniversidad, @Descripcion)";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                if (txtIdUniversidad.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar todos los datos')", true);
                    cnx.Close();
                    cnx.Dispose();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idUniversidad", Convert.ToInt32(txtIdUniversidad.Text));
                    cmd.Parameters.AddWithValue("@Descripcion", txtNombreUniversidad.Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Universidad ingresado correctamente')", true);
                    cnx.Close();
                    cnx.Dispose();

                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('No se pudo guardar el registro')", true);

            }
        }

        public void editarUniversidad()
        {
            try
            {

                String query = "UPDATE Universidad SET idUniversidad = @idUniversidad , Descripcion = @Descripcion";
                establecerConexion();
                int validar = 0;
                cmd = new SqlCommand(query, cnx);
                if (txtIdUniversidad.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar todos los datos')", true);
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    cnx.Dispose();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idUniversidad", Convert.ToInt32(txtIdUniversidad.Text));
                    cmd.Parameters.AddWithValue("@Descripcion", txtNombreUniversidad.Text);
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

        public void eliminarUniversidad()
        {

            try
            {
                String query = "DELETE FROM Universidad WHERE idUniversidad = @idUniversidad";
                establecerConexion();
                int validar = 0;
                cmd = new SqlCommand(query, cnx);
                if (txtIdUniversidad.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar el numero de registro para eliminar')", true);
                    cnx.Close();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idUniversidad", txtIdUniversidad.Text);
                    validar = cmd.ExecuteNonQuery();
                    if (validar == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Universidad eliminada del registro')", true);
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
            ingresarUniversidad();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            editarUniversidad();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarUniversidad();
        }
    }
}