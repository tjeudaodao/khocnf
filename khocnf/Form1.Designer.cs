namespace khocnf
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pantieude = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbcapnhat = new System.Windows.Forms.PictureBox();
            this.pbtatmoamthanh = new System.Windows.Forms.PictureBox();
            this.panthaydoi = new System.Windows.Forms.Panel();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnchuyenhang = new System.Windows.Forms.Button();
            this.btnkiemhang = new System.Windows.Forms.Button();
            this.pbminimize = new System.Windows.Forms.PictureBox();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.pantieude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcapnhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtatmoamthanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbminimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            this.SuspendLayout();
            // 
            // pantieude
            // 
            this.pantieude.BackColor = System.Drawing.Color.DimGray;
            this.pantieude.Controls.Add(this.pictureBox1);
            this.pantieude.Controls.Add(this.pbcapnhat);
            this.pantieude.Controls.Add(this.pbtatmoamthanh);
            this.pantieude.Controls.Add(this.panthaydoi);
            this.pantieude.Controls.Add(this.btntimkiem);
            this.pantieude.Controls.Add(this.btnchuyenhang);
            this.pantieude.Controls.Add(this.btnkiemhang);
            this.pantieude.Dock = System.Windows.Forms.DockStyle.Left;
            this.pantieude.Location = new System.Drawing.Point(0, 0);
            this.pantieude.Name = "pantieude";
            this.pantieude.Size = new System.Drawing.Size(190, 720);
            this.pantieude.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 622);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pbcapnhat
            // 
            this.pbcapnhat.Image = ((System.Drawing.Image)(resources.GetObject("pbcapnhat.Image")));
            this.pbcapnhat.Location = new System.Drawing.Point(48, 559);
            this.pbcapnhat.Name = "pbcapnhat";
            this.pbcapnhat.Size = new System.Drawing.Size(32, 31);
            this.pbcapnhat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbcapnhat.TabIndex = 2;
            this.pbcapnhat.TabStop = false;
            this.pbcapnhat.Click += new System.EventHandler(this.pbcapnhat_Click);
            // 
            // pbtatmoamthanh
            // 
            this.pbtatmoamthanh.Image = ((System.Drawing.Image)(resources.GetObject("pbtatmoamthanh.Image")));
            this.pbtatmoamthanh.Location = new System.Drawing.Point(132, 559);
            this.pbtatmoamthanh.Name = "pbtatmoamthanh";
            this.pbtatmoamthanh.Size = new System.Drawing.Size(32, 31);
            this.pbtatmoamthanh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbtatmoamthanh.TabIndex = 2;
            this.pbtatmoamthanh.TabStop = false;
            this.pbtatmoamthanh.Click += new System.EventHandler(this.pbtatmoamthanh_Click);
            // 
            // panthaydoi
            // 
            this.panthaydoi.BackColor = System.Drawing.Color.SpringGreen;
            this.panthaydoi.Location = new System.Drawing.Point(7, 73);
            this.panthaydoi.Name = "panthaydoi";
            this.panthaydoi.Size = new System.Drawing.Size(10, 90);
            this.panthaydoi.TabIndex = 1;
            // 
            // btntimkiem
            // 
            this.btntimkiem.BackColor = System.Drawing.Color.DimGray;
            this.btntimkiem.FlatAppearance.BorderSize = 0;
            this.btntimkiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntimkiem.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.ForeColor = System.Drawing.SystemColors.Control;
            this.btntimkiem.Image = ((System.Drawing.Image)(resources.GetObject("btntimkiem.Image")));
            this.btntimkiem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btntimkiem.Location = new System.Drawing.Point(31, 405);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(150, 90);
            this.btntimkiem.TabIndex = 1;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btntimkiem.UseVisualStyleBackColor = false;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnchuyenhang
            // 
            this.btnchuyenhang.BackColor = System.Drawing.Color.DimGray;
            this.btnchuyenhang.FlatAppearance.BorderSize = 0;
            this.btnchuyenhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchuyenhang.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchuyenhang.ForeColor = System.Drawing.SystemColors.Control;
            this.btnchuyenhang.Image = ((System.Drawing.Image)(resources.GetObject("btnchuyenhang.Image")));
            this.btnchuyenhang.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnchuyenhang.Location = new System.Drawing.Point(31, 241);
            this.btnchuyenhang.Name = "btnchuyenhang";
            this.btnchuyenhang.Size = new System.Drawing.Size(150, 90);
            this.btnchuyenhang.TabIndex = 1;
            this.btnchuyenhang.Text = "Chuyển hàng";
            this.btnchuyenhang.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnchuyenhang.UseVisualStyleBackColor = false;
            this.btnchuyenhang.Click += new System.EventHandler(this.btnchuyenhang_Click);
            // 
            // btnkiemhang
            // 
            this.btnkiemhang.BackColor = System.Drawing.Color.DimGray;
            this.btnkiemhang.FlatAppearance.BorderSize = 0;
            this.btnkiemhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkiemhang.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnkiemhang.ForeColor = System.Drawing.SystemColors.Control;
            this.btnkiemhang.Image = ((System.Drawing.Image)(resources.GetObject("btnkiemhang.Image")));
            this.btnkiemhang.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnkiemhang.Location = new System.Drawing.Point(31, 73);
            this.btnkiemhang.Name = "btnkiemhang";
            this.btnkiemhang.Size = new System.Drawing.Size(150, 90);
            this.btnkiemhang.TabIndex = 1;
            this.btnkiemhang.Text = "Kiểm hàng";
            this.btnkiemhang.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnkiemhang.UseVisualStyleBackColor = false;
            this.btnkiemhang.Click += new System.EventHandler(this.btnkiemhang_Click);
            // 
            // pbminimize
            // 
            this.pbminimize.Image = ((System.Drawing.Image)(resources.GetObject("pbminimize.Image")));
            this.pbminimize.Location = new System.Drawing.Point(1286, 0);
            this.pbminimize.Name = "pbminimize";
            this.pbminimize.Size = new System.Drawing.Size(30, 30);
            this.pbminimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbminimize.TabIndex = 1;
            this.pbminimize.TabStop = false;
            this.pbminimize.Click += new System.EventHandler(this.pbminimize_Click);
            // 
            // pbclose
            // 
            this.pbclose.Image = ((System.Drawing.Image)(resources.GetObject("pbclose.Image")));
            this.pbclose.Location = new System.Drawing.Point(1326, 0);
            this.pbclose.Name = "pbclose";
            this.pbclose.Size = new System.Drawing.Size(30, 30);
            this.pbclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbclose.TabIndex = 1;
            this.pbclose.TabStop = false;
            this.pbclose.Click += new System.EventHandler(this.pbclose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1360, 720);
            this.Controls.Add(this.pbminimize);
            this.Controls.Add(this.pbclose);
            this.Controls.Add(this.pantieude);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pantieude.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcapnhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtatmoamthanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbminimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pantieude;
        private System.Windows.Forms.Button btnkiemhang;
        private System.Windows.Forms.Panel panthaydoi;
        private System.Windows.Forms.Button btnchuyenhang;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.PictureBox pbminimize;
        private System.Windows.Forms.PictureBox pbcapnhat;
        private System.Windows.Forms.PictureBox pbtatmoamthanh;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

