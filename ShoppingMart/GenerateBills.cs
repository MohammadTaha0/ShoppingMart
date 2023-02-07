using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ShoppingMart
{
    public partial class GenerateBills : Form
    {
        Alert alrt = new Alert();
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("Debug\\", "assets\\sounds\\beep.wav"));
        public GenerateBills()
        {
            InitializeComponent();

            txtbxTp.Text = prfo.Select(x => x.price).Sum().ToString();
            ProTotal.Text = prfo.Select(x => x.price).Sum().ToString();
            txtbxQuan.Text = "1";
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                comboBox2.Items.Add(device.Name);
            comboBox2.SelectedIndex = 0;
        }
        IList<ProInfo> prfo = new List<ProInfo>();

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                txtbxbar.Invoke(new MethodInvoker(delegate ()
                {
                    txtbxbar.Text = result.ToString();
                }));
            }
            pictureBox1.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox2.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
            }
            else
            {
                MessageBox.Show("hh");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtbxbar.Text.Length > 0)
            {
                player.Play();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        { }

        private void GenerateBills_Load(object sender, EventArgs e)
        {

        }
        public void GenerateBillData()
        {

            Crud cd = new Crud();
            var req = cd.DisplayData("select * from tbl_products where barcode = '" + txtbxbar.Text + "'");

            int qty = Convert.ToUInt16(txtbxQuan.Text);
            if (cd.DisplayData("select product_name from tbl_products where barcode = '" + txtbxbar.Text + "'").Rows.Count == 0)
            {
                MessageBox.Show("This Barcode Does Not Exist! At Our DataBase!");
            }
            else if (Convert.ToInt32(req.Rows[0]["quan"]) < qty)
            {

                Alert frm = new Alert();
                frm.showAlert("Only " + req.Rows[0]["quan"] + " Qty Available In Stock!", "red");
            }
            else
            {
                int index = prfo.ToList().FindIndex(x => x.brc == txtbxbar.Text);
                if (index != -1)
                {
                    if (Convert.ToInt32(req.Rows[0]["quan"]) < qty + Convert.ToInt32(prfo[index].qty))
                    {
                        Alert frm = new Alert();
                        frm.showAlert("Only " + req.Rows[0]["quan"] + " Qty Available In Stock!", "red");
                    }
                    else
                    {
                        prfo[index].qty += Convert.ToInt32(txtbxQuan.Text);
                        prfo[index].price = Convert.ToInt32(req.Rows[0]["price"]) * Convert.ToInt32(prfo[index].qty);
                    }
                }
                else
                {
                    prfo.Add(new ProInfo { name = req.Rows[0]["product_name"].ToString(), brc = txtbxbar.Text, price = Convert.ToDouble(req.Rows[0]["price"]) * qty, qty = qty });
                }
                dataGridView1.DataSource = prfo.ToList();
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                txtbxbar.Text = "";
                txtbxQuan.Text = "1";
                SumProductsPrice();
            }
        }
        public void SumProductsPrice()
        {
            ProTotal.Text = "" + prfo.Select(x => x.price).Sum() + " Rs";
            txtbxTp.Text = prfo.Select(x => x.price).Sum().ToString();
            dataGridView1.DataSource = prfo.ToList();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                GenerateBillData();
            }
        }

        private void newButtonClick(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbxbar.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtbxQuan.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            if (btn.Text.ToLower() == "update")
            {
                Crud crd = new Crud();
                string barcode = txtbxbar.Text;
                string qty = txtbxQuan.Text;
                var req = crd.DisplayData("select * from tbl_products where barcode = '" + barcode + "'");

                int res = prfo.ToList().FindIndex(x => x.brc == barcode);
                if (res != -1)
                {
                    if (Convert.ToInt16(req.Rows[0]["quan"]) >= Convert.ToInt16(qty))
                    {
                        prfo[res].qty = Convert.ToInt16(qty);
                        prfo[res].price = Convert.ToInt32(req.Rows[0]["price"]) * Convert.ToInt16(qty);
                        dataGridView1.DataSource = prfo.ToList();
                        txtbxbar.Text = "";
                        txtbxQuan.Text = "1";
                        SumProductsPrice();
                    }
                    else
                    {
                        MessageBox.Show("Dont Have Reuired Quantity! Sorry!");
                    }
                }
                else
                {
                    MessageBox.Show("Selection Must Be Unique!!");
                }

            }
            else if (btn.Text.ToLower() == "delete")
            {
                string barcode = txtbxbar.Text;
                string qty = txtbxQuan.Text;

                int res = prfo.ToList().FindIndex(x => x.brc == barcode);
                if (res != -1)
                {
                    prfo.RemoveAt(res);
                    dataGridView1.DataSource = prfo.ToList();
                    txtbxbar.Text = "";
                    txtbxQuan.Text = "1";
                    SumProductsPrice();
                }
            }
            else
            {
                MessageBox.Show("Unknown Button trigger!!");
            }
        }
        int InvMain = 0;
        private void btnGenBill_Click(object sender, EventArgs e)
        {
            double totalPrice = Convert.ToDouble((ProTotal.Text).Replace(" Rs", ""));
            Crud crud = new Crud();
            Random ran = new Random();
            int inv = 0;
            inv = ran.Next(1111111, 9999999);
            InvMain = inv;
            bool check = true;
            while (check)
            {
                if (crud.DisplayData("select invId from tbl_order where invId = " + inv + "").Rows.Count == 0)
                {
                    double tp = Convert.ToDouble(txtbxTp.Text);
                    if (tp == totalPrice)
                    {
                        crud.CrudData("insert into tbl_order(invId,price,paidPrice,status) values(" + inv + "," + totalPrice + "," + tp + ",0)");

                        for (int i = 0; i < prfo.Count(); i++)
                        {
                            crud.CrudData("insert into tbl_inv(invNum,brcId,price,qty) values(" + inv + "," + prfo[i].brc + "," + (prfo[i].price / prfo[i].qty) + "," + prfo[i].qty + ")");
                        }
                        Panel panel = new Panel();
                        this.Controls.Add(panel);
                        Graphics grp = panel.CreateGraphics();
                        Size formSize = this.ClientSize;
                        bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
                        grp = Graphics.FromImage(bitmap);
                        Point panelLocation = PointToScreen(panel.Location);
                        grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
                        printPreviewDialog1.Document = printDocument1; printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                        printPreviewDialog1.ShowDialog();
                        prfo.Clear();
                        txtbxbar.Text = "";
                        txtbxQuan.Text = "1";
                        txtbxTp.Text = "";
                        dataGridView1.DataSource = prfo.ToList();
                    }
                    else
                    {
                        Alert frm = new Alert();
                        frm.showAlert("Please Pay Exact Amount", "red");
                    }

                    break;
                }
                else
                {
                    inv = ran.Next(1111111, 9999999);
                    InvMain = inv;
                }
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Company Name", new Font("Century Gothic", 24, FontStyle.Bold), Brushes.Black, new Point(260, 10));
            e.Graphics.DrawString("Invoice Slip", new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(340, 50));
            e.Graphics.DrawString("Invoice #: " + InvMain.ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(20, 100));

            e.Graphics.DrawString("Barcodes #:", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 140));
            e.Graphics.DrawString("Products Name:", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(250, 140));
            e.Graphics.DrawString("Qty:", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(520, 140));
            e.Graphics.DrawString("Price:", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(650, 140));
            e.Graphics.DrawString("Final Price:", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(750, 140));
            int x = 0;
            for (int i = 0; i < prfo.Count(); i++)
            {
                x += 40;
                e.Graphics.DrawString(prfo[i].brc, new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(20, 140 + x));
                e.Graphics.DrawString(prfo[i].name, new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(250, 140 + x));
                e.Graphics.DrawString(prfo[i].qty.ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(520, 140 + x));
                e.Graphics.DrawString((prfo[i].price / prfo[i].qty).ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(650, 140 + x));
                e.Graphics.DrawString(prfo[i].price.ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(750, 140 + x));
            }
            int z = x + 250;
            e.Graphics.DrawString("Total: ", new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(500, z));
            e.Graphics.DrawString(prfo.Select(y => y.price).Sum().ToString(), new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(750, z));

        }
        private void button5_Click(object sender, EventArgs e)
        {
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

        private void GenerateBills_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
            }
            else
            {
                MessageBox.Show("hh");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginForm lgn = new LoginForm();
            this.Hide();
            lgn.ShowDialog();
            this.Close();
        }
    }
}
