using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace assignment2_mmcken5
{
    public partial class mainView : Form
    {
        private ClientController controller;
        private int port;
        private IPAddress serverIP; 

        public mainView()
        {
            InitializeComponent();

            // Set the initial index of the video name drop down menu to be selected
            comboBox_video_name.SelectedIndex = 0;

            HideTransparentButtons();

            controller = new ClientController(); 
        }

        // Mouse has entered the video box frame area
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            ShowTransparentButtons();
        }

        // Display the semi-transparent buttons
        private void ShowTransparentButtons()
        {
            pictureBox2.Show();
            pictureBox2.Enabled = true;

            pictureBox3.Show();
            pictureBox3.Enabled = true;

            pictureBox4.Show();
            pictureBox4.Enabled = true;

            pictureBox5.Show();
            pictureBox5.Enabled = true;
        }

        // Hide the semi-transparent buttons
        private void HideTransparentButtons()
        {
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
        }

        // Semi-transparent setup button has been clicked
        private void ST_Setup_Clicked(object sender, EventArgs e)
        {
            // Call setup function in controller
            Console.WriteLine("Setup has been clicked");
        }

        // Semi-transparent play button has been clicked
        private void ST_Play_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Play has been clicked");
        }

        // Semi-transparent pause button has been clicked
        private void ST_Pause_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Pause has been clicked");
        }
        
        // Semi-transparent teardown button has been clicked
        private void ST_Teardown_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Teardown has been clicked");
        }

        // Mouse has left the video frame area
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (panel1.GetChildAtPoint(panel1.PointToClient(MousePosition)) == null)
            {
                HideTransparentButtons();   
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        private void mainView_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        private void button_setup_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        private void button_play_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        private void button_pause_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        private void button_teardown_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        // Validate the user input and then let the controller know the client wishes to connect to the server
        private void button_connect_Click(object sender, EventArgs e)
        {
            // Validate the user input for the port number
            try
            {
                port = int.Parse(textBox_port.Text);

                // Check the port number is greater than 1024
                if (port <= 1024)
                {
                    MessageBox.Show("Please enter a port number greater than 1024.");
                }
                else
                {
                    // Validate the user input for the server IP address
                    try
                    {
                        // Convert the user input to an IP address
                        serverIP = IPAddress.Parse(textBox_server_ip.Text);

                        // After successful validation, signal the controller
                        controller.Connect_Button_Click(sender, e);
                    }
                    catch (ArgumentNullException)
                    {
                        MessageBox.Show("Please enter a port number.");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Please make sure that the server IP address is a valid IP address");
                    }
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please enter a port number.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure the entered port number is an integer.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("An overflow exception has occured. Please make sure you are entering a"
                    + "correct port number that is an integer.");
            }
        }

        // Disables the controls associated with connecting
        public void Disable_InputTextBoxes()
        {
            textBox_port.ReadOnly = true;
            textBox_server_ip.ReadOnly = true;
            button_connect.Enabled = false;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            // TODO: Close the sockets

            // TODO: Close the application
        }

        public int GetPort()
        {
            return port;
        }

        public IPAddress GetServerIP()
        {
            return serverIP;
        }
    }
}
