using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment2_mmcken5
{
    public partial class UsedPortDialog : Form
    {
        private RtpModel rtpModel;
        private List<int> usedPorts;
        private bool newPortNum;


        public UsedPortDialog(RtpModel _rtpModel ,List<int> _usedPorts)
        {
            InitializeComponent();

            usedPorts = _usedPorts;
            rtpModel = _rtpModel;

            // Load the ports that have already been used
            foreach (int i in usedPorts)
            {
                textBox1.AppendText(i.ToString());
            }
        }


        // Exit the application
        private void button2_Click(object sender, EventArgs e)
        {
            newPortNum = false; 

            // Close the form
            this.Close();
        }


        // Validate and return the new udp port to bind
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate the port number
                int p = Int32.Parse(textBox2.Text);

                if (p <= 1024)
                {
                    MessageBox.Show("Please enter a port number greater than 1024.");
                }

                else
                {
                    bool matchFound = false;

                    // Verify that the entered port number has not already been used
                    foreach (int i in usedPorts)
                    {
                        if (p == i)
                        {
                            matchFound = true;
                            MessageBox.Show("Please enter a port number that has not already been used.");
                        }
                    }

                    // If the port number entered by the user has not already been used, use it now
                    if (!matchFound)
                    {
                        // Update the rtp model
                        rtpModel.SetNewUdpPort(p);

                        button1.DialogResult = DialogResult.Yes;
                        newPortNum = true; 

                        // Close the form
                        this.Close();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Please enter a valid port number");
            }
            catch (FormatException exc)
            {
                MessageBox.Show("Please enter a valid port number");
            }
        }


        // Return the new port number
        public bool GetDialogResult()
        {
            return newPortNum;
        }
    }
}
