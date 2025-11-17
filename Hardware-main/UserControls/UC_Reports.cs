using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

            btnPrintReport.Click += BtnPrint_Click;
            


        }
        private void LoadReportData()
        {
            var totalRevenue = DBHelper.ExecuteScalar("SELECT ISNULL(SUM(TotalAmount),0) FROM tblTransactions");
            var totalTransactions = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM tblTransactions");
            decimal avgSale = 0;
            if (Convert.ToInt32(totalTransactions) > 0)
                avgSale = Convert.ToDecimal(totalRevenue) / Convert.ToInt32(totalTransactions);

            lblUpdatingTotalRevenue.Text = Convert.ToDecimal(totalRevenue).ToString("C2");
            lblUpdatingTotalTransactions.Text = totalTransactions.ToString();
            lblUpdatingAverageSales.Text = avgSale.ToString("C2");

            LoadSalesTrendChart();
            LoadSalesByCategoryChart();
        }
        private void LoadSalesTrendChart()
        {
            var dt = DBHelper.ExecuteSelect(@"
            SELECT DATEPART(WK, DateCreated) AS WeekNumber, SUM(TotalAmount) AS WeeklySales 
            FROM tblTransactions GROUP BY DATEPART(WK, DateCreated) ORDER BY WeekNumber");

            var weeks = dt.AsEnumerable().Select(r => "W" + r.Field<int>("WeekNumber")).ToArray();
            var sales = dt.AsEnumerable().Select(r => r.Field<decimal>("WeeklySales")).ToArray();

            chartSalesTrendAnalysis.Series.Clear();
            chartSalesTrendAnalysis.AxisX.Clear();
            chartSalesTrendAnalysis.AxisY.Clear();

            chartSalesTrendAnalysis.Series.Add(new LineSeries
            {
                Title = "Sales Trend",
                Values = new ChartValues<decimal>(sales)
            });

            chartSalesTrendAnalysis.AxisX.Add(new Axis { Title = "Week", Labels = weeks });
            chartSalesTrendAnalysis.AxisY.Add(new Axis { Title = "Amount", LabelFormatter = value => value.ToString("C") });
        }
        private void LoadSalesByCategoryChart()
        {
            string sql = @"
            SELECT Category, SUM(i.Price * t.Quantity) AS TotalSales
            FROM tblItems i
            JOIN (SELECT ItemID, SUM(Quantity) AS Quantity FROM tblTransactionsItems GROUP BY ItemID) t ON i.ItemID = t.ItemID
            GROUP BY Category";

            var dt = DBHelper.ExecuteSelect(sql);
            var categories = dt.AsEnumerable().Select(r => r.Field<string>("Category")).ToArray();
            var totals = dt.AsEnumerable().Select(r => r.Field<decimal>("TotalSales")).ToArray();

            chartSalesByCategory.Series.Clear();
            chartSalesByCategory.AxisX.Clear();
            chartSalesByCategory.AxisY.Clear();

            chartSalesByCategory.Series.Add(new ColumnSeries
            {
                Title = "Sales by Category",
                Values = new ChartValues<decimal>(totals)
            });

            chartSalesByCategory.AxisX.Add(new Axis { Title = "Category", Labels = categories });
            chartSalesByCategory.AxisY.Add(new Axis { Title = "Sales", LabelFormatter = val => val.ToString("C") });
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
