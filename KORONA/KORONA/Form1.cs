using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace KORONA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GELCU46\\SQLEXPRESS;Initial Catalog=corona;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayList italyaCoords = new ArrayList();

            SqlCommand com = new SqlCommand("Select * from İTALYA", baglanti);
             baglanti.Open();
           SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                italyaCoords.Add(dr["Ölüm"].ToString());

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

         //   double[] dünyaCoords = { 17, 8, 16, 15, 24, 26, 38, 43, 46, 45, 58, 64, 66, 73, 73, 86, 89, 97, 108, 97, 146, 122, 143, 143, 106, 98, 136, 117, 121, 113, 100, 158, 81, 64, 37, 58, 65, 54, 73, 67, 85, 83, 102, 106, 105, 228, 197, 274, 330, 353, 447, 414, 691, 648, 820, 983, 1094, 1380, 1644, 1638, 1932, 2486, 2589, 2945, 3469, 3671, 3343, 4160, 4709, 5190, 6270, 5962, 6066, 5004, 5606, 7892, 6735, 7666, 7347, 6208, 5565, 5639, 7408, 8190, 6998, 8429, 6676, 4894, 5489, 7284, 6698, 6705, 6417, 6101, 3757, 4509, 6688, 6593, 5795, 5623, 5217, 3480, 4096, 5786, 6811, 5589, 5550, 4248, 3508, 3451, 5561, 5364, 5355, 5079, 4360, 3618, 3445, 4589, 4685, 4934, 5252, 4183, 2826, 1172, 4048, 5283, 5227, 4921, 4099, 3190, 3054, 4671, 4929, 5511, 4906, 4253, 3385, 3157, 4732, 5163, 4951, 4603, 4229, 3263, 3415, 6592, 5264, 6246, 5078, 4429, 3338, 3880, 5465, 5071, 5182, 4850, 4568, 3483, 3441, 5046, 4859, 5164, 5187, 4538, 3608, 3577, 5524, 5525, 5417, 5428, 5019, 4122, 3718, 5414 };//dünya
            double[] xCoords = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174 };//gün
            double[] ıtalyaCoords = { 0,0,0,0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 4, 3, 2, 5, 4, 8, 5, 18, 27, 28, 41, 49, 36, 133, 97, 168, 196, 189, 250, 175, 368, 349, 345, 475, 427, 627, 793, 651, 601, 743, 683, 712, 919, 889, 756, 812, 837, 727, 760, 766, 681, 525, 636, 604, 542, 610, 570, 619, 431, 566, 602, 578, 525, 575, 482, 433, 454, 534, 437, 464, 420, 415, 260, 333, 382, 323, 285, 269, 474, 174, 195, 236, 369, 274, 243, 194, 165, 179, 172, 195, 262, 242, 153, 145, 99, 162, 161, 156, 130, 119, 50, 92, 78, 117, 70, 87, 111, 75, 60, 55, 71, 88, 85, 72, 53, 65, 79, 71, 53, 56, 78, 44, 26, 34, 43, 66, 47, 49, 24, 23, 18, 21, 34, 30, 21, 30, 15, 21, 7, 8, 30, 15, 12, 12, 7, 9, 13, 14};//italya
            
            chart1.Series["Dünya"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["İtalya"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["İtalya"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
       
            for (int i = 0; i < xCoords.Length; i++)
                chart1.Series["İtalya"].Points.AddXY(xCoords[i], italyaCoords[i]);
                chart1.Series["İtalya"].Color = Color.Green;

            for(int i = 0; i < xCoords.Length; i++)
            {
                chart1.Series["Dünya"].Points.AddXY(xCoords[i], dünyaCoords[i]);
                chart1.Series["Dünya"].Color = Color.Black;
            }

            for(int i = 0; i < xCoords.Length; i++)
            {
                chart2.Series["İtalya"].Points.AddXY(xCoords[i], italyaCoords[i]);
                chart2.Series["İtalya"].Color = Color.Green;

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

            var y1 = DenseMatrix.OfColumns(ıtalyaCoords.Length, 1, new[] { new DenseVector(ıtalyaCoords) });


            var qrTheta1 = X.QR().Solve(y1).ToColumnMajorArray();
       
            var xMax = xCoords.Max(); 
            var xMin = xCoords.Min();
            var interval = (xMax - xMin) / Convert.ToDouble(xMax-1);

            for(var i = xMin; i <= xMax; i+=interval)
            {

               chart2.Series["Series2"].Points.AddXY(i, yPrediction(i, qrTheta1));
              
            }
        }
        private static double yPrediction(double xPlot,double[] theta)
        {
            var yPlot = 0.0;
            for(var i = 0; i < theta.Length; i++)
            
                yPlot += theta[i] * Math.Pow(xPlot, i);
                return yPlot;
            

            
        }
    }
}
