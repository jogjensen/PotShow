using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PortCombo.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

            //Update interval
            Timer tmr = new Timer();
            tmr.Interval = 250;
            tmr.Tick += timer1_Tick;
            tmr.Start();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = PortCombo.SelectedItem.ToString();
                ConnectButton.Text ="Disconnect";
                serialPort1.Open();
                timer1.Enabled = true;
            }
            else
            {
                ConnectButton.Text = "Connect";
                serialPort1.Close();
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                while (serialPort1.ReadChar() != 'a') { }
                byte[] packet = new byte[3];
                serialPort1.Read(packet, 0, 3);

                //Show everything
                textBox1.Text += serialPort1.ReadExisting();
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();

                //Pot1 data & progressbar
                Pot1Text.Text = ((int)packet[0]).ToString();
                progressBar1.Value = packet[0];

                //Pot2 data & progressbar
                Pot2Text.Text = ((int)packet[1]).ToString();
                progressBar2.Value = packet[1];
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void Pot1Text_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("O");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("F");
            }
        }
    }
}
