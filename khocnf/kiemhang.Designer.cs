namespace khocnf
{
    partial class kiemhang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kiemhang));
            this.datag1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsophieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.lbmasp = new System.Windows.Forms.Label();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.lbtongsoluong = new System.Windows.Forms.Label();
            this.datag2 = new System.Windows.Forms.DataGridView();
            this.btnsosanh = new System.Windows.Forms.Button();
            this.lbsoluongdon = new System.Windows.Forms.Label();
            this.btnbatdaukiemhang = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbedit = new System.Windows.Forms.PictureBox();
            this.pbdunglaidi = new System.Windows.Forms.PictureBox();
            this.pbdelete = new System.Windows.Forms.PictureBox();
            this.pbsave = new System.Windows.Forms.PictureBox();
            this.grbthongtindon = new System.Windows.Forms.GroupBox();
            this.lbnoidungdon = new System.Windows.Forms.Label();
            this.lbsophieu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdunglaidi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsave)).BeginInit();
            this.grbthongtindon.SuspendLayout();
            this.SuspendLayout();
            // 
            // datag1
            // 
            this.datag1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datag1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.datag1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.datag1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datag1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datag1.Location = new System.Drawing.Point(22, 319);
            this.datag1.MultiSelect = false;
            this.datag1.Name = "datag1";
            this.datag1.RowHeadersVisible = false;
            this.datag1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datag1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datag1.Size = new System.Drawing.Size(408, 343);
            this.datag1.TabIndex = 0;
            this.datag1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datag1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số phiếu :";
            // 
            // txtsophieu
            // 
            this.txtsophieu.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsophieu.Location = new System.Drawing.Point(165, 21);
            this.txtsophieu.Name = "txtsophieu";
            this.txtsophieu.Size = new System.Drawing.Size(265, 26);
            this.txtsophieu.TabIndex = 2;
            this.txtsophieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsophieu_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scan barcode";
            // 
            // txtbarcode
            // 
            this.txtbarcode.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbarcode.Location = new System.Drawing.Point(165, 64);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(265, 26);
            this.txtbarcode.TabIndex = 2;
            this.txtbarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbarcode_KeyDown);
            // 
            // lbmasp
            // 
            this.lbmasp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbmasp.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmasp.ForeColor = System.Drawing.Color.DimGray;
            this.lbmasp.Location = new System.Drawing.Point(23, 112);
            this.lbmasp.Name = "lbmasp";
            this.lbmasp.Size = new System.Drawing.Size(407, 54);
            this.lbmasp.TabIndex = 1;
            this.lbmasp.Text = "Mã sản phẩm";
            this.lbmasp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtsoluong
            // 
            this.txtsoluong.BackColor = System.Drawing.Color.White;
            this.txtsoluong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsoluong.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoluong.Location = new System.Drawing.Point(165, 191);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(265, 28);
            this.txtsoluong.TabIndex = 2;
            this.txtsoluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsoluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluong_KeyDown);
            // 
            // lbtongsoluong
            // 
            this.lbtongsoluong.BackColor = System.Drawing.Color.White;
            this.lbtongsoluong.Font = new System.Drawing.Font("Comic Sans MS", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtongsoluong.ForeColor = System.Drawing.Color.SpringGreen;
            this.lbtongsoluong.Location = new System.Drawing.Point(475, 13);
            this.lbtongsoluong.Name = "lbtongsoluong";
            this.lbtongsoluong.Size = new System.Drawing.Size(656, 217);
            this.lbtongsoluong.TabIndex = 1;
            this.lbtongsoluong.Text = "-";
            this.lbtongsoluong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datag2
            // 
            this.datag2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datag2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.datag2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.datag2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datag2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datag2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datag2.DefaultCellStyle = dataGridViewCellStyle2;
            this.datag2.Location = new System.Drawing.Point(474, 319);
            this.datag2.Name = "datag2";
            this.datag2.RowHeadersVisible = false;
            this.datag2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datag2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datag2.Size = new System.Drawing.Size(657, 343);
            this.datag2.TabIndex = 0;
            // 
            // btnsosanh
            // 
            this.btnsosanh.BackColor = System.Drawing.Color.SpringGreen;
            this.btnsosanh.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsosanh.ForeColor = System.Drawing.Color.DimGray;
            this.btnsosanh.Location = new System.Drawing.Point(328, 258);
            this.btnsosanh.Name = "btnsosanh";
            this.btnsosanh.Size = new System.Drawing.Size(102, 43);
            this.btnsosanh.TabIndex = 4;
            this.btnsosanh.Text = "So sánh";
            this.btnsosanh.UseVisualStyleBackColor = false;
            this.btnsosanh.Click += new System.EventHandler(this.btnsosanh_Click);
            // 
            // lbsoluongdon
            // 
            this.lbsoluongdon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbsoluongdon.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsoluongdon.ForeColor = System.Drawing.Color.SpringGreen;
            this.lbsoluongdon.Location = new System.Drawing.Point(531, 19);
            this.lbsoluongdon.Name = "lbsoluongdon";
            this.lbsoluongdon.Size = new System.Drawing.Size(107, 38);
            this.lbsoluongdon.TabIndex = 1;
            this.lbsoluongdon.Text = "-";
            this.lbsoluongdon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnbatdaukiemhang
            // 
            this.btnbatdaukiemhang.BackColor = System.Drawing.Color.SpringGreen;
            this.btnbatdaukiemhang.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbatdaukiemhang.ForeColor = System.Drawing.Color.DimGray;
            this.btnbatdaukiemhang.Location = new System.Drawing.Point(22, 187);
            this.btnbatdaukiemhang.Name = "btnbatdaukiemhang";
            this.btnbatdaukiemhang.Size = new System.Drawing.Size(129, 43);
            this.btnbatdaukiemhang.TabIndex = 4;
            this.btnbatdaukiemhang.Text = "Bắt đầu";
            this.btnbatdaukiemhang.UseVisualStyleBackColor = false;
            this.btnbatdaukiemhang.Click += new System.EventHandler(this.btnbatdaukiemhang_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(121, 61);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pbedit
            // 
            this.pbedit.Image = ((System.Drawing.Image)(resources.GetObject("pbedit.Image")));
            this.pbedit.Location = new System.Drawing.Point(90, 261);
            this.pbedit.Name = "pbedit";
            this.pbedit.Size = new System.Drawing.Size(55, 38);
            this.pbedit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbedit.TabIndex = 3;
            this.pbedit.TabStop = false;
            this.pbedit.Click += new System.EventHandler(this.pbedit_Click);
            // 
            // pbdunglaidi
            // 
            this.pbdunglaidi.Image = global::khocnf.Properties.Resources.pausegif;
            this.pbdunglaidi.Location = new System.Drawing.Point(23, 261);
            this.pbdunglaidi.Name = "pbdunglaidi";
            this.pbdunglaidi.Size = new System.Drawing.Size(51, 38);
            this.pbdunglaidi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbdunglaidi.TabIndex = 3;
            this.pbdunglaidi.TabStop = false;
            this.pbdunglaidi.Visible = false;
            this.pbdunglaidi.Click += new System.EventHandler(this.pbdunglaidi_Click);
            // 
            // pbdelete
            // 
            this.pbdelete.Image = ((System.Drawing.Image)(resources.GetObject("pbdelete.Image")));
            this.pbdelete.Location = new System.Drawing.Point(176, 261);
            this.pbdelete.Name = "pbdelete";
            this.pbdelete.Size = new System.Drawing.Size(50, 38);
            this.pbdelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbdelete.TabIndex = 3;
            this.pbdelete.TabStop = false;
            this.pbdelete.Click += new System.EventHandler(this.pbdelete_Click);
            // 
            // pbsave
            // 
            this.pbsave.Image = ((System.Drawing.Image)(resources.GetObject("pbsave.Image")));
            this.pbsave.Location = new System.Drawing.Point(265, 261);
            this.pbsave.Name = "pbsave";
            this.pbsave.Size = new System.Drawing.Size(42, 38);
            this.pbsave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbsave.TabIndex = 3;
            this.pbsave.TabStop = false;
            this.pbsave.Click += new System.EventHandler(this.pbsave_Click);
            // 
            // grbthongtindon
            // 
            this.grbthongtindon.Controls.Add(this.lbnoidungdon);
            this.grbthongtindon.Controls.Add(this.lbsophieu);
            this.grbthongtindon.Controls.Add(this.lbsoluongdon);
            this.grbthongtindon.Location = new System.Drawing.Point(474, 241);
            this.grbthongtindon.Name = "grbthongtindon";
            this.grbthongtindon.Size = new System.Drawing.Size(657, 72);
            this.grbthongtindon.TabIndex = 6;
            this.grbthongtindon.TabStop = false;
            this.grbthongtindon.Text = "Mô tả thông tin đơn";
            // 
            // lbnoidungdon
            // 
            this.lbnoidungdon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbnoidungdon.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnoidungdon.ForeColor = System.Drawing.Color.DimGray;
            this.lbnoidungdon.Location = new System.Drawing.Point(221, 24);
            this.lbnoidungdon.Name = "lbnoidungdon";
            this.lbnoidungdon.Size = new System.Drawing.Size(274, 29);
            this.lbnoidungdon.TabIndex = 1;
            this.lbnoidungdon.Text = "-";
            this.lbnoidungdon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbsophieu
            // 
            this.lbsophieu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbsophieu.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsophieu.ForeColor = System.Drawing.Color.DimGray;
            this.lbsophieu.Location = new System.Drawing.Point(6, 24);
            this.lbsophieu.Name = "lbsophieu";
            this.lbsophieu.Size = new System.Drawing.Size(184, 29);
            this.lbsophieu.TabIndex = 1;
            this.lbsophieu.Text = "-";
            this.lbsophieu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kiemhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grbthongtindon);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnbatdaukiemhang);
            this.Controls.Add(this.btnsosanh);
            this.Controls.Add(this.pbedit);
            this.Controls.Add(this.pbdunglaidi);
            this.Controls.Add(this.pbdelete);
            this.Controls.Add(this.pbsave);
            this.Controls.Add(this.txtsoluong);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.txtsophieu);
            this.Controls.Add(this.lbtongsoluong);
            this.Controls.Add(this.lbmasp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datag2);
            this.Controls.Add(this.datag1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "kiemhang";
            this.Size = new System.Drawing.Size(1160, 680);
            this.Load += new System.EventHandler(this.kiemhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdunglaidi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsave)).EndInit();
            this.grbthongtindon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datag1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsophieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Label lbmasp;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.Label lbtongsoluong;
        private System.Windows.Forms.DataGridView datag2;
        private System.Windows.Forms.PictureBox pbsave;
        private System.Windows.Forms.Button btnsosanh;
        private System.Windows.Forms.PictureBox pbdelete;
        private System.Windows.Forms.PictureBox pbdunglaidi;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbedit;
        private System.Windows.Forms.Label lbsoluongdon;
        private System.Windows.Forms.Button btnbatdaukiemhang;
        private System.Windows.Forms.GroupBox grbthongtindon;
        private System.Windows.Forms.Label lbsophieu;
        private System.Windows.Forms.Label lbnoidungdon;
    }
}
