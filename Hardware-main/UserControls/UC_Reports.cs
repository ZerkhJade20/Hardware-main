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
            btnPrint.Click += BtnPrint_Click;
            chartSalesTrendAnalysis.Series = new SeriesCollection
            { 
            new LineSeries
            {
                Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 10),
                        new ObservablePoint(4, 7),
                        new ObservablePoint(5, 8),
                        new ObservablePoint(6, 9),
                        new ObservablePoint(7, 10),
                    },
                PointGeometrySize = 15
            }
            };


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
    }
}
