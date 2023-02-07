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
    public partial class Register : Form
    {
        Crud crud = new Crud();
        int UserStatus = 0;
        int EmailStatus = 0;
        int NameStatus = 0;
        int MobileStatus = 0;
        int PassStatus = 0;
        public Register()
        {
            InitializeComponent();
            DataTable cd = crud.DisplayData("select * from tbl_role");
            for (int i = 0; i < cd.Rows.Count; i++)
            {
                cmbbxRole.Items.Add(cd.Rows[i]["role"] + " "+cd.Rows[i]["name"]);
            }
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
        private void txtbxUserName_Leave(object sender, EventArgs e)
        {
            TextBox txtbx = (TextBox)sender;
            if (txtbx.Name == "txtbxUserName")
            {
                if (crud.DisplayData("select * from tbl_register where username = '" + txtbxUserName.Text + "'").Rows.Count > 0)
                {
                    label8.Text = "This UserName Already Exist!";
                    label8.ForeColor = Color.White;
                    label8.BackColor = Color.Red;
                    UserStatus = 1;
                    Alert("Already Exist!", "Danger");
                }
                else if (txtbxUserName.TextLength < 5)
                {
                    label8.Text = "Should > 5";
                    label8.ForeColor = Color.White;
                    label8.BackColor = Color.Red;
                    Alert("Should > 5", "Danger");
                    UserStatus = 1;
                }
                else
                {
                    label8.Text = "";
                    UserStatus = 0;
                }
            }
            else if (txtbx.Name == "txtbxEmail")
            {
                if (crud.DisplayData("select * from tbl_register where Email = '" + txtbxEmail.Text + "'").Rows.Count > 0)
                {
                    label10.Text = "This Email Already Exist!";
                    label10.ForeColor = Color.White;
                    label10.BackColor = Color.Red;
                    Alert("Already Exist!", "Danger");
                    EmailStatus = 1;
                }
                else if (txtbxEmail.TextLength < 5)
                {
                    label10.Text = "Should > 5";
                    label10.ForeColor = Color.White;
                    label10.BackColor = Color.Red;
                    EmailStatus = 1;
                    Alert("Should > 5", "Danger");
                }
                else
                {
                    label10.Text = "";
                    EmailStatus = 0;
                }
            }
            else if (txtbx.Name == "txtbxName")
            {
                if (txtbxName.TextLength < 5)
                {
                    label7.Text = "Should > 5";
                    label7.ForeColor = Color.White;
                    label7.BackColor = Color.Red;
                    NameStatus = 1;
                    Alert("Should > 5", "Danger");
                }
                else
                {
                    label7.Text = "";
                    NameStatus = 0;
                }
            }
            else if (txtbx.Name == "txtbxMob")
            {
                if (txtbxMob.TextLength != 11)
                {
                    label9.Text = "Should be 11";
                    label9.ForeColor = Color.White;
                    label9.BackColor = Color.Red;
                    MobileStatus = 1;
                    Alert("Should be 11", "Danger");
                }
                else
                {
                    label9.Text = "";
                    MobileStatus = 0;
                }
            }
            else if (txtbx.Name == "txtbxPassword")
            {
                if (txtbxPassword.TextLength < 4)
                {
                    label11.Text = "Should > 4";
                    label11.ForeColor = Color.White;
                    label11.BackColor = Color.Red;
                    PassStatus = 1;

                }
                else
                {
                    label11.Text = "";
                    PassStatus = 0;
                }
            };
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (NameStatus == 0 && UserStatus == 0 && MobileStatus == 0 && EmailStatus == 0 && PassStatus == 0)
            {
                crud.InsertData(txtbxName.Text, txtbxEmail.Text, txtbxMob.Text, txtbxPassword.Text, txtbxUserName.Text, cmbbxRole.Text.Split(' ')[0]);
                ClearData();
                this.Alert("Registered SuccessFully", "success");
            }
            else
            {
                this.Alert("Plesae Fill Properly!", "red");
            }
        }
        public void Alert(string msg, string type)
        {
            Alert frm = new Alert();
            frm.showAlert(msg, type);
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Alert("Already Running!", "red");
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
