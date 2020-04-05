using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

namespace FundaVida
{
    public partial class Voluntario1 : System.Web.UI.Page
    {
        #region "Variables globales"
        SqlConnection cnx; //Declarando el objeto no lo inicializo
        SqlCommand cmd; //Declarado
        SqlDataReader dr;
        SqlDataAdapter sda;
        Inicio instancia = new Inicio();
        #endregion



        #region "Variables globales"
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

        public void exportar()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=listaVoluntariosFundaVida.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gVDatos.AllowPaging = false;
            this.cargarVoluntario();//llamamos al metodo que carga el gridview
            gVDatos.RenderControl(hw);
            String style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  

        }


        public void ingresarVoluntario()
        {
            String query = "INSERT INTO Tutor(Persona_idPersona,Fecha_ingreso,Activo, idUniversidad)" +
               "VALUES(@Persona_idPersona, @Fecha_ingreso, @Activo, @idUniversidad)";
            establecerConexion();
            cmd = new SqlCommand(query, cnx);
            cmd.Parameters.AddWithValue("@Persona_idPersona", Convert.ToInt32(txtCedula.Text));
            cmd.Parameters.AddWithValue("@Fecha_ingreso", Convert.ToDateTime(caleFecha.SelectedDate));
            cmd.Parameters.AddWithValue("@Activo", cbActivo.Checked);
            cmd.Parameters.AddWithValue("@idUniversidad", Convert.ToInt32(ddUniversidad.SelectedValue));
            cmd.ExecuteNonQuery();

            Session["prueba"] = "Se agrego el nuevo alumno correctamente";
            lblVal.Text = (String)Session["prueba"];

        }





        public void buscarVoluntario()
        {


            establecerConexion();
            SqlDataAdapter da = new SqlDataAdapter("SELECT P.idPersona, P.Nombre, P.Apellido1, P.Apellido2, V.Activo, V.Fecha_ingreso FROM Tutor V JOIN persona P on P.idPersona = V.Persona_idPersona where idPersona LIKE'" + txtBuscar.Text + "%'", cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.gVDatos.DataSource = dt;
            gVDatos.DataBind();



        }

        public void cargarVoluntario()
        {


            establecerConexion();
            SqlDataAdapter da = new SqlDataAdapter("SELECT P.idPersona, P.Nombre, P.Apellido1, P.Apellido2, T.Activo, T.Fecha_ingreso, U.idUniversidad, U.Descripcion FROM Tutor T JOIN persona P on P.idPersona = T.Persona_idPersona JOIN universidad U on U.idUniversidad = T.Universidad_idUniversidad", cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.gVDatos.DataSource = dt;
            gVDatos.DataBind();



        }

        public void Eliminar()
        {

            try
            {
                String query = "DELETE FROM Voluntario WHERE Persona_idPersona = @Persona_idPersona";
                establecerConexion();
                cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@Persona_idPersona", txtCedula.Text);
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            catch (Exception e)
            {

                lblVal.Text = e.ToString();
            }

        }

        public void Editar()
        {


            String query = "UPDATE Tutor SET Fecha_ingreso = @Fecha_ingreso , Activo = @Activo , idUniversidad = @Universidad WHERE Persona_idPersona = @Persona_idPersona ";
            establecerConexion();
            cmd = new SqlCommand(query, cnx);
            cmd.Parameters.AddWithValue("@Persona_idPersona", Convert.ToInt32(txtCedula.Text));
            cmd.Parameters.AddWithValue("@Fecha_ingreso", caleFecha.SelectedDate);
            cmd.Parameters.AddWithValue("@Activo", cbActivo.Checked);
            cmd.Parameters.AddWithValue("@idUniversidad", Convert.ToInt32(ddUniversidad.SelectedValue));
            cmd.ExecuteNonQuery();
            cnx.Close();


        }

        public void seleccionarUniversidad()
        {

            String query = "Select DISTINCT idUniversidad from Universidad ";
            establecerConexion();
            cmd = new SqlCommand(query, cnx);
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {
                ddUniversidad.Items.Add(registro["idUniversidad"].ToString());
            }

        }

        void RemoverDuplicacion(DropDownList ddl)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                ddl.SelectedIndex = i;
                string str = ddl.SelectedItem.ToString();
                for (int counter = i + 1; counter < ddl.Items.Count; counter++)
                {
                    ddl.SelectedIndex = counter;
                    string compareStr = ddl.SelectedItem.ToString();
                    if (str == compareStr)
                    {
                        ddl.Items.RemoveAt(counter);
                        counter = counter - 1;
                    }
                }
            }
        }

        #endregion

        protected void OpenWindow(object sender, EventArgs e)
        {
            string url = "Universidad.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=500,height=100,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            seleccionarUniversidad();
            RemoverDuplicacion(ddUniversidad);
            instancia.esconderCalendario(caleFecha);
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresarVoluntario();
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {


            cargarVoluntario();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarVoluntario();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            exportar();
        }
        protected void caleFecha_SelectionChanged(object sender, EventArgs e)
        {
            instancia.fecha(txtFecha, caleFecha);
        }
        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        {
            instancia.verClendario(caleFecha);
        }

        protected void btnNuevaUniversidad_Click(object sender, EventArgs e)
        {
            
        }
    }
}
