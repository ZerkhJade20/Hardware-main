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
        
        private DataTable cartItems = new DataTable();
        private DataTable cartTable;

        public UC_Cart()
        {
            InitializeComponent();

            // Initialize cart data table
            cartTable = new DataTable();
            cartTable.Columns.Add("ItemID", typeof(int));
            cartTable.Columns.Add("ProductName", typeof(string));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Total", typeof(decimal));

            // Bind table to dgvCart
            dgvCart.DataSource = cartTable;


        }
        private void UpdateTotalAmount()
        {
            decimal total = cartItems.AsEnumerable().Sum(row => row.Field<int>("Quantity") * row.Field<decimal>("Price"));
            lblTotalValue.Text = total.ToString("C2");
        }
        private void UC_Cart_Load(object sender, EventArgs e)
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ItemID", typeof(int));
            cartTable.Columns.Add("ItemName", typeof(string));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Total", typeof(decimal));

            dgvCart.DataSource = cartTable;
        }

        private void checkoutContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty!");
                return;
            }
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        var cmdTrans = new SqlCommand(@"INSERT INTO tblTransactions 
                          (CustomerName, TotalAmount, PaymentMethod, CreatedBy) VALUES (@cust, @total, @payment, @createdBy);
                          SELECT SCOPE_IDENTITY();", conn, tran);

                        cmdTrans.Parameters.AddWithValue("@cust", "Walk-in");
                        decimal totalAmount = cartItems.AsEnumerable().Sum(r => r.Field<int>("Quantity") * r.Field<decimal>("Price"));
                        cmdTrans.Parameters.AddWithValue("@total", totalAmount);
                        cmdTrans.Parameters.AddWithValue("@payment", "Cash");
                        cmdTrans.Parameters.AddWithValue("@createdBy", 1); // Set logged-in user id here

                        int newTransactionId = Convert.ToInt32(cmdTrans.ExecuteScalar());

                        foreach (DataRow row in cartItems.Rows)
                        {
                            int itemId = row.Field<int>("ItemID");
                            int qty = row.Field<int>("Quantity");

                            var cmdUpdateQty = new SqlCommand("UPDATE tblItems SET Quantity = Quantity - @qty WHERE ItemID = @itemId", conn, tran);
                            cmdUpdateQty.Parameters.AddWithValue("@qty", qty);
                            cmdUpdateQty.Parameters.AddWithValue("@itemId", itemId);
                            cmdUpdateQty.ExecuteNonQuery();

                            // Optionally insert transaction detail table if exists
                        }
                        tran.Commit();
                        MessageBox.Show("Checkout successful!");
                        cartItems.Clear();
                        UpdateTotalAmount();
                    }
                    // Notify Dashboard, Inventory, Sales, Reports, Worker UI to reload via event/callback
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Checkout failed: " + ex.Message);
                    }
                }
            }
            Checkout checkout = new Checkout();
            checkout.Show();

        }

        public void AddItemToCart(int id, string name, decimal price)
        {
            // 1. Check if the product already exists in cart
            DataRow existing = cartTable.Rows
                .Cast<DataRow>()
                .FirstOrDefault(r => Convert.ToInt32(r["ItemID"]) == id);

            if (existing != null)
            {
                // Update quantity
                int qty = Convert.ToInt32(existing["Quantity"]) + 1;
                existing["Quantity"] = qty;
                existing["Total"] = qty * price;
            }
            else
            {
                // Add new row
                cartTable.Rows.Add(id, name, price, 1, price);
            }
        }






        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotalAmount();

        }

        private void dgvCart_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                dgvCart.Rows.Remove(dgvCart.CurrentRow);
                UpdateTotalAmount();
            }

        }

        
    }
}
