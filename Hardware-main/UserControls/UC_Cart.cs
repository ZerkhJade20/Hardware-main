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
        private DataTable cartTable; // Internal table to hold cart items

        public UC_Cart()
        {
            InitializeComponent();
            InitializeCartTable();
            SetupListView();
        }

        // Initialize the DataTable for cart items (only called once in constructor)
        private void InitializeCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ItemID", typeof(int));
            cartTable.Columns.Add("ItemName", typeof(string));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Total", typeof(decimal)); // Calculated as Price * Quantity
            // Set primary key to enable Find() for existing items
            cartTable.PrimaryKey = new DataColumn[] { cartTable.Columns["ItemID"] };
        }

        // Set up the ListView (lvCart) - called in constructor
        private void SetupListView()
        {
            // Configure ListView properties (ensure View=Details in designer)
            lvCart.View = View.Details;
            lvCart.FullRowSelect = true;
            lvCart.GridLines = true;

            // Add columns
            lvCart.Columns.Add("ItemName", "Name", 150);
            lvCart.Columns.Add("Price", "Price", 100);
            lvCart.Columns.Add("Quantity", "Quantity", 80);
            lvCart.Columns.Add("Total", "Total", 100);
        }

        // Refresh the ListView by clearing and re-adding items from DataTable
        private void RefreshListView()
        {
            lvCart.Items.Clear();
            foreach (DataRow row in cartTable.Rows)
            {
                ListViewItem item = new ListViewItem(row["ItemName"].ToString());
                item.SubItems.Add(row["Price"].ToString());
                item.SubItems.Add(row["Quantity"].ToString());
                item.SubItems.Add(row["Total"].ToString());
                // Store ItemID in Tag for easy access (e.g., for removal)
                item.Tag = row["ItemID"];
                lvCart.Items.Add(item);
            }
        }

        // Method called by UC_Products to add an item to the cart
        public void AddItemToCart(int productId, string productName, decimal price)
        {
            // Debug: Confirm this method is called (remove in production)
            MessageBox.Show($"Adding to cart: ID={productId}, Name={productName}, Price={price}");
            try
            {
                // Check if the item already exists in the cart
                DataRow existingRow = cartTable.Rows.Find(productId);
                if (existingRow != null)
                {
                    // Increment quantity and update total
                    int currentQty = (int)existingRow["Quantity"];
                    existingRow["Quantity"] = currentQty + 1;
                    existingRow["Total"] = (decimal)existingRow["Price"] * (int)existingRow["Quantity"];
                }
                else
                {
                    // Add new row
                    DataRow newRow = cartTable.NewRow();
                    newRow["ItemID"] = productId;
                    newRow["ItemName"] = productName;
                    newRow["Price"] = price;
                    newRow["Quantity"] = 1;
                    newRow["Total"] = price * 1;
                    cartTable.Rows.Add(newRow);
                }
                // Refresh the ListView to reflect changes
                RefreshListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to cart: {ex.Message}");
            }
        }

        // Optional: Method to remove an item from the cart (called by btnRemove)
        public void RemoveItemFromCart(int productId)
        {
            try
            {
                DataRow rowToRemove = cartTable.Rows.Find(productId);
                if (rowToRemove != null)
                {
                    cartTable.Rows.Remove(rowToRemove);
                    RefreshListView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing from cart: {ex.Message}");
            }
        }

        // Optional: Clear the entire cart
        public void ClearCart()
        {
            cartTable.Clear();
            RefreshListView();
        }

        // Handle Remove button click (assumes btnRemove is added in designer next to lvCart)
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvCart.SelectedItems.Count > 0)
            {
                int productId = (int)lvCart.SelectedItems[0].Tag;
                RemoveItemFromCart(productId);
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void UC_Cart_Load(object sender, EventArgs e)
        {
           
        }

        private void checkoutContainer_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void lvCart_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
