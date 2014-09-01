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
using System.Timers;

namespace CoordPingStress
{
    public partial class Form1 : Form
    {
        // The main control for communicating through the RS-232 port
        private SerialPort comport = new SerialPort();
        bool error = false;
        byte coodrSequ;
        List<TAG> tagList = new List<TAG>();
        //static System.Timers.Timer _timer;
        bool finnished;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
                comboBox1.Items.Add(s);
        }

 

        private void setButton_Click(object sender, EventArgs e)
        {
            coodrSequ = 0;
            finnished = true;
            
            

            // open com port ***********************************************************

            if (comport.IsOpen) comport.Close();
            else
            {
                // Set the port's settings
                comport.BaudRate = 115200;//38400;
                comport.DataBits = 8;
                comport.StopBits = StopBits.One;
                comport.Parity = Parity.None;
                comport.PortName = comboBox1.Text;

                try
                {
                    // Open the port
                    comport.Open();
                }
                catch (UnauthorizedAccessException) { error = true; }
                //catch (IOException) { error = true; }
                catch (ArgumentException) { error = true; }

                if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {

                }
            }

            // open com port ***********************************************************
        }
        
        private void startButton_Click(object sender, EventArgs e)
        {

            //_timer = new System.Timers.Timer(Convert.ToInt32(burstGapText.Text));
            //_timer.Elapsed += new ElapsedEventHandler(timer_elapsed);
            //_timer.Enabled = true; // Enable it

            timer1.Interval = Convert.ToInt32(burstGapText.Text);
            

            // create tags ***********************************************************
            tagList.Clear();
            int numberOfTagsInt = Convert.ToInt32(noOfTagsText.Text);

            UInt64 startAddress = 0x00158d0123abc000;

            for (int i = 0; i < numberOfTagsInt; i++)
            {
               // if (i == 0x10) { startAddress++; }


                tagList.Add(new TAG(startAddress++));
            }

            startButton.Enabled = false;
            stopButton.Enabled = true;
            noOfTagsText.Enabled = false;
            gapText.Enabled = false;
            burstGapText.Enabled = false;

            timer1.Enabled = true;
            timer1.Start();

            SendBurst();
        }
            
        
        private void stopButton_Click(object sender, EventArgs e)
        {
            //_timer.Stop();
            timer1.Stop();
            //_timer = null;

            //tagList.Clear();
            startButton.Enabled = true;
            stopButton.Enabled = false;
            noOfTagsText.Enabled = true;
            gapText.Enabled = true;
            burstGapText.Enabled = true;


        }

         
        private void SendData(byte[] data)
        {
            //byte[] testData = new byte[] { 0x10, 0x2, 0x40, 0xe6, 0x54, 0x10, 0x10, 0x27, 0x0, 0x0, 0x30,
            //                               0x0 , 0x0 , 0xB6 , 0x08 , 0x0E , 0x0 , 0xF4 , 0xF1 , 0x11 , 0x0 , 0x0,
            //                               0x8D , 0x15 , 0x00 , 0x1E , 0x9F , 0x2E , 0x0 , 0x0 , 0x8D,
            //                               0x15 , 0x0 , 0x75 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0,
            //                               0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x0 , 0x1E , 0x9F , 0x2E,
            //                               0x0 , 0x0 , 0x8D , 0x15 , 0x0 , 0x6F , 0x0 , 0x0 , 0x0,
            //                               0x0 , 0x0 , 0x0 , 0x0 , 0x0  , 0x04 , 0x09 , 0x82 , 0x57
            //                                };
            // if (CurrentDataMode == DataMode.Text)
            // {
            // Send the user's text straight out the port
            try
            {

               //comport.Write(data, 0, data.Length);
                comport.Write(data, 0, data[2]+3);
              
            }
            catch (Exception)
            {
                MessageBox.Show("send error");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendBurst();
            
        }

        private void SendBurst()
        {
            if (finnished)
            {
                finnished = false;
                foreach (TAG tag in tagList.ToList())
                {
                    tag.setSequ(coodrSequ++);



                    SendData(tag.formatUartPacket());
                    System.Threading.Thread.Sleep(Convert.ToInt32(gapText.Text));

                }
                sequTextBox.Text = Convert.ToString(coodrSequ - 1);
                finnished = true;
            }
            else
            {
                sequTextBox.Text = "not finnished";
            }
        }




    }
}
