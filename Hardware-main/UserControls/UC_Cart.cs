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
            // Add the Remove button column to the DataGridView
            if (dgvCart.Columns["Remove"] == null)
            {
                DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
                removeButtonColumn.Name = "Remove";
                removeButtonColumn.HeaderText = "Remove";
                removeButtonColumn.Text = "Remove";
                removeButtonColumn.UseColumnTextForButtonValue = true;
                dgvCart.Columns.Add(removeButtonColumn);
            }
        }
           // Fix for circular dependency
        public void SetProducts(UC_Products products)
        {
            _products = products;
            
            // Note: RefreshCart is called separately in UC_Products after this
        }
        // Method called by UC_Products to add an item to the cart (inserts into DB)
        public void AddItemToCart(int productId, string productName, decimal price)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string insertQuery = "INSERT INTO Cart (ProductID, Name, Price, Quantity) VALUES (@ProductID, @Name, @Price, 1)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@Name", productName);
                        cmd.Parameters.AddWithValue("@Price", price);
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
                    string query = "SELECT ID, ProductID, Name, Price, Quantity FROM Cart";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvCart.DataSource = dt;
                    }
                }
                // IMPORTANT — update total amount here
                UpdateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing cart: {ex.Message}");
            }
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
            if (dgvCart.Columns[e.ColumnIndex].Name == "Remove" && e.RowIndex >= 0)
            {
                // Get the Cart row ID
                int cartId = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["ID"].Value);
                int productId = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["ProductID"].Value);

                try
                {
                    // 1. Delete ONLY this row
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string deleteQuery = "DELETE FROM Cart WHERE ID = @ID";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@ID", cartId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 2. Increase stock
                    IncreaseProductQuantity(productId, 1);

                    // 3. Refresh views
                    RefreshCart();
                    _products.LoadProducts();

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
    }
}
