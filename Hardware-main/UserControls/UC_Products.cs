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
    public partial class UC_Products : UserControl
    {
        private UC_Cart _cart;
        private string connectionString = "Data Source=ZERKH\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public UC_Products(UC_Cart cart)
        {
            InitializeComponent();
            _cart = cart;
            LoadProducts();
        }
        // Fix for circular dependency
        public void SetCart(UC_Cart cart)
        {
            _cart = cart;
        }
        public void LoadProducts()
        {
            var dt = DBHelper.ExecuteSelect("SELECT * FROM tblItems WHERE Status='In Stock'");
            dgvProducts.DataSource = dt;
            // 4. Disable auto-size so we can manually set widths
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // 5. Apply fixed widths for 1800px DataGridView
            dgvProducts.Columns["ItemID"].Width = 70;
            dgvProducts.Columns["ItemName"].Width = 150;
            dgvProducts.Columns["SKU"].Width = 100;
            dgvProducts.Columns["Category"].Width = 70;
            dgvProducts.Columns["Quantity"].Width = 70;
            dgvProducts.Columns["Price"].Width = 90;
            dgvProducts.Columns["ReorderLevel"].Width = 50;
            dgvProducts.Columns["Status"].Width = 100;
            dgvProducts.Columns["DateAdded"].Width = 200;
        }
        

        public void SubscribeToInventory(UC_Inventory inventoryCtrl)
        {
            inventoryCtrl.InventoryChanged += () => LoadProducts();
        }
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









        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        { }

        private void btnTools_Click(object sender, EventArgs e)
        {
           

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Add" && e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ItemID"].Value);
                string productName = Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["ItemName"].Value);
                decimal price = Convert.ToDecimal(dgvProducts.Rows[e.RowIndex].Cells["Price"].Value);

                try
                {
                    // 1. Decrease quantity in database (only if sufficient stock)
                    int rowsAffected = DecreaseProductQuantity(productId, 1);
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Insufficient stock for this item.");
                        return;
                    }

                    // 2. Add item to cart (this now handles the DB insert in UC_Cart)
                    _cart.AddItemToCart(productId);

                    // 3. Refresh cart's DataGridView from database
                    _cart.RefreshCart();

                    // 4. Refresh product list
                    LoadProducts();

                    MessageBox.Show("Product added to cart!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding to cart: {ex.Message}");
                }
            }
        }
        private int DecreaseProductQuantity(int productId, int qty)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"
                    UPDATE tblItems 
                    SET Quantity = Quantity - @qty 
                    WHERE ItemID = @id AND Quantity >= @qty";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@id", productId);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        private void UC_Products_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LiveSearch(txtSearch.Text.Trim());
        }
        private void LiveSearch(string keyword)
        {
            string query = @"
        SELECT * FROM tblItems 
        WHERE Status='In Stock'
        AND (
            ItemName LIKE @key OR
            SKU LIKE @key OR
            Category LIKE @key
        )";

            var dt = DBHelper.ExecuteSelect(query, new SqlParameter("@key", "%" + keyword + "%"));
            dgvProducts.DataSource = dt;
        }
        public void LoadInventoryList()
        {
            var dt = DBHelper.ExecuteSelect("SELECT * FROM tblItems");
            dgvProducts.DataSource = dt;
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            RefreshProducts();
        }
        public void RefreshProducts()
        {
            LoadProducts();   // Reload from database
        }
    }
}
