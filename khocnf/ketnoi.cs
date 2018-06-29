using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace khocnf
{
    class ketnoi
    {
        #region khoitao
        private SQLiteConnection conn = null;
        public SQLiteConnection returncon
        {
            get { return conn; }
        }
        private ketnoi()
        {
            string connstring = @"Data source=data.db;version=3;new=false";
            conn = new SQLiteConnection(connstring);
        }
        private static ketnoi _khoitao = null;
        public static ketnoi Khoitao()
        {
            if (_khoitao == null)
            {
                _khoitao = new ketnoi();
            }
            return _khoitao;
        }
        public void Open()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception)
                {

                    MessageBox.Show("Không kết nối được ", "Lỗi");
                }
            }
        }
        public void Close()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        #endregion

        // xu ly thread
        public void chenvaoDATA(DataTable dt)
        {
            string barcode = null;
            string masp = null;
            if (dt!= null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    barcode = row[0].ToString();
                    masp = row[1].ToString();
                    if (barcode != null && masp != null)
                    {
                        if (laymasp(barcode) == null)
                        {
                            string sql = "insert into data(barcode,masp) values('" + barcode + "','" + masp + "')";
                            Open();
                            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            Close();
                        }
                        
                    }
                   
                }
            }
        }
        
        #region xuly kiemhang
        public string laymasp(string barcode)
        {
            string h = null;
            string sql = string.Format("select masp from data where barcode ='{0}'", barcode);
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                h = dtr[0].ToString();
            }
            Close();
            return h;
        }
        public string laymatong(string masp)
        {
            string m = null;
            if (masp != null)
            {
                int vitrikitu = masp.IndexOf("-");
                m = masp.Substring(0, vitrikitu);
            }
            return m;
        }
        public string tongsoluongbt1()
        {
            string sql = "select sum(soluong) from btkiemhang1";
            string sl = null;
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                sl = dtr[0].ToString();
            }
            Close();
            return sl;
        }
        public string tongsoluongbt2()
        {
            string sql = "select sum(soluong1) from btkiemhang2";
            string sl = null;
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                sl = dtr[0].ToString();
            }
            Close();
            return sl;
        }
        public void chenvaobtkiemhang1(string barcode, string masp, string sophieu, string ngay, string gio)
        {
            string matong = laymatong(masp);
            string sql = string.Format(@"insert into btkiemhang1(sophieu,ngay,barcode,masp,matong,soluong,gio) values('{0}','{1}','{2}','{3}','{4}','1','{5}')", sophieu, ngay, barcode, masp, matong, gio);
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();

        }
        public DataTable bangkiemhang1()
        {
            DataTable h = new DataTable();
            string sql = "select idrow as 'STT',barcode as 'Barcode',masp as 'Mã sản phẩm' ,soluong as 'SL' from btkiemhang1";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            dta.Fill(h);
            Close();
            return h;
        }
        public DataTable locdulieu()
        {
            string sql = "select matong as 'Mã tổng thực tế', sum(soluong) as 'SL thực tế' from btkiemhang1 group by matong";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public void kiemtramamoi(string matong)
        {
            string sql = "select sum(soluong) from btkiemhang1 where matong='" + matong + "'";
            Open();
            string soluong = null;
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                soluong = dtr[0].ToString();
            }
            Close();
            if (soluong == "1")
            {
                amthanh.phatmamoi();
            }
            else
            {
                return;
            }
        }
        public void xoabangtam()
        {
            string sql = @"delete from btkiemhang1; delete from sqlite_sequence where name='btkiemhang1'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void xoabangtam2()
        {
            string sql = "delete from btkiemhang2 ; delete from sqlite_sequence where name='btkiemhang2'";
         
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void updatebangtam(string soluongmoi, string id)
        {
            string sql = "update btkiemhang1 set soluong='" + soluongmoi + "' where idrow='" + id + "'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void deletemasp(string id)
        {
            string sql = "delete from btkiemhang1 where idrow='" + id + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            Open();
            cmd.ExecuteNonQuery();
            Close();
        }

        public void laydataexcel(string matong, string sl)
        {
            string sql = "insert into btkiemhang2(matong1,soluong1) values('" + matong + "','" + sl + "')";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }

        public DataTable sosanhdulieu()
        {
            
            string sql2 = "select matong as 'Mã thực tế',tongsoluong as 'SL TT',matong1 as 'Mã theo đơn',tongsoluong1 as 'SL TĐ' from	(select matong1,sum(soluong1) as tongsoluong1 from btkiemhang2 group by matong1) left join (select matong,sum(soluong) as tongsoluong from btkiemhang1 group by matong) on matong1=matong union all select matong as 'Mã thực tế',tongsoluong as 'SL TT',matong1 as 'Mã theo đơn',tongsoluong1 as 'SL TĐ' from (select matong,sum(soluong) as tongsoluong from btkiemhang1 group by matong) left join (select matong1,sum(soluong1) as tongsoluong1 from btkiemhang2 group by matong1) on matong1=matong where matong1 is null";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql2, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public void savevaobangkiemhang()
        {
            string sql = "insert into kiemhang(sophieu,ngay,barcode,masp,matong,soluong,gio) select sophieu,ngay,barcode,masp,matong,soluong,gio from btkiemhang1";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            cmd.ExecuteNonQuery();
            Close();
        }
        public void chenthongtinphieu(string sophieu,string masp, string sl)
        {
            string sql = string.Format("insert into chitietphieu values('{0}','{1}','{2}')", sophieu, masp, sl);
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void chenthongtinphieu(string sophieu, string noidung, string dieuphoi,string sl)
        {
            string ngay = DateTime.Now.ToString("dd-MM-yyyy");
            string sql = string.Format("insert into bangphieu values('{0}','{1}','{2}','{3}','{4}')", sophieu, noidung, dieuphoi,sl,ngay);
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        #endregion

        #region xu ly tab chuyen hang
        public string tinhtrang(string masp)
        {
            string ketqua = null;
            if (kiemtracotmatongbangchuyenhang1() != "0")
            {
                if (kiemtracotrongcotmatong(laymatong(masp)) != null)
                {
                    ketqua = "Thiếu";
                }
                else if (kiemtracotrongcotmatong(laymatong(masp)) == null)
                {
                    double soluongtt = laysoluongthucte(masp);
                    double soluongtd = laysoluongtudon(masp);

                    if (soluongtd == 0)
                    {
                        ketqua = "Ngoài";
                    }
                    else if (soluongtt < soluongtd)
                    {
                        ketqua = "Thiếu";
                    }
                    else if (soluongtt == soluongtd)
                    {
                        ketqua = "Đủ";
                    }
                    else if (soluongtt > soluongtd)
                    {
                        ketqua = "Thừa";
                    }
                }
            }
            else if (kiemtracotmatongbangchuyenhang1() == "0")
            {
                double soluongtt = laysoluongthucte(masp);
                double soluongtd = laysoluongtudon(masp);

                if (soluongtd == 0)
                {
                    ketqua = "Ngoài";
                }
                else if (soluongtt < soluongtd)
                {
                    ketqua = "Thiếu";
                }
                else if (soluongtt == soluongtd)
                {
                    ketqua = "Đủ";
                }
                else if (soluongtt > soluongtd)
                {
                    ketqua = "Thừa";
                }
            }

            return ketqua;
        }

        public string kiemtracotrongbangthuathieu(string masp)
        {
            string sql = "select masp from bangthuathieu where masp='" + masp + "'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            string cohaykhong = null;
            while (dtr.Read())
            {
                cohaykhong = dtr[0].ToString();
            }
            Close();
            return cohaykhong;
        }
        public string kiemtracotrongcotmatong(string matong)
        {
            string sql = "select matong from bangtamchuyenhang1 where matong='" + matong + "'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            string cohaykhong = null;
            while (dtr.Read())
            {
                cohaykhong = dtr[0].ToString();
            }
            Close();
            return cohaykhong;
        }
        public string kiemtracotmatongbangchuyenhang1()
        {
            string sql = "select count(matong) from bangtamchuyenhang1";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            string sl1 = null;
            while (dtr.Read())
            {
                sl1 = dtr[0].ToString();
            }
            if (sl1 == null)
            {
                sl1 = "0";
            }
            Close();
            return sl1;
        }
        public double laysoluongthucte(string masp)
        {
            string sql = "select sum(soluong) from bangtamchuyenhang where masp='" + masp + "'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            string sl1 = null;
            while (dtr.Read())
            {
                sl1 = dtr[0].ToString();
            }
            Close();
            return hamtao.ConvertToDouble(sl1);
        }
        public double laysoluongtudon(string masp)
        {
            string sql = "select sum(soluong1) from bangtamchuyenhang1 where masp='" + masp + "'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            string sl1 = null;
            while (dtr.Read())
            {
                sl1 = dtr[0].ToString();
            }
            Close();
            return hamtao.ConvertToDouble(sl1);
        }
        public string laysoluong2tudon(string matong)
        {
            string sql = "select soluong2 from bangtamchuyenhang1 where matong='" + matong + "'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            string sl1 = null;
            while (dtr.Read())
            {
                sl1 = dtr[0].ToString();
            }
            Close();
            return sl1;
        }
        public void insertdl1(string barcode, string masp, string sl, string ngay, string gio,string noinhan)
        {
            string sql = "insert into bangtamchuyenhang(barcode,masp,soluong,ngay,gio,noinhan) values('" + barcode + "','" + masp + "','" + sl + "','" + ngay + "','" + gio + "', '"+noinhan+"')";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            cmd.ExecuteNonQuery();
            Close();
        }
        public void loadvaodatag1(DataGridView dgv)
        {
            string sql = "select idrow as 'STT',barcode as 'Barcode',masp as 'Mã sản phẩm' ,soluong as 'SL' from bangtamchuyenhang";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            dgv.DataSource = dt;
        }
        public void baoamthanh(string masp)
        {
            if (tinhtrang(masp) == "Ngoài")
            {
                amthanh.phatNGoai();
            }
            
            else if (tinhtrang(masp) == "Đủ")
            {
                amthanh.phatDu();
            }
            else if (tinhtrang(masp) == "Thừa")
            {
                amthanh.phatThua();
            }
        }
        public void chenvaobangthuathieu(string masp)
        {
            string sl = laysoluongthucte(masp).ToString();
            string sql = null;
            if (kiemtracotrongbangthuathieu(masp) == null)
            {
                sql = "insert into bangthuathieu values('" + masp + "','" + sl + "','" + tinhtrang(masp) + "')";
            }
            else if (kiemtracotrongbangthuathieu(masp) != null)
            {
                sql = "update bangthuathieu set soluong='" + sl + "',tinhtrang='" + tinhtrang(masp) + "' where masp='" + masp + "'";
            }

            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            cmd.ExecuteNonQuery();
            Close();
        }
        public DataTable laydulieubangthuathieu()
        {
            string sql = "select masp as 'Mã thực tế', sum(soluong) as 'SL TT',tinhtrang as 'Tình trạng' from bangthuathieu group by masp";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public string laytinhtrangthuathieu(string masp)
        {
            string sql = "select tinhtrang from bangthuathieu where masp='" + masp + "'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            string sl1 = null;
            while (dtr.Read())
            {
                sl1 = dtr[0].ToString();
            }
            Close();
            return sl1;
        }
        public string tongcheckhang()
        {
            string sql = "select sum(soluong) from bangtamchuyenhang";
            string sl = null;
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                sl = dtr[0].ToString();
            }
            Close();
            return sl;
        }
        public string kiemtracondonhangdangnhatkhong()
        {
            string sql = "select ngay,gio from bangtamchuyenhang";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            string cohaykhong = null;
            while (dtr.Read())
            {
                cohaykhong = dtr[0].ToString();
                if (cohaykhong != null)
                {
                    cohaykhong = "Ngày: " + dtr[0].ToString() + " - Giờ: " + dtr[1].ToString();
                }

            }
            Close();
            return cohaykhong;
        }
        public void xoabangtamchuyenhang()
        {
            string sql = "delete from bangtamchuyenhang ; delete from sqlite_sequence where name='bangtamchuyenhang'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void xoabangthuathieu()
        {
            string sql = "delete from bangthuathieu ; delete from sqlite_sequence where name='bangthuathieu'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void deletemaspchuyenhang(string id)
        {
            string sql = "delete from bangtamchuyenhang where idrow='" + id + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            Open();
            cmd.ExecuteNonQuery();
            Close();
        }
        public void updatebangthuathieu(string masp)
        {
            string sl = laysoluongthucte(masp).ToString();
            string sql = null;
            if (sl == "0")
            {
                sql = "delete from bangthuathieu where masp='" + masp + "'";
            }
            else
            {
                sql = "update bangthuathieu set soluong='" + sl + "',tinhtrang='" + tinhtrang(masp) + "' where masp='" + masp + "'";
            }

            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void xoabangtamchuyenhang1()
        {
            string sql = "delete from bangtamchuyenhang1 ; delete from sqlite_sequence where name='bangtamchuyenhang1'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public string tongsoluongcannhat(string tenbang)
        {
            string sql = "select sum(soluong1),sum(soluong2) from '"+tenbang+"'";

            string sl = null;
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                double sl1 = hamtao.ConvertToDouble(dtr[0].ToString());
                double sl2 = hamtao.ConvertToDouble(dtr[1].ToString());
                sl = (sl1 + sl2).ToString();
            }
            Close();
            return sl;
        }
        public void updatebangthuathieukhichendon(DataGridView dtv)
        {
            if (dtv.RowCount < 1)
            {
                return;
            }
            for (int i = 0; i < dtv.RowCount - 1; i++)
            {
                string masp = dtv.Rows[i].Cells[0].Value.ToString();
                string sql = "update bangthuathieu set tinhtrang='" + tinhtrang(masp) + "' where masp='" + masp + "'";
                Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Close();
            }
            dtv.DataSource = laydulieubangthuathieu();
        }
        public DataTable laybangxuatchuyenhang()
        {
            string sql = "select barcode as 'Barcode',masp as 'Mã thực tế', sum(soluong) as 'Số lượng' from bangtamchuyenhang group by masp";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable laybangmatongchuyenhang1()
        {
            string sql = "select matong as 'Ma tong',soluong2 as 'So luong' from bangtamchuyenhang1";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable laybangdein()
        {
            string sql = "select masp as 'Mã thực tế', sum(soluong) as 'SL TT' from bangthuathieu group by masp";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public void savevaobangchuyenhang(string ngay, string gio)
        {
            string sqlupdate = "update bangtamchuyenhang set ngay='" + ngay + "',gio='" + gio + "' ; insert into chuyenhang(barcode,masp,soluong,ngay,gio,noinhan) select barcode,masp,soluong,ngay,gio,noinhan from bangtamchuyenhang";
           
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sqlupdate, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public string kiemtracotrongdon(string masp)
        {
            string sql = "select masp from bangtamchuyenhang1 where masp='" + masp + "'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            string cohaykhong = null;
            while (dtr.Read())
            {
                cohaykhong = dtr[0].ToString();
            }
            Close();
            return cohaykhong;
        }
        public DataTable tachdon1(string tenbang)
        {
            string sql2 = "select masp as 'Mã sản phẩm',soluong1 as 'Sl sau tách' from '"+tenbang+"' where masp notnull";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql2, conn);
            DataTable dt1 = new DataTable();
            dta.Fill(dt1);
            Close();
            return dt1;
        }
        public DataTable tachdon2(string tenbang)
        {
            string sql2 = "select matong,soluong2 from '"+tenbang+"' where matong notnull";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql2, conn);
            DataTable dt1 = new DataTable();
            dta.Fill(dt1);
            Close();
            return dt1;
        }
        public DataTable tachdonmoi(DataGridView dtg, string tenbang)
        {
            for (int i = 0; i < dtg.RowCount - 1; i++)
            {
                string masp = dtg.Rows[i].Cells[0].Value.ToString();
                string sl = dtg.Rows[i].Cells[1].Value.ToString();
                if (kiemtracotrongdon(masp) != null)
                {
                    double slgoc = laysoluongtudon(masp);
                    string slupdate = (slgoc - hamtao.ConvertToDouble(sl)).ToString();
                    string sql = "update '"+tenbang+"' set soluong1='" + slupdate + "' where masp='" + masp + "' ; delete from '"+tenbang+"' where soluong1='0' ";
                    Open();
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Close();
                }

            }
            return hamtao.tachdon(tachdon1(tenbang), tachdon2(tenbang));
        }
        public void savebangtamchuyenhang1_1()
        {
            string sql = "delete from btchuyenhang1_1; delete from sqlite_sequence where name = 'btchuyenhang1_1'; insert into btchuyenhang1_1 select * from bangtamchuyenhang1";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        #endregion

        #region tab tim kiem
        public DataTable loadbangkiemhang(string ngay)
        {
            string sql = "select sophieu as 'Số phiếu',ngay as 'Ngày',gio as 'Giờ',masp as 'Mã chi tiết',soluong as 'Số lượng' from kiemhang where ngay ='" + ngay + "'";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable loadbangchuyenhang(string ngay)
        {
            string sql = "select noinhan as 'Nơi nhận',ngay as 'Ngày',gio as 'Giờ',masp as 'Mã chi tiết',soluong as 'Số lượng' from chuyenhang where ngay ='" + ngay + "'";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable loadbangPhieu(string ngay)
        {
            string sql = "select sophieu as 'Số phiếu',noidung as 'Nội dung',dieuphoi as 'User',tongsoluong as 'Số lượng' from bangphieu where ngay ='" + ngay + "'";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable loadbangchitietPhieu()
        {
            string sql = "select sophieu as 'Số phiếu',masp as 'Mã sản phẩm',soluong as 'Số lượng' from chitietphieu";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable loadbangchitietPhieu(string sophieu)
        {
            string sql = "select sophieu as 'Số phiếu',masp as 'Mã sản phẩm',soluong as 'Số lượng' from chitietphieu where sophieu ='" + sophieu + "'";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public string laysodontrongngay(string ngay,string tenbang)
        {
            string sql = "select count(*) from (select count(gio) from '"+tenbang+"' where ngay = '"+ngay+"' group by gio)";
            string sl = null;
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                sl = dtr[0].ToString();
            }
            Close();
            return sl;
        }
        public string laysoluongtrongngay(string ngay,string tenbang)
        {
            string sql = "select sum(soluong) from '" + tenbang + "' where ngay ='" + ngay + "'";
            string sl = null;
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                sl = dtr[0].ToString();
            }
            Close();
            return sl;
        }
        public string laysoluong1dontrongngay(string ngay,string gio, string tenbang)
        {
            string sql = "select count(gio) from '"+tenbang+"' where ngay ='"+ngay+"' and gio ='"+gio+"'";
            string sl = null;
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                sl = dtr[0].ToString();
            }
            Close();
            return sl;
        }
        public DataTable loctheoSophieubang1(string sophieu)
        {
            string sql = "select sophieu as 'Số phiếu',ngay as 'Ngày',gio as 'Giờ',masp as 'Mã chi tiết',soluong as 'Số lượng' from kiemhang where sophieu like 'CNF01/INT/" + sophieu + "%'";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable loctheoSophieubang3(string sophieu)
        {
            string sql = "select sophieu as 'Số phiếu',noidung as 'Nội dung',dieuphoi as 'User',tongsoluong as 'Số lượng' from bangphieu where sophieu like 'CNF01/INT/" + sophieu + "%'";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable loctheoNoinhan(string noinhan)
        {
            string sql = "select noinhan as 'Nơi nhận',ngay as 'Ngày',gio as 'Giờ',masp as 'Mã chi tiết',soluong as 'Số lượng' from chuyenhang where noinhan like '" + noinhan + "%'";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        #endregion
    }
}
