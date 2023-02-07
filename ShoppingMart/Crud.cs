using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMart
{
    internal class Crud
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=ShoppingMart;User ID=taha1234;Password=taha1234");
        int id = 0;
        public DataTable DisplayData(string query)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            adp.Fill(dt);
            con.Close();
            return dt;
        }
        public void InsertData(string name, string email, string mob, string password, string username, string role)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_register([name],email,mob,[password],username,role) values(@name,@email,@mob,@pass,@username,@role)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mob", mob);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void CrudData(string query)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool loginAuth(string user, string pass, string role)
        {
            con.Open();
            DataTable dts = new DataTable();
            SqlDataAdapter cmd = new SqlDataAdapter("select id from tbl_register where username = @user and password = @pass and role = @role", con);
            cmd.SelectCommand.Parameters.Add(new SqlParameter("@user", user));
            cmd.SelectCommand.Parameters.Add(new SqlParameter("@pass", pass));
            cmd.SelectCommand.Parameters.Add(new SqlParameter("@role", role));
            cmd.Fill(dts);
            con.Close();
            if (dts.Rows.Count == 1)
            {
                return true;
            }
            else{
                return false;
            }
        }
    }
}
