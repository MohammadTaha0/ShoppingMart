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
    public partial class Vendor : Form
    {
        public Vendor()
        {
            InitializeComponent();
            display();
        }
        Crud crd = new Crud();

        private void Vendor_Load(object sender, EventArgs e)
        {

        }

        private void txtbxVName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtbxVAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtbxVCon_TextChanged(object sender, EventArgs e)
        {

        }
        int id = 0;
        public void clearData()
        {
            txtbxVName.Text = "";
            txtbxVCon.Text = "";
            txtbxVAdd.Text = "";
            id = 0;
        }

        public void display()
        {
            dataGridView1.DataSource = crd.DisplayData("select * from tbl_vendor");
        }
        private void btnAddVen_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string btnTxt = btn.Text;
            string vName = txtbxVName.Text;
            string vCon = txtbxVCon.Text;
            string vAdd = txtbxVAdd.Text;
            if (vName != "" && vCon != "" && vAdd != "")
            {
                if (btnTxt == "Add")
                {
                    crd.CrudData("insert into tbl_vendor(venName,venCon,venAdd) values('" + vName + "','" + vCon + "','" + vAdd + "')");
                    clearData();
                }
                else if (btnTxt == "Update" && id != 0)
                {
                    crd.CrudData("update tbl_vendor set venName = '"+txtbxVName.Text+"', venCon = '"+txtbxVCon.Text+"', venAdd = '"+txtbxVAdd.Text+"' where vendorId = '"+id+"'");
                    clearData();
                }
                else if (btnTxt == "Delete" && id != 0)
                {
                    crd.CrudData("delete tbl_vendor where vendorId = '" + id + "'");
                    clearData();
                }
                display();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtbxVName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtbxVCon.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtbxVAdd.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }
    }
}
