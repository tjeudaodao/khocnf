using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace khocnf
{
    class ghiloi
    {
        public static void ghilog_loi(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString("g") + ": " + ex.Source + "; " + ex.Message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

                return;
            }
        }
        public static void ghilog_loi(string loinhan)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString("g") + ": " + loinhan);
                sw.Flush();
                sw.Close();
            }
            catch
            {
                return;
            }
        }
    }
}
