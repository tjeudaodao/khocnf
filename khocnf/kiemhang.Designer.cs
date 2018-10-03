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
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbXoaNhap = new System.Windows.Forms.PictureBox();
            this.panKiemhang = new System.Windows.Forms.Panel();
            this.lbthongbao = new System.Windows.Forms.Label();
            this.toggleMahang = new khocnf.nuttoggle();
            ((System.ComponentModel.ISupportInitialize)(this.datag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdunglaidi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsave)).BeginInit();
            this.grbthongtindon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbXoaNhap)).BeginInit();
            this.panKiemhang.SuspendLayout();
            this.SuspendLayout();
            // 
            // datag1
            // 
            this.datag1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datag1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.datag1.BackgroundColor = System.Drawing.Color.White;
            this.datag1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datag1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datag1.Location = new System.Drawing.Point(22, 311);
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
            this.label1.Location = new System.Drawing.Point(19, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số phiếu :";
            // 
            // txtsophieu
            // 
            this.txtsophieu.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsophieu.Location = new System.Drawing.Point(165, 13);
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
            this.label2.Location = new System.Drawing.Point(19, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scan barcode";
            // 
            // txtbarcode
            // 
            this.txtbarcode.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbarcode.Location = new System.Drawing.Point(165, 56);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(265, 26);
            this.txtbarcode.TabIndex = 2;
            this.txtbarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbarcode_KeyDown);
            // 
            // lbmasp
            // 
            this.lbmasp.BackColor = System.Drawing.Color.White;
            this.lbmasp.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmasp.ForeColor = System.Drawing.Color.DimGray;
            this.lbmasp.Location = new System.Drawing.Point(23, 104);
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
            this.txtsoluong.Location = new System.Drawing.Point(165, 183);
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
            this.lbtongsoluong.Location = new System.Drawing.Point(10, 13);
            this.lbtongsoluong.Name = "lbtongsoluong";
            this.lbtongsoluong.Size = new System.Drawing.Size(689, 217);
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
            this.datag2.Location = new System.Drawing.Point(4, 312);
            this.datag2.Name = "datag2";
            this.datag2.RowHeadersVisible = false;
            this.datag2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datag2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datag2.Size = new System.Drawing.Size(699, 343);
            this.datag2.TabIndex = 0;
            // 
            // btnsosanh
            // 
            this.btnsosanh.BackColor = System.Drawing.Color.SpringGreen;
            this.btnsosanh.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsosanh.ForeColor = System.Drawing.Color.DimGray;
            this.btnsosanh.Location = new System.Drawing.Point(328, 250);
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
            this.lbsoluongdon.Location = new System.Drawing.Point(548, 20);
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
            this.btnbatdaukiemhang.Location = new System.Drawing.Point(22, 179);
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
            this.pictureBox4.Location = new System.Drawing.Point(121, 53);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pbedit
            // 
            this.pbedit.Image = ((System.Drawing.Image)(resources.GetObject("pbedit.Image")));
            this.pbedit.Location = new System.Drawing.Point(84, 253);
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
            this.pbdunglaidi.Location = new System.Drawing.Point(23, 253);
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
            this.pbdelete.Location = new System.Drawing.Point(150, 253);
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
            this.pbsave.Location = new System.Drawing.Point(265, 253);
            this.pbsave.Name = "pbsave";
            this.pbsave.Size = new System.Drawing.Size(42, 38);
            this.pbsave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbsave.TabIndex = 3;
            this.pbsave.TabStop = false;
            this.pbsave.Click += new System.EventHandler(this.pbsave_Click);
            // 
            // grbthongtindon
            // 
            this.grbthongtindon.Controls.Add(this.toggleMahang);
            this.grbthongtindon.Controls.Add(this.lbnoidungdon);
            this.grbthongtindon.Controls.Add(this.lbsophieu);
            this.grbthongtindon.Controls.Add(this.lbsoluongdon);
            this.grbthongtindon.Location = new System.Drawing.Point(6, 233);
            this.grbthongtindon.Name = "grbthongtindon";
            this.grbthongtindon.Size = new System.Drawing.Size(693, 72);
            this.grbthongtindon.TabIndex = 6;
            this.grbthongtindon.TabStop = false;
            this.grbthongtindon.Text = "Mô tả thông tin đơn";
            this.grbthongtindon.Enter += new System.EventHandler(this.grbthongtindon_Enter);
            // 
            // lbnoidungdon
            // 
            this.lbnoidungdon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbnoidungdon.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnoidungdon.ForeColor = System.Drawing.Color.DimGray;
            this.lbnoidungdon.Location = new System.Drawing.Point(196, 24);
            this.lbnoidungdon.Name = "lbnoidungdon";
            this.lbnoidungdon.Size = new System.Drawing.Size(237, 29);
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
            // pbLoading
            // 
            this.pbLoading.Image = ((System.Drawing.Image)(resources.GetObject("pbLoading.Image")));
            this.pbLoading.Location = new System.Drawing.Point(3, 311);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(707, 354);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 7;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtsophieu);
            this.panel1.Controls.Add(this.datag1);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnbatdaukiemhang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnsosanh);
            this.panel1.Controls.Add(this.lbmasp);
            this.panel1.Controls.Add(this.pbedit);
            this.panel1.Controls.Add(this.txtbarcode);
            this.panel1.Controls.Add(this.pbdunglaidi);
            this.panel1.Controls.Add(this.txtsoluong);
            this.panel1.Controls.Add(this.pbdelete);
            this.panel1.Controls.Add(this.pbXoaNhap);
            this.panel1.Controls.Add(this.pbsave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 700);
            this.panel1.TabIndex = 9;
            // 
            // pbXoaNhap
            // 
            this.pbXoaNhap.Image = ((System.Drawing.Image)(resources.GetObject("pbXoaNhap.Image")));
            this.pbXoaNhap.Location = new System.Drawing.Point(213, 253);
            this.pbXoaNhap.Name = "pbXoaNhap";
            this.pbXoaNhap.Size = new System.Drawing.Size(42, 38);
            this.pbXoaNhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbXoaNhap.TabIndex = 3;
            this.pbXoaNhap.TabStop = false;
            this.pbXoaNhap.Click += new System.EventHandler(this.pbXoaNhap_Click);
            // 
            // panKiemhang
            // 
            this.panKiemhang.Controls.Add(this.pbLoading);
            this.panKiemhang.Controls.Add(this.datag2);
            this.panKiemhang.Controls.Add(this.lbtongsoluong);
            this.panKiemhang.Controls.Add(this.lbthongbao);
            this.panKiemhang.Controls.Add(this.grbthongtindon);
            this.panKiemhang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panKiemhang.Location = new System.Drawing.Point(447, 0);
            this.panKiemhang.Name = "panKiemhang";
            this.panKiemhang.Size = new System.Drawing.Size(713, 700);
            this.panKiemhang.TabIndex = 10;
            // 
            // lbthongbao
            // 
            this.lbthongbao.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthongbao.ForeColor = System.Drawing.Color.SpringGreen;
            this.lbthongbao.Location = new System.Drawing.Point(3, 673);
            this.lbthongbao.Name = "lbthongbao";
            this.lbthongbao.Size = new System.Drawing.Size(707, 19);
            this.lbthongbao.TabIndex = 1;
            this.lbthongbao.Text = "-";
            this.lbthongbao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toggleMahang
            // 
            this.toggleMahang.AutoSize = true;
            this.toggleMahang.BackColor = System.Drawing.Color.White;
            this.toggleMahang.Location = new System.Drawing.Point(439, 22);
            this.toggleMahang.Name = "toggleMahang";
            this.toggleMahang.Padding = new System.Windows.Forms.Padding(6);
            this.toggleMahang.Size = new System.Drawing.Size(90, 31);
            this.toggleMahang.TabIndex = 6;
            this.toggleMahang.Text = "nuttoggle1";
            this.toggleMahang.UseVisualStyleBackColor = false;
            this.toggleMahang.CheckedChanged += new System.EventHandler(this.toggleMahang_CheckedChanged);
            // 
            // kiemhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panKiemhang);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "kiemhang";
            this.Size = new System.Drawing.Size(1160, 700);
            this.Load += new System.EventHandler(this.kiemhang_Load);
            this.Resize += new System.EventHandler(this.kiemhang_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.datag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdunglaidi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsave)).EndInit();
            this.grbthongtindon.ResumeLayout(false);
            this.grbthongtindon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbXoaNhap)).EndInit();
            this.panKiemhang.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panKiemhang;
        private System.Windows.Forms.Label lbthongbao;
        private System.Windows.Forms.PictureBox pbXoaNhap;
        private nuttoggle toggleMahang;
    }
}
