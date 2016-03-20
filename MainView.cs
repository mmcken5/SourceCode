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
            // Call setup function in controller
            controller.SetupClicked(comboBox_video_name.Text);
        }


        // Disable all of the RTSP buttons, except for the PLAY button
        public void DisplayPlay()
        {
            // Disable all buttons except the play button
            button_setup.Enabled = false;
            button_pause.Enabled = false;
            button_teardown.Enabled = false;

            // Disable all the semi-transparent buttons except for the play button
            displaySetup = false;
            pictureBox2.Hide();
            displayPause = false;
            pictureBox4.Hide();
            displayTeardown = false;
            pictureBox5.Hide();

            // Enable the play button
            button_play.Enabled = true;
            displayPlay = true;
            pictureBox3.Show();
        }


        // Semi-transparent play button has been clicked
        private void ST_Play_Clicked(object sender, EventArgs e)
        {
            // Disable play button
            button_play.Enabled = false;
            displayPlay = false;
            pictureBox3.Hide();

            // Enable pause and teardown buttons
            button_pause.Enabled = true;
            pictureBox4.Show();
            displayPause = true;
            button_teardown.Enabled = true;
            displayTeardown = true;
            pictureBox5.Show();

            // Call play function in controller
            controller.PlayClicked();
        }


        // Semi-transparent pause button has been clicked
        private void ST_Pause_Clicked(object sender, EventArgs e)
        {
            // Enable play button
            button_play.Enabled = true;
            pictureBox3.Show();
            displayPlay = true; 

            // Disable pause button
            button_pause.Enabled = false;
            pictureBox4.Hide();
            displayPause = false; 

            // Call pause method in the controller
            controller.PauseClicked();
        }

        
        // Semi-transparent teardown button has been clicked
        private void ST_Teardown_Clicked(object sender, EventArgs e)
        {
            // Disable all buttons except setup
            button_setup.Enabled = true;
            displaySetup = true; 
            pictureBox2.Show();
            button_play.Enabled = false;
            displayPlay = false;
            pictureBox3.Hide();
            button_pause.Enabled = false;
            displayPause = false; 
            pictureBox4.Hide();
            button_teardown.Enabled = false;
            displayTeardown = false; 
            pictureBox5.Hide();

            // Call teardown method in the controller
            controller.TeardownClicked();
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

                        // After successful validation, signal the controller
                        controller.Connect_Button_Click(sender, e);
                    }
                    catch (ArgumentNullException)
                    {
                        MessageBox.Show("Please enter a server IP address.");
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


        // Display the video streaming box (panel) and enable/disable the associated controls
        public void DisplayStreamingBox()
        {
            // Display the streaming panel
            panel1.Show();
            panel2.Show();

            // Only display the setup button and disable the others
            button_play.Enabled = false;
            displayPlay = false;
            pictureBox3.Hide();
            button_pause.Enabled = false;
            displayPause = false;
            pictureBox4.Hide();
            button_teardown.Enabled = false;
            displayTeardown = false;
            pictureBox5.Hide();
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

            // Close the application
            Application.Exit();
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


        // Displays a frame in the picture box
        public void DisplayFrame(Image _img)
        {
            pictureBox1.Image = _img;
        }


        // Let the controller know that the form is closing
        private void mainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close any open connections before the application terminates
            controller.CloseConnections();
        }


        // Delegate to reset the display
        delegate void ResetDisplayCallback();


        // Create the deleage to call the SetupReset function 
        public void SetupReset()
        {
            ResetDisplayCallback d = new ResetDisplayCallback(SetupResetLocal);
            this.Invoke(d);
        }


        // Reset the form to the state where it is ready to set up a RTP connection with the server
        private void SetupResetLocal()
        {
            try
            {
                // Disable all buttons except setup
                button_setup.Enabled = true;
                displaySetup = true;
                button_play.Enabled = false;
                displayPlay = false;
                pictureBox3.Hide();
                button_pause.Enabled = false;
                displayPause = false;
                pictureBox4.Hide();
                button_teardown.Enabled = false;
                displayTeardown = false;
                pictureBox5.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        // Reset the view to how it is when it initially loads
        public void Reset()
        {
            // Disable all buttons RTSP buttons
            button_setup.Enabled = true;
            displaySetup = true;
            pictureBox2.Hide();
            button_play.Enabled = false;
            displayPlay = false;
            pictureBox3.Hide();
            button_pause.Enabled = false;
            displayPause = false;
            pictureBox4.Hide();
            button_teardown.Enabled = false;
            displayTeardown = false;
            pictureBox5.Hide();

            // Hide the video streaming box
            panel1.Hide();
            panel2.Hide();

            // Enable the user input text boxes
            textBox_port.Enabled = true; 
            textBox_server_ip.Enabled = true;

            // Enable the connect button
            button_connect.Enabled = true; 
        }


        // Returns whether the "Packet Report" check box is checked
        public bool IsPacketReportChecked()
        {
            return checkBox_packet_report.Checked;
        }


        // Returns whether the "Print Header" check box is checked
        public bool IsPrintHeaderChecked()
        {
            return checkBox_print_header.Checked;
        }


        // Delegate to reset the display
        delegate void DisplayReportCallback(string _report);


        // Create the deleage to call the SetupReset function 
        public void UpdateInfoTextBoxDelegate(string _rtp)
        {
            string r = _rtp;
            DisplayReportCallback d = new DisplayReportCallback(UpdateInfoTextBox);
            this.Invoke(d, new object[] { r });
        }
    }
}
