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
    class ketnoibarcode
    {
        #region khoitao
        private SQLiteConnection conn = null;
        public SQLiteConnection returncon
        {
            get { return conn; }
        }
        private ketnoibarcode()
        {
            string connstring = @"Data source=databarcode.db;version=3;new=false";
            conn = new SQLiteConnection(connstring);
        }

        private static ketnoibarcode _khoitao = null;
        public static ketnoibarcode Khoitao()
        {
            if (_khoitao == null)
            {
                _khoitao = new ketnoibarcode();
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

        #region kiemhang
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
        #endregion
    }
}
