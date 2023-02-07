using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingMart
{
    public partial class LoginForm : Form
    {
        Crud crud = new Crud();
        public static class loginAuth
        {
            public static int role;
        }
        public LoginForm()
        {
            InitializeComponent();
            DataTable cd = crud.DisplayData("select * from tbl_role");
            for (int i = 0; i < cd.Rows.Count; i++)
            {
                cmbbxRole.Items.Add(cd.Rows[i]["role"] + " " + cd.Rows[i]["name"]);
            }
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
            this.Close();
        }
        public void Alert(string msg, string type)
        {
            Alert frm = new Alert();
            frm.showAlert(msg, type);
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alert("Already Running!", "red");
        }
        private void ClearData()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string user = txtbxUser.Text;
            string pass = txtbxPass.Text;
            string roles = cmbbxRole.Text;
            if (user != "" && pass != "" && roles != "")
            {
                Crud crud = new Crud();
                string role = cmbbxRole.Text.Split(' ')[0];
                if (crud.loginAuth(user,pass,role))
                {
                    ClearData();
                    Alert("Login SucessFully", "success");
                    Cursor.Current = Cursors.Arrow;
                    if (role == "0")
                    {
                        Admin Admin = new Admin();
                        this.Hide();
                        Admin.ShowDialog();
                        this.Close();
                    }
                    else if (role == "1")
                    {
                        GenerateBills GB = new GenerateBills();
                        this.Hide();
                        GB.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    Alert("Invalid Username or Password", "red");
                    Cursor.Current = Cursors.Arrow;
                }
            }
            else
            {
                Alert("Please Fill All Fields!", "red");
            }
        }
    }
}
