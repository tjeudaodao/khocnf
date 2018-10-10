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
using Microsoft.Office.Interop;
using excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            pop.Click += Pop_Click;
            pop.Popup();
        }

        private static void Pop_Click(object sender, EventArgs e)
        {
            if (duongdanfileexcel != null)
            {
                var app = new excel.Application();

                excel.Workbooks book = app.Workbooks;
                excel.Workbook sh = book.Open(duongdanfileexcel);
                app.Visible = true;
            }
        }

        public static void tudongnhaydenmasp(DataGridView dtv, string masp)
        {
            try
            {
                if (dtv.RowCount < 1)
                {
                    return;
                }
                for (int i = 0; i < dtv.RowCount - 1; i++)
                {
                    if (masp == dtv.Rows[i].Cells[0].Value.ToString())
                    {
                        dtv.FirstDisplayedScrollingRowIndex = i;
                        dtv.Rows[i].Selected = true;
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
            
        }
        public static void tudongnhaydenmasp(DataGridView dtv, string masp,int kihieu)
        {
            try
            {
                if (dtv.RowCount < 1)
                {
                    return;
                }
                if (kihieu == 2)
                {
                    masp = masp.Substring(0, 15);
                }
                else if (kihieu == 3)
                {
                    masp = masp.Substring(0, 9);
                }
                for (int i = 0; i < dtv.RowCount - 1; i++)
                {
                    if (masp == dtv.Rows[i].Cells[0].Value.ToString())
                    {
                        dtv.FirstDisplayedScrollingRowIndex = i;
                        dtv.Rows[i].Selected = true;
                    }
                }
            }
            catch (Exception)
            {

                return;
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
        public static int ConvertToInt(string Value)
        {
            if (Value == null)
            {
                return 0;
            }
            else
            {
                int OutVal;
                int.TryParse(Value, out OutVal);

                if (!int.TryParse(Value, out OutVal))
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
        public static string ThongbaoketquaSosanh(DataTable bangdasosanhroi)
        {
            string ketqua = "";
            foreach (DataRow row in bangdasosanhroi.Rows)
            {
                if (row[4].ToString() != "OK")
                {
                    string ma;
                    if (row[0].ToString() == "")
                    {
                        ma = row[2].ToString();
                    }
                    else ma = row[0].ToString();
                    ketqua += "- " + ma + " --> " + row[4].ToString() + "\n";
                }
            }
            if (ketqua == "")
            {
                ketqua = "OK, nuột";
            }
            return ketqua;
        }
        public static void AmthanhSosanh(DataTable bangdasosanhroi)
        {
            foreach (DataRow row in bangdasosanhroi.Rows)
            {
                if (row[4].ToString() != "OK")
                {
                    amthanh.phatbaoLech();
                    return;
                }
            }
            amthanh.phatDu();
        }
        #region chuyenhang
        public static string duongdanfileexcel = "";
        public static string layduongdan()
        {
            return Path.GetDirectoryName(duongdanfileexcel);
        }
        public static void TaofileJSON(Dictionary<string,string> json)
        {
            string h = JsonConvert.SerializeObject(json, Formatting.Indented);
            File.WriteAllText("dulieucopy.json", h);
        }
        public static DataTable layvungcopy(Label lbsoluongcannhat)
        {
            DataTable dt = new DataTable();
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {

                dt.Columns.Add("Mã SP: '" + layngaygiohientai() + "'");
                dt.Columns.Add("SL");
                dt.AcceptChanges();
                string goc = o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray());
                string mau = @"\d\w{2}\d{2}[SWACswac]\d{3}-\w{2}\d{3}-\w+\s+\d+"; // loc theo ma chi tiet
                string mau1 = @"\d\w{2}\d{2}[SWACswac]\d{3}-\w{2}\d{3}\s+\d+"; // loc theo ma mau
                string mau1_1 = @"(?<matong>\d\w{2}\d{2}[SWACswac]\d{3}\s+.*)"; // loc theo ma tong
                string mau2 = @"\s+";
                
                string key;
                string value;
                Dictionary<string, string> gt = new Dictionary<string, string>();

                if (Regex.IsMatch(goc, mau))
                {
                    MatchCollection matchhts = Regex.Matches(goc, mau);
                    foreach (Match h in matchhts)
                    {
                        DataRow rowadd = dt.NewRow();
                        string[] hang = Regex.Split(h.Value.ToString(), mau2);
                        key = hang[0].ToUpper();
                        value = hang[1].TrimEnd();
                        rowadd[0] = key;
                        rowadd[1] = value;
                        dt.Rows.Add(rowadd);
                        if (gt.ContainsKey(key))
                        {
                            gt[key] = (int.Parse(gt[key].ToString()) + int.Parse(value)).ToString();
                            continue;
                        }

                        gt.Add(key, value);
                    }
                    TaofileJSON(gt);
                    var sl = gt.Sum(x => int.Parse(x.Value));
                    lbsoluongcannhat.Text = sl.ToString();
                }
                else if (Regex.IsMatch(goc, mau1))
                {
                    MatchCollection matchmamau = Regex.Matches(goc, mau1);
                    foreach (Match h1 in matchmamau)
                    {

                        string[] hang = Regex.Split(h1.Value.ToString(), mau2);

                        DataRow rowadd = dt.NewRow();
                        key = hang[0].ToUpper();
                        value = hang[1].TrimEnd();
                        rowadd[0] = key;
                        rowadd[1] = value;
                        dt.Rows.Add(rowadd);
                        if (gt.ContainsKey(key))
                        {
                            gt[key] = (int.Parse(gt[key].ToString()) + int.Parse(value)).ToString();
                            continue;
                        }

                        gt.Add(key, value);
                    }
                    TaofileJSON(gt);

                    var sl = gt.Sum(x => int.Parse(x.Value));
                    lbsoluongcannhat.Text = sl.ToString();
                }
                else if (Regex.IsMatch(goc, mau1_1))
                {
                    MatchCollection matchmatong_1 = Regex.Matches(goc, mau1_1);
                    foreach (Match mm in matchmatong_1)
                    {
                        string[] hang = Regex.Split(mm.Groups["matong"].Value.ToString(), mau2);
                        key = hang[0].ToUpper();
                        value = hang[1].TrimEnd();
                        DataRow rowadd = dt.NewRow();
                        rowadd[0] = key;
                        rowadd[1] = value;
                        dt.Rows.Add(rowadd);

                        if (gt.ContainsKey(key))
                        {
                            if (Regex.IsMatch(value, @"^\d+$"))
                            {
                                gt[key] = (int.Parse(gt[key].ToString()) + int.Parse(value)).ToString();
                            }
                            continue;
                        }
                        gt.Add(key, value);
                    }
                    TaofileJSON(gt);
                    try
                    {
                        var sl = gt.Sum(x => int.Parse(x.Value));
                        lbsoluongcannhat.Text = sl.ToString();
                    }
                    catch (Exception)
                    {

                        lbsoluongcannhat.Text = "Nhặt dứt";
                    }

                }
                
            }
            return dt;
        }
        public static bool KiemtraFileJSON()
        {
            bool kq = false;
            if (!File.Exists("dulieucopy.json"))
            {
                return kq;
            }

            return kq;
        }
        public static void taovainfileexcel(DataTable dt,string tongsp,int sobanin = 1)
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
            for (int i = 0; i < sobanin; i++)
            {
                sh.PrintOutEx();
            }
            
            book.Close();
            app.Quit();
        }
        public static bool xuatfile(DataTable dtmachitiet,DataTable dtmatong, string tongsp,string noinhan,string tencuahang)
        {
            bool kq = false;
            string tenfile = DateTime.Now.ToString("dd-MM");
            if (string.IsNullOrEmpty(noinhan))
            {
                noinhan = "-";
            }
            Random dr = new Random();
            string ver = " " + dr.Next(1, 10).ToString();
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (.xlsx)|*.xlsx";
                saveDialog.FileName = noinhan + "-" + tongsp + "sp" +"-"+ tencuahang+ "-ĐC ngày " + tenfile +ver;
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    duongdanfileexcel = Path.GetFullPath(saveDialog.FileName);
                    kq = true;
                    string exportFilePath = saveDialog.FileName;
                    var newFile = new FileInfo(exportFilePath);
                    using (var package = new ExcelPackage(newFile))
                    {

                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(tencuahang+ "_Điều chuyển_"+tongsp+"sp");

                        worksheet.Cells["A1"].Value = tencuahang + " _ Điều chuyển";
                        worksheet.Cells["A2"].Value = "Đến : " + noinhan;
                        worksheet.Cells["A3"].Value = "Ngày tạo : " + DateTime.Now.ToString("dd-MM-yyyy");
                        worksheet.Cells["A4"].Value = "Tổng SP : " + tongsp + " sp";
                        worksheet.Cells["A6"].LoadFromDataTable(dtmachitiet, true, OfficeOpenXml.Table.TableStyles.Light1);

                        worksheet.Cells["E6"].LoadFromDataTable(dtmatong, true, OfficeOpenXml.Table.TableStyles.Light1);
                        worksheet.Cells[worksheet.Dimension.End.Row + 1, 1].Value = "Tổng sản phẩm:";
                        worksheet.Cells[worksheet.Dimension.End.Row, 3].Value = Int32.Parse(tongsp);
                        worksheet.Column(1).AutoFit();
                        worksheet.Column(2).AutoFit();
                        worksheet.Column(5).AutoFit();
                        package.Save();

                    }
                }
            }
            return kq;
        }
        public static void taovainfileexcelchuyenhang(DataTable dt, string tongsp,string noinhan,string tencuahang)
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet worksheet = ExcelPkg.Workbook.Worksheets.Add("hts");
            worksheet.Cells["A1"].Value = tencuahang + " _ Điều chuyển";
            worksheet.Cells["A2"].Value = "Đến : " +noinhan;
            worksheet.Cells["A3"].Value = "Ngày tạo : " + DateTime.Now.ToString("dd-MM-yyyy");
            worksheet.Cells["A4"].Value = "Tổng SP : " + tongsp +" sp";
            worksheet.Cells["A6"].LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.Light1);

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
        public static void taovainfileexceltheoPhieu(DataTable dt, string sophieu, string noidung,string soluong,string ngay)
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet worksheet = ExcelPkg.Workbook.Worksheets.Add("hts");
            worksheet.Cells["A1"].Value ="Số phiếu: "+ sophieu ;
            worksheet.Cells["A2"].Value ="Nội dung: "+ noidung;
            worksheet.Cells["A3"].Value ="Tổng SL: "+ soluong +"sp";
            worksheet.Cells["A4"].Value ="Ngày/Phiếu: "+ ngay;

            worksheet.Cells["A6"].LoadFromDataTable(dt, true, OfficeOpenXml.Table.TableStyles.Light1);

            worksheet.Column(1).Width = 28;
            worksheet.Column(2).Width = 4;
            
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
        #endregion

        #region xuly thugon

        #endregion
    }
}
