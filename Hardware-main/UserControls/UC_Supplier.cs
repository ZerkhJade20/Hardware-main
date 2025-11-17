using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using UserControl = System.Windows.Forms.UserControl;

namespace Hardware_main.UserControls
{
    public partial class UC_Supplier : UserControl
    {
        public UC_Supplier()
        {
            InitializeComponent();
            LoadSupplierList();
            txtSearch.TextChanged += (s, e) => LoadSupplierList(txtSearch.Text);




            panelAddNewSupplier.Hide();

        }
        private void LoadSupplierList(string filter = "")
        {
            string sql = "SELECT * FROM tblSuppliers";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sql += " WHERE SupplierName LIKE @filter OR Location LIKE @filter OR Status LIKE @filter OR Phone LIKE @filter";
            }
            var dt = DBHelper.ExecuteSelect(sql, new SqlParameter("@filter", "%" + filter + "%"));
            dgvSupplier.DataSource = dt;
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
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Supplier Name required");
                return;
            }
            string sql = @"INSERT INTO tblSuppliers (SupplierName, Phone, Email, Location, Status, Rating) 
                       VALUES (@name, @phone, @email, @loc, @status, @rating)";
            var parameters = new[]
            {
            new SqlParameter("@name", txtSupplierName.Text.Trim()),
            new SqlParameter("@phone", txtPhone.Text.Trim()),
            new SqlParameter("@email", txtEmail.Text.Trim()),
            new SqlParameter("@loc", txtLocation.Text.Trim()),
            new SqlParameter("@status", cmbStatus.Text),
            new SqlParameter("@rating", (int)nudRating.Value)
        };
            DBHelper.ExecuteNonQuery(sql, parameters);
            LoadSupplierList();
            MessageBox.Show("Supplier added.");


            panelAddNewSupplier.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelAddNewSupplier.Hide();
        }

        private void dgvSupplier_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSupplier.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["SupplierID"].Value);
            string name = row.Cells["SupplierName"].Value?.ToString() ?? "";
            string phone = row.Cells["Phone"].Value?.ToString() ?? "";
            string email = row.Cells["Email"].Value?.ToString() ?? "";
            string loc = row.Cells["Location"].Value?.ToString() ?? "";
            string status = row.Cells["Status"].Value?.ToString() ?? "";
            int rating = Convert.ToInt32(row.Cells["Rating"].Value ?? 0);

            string sql = @"UPDATE tblSuppliers SET SupplierName=@name, Phone=@phone, Email=@email,
                       Location=@loc, Status=@status, Rating=@rating WHERE SupplierID=@id";
            var parameters = new SqlParameter[]
            {
            new SqlParameter("@name", name),
            new SqlParameter("@phone", phone),
            new SqlParameter("@email", email),
            new SqlParameter("@loc", loc),
            new SqlParameter("@status", status),
            new SqlParameter("@rating", rating),
            new SqlParameter("@id", id)
            };
            DBHelper.ExecuteNonQuery(sql, parameters);

        }

        private void dgvSupplier_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Delete this supplier?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
            else
            {
                var id = Convert.ToInt32(e.Row.Cells["SupplierID"].Value);
                DBHelper.ExecuteNonQuery("DELETE FROM tblSuppliers WHERE SupplierID=@id", new SqlParameter("@id", id));
            }

        }
    }
}
