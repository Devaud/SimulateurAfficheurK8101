using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace SimuVelleman.Kits
{
    public enum TextSize
    {
        Small,
        Large,
    }

    public class SimuK8101
    {
        #region Fields
        private const string IP_SERVE = "127.0.0.1";
        private const int PORT_SERVE = 500;

        private TcpClient _tcpClient;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the TcpClient
        /// </summary>
        private TcpClient TcpClient
        {
            get { return _tcpClient; }
            set { _tcpClient = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new SimuK8101
        /// </summary>
        public SimuK8101()
        {
            this.TcpClient = new TcpClient();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Connect the SimuK8101
        /// </summary>
        public void Connect()
        {
            try
            {
                this.TcpClient.Connect(IP_SERVE, PORT_SERVE);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Indicate if the TCP connection is made between the display and the client
        /// </summary>
        /// <returns>True if connected</returns>
        public bool Connected()
        {
            return this.TcpClient.Connected;
        }

        /// <summary>
        /// Disconnect the SimuK8101
        /// </summary>
        public void Disconnect()
        {
            try
            {
                this.TcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion
    }
}
