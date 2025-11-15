using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_main.UserControls
{
    
    public partial class Profile : UserControl
    {
        private string connectionString = "Data Source=ZERKH\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True;TrustServerCertificate=True";
        private frmMain dashboard;
        private int userID;
        private string username;
        private byte[] photo;
        private frmMain frmMain;

        public Profile(int userID, string username, byte[] photo, frmMain dash)
        {
            InitializeComponent();
            this.userID = userID;
            this.username = username;
            this.photo = photo;
            this.frmMain = dash;
            LoadProfileData();


        }
        private void LoadProfileData()
        {
            txtUsername.Text = username;
            if (photo != null)
            {
                using (MemoryStream ms = new MemoryStream(photo))
                {
                    pbPicture.Image = Image.FromStream(ms);
                }
            }
        }



        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
             
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbPicture.Image = Image.FromFile(ofd.FileName);
                    // Convert to byte[] for saving
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pbPicture.Image.Save(ms, pbPicture.Image.RawFormat);
                        photo = ms.ToArray();
                    }
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string newUsername = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tblUsers SET Username = @Username, Photo = @Photo WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", newUsername);
                        cmd.Parameters.AddWithValue("@Photo", photo ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh dashboard UI
                    if (frmMain is frmMain adminDash)
                    {
                        adminDash.RefreshUserData(newUsername, photo);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Visible = false;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
