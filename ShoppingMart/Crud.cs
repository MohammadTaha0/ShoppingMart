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
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=ShoppingMart;User ID=mtaha;Password=mtaha");
        int id = 0;
        public DataTable DisplayData(string query)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(query,con);
            adp.Fill(dt);
            con.Close();
            return dt;
        }
        public void InsertData(string name, string mob,string email,string password,string username)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_register([name],email,mob,[password],username) values(@name,@email,@mob,@pass,@username)",con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mob", mob);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void CrudData(string query)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
