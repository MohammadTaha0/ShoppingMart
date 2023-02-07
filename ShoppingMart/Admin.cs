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
    public partial class Admin : Form
    {
        Crud cd = new Crud();
        public Admin()
        {
            InitializeComponent();
            
            todaySale.Text = "Today | "+cd.DisplayData("select * from tbl_order where cast(date as Date) = cast(getdate() as Date)").Rows.Count.ToString();

            TotalSale.Text = "Total | "+cd.DisplayData("select orderId from tbl_order").Rows.Count.ToString();

            TotalVendor.Text = "Total | " + cd.DisplayData("select vendorId from tbL_vendor").Rows.Count.ToString();

            todayuser.Text = "Today | " + cd.DisplayData("select id from tbl_register where cast(date as Date) = cast(getdate() as Date)").Rows.Count.ToString();

            totalUser.Text = "Total | " + cd.DisplayData("select id from tbl_register").Rows.Count.ToString();

            totalProducts.Text = "Total | " + cd.DisplayData("select product_id from tbl_products").Rows.Count.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            AddProducts add = new AddProducts();
            this.Hide();
            add.ShowDialog();
            this.Close();
        }

        private void addVendor_Click(object sender, EventArgs e)
        {
            Vendor vendor = new Vendor();
            this.Hide();
            vendor.ShowDialog();
            this.Close();

        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            LoginForm lgn = new LoginForm();
            this.Hide();
            lgn.ShowDialog();
            this.Close();
        }
    }
}
