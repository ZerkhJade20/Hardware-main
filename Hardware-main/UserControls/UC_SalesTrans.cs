using Guna.UI2.WinForms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows.Forms;

namespace Hardware_main.UserControls
{
    public partial class UC_SalesTrans : UserControl
    {
        public event Action SalesDataChanged;
        private int currentUserId = 1; // Set properly per logged in user
        public UC_SalesTrans()
        {
            InitializeComponent();
            LoadTransactionSummary();
            LoadWeeklySalesChart();
            LoadTransactionHistory();
            guna2Panel1.Hide();
           
            
        }
        public void LoadTransactionSummary()
        {
            var totalSales = Convert.ToDecimal(DBHelper.ExecuteScalar("SELECT ISNULL(SUM(TotalAmount), 0) FROM tblTransactions"));
            var count = Convert.ToInt32(DBHelper.ExecuteScalar("SELECT COUNT(*) FROM tblTransactions"));
            var avgSale = count > 0 ? totalSales / count : 0m;
            lblTotalSales.Text = totalSales.ToString("C2");
            lblTotalTransactions.Text = count.ToString();
            lblAverageTransactions.Text = avgSale.ToString("C2");
        }
        public void LoadWeeklySalesChart()
        {
            var dt = DBHelper.ExecuteSelect(@"
            SELECT DATEPART(WEEK, DateCreated) AS WeekNumber, SUM(TotalAmount) AS WeeklyTotal 
            FROM tblTransactions GROUP BY DATEPART(WEEK, DateCreated) ORDER BY WeekNumber");
            var weeks = dt.AsEnumerable().Select(r => "W" + r.Field<int>("WeekNumber")).ToArray();
            var sales = dt.AsEnumerable().Select(r => r.Field<decimal>("WeeklyTotal")).ToArray();
            chartWeeklySalesOverview.Series.Clear();
            chartWeeklySalesOverview.AxisX.Clear();
            chartWeeklySalesOverview.AxisY.Clear();
            chartWeeklySalesOverview.Series = new SeriesCollection
        {
            new ColumnSeries { Title = "Weekly Sales", Values = new ChartValues<decimal>(sales) }
        };
            chartWeeklySalesOverview.AxisX.Add(new Axis { Title = "Week", Labels = weeks });
            chartWeeklySalesOverview.AxisY.Add(new Axis { Title = "Sales", LabelFormatter = v => v.ToString("C") });
        }
        public void LoadTransactionHistory()
        {
            var dt = DBHelper.ExecuteSelect(@"SELECT TOP 100 TransactionID, CustomerName, TotalAmount, PaymentMethod, DateCreated 
                                          FROM tblTransactions ORDER BY DateCreated DESC");
            lvTransactionHistory.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                var lvi = new ListViewItem(r["TransactionID"].ToString());
                lvi.SubItems.Add(r["CustomerName"].ToString());
                lvi.SubItems.Add(Convert.ToDecimal(r["TotalAmount"]).ToString("C2"));
                lvi.SubItems.Add(r["PaymentMethod"].ToString());
                lvi.SubItems.Add(Convert.ToDateTime(r["DateCreated"]).ToString("g"));
                lvTransactionHistory.Items.Add(lvi);
            }
        }
        private void UC_SalesTrans_Load(object sender, EventArgs e)
        {
            cmbPaymentMethod.Items.AddRange(new object[]
            {
                "Cash",
                "Credit Card",
                "Debit Card",
                "Bank Transfer",
                "Check",
                
            });
        }

        private void btnNewTransactions_Click(object sender, EventArgs e)
        {
            guna2Panel1.Show();
        }

        private void btnTransactionCancel_Click(object sender, EventArgs e)
        {
            guna2Panel1.Hide();
        }

        private void btnCreateTransaction_Click(object sender, EventArgs e)
        {
            if (nudTotalAmmount.Value <= 0)
            {
                MessageBox.Show("Amount must be greater than zero");
                return;
            }
            string sql = @"INSERT INTO tblTransactions (CustomerName, TotalAmount, PaymentMethod, CreatedBy) 
                       VALUES (@cust, @amt, @payment, @createdBy)";
            SqlParameter[] parameters = {
            new SqlParameter("@cust", txtCustomerName.Text.Trim()),
            new SqlParameter("@amt", nudTotalAmmount.Value),
            new SqlParameter("@payment", cmbPaymentMethod.Text),
            new SqlParameter("@createdBy", currentUserId)
        };
            DBHelper.ExecuteNonQuery(sql, parameters);
            MessageBox.Show("Transaction saved");
            guna2Panel1.Visible = false;
            LoadTransactionSummary();
            LoadWeeklySalesChart();
            LoadTransactionHistory();
            SalesDataChanged?.Invoke();
            
        }
    }
}
