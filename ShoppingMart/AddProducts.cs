using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShoppingMart
{
    public partial class AddProducts : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public static class Login
        {
           public static int userRole = 0;
        }

        Crud cd = new Crud();
        public AddProducts()
        {
            InitializeComponent();

            display();


            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                comboBox2.Items.Add(device.Name);
            comboBox2.SelectedIndex = 0;

        }


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

        public void display()
        {
            comboBox1.Items.Clear();
            dataGridView1.DataSource = cd.DisplayData("select * from tbl_products");
            foreach (DataRow item in cd.DisplayData("select vendorId,venName from tbl_vendor").Rows)
            {

                comboBox1.Items.Add(Convert.ToInt64(item["vendorId"].ToString()) + " " + item["venName"].ToString());
            }
        }

        public void clearData()
        {
            txtbxName.Text = "";
            txtbsPrice.Text = "";
            comboBox1.Text = "";
            txtbxbar.Text = "";
            txtbxQuan.Text = "";
        }
        int id = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            string btnTxt = btn.Text;
            string name = txtbxName.Text;
            string price = txtbsPrice.Text;
            string venId = comboBox1.Text;
            string bar = txtbxbar.Text;
            string quan = txtbxQuan.Text;



            if (name != "" && price != "" && bar != "" && venId != "" && quan != "")
            {
                int vend = (int)Convert.ToInt64(venId.Split(' ')[0]);

                if (btnTxt == "Add")
                {
                    if (cd.DisplayData("select * from tbl_products where barcode = '" + bar + "'").Rows.Count == 0)
                    {
                        cd.CrudData("insert into tbl_products(barcode,product_name,price,venId,quan) values('" + bar + "','" + name + "'," + Convert.ToInt64(price) + "," + vend + ",'" + quan + "')");
                        clearData();
                    }
                    else
                    {
                        MessageBox.Show("This Barcode Number Already Exist!");
                    }
                }
                else if (btnTxt == "Update" && id != 0)
                {
                    if (cd.DisplayData("select * from tbl_products where barcode = '" + bar + "'").Rows.Count == 1)
                    {
                        cd.CrudData("update tbl_products set product_name = '" + txtbxName.Text + "', barcode = '" + txtbxbar.Text + "', price = '" + txtbsPrice.Text + "', venId = '" + comboBox1.Text + "',quan = '" + quan + "' where product_id = '" + id + "'");
                        clearData();
                    }
                    else
                    {
                        MessageBox.Show("This Barcode Number Already Exist!");
                    }
                }
                else if (btnTxt == "Delete" && id != 0)
                {
                    cd.CrudData("delete tbl_products where product_id = '" + id + "'");
                    clearData();
                }
                display();
            }
            else
            {
                MessageBox.Show("Error!");
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtbxbar.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtbxName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtbsPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtbxQuan.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

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
        }

        List<List<string>> list = new List<List<string>>() {
                       new List<string>() { "1989896765656", "1" }
                };
        private void txtbxbar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                int qty = 1;
                for (int n = 0; n < list.Count; n++)
                {
                    for (int m = 0; m < 1; m++)
                    {
                        if (list[n][0] == txtbxbar.Text)
                        {
                            qty = Convert.ToInt16(list[n][1]) + 1;
                            list.RemoveAt(n);
                            break;
                        }

                    }
                }
                list.Add(new List<string>() { txtbxbar.Text, qty.ToString() });

                label6.Text = "";
                for (int x = 0; x < list.Count; x++)
                {
                    for (int y = 0; y < 1; y++)
                    {
                        label6.Text += list[x][y].ToString() + " qty:" + list[x][y + 1].ToString() + "\n";
                    }
                }
            }
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {

        }

        private void txtbxbar_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbsPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbxQuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void manageProduct_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            this.Hide();
            admin.ShowDialog();
            this.Close();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            //GenerateBills gn = new GenerateBills();
            LoginForm lgn = new LoginForm();
            this.Hide();
            lgn.ShowDialog();
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

