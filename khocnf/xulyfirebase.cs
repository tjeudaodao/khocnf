using Firebase.Storage;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace khocnf
{
    class xulyfirebase
    {
        // khoitao
        public static string duongdan = Application.StartupPath + @"\";
        public static IFirebaseClient clientFirebase;
        public static IFirebaseConfig configFirebase = new FirebaseConfig
        {
            AuthSecret = "w2evy6pLiTOlWdsl3ZJ40eJ1qvCkCrFGUecs2kou",
            BasePath = "https://danhmucvm-cnf.firebaseio.com/"
        };
        public static JObject jo = JObject.Parse(File.ReadAllText("capnhat.json"));
        // class
        

        // lang nghe co ban dbbarcode khong
        public static async void langnghe(Label lbcapnhatngay, Form ff)
        {
            clientFirebase = new FireSharp.FirebaseClient(configFirebase);
            EventStreamResponse response = await clientFirebase.OnAsync("capnhat/capnhatdbbarcode/phienban",
                changed:
                (sender, args, context) => {
                    taifiledbbarcode(args.Data, lbcapnhatngay, ff);
                });
        }
        public static async Task<string> layPhienbanbarcode()
        {
            clientFirebase = new FireSharp.FirebaseClient(configFirebase);
            FirebaseResponse lay =await clientFirebase.GetAsync("capnhat/capnhatdbbarcode");
            capnhatbarcode kq = lay.ResultAs<capnhatbarcode>();
            return kq.phienban;
        }
        public static async Task<string> layngaybarcode()
        {
            clientFirebase = new FireSharp.FirebaseClient(configFirebase);
            FirebaseResponse lay = await clientFirebase.GetAsync("capnhat/capnhatdbbarcode");
            capnhatbarcode kq = lay.ResultAs<capnhatbarcode>();
            return kq.ngay;
        }
        public static async void taifiledbbarcode(string phienbanSV, Label lbngaycapnhat, Form ff)
        {
            
            string tenfile = @"databarcode.db";
            var task = new FirebaseStorage("danhmucvm-cnf.appspot.com")
                    .Child("database")
                    .Child(tenfile)
                    .GetDownloadUrlAsync();
            string link = await task;
            
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(link, "databarcode.db");
                    jo["dbbarcode"]["phienban_cl"] = phienbanSV;
                    jo["dbbarcode"]["phienban_sv"] = phienbanSV;
                    string output = JsonConvert.SerializeObject(jo, Formatting.Indented);
                    File.WriteAllText("capnhat.json", output);

                    string ngay = await layngaybarcode();
                    lbngaycapnhat.Invoke(new MethodInvoker(delegate ()
                    {
                        lbngaycapnhat.Text = ngay;
                    }));
                    ff.Invoke(new MethodInvoker(delegate ()
                   {
                       hamtao.notifi_hts("Vừa cập nhật bảng Barcode mới\nDữ liệu ngày: " + ngay, 3);
                   }));
                }
                catch (Exception)
                {
                    jo["dbbarcode"]["phienban_cl"] = "0";
                    jo["dbbarcode"]["phienban_sv"] = phienbanSV;
                    string output = JsonConvert.SerializeObject(jo, Formatting.Indented);
                    File.WriteAllText("capnhat.json", output);
                    return;
                }
                
            }
        }
    }
}
