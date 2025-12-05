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
             frmAdminLogin frmAdminLogin = new frmAdminLogin();
            frmAdminLogin.ShowDialog();
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
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

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

                    // -------------------------------------------------------
                    // 1️⃣ CHECK OLD PASSWORD (only if user wants to change)
                    // -------------------------------------------------------
                    if (!string.IsNullOrEmpty(oldPassword) ||
                        !string.IsNullOrEmpty(newPassword) ||
                        !string.IsNullOrEmpty(confirmPassword))
                    {
                        if (string.IsNullOrEmpty(oldPassword) ||
                            string.IsNullOrEmpty(newPassword) ||
                            string.IsNullOrEmpty(confirmPassword))
                        {
                            MessageBox.Show("Fill all password fields to change password.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (newPassword != confirmPassword)
                        {
                            MessageBox.Show("New password and confirm password do not match.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string checkQuery = "SELECT PasswordHash FROM tblUsers WHERE UserID = @UserID";
                        string currentPassword = null;

                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@UserID", userID);
                            currentPassword = checkCmd.ExecuteScalar()?.ToString();
                        }

                        if (currentPassword == null)
                        {
                            MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (currentPassword != oldPassword)
                        {
                            MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // -------------------------------------------------------
                    // 2️⃣ UPDATE USERNAME + PHOTO + OPTIONAL PASSWORD
                    // -------------------------------------------------------
                    string updateQuery = @"
                UPDATE tblUsers 
                SET Username = @Username,
                    Photo = @Photo
                    /* Password will only update if condition triggered */
                    " +
                            (!string.IsNullOrEmpty(newPassword) ? ", PasswordHash = @NewPassword" : "") +
                        " WHERE UserID = @UserID";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Username", newUsername);
                        updateCmd.Parameters.AddWithValue("@Photo", photo ?? (object)DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@UserID", userID);

                        if (!string.IsNullOrEmpty(newPassword))
                            updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);

                        updateCmd.ExecuteNonQuery();
                    }

                    // -------------------------------------------------------
                    // 3️⃣ SUCCESS
                    // -------------------------------------------------------
                    MessageBox.Show("Profile updated successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Update UI & stored username
                    username = newUsername;
                    frmMain?.RefreshUserData(newUsername, photo);

                    // Clear password fields
                    txtOldPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating profile: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
