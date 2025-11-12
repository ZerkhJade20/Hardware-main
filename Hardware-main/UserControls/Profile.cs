using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_main.UserControls
{
    public partial class Profile : UserControl
    {
        private frmMain dashboard;
        public Profile(frmMain dash)
        {
            InitializeComponent();
            dashboard = dash;

           
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
            // Create and configure the OpenFileDialog for image files.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // Restrict to common image formats.
            openFileDialog.Title = "Select a Profile Picture";
            // Show the dialog and load the selected image if the user clicks OK.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the image from the selected file path and display it in the edit PictureBox.
                pbPicture.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Call the dashboard's update method to reflect changes instantly.
            dashboard.UpdateProfile(pbPicture.Image, txtUsername.Text);
            // Optional: You could add logic here to hide the control or show a success message.
            // For now, it stays visible so the user can make further edits.
            this.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            WorkerUI workerUI = new WorkerUI();
            workerUI.Show();
            
        }
    }
}
