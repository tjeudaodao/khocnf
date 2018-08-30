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
        private static SQLiteConnection conn = null;
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
        //public void chenvaoDATA(DataTable dt)
        //{
        //    string barcode = null;
        //    string masp = null;
        //    if (dt!= null)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            barcode = row[0].ToString();
        //            masp = row[1].ToString();
        //            if (barcode != null && masp != null)
        //            {
        //                if (laymasp(barcode) == null)
        //                {
        //                    string sql = "insert into data(barcode,masp) values('" + barcode + "','" + masp + "')";
        //                    Open();
        //                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        //                    cmd.ExecuteNonQuery();
        //                    Close();
        //                }
                        
        //            }
                   
        //        }
        //    }
        //}
        // them bang luu ngay
        public string layngayData()
        {
            string sql = "select ngaydata from ngaycapnhat";
            string sl = null;
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                sl = dtr[0].ToString();
            }
            Close();
            if (sl == null)
            {
                sl = "-";
            }
            return sl;
        }
        public void updatengayData(string ngay)
        {
            string sql = "update ngaycapnhat set ngaydata='" + ngay + "'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql,conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void xoatatca_backup()
        {
            string sql = @"delete from bangphieu; delete from sqlite_sequence where name='bangphieu'; delete from chitietphieu; delete from sqlite_sequence where name='chitietphieu';delete from chuyenhang; delete from sqlite_sequence where name='chuyenhang'; delete from kiemhang; delete from sqlite_sequence where name='kiemhang'";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }

        #region xuly kiemhang
        
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
        public bool kiemtraSophieu(string sophieu)
        {
            string h = null;
            bool kt;
            string sql = string.Format("select sophieu from bangphieu where sophieu ='{0}'", sophieu);
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                h = dtr[0].ToString();
            }
            Close();
            if (h != null)
            {
                kt = true;
            }
            else kt = false;
            return kt;
        }
        public void chenthongtinphieu(string sophieu,string masp, string sl,string matong)
        {
            string sql = string.Format("insert into chitietphieu values('{0}','{1}','{2}','{3}')", sophieu, masp, sl,matong);
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void chenthongtinphieu(string sophieu, string noidung, string dieuphoi,string sl,string ngaytrenphieu)
        {
            string ngay = DateTime.Now.ToString("dd-MM-yyyy");
            string sql = string.Format("insert into bangphieu values('{0}','{1}','{2}','{3}','{4}','{5}')", sophieu, noidung, dieuphoi,sl,ngay,ngaytrenphieu);
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        #endregion

        #region xu ly tab chuyen hang
        public string tinhtrang(string masp,int kihieu)
        {
            string ketqua = null;
            if (kihieu == 1)
            {
                double soluongtt = laysoluongthucte("bangtamchuyenhang",masp);
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
                else if (soluongtd == 0.0)
                {
                    ketqua = "Thiếu";
                }
            }
            else if (kihieu == 2)
            {
                string mamau = masp.Substring(0, 15);
                double soluongtt = laysoluongthucte("bangthuathieu", mamau);
                double soluongtd = laysoluongtudon(mamau);

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
                else if (soluongtd == 0.0)
                {
                    ketqua = "Thiếu";
                }
            }
            else if (kihieu == 3)
            {
                string matong = masp.Substring(0, 9);
                double soluongtt = laysoluongthucte("bangthuathieu", matong);
                double soluongtd = laysoluongtudon(matong);

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
                else if (soluongtd == 0.0)
                {
                    ketqua = "Thiếu";
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
        
        public double laysoluongthucte(string tenbang,string masp)
        {
            string sql = "select sum(soluong) from '"+tenbang+"' where masp='" + masp + "'";
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
        public string laysoluongthongtintudon(string masp)
        {
            string sql = "select soluong1 from bangtamchuyenhang1 where masp='" + masp + "'";
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
        public void baoamthanh(string masp,int kihieu)
        {
            if (tinhtrang(masp,kihieu) == "Ngoài")
            {
                amthanh.phatNGoai();
            }
            
            else if (tinhtrang(masp,kihieu) == "Đủ")
            {
                amthanh.phatDu();
            }
            else if (tinhtrang(masp,kihieu) == "Thừa")
            {
                amthanh.phatThua();
            }
        }
        public void chenvaobangthuathieu(string masp,string mamau,string matong,int kihieu)
        {
            string sl = laysoluongthucte("bangtamchuyenhang",masp).ToString();
            string sql = null;
            if (kiemtracotrongbangthuathieu(masp) == null)
            {
                sql = "insert into bangthuathieu values('" + masp + "','" + sl + "','" + tinhtrang(masp,kihieu) + "','"+mamau+"','"+matong+"')";
            }
            else if (kiemtracotrongbangthuathieu(masp) != null)
            {
                sql = "update bangthuathieu set soluong='" + sl + "',tinhtrang='" + tinhtrang(masp,kihieu) + "' where masp='" + masp + "'";
            }

            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            cmd.ExecuteNonQuery();
            Close();
        }
        public DataTable laydulieubangthuathieu(int kihieu)
        {
            string ma = null;
            if (kihieu == 1)
            {
                ma = "masp";
            }
            else if (kihieu == 2)
            {
                ma = "mamau";
            }
            else if (kihieu == 3)
            {
                ma = "matong";
            }
            string sql = "select '"+ma+"' as 'Mã thực tế', sum(soluong) as 'SL TT',tinhtrang as 'Tình trạng' from bangthuathieu group by '"+ma+"'";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable laydulieubangCOPY()
        {
            string sql = "select * from bangtamchuyenhang1";
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
        public bool kiemtraconDULIEUNHAT()
        {
            string sql = "select count(masp) from bangtamchuyenhang1";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            bool kq = false;
            while (dtr.Read())
            { 
                if (dtr[0].ToString() == "0")
                {
                    kq = false;
                }
                else
                {
                    kq = true;
                }
            }
            Close();
            return kq;
        }
        public string[] layngaygiodaluuCHuyenhang()
        {
            string[] h = new string[2];
            string sql = "select ngay,gio from bangtamchuyenhang";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                h[0] = dtr[0].ToString();
                h[1] = dtr[1].ToString();
            }
            Close();
            return h;
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
        public void updatebangthuathieu(string masp,int kihieu)
        {
            string sl = laysoluongthucte("bangtamchuyenhang",masp).ToString();
            string sql = null;
            if (sl == "0")
            {
                sql = "delete from bangthuathieu where masp='" + masp + "'";
            }
            else
            {
                sql = "update bangthuathieu set soluong='" + sl + "',tinhtrang='" + tinhtrang(masp,kihieu) + "' where masp='" + masp + "'";
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
            string sql = "select sum(soluong1) from '"+tenbang+"'";

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
        public void updatebangthuathieukhichendon(DataGridView dtv,int kihieu)
        {
            if (dtv.RowCount < 1)
            {
                return;
            }
            for (int i = 0; i < dtv.RowCount - 1; i++)
            {
                string masp = dtv.Rows[i].Cells[0].Value.ToString();
                string sql = "update bangthuathieu set tinhtrang='" + tinhtrang(masp,kihieu) + "' where masp='" + masp + "'";
                Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Close();
            }
            dtv.DataSource = laydulieubangthuathieu(kihieu);
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
        
        public DataTable laybangdein() // sua lai lay du lieu in tu bangtamchuyenhang thay vi lay tu bangthuathieu
        {
            string sql = "select masp as 'Mã thực tế', sum(soluong) as 'SL TT' from bangtamchuyenhang group by masp";
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
            string sql2 = "select masp as 'Mã sản phẩm',soluong1 as 'Sl' from '"+tenbang+"' where masp notnull";
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
            return tachdon1(tenbang);
        }
        public void savebangtamchuyenhang1_1()
        {
            string sql = "delete from btchuyenhang1_1; delete from sqlite_sequence where name = 'btchuyenhang1_1'; insert into btchuyenhang1_1 select * from bangtamchuyenhang1";
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Close();
        }

        public string LayTencuahang()
        {
            string sql = "select name from tencuahang";
            string kq = null;
            Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            dtr.Read();
            kq = dtr[0].ToString();
            Close();
            return kq;
        }
        public void Suatencuahang(string ten)
        {
            string sql = "update tencuahang set name = '" + ten + "'";
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
            string sql = "select sophieu as 'Số phiếu',noidung as 'Nội dung',dieuphoi as 'User',tongsoluong as 'SL',ngay as 'Ngày kiểm',ngaytrenphieu as 'Ngày / Phiếu' from bangphieu where ngay ='" + ngay + "'";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable loadbangchitietPhieu()
        {
            string sql = "select sophieu as 'Số phiếu',matong as 'Mã sản phẩm',soluong as 'Số lượng' from chitietphieu";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable loadbangchitietPhieu(string sophieu)
        {
            string sql = "select sophieu as 'Số phiếu',matong as 'Mã sản phẩm',sum(soluong) as 'Số lượng' from chitietphieu where sophieu ='" + sophieu + "' group by matong";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable loadbangchitietPhieuxuatEXCEL()
        {
            string sql = "select ngay as 'Ngày kiểm',sophieu as 'Số phiếu',noidung as 'Nội dung',matong as 'Mã tổng',masp as 'Mã sản phẩm',soluong as 'Số lượng' from bangphieu  left join chitietphieu  using(sophieu);";
            Open();
            SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable banginSp(string sophieu)
        {
            string sql = "select matong as 'Mã sản phẩm',sum(soluong) as 'SL' from chitietphieu where sophieu ='" + sophieu + "' group by matong";
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
            string sql = "select sum(soluong) from '"+tenbang+"' where ngay ='"+ngay+"' and gio ='"+gio+"'";
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
            string sql = "select sophieu as 'Số phiếu',noidung as 'Nội dung',dieuphoi as 'User',tongsoluong as 'SL',ngay as 'Ngày',ngaytrenphieu as 'Ngày / Phiếu' from bangphieu where sophieu like 'CNF01/INT/" + sophieu + "%'";
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
