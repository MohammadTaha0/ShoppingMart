using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        public GenerateBills()
        {
            InitializeComponent();

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
            //picCamera.Image = (Bitmap)eventArgs.Frame.Clone();
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

        string barLists = "0";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //barLists += "," + textBox1.Text;
            //MessageBox.Show(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = barLists.ToList();
        }

        private void GenerateBills_Load(object sender, EventArgs e)
        {

        }
        List<List<string>> list = new List<List<string>>()
        {     new List<string>() { "+923432959411", "1" }
                };

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Crud cd = new Crud();

                int qty = 1;
                if (cd.DisplayData("select product_name from tbl_products where barcode = '" + txtbxbar.Text + "'").Rows.Count == 0)
                {
                    MessageBox.Show("This Barcode Does Not Exist! At Our DataBase!");
                }
                else
                {
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
                            else if (list[n][0] == "+923432959411")
                            {
                                list.RemoveAt(n);
                            }

                        }
                    }
                    list.Add(new List<string>() { txtbxbar.Text, qty.ToString() });

                    label1.Text = "";
                    label2.Text = "";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    for (int x = 0; x < list.Count; x++)
                    {
                        for (int y = 0; y < 1; y++)
                        {
                            label1.Text += list[x][y].ToString() + "\n";
                            if (Convert.ToInt16(cd.DisplayData("select quan from tbl_products where barcode = '" + list[x][y] + "'").Rows[0]["quan"]) >= Convert.ToInt16(list[x][y + 1]))
                            {
                                qty = qty;
                            }
                            else
                            {
                                qty--;
                                list[x][y + 1] = (Convert.ToInt32(list[x][y + 1]) - 1).ToString();
                                MessageBox.Show("Don't have required quantity");
                            }
                            label2.Text += list[x][y + 1].ToString() + "\n";
                            label3.Text += cd.DisplayData("select product_name from tbl_products where barcode = '" + list[x][y] + "'").Rows[0]["product_name"].ToString() + "\n";
                            label4.Text += (Convert.ToInt32(cd.DisplayData("select price from tbl_products where barcode = '" + list[x][y] + "'").Rows[0]["price"]) * Convert.ToInt32(list[x][y + 1])).ToString() + "\n";
                        }
                    }
                }
                //dataGridView1.DataSource = list;
            }
            if (e.KeyChar == 13)
            {
                //lst.Add(txtbxbar.Text);
                //for (int i = 0; i < lst.Count; i++)
                //{
                //    label6.Text += txtbxbar.Text + "\n";
                //}
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
