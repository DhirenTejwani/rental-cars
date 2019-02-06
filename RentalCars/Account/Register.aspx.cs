using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using WebSite2;
using System.Data.SqlClient;
using System.Configuration;

public partial class Account_Register : Page { 

    protected void Page_Load(object sender, EventArgs e)
{
    if (IsPostBack)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        conn.Open();
        string checkuser = "select  count(*) from Login where name='" + UserName.Text + "'";
        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        if (temp == 1)
        {
            Response.Write("user exits");
        }


        conn.Close();
    }
}

    protected void CreateUser_Click(object sender, EventArgs e)
    {

        try
        {

            Guid newGUID = Guid.NewGuid();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            string checkuser = "select  count(*) from Login where name='" + UserName.Text + "'";
            SqlCommand com1 = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com1.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 0)
            {
                conn.Open();
                string insertQue = "insert into Login (name,email,password) values (@Uname,@email,@password)";
                SqlCommand com = new SqlCommand(insertQue, conn);
                
                com.Parameters.AddWithValue("@Uname", UserName.Text);
                com.Parameters.AddWithValue("@email", Email.Text);
                com.Parameters.AddWithValue("@password", Password.Text);
                

                com.ExecuteNonQuery();
                Response.Redirect("~/ULogin.aspx");
                Response.Write("registration is successful");




                conn.Close();
            }
            else
            {
                Response.Write("Account Already Exists");
            }
        }
        catch (Exception ex)
        {
            Response.Write("error:" + ex.ToString());
        }
    }
}