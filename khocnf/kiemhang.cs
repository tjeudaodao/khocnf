using System;
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
            datag2.DataSource = dulieu.locdulieu();
            lbtongsoluong.Text = dulieu.tongsoluongbt1();
            pbdelete.Image = Properties.Resources.eraser;
            pbedit.Image = Properties.Resources.tools;
            datag1.FirstDisplayedScrollingRowIndex = datag1.RowCount - 2;
            datag1.Rows[datag1.RowCount - 2].Cells[0].Selected = true;
            hamtao.tudongnhaydenmasp(datag2, dulieu.laymatong(lbmasp.Text));
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

                    hamtao.notifi_hts(" Vừa sửa mã\n- '" + lbmasp.Text + "'");
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
                    hamtao.notifi_hts( " Vừa xóa mã\n- '" + lbmasp.Text + "'");
                    updatetatca();
                    hamtao.tudongnhaydenmasp(datag2, dulieu.laymatong(lbmasp.Text));
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
                        string masp = dulieu.laymasp(txtbarcode.Text);
                        chinhsuama = false;
                        if (masp == null)
                        {
                            amthanh.phatbaoloi();
                            pbdunglaidi.Visible = true;
                            pbdunglaidi.Focus();
                            txtbarcode.Enabled = false;
                            txtsoluong.Enabled = false;

                            hamtao.notifi_hts("Có lỗi scan barcode rồi. Ấn biểu tượng tạm dừng để dừng âm thanh !");
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
                            datag2.DataSource = dulieu.locdulieu();
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
                dulieu.xoabangtam();
                dulieu.xoabangtam2();
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
                var dulieu = ketnoi.Khoitao();
                int RowIndex = datag1.RowCount - 1;
                DataGridViewRow row = datag1.Rows[RowIndex];
                idrows = row.Cells[0].Value.ToString();
                lbmasp.Text = row.Cells[2].Value.ToString();
                pbdelete.Image = Properties.Resources.taygif;

                chinhsuama = true;
            }
            catch (Exception)
            {

                return;
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
            sosanhdulieu();
        }
        
        void sosanhdulieu()
        {
            OpenFileDialog chonfile = new OpenFileDialog();
            chonfile.Filter = "Mời các anh chọn file excel (*.xlsx)|*.xlsx";
            chonfile.Multiselect = true;
            if (chonfile.ShowDialog() == DialogResult.OK)
            {
                string[] cacfiledachon = chonfile.FileNames;
                try
                {
                    var dulieu = ketnoi.Khoitao();
                    dulieu.xoabangtam2();

                    string sophieu = null;
                    string noidung = null;
                    string dieuphoi = null;
                    string tongsoluong = null;

                    foreach (string file in cacfiledachon)
                    {
                        string matong = null;
                        string soluong = null;
                        string masp = null;
                        ExcelPackage filechon = new ExcelPackage(new FileInfo(file));
                        ExcelWorksheet ws = filechon.Workbook.Worksheets[1];
                        var sodong = ws.Dimension.End.Row;
                        if (sodong < 2)
                        {
                            MessageBox.Show("Lỗi rồi. File đã chọn chưa có dữ liệu");
                        }
                        else
                        {
                            try
                            {
                                sophieu = ws.Cells[2, 3].Value.ToString();
                                noidung = ws.Cells[2, 11].Value.ToString();
                                dieuphoi = ws.Cells[2, 18].Value.ToString();
                                tongsoluong = ws.Cells[2, 14].Value.ToString();

                                for (int i = 3; i < sodong; i++)
                                {
                                    matong = ws.Cells[i, 10].Value.ToString();
                                    masp = ws.Cells[i, 12].Value.ToString();
                                    soluong = ws.Cells[i, 14].Value.ToString();
                                    dulieu.laydataexcel(matong, soluong);
                                    dulieu.chenthongtinphieu(sophieu, masp, soluong);
                                }
                                dulieu.chenthongtinphieu(sophieu, noidung, dieuphoi, tongsoluong);
                            }
                            catch (Exception)
                            {
                                return;
                            }


                        }

                        filechon.Dispose();

                    }

                    datag2.DataSource = hamtao.bangdasosanh(dulieu.sosanhdulieu());
                    datag2.DefaultCellStyle.Font = new Font("Comic Sans MS", 20.0F);
                    DataGridViewColumn column = datag2.Columns[1];
                    column.Width = 40;
                    column = datag2.Columns[3];
                    column.Width = 40;
                    column = datag2.Columns[4];
                    column.Width = 150;

                    chinhsizecot = true;
                    cochuthaydoi = true;

                    lbsophieu.Text = sophieu;
                    lbnoidungdon.Text = noidung;
                    lbsoluongdon.Text = dulieu.tongsoluongbt2();
                    hamtao.notifi_hts( "Đã xong - Đối chiếu xem sao!\n Nếu OK thì ấn vào nút lưu.");
                }
                catch (Exception)
                {
                    return;
                }
            }

        }

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
    }
}

