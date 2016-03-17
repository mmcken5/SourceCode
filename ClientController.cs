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

        private int port;
        private IPAddress serverIP;

        // Connect to the server, given the port number and IP address entered by the user
        public void Connect_Button_Click(object sender, EventArgs e)
        {
            // Get a reference to the mainView class (i.e. the view)
            view = (mainView)((Button)sender).FindForm();

            // Disable the "Listen" button and the associated textfield
            view.Disable_InputTextBoxes();

            // Get the port number
            port = view.GetPort();

            // Get the server IP address
            serverIP = view.GetServerIP();

            // Signal the RtspModel to setup a TCP connection
            rtspModel = new RtspModel(port, serverIP);
        }
    }
}
