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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmAdminLogin frmAdminLogin = new frmAdminLogin();
            frmAdminLogin.Show();
            this.Hide();
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            frmWorkerLogin frmWorkerLogin = new frmWorkerLogin();
            frmWorkerLogin.Show();
            this.Hide();
        }
    }
}
