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
    public partial class UC_Products : UserControl
    {
        public UC_Products()
        {
            InitializeComponent();
            AllProducts allProducts = new AllProducts();
            addUserControl(allProducts);


        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelProductsCon.Controls.Clear();
            panelProductsCon.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AllProducts allProducts = new AllProducts();
            addUserControl(allProducts);
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            Tools tool = new Tools();
            addUserControl(tool);

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            PaintandSupplies paintandSupplies = new PaintandSupplies();
            addUserControl(paintandSupplies);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Electrical electrical = new Electrical();
            addUserControl(electrical);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            plumbing plumbing = new plumbing();
            addUserControl(plumbing);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Lumber lumber = new Lumber();
            addUserControl(lumber);

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            SafetyEquipment safety = new SafetyEquipment();
            addUserControl(safety);
        }
    }
}
