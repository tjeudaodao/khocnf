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
using System.Diagnostics;

namespace khocnf
{
    public partial class Form1 : Form
    {
        static int tabnao = 1;
        bool chay = true;
        kiemhang uskiemhang = new kiemhang();
        chuyenhang uschuyenhang = new chuyenhang();
        timkiem ustimkiem = new timkiem();
        Thread tuCapnhat;
        string duongdanAPP = Application.StartupPath;

        Thread closecheckupdate;

        public Form1()
        {
            InitializeComponent();

            closecheckupdate = new Thread(CloseCheckupdate);
            closecheckupdate.IsBackground = true;
            closecheckupdate.Start();

            tabnao = 1;
            tuCapnhat = new Thread(hamkiemtra);
            tuCapnhat.IsBackground = true;
            tuCapnhat.Start();
        }
        public void CloseCheckupdate()
        {
            Process[] GetPArry = Process.GetProcesses();
            foreach (Process testProcess in GetPArry)
            {
                string ProcessName = testProcess.ProcessName;
                if (ProcessName.CompareTo("checkUpdate") == 0)
                {
                    testProcess.Kill();
                    return;
                }

            }
        }

        protected override CreateParams CreateParams // hieu ung shadow cho form
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        void hamkiemtra()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    string luungayData = layngayClient();
                    var con = ketnoimysql.Khoitao();
                    string ngaylay = con.LayNgaycapnhat();
                    
                    lbNgayCapnhat.Invoke(new MethodInvoker(delegate ()
                    {
                        if (luungayData == null)
                        {
                            lbNgayCapnhat.Text = "-";
                        }
                        lbNgayCapnhat.Text = luungayData;
                    }));
                    if (luungayData != ngaylay)
                    {
                        pbANHNEN.Invoke(new MethodInvoker(delegate ()
                        {
                            pbANHNEN.Image = Properties.Resources.down;
                        }));

                        btnUPDATE.Invoke(new MethodInvoker(delegate ()
                        {
                            btnUPDATE.Image = Properties.Resources.update;
                        }));
                    }
                    Thread.Sleep(300000);
                }
                

