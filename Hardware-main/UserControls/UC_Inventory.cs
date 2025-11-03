using Guna.UI2.WinForms;
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
    public partial class UC_Inventory : UserControl
    {
        public UC_Inventory()
        {
            InitializeComponent();
            guna2Panel4.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            

            guna2Panel4.Show();

           

            

        }
       

        private void UC_Inventory_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            guna2Panel4.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel4.Hide();
        }
    }
}
