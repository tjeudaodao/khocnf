using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace khocnf
{
    class xulyJSON
    {
        public  JObject johts;
        public xulyJSON()
        {
            johts = JObject.Parse(File.ReadAllText("dulieucopy.json"));
        }

        public string laySL(string masp)
        {
            string kq;
            if (johts.ContainsKey(masp))
            {
                kq = johts[masp].ToString();
            }
            else kq = "0";
            return kq;
            
        }
    }
}
