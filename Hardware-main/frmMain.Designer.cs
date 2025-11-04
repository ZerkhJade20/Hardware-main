using System.Windows.Forms;

namespace Hardware_main
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pbProfilePic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnStaffs = new Guna.UI2.WinForms.Guna2Button();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.btnSalesTrans = new Guna.UI2.WinForms.Guna2Button();
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.panelContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.DimGray;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.lblUserName);
            this.guna2Panel1.Controls.Add(this.pbProfilePic);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1449, 81);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(1193, 18);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(168, 40);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Miguelito";
            // 
            // pbProfilePic
            // 
            this.pbProfilePic.Image = ((System.Drawing.Image)(resources.GetObject("pbProfilePic.Image")));
            this.pbProfilePic.ImageRotate = 0F;
            this.pbProfilePic.Location = new System.Drawing.Point(1375, 7);
            this.pbProfilePic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbProfilePic.Name = "pbProfilePic";
            this.pbProfilePic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbProfilePic.Size = new System.Drawing.Size(64, 64);
            this.pbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfilePic.TabIndex = 2;
            this.pbProfilePic.TabStop = false;
            this.pbProfilePic.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(100, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seminiano Enterprise";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BorderRadius = 30;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 2);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(64, 69);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.Controls.Add(this.btnStaffs);
            this.guna2Panel2.Controls.Add(this.btnReports);
            this.guna2Panel2.Controls.Add(this.btnSupplier);
            this.guna2Panel2.Controls.Add(this.btnSalesTrans);
            this.guna2Panel2.Controls.Add(this.btnInventory);
            this.guna2Panel2.Controls.Add(this.btnDashboard);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 81);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1449, 62);
            this.guna2Panel2.TabIndex = 1;
            // 
            // btnStaffs
            // 
            this.btnStaffs.Animated = true;
            this.btnStaffs.BorderRadius = 10;
            this.btnStaffs.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnStaffs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaffs.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnStaffs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStaffs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStaffs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStaffs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStaffs.FillColor = System.Drawing.Color.White;
            this.btnStaffs.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffs.ForeColor = System.Drawing.Color.DimGray;
            this.btnStaffs.HoverState.CustomBorderColor = System.Drawing.Color.DarkBlue;
            this.btnStaffs.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnStaffs.Image = ((System.Drawing.Image)(resources.GetObject("btnStaffs.Image")));
            this.btnStaffs.Location = new System.Drawing.Point(1243, 0);
            this.btnStaffs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStaffs.Name = "btnStaffs";
            this.btnStaffs.Size = new System.Drawing.Size(207, 57);
            this.btnStaffs.TabIndex = 6;
            this.btnStaffs.Text = "Staffs";
            this.btnStaffs.Click += new System.EventHandler(this.btnStaffs_Click);
            // 
            // btnReports
            // 
            this.btnReports.Animated = true;
            this.btnReports.BorderRadius = 10;
            this.btnReports.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReports.FillColor = System.Drawing.Color.White;
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.DimGray;
            this.btnReports.HoverState.CustomBorderColor = System.Drawing.Color.DarkBlue;
            this.btnReports.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.Location = new System.Drawing.Point(984, 0);
            this.btnReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(253, 57);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "Reports";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Animated = true;
            this.btnSupplier.BorderRadius = 10;
            this.btnSupplier.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplier.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSupplier.FillColor = System.Drawing.Color.White;
            this.btnSupplier.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.DimGray;
            this.btnSupplier.HoverState.CustomBorderColor = System.Drawing.Color.DarkBlue;
            this.btnSupplier.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnSupplier.Image")));
            this.btnSupplier.Location = new System.Drawing.Point(776, 0);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(203, 57);
            this.btnSupplier.TabIndex = 5;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnSalesTrans
            // 
            this.btnSalesTrans.Animated = true;
            this.btnSalesTrans.BorderRadius = 10;
            this.btnSalesTrans.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSalesTrans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesTrans.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnSalesTrans.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSalesTrans.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSalesTrans.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSalesTrans.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSalesTrans.FillColor = System.Drawing.Color.White;
            this.btnSalesTrans.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSalesTrans.ForeColor = System.Drawing.Color.DimGray;
            this.btnSalesTrans.HoverState.CustomBorderColor = System.Drawing.Color.DarkBlue;
            this.btnSalesTrans.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnSalesTrans.Image = ((System.Drawing.Image)(resources.GetObject("btnSalesTrans.Image")));
            this.btnSalesTrans.Location = new System.Drawing.Point(477, 0);
            this.btnSalesTrans.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalesTrans.Name = "btnSalesTrans";
            this.btnSalesTrans.Size = new System.Drawing.Size(292, 57);
            this.btnSalesTrans.TabIndex = 4;
            this.btnSalesTrans.Text = "Sales / Transactions";
            this.btnSalesTrans.Click += new System.EventHandler(this.btnSalesTrans_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Animated = true;
            this.btnInventory.BorderRadius = 10;
            this.btnInventory.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInventory.FillColor = System.Drawing.Color.White;
            this.btnInventory.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.DimGray;
            this.btnInventory.HoverState.CustomBorderColor = System.Drawing.Color.DarkBlue;
            this.btnInventory.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnInventory.Image")));
            this.btnInventory.Location = new System.Drawing.Point(237, 0);
            this.btnInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(235, 57);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Animated = true;
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.BorderColor = System.Drawing.Color.Maroon;
            this.btnDashboard.BorderRadius = 5;
            this.btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDashboard.FillColor = System.Drawing.Color.White;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.DimGray;
            this.btnDashboard.HoverState.CustomBorderColor = System.Drawing.Color.DarkBlue;
            this.btnDashboard.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(231, 57);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.Lavender;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.FillColor = System.Drawing.Color.Transparent;
            this.panelContainer.Location = new System.Drawing.Point(0, 143);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1449, 645);
            this.panelContainer.TabIndex = 2;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContainer_Paint_1);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.guna2Panel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 788);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnStaffs;
        private Guna.UI2.WinForms.Guna2Button btnReports;
        private Guna.UI2.WinForms.Guna2Button btnSupplier;
        private Guna.UI2.WinForms.Guna2Button btnSalesTrans;
        private Guna.UI2.WinForms.Guna2Button btnInventory;
        private Guna.UI2.WinForms.Guna2Panel panelContainer;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbProfilePic;
        private System.Windows.Forms.Label lblUserName;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private PaintEventHandler panelContainer_Paint;
    }
}