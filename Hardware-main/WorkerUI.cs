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
    public partial class WorkerUI : Form
    {
        public WorkerUI()
        {
            InitializeComponent();
            UC_Products uC_Products = new UC_Products();
            addUserControl(uC_Products);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelWorkerContainer.Controls.Clear();
            panelWorkerContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Products uC_Products = new UC_Products();
            addUserControl(uC_Products);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_Cart uC_Cart = new UC_Cart();
            addUserControl(uC_Cart);
        }
    }
}
