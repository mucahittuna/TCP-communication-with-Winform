using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using UI_Prototype_1.Menuitems;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Threading;

namespace UI_Prototype_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool iscollapse = false;
        homePage home_page = new homePage();
        aboutUs about_us = new aboutUs();
        missions missions = new missions();
        settings settings = new settings();

       





        #region menubar
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (iscollapse == false)
            {
                bunifuGradientPanel2.Width = 60;
                iscollapse = true;
            }
            else
            {
                bunifuGradientPanel2.Width = 200;
                iscollapse = false;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel3.Controls.Remove(home_page);
            bunifuGradientPanel3.Controls.Remove(missions);
            bunifuGradientPanel3.Controls.Remove(about_us);
            bunifuGradientPanel3.Controls.Remove(settings);
            
        }
        private void btnMissions_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel3.Controls.Add(missions);
            bunifuGradientPanel3.Controls.Remove(home_page);
            bunifuGradientPanel3.Controls.Remove(about_us);
            bunifuGradientPanel3.Controls.Remove(settings);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel3.Controls.Add(settings);
            bunifuGradientPanel3.Controls.Remove(home_page);
            bunifuGradientPanel3.Controls.Remove(missions);
            bunifuGradientPanel3.Controls.Remove(about_us);
           
        }
        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel3.Controls.Add(about_us);
            bunifuGradientPanel3.Controls.Remove(home_page);
            bunifuGradientPanel3.Controls.Remove(missions);
            bunifuGradientPanel3.Controls.Remove(settings);
        }


        #endregion


         
        TcpClient client = new TcpClient(); // TCp yi arkaplanda hazır hale getiriyoruz.
        

        public void btnConnect_Click(object sender, EventArgs e)
        { 
            var ipNum = txtHost.text;
            int portNum = Convert.ToInt32(txtPort.text);
            client = new TcpClient(ipNum, portNum);
            Thread thread;
            thread = new Thread(new ThreadStart(settings.dataoku));
            thread.Start();

            lblStatus.Text = "Connected";

        }

        
    }



    }

