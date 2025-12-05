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
            // 1. Create both controls with nulls
            cartControl = new UC_Cart(null);
            productsControl = new UC_Products(null);

            // 2. Connect them properly
            cartControl.SetProducts(productsControl);
            productsControl.SetCart(cartControl);

            // 3. Load product UI by default
            addUserControl(productsControl);
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
            addUserControl(productsControl);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            addUserControl(cartControl);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void WorkerUI_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
