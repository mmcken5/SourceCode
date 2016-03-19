using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

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

        private int sessionID;
        private int cseq;
        private string videoName;

        // Connect to the server, given the port number and IP address entered by the user
        public void Connect_Button_Click(object sender, EventArgs e)
        {
            // Get a reference to the mainView class (i.e. the view)
            view = (mainView)((Button)sender).FindForm();

            // Disable the "Listen" button and the associated textfield
            view.Disable_InputTextBoxes();

            // Get the port number
            serverTcpPort = view.GetPort();

            // Get the server IP address
            serverIP = view.GetServerIP();

            // Create a new rtsp model to handle the rtsp communication with the server
            rtspModel = new RtspModel();

            // Signal the rtsp model to setup a TCP connection
            rtspModel.Connect(serverTcpPort, serverIP);
        }

        //
        public void SetupClicked(string _videoName)
        {
            // Initialize the rtsp sequence number
            cseq = 1; 

            // Initialize the video file name
            videoName = _videoName;

            // Create an rtp model
            rtpModel = new RtpModel();

            // Signal the rtp model to create a local udp socket and get the server udp port number
            int serverUdpPort = rtpModel.CreateUDPSocket(serverIP);

            // Send a setup request to the server
            rtspModel.Setup(serverIP.ToString(), serverTcpPort, serverUdpPort, videoName, cseq);

            // Receive the reply message from the server
            string message = rtspModel.ReceiveReply();

            // Extract the session number from the reply message
            sessionID = ExtractSessionID(message);

            // Update the view to display the server response
            view.UpdateServerResponsesTextBox(message);

            // Update the view to display the name of the video file
            view.UpdateInfoTextBox(videoName);
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
                MessageBox.Show("There was an error parsing the RSTP reply message from the server.\r\n" + e.Message);
            }

            return id; 
        }

        // Close the socket connections
        public void CloseConnections()
        {
            // TODO: Close the socket connections
        }
    }
}
