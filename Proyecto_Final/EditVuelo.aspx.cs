using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class EditVuelo : System.Web.UI.Page
{
    SqlConnection con2 = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Vuelos; Integrated Security = True");

    protected void Page_Load(object sender, EventArgs e)
    {
        lblcodigo.Text = Session["conVuex"].ToString();

        if (!Page.IsPostBack)
        {
            dplEstado.Items.Clear();
            ListItem arribo = new ListItem("Arribó", "Arribó");
            ListItem salio = new ListItem("Salió", "Salió");
            ListItem confirmado = new ListItem("Confirmado", "Confirmado");
            ListItem demorado = new ListItem("Demorado", "Demorado");
            ListItem atiempo = new ListItem("A tiempo", "A tiempo");

            if (Session["drop"].Equals("salida"))
            {
                
                dplEstado.Items.Add(salio);
                dplEstado.Items.Add(confirmado);
                dplEstado.Items.Add(demorado);
                dplEstado.Items.Add(atiempo);

            }

            else
            {
             
                dplEstado.Items.Add(arribo);
                dplEstado.Items.Add(confirmado);
                dplEstado.Items.Add(demorado);
                dplEstado.Items.Add(atiempo);
            }
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {

            con2.Close();
            con2.Open();
            SqlCommand com = new SqlCommand("UPDATE VUELO SET estado=@a1 where cod_vuelo = '" + Session["conVuex"] + "'", con2);
            com.Parameters.AddWithValue("a1", dplEstado.Text);
            com.ExecuteNonQuery();
            con2.Close();
            Response.Redirect("Vuelos.aspx");
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vuelo Editado')", true);
        }
        catch (Exception)
        { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Data')", true); }

    }
}

