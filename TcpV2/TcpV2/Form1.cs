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

namespace TcpV2
{    // user interfaces
    // Burak was here
    // 2
    // deneme
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        TcpClient client = new TcpClient("192.168.1.105", 8080); // wifi IP adress,port


        private void btnConnect_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Thread thread;
            thread = new Thread(new ThreadStart(read));
            thread.Start();
            lblconnect.Text = "Connected";
            lblconnect.ForeColor = Color.Green;


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
                txtRead.AppendText("Data : " + responseData + Environment.NewLine);

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
    }
}