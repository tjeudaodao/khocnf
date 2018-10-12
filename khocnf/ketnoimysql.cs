using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace khocnf
{
    class ketnoimysql
    {
        #region khoitao
        private MySqlConnection conn = null;
        private ketnoimysql()
        {
            string connstring = string.Format("Server=27.72.29.28;port=3306; database=cnf; User Id=kho; password=1234");
            conn = new MySqlConnection(connstring);
        }
        private static ketnoimysql _khoitao = null;
        public static ketnoimysql Khoitao()
        {
            if (_khoitao == null)
            {
                _khoitao = new ketnoimysql();
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

                    MessageBox.Show("Không kết nối được đến máy chủ ", "Lỗi");
                    return;
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

        public DataTable Check()
        {
            string sql = "select cnf.data.barcode,cnf.data.masp from cnf.data left join cnf.data_backup on cnf.data.barcode = cnf.data_backup.barcode where cnf.data_backup.barcode is null";
            Open();
            MySqlDataAdapter dta = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            Close();
            return dt;
        }
        public string LayNgaycapnhat()
        {
            string h = null;
            string sql = "select ngaydata from ngaycapnhat";

            Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                h = dtr[0].ToString();
            }
            Close();
            return h;
        }
        public string GetPhienban(string tenungdung)
        {
            string kq = null;
            string sql = "select phienban from bangcapnhatphanmem where tenungdung = '" + tenungdung + "'";
            Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            dtr.Read();
            kq = dtr[0].ToString();
            Close();
            return kq;
        }
    }
}
