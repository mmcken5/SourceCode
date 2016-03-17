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
        Socket tcpSoc;

        public RtspModel(int _port, IPAddress _serverIP)
        {
            try
            {
            // Create a TCP socket 
            tcpSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Create an IP endpoint
            IPEndPoint serverEndPoint = new IPEndPoint(_serverIP, _port);

            // Connect to the server
            tcpSoc.Connect(serverEndPoint);

            Console.WriteLine("Socket connected to " + tcpSoc.RemoteEndPoint.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Error establishing the TCP socket connection.\n\r" + e.Message);
            }
        }
    }
}
