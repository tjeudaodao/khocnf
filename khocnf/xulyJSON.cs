using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Data;

namespace khocnf
{
    class xulyJSON
    {
        public static JObject johts;
        public static JObject jotachdon;
        public xulyJSON()
        {
            johts = JObject.Parse(File.ReadAllText("dulieucopy.json"));
        }
        public xulyJSON(string tenfile)
        {
            jotachdon = JObject.Parse(File.ReadAllText(tenfile));
        }
        public JObject get()
        {
            return johts;
        }
        public JObject get(string tenfile)
        {
            return jotachdon;
        }
        public string laySL(string masp)
        {
            try
            {
                string kq;
                if (johts.ContainsKey(masp))
                {
                    kq = johts[masp].ToString();
                }
                else kq = "0";
                return kq;
            }
            catch (Exception)
            {
                return "0";
            }
           
            
        }
        public bool kiemtraDulieu()
        {
            bool kq = false;
            if (johts.Count > 0)
            {
                kq = true;
            }
            return kq;
        }
        public static void converttoDatatable(DataGridView dg)
        {
            var get = JsonConvert.DeserializeObject<Dictionary<string,string>>(File.ReadAllText("dulieucopy.json"));
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã SP");
            dt.Columns.Add("SL");
            dt.AcceptChanges();
            foreach (KeyValuePair<string,string> item in get)
            {
                DataRow dtr = dt.NewRow();
                dtr[0] = item.Key;
                dtr[1] = item.Value;
                dt.Rows.Add(dtr);
            }
            dg.DataSource = dt;
        }
        public static string tongsoluongValue()
        {
            var dicconvert = JsonConvert.DeserializeObject<Dictionary<string, string>>(johts.ToString());
            try
            {
                var sum = dicconvert.Sum(z => int.Parse(z.Value));
                return sum.ToString();
            }
            catch (Exception)
            {
                return "Nhặt dứt";
            }
           
        }
        public string tongsoluongValue(JObject jo)
        {
            var dicconvert = JsonConvert.DeserializeObject<Dictionary<string, string>>(jo.ToString());
            try
            {
                var sum = dicconvert.Sum(z => int.Parse(z.Value));
                return sum.ToString();
            }
            catch (Exception)
            {
                return "Nhặt dứt";
            }

        }
        public DataTable tachDON(DataGridView dtg,string tenfile,JObject jo)
        {
            string masp = null;
            string sl = null;
            for (int i = 0; i < dtg.RowCount - 1; i++)
            {
                masp = dtg.Rows[i].Cells[0].Value.ToString();
                sl = dtg.Rows[i].Cells[1].Value.ToString();
                int slgoc = int.Parse(jo[masp].ToString());
                
                string slupdate = (slgoc - int.Parse(sl)).ToString();
                if (int.Parse(slupdate) <= 0)
                {
                    jo.Property(masp).Remove();
                    continue;
                }
                jo[masp] = slupdate;
            }
            File.WriteAllText(tenfile, jo.ToString());

            var get = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(tenfile));
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã SP");
            dt.Columns.Add("SL");
            dt.AcceptChanges();
            foreach (KeyValuePair<string, string> item in get)
            {
                DataRow dtr = dt.NewRow();
                dtr[0] = item.Key;
                dtr[1] = item.Value;
                dt.Rows.Add(dtr);
            }
            return dt;
        }
        // phan doc file cap nhat
        public string ReadJSON(string key)
        {
            return (string)jotachdon[key];
        }
        public void UpdatevalueJSON(string key, string valuenew)
        {
            jotachdon[key] = valuenew;
            string output = JsonConvert.SerializeObject(jotachdon, Formatting.Indented);
            File.WriteAllText("config.json", output);
        }
        public void UpdatevalueJSON(string[,] mangNx2)
        {
            for (int i = 0; i < mangNx2.GetLength(0); i++)
            {
                string key = mangNx2[i, 0];
                string value = mangNx2[i, 1];
                jotachdon[key] = value;
            }
            string output = JsonConvert.SerializeObject(jotachdon, Formatting.Indented);
            File.WriteAllText("config.json", output);
        }
    }
}
