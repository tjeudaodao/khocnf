using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.IO;


namespace khocnf
{
    public partial class Form1 : Form
    {
        static int tabnao = 1;
        bool chay = true;
        kiemhang uskiemhang = new kiemhang();
        chuyenhang uschuyenhang = new chuyenhang();
        timkiem ustimkiem = new timkiem();

        Thread kiemtra;
        public Form1()
        {
            InitializeComponent();
            kiemtra = new Thread(hamkiemtra);
            kiemtra.IsBackground = true;
           
            tabnao = 1;

        }
        
        void hamkiemtra()
        {
            try
            {
                Thread.Sleep(5000);
                var con = ketnoimysql.Khoitao();
                var conn = ketnoi.Khoitao();

                pbcapnhat.Invoke(new MethodInvoker(delegate ()
                {
                    pbcapnhat.Image = Properties.Resources.update;
                    DataTable dt = con.Check();
                    conn.chenvaoDATA(dt);

                    pbcapnhat.Image = Properties.Resources.hetupdate;
                }));




            }
            catch (Exception)
            {

                hamtao.notifi_hts("Có lỗi cập nhật");
            }
            
        }
        

        private void btnchuyenhang_Click(object sender, EventArgs e)
        {
            panthaydoi.Top = btnchuyenhang.Top;
            panthaydoi.BackColor = Color.RoyalBlue;
            btnchuyenhang.BackColor = Color.Gray;
            btnkiemhang.BackColor = Color.DimGray;
            btntimkiem.BackColor = Color.DimGray;

            uschuyenhang.Show();
            uschuyenhang.BringToFront();
            tabnao = 2;
        }

        private void btnkiemhang_Click(object sender, EventArgs e)
        {
            panthaydoi.Top = btnkiemhang.Top;
            panthaydoi.BackColor = Color.SpringGreen;
            btnkiemhang.BackColor = Color.Gray;
            btnchuyenhang.BackColor = Color.DimGray;
            btntimkiem.BackColor = Color.DimGray;

            uskiemhang.Show();
            uskiemhang.BringToFront();
            tabnao = 1;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            panthaydoi.Top = btntimkiem.Top;
            panthaydoi.BackColor = Color.OrangeRed;
            btntimkiem.BackColor = Color.Gray;
            btnchuyenhang.BackColor = Color.DimGray;
            btnkiemhang.BackColor = Color.DimGray;
            
            ustimkiem.Show();
            ustimkiem.BringToFront();
            tabnao = 3;
        }

        private void pbminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
            var dulieu = ketnoi.Khoitao();
            dulieu.savevaobangkiemhang();
            dulieu.xoabangtam2();
        }

        private void pbtatmoamthanh_Click(object sender, EventArgs e)
        {
            chay = !chay;
            amthanh.amluong(chay);
            if (chay)
            {
                pbtatmoamthanh.Image = Properties.Resources.spacker;
            }
            else
            {
                pbtatmoamthanh.Image = Properties.Resources.mute;
            }
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            uskiemhang.Location = new Point(190, 30);
            uskiemhang.Name = "tabkiemhang";
            this.Controls.Add(uskiemhang);

            uschuyenhang.Location = new Point(190, 30);
            uschuyenhang.Name = "tabchuyenhang";
            this.Controls.Add(uschuyenhang);

            ustimkiem.Location = new Point(190, 30);
            ustimkiem.Name = "tabtimkiem";
            this.Controls.Add(ustimkiem);

            uschuyenhang.Hide();
            ustimkiem.Hide();
            
        }

        #region xu ly su kien ban phim 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                if (uskiemhang.pbdunglai.Visible == true)
                {
                   
                    uskiemhang.pbdunglaidi_Click(uskiemhang.pbdunglai, new KeyEventArgs(keyData));
                }
                else if (uschuyenhang.pbdunglai.Visible == true)
                {
                    uschuyenhang.pbdunglaidi_Click(uschuyenhang.pbdunglai, new KeyEventArgs(keyData));
                }
            }
            
            else if (keyData == Keys.Delete)
            {
                if (tabnao == 2)
                {
                    
                        uschuyenhang.chonhangcuoi();
                        uschuyenhang.pbdelete_Click(uschuyenhang.pbxoa, new KeyEventArgs(keyData));
                    
                }
                else if (tabnao == 1)
                {
                    
                        uskiemhang.chonhangcuoi();
                        uskiemhang.pbdelete_Click(uskiemhang.pbxoa, new KeyEventArgs(keyData));
                   
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void pbcapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!kiemtra.IsAlive)
                {
                    kiemtra.Start();
                }
            }
            catch (Exception)
            {

                hamtao.notifi_hts("Có vấn đề, xem lại");
            }
            
        }
        
    }
}
