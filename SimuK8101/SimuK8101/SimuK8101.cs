using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace SimuVelleman.Kits
{
    public class SimuK8101
    {
        #region Fields
        private const string IP_SERVE = "127.0.0.1";
        private const int PORT_SERVE = 500;

        private TcpClient _tcpClient;
        //// Get a client stream for reading and writing.
        private NetworkStream _stream;
        private StreamWriter _sw;

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

        public NetworkStream Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        public StreamWriter Sw
        {
            get { return _sw; }
            set { _sw = value; }
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
                this.Stream = TcpClient.GetStream();
                Sw = new StreamWriter(this.Stream);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">The string you want write</param>
        /// <param name="size">Size of the text</param>
        /// <param name="x1">position x</param>
        /// <param name="y1">position y</param>
        /// <param name="x2">position x2</param>
        public void DrawText(string str, TextSize size, byte x1, byte y1, byte x2)
        {
            Sw.Write("Hello");
            //string response = new StreamReader(this.Stream).ReadToEnd();
            Sw.Close();
        }



        #endregion
        public enum TextSize
        {
            Small,
            Large,
        }
    }
}
