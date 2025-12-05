using Guna.UI2.WinForms;
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

namespace Hardware_main.UserControls
{
    public partial class UC_Cart : UserControl
    {

        private string connectionString = "Data Source=ZERKH\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private UC_Products _products;  // Reference to UC_Products for refreshing
        public UC_Cart(UC_Products products)
        {
            InitializeComponent();
            
            _products = products;
            RefreshCart();
            
        }
           // Fix for circular dependency
        public void SetProducts(UC_Products products)
        {
            _products = products;
            
            // Note: RefreshCart is called separately in UC_Products after this
        }
        // Method called by UC_Products to add an item to the cart (inserts into DB)
        public void AddItemToCart(int productId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Check if item already exists in cart
                    string checkQuery = "SELECT Quantity FROM Cart WHERE ProductID = @ProductID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@ProductID", productId);
                        var result = checkCmd.ExecuteScalar();

                        if (result != null)
                        {
                            int qty = Convert.ToInt32(result) + 1;
                            string updateQuery = "UPDATE Cart SET Quantity = @qty WHERE ProductID = @ProductID";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                            {
                                updateCmd.Parameters.AddWithValue("@qty", qty);
                                updateCmd.Parameters.AddWithValue("@ProductID", productId);
                                updateCmd.ExecuteNonQuery();
                            }

                            return;
                        }
                    }

