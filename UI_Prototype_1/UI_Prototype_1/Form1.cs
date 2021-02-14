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
        homePage homePage = new homePage();

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(iscollapse==false)
            {
                
                bunifuGradientPanel3.Width = 1400;
                

                
                bunifuGradientPanel2.Width = 60;
                
                iscollapse = true;
            }
            else
            {
                bunifuGradientPanel2.Width = 300;
                bunifuGradientPanel3.Width = 1131;
                
                iscollapse = false;
            }
        }

        private void AddControlsToPanel(Control c)
        {
            
        }

        
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            var alpha = bunifuGradientPanel3.Controls.IndexOf(bunifuGradientPanel3);
            var beta = homePage.Controls.IndexOf(homePage);
            

        }
    }
}
