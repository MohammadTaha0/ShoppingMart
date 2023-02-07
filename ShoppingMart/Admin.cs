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

            todaySale.Text = "Today | " + cd.DisplayData("select * from tbl_order where cast(date as Date) = cast(getdate() as Date)").Rows.Count.ToString();

            TotalSale.Text = "Total | " + cd.DisplayData("select orderId from tbl_order").Rows.Count.ToString();

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

        private void btnGnReport_Click(object sender, EventArgs e)
        {
            string start = dtStart.Value.ToString("yyyy-MM-dd");
            string end = dtEnd.Value.ToString("yyyy-MM-dd");
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();

        }
        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           DataTable dt = cd.DisplayData("select orderId,invId,paidPrice,date from tbl_order where status = 0 and cast(date as Date) Between cast('"+dtStart.Value.ToString("yyyy-MM-dd") + "' as Date) and cast('"+dtEnd.Value.ToString("yyyy-MM-dd") + "' as Date)");

            e.Graphics.DrawString("Company Name", new Font("Century Gothic", 24, FontStyle.Bold), Brushes.Black, new Point(260, 10));
            e.Graphics.DrawString("Report", new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(340, 70));
            e.Graphics.DrawString("From: " + dtStart.Value.ToString("yyyy-MM-dd"), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(20, 100));
            e.Graphics.DrawString("To: " + dtStart.Value.ToString("yyyy-MM-dd"), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(20, 130));

            e.Graphics.DrawString("Order #:", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 170));
            e.Graphics.DrawString("Invoice #:", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(250, 170));
            e.Graphics.DrawString("Price:", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(520, 170));
            e.Graphics.DrawString("Date:", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(650, 170));
            int x = 0;
            int sum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x += 40;
                sum += Convert.ToInt32(dt.Rows[i][2].ToString());
                e.Graphics.DrawString(dt.Rows[i][0].ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(20, 170 + x));
                e.Graphics.DrawString(dt.Rows[i][1].ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(250, 170 + x));
                e.Graphics.DrawString(dt.Rows[i][2].ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(520, 170 + x));
                e.Graphics.DrawString(dt.Rows[i][3].ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(650, 170 + x));
            }
            int z = x + 250;
            e.Graphics.DrawString("Total: ", new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(500, z));
            e.Graphics.DrawString(sum.ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(750, z));
        }

        private void label5_Click(object sender, EventArgs e)
        {
            GenerateBills gen = new GenerateBills();
            this.Hide();
            gen.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            User user = new User();
            this.Hide();
            user.ShowDialog();
            this.Close();
        }
    }
   
}
