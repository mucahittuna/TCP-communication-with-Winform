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


    }
}
