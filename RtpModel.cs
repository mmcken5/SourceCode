using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace assignment2_mmcken5
{
    public class RtpModel
    {
        private Socket udpSoc;
        private IPAddress serverIp;
        private IPAddress clientIp;
        private IPEndPoint serverEndPoint;
        private IPEndPoint clientEndPoint;

        private int serverPort = 1818;
        private List<int> usedPorts;
        private bool loop; 

        private byte[] rtpHeader;
        private string headerSeqNo;
        private string headerTimeStamp;
        private string headerPayloadType;

        private RtpPacket packet; 

        public RtpModel()
        {
            // Set the local IP address
            clientIp = IPAddress.Parse("127.0.0.1");

            // Initialize the list
            usedPorts = new List<int>(); 
        }

        // Creates a local UDP socket, and returns the UDP server port number
        public int CreateUDPSocket(IPAddress _ip)
        {
            do
            {
                loop = false; 

                try
                {
                    serverIp = _ip;

                    // Create the local (client end point)
                    clientEndPoint = new IPEndPoint(clientIp, serverPort);

                    // Create the server end point
                    serverEndPoint = new IPEndPoint(serverIp, serverPort);

                    // Create a UDP socket
                    udpSoc = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                    // Bind the socket to a local port
                    udpSoc.Bind(clientEndPoint);
                }
                catch (Exception e)
                {

                    //MessageBox.Show("An error has occured while setting up the UDP socket.\r\n" + e.Message);

                    int usedServerPort = serverPort;
                    
                    // Add this used port to the 
                    usedPorts.Add(usedServerPort);

                    // Alert the user that the port has already been used and ask if they would like to use a new one
                    UsedPortDialog upd = new UsedPortDialog(this, usedPorts);

                    // Display already used ports and ask user to input a new one or exit the application
                    DialogResult d =  upd.ShowDialog();
                    bool cont = upd.GetDialogResult();

                    // Determine if the user wants to continue or not
                    if (cont)
                    {
                        loop = true; 
                    }

                    else
                    {
                        Application.Exit();
                    }

                    upd.Dispose();
                }
            }
            while (loop);

            // Return the port number that corresponds to the UDP socket that the server will listen on
            return serverPort; 
        }

        // Set the new udp port to bind to
        public void SetNewUdpPort(int _p)
        {
            serverPort = _p;
        }

        // Receives a frame from the video server
        public Image ReceiveFrame()
        {
            // Create an array of bytes to store the data
            byte[] receiveBuffer = new byte[100000];

            // Store the IPEndpoint as an EndPoint (abstract class) to be used in the ReceiveFrom method below
            EndPoint svrEP = serverEndPoint;

            // Initialize a variable to store the amount of bytes received from the server
            int bytesReceived = 0;

            try
            {
                //Set the timeout
                udpSoc.ReceiveTimeout = 1000;

                // Receive the data and store the number of bytes received by the buffer
                bytesReceived = udpSoc.ReceiveFrom(receiveBuffer, ref svrEP);
            }
            catch (Exception e)
            {
                // Throw an exception to the function that called the ReceiveFrame function
                Console.WriteLine("Socket receive has timed out.");
                throw;
            }
            
            // Create a new rtp packet object
            packet = new RtpPacket(receiveBuffer, bytesReceived);

            // Store header as byte stream
            rtpHeader = packet.GetPacketHeader();

            // Extract packet header fields (sequence number, time stamp, and payload type)
            headerSeqNo = packet.GetPacketSequenceNumber().ToString();
            headerTimeStamp = packet.GetPacketTimeStamp().ToString();
            headerPayloadType = packet.GetPacketPayloadType().ToString();

            // Extract payload
            byte[] payload = packet.GetPacketPayload();

            // Convert to frame to an Image
            MemoryStream ms = new MemoryStream(payload);
            Image image = Image.FromStream(ms);

            return image;
        }

        // Returns the rtp header as an array of bytes
        public byte[] GetRtpHeaderBytes()
        {
            return rtpHeader;
        }

        // Returns a string containing a report about the packet
        public string GetRtpPacketReport()
        {
            string s = "Received RTP packet with sequence number = " + headerSeqNo + ", time stamp = " + headerTimeStamp + "ms, and payload type = " + headerPayloadType;
            return s; 
        }

        // Returns the sequence number of the rtp packet
        public string GetRtpHeaderSequenceNumber()
        {
            return headerSeqNo;
        }

        // Returns the time stamp of the rtp packet
        public string GetRtpHeaderTimeStamp()
        {
            return headerTimeStamp;
        }

        // Returns the payload type of the rtp packet
        public string GetRtpHeaderPayloadType()
        {
            return headerPayloadType;
        }

        // Close the UDP socket
        public void CloseUDPSocket()
        {
            try
            {
                udpSoc.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show("An error occured while attempting to close the UDP connection.\r\n" + e.Message);
            }
        }
    }
}
