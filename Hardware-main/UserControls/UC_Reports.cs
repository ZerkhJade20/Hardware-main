using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace Hardware_main.UserControls
{

    public partial class UC_Reports : UserControl
    {
        private PrintDocument printDocument;
        private System.Collections.Generic.List<TabPage> tabsToPrint;
        private int currentTabIndex;
        public UC_Reports()
        {
            InitializeComponent();
            btnPrint.Click += BtnPrint_Click;
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {

        }

        private void UC_Reports_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