                //}
            }
            catch (Exception)
            {

                hamtao.notifi_hts("Có lỗi cập nhật");
            }
            
        }
        public string layngayClient()
        {
            var consqlite = ketnoi.Khoitao();
            return consqlite.layngayData();
        }
        void hamKiemtay()
        {
            try
            {
                var con = ketnoimysql.Khoitao();
                var consqlite = ketnoi.Khoitao();
                ftp ftpClient = new ftp(@"ftp://27.72.29.28/", "hts", "hoanglaota");
                string ngaylay = con.LayNgaycapnhat();
                string ngayclient = consqlite.layngayData();
                Console.WriteLine(ngaylay + "-" + ngayclient);

                if (ngaylay != ngayclient)
                {
                    btnUPDATE.Invoke(new MethodInvoker(delegate ()
                    {
                        btnUPDATE.Image = Properties.Resources.update;
                        //if (File.Exists(Application.StartupPath + @"\databarcode.db"))
                        //{
                        //    File.Delete(Application.StartupPath + @"\databarcode.db");
                        //}
                        ftpClient.download("app/luutru/databarcode.db", Application.StartupPath + @"\databarcode.db");


                        btnUPDATE.Image = Properties.Resources.hetupdate;
                        
                    }));
                    lbNgayCapnhat.Invoke(new MethodInvoker(delegate ()
                    {
                        lbNgayCapnhat.Text = ngaylay;
                    }));
                    pbANHNEN.Invoke(new MethodInvoker(delegate ()
                    {
                        pbANHNEN.Image = Properties.Resources.totoro1;
                    }));
                    consqlite.updatengayData(ngaylay);
                }
            }
            catch (Exception)
            {

                return;
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

       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            uskiemhang.Location = new Point(190, 30);
            uskiemhang.Name = "tabkiemhang";
            uskiemhang.Dock = DockStyle.Fill;
            this.panMain.Controls.Add(uskiemhang);
            //this.Controls.Add(uskiemhang);


            uschuyenhang.Location = new Point(190, 30);
            uschuyenhang.Name = "tabchuyenhang";
            uschuyenhang.Dock = DockStyle.Fill;
            this.panMain.Controls.Add(uschuyenhang);
            //this.Controls.Add(uschuyenhang);

            ustimkiem.Location = new Point(190, 30);
            ustimkiem.Name = "tabtimkiem";
            ustimkiem.Dock = DockStyle.Fill;
            this.panMain.Controls.Add(ustimkiem);
           // this.Controls.Add(ustimkiem);

            uschuyenhang.Hide();
            ustimkiem.Hide();

            xulyThugon(true);
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
            else if (keyData == Keys.Down)
            {
                if (tabnao == 1)
                {
                    uskiemhang.chonhangcuoi2();
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



        private bool thugonhaykhong = true;
        void xulyThugon(bool thugon)
        {
            if (thugon)
            {
                pantieude.Width = 80;
                xulyBTN(btnkiemhang, "", thugon);
                xulyBTN(btnchuyenhang, "", thugon);
                xulyBTN(btntimkiem, "", thugon);
                xulyBTN(btnUPDATE, "", thugon);
                xulyBTN(btnAMTHANH, "", thugon);
                xulyBTN(btn_Backup, "", thugon);
                xulyBTN(btn_restore, "", thugon);
                btnTHUGON.Width = 50;
                btnTHUGON.Image = Properties.Resources.menu_mau;
                pbANHNEN.Width = 78;
            }
            else
            {
                pantieude.Width = 190;
                xulyBTN(btnkiemhang, "Kiểm hàng", thugon);
                xulyBTN(btnchuyenhang, "Chuyển hàng", thugon);
                xulyBTN(btntimkiem, "Tìm kiếm", thugon);
                xulyBTN(btnUPDATE, "", thugon);
                xulyBTN(btnAMTHANH, "", thugon);
                xulyBTN(btn_Backup, "", thugon);
                xulyBTN(btn_restore, "", thugon);
                btnTHUGON.Width = 150;
                btnTHUGON.Image = Properties.Resources.menu_goc;
                pbANHNEN.Width = 180;
            }
        }
        void xulyBTN(Button btn,string noidung, bool thu)
        {
            if (thu)
            {
                btn.Width = 50;
                btn.ImageAlign = ContentAlignment.MiddleCenter;
                btn.Text = noidung;
            }
            else
            {
                btn.Width = 150;
                btn.ImageAlign = ContentAlignment.TopCenter;
                btn.Text = noidung;
            }
        }
        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                
                Thread kiemtra = new Thread(hamKiemtay);
                kiemtra.IsBackground = true;
                
                    kiemtra.Start();

                   
                
            }
            catch (Exception)
            {

                hamtao.notifi_hts("Có vấn đề, xem lại");
            }
        }

        private void btnAMTHANH_Click(object sender, EventArgs e)
        {
            chay = !chay;
            amthanh.amluong(chay);
            if (chay)
            {
                btnAMTHANH.Image = Properties.Resources.spacker;
            }
            else
            {
                btnAMTHANH.Image = Properties.Resources.mute;
            }
        }

        private void btnTHUGON_Click(object sender, EventArgs e)
        {
            thugonhaykhong = !thugonhaykhong;
            xulyThugon(thugonhaykhong);
        }

        private void pantieude_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            DialogResult backup = MessageBox.Show("Backup dữ liệu. Chú ý: Nếu nhấn 'OK' sẽ lưu dữ liệu cũ ra 1 file mới và file dữ liệu hiện tại sẽ bi 'XÓA'.!\nKhông cần lưu thường xuyên (có thể sau 3 đến 6 tháng lưu 1 lần, tùy vào trường hợp có kiểm hàng và chuyển hàng nhiều hay không)", "CAUTION: ĐỌC KĨ HƯỚNG DẪN TRƯỚC KHI DÙNG", MessageBoxButtons.OKCancel);
            if (backup == DialogResult.OK)
            {
                if (!Directory.Exists(duongdanAPP + @"\backup"))
                {
                    Directory.CreateDirectory(duongdanAPP + @"\backup");
                }
                Random rd = new Random();

                string tenfilenew = "data_backup_" + DateTime.Now.ToString("dd-MM-yyy_HH-mm") + "_" + rd.Next(1, 1000);
                if (File.Exists(duongdanAPP+@"\backup\"+tenfilenew))
                {
                    tenfilenew += "_1";
                }
                File.Copy(duongdanAPP + @"\data.db", duongdanAPP + @"\backup\" + tenfilenew +".db");
                var con = ketnoi.Khoitao();
                con.xoatatca_backup();
                MessageBox.Show("Backup thành công\nFile backup được lưu trong thư mục backup của Folder chứa chương trình.\nTrong trường hợp muốn lấy lại hoặc xem lại dữ liệu cũ thì dùng chức năng 'KHÔI PHỤC DỮ LIỆU' bên dưới", "Backup Done !");
            }
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            DialogResult restore = MessageBox.Show("Nên khởi động lại chương trình trước khi khôi phục để tránh bị lỗi (nhớ lưu lại công việc đang làm)\nKhôi phục lại dữ liệu từ các lần lưu trước.\nNếu nhấn 'OK' sẽ lưu tạm 1 bản tạm thời dùng trong trường hợp lỗi có thể khôi phục lại", "CAUTION: ĐỌC KĨ HƯỚNG DẪN TRƯỚC KHI DÙNG", MessageBoxButtons.OKCancel);
            if (restore == DialogResult.OK)
            {
                if (!Directory.Exists(duongdanAPP + @"\backup"))
                {
                    Directory.CreateDirectory(duongdanAPP + @"\backup");
                }
                OpenFileDialog opendig = new OpenFileDialog();
                opendig.Filter = "File sqlite (*.db)|*.db";
                opendig.Multiselect = false;
                opendig.InitialDirectory = duongdanAPP + @"\backup";
                if (opendig.ShowDialog() == DialogResult.OK)
                {
                    
                    Random rd = new Random();

                    string tenfilenew = "data_backup_" + DateTime.Now.ToString("dd-MM-yyy_HH-mm") + "_" + rd.Next(1, 1000);
                    if (File.Exists(duongdanAPP + @"\backup\" + tenfilenew))
                    {
                        tenfilenew += "_1";
                    }
                    File.Copy(duongdanAPP + @"\data.db", duongdanAPP + @"\backup\" + tenfilenew + ".db");
                    var con = ketnoi.Khoitao();
                    con.xoatatca_backup();
                    
                    File.Copy(opendig.FileName, duongdanAPP + @"\data.db",true);
                    MessageBox.Show("Khôi phục hoàn tất");
                }
            }
        }
    }
}
