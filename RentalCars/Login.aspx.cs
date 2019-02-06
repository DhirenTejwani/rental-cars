using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Login : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_Func(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BHAVIK\source\WebSites\WebSite2\App_Data\Database.mdf;Integrated Security=True");
        SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from Login where name = '" + uid.Text + "' and password = '" + pid.Text + "'",con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows[0][0].ToString() == "1")
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('done')", true);
            Response.Redirect("~/ULogin.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Email ID or Password')", true);
        }

        
    }
}