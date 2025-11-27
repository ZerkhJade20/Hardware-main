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
        public delegate void AddToCartHandler(int productID, string name, decimal price);
        public event AddToCartHandler OnAddToCart;
        private UC_Cart _cart;
        public UC_Products(UC_Cart cart)
        {
            InitializeComponent();
            _cart = cart;
            LoadProducts();

            


        }
        public void LoadProducts()
        {
            var dt = DBHelper.ExecuteSelect("SELECT * FROM tblItems WHERE Status='In Stock'");
            dgvProducts.DataSource = dt;
        }
        public void SubscribeToInventory(UC_Inventory inventoryCtrl)
        {
            inventoryCtrl.InventoryChanged += () => LoadProducts();
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
                string productName = dgvProducts.Rows[e.RowIndex].Cells["ItemName"].Value.ToString();
                decimal price = Convert.ToDecimal(dgvProducts.Rows[e.RowIndex].Cells["Price"].Value);

                // 1. Add/update item in the Cart
                _cart.AddItemToCart(productId, productName, price);

                // 2. Decrease quantity in database
                DecreaseProductQuantity(productId, 1);

                // 3. Refresh product list
                LoadProducts();
            }
        }
        private void DecreaseProductQuantity(int productId, int qty)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ZERKH\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
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
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UC_Products_Load(object sender, EventArgs e)
        {

        }
    }
}
