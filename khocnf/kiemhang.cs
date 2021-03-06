﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace khocnf
{
    public partial class kiemhang : UserControl
    {
        static string ngay = null;
        static string gio = null;
        static bool chinhsizecot = false;
        static bool cochuthaydoi = true;
        static string idrows = null;
        static bool chinhsuama = false;

        Thread chayHts;

        public kiemhang()
        {
            InitializeComponent();
        }

        private void kiemhang_Load(object sender, EventArgs e)
        {
            txtsophieu.Select();
            txtsophieu.Focus();
            txtbarcode.Enabled = false;
            txtsoluong.Enabled = false;
            amthanh.amluong(true);

            
        }

        

        // ham ho tro
        public void updatetatca()
        {
            var dulieu = ketnoi.Khoitao();
            datag1.DataSource = dulieu.bangkiemhang1();
            datag2.DataSource = dulieu.locdulieu("matong");
            lbtongsoluong.Text = dulieu.tongsoluongbt1();
            pbdelete.Image = Properties.Resources.eraser;
            pbedit.Image = Properties.Resources.tools;
            try
            {
                datag1.FirstDisplayedScrollingRowIndex = datag1.RowCount - 2;
                datag1.Rows[datag1.RowCount - 2].Cells[0].Selected = true;
                hamtao.tudongnhaydenmasp(datag2, dulieu.laymatong(lbmasp.Text));
            }
            catch (Exception)
            {

                return;
            }
            
        }
        public void clearvungnhap()
        {
            txtbarcode.Clear();
            txtsoluong.Clear();
            lbmasp.Text = "-";
        }
        public void lammoitatca()
        {
            datag1.DataSource = null;
            datag1.Refresh();
            datag2.DataSource = null;
            datag2.Refresh();

            lbtongsoluong.Text = "-";
            clearvungnhap();
            btnbatdaukiemhang.Enabled = true;
            txtbarcode.Enabled = false;
            txtsoluong.Enabled = false;
        }
        public void hamupdatesoluong()
        {
            if (datag1.SelectedCells.Count > 0 && chinhsuama)
            {
                try
                {
                    var dulieu = ketnoi.Khoitao();
                    dulieu.updatebangtam(txtsoluong.Text, idrows);

                    updatetatca();

                    // hamtao.notifi_hts(" Vừa sửa mã\n- '" + lbmasp.Text + "'");
                    lbthongbao.Text = " Vừa sửa mã : '" + lbmasp.Text + "'";
                    clearvungnhap();
                    txtbarcode.Focus();
                    chinhsuama = false;
                }
                catch (Exception)
                {

                    hamtao.notifi_hts("Có vân đề \n Xem lại đi");
                }

            }
        }
        public void hamxoama()
        {
            try
            {
                var dulieu = ketnoi.Khoitao();
                dulieu.deletemasp(idrows);
                // hamtao.notifi_hts( " Vừa xóa mã\n- '" + lbmasp.Text + "'");
                lbthongbao.Text = " Vừa xóa mã : '" + lbmasp.Text + "'";
                updatetatca();
                clearvungnhap();
                txtbarcode.Focus();
            }
            catch (Exception)
            {

                hamtao.notifi_hts("Có vân đề \n Xem lại đi");
            }

        }
        //
        private void txtsophieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnbatdaukiemhang.Select();
                btnbatdaukiemhang.Focus();
            }
        }

        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtbarcode.Text))
                {
                    try
                    {
                        var dulieu = ketnoi.Khoitao();
                        var con = ketnoibarcode.Khoitao();
                        string masp = con.laymasp(txtbarcode.Text);
                        chinhsuama = false;
                        if (masp == null)
                        {
                            amthanh.phatbaoloi();
                            pbdunglaidi.Visible = true;
                            pbdunglaidi.Focus();
                            txtbarcode.Enabled = false;
                            txtsoluong.Enabled = false;
                            lbthongbao.Text = "Có lỗi barcode. Ấn dấu cách để tiếp tục";
                            // hamtao.notifi_hts("Có lỗi scan barcode rồi. Ấn biểu tượng tạm dừng để dừng âm thanh !",1); // dung lenh nay gay cham khi nhan phim fai doi no show het moi nhan dc
                        }
                        else
                        {
                            lbmasp.Text = masp;
                            string matong = dulieu.laymatong(lbmasp.Text);
                            txtsoluong.Text = "1";
                            if (string.IsNullOrEmpty(txtsophieu.Text))
                            {
                                txtsophieu.Text = "-";
                            }
                            dulieu.chenvaobtkiemhang1(txtbarcode.Text, lbmasp.Text, txtsophieu.Text, ngay, gio);
                            datag1.DataSource = dulieu.bangkiemhang1();
                            if (datag1.RowCount > 0 && !chinhsizecot)
                            {
                                DataGridViewColumn column = datag1.Columns[0];
                                column.Width = 30;
                                column = datag1.Columns[3];
                                column.Width = 40;
                                chinhsizecot = true;
                            }
                            if (cochuthaydoi)
                            {
                                datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 30f);
                                cochuthaydoi = false;
                            }
                            datag2.DataSource = dulieu.locdulieu("matong");
                            dulieu.kiemtramamoi(matong);
                            datag1.FirstDisplayedScrollingRowIndex = datag1.RowCount - 2;
                            lbtongsoluong.Text = dulieu.tongsoluongbt1();
                            txtbarcode.Clear();
                            txtbarcode.Focus();
                            hamtao.tudongnhaydenmasp(datag2, matong);
                            if (pbdelete.Image == Properties.Resources.taygif || pbedit.Image == Properties.Resources.editgif)
                            {
                                pbdelete.Image = Properties.Resources.eraser;
                                pbedit.Image = Properties.Resources.tools;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        hamtao.notifi_hts("Có vân đề \n Xem lại đi");
                    }

                }
            }
        }
        private void txtsoluong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                hamupdatesoluong();
            }
        }

        private void btnbatdaukiemhang_Click(object sender, EventArgs e)
        {
            try
            {
                var dulieu = ketnoi.Khoitao();
                if (dulieu.kiemtraBang() != null)
                {
                    DialogResult hoi =   MessageBox.Show("Còn dữ liệu kiểm hàng lần trước.\nCó muốn kiểm tiếp không?","???" ,MessageBoxButtons.YesNo);
                    if (hoi == DialogResult.Yes)
                    {
                        datag1.DataSource = dulieu.bangkiemhang1();
                        datag2.DataSource = dulieu.locdulieu("matong");
                    }
                    else
                    {
                        dulieu.savevaobangkiemhang();
                        dulieu.xoabangtam();
                        dulieu.xoabangtam2();
                    }
                }
                chinhsizecot = false;
                txtbarcode.Enabled = true;
                ngay = DateTime.Now.ToString("dd-MM-yyyy");
                gio = DateTime.Now.ToString("HH:mm");
                btnbatdaukiemhang.Enabled = false;
                txtbarcode.Focus();

            }
            catch (Exception)
            {
                hamtao.notifi_hts("Có vân đề \n Xem lại đi");
            }
        }

        public void pbdunglaidi_Click(object sender, EventArgs e)
        {
            try
            {
                amthanh.dungbaoloi();
                lbthongbao.Text = "-";
                txtbarcode.Enabled = true;
                txtbarcode.Clear();
                txtbarcode.Focus();
                pbdunglaidi.Visible = false;
            }
            catch (Exception)
            {

                hamtao.notifi_hts("Có vân đề \n Xem lại đi");
            }
        }

        private void pbedit_Click(object sender, EventArgs e)
        {
            hamupdatesoluong();
        }

        public void pbdelete_Click(object sender, EventArgs e)
        {
            if (datag1.SelectedCells.Count > 0 && chinhsuama)
            {
                DialogResult hoi = MessageBox.Show("Có chắc muốn xóa mã này không ?\n" + lbmasp.Text, "Hỏi cho chắc cú", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    hamxoama();
                    chinhsuama = false;
                }
            }
            
        }
        public bool laygiatriChinhsua
        {
            get { return chinhsuama; }
        }
        public void chonhangcuoi()
        {
            try
            {
                int RowIndex = datag1.RowCount - 2;
                DataGridViewRow row = datag1.Rows[RowIndex];
                idrows = row.Cells[0].Value.ToString();
                pbdelete.Image = Properties.Resources.taygif;

                chinhsuama = true;
            }
            catch (Exception)
            {

                return;
            }
        }
        public void chonhangcuoi2()
        {
            try
            {
                int RowIndex = datag1.RowCount - 2;
                DataGridViewRow row = datag1.Rows[RowIndex];
                idrows = row.Cells[0].Value.ToString();
                lbmasp.Text = row.Cells[2].Value.ToString();
                txtsoluong.Text = row.Cells[3].Value.ToString();

                pbedit.Image = Properties.Resources.editgif;
                pbdelete.Image = Properties.Resources.taygif;
                txtsoluong.Enabled = true;
                txtsoluong.Focus();
                txtsoluong.SelectAll();

                chinhsuama = true;
            }
            catch (Exception)
            {


                hamtao.notifi_hts("Có vân đề \n Xem lại đi");
            }
        }
        public PictureBox pbxoa
        {
            get { return pbdelete; }
        }
        private void datag1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = datag1.Rows[e.RowIndex];
                idrows = row.Cells[0].Value.ToString();
                lbmasp.Text = row.Cells[2].Value.ToString();
                txtsoluong.Text = row.Cells[3].Value.ToString();

                pbedit.Image  = Properties.Resources.editgif;
                pbdelete.Image = Properties.Resources.taygif;
                txtsoluong.Enabled = true;
                txtsoluong.Focus();
                txtsoluong.SelectAll();

                chinhsuama = true;
            }
            catch (Exception)
            {


                hamtao.notifi_hts("Có vân đề \n Xem lại đi");
            }
        }

        private void btnsosanh_Click(object sender, EventArgs e)
        {
            // sosanhdulieu();
            try
            {
                luuFilechon = Chonfile();
                chayHts = new Thread(xulysosanh);
                chayHts.IsBackground = true;
                chayHts.Start();
            }
            catch (Exception)
            {

                hamtao.notifi_hts("Có vân đề \n Xem lại đi");
            }
            
        }
        /* nhap so sanh trong thread
         * 
         * 
         * 
         * 
         * */
        public string[] luuFilechon;
        public string[] Chonfile()
        {
            string[] hh = null;
            OpenFileDialog chonfile = new OpenFileDialog();
            chonfile.Filter = "Mời các anh chọn file excel (*.xlsx)|*.xlsx";
            chonfile.Multiselect = true;
            if (chonfile.ShowDialog() == DialogResult.OK)
            {
                hh = chonfile.FileNames;
            }
            return hh;
        }
        void xulysosanh()
        {
            if (luuFilechon != null)
            {
                var dulieu = ketnoi.Khoitao();
                dulieu.xoabangtam2();

                pbLoading.Invoke(new MethodInvoker(delegate ()
                {
                    pbLoading.Visible = true;
                }));
                string sophieu = null;
                string noidung = null;
                string dieuphoi = null;
                string tongsoluong = null;
                string ngaytrenphieu = null;

                foreach (string file in luuFilechon)
                {
                    string matong = null;
                    string soluong = null;
                    string masp = null;
                    ExcelPackage filechon = new ExcelPackage(new FileInfo(file));
                    ExcelWorksheet ws = filechon.Workbook.Worksheets[1];
                    var sodong = ws.Dimension.End.Row;
                    if (sodong < 2)
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            sophieu = ws.Cells[2, 3].Value.ToString();
                            noidung = ws.Cells[2, 11].Value.ToString();
                            dieuphoi = ws.Cells[2, 18].Value.ToString();
                            tongsoluong = ws.Cells[2, 14].Value.ToString();
                            try
                            {
                                ngaytrenphieu = ws.Cells[3, 1].Value.ToString();
                            }
                            catch (Exception)
                            {

                                ngaytrenphieu = "-";
                            }
                            

                            bool kiemtraSP = dulieu.kiemtraSophieu(sophieu);

                            for (int i = 3; i < sodong; i++)
                            {
                                matong = ws.Cells[i, 10].Value.ToString();
                                masp = ws.Cells[i, 12].Value.ToString();
                                soluong = ws.Cells[i, 14].Value.ToString();
                                dulieu.laydataexcel(matong, soluong, masp);
                                if (!kiemtraSP)
                                {
                                    dulieu.chenthongtinphieu(sophieu, masp, soluong,matong);
                                }
                                
                            }
                            if (!kiemtraSP)
                            {
                                dulieu.chenthongtinphieu(sophieu, noidung, dieuphoi, tongsoluong,ngaytrenphieu);
                            }
                            
                        }
                        catch (Exception)
                        {
                            pbLoading.Invoke(new MethodInvoker(delegate ()
                            {
                                pbLoading.Visible = false;
                            }));
                            return;
                        }


                    }

                    filechon.Dispose();

                }
                datag2.Invoke(new MethodInvoker(delegate ()
                {
                    datag2.DataSource = hamtao.bangdasosanh(dulieu.sosanhdulieu("matong","matong1"));
                    hamtao.AmthanhSosanh((DataTable)datag2.DataSource);
                    datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 20.0F);
                    DataGridViewColumn column = datag2.Columns[1];
                    column.Width = 60;
                    column = datag2.Columns[3];
                    column.Width = 60;
                    column = datag2.Columns[4];
                    column.Width = 180;

                    chinhsizecot = true;
                    cochuthaydoi = true;
                }));
                pbLoading.Invoke(new MethodInvoker(delegate ()
                {
                    pbLoading.Visible = false;
                }));
                lbsophieu.Invoke(new MethodInvoker(delegate ()
                {
                    lbsophieu.Text = sophieu;
                }));
                lbnoidungdon.Invoke(new MethodInvoker(delegate ()
                {
                    lbnoidungdon.Text = noidung;
                }));
                lbsoluongdon.Invoke(new MethodInvoker(delegate ()
                {
                    lbsoluongdon.Text = dulieu.tongsoluongbt2();
                }));
                
                
                
            }
        }
        //void sosanhdulieu()
        //{
        //    OpenFileDialog chonfile = new OpenFileDialog();
        //    chonfile.Filter = "Mời các anh chọn file excel (*.xlsx)|*.xlsx";
        //    chonfile.Multiselect = true;
        //    if (chonfile.ShowDialog() == DialogResult.OK)
        //    {
        //        string[] cacfiledachon = chonfile.FileNames;
        //        try
        //        {
        //            var dulieu = ketnoi.Khoitao();
        //            dulieu.xoabangtam2();

        //            string sophieu = null;
        //            string noidung = null;
        //            string dieuphoi = null;
        //            string tongsoluong = null;

        //            foreach (string file in cacfiledachon)
        //            {
        //                string matong = null;
        //                string soluong = null;
        //                string masp = null;
        //                ExcelPackage filechon = new ExcelPackage(new FileInfo(file));
        //                ExcelWorksheet ws = filechon.Workbook.Worksheets[1];
        //                var sodong = ws.Dimension.End.Row;
        //                if (sodong < 2)
        //                {
        //                    MessageBox.Show("Lỗi rồi. File đã chọn chưa có dữ liệu");
        //                }
        //                else
        //                {
        //                    try
        //                    {
        //                        sophieu = ws.Cells[2, 3].Value.ToString();
        //                        noidung = ws.Cells[2, 11].Value.ToString();
        //                        dieuphoi = ws.Cells[2, 18].Value.ToString();
        //                        tongsoluong = ws.Cells[2, 14].Value.ToString();

        //                        for (int i = 3; i < sodong; i++)
        //                        {
        //                            matong = ws.Cells[i, 10].Value.ToString();
        //                            masp = ws.Cells[i, 12].Value.ToString();
        //                            soluong = ws.Cells[i, 14].Value.ToString();
        //                            dulieu.laydataexcel(matong, soluong);
        //                            dulieu.chenthongtinphieu(sophieu, masp, soluong);
        //                        }
        //                        dulieu.chenthongtinphieu(sophieu, noidung, dieuphoi, tongsoluong);
        //                    }
        //                    catch (Exception)
        //                    {
        //                        return;
        //                    }


        //                }

        //                filechon.Dispose();

        //            }

        //            datag2.DataSource = hamtao.bangdasosanh(dulieu.sosanhdulieu());
        //            datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 20.0F);
        //            DataGridViewColumn column = datag2.Columns[1];
        //            column.Width = 40;
        //            column = datag2.Columns[3];
        //            column.Width = 40;
        //            column = datag2.Columns[4];
        //            column.Width = 150;

        //            chinhsizecot = true;
        //            cochuthaydoi = true;

        //            lbsophieu.Text = sophieu;
        //            lbnoidungdon.Text = noidung;
        //            lbsoluongdon.Text = dulieu.tongsoluongbt2();
        //            hamtao.notifi_hts( "Đã xong - Đối chiếu xem sao!\n Nếu OK thì ấn vào nút lưu.");
        //        }
        //        catch (Exception)
        //        {
        //            return;
        //        }
        //    }

        //}

        private void pbsave_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Lưu lại đơn đã kiểm\n-Số phiếu:'" + txtsophieu.Text + "'\n-Tiếp hay nghỉ thì tùy !", "CHốt", MessageBoxButtons.OKCancel);
            if (hoi == DialogResult.OK)
            {
                try
                {
                    var dulieu = ketnoi.Khoitao();
                    dulieu.savevaobangkiemhang();
                    dulieu.xoabangtam();
                    dulieu.xoabangtam2();
                    lammoitatca();
                    txtsophieu.Clear();
                    txtsophieu.Focus();
                }
                catch (Exception)
                {
                    hamtao.notifi_hts("Có vân đề \n Xem lại đi");
                }
            }
        }
        public PictureBox pbdunglai
        {
            get { return pbdunglaidi; }
        }

        private void grbthongtindon_Enter(object sender, EventArgs e)
        {

        }

        private void kiemhang_Resize(object sender, EventArgs e)
        {
            if (this.Width > 1170)
            {
                datag2.Width = 820;
                grbthongtindon.Width = 810;
                lbtongsoluong.Width = 820;
                pbLoading.Width = 820;
                lbsoluongdon.Width = 210;
            }
            else if (this.Width <= 1170)
            {
                datag2.Width = 680;
                grbthongtindon.Width = 670;
                lbtongsoluong.Width = 690;
                pbLoading.Width = 680;
                lbsoluongdon.Width = 107;
            }
        }

        private void pbXoaNhap_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Xóa nháp không lưu lại gì sất :). OK?", "Xóa nháp", MessageBoxButtons.OKCancel);
            if (hoi == DialogResult.OK)
            {
                try
                {
                    var dulieu = ketnoi.Khoitao();
                    dulieu.xoabangtam();
                    dulieu.xoabangtam2();
                    lammoitatca();
                    txtsophieu.Clear();
                    txtsophieu.Focus();
                }
                catch (Exception)
                {
                    hamtao.notifi_hts("Có vân đề \n Xem lại đi");
                }
            }
        }

        private void toggleMahang_CheckedChanged(object sender, EventArgs e)
        {
            var dulieu = ketnoi.Khoitao();
            if (datag2.ColumnCount == 2)
            {
                if (toggleMahang.Checked)
                {
                    datag2.DataSource = dulieu.locdulieu("masp");
                    datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 20.0F);
                }
                else
                {
                    datag2.DataSource = dulieu.locdulieu("matong");
                    datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 30f);
                }
            }
            else if (datag2.ColumnCount == 5)
            {
                if (toggleMahang.Checked)
                {
                    datag2.DataSource = hamtao.bangdasosanh(dulieu.sosanhdulieu("masp", "masp1"));
                    datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 14.0F);
                    string layketqua = hamtao.ThongbaoketquaSosanh((DataTable)datag2.DataSource);
                    MessageBox.Show("Kết quả : \n" + layketqua, "Thông báo");
                }
                else
                {
                    datag2.DataSource = hamtao.bangdasosanh(dulieu.sosanhdulieu("matong", "matong1"));
                    datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 20.0F);
                }
            }
        }
    }
}

