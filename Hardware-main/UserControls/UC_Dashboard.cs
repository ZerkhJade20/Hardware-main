using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Charts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_main.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();

        }
        public void LoadDashboardData()
        {
            LoadTotalSales();
            LoadTotalTransactions();
            LoadLowStockItems();
            LoadRecentTransactions();
            LoadSalesChart();
        }
        private void LoadTotalSales()
        {
            var result = DBHelper.ExecuteScalar("SELECT ISNULL(SUM(TotalAmount),0) FROM tblTransactions");
            decimal totalSales = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0m;
            lblTotalSalesUpdate.Text = totalSales.ToString("C2"); // Currency format
        }
        private void LoadTotalTransactions()
        {
            var result = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM tblTransactions");
            int totalTransactions = Convert.ToInt32(result);
            lblTransactionUpdate.Text = totalTransactions.ToString();
        }
        private void LoadLowStockItems()
        {
            string sql = "SELECT ItemName, SKU, Quantity, ReorderLevel FROM tblItems WHERE Quantity <= ReorderLevel";
            DataTable dt = DBHelper.ExecuteSelect(sql);
            lvLowStockAlert.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["ItemName"].ToString());
                item.SubItems.Add(row["SKU"].ToString());
                item.SubItems.Add(row["Quantity"].ToString());
                item.SubItems.Add(row["ReorderLevel"].ToString());
                lvLowStockAlert.Items.Add(item);
            }
        }
        private void LoadRecentTransactions()
        {
            string sql = "SELECT TOP 20 TransactionID, CustomerName, TotalAmount, DateCreated FROM tblTransactions ORDER BY DateCreated DESC";
            DataTable dt = DBHelper.ExecuteSelect(sql);
            lvRecentTransactions.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["TransactionID"].ToString());
                item.SubItems.Add(row["CustomerName"].ToString());
                item.SubItems.Add(Convert.ToDecimal(row["TotalAmount"]).ToString("C2"));
                item.SubItems.Add(Convert.ToDateTime(row["DateCreated"]).ToString("g"));
                lvRecentTransactions.Items.Add(item);
            }
        }
        private void LoadSalesChart()
        {
            string sql = @"
            SELECT DATEPART(WEEK, DateCreated) AS WeekNumber, SUM(TotalAmount) AS WeeklySales
            FROM tblTransactions
            GROUP BY DATEPART(WEEK, DateCreated)
            ORDER BY WeekNumber";

            DataTable dt = DBHelper.ExecuteSelect(sql);
            var weeks = dt.AsEnumerable().Select(r => "W" + r.Field<int>("WeekNumber")).ToArray();
            var sales = dt.AsEnumerable().Select(r => r.Field<decimal>("WeeklySales")).ToArray();

            chartSalesAnalytics.Series.Clear();
            chartSalesAnalytics.AxisX.Clear();
            chartSalesAnalytics.AxisY.Clear();

            chartSalesAnalytics.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Weekly Sales",
                    Values = new ChartValues<decimal>(sales)
                }
            };
            chartSalesAnalytics.AxisX.Add(new Axis
            {
                Title = "Week",
                Labels = weeks
            });
            chartSalesAnalytics.AxisY.Add(new Axis
            {
                Title = "Sales Amount",
                LabelFormatter = value => value.ToString("C")
            });
        }
        private void UC_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
