using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KORONA
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GELCU46\\SQLEXPRESS;Initial Catalog=corona;Integrated Security=True");

        private void Form5_Load(object sender, EventArgs e)
        {
            ArrayList amerikaCoords = new ArrayList();
            SqlCommand com = new SqlCommand("Select * from Amerika", baglanti);
            baglanti.Open();
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                amerikaCoords.Add(dr["Ölüm"].ToString());

            }
            baglanti.Close();

            ArrayList dünyaCoords = new ArrayList();

            SqlCommand com2 = new SqlCommand("Select * from Dünya", baglanti);
            baglanti.Open();
            SqlDataReader dr2 = com2.ExecuteReader();
            while (dr2.Read())
            {
                dünyaCoords.Add(dr2["Ölüm"].ToString());

            }
            baglanti.Close();

           // double[] dünyaCoords = { 17, 8, 16, 15, 24, 26, 38, 43, 46, 45, 58, 64, 66, 73, 73, 86, 89, 97, 108, 97, 146, 122, 143, 143, 106, 98, 136, 117, 121, 113, 100, 158, 81, 64, 37, 58, 65, 54, 73, 67, 85, 83, 102, 106, 105, 228, 197, 274, 330, 353, 447, 414, 691, 648, 820, 983, 1094, 1380, 1644, 1638, 1932, 2486, 2589, 2945, 3469, 3671, 3343, 4160, 4709, 5190, 6270, 5962, 6066, 5004, 5606, 7892, 6735, 7666, 7347, 6208, 5565, 5639, 7408, 8190, 6998, 8429, 6676, 4894, 5489, 7284, 6698, 6705, 6417, 6101, 3757, 4509, 6688, 6593, 5795, 5623, 5217, 3480, 4096, 5786, 6811, 5589, 5550, 4248, 3508, 3451, 5561, 5364, 5355, 5079, 4360, 3618, 3445, 4589, 4685, 4934, 5252, 4183, 2826, 1172, 4048, 5283, 5227, 4921, 4099, 3190, 3054, 4671, 4929, 5511, 4906, 4253, 3385, 3157, 4732, 5163, 4951, 4603, 4229, 3263, 3415, 6592, 5264, 6246, 5078, 4429, 3338, 3880, 5465, 5071, 5182, 4850, 4568, 3483, 3441, 5046, 4859, 5164, 5187, 4538, 3608, 3577, 5524, 5525, 5417, 5428, 5019, 4122, 3718, 5414 };//dünya
            double[] xCoords = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174 };//gün
            double[] amerıkaCoords = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 1, 4, 1, 2, 3, 4, 1, 6, 4, 11, 9, 7, 13, 28, 34, 57, 78, 97, 90, 144, 184, 235, 310, 407, 548, 637, 625, 806, 1216, 1219, 1562, 1297, 1266, 1411, 1662, 2305, 2079, 2046, 2071, 2012, 1740, 1798, 2393, 2515, 2087, 2590, 2345, 1182, 1770, 2396, 2335, 2320, 1777, 2269, 1147, 1340, 2130, 2620, 2039, 1952, 1425, 1322, 1247, 2150, 2388, 2211, 1509, 1627, 734, 1162, 1691, 1743, 1777, 1633, 1222, 809, 790, 1569, 1523, 1245, 1276, 1110, 633, 502, 698, 1505, 1193, 1176, 941, 605, 771, 1031, 983, 1035, 970, 675, 451, 493, 946, 921, 888, 846, 767, 296, 395, 836, 754, 715, 692, 596, 259, 423, 829, 754, 2425, 629, 645, 741, 631, 242, 271, 338, 1195, 820, 990, 802, 685, 841, 349, 899 };//abd

            chart1.Series["Dünya"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Abd"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["Abd"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

            for (int i = 0; i < xCoords.Length; i++)
                chart1.Series["Abd"].Points.AddXY(xCoords[i], amerikaCoords[i]);
            chart1.Series["Abd"].Color = Color.Aqua;

            for (int i = 0; i < xCoords.Length; i++)
            {
                chart1.Series["Dünya"].Points.AddXY(xCoords[i], dünyaCoords[i]);
                chart1.Series["Dünya"].Color = Color.Black;
            }
            for (int i = 0; i < xCoords.Length; i++)
            {
                chart2.Series["Abd"].Points.AddXY(xCoords[i], amerikaCoords[i]);
            }

            chart2.Series["Series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["Series2"].Color = Color.Red;

            var degree = 1;
            var X = new DenseMatrix(xCoords.Length, degree + 1);
            X.SetColumn(0, DenseVector.Create(xCoords.Length, i => 1));

            if (degree != 0)
            {
                X.SetColumn(1, xCoords);
            }
            for (int i = 2; i <= degree; i++)
                X.SetColumn(i, X.Column(1).PointwiseMultiply(X.Column(i - 1)));

            var y = DenseMatrix.OfColumns(amerıkaCoords.Length, 1, new[] { new DenseVector(amerıkaCoords) });
            var qrTheta = X.QR().Solve(y).ToColumnMajorArray();

            var xMax = xCoords.Max();
            var xMin = xCoords.Min();
            var interval = (xMax - xMin) / Convert.ToDouble(xMax - 1);

            for (var i = xMin; i <= xMax; i += interval)
            {
                chart2.Series["Series2"].Points.AddXY(i, yPrediction(i, qrTheta));
               
            }


        }
        private static double yPrediction(double xPlot, double[] theta)
        {
            var yPlot = 0.0;
            for (var i = 0; i < theta.Length; i++)

                yPlot += theta[i] * Math.Pow(xPlot, i);
            return yPlot;

        }
    }
}


