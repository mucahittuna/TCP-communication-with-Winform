using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Media;


using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using Point = System.Windows.Point;
using System.Drawing.Drawing2D;



namespace TcpV2
{
    public partial class Form1 : Form
    {

        public class MeasureModel
        {
            public System.DateTime DateTime { get; set; }
            public double Value { get; set; }
        }

        public ChartValues<MeasureModel> ChartValues { get; set; }

        double minY = 0;
        double maxY = 1000;
        int data_from_tcp = 0;

        public Form1()
        {
            InitializeComponent();

            #region Grandyan Çizgi Altı
            var gradientBrush = new System.Windows.Media.LinearGradientBrush
            {
                StartPoint = new System.Windows.Point(0, 0),
                EndPoint = new Point(0, 1)
            };

            gradientBrush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(33, 148, 241), 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
            #endregion

            #region ile baglanti
            var mapper = Mappers.Xy<MeasureModel>()
               .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
               .Y(model => model.Value);           //use the value property as Y

            Charting.For<MeasureModel>(mapper);
            #endregion

            #region Data Setini Ayarla
            ChartValues = new ChartValues<MeasureModel>();

            cartesianChart1.Series.Add(new LineSeries
            {
                Values = ChartValues,

                Fill = gradientBrush,
                StrokeThickness = 1,
                PointGeometry = null
            });
            #endregion

            #region Arka Plan Rengi
            cartesianChart1.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 40, 50));
            #endregion

            #region Eksen Ayarları
            cartesianChart1.AxisX.Add(new Axis
            {
                //IsMerged = true,
                //LabelFormatter = value => new System.DateTime((long)value).ToString("mm:ss"),
                LabelFormatter = value => "",

                Separator = new Separator
                {
                    //StrokeThickness = 1.5,
                    //StrokeDashArray = new System.Windows.Media.DoubleCollection(new double[] { 4 }),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86)),
                    Step = TimeSpan.FromMilliseconds(1000).Ticks
                }

            });

            SetAxisLimits(System.DateTime.Now);

            cartesianChart1.AxisY.Add(new Axis
            {
                
                FontSize = 15,
                MinValue = minY,
                MaxValue = maxY,
                LabelFormatter = val => val + " cm",
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1.5,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(new double[] { 4 }),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });

            cartesianChart1.DisableAnimations = true;
            #endregion


        }

        private void SetAxisLimits(System.DateTime now)
        {
            //cartesianChart1.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 100ms ahead
            cartesianChart1.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(10).Ticks; //we only care about the last 10 seconds
        }


        TcpClient client = new TcpClient("192.168.1.100", 8080); // wifi IP adress,port


        private void btnConnect_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Thread thread;
            thread = new Thread(new ThreadStart(read));
            thread.Start();
            lblconnect.Text = "Connected";
            lblconnect.ForeColor = System.Drawing.Color.Green;


        }

        private void read()
        {
         
            while (true)
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                NetworkStream stream = client.GetStream();
                Byte[] data = new Byte[256];
                String responseData = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                txtRead.AppendText(responseData + Environment.NewLine);

                data_from_tcp = Int32.Parse(responseData);
            }
           
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message;
            message = txtSend.Text.ToString();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);


        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            label1.Text = i.ToString();
        }

        private void livechart_Tick(object sender, EventArgs e)
        {
            var now = System.DateTime.Now;

            ChartValues.Add(new MeasureModel
            {
                DateTime = now,
                Value = data_from_tcp
            }) ; ; ;

            SetAxisLimits(now);

            //lets only use the last 30 values
            if (ChartValues.Count > 205) ChartValues.RemoveAt(0);
        }
    }
}