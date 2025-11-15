namespace Hardware_main.UserControls
{
    partial class UC_Dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Dashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.chartSalesAnalytics = new LiveCharts.WinForms.CartesianChart();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblTotalSalesUpdate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CirclePictureBox4 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblTransactionUpdate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2Panel8 = new Guna.UI2.WinForms.Guna2Panel();
            this.lvRecentTransactions = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lvLowStockAlert = new System.Windows.Forms.ListView();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).BeginInit();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(11, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(536, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome back! Here\'s your business overview.\r\n";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.chartSalesAnalytics);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Location = new System.Drawing.Point(16, 102);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 25;
            this.guna2Panel1.Size = new System.Drawing.Size(855, 340);
            this.guna2Panel1.TabIndex = 2;
            // 
            // chartSalesAnalytics
            // 
            this.chartSalesAnalytics.Location = new System.Drawing.Point(18, 69);
            this.chartSalesAnalytics.Name = "chartSalesAnalytics";
            this.chartSalesAnalytics.Size = new System.Drawing.Size(818, 255);
            this.chartSalesAnalytics.TabIndex = 4;
            this.chartSalesAnalytics.Text = "cartesianChart1";
            this.chartSalesAnalytics.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.cartesianChart1_ChildChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 47);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sales Analytics";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel2.BorderRadius = 15;
            this.guna2Panel2.Controls.Add(this.guna2CirclePictureBox3);
            this.guna2Panel2.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2Panel2.Controls.Add(this.lblTotalSalesUpdate);
            this.guna2Panel2.Controls.Add(this.label5);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.guna2Panel2.Location = new System.Drawing.Point(890, 102);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(259, 135);
            this.guna2Panel2.TabIndex = 3;
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox3.Image")));
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(198, 3);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(42, 57);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox3.TabIndex = 8;
            this.guna2CirclePictureBox3.TabStop = false;
            this.guna2CirclePictureBox3.UseTransparentBackground = true;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.FillColor = System.Drawing.Color.PowderBlue;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(164, -50);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(159, 138);
            this.guna2CirclePictureBox1.TabIndex = 7;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // lblTotalSalesUpdate
            // 
            this.lblTotalSalesUpdate.AutoSize = true;
            this.lblTotalSalesUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSalesUpdate.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalesUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalSalesUpdate.Location = new System.Drawing.Point(55, 69);
            this.lblTotalSalesUpdate.Name = "lblTotalSalesUpdate";
            this.lblTotalSalesUpdate.Size = new System.Drawing.Size(87, 34);
            this.lblTotalSalesUpdate.TabIndex = 6;
            this.lblTotalSalesUpdate.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(24, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 34);
            this.label5.TabIndex = 5;
            this.label5.Text = "₱";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(16, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Sales";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel3.BorderRadius = 15;
            this.guna2Panel3.Controls.Add(this.guna2CirclePictureBox2);
            this.guna2Panel3.Controls.Add(this.guna2CirclePictureBox4);
            this.guna2Panel3.Controls.Add(this.lblTransactionUpdate);
            this.guna2Panel3.Controls.Add(this.label8);
            this.guna2Panel3.Controls.Add(this.label9);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.guna2Panel3.Location = new System.Drawing.Point(1165, 102);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(259, 135);
            this.guna2Panel3.TabIndex = 9;
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox2.Image")));
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(187, 3);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(59, 60);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox2.TabIndex = 8;
            this.guna2CirclePictureBox2.TabStop = false;
            this.guna2CirclePictureBox2.UseTransparentBackground = true;
            // 
            // guna2CirclePictureBox4
            // 
            this.guna2CirclePictureBox4.FillColor = System.Drawing.Color.PaleVioletRed;
            this.guna2CirclePictureBox4.ImageRotate = 0F;
            this.guna2CirclePictureBox4.Location = new System.Drawing.Point(164, -50);
            this.guna2CirclePictureBox4.Name = "guna2CirclePictureBox4";
            this.guna2CirclePictureBox4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox4.Size = new System.Drawing.Size(159, 138);
            this.guna2CirclePictureBox4.TabIndex = 7;
            this.guna2CirclePictureBox4.TabStop = false;
            // 
            // lblTransactionUpdate
            // 
            this.lblTransactionUpdate.AutoSize = true;
            this.lblTransactionUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionUpdate.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTransactionUpdate.Location = new System.Drawing.Point(55, 69);
            this.lblTransactionUpdate.Name = "lblTransactionUpdate";
            this.lblTransactionUpdate.Size = new System.Drawing.Size(87, 34);
            this.lblTransactionUpdate.TabIndex = 6;
            this.lblTransactionUpdate.Text = "1000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(24, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 34);
            this.label8.TabIndex = 5;
            this.label8.Text = "₱";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(3, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "Transactions";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel4.BorderRadius = 15;
            this.guna2Panel4.Controls.Add(this.lvLowStockAlert);
            this.guna2Panel4.Controls.Add(this.guna2Panel5);
            this.guna2Panel4.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel4.Controls.Add(this.label12);
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.guna2Panel4.Location = new System.Drawing.Point(890, 255);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(534, 187);
            this.guna2Panel4.TabIndex = 9;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BorderRadius = 5;
            this.guna2Panel5.FillColor = System.Drawing.Color.Gray;
            this.guna2Panel5.Location = new System.Drawing.Point(21, 56);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(500, 10);
            this.guna2Panel5.TabIndex = 11;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(21, 16);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(31, 34);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 10;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(56, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(221, 30);
            this.label12.TabIndex = 4;
            this.label12.Text = "Low stock alert";
            // 
            // guna2Panel8
            // 
            this.guna2Panel8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel8.BorderRadius = 15;
            this.guna2Panel8.Controls.Add(this.lvRecentTransactions);
            this.guna2Panel8.Controls.Add(this.label6);
            this.guna2Panel8.Controls.Add(this.guna2PictureBox2);
            this.guna2Panel8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.guna2Panel8.Location = new System.Drawing.Point(13, 448);
            this.guna2Panel8.Name = "guna2Panel8";
            this.guna2Panel8.Size = new System.Drawing.Size(1411, 197);
            this.guna2Panel8.TabIndex = 11;
            // 
            // lvRecentTransactions
            // 
            this.lvRecentTransactions.HideSelection = false;
            this.lvRecentTransactions.Location = new System.Drawing.Point(21, 50);
            this.lvRecentTransactions.Name = "lvRecentTransactions";
            this.lvRecentTransactions.Size = new System.Drawing.Size(1364, 134);
            this.lvRecentTransactions.TabIndex = 14;
            this.lvRecentTransactions.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(58, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(292, 30);
            this.label6.TabIndex = 9;
            this.label6.Text = "Recent Transactions";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(21, 10);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(31, 34);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 13;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.UseTransparentBackground = true;
            // 
            // lvLowStockAlert
            // 
            this.lvLowStockAlert.HideSelection = false;
            this.lvLowStockAlert.Location = new System.Drawing.Point(21, 74);
            this.lvLowStockAlert.Name = "lvLowStockAlert";
            this.lvLowStockAlert.Size = new System.Drawing.Size(500, 97);
            this.lvLowStockAlert.TabIndex = 12;
            this.lvLowStockAlert.UseCompatibleStateImageBehavior = false;
            // 
            // UC_Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel8);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1450, 648);
            this.Load += new System.EventHandler(this.UC_Dashboard_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).EndInit();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel8.ResumeLayout(false);
            this.guna2Panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblTotalSalesUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox4;
        private System.Windows.Forms.Label lblTransactionUpdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel8;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.ListView lvRecentTransactions;
        private LiveCharts.WinForms.CartesianChart chartSalesAnalytics;
        private System.Windows.Forms.ListView lvLowStockAlert;
    }
}
