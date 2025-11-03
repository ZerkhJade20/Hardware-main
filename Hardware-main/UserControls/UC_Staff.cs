using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_main.UserControls
{
    public partial class UC_Staff : UserControl
    {
        public UC_Staff()
        {
            InitializeComponent();
            panelAddNewStaff.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panelAddNewStaff.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panelAddNewStaff.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panelAddNewStaff.Hide();
        }
    }
}
