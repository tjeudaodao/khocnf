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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnchuyenhang_Click(object sender, EventArgs e)
        {
            panthaydoi.Top = btnchuyenhang.Top;
            btnchuyenhang.BackColor = Color.Gray;
            btnkiemhang.BackColor = Color.DimGray;
            btntimkiem.BackColor = Color.DimGray;
        }

        private void btnkiemhang_Click(object sender, EventArgs e)
        {
            panthaydoi.Top = btnkiemhang.Top;
            btnkiemhang.BackColor = Color.Gray;
            btnchuyenhang.BackColor = Color.DimGray;
            btntimkiem.BackColor = Color.DimGray;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            panthaydoi.Top = btntimkiem.Top;
            btntimkiem.BackColor = Color.Gray;
            btnchuyenhang.BackColor = Color.DimGray;
            btnkiemhang.BackColor = Color.DimGray;
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
