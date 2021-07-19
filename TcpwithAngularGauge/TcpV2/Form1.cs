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
using LiveCharts.WinForms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using System.Windows;
using Color = System.Drawing.Color;

namespace TcpV2
{    // user interfaces
    // Burak was here
    // 2
    // deneme
    public partial class Form1 : Form

    {


        int data_from_tcp = 0;
        

        public Form1()
        {
            InitializeComponent();

            angularGauge1.Value = data_from_tcp; 
            angularGauge1.FromValue = 0;
            angularGauge1.ToValue = 50;
            angularGauge1.TicksForeground = Brushes.White;
            angularGauge1.Base.Foreground = Brushes.White;
            angularGauge1.Base.FontWeight = FontWeights.Bold;
            angularGauge1.Base.FontSize = 16;
            angularGauge1.SectionsInnerRadius = 0.5;
            angularGauge1.Wedge = 200;

            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 500,
                //Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 500,
               // Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });


        }
              
   
        TcpClient client = new TcpClient("192.168.1.102", 8080);
                      
        public void btnConnect_Click(object sender, EventArgs e)
        {


            livechart.Start();


            timer1.Start();
            Thread thread;
            thread = new Thread(new ThreadStart(read));
            thread.Start();
            lblconnect.Text = "Connected";
            lblconnect.ForeColor = Color.Green;


        }
       

        public void read()
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
                data_from_tcp = Convert.ToInt32(responseData);
                txtVeri.Text = data_from_tcp.ToString();
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
            angularGauge1.Value = Convert.ToInt32(data_from_tcp);
            if(data_from_tcp>=50)
            {
                data_from_tcp = 50;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}