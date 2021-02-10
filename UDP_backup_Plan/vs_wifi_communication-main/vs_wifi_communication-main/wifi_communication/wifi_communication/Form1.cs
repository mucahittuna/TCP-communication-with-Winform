using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace wifi_communication
{
    public partial class Form1 : Form
    {

        UdpClient Client = new UdpClient(8800);
        public Form1()
        {
             //this device Port number (uygulama ayarlar sekmesinde remoto port yerine bunu yazılacak)
                                                                            //(uygulamada ayarlar sekmesindeki remote addr yerine, pc de cmd ye girip ipconfig yazılmalı ve çıkan ipv4 adresi girilmeli)
            InitializeComponent();
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("192.168.1.101"); //slave adress (Uygulamada Sol yukarda yazan yani telefonun ip si)

            byte[] sendbuf = Encoding.ASCII.GetBytes(richTextBox1.Text);

            IPEndPoint ep = new IPEndPoint(broadcast, 8080); //slave adress, slave port(uygulama ayarlar sekmesindeki local port)

            s.SendTo(sendbuf, ep);
        }
  
        private void read_btn_Click(object sender, EventArgs e)
        {
            UdpClient listener = new UdpClient(8080);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 8080);

            try
            {
                while (true)
                {
                    richTextBox2.Text = "Waiting a message";
                    byte[] bytes = listener.Receive(ref groupEP);

                   richTextBox2.Text= ($"Received broadcast from {groupEP} :");
                   richTextBox2.Text= ($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                }
            }
            catch (SocketException )
            {
               
            }
            finally
            {
                listener.Close();
            }






        }
    }
}
