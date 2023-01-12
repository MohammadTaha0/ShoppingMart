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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
            if (user != "" && pass != "")
            {
                Crud crud = new Crud();
                if (crud.DisplayData("select * from tbl_register where username = '" + user + "' and password = '" + pass + "'").Rows.Count > 0)
                {
                    ClearData();
                    Alert("Login SucessFully", "success");
                    Cursor.Current = Cursors.Arrow;
                }
                else
                {
                    Alert("Invalid Username or Password", "red");
                    Cursor.Current = Cursors.Arrow;
                }
            }
            else
            {
                Alert("Please Fill Both Fields!", "red");
            }
        }
    }
}
