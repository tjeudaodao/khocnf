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

        Thread laydataHts;  
        public chuyenhang()
        {
            InitializeComponent();
        }
        // ham ho tro
        public void updatetatca()
        {
            var dulieu = ketnoi.Khoitao();
            dulieu.loadvaodatag1(datag1);
            datag2.DataSource = dulieu.laydulieubangthuathieu();
            lbtongsoluong.Text = dulieu.tongcheckhang();
        }
        public void xuatexcel()
        {
            try
            {
                var dulieu = ketnoi.Khoitao();
                if (datag2.RowCount > 0)
                {
                    hamtao.xuatfile(dulieu.laybangxuatchuyenhang(), lbtongsoluong.Text, txtnoinhan.Text);
                    hamtao.taovainfileexcelchuyenhang(dulieu.laybangdein(), lbtongsoluong.Text, txtnoinhan.Text);
                    hamtao.notifi_hts("Đường dẫn:'" + hamtao.layduongdan() + "'", 5);
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
                lbtongsoluong.Text = "-";
                datag2.DataSource = null;
                datag2.Refresh();
                txtbarcode.Clear();
                btnbatdaukiemhang.Enabled = true;
                txtbarcode.Enabled = false;
                chinhsizecot = false;
                chinhsuama = false;
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
            string matong = dulieu.laymatong(masp);
            if (dulieu.kiemtracotrongcotmatong(matong) != null)
            {
                lbthongtin.Text = dulieu.laysoluong2tudon(matong);
            }
            else
            {
                lbthongtin.Text = "-";
            }
        }
        //
        private void chuyenhang_Load(object sender, EventArgs e)
        {
            txtbarcode.Enabled = false;
            txtnoinhan.Select();
            txtnoinhan.Focus();
            datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 16.0f);
        }
        private void pbsave_Click(object sender, EventArgs e)
        {
            var dulieu = ketnoi.Khoitao();
            DialogResult hoi = MessageBox.Show("Lưu lại đơn đã kiểm và làm mới\n\n-Sau đó Tiếp hay nghỉ thì tùy !", "Chốt", MessageBoxButtons.OKCancel);
            if (hoi == DialogResult.OK)
            {
                try
                {
                    dulieu.savevaobangchuyenhang(ngay,gio);
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
                    string masp = dulieu.laymasp(txtbarcode.Text);
                    if (masp == null)
                    {
                        amthanh.phatbaoloi();
                        pbdunglaidi.Visible = true;
                        txtbarcode.Enabled = false;
                       // hamtao.notifi_hts("Có lỗi scan barcode rồi. Ấn biểu tượng tạm dừng để dừng âm thanh !");
                    }
                    else
                    {
                        try
                        {
                            lbmasp.Text = masp;
                            lbtinhtrang.Text = dulieu.tinhtrang(masp);
                            dulieu.insertdl1(txtbarcode.Text, lbmasp.Text, "1", ngay, gio,txtnoinhan.Text);
                            dulieu.loadvaodatag1(datag1);
                            if (datag3.RowCount > 0)
                            {

                                dulieu.baoamthanh(masp);
                            }
                            datag1.FirstDisplayedScrollingRowIndex = datag1.RowCount - 1;
                            dulieu.chenvaobangthuathieu(masp);
                            datag2.DataSource = dulieu.laydulieubangthuathieu();
                            hamtao.tudongnhaydenmasp(datag2, masp);
                            //ham.tudongnhaydenmasp(datagrid3, txtmasp.Text);
                            txtbarcode.Clear();
                            txtbarcode.Focus();

                            lbtongsoluong.Text = dulieu.tongcheckhang();
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

                                 hamtao.notifi_hts( "Xem lại đi lỗi rồi");
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
                    ngay = DateTime.Now.ToString("dd-MM-yyyy");
                    gio = DateTime.Now.ToString("HH:mm");
                    txtbarcode.Enabled = true;
                    txtbarcode.Focus();
                    btnbatdaukiemhang.Enabled = false;
                }
                else if (hoi == DialogResult.No)
                {
                    try
                    {
                        dulieu.xoabangtamchuyenhang();
                        dulieu.xoabangthuathieu();
                        ngay = DateTime.Now.ToString("dd-MM-yyyy");
                        gio = DateTime.Now.ToString("HH:mm");
                        txtbarcode.Enabled = true;
                        txtbarcode.Focus();
                        btnbatdaukiemhang.Enabled = false;
                        datag3.DataSource = dulieu.laybangmatongchuyenhang1();
                    }
                    catch (Exception)
                    {

                        return;
                    }
                }
            }
            else
            {
                try
                {
                    dulieu.xoabangtamchuyenhang();
                    dulieu.xoabangthuathieu();
                    ngay = DateTime.Now.ToString("dd-MM-yyyy");
                    gio = DateTime.Now.ToString("HH:mm");
                    txtbarcode.Enabled = true;
                    txtbarcode.Focus();
                    btnbatdaukiemhang.Enabled = false;
                    datag3.DataSource = dulieu.laybangmatongchuyenhang1();
                }
                catch (Exception)
                {

                    return;
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
                //txtsoluong.Enabled = true;
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
                if (datag1.SelectedCells.Count >0 && chinhsuama)
                {
                    try
                    {
                        var dulieu = ketnoi.Khoitao();
                        dulieu.deletemaspchuyenhang(idrows);
                        dulieu.updatebangthuathieu(lbmasp.Text);
                        hamtao.notifi_hts("Vừa xóa mã :\n" + lbmasp.Text);
                        hamtao.tudongnhaydenmasp(datag2, lbmasp.Text);
                        updatetatca();

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
                laydataHts = new Thread(hamLaydata);
                laydataHts.IsBackground = true;
                laydataHts.Start();
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
                    string mau = @"\d\w{2}\d{2}[SWAC]\d{3}-\w{2}\d{3}-\w+";
                    string mau1 = @"\d\w{2}\d{2}[SWAC]\d{3}";

                    dulieu.Open();
                    for (int i = 0; i < datag3.Rows.Count - 1; i++)
                    {
                        string magoc = datag3.Rows[i].Cells[0].Value.ToString().Trim();
                        if (Regex.IsMatch(magoc, mau))
                        {
                            StrQuery = "INSERT INTO bangtamchuyenhang1(masp,soluong1) VALUES ('" + magoc + "', '" + datag3.Rows[i].Cells[1].Value.ToString() + "')";
                        }
                        else if (Regex.IsMatch(magoc, mau1))
                        {
                            StrQuery = "INSERT INTO bangtamchuyenhang1(matong,soluong2) VALUES ('" + magoc + "', '" + datag3.Rows[i].Cells[1].Value.ToString() + "')";
                        }
                        SQLiteCommand cmd = new SQLiteCommand(StrQuery, dulieu.returncon);
                        cmd.ExecuteNonQuery();
                    }

                    dulieu.Close();
                }));
                lbsoluongdon.Invoke(new MethodInvoker(delegate ()
                {
                    lbsoluongdon.Text = dulieu.tongsoluongcannhat("bangtamchuyenhang1");
                }));
                datag2.Invoke(new MethodInvoker(delegate ()
                {
                    dulieu.updatebangthuathieukhichendon(datag2);
                }));
                
            }

            catch (Exception)
            {
               
                return;
            }
        }
        private void btninnhat_Click(object sender, EventArgs e)
        {

            try
            {
                var dulieu = ketnoi.Khoitao();
                if (datag3.RowCount < 1)
                {
                    hamtao.notifi_hts( "Có vấn đề - Xem lại");
                    return;
                }
                DataTable dt = null;
                string soluong = null;
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
                hamtao.taovainfileexcel(dt,soluong);
                hamtao.notifi_hts("In rồi giờ nhặt thôi");
            }
            catch (Exception)
            {

                hamtao.notifi_hts("Có vấn đề - Xem lại");
            }
        }

        private void btntachdon_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Tạo 1 đơn mới từ dữ liệu gốc đã trừ đi số lượng vừa nhặt", "Hỏi", MessageBoxButtons.YesNo);
            if (hoi == DialogResult.Yes)
            {
                try
                {
                    var dulieu = ketnoi.Khoitao();
                    xuatexcel();
                    dulieu.savevaobangchuyenhang(ngay, gio);
                    datag3.DataSource = dulieu.tachdonmoi(datag2,"bangtamchuyenhang1");
                    
                    lammoitatca();
                    lbsoluongdon.Text = dulieu.tongsoluongcannhat("bangtamchuyenhang1");
                    hamtao.notifi_hts("OK ,Triển chiêu");
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
                        if (mabang3 == mabang2 || dulieu.laymatong(mabang2) == mabang3)
                        {
                            datag3.Rows[i].Selected = true;
                        }
                    }
                }
            }
            else
            {
                radioMathieu.BackColor = Color.White;
                radioMathieu.ForeColor = Color.DimGray;
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
                radioTatca.ForeColor = Color.DimGray;
            }
        }
    }
}
