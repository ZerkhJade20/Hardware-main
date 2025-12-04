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
        public void UpdateLabels()
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
        public void LoadTrendChart()
        {
            string query = @"
        SELECT 
            DATEPART(WEEK, DateCreated) AS WeekNumber,
            DATENAME(WEEK, DateCreated) AS [WeekName],
            SUM(TotalAmount) AS TotalSales,
            MIN(DateCreated) AS FirstDate
        FROM tblTransactions
        GROUP BY DATEPART(WEEK, DateCreated), DATENAME(WEEK, DateCreated)
        ORDER BY FirstDate";   // Ensures left-to-right order


            DataTable dt = DBHelper.ExecuteSelect(query);

            var salesValues = new LiveCharts.ChartValues<decimal>();
            var weekLabels = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                weekLabels.Add("Week " + row["WeekNumber"].ToString()); // LEFT → RIGHT
                salesValues.Add(Convert.ToDecimal(row["TotalSales"]));
            }

            chartSalesTrendAnalysis.Series.Clear();
            chartSalesTrendAnalysis.AxisX.Clear();
            chartSalesTrendAnalysis.AxisY.Clear();

            chartSalesTrendAnalysis.Series = new LiveCharts.SeriesCollection
    {
        new LiveCharts.Wpf.LineSeries
        {
            Title = "Total Sales",
            Values = salesValues,
            PointGeometrySize = 10,
            LineSmoothness = 1,
        }

    };

            chartSalesTrendAnalysis.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Week",
                Labels = weekLabels,
                MinValue = 0,        // makes line start at index 0 (left)
                Separator = new Separator
                {
                    Step = 1,       // one label per point
                    IsEnabled = false
                }
            });

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
