using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace sample3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = getrecords();
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            insertData(TextBox1.Text, TextBox2.Text);
        }
        void insertData(string t1,string t2)
        {
            
            string con = "server=FOB3JV1W2G; database=Training; Integrated Security=SSPI";
            SqlConnection sqlcon = new SqlConnection(con);
            string sqltest="Insert into Users values('"+t1+"','"+t2+"')";
            SqlCommand sqlcmd = new SqlCommand(sqltest, sqlcon);
            sqlcon.Open();
            sqlcmd.ExecuteNonQuery();
        }
        SqlDataReader getrecords()
        {
            string con = "server=FOB3JV1W2G; database=Training; Integrated Security=SSPI";
            SqlConnection sqlcon = new SqlConnection(con);
            string sqltest = "Select * from Users";
            SqlCommand sqlcmd = new SqlCommand(sqltest, sqlcon);
            sqlcon.Open();
            DataTable dt = new DataTable();
            SqlDataReader dr = sqlcmd.ExecuteReader();
            return dr;




        }

    }

}