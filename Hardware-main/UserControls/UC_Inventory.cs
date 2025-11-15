using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hardware_main.UserControls
{
    public partial class UC_Inventory : UserControl
    {
        public event Action InventoryChanged;
        public UC_Inventory()
        {
            InitializeComponent();
            dgvInventory.CellContentClick += dataGridView1_CellContentClick;
            LoadInventoryList();
            txtSearchInInventory.TextChanged += (s, e) => LoadInventoryList(txtSearchInInventory.Text);

            guna2Panel4.Hide();
        }
        private void LoadInventoryList(string filter = "")
        {
            string sql = "SELECT * FROM tblItems";
            SqlParameter[] parameters = null;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sql += " WHERE ItemName LIKE @filter OR SKU LIKE @filter OR Category LIKE @filter";
                parameters = new[] { new SqlParameter("@filter", $"%{filter}%") };
            }
            dgvInventory.DataSource = DBHelper.ExecuteSelect(sql, parameters);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Panel4.Show();
            ClearNewItemForm();
        }
        private void ClearNewItemForm()
        {
            txtItemName.Clear();
            txtSKU.Clear();
            cmbCategory.SelectedIndex = -1;
            nudQuantity.Value = 0;
            nudPrice.Value = 0;
            nudReorder.Value = 0;
        }


        private void UC_Inventory_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.AddRange(new object[]
            {
                "Electronics",
                "Hardware",
                "Furniture",
                "Tools",
                "Accessories"
            });
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Validate required inputs
            if (string.IsNullOrWhiteSpace(txtItemName.Text) || string.IsNullOrWhiteSpace(txtSKU.Text) || cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Fill all required fields (name, SKU, category).");
                return;
            }
            string status = nudQuantity.Value > 0 ? "In Stock" : "Out of Stock";
            string sql = @"INSERT INTO tblItems (ItemName, SKU, Category, Quantity, Price, ReorderLevel, Status)
                       VALUES (@Name, @SKU, @Category, @Quantity, @Price, @ReorderLevel, @Status)";
            var parameters = new[]
        {
            new SqlParameter("@Name", txtItemName.Text.Trim()),
            new SqlParameter("@SKU", txtSKU.Text.Trim()),
            new SqlParameter("@Category", cmbCategory.Text),
            new SqlParameter("@Quantity", (int)nudQuantity.Value),
            new SqlParameter("@Price", nudPrice.Value),
            new SqlParameter("@ReorderLevel", (int)nudReorder.Value),
            new SqlParameter("@Status", status)
        };
            int rowsAffected = DBHelper.ExecuteNonQuery(sql, parameters);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Item added successfully.");
                guna2Panel4.Visible = false;
                LoadInventoryList();
                InventoryChanged?.Invoke();  // Notify worker UI to refresh
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel4.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure clicked column is Delete button column, e.g. "Delete"
            if (dgvInventory.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Confirm deletion
                if (MessageBox.Show("Delete this item?", "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                int itemId = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["ItemID"].Value);
                string sql = "DELETE FROM tblItems WHERE ItemID = @ItemID";
                try
                {
                    DBHelper.ExecuteNonQuery(sql, new SqlParameter("@ItemID", itemId));
                    // Remove row from DataGridView (refresh your grid instead for consistency)
                    LoadInventoryList();
                    InventoryChanged?.Invoke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        private void dgvInventory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dgvInventory.Rows[e.RowIndex];
            if (row.Cells["ItemID"].Value == null || row.Cells["ItemID"].Value == DBNull.Value)
                return;
            // Read updated values from the grid row
            int itemId = Convert.ToInt32(row.Cells["ItemID"].Value);
            string itemName = row.Cells["ItemName"].Value?.ToString() ?? "";
            string sku = row.Cells["SKU"].Value?.ToString() ?? "";
            string category = row.Cells["Category"].Value?.ToString() ?? "";
            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
            int reorderLevel = Convert.ToInt32(row.Cells["ReorderLevel"].Value);
            string status = quantity > 0 ? "In Stock" : "Out of Stock";

            string sql = @"UPDATE tblItems SET ItemName=@Name, SKU=@SKU, Category=@Category, Quantity=@Quantity,
                       Price=@Price, ReorderLevel=@ReorderLevel, Status=@Status WHERE ItemID=@ItemID";
            var parameters = new[]
            {
            new SqlParameter("@Name", itemName),
            new SqlParameter("@SKU", sku),
            new SqlParameter("@Category", category),
            new SqlParameter("@Quantity", quantity),
            new SqlParameter("@Price", price),
            new SqlParameter("@ReorderLevel", reorderLevel),
            new SqlParameter("@Status", status),
            new SqlParameter("@ItemID", itemId)
        };
            DBHelper.ExecuteNonQuery(sql, parameters);
            InventoryChanged?.Invoke();

        }
        private void dgvInventory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            

        }
    }
}

    
        


