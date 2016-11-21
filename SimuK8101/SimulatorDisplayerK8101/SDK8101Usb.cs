/*
 * Projet      : SimulatorDisplayerK8101
 * Description : Simulate fonctionnalities of the Velleman K8101 display.
 * Author      : Devaud Alan & Dylan Wacker
 * Date        : 21.11.2016
 * Version     : 1.0
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulatorDisplayerK8101
{
    public class SDK8101Usb
    {
        #region Constantes
        private const string DEFAULT_IP = "127.0.0.1";
        private const int DEFAULT_PORT = 500;
        private const int MAX_CONNEXION_WAITING = 1;
        #endregion

        #region Fields
        private Socket _clientConnected;
        private Socket _server;
        private Thread _receiveMessage;
        #endregion

        #region Properties
        /// <summary>
        /// Get if the client is connected
        /// </summary>
        public bool IsConnected
        {
            get { return (this.ClientConnected != null) ? this.ClientConnected.Connected : false; }
        }

        /// <summary>
        /// Get or set the receiveMessage thread
        /// </summary>
        public Thread ReceiveMessage
        {
            get { return _receiveMessage; }
            set { _receiveMessage = value; }
        }

        /// <summary>
        /// Get or set the server socket
        /// </summary>
        public Socket Server
        {
            get { return _server; }
            set { _server = value; }
        }

        /// <summary>
        /// Get or set the connected client
        /// </summary>
        public Socket ClientConnected
        {
            get { return _clientConnected; }
            set { _clientConnected = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create new SDK8101Usb
        /// </summary>
        public SDK8101Usb()
        {
            this.Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.ClientConnected = null;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create new connexion
        /// </summary>
        public void Connect()
        {
            //Console.WriteLine("Waiting connexion ...");
            try
            {
                // Add a bind and listen utile connection done
                this.Server.Bind(new IPEndPoint(IPAddress.Parse(DEFAULT_IP), DEFAULT_PORT));
                this.Server.Listen(MAX_CONNEXION_WAITING);

                this.ClientConnected = this.Server.Accept(); // Accept the clientSocket

                if (this.ClientConnected.Connected)
                {
                    //Console.WriteLine("Connected");
                    // Create receive message thread
                    this.ReceiveMessage = new Thread(new ThreadStart(this.ReceivedMessage));
                    this.ReceiveMessage.Start();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Disconnect the connexion
        /// </summary>
        public void Disconnect()
        {
            this.ReceiveMessage = null;

            this.ClientConnected.Close();
            this.Server.Close();
        }

        /// <summary>
        /// Receive message from socket
        /// </summary>
        public void ReceivedMessage()
        {
            while (this.ClientConnected.Connected)
            {
                //Console.WriteLine("Thread read");
                if (this.ClientConnected.Available > 0)
                {
                    byte[] msg = new byte[this.ClientConnected.Available]; // Prepare the msg buffer
                    this.ClientConnected.Receive(msg, msg.Length, SocketFlags.None); // Read the received buffer
                    string msgString = Encoding.UTF8.GetString(msg); // Convert the buffer
                    Console.WriteLine(msgString); // Write the message
                }
                Thread.Sleep(500);
            }

        }
        #endregion
    }
}
