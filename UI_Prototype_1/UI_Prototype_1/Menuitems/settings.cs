using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using UI_Prototype_1;
using System.Security.Permissions;
using System.Reflection;
using System.IO;
using System.Globalization;


namespace UI_Prototype_1.Menuitems
{
    public partial class settings : UserControl
    {
        
       
        public settings()
        {
            InitializeComponent();
        }

     
        
       

        TcpClient client = new TcpClient("192.168.1.107", 8080);

        

        public void dataoku()
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
    }
}
