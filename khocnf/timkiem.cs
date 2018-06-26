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

        private void timkiem_Load(object sender, EventArgs e)
        {
            ngaymuontim = DateTime.Now.ToString("dd/MM/yyyy");
            hamloadBang(ngaymuontim);
            var dulieu = ketnoi.Khoitao();
            datag4.DataSource = dulieu.loadbangchitietPhieu();
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

        

        private void datag3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = datag3.Rows[e.RowIndex];
            string sophieu = row.Cells[0].Value.ToString();
            var dulieu = ketnoi.Khoitao();

            datag4.DataSource = dulieu.loadbangchitietPhieu(sophieu);
        }

        private void datag1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = datag1.Rows[e.RowIndex];
            string ngay = row.Cells[1].Value.ToString();
            string gio = row.Cells[2].Value.ToString();
            var dulieu = ketnoi.Khoitao();

            lbtongslkiemhang.Text = dulieu.laysoluong1dontrongngay(ngay,gio,"kiemhang");
        }

        private void datag2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = datag2.Rows[e.RowIndex];
            string ngay = row.Cells[1].Value.ToString();
            string gio = row.Cells[2].Value.ToString();
            var dulieu = ketnoi.Khoitao();

            lbtongslchuyenhang.Text = dulieu.laysoluong1dontrongngay(ngay, gio, "chuyenhang");
        }

        private void btnxuatKH_Click(object sender, EventArgs e)
        {
            try
            {
                var dulieu = ketnoi.Khoitao();
                
                hamtao.xuatfileexceltabtimkiem(dulieu.loadbangkiemhang(ngaymuontim),dulieu.loadbangchuyenhang(ngaymuontim),dulieu.loadbangchitietPhieu(), ngaymuontim);
                hamtao.notifi_hts("Đã xuất file tại:\n-->" + hamtao.layduongdan(),5);
            }
            catch (Exception)
            {

                hamtao.notifi_hts("Có vấn đề \n- Xem lại đi");
            }
        }

        

        private void txtsophieu_TextChanged(object sender, EventArgs e)
        {
            var dulieu = ketnoi.Khoitao();
            datag1.DataSource = dulieu.loctheoSophieubang1(txtsophieu.Text);
            datag3.DataSource = dulieu.loctheoSophieubang3(txtsophieu.Text);
        }

        private void txtnoinhan_TextChanged(object sender, EventArgs e)
        {
            var dulieu = ketnoi.Khoitao();
            datag2.DataSource = dulieu.loctheoNoinhan(txtnoinhan.Text);
        }
    }
}
