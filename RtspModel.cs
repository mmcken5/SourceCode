using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace assignment2_mmcken5
{
    class RtspModel
    {
        private Socket tcpSoc;
        private IPEndPoint serverEndPoint;

        private int sessionID;
        private int cseq;

        private string serverIP;
        private int serverPort;
        private string videoName;

        public RtspModel()
        {
            try
            {
                // Create a TCP socket 
                tcpSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error creating a TCP socket.\n\r" + e.Message);
            }
        }

        public void Connect(int _port, IPAddress _serverIP)
        {
            try
            {
                // Create an IP endpoint
                serverEndPoint = new IPEndPoint(_serverIP, _port);

                // Connect to the server
                tcpSoc.Connect(serverEndPoint);
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error establishing the TCP socket connection.\n\r" + e.Message);
                throw;
            }
        }

        // Initialize the sequence number
        public void ResetSequenceNumber()
        {
            cseq = 0; 
        }

        // Increase the sequence number by one
        public void UpdateSequenceNumber()
        {
            cseq++;
        }

        // Set the session ID number
        public void SetSessionID(int _id)
        {
            sessionID = _id; 
        }

        // Send the RTSP SETUP message to the server with the necessary information enclosed
        public void Setup(string _serverIP, int _serverPort, int _port, string _videoName)
        {
            serverIP = _serverIP;
            serverPort = _serverPort;
            videoName = _videoName;

            // Construct the rtsp setup message
            string message = "SETUP rtsp://" + _serverIP + ":" + _serverPort + "/" + _videoName + " RTSP/1.0\r\nCSeq: " + cseq + "\r\nTransport: RTP/UDP; client_port= " + _port;

            // Convert the message to a byte array
            byte[] bMsg = Encoding.UTF8.GetBytes(message);

            try
            {
                // Send the rstp SETUP message to the server
                tcpSoc.Send(bMsg);
            }
            catch (Exception e)
            {
                // The server has terminated
                // Close the RTSP connection
                tcpSoc.Close();

                //MessageBox.Show("An error occured while attempting to send the RTSP SETUP message to the server.\r\n" + e.Message);

                throw;
            }
        }

        // Send the RTSP PLAY message to the server
        public void Play()
        {
            // Construct the rtsp setup message
            string message = "PLAY rtsp://" + serverIP + ":" + serverPort + "/" + videoName + " RTSP/1.0\r\nCSeq: " + cseq + "\r\nSession: " + sessionID;

            // Convert the message to a byte array
            byte[] bMsg = Encoding.UTF8.GetBytes(message);

            try
            {
                // Send the rstp SETUP message to the server
                tcpSoc.Send(bMsg);
            }
            catch (Exception e)
            {
                //MessageBox.Show("An error occured while attempting to send the RTSP PLAY message to the server.\r\n" + e.Message);
            }
        }

        // Send the RTSP PAUSE message to the server
        public void Pause()
        {
            // Construct the rtsp setup message
            string message = "PAUSE rtsp://" + serverIP + ":" + serverPort + "/" + videoName + " RTSP/1.0\r\nCSeq: " + cseq + "\r\nSession: " + sessionID;

            // Convert the message to a byte array
            byte[] bMsg = Encoding.UTF8.GetBytes(message);

            try
            {
                // Send the rstp SETUP message to the server
                tcpSoc.Send(bMsg);
            }
            catch (Exception e)
            {
                //MessageBox.Show("An error occured while attempting to send the RTSP PAUSE message to the server.\r\n" + e.Message);
            }
        }

        // Send the RTSP TEARDOWN message to the server
        public void Teardown()
        {
            // Construct the rtsp setup message
            string message = "TEARDOWN rtsp://" + serverIP + ":" + serverPort + "/" + videoName + " RTSP/1.0\r\nCSeq: " + cseq + "\r\nSession: " + sessionID;

            // Convert the message to a byte array
            byte[] bMsg = Encoding.UTF8.GetBytes(message);

            try
            {
                // Send the rstp SETUP message to the server
                tcpSoc.Send(bMsg);
            }
            catch (Exception e)
            {
                //MessageBox.Show("An error occured while attempting to send the RTSP PAUSE message to the server.\r\n" + e.Message);
            }
        }

        // Receive the reply message from the server
        public string ReceiveReply()
        {
            string reply;

            // Create a buffer to receive the data
            byte[] dataBuffer = new byte[1024];

            try
            {
                // Receive the rtsp reply message from the server
                tcpSoc.Receive(dataBuffer);
            }
            catch (Exception e)
            {
                //MessageBox.Show("An error occured while attempting to receive the RTSP reply message from the server.\r\n" + e.Message);
            }

            // Convert the reply message from a byte array to a string
            reply = Encoding.UTF8.GetString(dataBuffer);

            return reply;
        }

        // Close the tcp socket
        public void CloseTcpSocket()
        {
            try
            {
                tcpSoc.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show("An error occured while attempting to close the TCP connection.\r\n" + e.Message);
            }
        }
    }
}
