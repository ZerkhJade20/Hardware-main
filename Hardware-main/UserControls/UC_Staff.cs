using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hardware_main.UserControls
{
    public partial class UC_Staff : UserControl
    {
        public UC_Staff()
        {
            InitializeComponent();
            LoadStaffList();
            txtSearchInStaffs.TextChanged += (s, e) => SearchStaff(txtSearchInStaffs.Text);


            panelAddNewStaff.Hide();
        }
        private void LoadStaffList()
        {
            dgvStaff.DataSource = DBHelper.ExecuteSelect("SELECT * FROM tblStaff");
        }

        private void SearchStaff(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                LoadStaffList();
                return;
            }

            string sql = @"SELECT * FROM tblStaff WHERE Name LIKE @filter OR PhoneNumber LIKE @filter OR Email LIKE @filter OR Location LIKE @filter";
            dgvStaff.DataSource = DBHelper.ExecuteSelect(sql, new SqlParameter("@filter", "%" + filter + "%"));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panelAddNewStaff.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStaffName.Text))
            {
                MessageBox.Show("Enter name.");
                return;
            }
            string sql = @"INSERT INTO tblStaff (Name, Position, PhoneNumber, Email, Location, HireDate, Status) 
                       VALUES (@Name, @Position, @Phone, @Email, @Location, @HireDate, @Status)";
            var parameters = new[]
            {
            new SqlParameter("@Name", txtStaffName.Text.Trim()),
            new SqlParameter("@Position", cmbStaffPosition.Text),
            new SqlParameter("@Phone", txtStaffPhone.Text.Trim()),
            new SqlParameter("@Email", txtStaffEmail.Text.Trim()),
            new SqlParameter("@Location", txtStaffLocation.Text.Trim()),
            new SqlParameter("@HireDate", dtpStaffHireDate.Value),
            new SqlParameter("@Status", cmbStaffStatus.Text)
        };
            DBHelper.ExecuteNonQuery(sql, parameters);
            LoadStaffList();
            MessageBox.Show("Staff added.");

            panelAddNewStaff.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panelAddNewStaff.Hide();
        }

        private void UC_Staff_Load(object sender, EventArgs e)
        {
            cmbStaffPosition.Items.AddRange(new object[]
           {
                "Worker",
                
           });
            cmbStaffStatus.Items.AddRange(new object[]
           {
                "Active",
                "In Active"
           });
        }

        private void dgvStaff_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header row or invalid rows
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Ignore the new row placeholder
            if (dgvStaff.Rows[e.RowIndex].IsNewRow)
                return;
            var row = dgvStaff.Rows[e.RowIndex];

            int id = Convert.ToInt32(row.Cells["StaffID"].Value);
            string name = row.Cells["Name"].Value?.ToString();
            string position = row.Cells["Position"].Value?.ToString();
            string phone = row.Cells["PhoneNumber"].Value?.ToString();
            string email = row.Cells["Email"].Value?.ToString();
            string location = row.Cells["Location"].Value?.ToString();
            DateTime hireDate = Convert.ToDateTime(row.Cells["HireDate"].Value);
            string status = row.Cells["Status"].Value?.ToString();

            string sql = @"UPDATE tblStaff 
                   SET Name=@Name, Position=@Position, PhoneNumber=@Phone, 
                       Email=@Email, Location=@Location, 
                       HireDate=@HireDate, Status=@Status 
                   WHERE StaffID=@ID";
            SqlParameter[] parameters =
   {
        new SqlParameter("@ID", id),
        new SqlParameter("@Name", name),
        new SqlParameter("@Position", position),
        new SqlParameter("@Phone", phone),
        new SqlParameter("@Email", email),
        new SqlParameter("@Location", location),
        new SqlParameter("@HireDate", hireDate),
        new SqlParameter("@Status", status)
    };

            DBHelper.ExecuteNonQuery(sql, parameters);
        }

        private void dgvStaff_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Delete this staff member?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
            else
            {
                int id = Convert.ToInt32(e.Row.Cells["StaffID"].Value);
                DBHelper.ExecuteNonQuery("DELETE FROM tblStaff WHERE StaffID=@ID", new SqlParameter("@ID", id));
            }

        }
    }
}
