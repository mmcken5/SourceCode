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

        private bool displaySetup = true;
        private bool displayPlay = true;
        private bool displayPause = true;
        private bool displayTeardown = true;

        private bool firstMessage = true;

        public mainView()
        {
            // Initialize all the form components and display the UI
            InitializeComponent();

            // Set the initial index of the video name drop down menu to be selected
            comboBox_video_name.SelectedIndex = 0;

            // Hide the transparent buttons in the video frame box
            HideTransparentButtons();

            // Hide the streaming panels
            panel1.Hide();
            panel2.Hide();

            // Create a new controller
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
            if (displaySetup)
            {
                pictureBox2.Show();
                pictureBox2.Enabled = true;
            }

            if (displayPlay)
            {
                pictureBox3.Show();
                pictureBox3.Enabled = true;
            }

            if (displayPause)
            {
                pictureBox4.Show();
                pictureBox4.Enabled = true;
            }

            if (displayTeardown)
            {
                pictureBox5.Show();
                pictureBox5.Enabled = true;
            }
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
            // Disable all buttons except the play button
            button_setup.Enabled = false;
            button_pause.Enabled = false;
            button_teardown.Enabled = false;

            // Disable all the semi-transparent buttons except for the play button
            displaySetup = false;
            displayPause = false;
            displayTeardown = false;

            // Call setup function in controller
            controller.SetupClicked(comboBox_video_name.Text);
            Console.WriteLine("Setup has been clicked");
        }

        // Semi-transparent play button has been clicked
        private void ST_Play_Clicked(object sender, EventArgs e)
        {
            // Disable play button


            // Enable pause and play buttons

            // TODO: Call play function in controller

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

        // Mouse has left the video frame area
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        // Mouse has left the video frame area
        private void mainView_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        // Mouse has left the video frame area
        private void button_setup_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        // Mouse has left the video frame area
        private void button_play_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        // Mouse has left the video frame area
        private void button_pause_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        // Mouse has left the video frame area
        private void button_teardown_MouseEnter(object sender, EventArgs e)
        {
            HideTransparentButtons();
        }

        // Mouse has left the video frame area
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

                        // Display the streaming panel
                        panel1.Show();
                        panel2.Show();

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
            textBox_port.Enabled = false;
            textBox_server_ip.Enabled = false; 
            button_connect.Enabled = false;
        }

        // The exit button has been pressed and the application is about to close
        private void button_exit_Click(object sender, EventArgs e)
        {
            // Let the controller know that the application is about to close
            controller.CloseConnections();

            // TODO: Close the application
        }

        // Return the port number to connect to, as entered by the user
        public int GetPort()
        {
            return port;
        }

        // Return the server's IP address as entered by the user
        public IPAddress GetServerIP()
        {
            return serverIP;
        }

        // Adds a message to the server responses text box
        public void UpdateServerResponsesTextBox(string message)
        {
            if (firstMessage)
            {
                textBox4.Text += message + "\r\n";
            }
            else
            {
                textBox4.Text += "\r\n" + message + "\r\n";
            }
        }

        // Adds a message to the information text box 
        public void UpdateInfoTextBox(string message)
        {
            if (firstMessage)
            {
                textBox3.Text += message + "\r\n";
                firstMessage = false;
            }
            else
            {
                textBox3.Text += "\r\n" + message + "\r\n";
            }
        }
    }
}
