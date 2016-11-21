/* Project : SimulatorK8101
*  Author : DEVAUD - WACKER
*  Date : 11.2016
*  Class : SimuK8101
*  Description :  Simulation of the connexion USB of the K8101
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorDisplayerK8101
{
    class SimuDisplayUsbK8101
    {
        #region Constantes
        private const string DEFAULT_IP = "127.0.0.1";
        private const int DEFAULT_PORT = 500;
        #endregion

        #region Fields
        private TcpListener _tcpListener;
        private IPAddress _ip;
        #endregion

        #region Properties
        public IPAddress Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public TcpListener TcpListener
        {
            get { return _tcpListener; }
            set { _tcpListener = value; }
        }
        #endregion

        #region Constructor
        public SimuDisplayUsbK8101()
        {
            this.Ip = IPAddress.Parse(DEFAULT_IP);
            this.TcpListener = new TcpListener(this.Ip, DEFAULT_PORT);
        }
        #endregion

        #region Methods
        public void Connect()
        {
            this.TcpListener.Start();
        }
        #endregion
    }
}
