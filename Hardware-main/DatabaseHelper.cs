using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware_main
{
    internal class DatabaseHelper
    {
        private string connectionString = "Data Source=ZERKH\\SQLEXPRESS;Initial Catalog=HardwareInventoryDB_AdminOnly;Integrated Security=True;TrustServerCertificate=True";
        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open(); // Opens the connection.
            return conn;
        }

        public bool AuthenticateAdmin(string username, string password)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    string query = "SELECT PasswordHash FROM tblAdmin WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            // In production, hash the input password and compare hashes.
                            // For now, direct comparison (not secure).
                            return result.ToString() == password;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., log or show message).
                Console.WriteLine("Error: " + ex.Message);
            }
            return false;
        }
        public DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    string query = "SELECT * FROM tblProducts";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt); // Fills the DataTable with query results.
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }
        // Example: Add a new product (insert into tblProducts).
        public bool AddProduct(string itemName, string sku, int categoryId, int quantity, decimal price, int reorderLevel)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    string query = "INSERT INTO tblProducts (ItemName, SKU, CategoryID, Quantity, Price, ReorderLevel) VALUES (@ItemName, @SKU, @CategoryID, @Quantity, @Price, @ReorderLevel)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", itemName);
                        cmd.Parameters.AddWithValue("@SKU", sku);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
                        cmd.ExecuteNonQuery(); // Executes the insert.
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    string query = "DELETE FROM tblProducts WHERE ProductID = @ProductID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        // Example: Get dashboard summary (reads from vwDashboardSummary view).
        public DataTable GetDashboardSummary()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    string query = "SELECT * FROM vwDashboardSummary";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }
        // Add more methods as needed for other tables (e.g., sales, suppliers, etc.).
        // For example, to insert a sale:
        // public bool AddSale(string customerName, decimal totalAmount, string paymentMethod) { ... }
    }
}


        
    


