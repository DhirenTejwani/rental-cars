using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for CodeClass
/// </summary>
public class CodeClass
{
   
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\E-HelpDesk\App_Data\MSU.mdf;Integrated Security=True");

        public void conn_state()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

        }

        public Boolean insert(string query)
        {

            try
            {
                conn_state();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public DataSet select(string query)
        {
            try
            {
                conn_state();
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public int auto(string field, string table)
        {
            int no = 0;
            string str = "select max(" + field + ") from " + table + "";
            try
            {
                conn_state();
                SqlCommand cmd = new SqlCommand(str, con);
                no = Convert.ToInt32(cmd.ExecuteScalar());
                no = no + 1;
                return no;


            }
            catch (Exception ex)
            {
                no = 1;
                return no;
            }

        }

        public int autoID(string field, string table, string groupname, string value)
        {
            int no = 0;
            string str = "select max(" + field + ") from " + table + " where " + groupname + " = " + value + "";
            try
            {
                conn_state();
                SqlCommand cmd = new SqlCommand(str, con);
                no = Convert.ToInt32(cmd.ExecuteScalar());
                no = no + 1;
                return no;


            }
            catch (Exception ex)
            {
                no = 1;
                return no;
            }

        }
    }
