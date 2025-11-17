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

        public UC_Cart()
        {
            InitializeComponent();
            cartItems.Columns.Add("ItemID", typeof(int));
            cartItems.Columns.Add("ItemName", typeof(string));
            cartItems.Columns.Add("Quantity", typeof(int));
            cartItems.Columns.Add("Price", typeof(decimal));

            dgvCart.DataSource = cartItems;
            UpdateTotalAmount();


        }
        private void UpdateTotalAmount()
        {
            decimal total = cartItems.AsEnumerable().Sum(row => row.Field<int>("Quantity") * row.Field<decimal>("Price"));
            lblTotalValue.Text = total.ToString("C2");
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
