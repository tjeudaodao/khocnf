﻿namespace khocnf
{
    partial class chuyenhang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chuyenhang));
            this.grbthongtindon = new System.Windows.Forms.GroupBox();
            this.radioMatong = new System.Windows.Forms.RadioButton();
            this.radioMamau = new System.Windows.Forms.RadioButton();
            this.radioMacdinh = new System.Windows.Forms.RadioButton();
            this.btnlaydata = new System.Windows.Forms.Button();
            this.lbthongtin = new System.Windows.Forms.Label();
            this.btntachdon = new System.Windows.Forms.Button();
            this.lbsoluongdon = new System.Windows.Forms.Label();
            this.btnxuatexcel = new System.Windows.Forms.Button();
            this.btninnhat = new System.Windows.Forms.Button();
            this.btnbatdaukiemhang = new System.Windows.Forms.Button();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.txtnoinhan = new System.Windows.Forms.TextBox();
            this.lbtongsoluong = new System.Windows.Forms.Label();
            this.lbmasp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datag2 = new System.Windows.Forms.DataGridView();
            this.datag1 = new System.Windows.Forms.DataGridView();
            this.datag3 = new System.Windows.Forms.DataGridView();
            this.lbtinhtrang = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbdunglaidi = new System.Windows.Forms.PictureBox();
            this.pbdelete = new System.Windows.Forms.PictureBox();
            this.pbsave = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSLIN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSuaTencuahang = new System.Windows.Forms.Button();
            this.txtTencuahang = new System.Windows.Forms.TextBox();
            this.lbThongbao = new System.Windows.Forms.Label();
            this.pbXoaNhap = new System.Windows.Forms.PictureBox();
            this.nut_checkmathieu = new khocnf.nuttoggle();
            this.label5 = new System.Windows.Forms.Label();
            this.grbthongtindon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datag3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdunglaidi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsave)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbXoaNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // grbthongtindon
            // 
            this.grbthongtindon.Controls.Add(this.radioMatong);
            this.grbthongtindon.Controls.Add(this.radioMamau);
            this.grbthongtindon.Controls.Add(this.radioMacdinh);
            this.grbthongtindon.Controls.Add(this.btnlaydata);
            this.grbthongtindon.Location = new System.Drawing.Point(378, 251);
            this.grbthongtindon.Name = "grbthongtindon";
            this.grbthongtindon.Size = new System.Drawing.Size(495, 65);
            this.grbthongtindon.TabIndex = 23;
            this.grbthongtindon.TabStop = false;
            // 
            // radioMatong
            // 
            this.radioMatong.AutoSize = true;
            this.radioMatong.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMatong.Location = new System.Drawing.Point(237, 27);
            this.radioMatong.Name = "radioMatong";
            this.radioMatong.Size = new System.Drawing.Size(71, 21);
            this.radioMatong.TabIndex = 21;
            this.radioMatong.Text = "Mã tổng";
            this.radioMatong.UseVisualStyleBackColor = true;
            this.radioMatong.CheckedChanged += new System.EventHandler(this.radioMatong_CheckedChanged);
            // 
            // radioMamau
            // 
            this.radioMamau.AutoSize = true;
            this.radioMamau.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMamau.Location = new System.Drawing.Point(125, 27);
            this.radioMamau.Name = "radioMamau";
            this.radioMamau.Size = new System.Drawing.Size(66, 21);
            this.radioMamau.TabIndex = 21;
            this.radioMamau.Text = "Mã màu";
            this.radioMamau.UseVisualStyleBackColor = true;
            this.radioMamau.CheckedChanged += new System.EventHandler(this.radioMamau_CheckedChanged);
            // 
            // radioMacdinh
            // 
            this.radioMacdinh.AutoSize = true;
            this.radioMacdinh.BackColor = System.Drawing.Color.RoyalBlue;
            this.radioMacdinh.Checked = true;
            this.radioMacdinh.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMacdinh.ForeColor = System.Drawing.Color.White;
            this.radioMacdinh.Location = new System.Drawing.Point(18, 27);
            this.radioMacdinh.Name = "radioMacdinh";
            this.radioMacdinh.Size = new System.Drawing.Size(75, 21);
            this.radioMacdinh.TabIndex = 21;
            this.radioMacdinh.TabStop = true;
            this.radioMacdinh.Text = "Mặc định";
            this.radioMacdinh.UseVisualStyleBackColor = false;
            this.radioMacdinh.CheckedChanged += new System.EventHandler(this.radioMacdinh_CheckedChanged);
            // 
            // btnlaydata
            // 
            this.btnlaydata.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnlaydata.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlaydata.ForeColor = System.Drawing.Color.White;
            this.btnlaydata.Location = new System.Drawing.Point(347, 14);
            this.btnlaydata.Name = "btnlaydata";
            this.btnlaydata.Size = new System.Drawing.Size(127, 43);
            this.btnlaydata.TabIndex = 21;
            this.btnlaydata.Text = "Lấy dữ liệu ";
            this.btnlaydata.UseVisualStyleBackColor = false;
            this.btnlaydata.Click += new System.EventHandler(this.btnlaydata_Click);
            // 
            // lbthongtin
            // 
            this.lbthongtin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbthongtin.Font = new System.Drawing.Font("Comic Sans MS", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthongtin.ForeColor = System.Drawing.Color.Crimson;
            this.lbthongtin.Location = new System.Drawing.Point(18, 153);
            this.lbthongtin.Name = "lbthongtin";
            this.lbthongtin.Size = new System.Drawing.Size(219, 53);
            this.lbthongtin.TabIndex = 1;
            this.lbthongtin.Text = "-";
            this.lbthongtin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btntachdon
            // 
            this.btntachdon.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntachdon.ForeColor = System.Drawing.Color.DimGray;
            this.btntachdon.Location = new System.Drawing.Point(16, 209);
            this.btntachdon.Name = "btntachdon";
            this.btntachdon.Size = new System.Drawing.Size(223, 34);
            this.btntachdon.TabIndex = 20;
            this.btntachdon.Text = "Tách đơn";
            this.btntachdon.UseVisualStyleBackColor = true;
            this.btntachdon.Click += new System.EventHandler(this.btntachdon_Click);
            // 
            // lbsoluongdon
            // 
            this.lbsoluongdon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbsoluongdon.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsoluongdon.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbsoluongdon.Location = new System.Drawing.Point(18, 105);
            this.lbsoluongdon.Name = "lbsoluongdon";
            this.lbsoluongdon.Size = new System.Drawing.Size(219, 42);
            this.lbsoluongdon.TabIndex = 1;
            this.lbsoluongdon.Text = "-";
            this.lbsoluongdon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnxuatexcel
            // 
            this.btnxuatexcel.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxuatexcel.ForeColor = System.Drawing.Color.DimGray;
            this.btnxuatexcel.Location = new System.Drawing.Point(16, 247);
            this.btnxuatexcel.Name = "btnxuatexcel";
            this.btnxuatexcel.Size = new System.Drawing.Size(223, 43);
            this.btnxuatexcel.TabIndex = 20;
            this.btnxuatexcel.Text = "Xuất Excel";
            this.btnxuatexcel.UseVisualStyleBackColor = true;
            this.btnxuatexcel.Click += new System.EventHandler(this.btnxuatexcel_Click);
            // 
            // btninnhat
            // 
            this.btninnhat.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninnhat.ForeColor = System.Drawing.Color.DimGray;
            this.btninnhat.Location = new System.Drawing.Point(17, 12);
            this.btninnhat.Name = "btninnhat";
            this.btninnhat.Size = new System.Drawing.Size(150, 34);
            this.btninnhat.TabIndex = 20;
            this.btninnhat.Text = "In nhặt";
            this.btninnhat.UseVisualStyleBackColor = true;
            this.btninnhat.Click += new System.EventHandler(this.btninnhat_Click);
            // 
            // btnbatdaukiemhang
            // 
            this.btnbatdaukiemhang.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnbatdaukiemhang.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbatdaukiemhang.ForeColor = System.Drawing.Color.White;
            this.btnbatdaukiemhang.Location = new System.Drawing.Point(27, 263);
            this.btnbatdaukiemhang.Name = "btnbatdaukiemhang";
            this.btnbatdaukiemhang.Size = new System.Drawing.Size(106, 43);
            this.btnbatdaukiemhang.TabIndex = 21;
            this.btnbatdaukiemhang.Text = "Bắt đầu";
            this.btnbatdaukiemhang.UseVisualStyleBackColor = false;
            this.btnbatdaukiemhang.Click += new System.EventHandler(this.btnbatdaukiemhang_Click);
            // 
            // txtsoluong
            // 
            this.txtsoluong.BackColor = System.Drawing.Color.White;
            this.txtsoluong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsoluong.Enabled = false;
            this.txtsoluong.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoluong.ForeColor = System.Drawing.Color.DimGray;
            this.txtsoluong.Location = new System.Drawing.Point(228, 199);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(127, 28);
            this.txtsoluong.TabIndex = 15;
            this.txtsoluong.Text = "1";
            this.txtsoluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtbarcode
            // 
            this.txtbarcode.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbarcode.Location = new System.Drawing.Point(170, 67);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(185, 26);
            this.txtbarcode.TabIndex = 14;
            this.txtbarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbarcode_KeyDown);
            // 
            // txtnoinhan
            // 
            this.txtnoinhan.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnoinhan.Location = new System.Drawing.Point(170, 24);
            this.txtnoinhan.Name = "txtnoinhan";
            this.txtnoinhan.Size = new System.Drawing.Size(185, 26);
            this.txtnoinhan.TabIndex = 13;
            this.txtnoinhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtnoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsophieu_KeyDown);
            // 
            // lbtongsoluong
            // 
            this.lbtongsoluong.BackColor = System.Drawing.Color.White;
            this.lbtongsoluong.Font = new System.Drawing.Font("Comic Sans MS", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtongsoluong.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbtongsoluong.Location = new System.Drawing.Point(380, 16);
            this.lbtongsoluong.Name = "lbtongsoluong";
            this.lbtongsoluong.Size = new System.Drawing.Size(493, 232);
            this.lbtongsoluong.TabIndex = 12;
            this.lbtongsoluong.Text = "-";
            this.lbtongsoluong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbmasp
            // 
            this.lbmasp.BackColor = System.Drawing.Color.White;
            this.lbmasp.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmasp.ForeColor = System.Drawing.Color.DimGray;
            this.lbmasp.Location = new System.Drawing.Point(28, 115);
            this.lbmasp.Name = "lbmasp";
            this.lbmasp.Size = new System.Drawing.Size(327, 54);
            this.lbmasp.TabIndex = 11;
            this.lbmasp.Text = "Mã sản phẩm";
            this.lbmasp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Scan barcode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nơi nhận :";
            // 
            // datag2
            // 
            this.datag2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datag2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.datag2.BackgroundColor = System.Drawing.Color.White;
            this.datag2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datag2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.datag2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datag2.DefaultCellStyle = dataGridViewCellStyle14;
            this.datag2.Location = new System.Drawing.Point(378, 322);
            this.datag2.Name = "datag2";
            this.datag2.RowHeadersVisible = false;
            this.datag2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datag2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datag2.Size = new System.Drawing.Size(495, 343);
            this.datag2.TabIndex = 8;
            // 
            // datag1
            // 
            this.datag1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datag1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.datag1.BackgroundColor = System.Drawing.Color.White;
            this.datag1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datag1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datag1.Location = new System.Drawing.Point(27, 322);
            this.datag1.MultiSelect = false;
            this.datag1.Name = "datag1";
            this.datag1.RowHeadersVisible = false;
            this.datag1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datag1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datag1.Size = new System.Drawing.Size(328, 343);
            this.datag1.TabIndex = 7;
            this.datag1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datag1_CellClick);
            // 
            // datag3
            // 
            this.datag3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datag3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.datag3.BackgroundColor = System.Drawing.Color.White;
            this.datag3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datag3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.datag3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datag3.DefaultCellStyle = dataGridViewCellStyle16;
            this.datag3.Location = new System.Drawing.Point(11, 322);
            this.datag3.Name = "datag3";
            this.datag3.RowHeadersVisible = false;
            this.datag3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datag3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datag3.Size = new System.Drawing.Size(261, 343);
            this.datag3.TabIndex = 8;
            // 
            // lbtinhtrang
            // 
            this.lbtinhtrang.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbtinhtrang.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtinhtrang.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbtinhtrang.Location = new System.Drawing.Point(28, 194);
            this.lbtinhtrang.Name = "lbtinhtrang";
            this.lbtinhtrang.Size = new System.Drawing.Size(194, 38);
            this.lbtinhtrang.TabIndex = 11;
            this.lbtinhtrang.Text = "-";
            this.lbtinhtrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(126, 64);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 22;
            this.pictureBox4.TabStop = false;
            // 
            // pbdunglaidi
            // 
            this.pbdunglaidi.ErrorImage = null;
            this.pbdunglaidi.Image = ((System.Drawing.Image)(resources.GetObject("pbdunglaidi.Image")));
            this.pbdunglaidi.Location = new System.Drawing.Point(139, 266);
            this.pbdunglaidi.Name = "pbdunglaidi";
            this.pbdunglaidi.Size = new System.Drawing.Size(51, 38);
            this.pbdunglaidi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbdunglaidi.TabIndex = 17;
            this.pbdunglaidi.TabStop = false;
            this.pbdunglaidi.Visible = false;
            this.pbdunglaidi.Click += new System.EventHandler(this.pbdunglaidi_Click);
            // 
            // pbdelete
            // 
            this.pbdelete.Image = ((System.Drawing.Image)(resources.GetObject("pbdelete.Image")));
            this.pbdelete.Location = new System.Drawing.Point(196, 266);
            this.pbdelete.Name = "pbdelete";
            this.pbdelete.Size = new System.Drawing.Size(50, 38);
            this.pbdelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbdelete.TabIndex = 16;
            this.pbdelete.TabStop = false;
            this.pbdelete.Click += new System.EventHandler(this.pbdelete_Click);
            // 
            // pbsave
            // 
            this.pbsave.Image = ((System.Drawing.Image)(resources.GetObject("pbsave.Image")));
            this.pbsave.Location = new System.Drawing.Point(313, 266);
            this.pbsave.Name = "pbsave";
            this.pbsave.Size = new System.Drawing.Size(42, 38);
            this.pbsave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbsave.TabIndex = 19;
            this.pbsave.TabStop = false;
            this.pbsave.Click += new System.EventHandler(this.pbsave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nut_checkmathieu);
            this.groupBox1.Controls.Add(this.txtSLIN);
            this.groupBox1.Controls.Add(this.btntachdon);
            this.groupBox1.Controls.Add(this.lbthongtin);
            this.groupBox1.Controls.Add(this.btnxuatexcel);
            this.groupBox1.Controls.Add(this.lbsoluongdon);
            this.groupBox1.Controls.Add(this.btninnhat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 300);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // txtSLIN
            // 
            this.txtSLIN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSLIN.Font = new System.Drawing.Font("Comic Sans MS", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLIN.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtSLIN.Location = new System.Drawing.Point(171, 15);
            this.txtSLIN.Name = "txtSLIN";
            this.txtSLIN.Size = new System.Drawing.Size(64, 28);
            this.txtSLIN.TabIndex = 23;
            this.txtSLIN.Text = "1";
            this.txtSLIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSLIN.Click += new System.EventHandler(this.txtSLIN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Số lượng cần nhặt";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.datag3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(888, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 700);
            this.panel1.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 673);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tên cửa hàng: ";
            // 
            // btnSuaTencuahang
            // 
            this.btnSuaTencuahang.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaTencuahang.Image")));
            this.btnSuaTencuahang.Location = new System.Drawing.Point(270, 667);
            this.btnSuaTencuahang.Name = "btnSuaTencuahang";
            this.btnSuaTencuahang.Size = new System.Drawing.Size(36, 30);
            this.btnSuaTencuahang.TabIndex = 26;
            this.btnSuaTencuahang.UseVisualStyleBackColor = true;
            this.btnSuaTencuahang.Click += new System.EventHandler(this.btnSuaTencuahang_Click);
            // 
            // txtTencuahang
            // 
            this.txtTencuahang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTencuahang.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTencuahang.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtTencuahang.Location = new System.Drawing.Point(126, 671);
            this.txtTencuahang.Name = "txtTencuahang";
            this.txtTencuahang.Size = new System.Drawing.Size(138, 19);
            this.txtTencuahang.TabIndex = 27;
            this.txtTencuahang.Text = "-";
            this.txtTencuahang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTencuahang.Click += new System.EventHandler(this.txtTencuahang_Click);
            // 
            // lbThongbao
            // 
            this.lbThongbao.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongbao.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbThongbao.Location = new System.Drawing.Point(313, 672);
            this.lbThongbao.Name = "lbThongbao";
            this.lbThongbao.Size = new System.Drawing.Size(569, 19);
            this.lbThongbao.TabIndex = 9;
            this.lbThongbao.Text = "-";
            this.lbThongbao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbXoaNhap
            // 
            this.pbXoaNhap.Image = ((System.Drawing.Image)(resources.GetObject("pbXoaNhap.Image")));
            this.pbXoaNhap.Location = new System.Drawing.Point(258, 266);
            this.pbXoaNhap.Name = "pbXoaNhap";
            this.pbXoaNhap.Size = new System.Drawing.Size(42, 38);
            this.pbXoaNhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbXoaNhap.TabIndex = 19;
            this.pbXoaNhap.TabStop = false;
            this.pbXoaNhap.Click += new System.EventHandler(this.pbXoaNhap_Click);
            // 
            // nut_checkmathieu
            // 
            this.nut_checkmathieu.AutoSize = true;
            this.nut_checkmathieu.Location = new System.Drawing.Point(149, 49);
            this.nut_checkmathieu.Name = "nut_checkmathieu";
            this.nut_checkmathieu.Padding = new System.Windows.Forms.Padding(6);
            this.nut_checkmathieu.Size = new System.Drawing.Size(90, 31);
            this.nut_checkmathieu.TabIndex = 28;
            this.nut_checkmathieu.Text = "nuttoggle1";
            this.nut_checkmathieu.UseVisualStyleBackColor = true;
            this.nut_checkmathieu.CheckedChanged += new System.EventHandler(this.nut_checkmathieu_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Check mã thiếu: ";
            // 
            // chuyenhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtTencuahang);
            this.Controls.Add(this.btnSuaTencuahang);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbthongtindon);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnbatdaukiemhang);
            this.Controls.Add(this.pbdunglaidi);
            this.Controls.Add(this.pbdelete);
            this.Controls.Add(this.pbXoaNhap);
            this.Controls.Add(this.pbsave);
            this.Controls.Add(this.txtsoluong);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.txtnoinhan);
            this.Controls.Add(this.lbtongsoluong);
            this.Controls.Add(this.lbtinhtrang);
            this.Controls.Add(this.lbmasp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbThongbao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datag2);
            this.Controls.Add(this.datag1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "chuyenhang";
            this.Size = new System.Drawing.Size(1170, 700);
            this.Load += new System.EventHandler(this.chuyenhang_Load);
            this.Resize += new System.EventHandler(this.chuyenhang_Resize);
            this.grbthongtindon.ResumeLayout(false);
            this.grbthongtindon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datag3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdunglaidi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsave)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbXoaNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbthongtindon;
        private System.Windows.Forms.Label lbsoluongdon;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnbatdaukiemhang;
        private System.Windows.Forms.Button btnlaydata;
        private System.Windows.Forms.PictureBox pbdunglaidi;
        private System.Windows.Forms.PictureBox pbdelete;
        private System.Windows.Forms.PictureBox pbsave;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.TextBox txtnoinhan;
        private System.Windows.Forms.Label lbtongsoluong;
        private System.Windows.Forms.Label lbmasp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datag2;
        private System.Windows.Forms.DataGridView datag1;
        private System.Windows.Forms.DataGridView datag3;
        private System.Windows.Forms.Button btnxuatexcel;
        private System.Windows.Forms.Button btntachdon;
        private System.Windows.Forms.Button btninnhat;
        private System.Windows.Forms.Label lbtinhtrang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbthongtin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioMatong;
        private System.Windows.Forms.RadioButton radioMamau;
        private System.Windows.Forms.RadioButton radioMacdinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSuaTencuahang;
        private System.Windows.Forms.TextBox txtTencuahang;
        private System.Windows.Forms.Label lbThongbao;
        private System.Windows.Forms.TextBox txtSLIN;
        private System.Windows.Forms.PictureBox pbXoaNhap;
        private nuttoggle nut_checkmathieu;
        private System.Windows.Forms.Label label5;
    }
}
