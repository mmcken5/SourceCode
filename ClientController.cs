using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Timers;
using System.Drawing;

namespace assignment2_mmcken5
{
    class ClientController
    {
        private mainView view;
        private RtspModel rtspModel;
        private RtpModel rtpModel;

        private int serverUdpPort;
        private int serverTcpPort;
        private IPAddress serverIP;

        private string videoName;

        private System.Timers.Timer timer;

        private bool paused = true; 


        // Connect to the server, given the port number and IP address entered by the user
        public void Connect_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // Get a reference to the mainView class (i.e. the view)
                view = (mainView)((Button)sender).FindForm();

                // Get the port number
                serverTcpPort = view.GetPort();

                // Get the server IP address
                serverIP = view.GetServerIP();

                // Create a new rtsp model to handle the rtsp communication with the server
                rtspModel = new RtspModel();

                // Signal the rtsp model to setup a TCP connection
                rtspModel.Connect(serverTcpPort, serverIP);

                // Disable the "Listen" button and the associated textfield
                view.Disable_InputTextBoxes();

                // Update the view to display the video streaming box and the associated controls
                view.DisplayStreamingBox();
            }
            catch (Exception exc)
            {
                view.Reset();
                MessageBox.Show("An error occured while attempting to connect to the server. Please make sure that the server application is running.");
            }
        }


        // Set up the TCP connection with the server and open a UDP socket
        public void SetupClicked(string _videoName)
        {
            // Initialize the rtsp sequence number
            rtspModel.ResetSequenceNumber();
            rtspModel.UpdateSequenceNumber();

            // Initialize the video file name
            videoName = _videoName;

            // Create an rtp model
            rtpModel = new RtpModel();

            // Signal the rtp model to create a local udp socket and get the server udp port number
            serverUdpPort = rtpModel.CreateUDPSocket(serverIP);

            try
            {
                // Send a setup request to the server
                rtspModel.Setup(serverIP.ToString(), serverTcpPort, serverUdpPort, videoName);

                // Receive the reply message from the server
                string message = rtspModel.ReceiveReply();

                // Extract the session number from the reply message
                int sessionID = ExtractSessionID(message);

                // Set the session ID number in the rtsp model
                rtspModel.SetSessionID(sessionID);

                // Update the view to display the correct buttons
                view.DisplayPlay();

                // Update the view to display the server response
                view.UpdateServerResponsesTextBox(message);

                // Update the view to display the name of the video file
                view.UpdateInfoTextBox(videoName);

                // Initialize the timer
                timer = new System.Timers.Timer();
                timer.AutoReset = false;
                timer.Interval = 50;
                timer.Elapsed += timer_Elapsed;
            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occured. The server has likely been terminated, and the connection has been closed.");

                // The server no longer exists
                // Reset the view
                view.Reset();

                // Close the RTSP connection
                rtspModel.CloseTcpSocket();
            }
        }


        // On a timer timer event, get one frame from the server
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Pause the timer
                timer.Stop();

                if (!paused)
                {
                    // Get the frame from the rtp model
                    Image frame = rtpModel.ReceiveFrame();

                    // Update the view to display the frame
                    view.DisplayFrame(frame);

                    // If the user has checked "Packet Report", display the packet report
                    if (view.IsPacketReportChecked())
                    {
                        // Get the RTP packet report
                        string report = rtpModel.GetRtpPacketReport();

                        // Update the view to display the report
                        view.UpdateInfoTextBoxDelegate(report);
                    }

                    // If the user has checked "Print Header", display the packet header
                    if (view.IsPrintHeaderChecked())
                    {
                        // Get the RTP packet header
                        byte[] header = rtpModel.GetRtpHeaderBytes();

                        string sHeader = ""; 

                        // Convert the bytes to bits
                        foreach (byte b in header)
                        {
                            sHeader += (Convert.ToString(b, 2).PadLeft(8, '0') + " ");
                        }

                        // Update the view to display the header
                        view.UpdateInfoTextBoxDelegate(sHeader);
                    }

                    // Resume the timer
                    timer.Start();
                }
            }
            catch (Exception ex)
            {
                // Catch the socket exception if socket receive times out (indicating the server has terminated or the video file finished streaming)
                if (!paused)
                {
                    // Update the view
                    view.SetupReset();

                    // Close the RTP socket
                    rtpModel.CloseUDPSocket();

                    // Free the timer resources
                    timer.Enabled = false;
                    timer.Elapsed -= timer_Elapsed;
                    timer.Dispose();

                    // Reset the rtsp sequence number
                    rtspModel.ResetSequenceNumber();
                }
            }
        }


        // Returns true if the stream has been paused
        public bool IsPaused()
        {
            return paused;
        }


        // Extract the session ID number from the rtsp reply message from the server
        private int ExtractSessionID(string _message)
        {
            int id = 0;

            // Split the message up and extract the session ID created by the server
            try
            {
                // Split the string by spaces and get the session ID as a string
                string s = _message.Split(' ')[4];

                // Convert the session ID from a string to an int
                id = Int32.Parse(s);
            }
            catch (Exception e)
            {
                //MessageBox.Show("There was an error parsing the RSTP reply message from the server.\r\n" + e.Message);
            }

            return id; 
        }


        // Start playing the video stream from the video server
        public void PlayClicked()
        {
            paused = false; 

            // Start the timer
            timer.Start();

            // Update the rtsp sequence number
            rtspModel.UpdateSequenceNumber();

            // Signal the rtsp model to send a play message
            rtspModel.Play();

            // Receive the reply message from the server
            string message = rtspModel.ReceiveReply();

            // Update the view to display the server response
            view.UpdateServerResponsesTextBox(message);
        }


        // Stop playing the video stream from the video server
        public void PauseClicked()
        {
            paused = true; 

            // Stop the timer
            timer.Stop();

            // Update the rtsp sequence number
            rtspModel.UpdateSequenceNumber();

            // Signal the rtsp model to send a pause request
            rtspModel.Pause();

            // Receive the reply message from the server
            string message = rtspModel.ReceiveReply();

            // Update the view to display the server response
            view.UpdateServerResponsesTextBox(message);
        }


        // Stop streaming and close the UDP connection with the server
        public void TeardownClicked()
        {
            // Stop the timer
            timer.Stop();

            // Free the timer resources
            timer.Elapsed -= timer_Elapsed;
            timer.Enabled = false;
            timer.Dispose();

            // Update the rtsp sequence number
            rtspModel.UpdateSequenceNumber();

            // Signal the rtsp model to send a teardown request
            rtspModel.Teardown();

            // Receive the reply message from the server
            string message = rtspModel.ReceiveReply();

            // Update the view to display the server response
            view.UpdateServerResponsesTextBox(message);

            // Reset the rtsp sequence number
            rtspModel.ResetSequenceNumber();

            // Close the UDP connection
            rtpModel.CloseUDPSocket();
        }


        // Close the socket connections
        public void CloseConnections()
        {
            try
            {
                // CLose the UDP connection if it is still open
                rtpModel.CloseUDPSocket();

                // Close the TCP connection
                rtspModel.CloseTcpSocket();
            }
            catch (Exception e)
            {
                //MessageBox.Show("An error has occured while attempting to close the RTP and/or the RTSP sockets.");
            }
        }
    }
}
