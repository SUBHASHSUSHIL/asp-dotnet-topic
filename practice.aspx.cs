using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;

namespace Project
{
    //Ajax control toolkit use-------------------
    public partial class practice : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F1LI6MI;initial catalog=master;integrated security=true");
        SqlCommand cmd;
        public string Query { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Query = "insert into Practice_Ajax (Name,FatherName) values (@Name,@FatherName)";
            cmd = new SqlCommand(Query,con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Name",TextBox1.Text);
            cmd.Parameters.AddWithValue("@FatherName",TextBox2.Text);
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('inserted successfully..')</script>");
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        //Not Reload----------------------------------------------
        protected void Button2_Click(object sender, EventArgs e)
        {
            Query = "insert into Practice_Ajax (Name,FatherName) values (@Name,@FatherName)";
            cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Name", TextBox3.Text);
            cmd.Parameters.AddWithValue("@FatherName", TextBox4.Text);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('inserted successfully..')</script>");
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        // default fill third box----------------------------------------
        protected void Button3_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox5.Text);
            int b = int.Parse(TextBox6.Text);
            int result = a + b;
            TextBox7.Text = result.ToString();
            TextBox7.Visible = true;
        }


        //--Filtration(auto complete)----------------------------

        [System.Web.Script.Services.ScriptMethod]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText,int count)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                string Query = "select * from tbl_Country where Country like @name + '%'";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", prefixText);
                List<string> CountryName = new List<string>();
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CountryName.Add(dr["Country"].ToString());
                }
                con.Close();
                return CountryName;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using( SqlConnection con = new SqlConnection(cs))
            {
                string Query = "select * from stdu where Id = @Id";
                SqlDataAdapter adp = new SqlDataAdapter(Query, con);
                adp.SelectCommand.Parameters.AddWithValue("@Id",txtSearch.Text);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["name"].ToString();
                    txtDesignation.Text = dt.Rows[0]["designation"].ToString();
                    Label1.Text = "Record Found !!";
                    Label1.ForeColor = Color.Green;
                    Label1.Visible = true;
                }
                else
                {
                    Label1.Text = "Record Not Found !!";
                    Label1.ForeColor = Color.Red;
                    Label1.Visible = true;
                    txtName.Text = "";
                    txtDesignation.Text = "";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                string Query = "Update stdu set Name = @Name,Designation = @Designation where Id = @Id";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id",txtSearch.Text.ToString());
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Response.Write("<script>alert('Updated Successfully..')</script>");
                    txtName.Text = "";
                    txtDesignation.Text = "";
                    txtSearch.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Updated Failed..')</script>");
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            string Query = "Delete from stdu where Id = @Id";
            SqlCommand cmd = new SqlCommand(Query,con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id",txtSearch.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Response.Write("<script>alert('Deleted Successfully..')</script>");
            }
            else
            {
                Response.Write("<script>alert('Deleted Failed')</script>");
            }
        }
        //------------DateTime current--------------------------------
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            Label2.Text = dt.ToString();
        }
        //---------------5 Star --------------------
        protected void Rating1_Click(object sender, AjaxControlToolkit.RatingEventArgs e)
        {
            Label3.Text = "You gave us" + e.Value.ToString() + "Star";
            Label3.Visible = true;
        }
        //----List box and dropdown--------------------------
        protected void Button6_Click(object sender, EventArgs e)
        {
            //Label4.Text = "you have selected" + ListBox1.SelectedItem.ToString();
            Label4.Text = "you have selected" + DropDownList1.SelectedItem.ToString();
        }
        //-----------HTML editor text------------------------------------
        protected void Button8_Click(object sender, EventArgs e)
        {
            Label5.Text = TextBox24.Text;
            Label5.Visible = true;
        }

    }
}