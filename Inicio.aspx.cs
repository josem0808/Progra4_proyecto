using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Threading.Tasks;

namespace FundaVida
{
    public partial class Inicio : System.Web.UI.Page
    {
        #region "Variables globales"
        SqlConnection cnx; //Declarando el objeto no lo inicializo
        SqlCommand cmd; //Declarado
        SqlDataReader dr;
        SqlDataAdapter sda;
        Login obj = new Login();
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




        public  void Logear(String usuario, String contraseña)
        {

            try
            {

                String query = "SELECT Persona_idPersona, Rol_idRol FROM Usuario WHERE Nombre_usuario = @Nombre_usuario AND Contraseña = @Contraseña";
                establecerConexion();//Se llama al metodo 
                cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@Nombre_usuario", usuario);
             cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                DataTable dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                

                if (dt.Rows.Count == 1)
                {

                    if (dt.Rows[0][1].ToString() == "1")
                    {
                        Session["Nombre_usuario"] = txtUsuario.Text;
                        Session["tipoUsuario"] = "1";
                        Response.Redirect("Comandos.aspx");
                        
                    }
                    else if (dt.Rows[0][1].ToString() == "2")
                    {
                        Session["Nombre_usuario"] = txtUsuario.Text;
                        Session["tipoUsuario"] = "2";
                        Response.Redirect("Comandos.aspx");

                    }
 
                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "succesLog()", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ALTER", "alert('Usuario y/o Contraseña incorrecta');", true);
                }
            }
            catch (Exception e)
            {

                
            }

            

            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
           
            Logear(txtUsuario.Text.Trim(),txtContraseña.Text.Trim());
            establecerConexion();
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "succesLog()", true);
  


        }

        protected void btnPrueba_Click(object sender, EventArgs e)
        {
           
        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}