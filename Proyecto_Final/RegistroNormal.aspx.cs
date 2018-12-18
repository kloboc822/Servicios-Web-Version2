using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistroNormal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void createBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (idTxt.Text.Equals("") || passwordTxt.Text.Equals("") || firstnameTxt.Text.Equals("") || surname1Txt.Text.Equals("") || surname2Txt.Text.Equals("") || emailTxt.Text.Equals("") || PreguntaTxt.Text.Equals("Seleccione una pregunta de seguridad"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No pueden haber campos vacíos')", true);
            }
            else
            {
                string resultado;
                resultado = Usuarios.verificaUsuario(Int32.Parse(idTxt.Text));
                if (resultado.Equals("exitoso"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ya existe un usuario ligado a este ID')", true);
                }
                else
                {
                    resultado = Usuarios.addUser(firstnameTxt.Text, surname1Txt.Text, surname2Txt.Text, Int32.Parse(idTxt.Text), emailTxt.Text, 6, passwordTxt.Text, nacionalidadTxt.Text, PreguntaTxt.SelectedValue.ToString(), RespuestaTxt.Text);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultado + "')", true);
                    Response.Redirect("http://localhost:53551/LogIn.aspx");
                }
            }
        }
        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error en codigo de boton')", true);
            throw;
        }
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/LogIn.aspx");
    }
}