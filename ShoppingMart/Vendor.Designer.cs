namespace ShoppingMart
{
    partial class Vendor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbxVName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxVAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbxVCon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddVen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.manageProduct = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbxVName
            // 
            this.txtbxVName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxVName.Location = new System.Drawing.Point(91, 76);
            this.txtbxVName.Name = "txtbxVName";
            this.txtbxVName.Size = new System.Drawing.Size(291, 27);
            this.txtbxVName.TabIndex = 1;
            this.txtbxVName.TextChanged += new System.EventHandler(this.txtbxVName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtbxVAdd
            // 
            this.txtbxVAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxVAdd.Location = new System.Drawing.Point(482, 78);
            this.txtbxVAdd.Name = "txtbxVAdd";
            this.txtbxVAdd.Size = new System.Drawing.Size(291, 27);
            this.txtbxVAdd.TabIndex = 2;
            this.txtbxVAdd.TextChanged += new System.EventHandler(this.txtbxVAdd_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtbxVCon
            // 
            this.txtbxVCon.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxVCon.Location = new System.Drawing.Point(91, 122);
            this.txtbxVCon.Name = "txtbxVCon";
            this.txtbxVCon.Size = new System.Drawing.Size(291, 27);
            this.txtbxVCon.TabIndex = 3;
            this.txtbxVCon.TextChanged += new System.EventHandler(this.txtbxVCon_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Contact:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnAddVen
            // 
            this.btnAddVen.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddVen.FlatAppearance.BorderSize = 0;
            this.btnAddVen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVen.Location = new System.Drawing.Point(472, 119);
            this.btnAddVen.Name = "btnAddVen";
            this.btnAddVen.Size = new System.Drawing.Size(93, 30);
            this.btnAddVen.TabIndex = 4;
            this.btnAddVen.Text = "Add";
            this.btnAddVen.UseVisualStyleBackColor = false;
            this.btnAddVen.Click += new System.EventHandler(this.btnAddVen_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(575, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnAddVen_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(677, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnAddVen_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 243);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(783, 195);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(242, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 44);
            this.label4.TabIndex = 4;
            this.label4.Text = "Vendor Details";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Red;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(156, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.MinimumSize = new System.Drawing.Size(150, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 40);
            this.label8.TabIndex = 18;
            this.label8.Text = "Logout";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // manageProduct
            // 
            this.manageProduct.AutoSize = true;
            this.manageProduct.BackColor = System.Drawing.Color.RoyalBlue;
            this.manageProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.manageProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manageProduct.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageProduct.ForeColor = System.Drawing.Color.White;
            this.manageProduct.Location = new System.Drawing.Point(4, 9);
            this.manageProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.manageProduct.MinimumSize = new System.Drawing.Size(150, 40);
            this.manageProduct.Name = "manageProduct";
            this.manageProduct.Size = new System.Drawing.Size(150, 40);
            this.manageProduct.TabIndex = 17;
            this.manageProduct.Text = "Back";
            this.manageProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.manageProduct.Click += new System.EventHandler(this.manageProduct_Click);
            // 
            // Vendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.manageProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddVen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbxVCon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxVAdd);
            this.Controls.Add(this.txtbxVName);
            this.Name = "Vendor";
            this.Text = "Vendor";
            this.Load += new System.EventHandler(this.Vendor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxVName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxVAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxVCon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddVen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label manageProduct;
    }
}