using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace FundaVida
{
    public partial class Persona : System.Web.UI.Page
    {
        #region "Variables globales"
        SqlConnection cnx; //Declarando el objeto no lo inicializo
        SqlCommand cmd; //Declarado
                        //SqlDataReader dr;
                        //SqlDataAdapter sda;
       


        #endregion

        #region "Metodos globales"
        private  bool establecerConexion()
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


        private void AumentarId() {



          

        
        }

        public async Task  ingresarPersona()
        {
            try
            {

                string consulta = "SELECT idPersona FROM Persona WHERE  idPersona ='" + txtCedula.Text + "'";
                String query = "  INSERT INTO Persona(idPersona, Nombre, Apellido1, Apellido2, Fecha_Nacimiento, Genero_idGenero)" +
                "VALUES(@idPersona, @Nombre, @Apellido1, @Apellido2, @Fecha_Nacimiento, @Genero_idGenero)";
                 establecerConexion();
                cmd = new SqlCommand (query, cnx);
                cmd.Parameters.AddWithValue("@idPersona", Convert.ToInt32(txtCedula.Text));
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido1", txtApellido_1.Text);
                cmd.Parameters.AddWithValue("@Apellido2", txtApellido_2.Text);
                cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Convert.ToDateTime(caleFecha.SelectedDate));
                cmd.Parameters.AddWithValue("@Genero_idGenero", Convert.ToInt32(ddGenero.SelectedValue));

                int registrosExitoso = cmd.ExecuteNonQuery();
                await cargarPersona();

                cnx.Close();



                //if (txtCedula.Text== "") // validacion por si el campo es nullo o no tiene nada escrito
                //{

                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);

                //}
                //else
                //{

                //    if (consulta == txtCedula.Text) // validacion por si ya existe 
                //    {

                //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Ale", "error2()", true);

                //    }

                //    else
                //    {

                if (registrosExitoso > 0)
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "succes()", true);

                        }
                else
                {


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);
                }
                //}
                //}


            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);

            }
            

        }

        public  async Task cargarPersona()
        {
            try
            {
                establecerConexion();
                SqlDataAdapter da = new SqlDataAdapter ("SELECT* FROM Persona", cnx);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.gVDatos.DataSource = dt;
                gVDatos.DataBind();
               


                
            }
            catch (Exception e)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);
            }
            
        }

        public void  buscarPersona()
        {
            try
            {
                establecerConexion();
                SqlDataAdapter da = new SqlDataAdapter("SELECT* FROM Persona WHERE idPersona = '" + txtBuscar.Text + "'", cnx);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.gVDatos.DataSource = dt;
                gVDatos.DataBind();


                if (dt.Rows.Count > 0) { // valida si existe 

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "succes4()", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);

                }
            }
            catch (Exception e)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);
            }
            

        }

        public async Task Eliminar()
        {

            try
            {
              
                String query = "DELETE FROM Persona WHERE idPersona = @idPersona";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("idPersona", txtCedula.Text);
                
                int registrosExitoso = cmd.ExecuteNonQuery();
                await cargarPersona();
                
                cnx.Close();



                if (registrosExitoso > 0)
                {


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "succes3()", true);


                }
                else {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);
                }

            }
            catch (Exception e)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);
            }
           
        }

        public async Task Editar()
        {

            try
            {
                String query = "UPDATE Persona SET Nombre = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2, Fecha_Nacimiento = @Fecha_Nacimiento, Genero_idGenero = @Genero_idGenero  WHERE idPersona = @idPersona ";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@idPersona", Convert.ToInt32(txtCedula.Text));
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido1", txtApellido_1.Text);
                cmd.Parameters.AddWithValue("@Apellido2", txtApellido_2.Text);
                cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Convert.ToDateTime(caleFecha.SelectedDate));
                cmd.Parameters.AddWithValue("@Genero_idGenero", Convert.ToInt32(ddGenero.SelectedValue));
                int registrosExitoso =  cmd.ExecuteNonQuery();
                await cargarPersona();
                cnx.Close();

                if (registrosExitoso > 0)
                {


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "succes2()", true);




                }

                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);
                }

            }
            catch (Exception e)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "error()", true);
            }
           
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
            
        {

       
            
        }

        protected void ddGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresarPersona();
            
            
        }

        protected  void btnRefrescar_Click(object sender, EventArgs e)
        {
               cargarPersona();
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
            buscarPersona();
        }
    }
}