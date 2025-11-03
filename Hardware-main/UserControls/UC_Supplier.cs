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
    public partial class UC_Supplier : UserControl
    {
        public UC_Supplier()
        {
            InitializeComponent();
            panelAddNewSupplier.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_Supplier_Load(object sender, EventArgs e)
        {

        }

        private void btnAddNewSupplier_Click(object sender, EventArgs e)
        {
            panelAddNewSupplier.Show();

        }

        private void btnAddSupp_Click(object sender, EventArgs e)
        {
            panelAddNewSupplier.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelAddNewSupplier.Hide();
        }
    }
}
