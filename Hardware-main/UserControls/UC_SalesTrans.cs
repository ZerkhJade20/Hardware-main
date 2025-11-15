using Guna.UI2.WinForms;
using LiveCharts;
using LiveCharts.Defaults;
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
    public partial class UC_SalesTrans : UserControl
    {
        public UC_SalesTrans()
        {
            InitializeComponent();
            guna2Panel1.Hide();
            chartWeeklySalesOverview.Series = new SeriesCollection
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

        private void UC_SalesTrans_Load(object sender, EventArgs e)
        {

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
            guna2Panel1.Hide();
        }
    }
}
