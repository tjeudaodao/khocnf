using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.Data.SQLite;
using System.Threading;

namespace khocnf
{
    public partial class chuyenhang : UserControl
    {
        static string idrows = "";
        static string ngay = "";
        static string gio = "";
        static bool chinhsizecot = false;
        static bool chinhsuama = false;
        static int kihieumasanpham = 1; // 1 la ma chi tiet ; 2 la ma mau ; 3 la ma tong

        public chuyenhang()
        {
            InitializeComponent();
        }
        // ham ho tro
        public void updatetatca()
        {
            var dulieu = ketnoi.Khoitao();
            dulieu.loadvaodatag1(datag1);
            datag2.DataSource = dulieu.laydulieubangthuathieu(kihieumasanpham);
            datag3.DataSource = dulieu.laydulieubangCOPY();
            lbtongsoluong.Text = dulieu.tongcheckhang();
            lbsoluongdon.Text = dulieu.tongsoluongcannhat("bangtamchuyenhang1");
        }
        public void xuatexcel()
        {
            try
            {
                var dulieu = ketnoi.Khoitao();
                if (datag2.RowCount > 0)
                {
                    hamtao.xuatfile(dulieu.laybangxuatchuyenhang(), lbtongsoluong.Text, txtnoinhan.Text, txtTencuahang.Text);
                    hamtao.taovainfileexcelchuyenhang(dulieu.laybangdein(), lbtongsoluong.Text, txtnoinhan.Text, txtTencuahang.Text);
                    hamtao.notifi_hts("Đường dẫn:'" + hamtao.layduongdan() + "'", 5);
                    lbThongbao.Text = "Đường dẫn: '" + hamtao.layduongdan();
                    return;
                }
                hamtao.notifi_hts("Chưa có gì mà xuất :)");
            }
            catch (Exception)
            {

                return;
            }
        }
        public void lammoitatca()
        {
            try
            {
                datag1.DataSource = null;
                datag1.Refresh();
                datag2.DataSource = null;
                datag2.Refresh();
                txtbarcode.Clear();
                btnbatdaukiemhang.Enabled = true;
                txtbarcode.Enabled = false;
                chinhsizecot = false;
                chinhsuama = false;

                lbtongsoluong.Text = "-";
                lbThongbao.Text = "-";
                lbthongtin.Text = "-";
                lbsoluongdon.Text = "-";
            }
            catch (Exception)
            {

                return;
            }

        }
        public void clearvungnhap()
        {
            txtbarcode.Clear();
        }
        public void capnhatlbthongtin(string masp)
        {
            var dulieu = ketnoi.Khoitao();
            if (kihieumasanpham == 1)
            {
                lbthongtin.Text = dulieu.laysoluongthongtintudon(masp);
            }
            else if (kihieumasanpham == 2)
            {
                masp = masp.Substring(0, 15);
                lbthongtin.Text = dulieu.laysoluongthongtintudon(masp);
            }
            else if (kihieumasanpham == 3)
            {
                masp = masp.Substring(0, 9);
                lbthongtin.Text = dulieu.laysoluongthongtintudon(masp);
            }
        }
        public void KiemtradangDAUVAO()
        {
            string mau = @"\d\w{2}\d{2}[SWAC]\d{3}-\w{2}\d{3}-\w+";
            string mau2 = @"\d\w{2}\d{2}[SWAC]\d{3}";
            string mau1 = @"\d\w{2}\d{2}[SWAC]\d{3}-\w{2}\d{3}";
            if (datag3.RowCount >0)
            {
                string maspgoc = datag3.Rows[1].Cells[0].Value.ToString().Trim();
                if (Regex.IsMatch(maspgoc, mau))
                {
                    kihieumasanpham = 1;
                    radioMacdinh.Checked = true;
                }
                else if (Regex.IsMatch(maspgoc, mau1))
                {
                    kihieumasanpham = 2;
                    radioMamau.Checked = true;
                }
                else if (Regex.IsMatch(maspgoc, mau2))
                {
                    kihieumasanpham = 3;
                    radioMatong.Checked = true;
                }
            }
            else
            {
                kihieumasanpham = 1;
                radioMacdinh.Checked = true;
            }
        }
        public void HamBatDau()
        {
            ngay = DateTime.Now.ToString("dd-MM-yyyy");
            gio = DateTime.Now.ToString("HH:mm");
            txtbarcode.Enabled = true;
            txtbarcode.Focus();
            btnbatdaukiemhang.Enabled = false;
            KiemtradangDAUVAO();
        }
        //
        private void chuyenhang_Load(object sender, EventArgs e)
        {
            txtbarcode.Enabled = false;
            txtnoinhan.Select();
            txtnoinhan.Focus();
            datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 16.0f);
            var con = ketnoi.Khoitao();
            txtTencuahang.Text = con.LayTencuahang();
        }
        private void pbsave_Click(object sender, EventArgs e)
        {
            var dulieu = ketnoi.Khoitao();
            DialogResult hoi = MessageBox.Show("-Nhấn 'YES' để lưu lại đơn đã kiểm và làm mới hoàn toàn\n-Nhấn 'NO' lưu lại đơn nhưng vẫn giữ lại phần 'LẤY DỮ LIỆU'\n-Sau đó Tiếp hay nghỉ thì tùy !", "Chốt", MessageBoxButtons.YesNoCancel);
            if (hoi == DialogResult.Yes)
            {
                try
                {
                    dulieu.savevaobangchuyenhang(ngay, gio);
                    dulieu.xoabangtamchuyenhang();
                    dulieu.xoabangtamchuyenhang1();
                    dulieu.xoabangthuathieu();
                    lammoitatca();
                    datag3.DataSource = null;
                    datag3.Refresh();
                    hamtao.notifi_hts("OK ,Triển chiêu");
                }
                catch (Exception)
                {
                    hamtao.notifi_hts("Có vấn đề - Xem lại");
                }
            }
            else if (hoi == DialogResult.No)
            {
                try
                {
                    dulieu.savevaobangchuyenhang(ngay, gio);
                    dulieu.xoabangtamchuyenhang();
                    dulieu.xoabangthuathieu();
                    lammoitatca();
                    hamtao.notifi_hts("OK ,Triển chiêu");
                }
                catch (Exception)
                {
                    hamtao.notifi_hts("Có vấn đề - Xem lại");
                }
            }
        }

