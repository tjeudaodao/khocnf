using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace khocnf
{
    public partial class Form1 : Form
    {

        kiemhang uskiemhang = new kiemhang();
        chuyenhang uschuyenhang = new chuyenhang();
        timkiem ustimkiem = new timkiem();

        public Form1()
        {
            InitializeComponent();

            uskiemhang.Location = new Point(190, 30);
            uskiemhang.Name = "tabkiemhang";
            this.Controls.Add(uskiemhang);

            uschuyenhang.Location = new Point(190, 30);
            uschuyenhang.Name = "tabchuyenhang";
            this.Controls.Add(uschuyenhang);

            ustimkiem.Location = new Point(190, 30);
            ustimkiem.Name = "tabtimkiem";
            this.Controls.Add(ustimkiem);

            uschuyenhang.Hide();
            ustimkiem.Hide();
        }

        private void btnchuyenhang_Click(object sender, EventArgs e)
        {
            panthaydoi.Top = btnchuyenhang.Top;
            btnchuyenhang.BackColor = Color.Gray;
            btnkiemhang.BackColor = Color.DimGray;
            btntimkiem.BackColor = Color.DimGray;

            uschuyenhang.Show();
            uschuyenhang.BringToFront();
        }

        private void btnkiemhang_Click(object sender, EventArgs e)
        {
            panthaydoi.Top = btnkiemhang.Top;
            btnkiemhang.BackColor = Color.Gray;
            btnchuyenhang.BackColor = Color.DimGray;
            btntimkiem.BackColor = Color.DimGray;

            uskiemhang.Show();
            uskiemhang.BringToFront();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            panthaydoi.Top = btntimkiem.Top;
            btntimkiem.BackColor = Color.Gray;
            btnchuyenhang.BackColor = Color.DimGray;
            btnkiemhang.BackColor = Color.DimGray;

            ustimkiem.Show();
            ustimkiem.BringToFront();
        }

        private void pbminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
