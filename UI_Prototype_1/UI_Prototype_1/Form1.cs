using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Prototype_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool iscollapse = false;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(iscollapse==false)
            {
                bunifuGradientPanel2.Width = 60;
                bunifuGradientPanel3.Width = 1400;
                iscollapse = true;
            }
            else
            {
                bunifuGradientPanel2.Width = 300;
                bunifuGradientPanel3.Width = 1131;
                iscollapse = false;
            }
        }

      
    }
}
