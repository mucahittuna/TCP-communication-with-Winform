namespace TcpV2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblconnect = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtRead = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.angularGauge1 = new LiveCharts.WinForms.AngularGauge();
            this.livechart = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtVeri = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lblconnect
            // 
            this.lblconnect.AutoSize = true;
            this.lblconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblconnect.Location = new System.Drawing.Point(299, 9);
            this.lblconnect.Name = "lblconnect";
            this.lblconnect.Size = new System.Drawing.Size(20, 29);
            this.lblconnect.TabIndex = 10;
            this.lblconnect.Text = ".";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(451, 489);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(143, 44);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(363, 210);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(231, 237);
            this.txtSend.TabIndex = 8;
            // 
            // txtRead
            // 
            this.txtRead.Location = new System.Drawing.Point(67, 210);
            this.txtRead.Multiline = true;
            this.txtRead.Name = "txtRead";
            this.txtRead.Size = new System.Drawing.Size(231, 237);
            this.txtRead.TabIndex = 7;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(576, 96);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(143, 44);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(135, 107);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(145, 22);
            this.txtHost.TabIndex = 12;
            this.txtHost.Text = "192.168.1.102";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(339, 107);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(145, 22);
            this.txtPort.TabIndex = 13;
            this.txtPort.Text = "8080";
            // 
            // angularGauge1
            // 
            this.angularGauge1.Location = new System.Drawing.Point(775, 262);
            this.angularGauge1.Name = "angularGauge1";
            this.angularGauge1.Size = new System.Drawing.Size(394, 288);
            this.angularGauge1.TabIndex = 14;
            this.angularGauge1.Text = "Speed";
            // 
            // livechart
            // 
            this.livechart.Tick += new System.EventHandler(this.livechart_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "label2";
            // 
            // txtVeri
            // 
            this.txtVeri.Location = new System.Drawing.Point(930, 601);
            this.txtVeri.Name = "txtVeri";
            this.txtVeri.Size = new System.Drawing.Size(100, 22);
            this.txtVeri.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1270, 872);
            this.Controls.Add(this.txtVeri);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.angularGauge1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblconnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtRead);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblconnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.TextBox txtRead;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.TextBox txtHost;
        public System.Windows.Forms.TextBox txtPort;
        private LiveCharts.WinForms.AngularGauge angularGauge1;
        private System.Windows.Forms.Timer livechart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtVeri;
    }
}

