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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Imaging;


namespace Hardware_main.UserControls
{

    public partial class UC_Reports : UserControl
    {
        private PrintDocument printDocument = new PrintDocument();
        private Bitmap controlBitmap;
        public UC_Reports()
        {
            InitializeComponent();
            LoadReportData();
            printDocument.PrintPage += printDocument1_PrintPage;
            btnPrintReport.Click += BtnPrint_Click;


        }

        private Bitmap CaptureUserControl(UserControl control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));
            return bmp;
        }
        public static void RefreshReport()
        {
        }
        public void LoadReportData()
        {
            UpdateLabels();
            LoadTrendChart();
            LoadCategoryChart();
        }
        public void UpdateLabels()
        {
            string queryRevenue = "SELECT SUM(TotalAmount) FROM tblTransactions";
            DataTable dtRevenue = DBHelper.ExecuteSelect(queryRevenue);
            lblUpdatingTotalRevenue.Text = " " + (dtRevenue.Rows.Count > 0 && dtRevenue.Rows[0][0] != DBNull.Value ? dtRevenue.Rows[0][0].ToString() : "0");

            string queryTrans = "SELECT COUNT(*) FROM tblTransactions";
            DataTable dtTrans = DBHelper.ExecuteSelect(queryTrans);
            lblUpdatingTotalTransactions.Text = " " + dtTrans.Rows[0][0].ToString();

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
                            ORDER BY FirstDate";  
            DataTable dt = DBHelper.ExecuteSelect(query);

            var salesValues = new LiveCharts.ChartValues<decimal>();
            var weekLabels = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                weekLabels.Add("Week " + row["WeekNumber"].ToString()); 
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
                MinValue = 0,        
                Separator = new Separator
                {
                    Step = 1,       
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
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 1200,
                Height = 800
            };
            preview.ShowDialog();
        }

        private void chartSalesTrendAnalysis_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            DataTable dtTrend = DBHelper.ExecuteSelect(@"
                                                        SELECT DATEPART(WEEK, DateCreated) AS WeekNumber, SUM(TotalAmount) AS TotalSales
                                                        FROM tblTransactions
                                                        GROUP BY DATEPART(WEEK, DateCreated)
                                                        ORDER BY WeekNumber");

            DataTable dtCategory = DBHelper.ExecuteSelect(@"
                                                           SELECT Category, SUM(Price * Quantity) AS TotalValue
                                                           FROM tblItems
                                                           GROUP BY Category");

            Graphics g = e.Graphics;
            int pageWidth = e.PageBounds.Width;
            int margin = 40;
            int currentY = margin;

            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 12, FontStyle.Regular);
            Font tableHeaderFont = new Font("Arial", 11, FontStyle.Bold);
            Font tableFont = new Font("Arial", 10, FontStyle.Regular);
            Brush brush = Brushes.Black;
            Pen tablePen = new Pen(Color.Black, 1);

            string header = "Sales Report";
            SizeF headerSize = g.MeasureString(header, headerFont);
            g.DrawString(header, headerFont, brush, (pageWidth - headerSize.Width) / 2, currentY);
            currentY += (int)headerSize.Height + 10;

            string dateText = "Date: " + DateTime.Now.ToString("yyyy-MM-dd");
            SizeF dateSize = g.MeasureString(dateText, subHeaderFont);
            g.DrawString(dateText, subHeaderFont, brush, (pageWidth - dateSize.Width) / 2, currentY);
            currentY += (int)dateSize.Height + 20;

            int summaryBoxWidth = (pageWidth - margin * 2) / 3;
            int summaryHeight = 40;

            Rectangle revenueRect = new Rectangle(margin, currentY, summaryBoxWidth, summaryHeight);
            Rectangle transRect = new Rectangle(margin + summaryBoxWidth, currentY, summaryBoxWidth, summaryHeight);
            Rectangle avgRect = new Rectangle(margin + summaryBoxWidth * 2, currentY, summaryBoxWidth, summaryHeight);

            g.DrawRectangle(tablePen, revenueRect);
            g.DrawRectangle(tablePen, transRect);
            g.DrawRectangle(tablePen, avgRect);

            StringFormat centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;

            g.DrawString("Total Revenue\n" + lblUpdatingTotalRevenue.Text, subHeaderFont, brush, revenueRect, centerFormat);
            g.DrawString("Total Transactions\n" + lblUpdatingTotalTransactions.Text, subHeaderFont, brush, transRect, centerFormat);
            g.DrawString("Average Sales\n" + lblUpdatingAverageSales.Text, subHeaderFont, brush, avgRect, centerFormat);

            currentY += summaryHeight + 30;

            g.DrawString("Sales Trend Over Weeks", subHeaderFont, brush, margin, currentY);
            currentY += 25;

            int tableX = margin;
            int tableWidth = pageWidth - margin * 2;
            int colWeekWidth = 100;
            int colSalesWidth = tableWidth - colWeekWidth;

            g.DrawRectangle(tablePen, tableX, currentY, colWeekWidth, 25);
            g.DrawRectangle(tablePen, tableX + colWeekWidth, currentY, colSalesWidth, 25);
            g.DrawString("Week", tableHeaderFont, brush, new Rectangle(tableX, currentY, colWeekWidth, 25), centerFormat);
            g.DrawString("Total Sales", tableHeaderFont, brush, new Rectangle(tableX + colWeekWidth, currentY, colSalesWidth, 25), centerFormat);
            currentY += 25;

            foreach (DataRow row in dtTrend.Rows)
            {
                g.DrawRectangle(tablePen, tableX, currentY, colWeekWidth, 25);
                g.DrawRectangle(tablePen, tableX + colWeekWidth, currentY, colSalesWidth, 25);

                g.DrawString("Week " + row["WeekNumber"], tableFont, brush, new Rectangle(tableX, currentY, colWeekWidth, 25), centerFormat);
                g.DrawString(Convert.ToDecimal(row["TotalSales"]).ToString("C"), tableFont, brush, new Rectangle(tableX + colWeekWidth, currentY, colSalesWidth, 25), centerFormat);

                currentY += 25;
            }

            currentY += 20;

            g.DrawString("Sales by Category", subHeaderFont, brush, margin, currentY);
            currentY += 25;

            int colCategoryWidth = 200;
            int colValueWidth = tableWidth - colCategoryWidth;

            g.DrawRectangle(tablePen, tableX, currentY, colCategoryWidth, 25);
            g.DrawRectangle(tablePen, tableX + colCategoryWidth, currentY, colValueWidth, 25);
            g.DrawString("Category", tableHeaderFont, brush, new Rectangle(tableX, currentY, colCategoryWidth, 25), centerFormat);
            g.DrawString("Total Sales", tableHeaderFont, brush, new Rectangle(tableX + colCategoryWidth, currentY, colValueWidth, 25), centerFormat);
            currentY += 25;

            foreach (DataRow row in dtCategory.Rows)
            {
                g.DrawRectangle(tablePen, tableX, currentY, colCategoryWidth, 25);
                g.DrawRectangle(tablePen, tableX + colCategoryWidth, currentY, colValueWidth, 25);

                g.DrawString(row["Category"].ToString(), tableFont, brush, new Rectangle(tableX, currentY, colCategoryWidth, 25), centerFormat);
                g.DrawString(Convert.ToDecimal(row["TotalValue"]).ToString("C"), tableFont, brush, new Rectangle(tableX + colCategoryWidth, currentY, colValueWidth, 25), centerFormat);

                currentY += 25;
            }

            e.HasMorePages = false;
        }
        private Bitmap CaptureCartesianChart(LiveCharts.WinForms.CartesianChart chart)
        {
            Bitmap bmp = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bmp, new Rectangle(0, 0, chart.Width, chart.Height));
            return bmp;
        }


        private List<(double X, double Y)> GetLiveChartPoints()
        {
            var points = new List<(double X, double Y)>();

            foreach (var series in chartSalesTrendAnalysis.Series)
            {
                foreach (var val in series.Values)
                {
                    if (val is decimal decValue)
                    {
                        int xIndex = series.Values.IndexOf(val);
                        points.Add((xIndex, (double)decValue));
                    }
                    else if (val is ObservablePoint obs)
                    {
                        points.Add((obs.X, obs.Y));
                    }
                }
            }

            return points;
        }





        private Bitmap CaptureControl(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));
            return bmp;
        }
       


        // Capture WinForms Chart
        private Bitmap CaptureWinFormsChart(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            Bitmap bmp = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bmp, new Rectangle(0, 0, chart.Width, chart.Height));
            return bmp;
        }


    }
}

