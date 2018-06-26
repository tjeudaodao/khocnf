using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using Excel =Microsoft.Office.Interop.Excel;
using OfficeOpenXml.Drawing;
using Tulpep.NotificationWindow;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using Microsoft.Office.Interop;
using excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.IO;
namespace khocnf
{
    class hamtao
    {
        public static void notifi_hts(string noidung)
        {
            PopupNotifier pop = new PopupNotifier();
            pop.TitleText = "Thông báo";
            pop.ContentText = "\" " + noidung + " \"";
            pop.Image = Properties.Resources.totoro;
            pop.IsRightToLeft = false;
            pop.TitleColor = System.Drawing.Color.Navy;
            pop.TitleFont = new System.Drawing.Font("Comic Sans MS", 9, System.Drawing.FontStyle.Underline);
            pop.BodyColor = System.Drawing.Color.DimGray;
            pop.Size = new System.Drawing.Size(380, 130);
            pop.ImageSize = new System.Drawing.Size(100, 100);
            pop.ImagePadding = new Padding(15);
            pop.ContentColor = System.Drawing.Color.White;
            pop.ContentFont = new System.Drawing.Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            pop.Delay = 2000;
            pop.BorderColor = System.Drawing.Color.DimGray;
            pop.HeaderHeight = 1;
            pop.Popup();
        }
        public static void notifi_hts(string noidung, int sogiayhienthi)
        {
            PopupNotifier pop = new PopupNotifier();
            pop.TitleText = "Thông báo";
            pop.ContentText = "\" " + noidung + " \"";
            pop.Image = Properties.Resources.totoro;
            pop.IsRightToLeft = false;
            pop.TitleColor = System.Drawing.Color.Navy;
            pop.TitleFont = new System.Drawing.Font("Comic Sans MS", 9, System.Drawing.FontStyle.Underline);
            pop.BodyColor = System.Drawing.Color.DimGray;
            pop.Size = new System.Drawing.Size(380, 130);
            pop.ImageSize = new System.Drawing.Size(100, 100);
            pop.ImagePadding = new Padding(15);
            pop.ContentColor = System.Drawing.Color.White;
            pop.ContentFont = new System.Drawing.Font("Comic Sans MS", 10, System.Drawing.FontStyle.Bold);
            pop.Delay = sogiayhienthi *1000;
            pop.BorderColor = System.Drawing.Color.DimGray;
            pop.HeaderHeight = 1;
            pop.Popup();
        }
        public static void tudongnhaydenmasp(DataGridView dtv, string masp)
        {
            if (dtv.RowCount < 1)
            {
                return;
            }
            for (int i = 0; i < dtv.RowCount -1; i++)
            {
                if (masp == dtv.Rows[i].Cells[0].Value.ToString())
                {
                    dtv.FirstDisplayedScrollingRowIndex = i;
                    dtv.Rows[i].Selected = true;
                }
            }
        }
        public static double ConvertToDouble(string Value)
        {
            if (Value == null)
            {
                return 0;
            }
            else
            {
                double OutVal;
                double.TryParse(Value, out OutVal);

                if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
                {
                    return 0;
                }
                return OutVal;
            }
        }
        public static string layngaygiohientai()
        {
            return DateTime.Now.ToString("dd/MM/yy-HH:mm");
        }
        public static DataTable bangdasosanh(DataTable dt)
        {
            double chechlech = 0;
            dt.Columns.Add("Status");
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i <= 4; i++)
                {
                    if (row[3].ToString() == "")
                    {
                        row[4] = "Ngoài đơn";
                        continue;
                    }
                    chechlech = ConvertToDouble(row[1].ToString()) - ConvertToDouble(row[3].ToString());
                    if (chechlech > 0)
                    {
                        row[4] = "Thừa: " + chechlech + "";
                    }
                    else if (chechlech == 0)
                    {
                        row[4] = "OK";
                    }
                    else if (chechlech < 0)
                    {
                        row[4] = "Thiếu: " + chechlech + "";
                    }
                }
            }
            return dt;
        }

        #region chuyenhang
        public static string duongdanfileexcel = "";
        public static string layduongdan()
        {
            return duongdanfileexcel;
        }
        public static DataTable layvungcopy()
        {
            DataTable dt = new DataTable();
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {

                dt.Columns.Add("Mã SP: '" + layngaygiohientai() + "'");
                dt.Columns.Add("SL");
                dt.AcceptChanges();
                string goc = o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray());
                string mau = @"\d\w{2}\d{2}[SWAC]\d{3}-\w{2}\d{3}-\w+\s+\d+";
                //string mau1 = @"\d\w{2}\d{2}[SWAC]\d{3}\s+\w+";
                string mau1_1 = @"(?<matong>\d\w{2}\d{2}[SWAC]\d{3}\s+.*)";
                string mau2 = @"\s+";
                MatchCollection matchhts = Regex.Matches(goc, mau);
                //MatchCollection matchmatong = Regex.Matches(goc, mau1);
                MatchCollection matchmatong_1 = Regex.Matches(goc, mau1_1);
                foreach (Match h in matchhts)
                {

                    string[] hang = Regex.Split(h.Value.ToString(), mau2);

                    DataRow rowadd = dt.NewRow();
                    for (int i = 0; i < hang.Length; i++)
                    {

                        rowadd[i] = hang[i];

                    }
                    dt.Rows.Add(rowadd);
                }
                //foreach (Match h in matchmatong)
                //{
                //    string[] hang = Regex.Split(h.Value.ToString(), mau2);

                //    DataRow rowadd = dt.NewRow();
                //    for (int i = 0; i < hang.Length; i++)
                //    {

                //        rowadd[i] = hang[i];

                //    }
                //    dt.Rows.Add(rowadd);
                //}
                foreach (Match mm in matchmatong_1)
                {
                    string[] hang = Regex.Split(mm.Groups["matong"].Value.ToString(), mau2);

                    DataRow rowadd = dt.NewRow();
                    rowadd[0] = hang[0];
                    string hh = null;
                    for (int i = 1; i < hang.Length; i++)
                    {

                        hh += hang[i] +" ";

                    }
                    rowadd[1] = hh;
                    dt.Rows.Add(rowadd);
                }
            }
            return dt;
        }
        public static void taovainfileexcel(DataTable dt,string tongsp)
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet worksheet = ExcelPkg.Workbook.Worksheets.Add("hts");
            worksheet.Cells["A1"].LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.Light1);

            worksheet.Column(1).Width = 28;
            worksheet.Column(2).Width = 4;



            worksheet.Cells[worksheet.Dimension.End.Row + 1, 1].Value = "Tổng sản phẩm:";
            worksheet.Cells[worksheet.Dimension.End.Row, 2].Value = tongsp;

            var allCells = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];
            var cellFont = allCells.Style.Font;
            cellFont.SetFromFont(new Font("Calibri", 11));

            worksheet.PrinterSettings.LeftMargin = 0.2M / 2.54M;
            worksheet.PrinterSettings.RightMargin = 0.2M / 2.54M;
            worksheet.PrinterSettings.TopMargin = 0.2M / 2.54M;
            worksheet.Protection.IsProtected = false;
            worksheet.Protection.AllowSelectLockedCells = false;
            if (File.Exists("hts.xlsx"))
            {
                File.Delete("hts.xlsx");

            }
            ExcelPkg.SaveAs(new FileInfo("hts.xlsx"));
            ExcelPkg.Dispose();

            var app = new excel.Application();

            excel.Workbooks book = app.Workbooks;
            excel.Workbook sh = book.Open(Path.GetFullPath("hts.xlsx"));
            //app.Visible = true;
            sh.PrintOutEx();
            book.Close();
            app.Quit();
        }
        public static void xuatfile(DataTable dt, string tongsp,string noinhan)
        {
            string tenfile = DateTime.Now.ToString("dd-MM");
            if (string.IsNullOrEmpty(noinhan))
            {
                noinhan = "-";
            }
            Random dr = new Random();
            string ver = " " + dr.Next(1, 100).ToString();
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (.xlsx)|*.xlsx";
                saveDialog.FileName = noinhan + "-" + tongsp + "sp" +"-"+ "27LVL-ĐC ngày " + tenfile +ver;
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    duongdanfileexcel = Path.GetFullPath(saveDialog.FileName);
                    string exportFilePath = saveDialog.FileName;
                    var newFile = new FileInfo(exportFilePath);
                    using (var package = new ExcelPackage(newFile))
                    {

                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("27LVL_Điều chuyển_"+tongsp+"sp");

                        worksheet.Cells["A1"].LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.Light1);

                        worksheet.Cells[worksheet.Dimension.End.Row + 1, 1].Value = "Tổng sản phẩm:";
                        worksheet.Cells[worksheet.Dimension.End.Row, 3].Value = Int32.Parse(tongsp);
                        worksheet.Column(1).AutoFit();
                        worksheet.Column(2).AutoFit();
                        worksheet.PrinterSettings.LeftMargin = 0.2M / 2.54M;
                        worksheet.PrinterSettings.RightMargin = 0.2M / 2.54M;
                        package.Save();

                    }
                }
            }
        }
        public static void taovainfileexcelchuyenhang(DataTable dt, string tongsp,string noinhan)
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet worksheet = ExcelPkg.Workbook.Worksheets.Add("hts");
            worksheet.Cells["A1"].Value = "27 Lê Văn Lương _ Điều chuyển";
            worksheet.Cells["A2"].Value = "Đến :" +noinhan;
            worksheet.Cells["A4"].LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.Light1);

            worksheet.Column(1).Width = 28;
            worksheet.Column(2).Width = 4;



            worksheet.Cells[worksheet.Dimension.End.Row + 1, 1].Value = "Tổng sản phẩm:";
            worksheet.Cells[worksheet.Dimension.End.Row, 2].Value = tongsp;

            var allCells = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];
            var cellFont = allCells.Style.Font;
            cellFont.SetFromFont(new Font("Calibri", 10));

            worksheet.PrinterSettings.LeftMargin = 0.2M / 2.54M;
            worksheet.PrinterSettings.RightMargin = 0.2M / 2.54M;
            worksheet.PrinterSettings.TopMargin = 0.2M / 2.54M;
            worksheet.Protection.IsProtected = false;
            worksheet.Protection.AllowSelectLockedCells = false;
            if (File.Exists("hts.xlsx"))
            {
                File.Delete("hts.xlsx");

            }
            ExcelPkg.SaveAs(new FileInfo("hts.xlsx"));
            ExcelPkg.Dispose();

            var app = new excel.Application();

            excel.Workbooks book = app.Workbooks;
            excel.Workbook sh = book.Open(Path.GetFullPath("hts.xlsx"));
            //app.Visible = true;
            sh.PrintOutEx();
            book.Close();
            app.Quit();
        }
        public static DataTable tachdon(DataTable dtmasp, DataTable dtmatong)
        {
            foreach (DataRow row in dtmatong.Rows)
            {
                DataRow newrow = dtmasp.NewRow();
                newrow[0] = row[0];
                newrow[1] = row[1];
                dtmasp.Rows.Add(newrow);
            }
            return dtmasp;
        }
        #endregion
        #region tab tim kiem
        public static void xuatfileexceltabtimkiem(DataTable dtkiemhang,DataTable dtchuyenhang,DataTable dtchitietphieu, string ngay)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                Random dr = new Random();
                string ver = " " + dr.Next(1, 100).ToString();
                saveDialog.Filter = "Excel (.xlsx)|*.xlsx";
                saveDialog.FileName = "Thống kê đơn từ ngày " +ngay + ver;
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    duongdanfileexcel = Path.GetFullPath(saveDialog.FileName);
                    string exportFilePath = saveDialog.FileName;
                    var newFile = new FileInfo(exportFilePath);
                    using (var package = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Kiểm hàng");

                        worksheet.Cells["A1"].LoadFromDataTable(dtkiemhang, true, OfficeOpenXml.Table.TableStyles.Light1);
                        worksheet.Column(1).AutoFit();
                        worksheet.Column(2).AutoFit();
                        worksheet.Column(3).AutoFit();
                        worksheet.Column(4).AutoFit();

                        worksheet = package.Workbook.Worksheets.Add("Chuyển hàng");

                        worksheet.Cells["A1"].LoadFromDataTable(dtchuyenhang, true,OfficeOpenXml.Table.TableStyles.Light1);
                        worksheet.Column(1).AutoFit();
                        worksheet.Column(2).AutoFit();
                        worksheet.Column(3).AutoFit();
                        worksheet.Column(4).AutoFit();

                        worksheet = package.Workbook.Worksheets.Add("Chi tiết phiếu");

                        worksheet.Cells["A1"].LoadFromDataTable(dtchitietphieu, true, OfficeOpenXml.Table.TableStyles.Light1);
                        worksheet.Column(1).AutoFit();
                        worksheet.Column(2).AutoFit();
                        worksheet.Column(3).AutoFit();
                        worksheet.Column(4).AutoFit();
                        package.Save();

                    }
                }
            }
        }
        #endregion
    }
}
