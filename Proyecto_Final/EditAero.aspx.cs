using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;


public partial class EditAero : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Vuelos; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblcodigo.Text = Session["CodAero"].ToString();
            txtName.Text = Session["AeroName"].ToString();
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Equals(""))
        { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No blank spaces are allowed.')", true); }

      

            else
            {
                con.Close();
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(fileName);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);


                    SqlCommand del = new SqlCommand("Delete AEROLINEA WHERE cod_aerol = '" + Session["CodAero"] + "'", con);
                    con.Open();
                    del.ExecuteNonQuery();
                    con.Close();

                    SqlCommand cmd = new SqlCommand("spUploadImage", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraCode = new SqlParameter()
                    {
                        ParameterName = "@cod_aerol",
                        Value = Session["CodAero"]
                    };
                    cmd.Parameters.Add(paraCode);

                    SqlParameter paraName = new SqlParameter()
                    {
                        ParameterName = "@nombre",
                        Value = txtName.Text
                    };
                    cmd.Parameters.Add(paraName);

                    SqlParameter paraImage = new SqlParameter()
                    {
                        ParameterName = "@image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(paraImage);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Aerolinea Modificada')", true);
                    DatosBITACORA.agregarDato("Aerolínea modificada " + txtName.Text);
                    Response.Redirect("verAerolineas.aspx");
                    

                }

                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Image')", true);
                    DatosBITACORA.agregarDato("Problema al modificar la aerolínea " + txtName.Text);

                }
            }


}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("verAerolineas.aspx");
    }
}