using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace khocnf
{
    public partial class timkiem : UserControl
    {
        static string ngaymuontim = "";

        public timkiem()
        {
            InitializeComponent();
        }
        void demSLPHIEU()
        {
            try
            {
                lbsoluongphieu.Text = (datag3.RowCount - 1).ToString();
            }
            catch (Exception)
            {

                lbsoluongphieu.Text = "-";
            }
            
        }
        private void timkiem_Load(object sender, EventArgs e)
        {
            ngaymuontim = DateTime.Now.ToString("dd/mm/yyyy");
            hamloadBang(ngaymuontim);
            var dulieu = ketnoi.Khoitao();
            datag4.DataSource = dulieu.loadbangchitietPhieu();
            DataGridViewColumn column = datag3.Columns[0];
            column.Width = 130;
            column = datag3.Columns[1];
            column.Width = 180;
            column = datag3.Columns[2];
            column.Width = 80;
        }
        // ham ho tro
        void hamloadBang(string ngay)
        {
            var dulieu = ketnoi.Khoitao();
            
            datag2.DataSource = dulieu.loadbangchuyenhang(ngay);
            datag1.DataSource = dulieu.loadbangkiemhang(ngay);
            datag3.DataSource = dulieu.loadbangPhieu(ngay);
            lbsldonkiemhang.Text = dulieu.laysodontrongngay(ngay, "kiemhang");
            lbsldonchuyenhang.Text = dulieu.laysodontrongngay(ngay, "chuyenhang");
            lbtongslkiemhang.Text = dulieu.laysoluongtrongngay(ngay, "kiemhang");
            lbtongslchuyenhang.Text = dulieu.laysoluongtrongngay(ngay, "chuyenhang");
            demSLPHIEU();
            
        }

        //
        private void monthC_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                var month = sender as MonthCalendar;
                ngaymuontim = month.SelectionStart.ToString("dd-MM-yyyy");
                hamloadBang(ngaymuontim);
                var dulieu = ketnoi.Khoitao();
                datag4.DataSource = dulieu.loadbangchitietPhieu();
            }
            catch (Exception)
            {
                hamtao.notifi_hts("Có vấn đề \n- Xem lại đi");
            }
        }


        static string sophieu = null;
        static string noidung = null;
        static string tongsoluong = null;
        static string ngaytrenphieu = null;
        static bool laythongtinP = false;

        public static bool laythongtinPhieu(string sophieu1,string noidung1,string tongsoluong1,string ngaytrenphieu1)
        {
            bool ok = false;
            try
            {
                sophieu = sophieu1;
                noidung = noidung1;
                tongsoluong = tongsoluong1;
                ngaytrenphieu = ngaytrenphieu1;
                ok = true;
            }
            catch (Exception)
            {

                ok = false;
            }
            return ok;
        }
        private void datag3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = datag3.Rows[e.RowIndex];
                string sophieu = row.Cells[0].Value.ToString();
                var dulieu = ketnoi.Khoitao();
                laythongtinP = laythongtinPhieu(sophieu, row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[5].Value.ToString());
                datag4.DataSource = dulieu.loadbangchitietPhieu(sophieu);
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
                DataGridViewRow row = datag1.Rows[e.RowIndex];
                string ngay = row.Cells[1].Value.ToString();
                string gio = row.Cells[2].Value.ToString();
                var dulieu = ketnoi.Khoitao();

                lbtongslkiemhang.Text = dulieu.laysoluong1dontrongngay(ngay, gio, "kiemhang");
            }
            catch (Exception)
            {

                return;
            }
            
        }

        private void datag2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = datag2.Rows[e.RowIndex];
                string ngay = row.Cells[1].Value.ToString();
                string gio = row.Cells[2].Value.ToString();
                var dulieu = ketnoi.Khoitao();

                lbtongslchuyenhang.Text = dulieu.laysoluong1dontrongngay(ngay, gio, "chuyenhang");
            }
            catch (Exception)
            {

                return;
            }
            
        }

        private void btnxuatKH_Click(object sender, EventArgs e)
        {
            //try
            {
                var dulieu = ketnoi.Khoitao();
                
                hamtao.xuatfileexceltabtimkiem(dulieu.loadbangkiemhang(ngaymuontim),dulieu.loadbangchuyenhang(ngaymuontim),dulieu.loadbangchitietPhieuxuatEXCEL(), ngaymuontim);
                hamtao.notifi_hts("Đã xuất file tại:\n-->" + hamtao.layduongdan(),5);
            }
            //catch (Exception)
            //{

            //    hamtao.notifi_hts("Có vấn đề \n- Xem lại đi");
            //}
        }

        

        private void txtsophieu_TextChanged(object sender, EventArgs e)
        {
            var dulieu = ketnoi.Khoitao();
            datag1.DataSource = dulieu.loctheoSophieubang1(txtsophieu.Text);
            datag3.DataSource = dulieu.loctheoSophieubang3(txtsophieu.Text);
            demSLPHIEU();
        }

        private void txtnoinhan_TextChanged(object sender, EventArgs e)
        {
            var dulieu = ketnoi.Khoitao();
            datag2.DataSource = dulieu.loctheoNoinhan(txtnoinhan.Text);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lbtongslkiemhang_Click(object sender, EventArgs e)
        {

        }

        private void timkiem_Resize(object sender, EventArgs e)
        {
            if (this.Width > 1170)
            {
                datag2.Width = 580;
                datag1.Width = 580;
                lbtongslchuyenhang.Width = 200;
                lbtongslkiemhang.Width = 200;
            }
            else if (this.Width <= 1170)
            {
                datag2.Width = 463;
                datag1.Width = 463;
                lbtongslchuyenhang.Width = 77;
                lbtongslkiemhang.Width = 77;
            }
        }

        private void btnInphieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (laythongtinP)
                {
                    var con = ketnoi.Khoitao();
                    hamtao.taovainfileexceltheoPhieu(con.banginSp(sophieu), sophieu, noidung, tongsoluong, ngaytrenphieu);
                }
            }
            catch (Exception)
            {

                hamtao.notifi_hts("co van de");
            }
        }
    }
}
