namespace Hardware_main.UserControls
{
    partial class UC_SalesTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_SalesTrans));
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.chartWeeklySalesOverview = new LiveCharts.WinForms.CartesianChart();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.lvTransactionHistory = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTotalTransactions = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblAverageTransactions = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnNewTransactions = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudTotalAmmount = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCreateTransaction = new Guna.UI2.WinForms.Guna2Button();
            this.btnTransactionCancel = new Guna.UI2.WinForms.Guna2Button();
            this.TransactionID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            this.guna2GradientPanel3.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalAmmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(90, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales and Transactions";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(36, 16);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(48, 44);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(32, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(520, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "Track your sales and performance and sales history.\r\n\r\n";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BorderRadius = 15;
            this.guna2Panel4.Controls.Add(this.chartWeeklySalesOverview);
            this.guna2Panel4.Controls.Add(this.label5);
            this.guna2Panel4.FillColor = System.Drawing.Color.White;
            this.guna2Panel4.Location = new System.Drawing.Point(41, 233);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(1851, 335);
            this.guna2Panel4.TabIndex = 13;
            // 
            // chartWeeklySalesOverview
            // 
            this.chartWeeklySalesOverview.BackColorTransparent = true;
            this.chartWeeklySalesOverview.ForeColor = System.Drawing.Color.White;
            this.chartWeeklySalesOverview.Location = new System.Drawing.Point(19, 60);
            this.chartWeeklySalesOverview.Name = "chartWeeklySalesOverview";
            this.chartWeeklySalesOverview.Size = new System.Drawing.Size(1816, 256);
            this.chartWeeklySalesOverview.TabIndex = 15;
            this.chartWeeklySalesOverview.Text = "cartesianChart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(14, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 28);
            this.label5.TabIndex = 14;
            this.label5.Text = "Weekly Sales Overview";
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BorderRadius = 15;
            this.guna2Panel5.Controls.Add(this.lvTransactionHistory);
            this.guna2Panel5.Controls.Add(this.label6);
            this.guna2Panel5.FillColor = System.Drawing.Color.White;
            this.guna2Panel5.Location = new System.Drawing.Point(41, 577);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(1851, 259);
            this.guna2Panel5.TabIndex = 15;
            // 
            // lvTransactionHistory
            // 
            this.lvTransactionHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TransactionID,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvTransactionHistory.HideSelection = false;
            this.lvTransactionHistory.Location = new System.Drawing.Point(19, 41);
            this.lvTransactionHistory.Name = "lvTransactionHistory";
            this.lvTransactionHistory.Size = new System.Drawing.Size(1816, 198);
            this.lvTransactionHistory.TabIndex = 15;
            this.lvTransactionHistory.UseCompatibleStateImageBehavior = false;
            this.lvTransactionHistory.View = System.Windows.Forms.View.Details;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(14, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "Transaction History";
            // 
            // btnExport
            // 
            this.btnExport.Animated = true;
            this.btnExport.BorderRadius = 20;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.Gray;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnExport.Location = new System.Drawing.Point(1380, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(218, 55);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "Export";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 15;
            this.guna2GradientPanel1.Controls.Add(this.lblTotalSales);
            this.guna2GradientPanel1.Controls.Add(this.label4);
            this.guna2GradientPanel1.Controls.Add(this.label9);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(41, 97);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(573, 118);
            this.guna2GradientPanel1.TabIndex = 17;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSales.Font = new System.Drawing.Font("Bookman Old Style", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.White;
            this.lblTotalSales.Location = new System.Drawing.Point(12, 42);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(101, 38);
            this.lblTotalSales.TabIndex = 11;
            this.lblTotalSales.Text = "1100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(12, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "All Time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(12, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Total Sales";
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderRadius = 15;
            this.guna2GradientPanel2.Controls.Add(this.lblTotalTransactions);
            this.guna2GradientPanel2.Controls.Add(this.label12);
            this.guna2GradientPanel2.Controls.Add(this.label18);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.Green;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.Green;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(645, 97);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(588, 118);
            this.guna2GradientPanel2.TabIndex = 18;
            // 
            // lblTotalTransactions
            // 
            this.lblTotalTransactions.AutoSize = true;
            this.lblTotalTransactions.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalTransactions.Font = new System.Drawing.Font("Bookman Old Style", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTransactions.ForeColor = System.Drawing.Color.White;
            this.lblTotalTransactions.Location = new System.Drawing.Point(9, 43);
            this.lblTotalTransactions.Name = "lblTotalTransactions";
            this.lblTotalTransactions.Size = new System.Drawing.Size(101, 38);
            this.lblTotalTransactions.TabIndex = 11;
            this.lblTotalTransactions.Text = "1100";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gainsboro;
            this.label12.Location = new System.Drawing.Point(12, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 23);
            this.label12.TabIndex = 10;
            this.label12.Text = "Completed";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Gainsboro;
            this.label18.Location = new System.Drawing.Point(12, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(191, 23);
            this.label18.TabIndex = 8;
            this.label18.Text = "Total Transactions";
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.BorderRadius = 15;
            this.guna2GradientPanel3.Controls.Add(this.lblAverageTransactions);
            this.guna2GradientPanel3.Controls.Add(this.label11);
            this.guna2GradientPanel3.Controls.Add(this.label19);
            this.guna2GradientPanel3.FillColor = System.Drawing.Color.DarkViolet;
            this.guna2GradientPanel3.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.guna2GradientPanel3.Location = new System.Drawing.Point(1262, 97);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.Size = new System.Drawing.Size(630, 118);
            this.guna2GradientPanel3.TabIndex = 18;
            // 
            // lblAverageTransactions
            // 
            this.lblAverageTransactions.AutoSize = true;
            this.lblAverageTransactions.BackColor = System.Drawing.Color.Transparent;
            this.lblAverageTransactions.Font = new System.Drawing.Font("Bookman Old Style", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageTransactions.ForeColor = System.Drawing.Color.White;
            this.lblAverageTransactions.Location = new System.Drawing.Point(9, 42);
            this.lblAverageTransactions.Name = "lblAverageTransactions";
            this.lblAverageTransactions.Size = new System.Drawing.Size(101, 38);
            this.lblAverageTransactions.TabIndex = 11;
            this.lblAverageTransactions.Text = "1100";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(12, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 23);
            this.label11.TabIndex = 10;
            this.label11.Text = "Per Sale";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Gainsboro;
            this.label19.Location = new System.Drawing.Point(12, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(211, 23);
            this.label19.TabIndex = 8;
            this.label19.Text = "Average Transaction";
            // 
            // btnNewTransactions
            // 
            this.btnNewTransactions.Animated = true;
            this.btnNewTransactions.BorderRadius = 20;
            this.btnNewTransactions.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNewTransactions.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNewTransactions.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNewTransactions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNewTransactions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(115)))), ((int)(((byte)(22)))));
            this.btnNewTransactions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNewTransactions.ForeColor = System.Drawing.Color.White;
            this.btnNewTransactions.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnNewTransactions.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTransactions.Image")));
            this.btnNewTransactions.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNewTransactions.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnNewTransactions.Location = new System.Drawing.Point(1604, 16);
            this.btnNewTransactions.Name = "btnNewTransactions";
            this.btnNewTransactions.Size = new System.Drawing.Size(272, 56);
            this.btnNewTransactions.TabIndex = 19;
            this.btnNewTransactions.Text = "New Transaction";
            this.btnNewTransactions.Click += new System.EventHandler(this.btnNewTransactions_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.btnTransactionCancel);
            this.guna2Panel1.Controls.Add(this.btnCreateTransaction);
            this.guna2Panel1.Controls.Add(this.cmbPaymentMethod);
            this.guna2Panel1.Controls.Add(this.label14);
            this.guna2Panel1.Controls.Add(this.nudTotalAmmount);
            this.guna2Panel1.Controls.Add(this.label10);
            this.guna2Panel1.Controls.Add(this.txtCustomerName);
            this.guna2Panel1.Controls.Add(this.label8);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.guna2Panel1.Location = new System.Drawing.Point(714, 37);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(554, 475);
            this.guna2Panel1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(19, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 40);
            this.label3.TabIndex = 21;
            this.label3.Text = "New Transaction";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(22, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 23);
            this.label8.TabIndex = 21;
            this.label8.Text = "Customer Name *";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Animated = true;
            this.txtCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.txtCustomerName.BorderColor = System.Drawing.Color.White;
            this.txtCustomerName.BorderRadius = 5;
            this.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerName.DefaultText = "";
            this.txtCustomerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerName.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCustomerName.Location = new System.Drawing.Point(26, 114);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PlaceholderText = "";
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.Size = new System.Drawing.Size(507, 48);
            this.txtCustomerName.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(22, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 23);
            this.label10.TabIndex = 23;
            this.label10.Text = "Total Ammount *";
            // 
            // nudTotalAmmount
            // 
            this.nudTotalAmmount.BackColor = System.Drawing.Color.Transparent;
            this.nudTotalAmmount.BorderRadius = 5;
            this.nudTotalAmmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudTotalAmmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudTotalAmmount.Location = new System.Drawing.Point(26, 215);
            this.nudTotalAmmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudTotalAmmount.Name = "nudTotalAmmount";
            this.nudTotalAmmount.Size = new System.Drawing.Size(507, 48);
            this.nudTotalAmmount.TabIndex = 24;
            this.nudTotalAmmount.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(115)))), ((int)(((byte)(22)))));
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Location = new System.Drawing.Point(22, 293);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(189, 23);
            this.label14.TabIndex = 25;
            this.label14.Text = "Payment Method *";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.cmbPaymentMethod.BorderRadius = 5;
            this.cmbPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPaymentMethod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.cmbPaymentMethod.ItemHeight = 30;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(26, 333);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(507, 36);
            this.cmbPaymentMethod.TabIndex = 26;
            // 
            // btnCreateTransaction
            // 
            this.btnCreateTransaction.Animated = true;
            this.btnCreateTransaction.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateTransaction.BorderRadius = 10;
            this.btnCreateTransaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateTransaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateTransaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreateTransaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreateTransaction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(115)))), ((int)(((byte)(22)))));
            this.btnCreateTransaction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCreateTransaction.ForeColor = System.Drawing.Color.White;
            this.btnCreateTransaction.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnCreateTransaction.Location = new System.Drawing.Point(325, 413);
            this.btnCreateTransaction.Name = "btnCreateTransaction";
            this.btnCreateTransaction.Size = new System.Drawing.Size(208, 39);
            this.btnCreateTransaction.TabIndex = 21;
            this.btnCreateTransaction.Text = "Create Transaction";
            this.btnCreateTransaction.Click += new System.EventHandler(this.btnCreateTransaction_Click);
            // 
            // btnTransactionCancel
            // 
            this.btnTransactionCancel.Animated = true;
            this.btnTransactionCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnTransactionCancel.BorderRadius = 10;
            this.btnTransactionCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTransactionCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTransactionCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTransactionCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTransactionCancel.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnTransactionCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTransactionCancel.ForeColor = System.Drawing.Color.Black;
            this.btnTransactionCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(162)))), ((int)(((byte)(73)))));
            this.btnTransactionCancel.Location = new System.Drawing.Point(198, 413);
            this.btnTransactionCancel.Name = "btnTransactionCancel";
            this.btnTransactionCancel.Size = new System.Drawing.Size(121, 39);
            this.btnTransactionCancel.TabIndex = 27;
            this.btnTransactionCancel.Text = "Cancel";
            this.btnTransactionCancel.Click += new System.EventHandler(this.btnTransactionCancel_Click);
            // 
            // TransactionID
            // 
            this.TransactionID.Text = "Transaction ID";
            this.TransactionID.Width = 200;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Customer Name";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Total Amount";
            this.columnHeader2.Width = 317;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Payment Method";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date Created";
            this.columnHeader4.Width = 500;
            // 
            // UC_SalesTrans
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btnNewTransactions);
            this.Controls.Add(this.guna2GradientPanel3);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.guna2Panel5);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "UC_SalesTrans";
            this.Size = new System.Drawing.Size(1918, 857);
            this.Load += new System.EventHandler(this.UC_SalesTrans_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.guna2GradientPanel3.ResumeLayout(false);
            this.guna2GradientPanel3.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalAmmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Label lblTotalTransactions;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private System.Windows.Forms.Label lblAverageTransactions;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label19;
        private Guna.UI2.WinForms.Guna2Button btnNewTransactions;
        private LiveCharts.WinForms.CartesianChart chartWeeklySalesOverview;
        private System.Windows.Forms.ListView lvTransactionHistory;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerName;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Button btnTransactionCancel;
        private Guna.UI2.WinForms.Guna2Button btnCreateTransaction;
        private Guna.UI2.WinForms.Guna2ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudTotalAmmount;
        private System.Windows.Forms.ColumnHeader TransactionID;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
