using Hardware_main.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
            UC_Dashboard uC_Dashboard = new UC_Dashboard();
            addUserControl(uC_Dashboard);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UC_Dashboard uC_Dashboard = new UC_Dashboard();
            addUserControl(uC_Dashboard);

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            UC_Inventory uC_Inventory = new UC_Inventory();
            addUserControl(uC_Inventory);
        }

        private void btnSalesTrans_Click(object sender, EventArgs e)
        {
            UC_SalesTrans uC_SalesTrans = new UC_SalesTrans();
            addUserControl(uC_SalesTrans);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            UC_Supplier uC_Supplier = new UC_Supplier();
            addUserControl(uC_Supplier);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            UC_Reports uC_Reports = new UC_Reports();
            addUserControl(uC_Reports);
        }

        private void btnStaffs_Click(object sender, EventArgs e)
        {
            UC_Staff uC_Staff = new UC_Staff();
            addUserControl(uC_Staff);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContainer_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            frmProfile frmProfile = new frmProfile();
            frmProfile.ShowDialog();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }
    }
}