        private void txtsophieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnbatdaukiemhang.Focus();
            }
        }

        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtbarcode.Text))
                {
                    var dulieu = ketnoi.Khoitao();
                    var con = ketnoibarcode.Khoitao();
                    string masp = con.laymasp(txtbarcode.Text);
                    if (masp == null)
                    {
                        amthanh.phatbaoloi();
                        pbdunglaidi.Visible = true;
                        txtbarcode.Enabled = false;
                        btnlaydata.Enabled = false;
                        lbThongbao.Text = "Có lỗi barcode. Ấn dấu cách để tiếp tục";
                    }
                    else
                    {
                        try
                        {
                            lbmasp.Text = masp;
                            string mamau = masp.Substring(0, 15); // 1bs18a001-sk010
                            string matong = masp.Substring(0, 9);
                            dulieu.insertdl1(txtbarcode.Text, masp, "1", ngay, gio, txtnoinhan.Text);
                            dulieu.chenvaobangthuathieu(masp, mamau, matong, kihieumasanpham);
                            if (datag3.RowCount > 1)
                            {
                                dulieu.baoamthanh(masp);
                            }

                            lbtongsoluong.Text = dulieu.tongcheckhang();
                            dulieu.loadvaodatag1(datag1);
                            datag1.FirstDisplayedScrollingRowIndex = datag1.RowCount - 1;
                            lbtinhtrang.Text = dulieu.laytinhtrangthuathieu(masp);
                            datag2.DataSource = dulieu.laydulieubangthuathieu(kihieumasanpham);
                            hamtao.tudongnhaydenmasp(datag2, masp,kihieumasanpham);
                            txtbarcode.Clear();
                            txtbarcode.Focus();

                            if (datag1.RowCount > 0 && !chinhsizecot)
                            {
                                DataGridViewColumn column = datag1.Columns[0];
                                column.Width = 30;
                                column = datag1.Columns[1];
                                column.Width = 70;
                                column = datag1.Columns[3];
                                column.Width = 40;

                                column = datag2.Columns[1];
                                column.Width = 30;
                                column = datag2.Columns[2];
                                column.Width = 120;
                                chinhsizecot = true;
                            }
                            capnhatlbthongtin(masp);
                            if (pbdelete.Image == Properties.Resources.taygif || chinhsuama)
                            {
                                pbdelete.Image = Properties.Resources.eraser;
                                chinhsuama = false;
                            }
                        }
                        catch (Exception)
                        {

                            hamtao.notifi_hts("Xem lại đi lỗi rồi");
                        }
                    }
                }

            }
        }

        private void btnbatdaukiemhang_Click(object sender, EventArgs e)
        {
            var dulieu = ketnoi.Khoitao();
            if (dulieu.kiemtracondonhangdangnhatkhong() != null)
            {
                DialogResult hoi = MessageBox.Show("Còn đơn hàng đang nhặt từ đợt trước\n- '" + dulieu.kiemtracondonhangdangnhatkhong() + "'\n\nCó muốn nhặt tiếp không?", "Vẫn còn đơn cũ", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    updatetatca();
                    HamBatDau();
                }
                else if (hoi == DialogResult.No)
                {
                    if (dulieu.kiemtraconDULIEUNHAT())
                    {
                        DialogResult hoi2 = MessageBox.Show("Còn dữ liệu COPY lần trước có muốn nhặt tiếp không?", "Dữ liệu COPY ?", MessageBoxButtons.YesNo);
                        if (hoi2 == DialogResult.Yes)
                        {
                            string[] ngaygio = dulieu.layngaygiodaluuCHuyenhang();
                            dulieu.savevaobangchuyenhang(ngaygio[0], ngaygio[1]);
                            dulieu.xoabangtamchuyenhang();
                            dulieu.xoabangthuathieu();
                            datag3.DataSource = dulieu.laydulieubangCOPY();
                            lbsoluongdon.Text = dulieu.tongsoluongcannhat("bangtamchuyenhang1");
                            HamBatDau();
                        }
                        else
                        {
                            string[] ngaygio = dulieu.layngaygiodaluuCHuyenhang();
                            dulieu.savevaobangchuyenhang(ngaygio[0], ngaygio[1]);
                            dulieu.xoabangtamchuyenhang();
                            dulieu.xoabangtamchuyenhang1();
                            dulieu.xoabangthuathieu();
                            HamBatDau();
                        }
                    }
                    else
                    {
                        try
                        {
                            string[] ngaygio = dulieu.layngaygiodaluuCHuyenhang();
                            dulieu.savevaobangchuyenhang(ngaygio[0], ngaygio[1]);
                            dulieu.xoabangtamchuyenhang();
                            dulieu.xoabangtamchuyenhang1();
                            dulieu.xoabangthuathieu();
                            HamBatDau();
                        }
                        catch (Exception)
                        {

                            return;
                        }
                    }

                }
            }
            else
            {
                if (dulieu.kiemtraconDULIEUNHAT())
                {
                    DialogResult hoi2 = MessageBox.Show("Còn dữ liệu COPY lần trước có muốn nhặt tiếp không?", "Dữ liệu COPY ?", MessageBoxButtons.YesNo);
                    if (hoi2 == DialogResult.Yes)
                    {
                        dulieu.xoabangtamchuyenhang();
                        dulieu.xoabangthuathieu();
                        datag3.DataSource = dulieu.laydulieubangCOPY();
                        lbsoluongdon.Text = dulieu.tongsoluongcannhat("bangtamchuyenhang1");
                        HamBatDau();
                    }
                    else
                    {
                        if (datag3.RowCount > 0)
                        {
                            dulieu.xoabangthuathieu();
                            HamBatDau();
                        }
                        else
                        {
                            dulieu.xoabangtamchuyenhang1();
                            dulieu.xoabangthuathieu();
                            HamBatDau();
                        }
                        
                    }
                }
                else
                {
                    try
                    {
                        dulieu.xoabangtamchuyenhang();
                        dulieu.xoabangthuathieu();
                        HamBatDau();
                    }
                    catch (Exception)
                    {

                        return;
                    }
                }
            }
        }
        public bool laygiatriChinhsua
        {
            get { return chinhsuama; }
        }
        public PictureBox pbdunglai
        {
            get { return pbdunglaidi; }
        }
        public PictureBox pbxoa
        {
            get { return pbdelete; }
        }
        public void pbdunglaidi_Click(object sender, EventArgs e)
        {
            try
            {
                amthanh.dungbaoloi();
                pbdunglaidi.Visible = false;
                txtbarcode.Enabled = true;
                txtbarcode.Clear();
                txtbarcode.Focus();
                btnlaydata.Enabled = true;
                lbThongbao.Text = "-";
            }
            catch (Exception)
            {

                return;
            }
        }

        public void pbdelete_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Có chắc muốn xóa mã này không ?\n" + lbmasp.Text, "Hỏi cho chắc cú", MessageBoxButtons.YesNo);
            if (hoi == DialogResult.Yes)
            {
                if (datag1.SelectedCells.Count > 0 && chinhsuama)
                {
                    try
                    {
                        string masp = lbmasp.Text;
                        var dulieu = ketnoi.Khoitao();
                        dulieu.deletemaspchuyenhang(idrows);
                        dulieu.updatebangthuathieu(masp, kihieumasanpham);
                        //hamtao.notifi_hts("Vừa xóa mã :\n" + lbmasp.Text);
                        lbThongbao.Text = "Vừa xóa mã :" + masp + " tại STT: " + idrows;
                        dulieu.loadvaodatag1(datag1);
                        datag2.DataSource = dulieu.laydulieubangthuathieu(kihieumasanpham);
                        dulieu.baoamthanh(masp);
                        hamtao.tudongnhaydenmasp(datag2, masp, kihieumasanpham);
                        lbtongsoluong.Text = dulieu.tongcheckhang();
                        txtbarcode.Clear();
                        lbmasp.Text = "-";
                        txtsoluong.Text = "-";
                        txtbarcode.Focus();
                        pbdelete.Image = Properties.Resources.eraser;
                        chinhsuama = false;
                    }
                    catch (Exception)
                    {

                        return;
                    }
                }


            }
        }
        public void chonhangcuoi()
        {
            try
            {
                var dulieu = ketnoi.Khoitao();
                int RowIndex = datag1.RowCount - 2;
                DataGridViewRow row = datag1.Rows[RowIndex];
                idrows = row.Cells[0].Value.ToString();
                lbmasp.Text = row.Cells[2].Value.ToString();
                pbdelete.Image = Properties.Resources.taygif;

                lbtinhtrang.Text = dulieu.laytinhtrangthuathieu(lbmasp.Text);
                capnhatlbthongtin(lbmasp.Text);
                chinhsuama = true;
            }
            catch (Exception)
            {

                return;
            }
        }

        private void datag1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dulieu = ketnoi.Khoitao();
                DataGridViewRow row = datag1.Rows[e.RowIndex];
                idrows = row.Cells[0].Value.ToString();
                lbmasp.Text = row.Cells[2].Value.ToString();
                pbdelete.Image = Properties.Resources.taygif;

                lbtinhtrang.Text = dulieu.laytinhtrangthuathieu(lbmasp.Text);
                capnhatlbthongtin(lbmasp.Text);
                chinhsuama = true;
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btnlaydata_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dilog = MessageBox.Show("Lấy dữ liệu vửa copy từ clipbroad.?", "COPY", MessageBoxButtons.YesNo);
                if (dilog == DialogResult.Yes)
                {
                    Thread laydataHts = new Thread(hamLaydata);
                    laydataHts.IsBackground = true;
                    laydataHts.Start();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        //void laydatagoc()
        //{
        //    try
        //    {
        //        var dulieu = ketnoi.Khoitao();
        //        datag3.DataSource = hamtao.layvungcopy();
        //        if (datag3.RowCount > 0)
        //        {
        //            DataGridViewColumn column = datag3.Columns[1];
        //            column.Width = 40;
        //            datag3.DefaultCellStyle.Font = new Font("Comic Sans MS", 12.0f);
        //        }
        //        dulieu.xoabangtamchuyenhang1();
        //        string StrQuery = "";
        //        string mau = @"\d\w{2}\d{2}[SWAC]\d{3}-\w{2}\d{3}-\w+";
        //        string mau1 = @"\d\w{2}\d{2}[SWAC]\d{3}";

        //        dulieu.Open();
        //        for (int i = 0; i < datag3.Rows.Count - 1; i++)
        //        {
        //            string magoc = datag3.Rows[i].Cells[0].Value.ToString().Trim();
        //            if (Regex.IsMatch(magoc, mau))
        //            {
        //                StrQuery = "INSERT INTO bangtamchuyenhang1(masp,soluong1) VALUES ('" + magoc + "', '" + datag3.Rows[i].Cells[1].Value.ToString() + "')";
        //            }
        //            else if (Regex.IsMatch(magoc, mau1))
        //            {
        //                StrQuery = "INSERT INTO bangtamchuyenhang1(matong,soluong2) VALUES ('" + magoc + "', '" + datag3.Rows[i].Cells[1].Value.ToString() + "')";
        //            }
        //            SQLiteCommand cmd = new SQLiteCommand(StrQuery, dulieu.returncon);
        //            cmd.ExecuteNonQuery();
        //        }

        //        dulieu.Close();
        //        lbsoluongdon.Text = dulieu.tongsoluongcannhat("bangtamchuyenhang1");
        //        dulieu.updatebangthuathieukhichendon(datag2);
        //    }

        //    catch (Exception)
        //    {
        //        hamtao.notifi_hts("Lỗi rồi:\n-Chỉ được chọn 2 cột (2xn) n bao nhiêu cũng được");
        //        return;
        //    }
        //}
        void hamLaydata() // ham xu ly trong thread
        {
            try
            {
                var dulieu = ketnoi.Khoitao();
                lbThongbao.Invoke(new MethodInvoker(delegate ()
                {
                    lbThongbao.Text = "Đang xử lý ... ";
                }));
                datag3.Invoke(new MethodInvoker(delegate ()
                {
                    datag3.DataSource = hamtao.layvungcopy();
                    if (datag3.RowCount > 0)
                    {
                        DataGridViewColumn column = datag3.Columns[1];
                        column.Width = 40;
                        datag3.DefaultCellStyle.Font = new Font("Comic Sans MS", 12.0f);
                    }
                    dulieu.xoabangtamchuyenhang1();
                    string StrQuery = "";
                    KiemtradangDAUVAO();
                    dulieu.Open();
                    for (int i = 0; i < datag3.Rows.Count - 1; i++)
                    {
                        string magoc = datag3.Rows[i].Cells[0].Value.ToString().Trim();

                        StrQuery = "INSERT INTO bangtamchuyenhang1(masp,soluong1) VALUES ('" + magoc + "', '" + datag3.Rows[i].Cells[1].Value.ToString() + "')";
                        SQLiteCommand cmd = new SQLiteCommand(StrQuery, dulieu.returncon);
                        cmd.ExecuteNonQuery();
                    }

                    dulieu.Close();
                }));
                lbsoluongdon.Invoke(new MethodInvoker(delegate ()
                {
                    string sl = dulieu.tongsoluongcannhat("bangtamchuyenhang1");
                    if (sl != "0")
                    {
                        lbsoluongdon.Text = sl;
                    }
                    else lbsoluongdon.Text = "Nhặt dứt";
                }));
                datag2.Invoke(new MethodInvoker(delegate ()
                {
                    if (datag2.RowCount > 0)
                    {
                        dulieu.updatebangthuathieukhichendon(datag2, kihieumasanpham);
                    }

                }));
                lbThongbao.Invoke(new MethodInvoker(delegate ()
                {
                    lbThongbao.Text = "Import dữ liệu thành công.";
                }));
            }

            catch (Exception)
            {

                return;
            }
        }
        private void btninnhat_Click(object sender, EventArgs e)
        {
            Thread innhat = new Thread(haminnhat);
            innhat.IsBackground = true;
            innhat.Start();

        }
        void haminnhat() // ham xu ly thread innhat
        {
            try
            {
                var dulieu = ketnoi.Khoitao();
                int slIN = 1;
                lbThongbao.Invoke(new MethodInvoker(delegate ()
                {
                    lbThongbao.Text = "Đang xử lý in đơn để nhặt ...";
                }));
                DataTable dt = null;
                string soluong = null;
                datag3.Invoke(new MethodInvoker(delegate ()
                {
                    if (datag3.RowCount < 1)
                    {
                        return;
                    }
                    radioMathieu.Invoke(new MethodInvoker(delegate ()
                    {
                        if (radioMathieu.Checked)
                        {
                            dulieu.savebangtamchuyenhang1_1();
                            dt = dulieu.tachdonmoi(datag2, "btchuyenhang1_1");
                            soluong = dulieu.tongsoluongcannhat("btchuyenhang1_1");
                        }
                        else
                        {

                            dt = (DataTable)(datag3.DataSource);
                            soluong = lbsoluongdon.Text;
                        }
                    }));
                }));
                txtSLIN.Invoke(new MethodInvoker(delegate ()
                {
                    if (Regex.IsMatch(txtSLIN.Text, @"^\d+"))
                    {
                        slIN = int.Parse(txtSLIN.Text.Trim());
                    }
                }));
                hamtao.taovainfileexcel(dt, soluong, slIN);
                lbThongbao.Invoke(new MethodInvoker(delegate ()
                {
                    lbThongbao.Text = "IN xong - Nhặt thôi.";
                }));
            }
            catch (Exception)
            {
                return;
            }
        }
        private void btntachdon_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Tạo 1 đơn mới từ dữ liệu gốc đã trừ đi số lượng vừa nhặt", "Hỏi", MessageBoxButtons.YesNo);
            if (hoi == DialogResult.Yes)
            {
                try
                {
                    lbThongbao.Text = "Đang tách đơn ... ";
                    var dulieu = ketnoi.Khoitao();
                    xuatexcel();
                    dulieu.savevaobangchuyenhang(ngay, gio);
                    dulieu.xoabangtamchuyenhang();
                    dulieu.xoabangthuathieu();
                    datag3.DataSource = dulieu.tachdonmoi(datag2, "bangtamchuyenhang1");

                    lammoitatca();
                    lbsoluongdon.Text = dulieu.tongsoluongcannhat("bangtamchuyenhang1");
                    hamtao.notifi_hts("OK ,Triển chiêu");
                    lbThongbao.Text = "-";
                }
                catch (Exception)
                {

                    hamtao.notifi_hts("Có vấn đề - Xem lại");
                }
            }
        }

        private void btnxuatexcel_Click(object sender, EventArgs e)
        {
            xuatexcel();
        }

        private void radioMathieu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioMathieu.Checked)
                {
                    var dulieu = ketnoi.Khoitao();
                    radioMathieu.BackColor = Color.RoyalBlue;
                    radioMathieu.ForeColor = Color.White;
                    string mabang3 = null;
                    string mabang2 = null;
                    for (int i = 0; i < datag3.RowCount - 1; i++)
                    {
                        mabang3 = datag3.Rows[i].Cells[0].Value.ToString().Trim();
                        for (int j = 0; j < datag2.RowCount - 1; j++)
                        {
                            mabang2 = datag2.Rows[j].Cells[0].Value.ToString();
                            if (mabang3 == mabang2)
                            {
                                datag3.Rows[i].Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    radioMathieu.BackColor = Color.White;
                    radioMathieu.ForeColor = Color.Black;
                }
            }
            catch (Exception)
            {
                radioTatca.Checked = true;
                return;
            }
            

        }

        private void radioTatca_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTatca.Checked)
            {
                radioTatca.BackColor = Color.RoyalBlue;
                radioTatca.ForeColor = Color.White;
            }
            else
            {
                radioTatca.BackColor = Color.White;
                radioTatca.ForeColor = Color.Black;
            }
        }

        private void chuyenhang_Resize(object sender, EventArgs e)
        {
            if (this.Width > 1170)
            {
                datag2.Width = 610;
                grbthongtindon.Width = 610;
                lbtongsoluong.Width = 610;
                btnlaydata.Width = 250;
            }
            else if (this.Width <= 1170)
            {
                datag2.Width = 495;
                grbthongtindon.Width = 490;
                lbtongsoluong.Width = 495;
                btnlaydata.Width = 127;
            }
        }

        private void btnSuaTencuahang_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTencuahang.Text))
            {
                var con = ketnoi.Khoitao();
                con.Suatencuahang(txtTencuahang.Text);
                MessageBox.Show("Vừa sửa tên cửa hàng thành: " + txtTencuahang.Text + " \nTừ giờ mọi file xuất đều lấy theo tên này.");
            }
        }

        private void radioMacdinh_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMacdinh.Checked)
            {
                var dulieu = ketnoi.Khoitao();
                datag2.DataSource = dulieu.laydulieubangthuathieu(1);
                radioMacdinh.BackColor = Color.RoyalBlue;
                radioMacdinh.ForeColor = Color.White;
            }
            else
            {
                radioMacdinh.BackColor = Color.White;
                radioMacdinh.ForeColor = Color.Black;
            }
        }

        private void radioMamau_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMamau.Checked)
            {
                var dulieu = ketnoi.Khoitao();
                datag2.DataSource = dulieu.laydulieubangthuathieu(2);
                radioMamau.BackColor = Color.RoyalBlue;
                radioMamau.ForeColor = Color.White;
            }
            else
            {
                radioMamau.BackColor = Color.White;
                radioMamau.ForeColor = Color.Black;
            }
        }

        private void radioMatong_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMatong.Checked)
            {
                var dulieu = ketnoi.Khoitao();
                datag2.DataSource = dulieu.laydulieubangthuathieu(3);
                radioMatong.BackColor = Color.RoyalBlue;
                radioMatong.ForeColor = Color.White;
            }
            else
            {
                radioMatong.BackColor = Color.White;
                radioMatong.ForeColor = Color.Black;
            }
        }

        private void txtSLIN_Click(object sender, EventArgs e)
        {
            txtSLIN.SelectAll();
        }

        private void txtTencuahang_Click(object sender, EventArgs e)
        {
            txtTencuahang.SelectAll();
        }

        private void pbXoaNhap_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Xóa bản nháp không lưu lại gì ? OK?", "Xóa nháp", MessageBoxButtons.OKCancel);
            if (hoi == DialogResult.OK)
            {
                var dulieu = ketnoi.Khoitao();
                dulieu.xoabangtamchuyenhang();
                dulieu.xoabangtamchuyenhang1();
                dulieu.xoabangthuathieu();
                lammoitatca();
                datag3.DataSource = null;
                datag3.Refresh();
            }
            else return;
        }
    }
}
