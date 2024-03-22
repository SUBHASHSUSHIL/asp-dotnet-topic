using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace asp.net_CRUD_operation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);
        SqlCommand cmd;
        public string Query { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Query = "_insertEmp";
                using (cmd = new SqlCommand(Query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Inserted Successfully..')</script>");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        protected void txtupdate_Click(object sender, EventArgs e)
        {
            try
            {
                Query = "_UpdateEmp";
                using(cmd = new SqlCommand(Query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", txtid.Text);
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open() ;
                    }
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Updated Successfully..')</script>");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close() ;
                }
            }
        }

        protected void txtdelete_Click(object sender, EventArgs e)
        {
            try
            {
                Query = "_deleteEmp";
                using (cmd = new SqlCommand(Query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", txtid.Text);
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Deleted Successfully..')</script>");
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            
        }

        protected void txtselect_Click(object sender, EventArgs e)
        {
            try
            {
                Query = "_selectEmp";
                using(cmd = new SqlCommand(Query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", txtid.Text);
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        txtname.Text = dr["Name"].ToString();
                        txtemail.Text = dr["Email"].ToString();
                        txtphone.Text = dr["Phone"].ToString() ;
                        txtaddress.Text = dr["Address"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('No Record Found..')</script>");
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}