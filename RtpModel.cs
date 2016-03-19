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
    class RtpModel
    {
        private Socket udpSoc;
        private IPAddress serverIp;
        private IPAddress clientIp;
        private IPEndPoint serverEndPoint;
        private IPEndPoint clientEndPoint;

        private const int serverPort = 1818;
        private const int clientPort = 1800;

        public RtpModel()
        {
            clientIp = IPAddress.Parse("127.0.0.1");
        }

        // Creates a local UDP socket, and returns the UDP server port number
        public int CreateUDPSocket(IPAddress _ip)
        {
            try
            {
                serverIp = _ip;

                // Create the local (client end point)
                clientEndPoint = new IPEndPoint(clientIp, clientPort);

                // Create the server end point
                serverEndPoint = new IPEndPoint(serverIp, serverPort);

                // Create a UDP socket
                udpSoc = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Bind the socket to a local port
                udpSoc.Bind(clientEndPoint);
            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occured setting up the UDP socket.\r\n" + e.Message);
            }

            // Return the port number that corresponds to the UDP socket that the server will listen on
            return serverPort; 
        }

        // Receives a frame from the video server
        public byte[] ReceiveFrame()
        {
            // Create an array of bytes to store the data
            byte[] receiveBuffer = new byte[1024];

            // Store the IPEndpoint as an EndPoint (abstract class) to be used in the ReceiveFrom method below
            EndPoint svrEP = serverEndPoint;

            try
            {
                // Receive the data
                udpSoc.ReceiveFrom(receiveBuffer, ref svrEP);
            }
            catch (Exception e)
            {
                MessageBox.Show("There was an error receiving data from the server via UDP socket.\r\n" + e.Message);
            }

            return receiveBuffer;
        }

        // Closes the UDP socket
        public void CloseUDPSocket()
        {
            udpSoc.Close();
        }
    }
}
