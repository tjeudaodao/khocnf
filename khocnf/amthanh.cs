using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hamamthanh = System.Media.SoundPlayer;

namespace khocnf
{
    class amthanh
    {
        public static bool amluong(bool chay)
        {
            chayhaykhongchay = chay;
            return chay;
        }
        static bool chayhaykhongchay;
        static hamamthanh ambaolech = new hamamthanh(Application.StartupPath + "/amthanh/lech.wav");
        static hamamthanh ambaoloi = new hamamthanh(Properties.Resources.baoloi);
        static hamamthanh ammamoi = new hamamthanh(Properties.Resources.mamoi);
        static hamamthanh amNgoai = new hamamthanh(Properties.Resources.Ngoai);
        static hamamthanh amDu = new hamamthanh(Properties.Resources.Du);
        static hamamthanh amThua = new hamamthanh(Properties.Resources.Th_a);

        public static void phatbaoLech()
        {
            if (chayhaykhongchay)
            {
                ambaolech.Play();
            }
        }
        public static void phatbaoloi()
        {
            if (chayhaykhongchay)
            {
                ambaoloi.PlayLooping();
            }
        }
        public static void dungbaoloi()
        {
            ambaoloi.Stop();
        }
        public static void phatmamoi()
        {
            if (chayhaykhongchay)
            {
                ammamoi.Play();
            }
        }
        public static void phatNGoai()
        {
            if (chayhaykhongchay)
            {
                amNgoai.Play();
            }
        }
        public static void phatDu()
        {
            if (chayhaykhongchay)
            {
                amDu.Play();
            }
        }
        public static void phatThua()
        {
            if (chayhaykhongchay)
            {
                amThua.Play();
            }
        }
    }
}