                    // Insert new cart item
                    string insertQuery = "INSERT INTO Cart (ProductID, Quantity) VALUES (@ProductID, 1)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to cart: {ex.Message}");
            }
        }


        // Method to refresh the cart's DataGridView from the database
        public void RefreshCart()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                                    SELECT 
                                        c.ID AS CartID,
                                        c.ProductID,
                                        i.ItemName,
                                        i.SKU,
                                        i.Category,
                                        i.Price,
                                        c.Quantity
                                    FROM Cart c
                                    INNER JOIN tblItems i ON c.ProductID = i.ItemID";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvCart.DataSource = dt;
                    }
                }

                // Remove duplicate Remove buttons if refreshing
                if (dgvCart.Columns.Contains("Remove"))
                    dgvCart.Columns.Remove("Remove");

                // Add Remove button column
                DataGridViewButtonColumn removeBtn = new DataGridViewButtonColumn();
                removeBtn.Name = "Remove";
                removeBtn.HeaderText = "Remove";
                removeBtn.Text = "Remove";
                removeBtn.UseColumnTextForButtonValue = true;
                dgvCart.Columns.Add(removeBtn);

                // Apply sizing
                SetupCartGridColumns();

                UpdateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing cart: " + ex.Message);
            }
        }

        private void SetupCartGridColumns()
        {
            if (dgvCart.Columns.Count == 0)
                return;

            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvCart.Columns["CartID"].Width = 70;
            dgvCart.Columns["ProductID"].Width = 80;
            dgvCart.Columns["ItemName"].Width = 264;
            dgvCart.Columns["SKU"].Width = 100;
            dgvCart.Columns["Category"].Width = 170;
            dgvCart.Columns["Price"].Width = 100;
            dgvCart.Columns["Quantity"].Width = 80;

            if (dgvCart.Columns.Contains("Remove"))
                dgvCart.Columns["Remove"].Width = 80;
        }




        private void UpdateTotalAmount()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["Price"].Value != null && row.Cells["Quantity"].Value != null)
                {
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    total += price * qty;
                }
            }

            lblTotal.Text = "Total Amount: ₱" + total.ToString("N2");
        }



        public void LoadCartItems()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, ProductID, Name, Price, Quantity FROM Cart";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCart.DataSource = dt;
            }

            UpdateTotalAmount();  // ← ADD THIS
        }


        private void UC_Cart_Load(object sender, EventArgs e)
        {

        }

        private void checkoutContainer_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Get total amount from label
                decimal totalAmount = 0m;
                string text = lblTotal.Text.Replace("Total Amount: ₱", "").Trim();
                decimal.TryParse(text, out totalAmount);

                if (totalAmount <= 0)
                {
                    MessageBox.Show("Cart is empty.");
                    return;
                }

                // 2️⃣ Insert transaction
                string insertSql = @"
            INSERT INTO tblTransactions (TotalAmount, DateCreated)
            VALUES (@amount, GETDATE())";

                DBHelper.ExecuteNonQuery(insertSql,
                    new SqlParameter("@amount", totalAmount)
                );

                // 3️⃣ Clear cart
                DBHelper.ExecuteNonQuery("DELETE FROM Cart");
                RefreshCart();

                MessageBox.Show("Checkout completed!");

                // 4️⃣ Update all user controls in frmMain
                UpdateParentFormControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Checkout failed: " + ex.Message);
            }
        }

        private void UpdateParentFormControls()
        {
            // Find parent form (frmMain)
            frmMain mainForm = this.FindForm() as frmMain;
            if (mainForm == null) return;

            // DASHBOARD
            if (mainForm.dashboardUC != null)
            {
                mainForm.dashboardUC.LoadTotalSales();
                mainForm.dashboardUC.LoadSalesChart();
            }

            // SALES & TRANSACTIONS
            if (mainForm.salesUC != null)
            {
                mainForm.salesUC.LoadTransactionSummary();
                mainForm.salesUC.LoadWeeklySalesChart();
            }

            // REPORTS
            if (mainForm.reportsUC != null)
            {
                mainForm.reportsUC.UpdateLabels();       // ✅ Your existing method
                mainForm.reportsUC.LoadTrendChart();     // Trend chart update
            }
        }





        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void lvCart_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks

            if (dgvCart.Columns[e.ColumnIndex].Name == "Remove")
            {
                int cartId = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["CartID"].Value);
                int productId = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["ProductID"].Value);

                try
                {
                    // 1. Delete only this row from Cart
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string deleteQuery = "DELETE FROM Cart WHERE ID = @CartID";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@CartID", cartId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 2. Optional: Restore stock in tblItems
                    IncreaseProductQuantity(productId, 1);

                    // 3. Refresh cart
                    RefreshCart();

                    MessageBox.Show("Item removed from cart and stock restored!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing from cart: {ex.Message}");
                }
            }
        }


        // Helper method to increase product quantity (reverse of DecreaseProductQuantity)
        private void IncreaseProductQuantity(int productId, int qty)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"
                    UPDATE tblItems 
                    SET Quantity = Quantity + @qty 
                    WHERE ItemID = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private int previousQuantity = 0;
        private void dgvCart_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCart.CurrentCell.ColumnIndex == dgvCart.Columns["Quantity"].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= Quantity_KeyPress;
                    tb.KeyPress += Quantity_KeyPress;
                }
            }
        }
        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private bool suppressEvent = false;

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCart.Columns[e.ColumnIndex].Name != "Quantity") return;

            try
            {
                var row = dgvCart.Rows[e.RowIndex];

                int cartId = Convert.ToInt32(row.Cells["CartID"].Value);
                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                int newQty = Convert.ToInt32(row.Cells["Quantity"].Value);

                if (newQty <= 0)
                {
                    MessageBox.Show("Quantity must be at least 1.");
                    row.Cells["Quantity"].Value = previousQuantity;
                    return;
                }

                int difference = newQty - previousQuantity;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // 1️⃣ Update Cart table
                    string updateCart = "UPDATE Cart SET Quantity = @Q WHERE ID = @CartID";
                    using (SqlCommand cmd = new SqlCommand(updateCart, con))
                    {
                        cmd.Parameters.AddWithValue("@Q", newQty);
                        cmd.Parameters.AddWithValue("@CartID", cartId);
                        cmd.ExecuteNonQuery();
                    }

                    // 2️⃣ Update tblItems stock based on difference
                    string updateItem = @"
                UPDATE tblItems 
                SET Quantity = Quantity - @difference 
                WHERE ItemID = @id";

                    using (SqlCommand cmd = new SqlCommand(updateItem, con))
                    {
                        cmd.Parameters.AddWithValue("@difference", difference);
                        cmd.Parameters.AddWithValue("@id", productId);
                        cmd.ExecuteNonQuery();
                    }
                }

                UpdateTotalAmount();
                previousQuantity = newQty; // set new baseline
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating quantity / stock: " + ex.Message);
            }
        }


        private void dgvCart_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvCart.Columns[e.ColumnIndex].Name == "Quantity")
            {
                previousQuantity = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["Quantity"].Value);
            }
        }
    }
}
