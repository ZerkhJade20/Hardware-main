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
        private UC_Cart cartControl;
        private UC_Products productsControl;

        public WorkerUI()
        {
            InitializeComponent();
            cartControl = new UC_Cart();
            productsControl = new UC_Products(cartControl);

            addUserControl(productsControl);

            UC_Cart uC_Cart = new UC_Cart();
            UC_Products uC_Products = new UC_Products(uC_Cart);
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
            UC_Cart uC_Cart = new UC_Cart();
            UC_Products uC_Products = new UC_Products(uC_Cart);
            addUserControl(uC_Products);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_Cart uC_Cart = new UC_Cart();
            addUserControl(uC_Cart);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
