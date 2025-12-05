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
        private PrintDocument printDocument;
        private PrintPreviewDialog previewDialog;
        public UC_Reports()
        {
            InitializeComponent();
            LoadReportData();
            printDocument = new PrintDocument();
            printDocument.PrintPage += printDocument1_PrintPage;

            previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument;
            previewDialog.Width = 1000;
            previewDialog.Height = 800;
            btnPrintReport.Click += BtnPrint_Click;
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
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF File|*.pdf";
                    sfd.FileName = "Report.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    using (System.IO.FileStream stream = new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create))
                    {
                        // 1️⃣ Create PDF document
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20);
                        iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // 2️⃣ Capture UC labels (optional: just labels panel or the whole UC)
                        Bitmap labelsBmp = new Bitmap(this.Width, this.Height);
                        this.DrawToBitmap(labelsBmp, new Rectangle(0, 0, this.Width, this.Height));

                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            labelsBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(ms.ToArray());

                            // Scale image to fit page width
                            if (pdfImage.Width > pdfDoc.PageSize.Width - pdfDoc.LeftMargin - pdfDoc.RightMargin)
                            {
                                pdfImage.ScaleToFit(pdfDoc.PageSize.Width - pdfDoc.LeftMargin - pdfDoc.RightMargin,
                                                    pdfDoc.PageSize.Height - pdfDoc.TopMargin - pdfDoc.BottomMargin);
                            }

                            pdfDoc.Add(pdfImage);
                        }

                        pdfDoc.Close();
                    }

                    MessageBox.Show("PDF generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message);
            }
        }

        private void chartSalesTrendAnalysis_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Capture entire UserControl into a bitmap
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

            // Optionally scale to fit page
            float scale = Math.Min((float)e.MarginBounds.Width / bmp.Width,
                                   (float)e.MarginBounds.Height / bmp.Height);

            int printWidth = (int)(bmp.Width * scale);
            int printHeight = (int)(bmp.Height * scale);

            e.Graphics.DrawImage(bmp, e.MarginBounds.Left, e.MarginBounds.Top, printWidth, printHeight);
        }
        private Bitmap CaptureControl(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));
            return bmp;
        }
        // Capture CartesianChart (LiveCharts WPF)
        private Bitmap CaptureCartesianChart(LiveCharts.Wpf.CartesianChart chart)
        {
            chart.Update(true, true); // Force redraw

            int width = (int)chart.ActualWidth;
            int height = (int)chart.ActualHeight;
            if (width == 0 || height == 0)
            {
                width = chart.Width > 0 ? (int)chart.Width : 938; // fallback size
                height = chart.Height > 0 ? (int)chart.Height : 513;
            }

            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96, 96, System.Windows.Media.PixelFormats.Pbgra32);
            rtb.Render(chart);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                return new Bitmap(ms);
            }
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

