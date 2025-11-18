using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Hardware_main.UserControls
{

    public partial class UC_Reports : UserControl
    {
        private PrintDocument printDocument;
        private System.Collections.Generic.List<TabPage> tabsToPrint;
        private int currentTabIndex;
        public UC_Reports()
        {
            InitializeComponent();
            LoadReportData();
        }
        public static void RefreshReport()
        {
            // Call on instance.
        }
        public void LoadReportData()
        {
            UpdateLabels();
            LoadTrendChart();
            LoadCategoryChart();
        }
        private void UpdateLabels()
        {
            // Total Revenue: Sum TotalAmount from tblTransactions.
            string queryRevenue = "SELECT SUM(TotalAmount) FROM tblTransactions";
            DataTable dtRevenue = DBHelper.ExecuteSelect(queryRevenue);
            lblUpdatingTotalRevenue.Text = " " + (dtRevenue.Rows.Count > 0 && dtRevenue.Rows[0][0] != DBNull.Value ? dtRevenue.Rows[0][0].ToString() : "0");
            // Total Transactions.
            string queryTrans = "SELECT COUNT(*) FROM tblTransactions";
            DataTable dtTrans = DBHelper.ExecuteSelect(queryTrans);
            lblUpdatingTotalTransactions.Text = " " + dtTrans.Rows[0][0].ToString();
            // Average Sale.
            string queryAvg = "SELECT AVG(TotalAmount) FROM tblTransactions";
            DataTable dtAvg = DBHelper.ExecuteSelect(queryAvg);

            if (dtAvg.Rows.Count > 0 && dtAvg.Rows[0][0] != DBNull.Value)
            {
                decimal average = Convert.ToDecimal(dtAvg.Rows[0][0]);
                lblUpdatingAverageSales.Text = " " + average.ToString("0.00");
            }
            
        }
        private void LoadTrendChart()
        {
            string query = @"
                            SELECT DATENAME(week, DateCreated) AS [Week], 
                                   SUM(TotalAmount) AS TotalSales
                            FROM tblTransactions
                            GROUP BY DATENAME(week, DateCreated)
                            ORDER BY MIN(DateCreated)";

            DataTable dt = DBHelper.ExecuteSelect(query);

            // Prepare collections
            var salesValues = new LiveCharts.ChartValues<decimal>();
            var weekLabels = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                weekLabels.Add(row["Week"].ToString());
                salesValues.Add(Convert.ToDecimal(row["TotalSales"]));
            }

            chartSalesTrendAnalysis.Series.Clear();

            chartSalesTrendAnalysis.Series = new LiveCharts.SeriesCollection
    {
        new LiveCharts.Wpf.LineSeries
        {
            Title = "Total Sales",
            Values = salesValues,
            PointGeometrySize = 10
        }
    };

            chartSalesTrendAnalysis.AxisX.Clear();
            chartSalesTrendAnalysis.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Week",
                Labels = weekLabels
            });

            chartSalesTrendAnalysis.AxisY.Clear();
            chartSalesTrendAnalysis.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C")
            });
        }
        private void LoadCategoryChart()
        {
            string query = @"
        SELECT Category, SUM(Price * Quantity) AS TotalValue
        FROM tblItems
        GROUP BY Category";

            DataTable dt = DBHelper.ExecuteSelect(query);

            var categories = new List<string>();
            var values = new LiveCharts.ChartValues<decimal>();

            foreach (DataRow row in dt.Rows)
            {
                categories.Add(row["Category"].ToString());
                values.Add(Convert.ToDecimal(row["TotalValue"]));
            }

            chartSalesByCategory.Series = new LiveCharts.SeriesCollection
    {
        new LiveCharts.Wpf.ColumnSeries
        {
            Title = "Sales by Category",
            Values = values
        }
    };

            chartSalesByCategory.AxisX.Clear();
            chartSalesByCategory.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Category",
                Labels = categories
            });

            chartSalesByCategory.AxisY.Clear();
            chartSalesByCategory.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Total Sales",
                LabelFormatter = value => value.ToString("C")
            });
        }




        private void BtnPrint_Click(object sender, EventArgs e)
        {

        }

        private void UC_Reports_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void chartSalesTrendAnalysis_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
