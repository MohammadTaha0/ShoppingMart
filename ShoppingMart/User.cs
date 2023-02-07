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
    public partial class User : Form
    {
        Crud crud = new Crud();
        int id = 0;
        public User()
        {
            InitializeComponent();
            DataTable cd = crud.DisplayData("select * from tbl_role");
            for (int i = 0; i < cd.Rows.Count; i++)
            {
                cmbbxRole.Items.Add(cd.Rows[i]["role"] + " " + cd.Rows[i]["name"]);
            }
            display();
        }

        public void display()
        {
            DataTable dt = crud.DisplayData("select A.id,A.name,A.username,A.email,A.password,A.mob,B.name,A.date from tbl_register A inner join tbl_role B on B.role = A.role");
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
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
        Alert alt = new Alert();

        private void btnAddVen_Click(object sender, EventArgs e)
        {
            if (txtbxName.Text != "" && txtbxEmail.Text != "" && txtbxMob.Text != "" && txtbxPassword.Text != "" && txtbxUserName.Text != "" && cmbbxRole.Text != "")
            {
                crud.InsertData(txtbxName.Text, txtbxEmail.Text, txtbxMob.Text, txtbxPassword.Text, txtbxUserName.Text, cmbbxRole.Text.Split(' ')[0]);
                ClearData();
                alt.showAlert("Add SuccessFully", "success");
                display();
            }
            else
            {
                alt.showAlert("Plesae Fill Properly!", "red");
            }
        }

        private void manageProduct_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            this.Hide();
            adm.ShowDialog();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm lgn = new LoginForm();
            this.Hide();
            lgn.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtbxName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtbxUserName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtbxMob.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbxEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtbxPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbbxRole.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}
