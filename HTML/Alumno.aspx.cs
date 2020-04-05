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
    public partial class Alumno : System.Web.UI.Page
    {
        #region "Variables globales"
        SqlConnection cnx; //Declarando el objeto no lo inicializo
        SqlCommand cmd; //Declarado
        SqlDataReader dr;
        SqlDataAdapter sda;
        Inicio insInicio = new Inicio();
        Menu insMenu = new Menu();
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

        protected void OpenWindow(object sender, EventArgs e)
        {
            string url = "Institucion.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=500,height=400,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        public void ingresarAlumno()
        {
            try
            {
                String query = "INSERT INTO Niño(Persona_idPersona, Activo , Institucion_idInstitucion, Grado_idGrado, Encargado_Persona_idPersona,Recogen, Cede_idCede )" +
                "VALUES(@Persona_idPersona, @Activo, @Institucion_idInstitucion, @Grado_idGrado, @Encargado_Persona_idPersona, @Recogen, @Cede_idCede )";
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
                    cmd.Parameters.AddWithValue("@Activo", cbActivo.Checked);
                    cmd.Parameters.AddWithValue("@Institucion_idInstitucion", Convert.ToInt32(ddInstitucion.SelectedValue));
                    cmd.Parameters.AddWithValue("@Grado_idGrado", Convert.ToInt32(ddGrado.SelectedValue));
                    cmd.Parameters.AddWithValue("@Encargado_Persona_idPersona", Convert.ToInt32(ddEncargado.SelectedValue));
                    cmd.Parameters.AddWithValue("@Recogen", cbRecogen.Checked);
                    cmd.Parameters.AddWithValue("@Cede_idCede", Convert.ToInt32(ddSede.SelectedValue));
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Estudiante ingresado correctamente')", true);
                    cnx.Close();
                    cnx.Dispose();

                }


            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('No se pudo guardar el registro')", true);

            }



        }

        public void cargarAlumno()
        {

            establecerConexion();
            SqlDataAdapter da = new SqlDataAdapter("SELECT P.idPersona, P.Nombre, P.Apellido1, P.Apellido2, N.Activo, N.Institucion_idInstitucion,(I.Descripcion)DesInsti, N.Grado_idGrado,(G.Descricpcion)Des, N.Encargado_Persona_idPersona, N.Recogen, N.Cede_idCede, C.Descricpcion FROM Niño N JOIN persona P on P.idPersona = N.Persona_idPersona JOIN Institucion I ON I.idInstitucion = N.Institucion_idInstitucion JOIN Grado G ON G.idGrado = N.Grado_idGrado JOIN Cede C on C.idCede = N.Cede_idCede", cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.gVDatos.DataSource = dt;
            gVDatos.DataBind();

        }

        public void buscarAlumno()
        {


            establecerConexion();
            SqlDataAdapter da = new SqlDataAdapter("SELECT P.idPersona, P.Nombre, P.Apellido1, P.Apellido2, N.Activo, (N.Institucion_idInstitucion)DesInsti, N.Grado_idGrado, N.Encargado_Persona_idPersona, N.Recogen, N.Cede_idCede FROM Niño N JOIN persona P on P.idPersona = N.Persona_idPersona where idPersona LIKE'" + txtBuscar.Text + "%'", cnx);
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
                int validar = 0;
                cmd = new SqlCommand(query, cnx);
                if (txtCedula.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar el numero de registro para eliminar')", true);
                    cnx.Close();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Persona_idPersona", txtCedula.Text);
                    validar = cmd.ExecuteNonQuery();
                    if (validar == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Estudiante eliminado del registro')", true);
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
                String query = "UPDATE Niño SET  Activo = @Activo, Institucion_idInstitucion=@Institucion_idInstitucion, Grado_idGrado = @Grado_idGrado, Encargado_Persona_idPersona = @Encargado_Persona_idPersona, Recogen = @Recogen, Cede_idCede = @Cede_idCede  WHERE Persona_idPersona = @Persona_idPersona ";
                establecerConexion();
                int validar = 0;
                cmd = new SqlCommand(query, cnx);
                if (txtCedula.Text == String.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "clave1", "Swal.fire('Debes ingresar el id del registro a editar')", true);
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    cnx.Dispose();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Persona_idPersona", Convert.ToInt32(txtCedula.Text));
                    cmd.Parameters.AddWithValue("@Activo", cbActivo.Checked);
                    cmd.Parameters.AddWithValue("@Institucion_idInstitucion", Convert.ToInt32(ddInstitucion.SelectedValue));
                    cmd.Parameters.AddWithValue("@Grado_idGrado", Convert.ToInt32(ddGrado.SelectedValue));
                    cmd.Parameters.AddWithValue("@Encargado_Persona_idPersona", Convert.ToInt32(ddEncargado.SelectedValue));
                    cmd.Parameters.AddWithValue("@Recogen", cbRecogen.Checked);
                    cmd.Parameters.AddWithValue("@Cede_idCede", Convert.ToInt32(ddSede.SelectedValue));
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

        public void seleccionarEncargado()
        {

            String query = "Select Persona_idPersona from Encargado";
            establecerConexion();
            cmd = new SqlCommand(query, cnx);
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {
                ddEncargado.Items.Add(registro["Persona_idPersona"].ToString());

            }

        }
        public void seleccionarInstitucion()
        {

            String query = "Select idInstitucion from Institucion";
            establecerConexion();
            cmd = new SqlCommand(query, cnx);
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {
                ddInstitucion.Items.Add(registro["idInstitucion"].ToString());

            }

        }


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            seleccionarEncargado();
            seleccionarInstitucion();
            insInicio.RemoverDuplicacion(ddGrado);
            insInicio.RemoverDuplicacion(ddEncargado);
            insInicio.RemoverDuplicacion(ddInstitucion);
            insMenu.permisos(lblUsuario, btnIngresar, btnEliminar, btnEditar, btnBuscar, btnRefrescar);

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresarAlumno();
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargarAlumno();
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
