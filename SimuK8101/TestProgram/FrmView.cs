/*
 * Projet      : TestProgramm
 * Description : Test programm which use SimuVelleman.Kits and connect with the SimulatorDisplayerK8101
 * Author      : Devaud Alan & Dylan Wacker
 * Date        : 21.11.2016
 * Version     : 1.0
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimuVelleman.Kits;
using System.Net.Sockets;
using System.Net;

namespace TestProgram
{
    public partial class FrmView : Form
    {
        #region Fields
        SimuK8101 display;
       // Socket ClientSocket;
        #endregion

        #region Properties
        public SimuK8101 Display
        {
            get { return display; }
            set { display = value; }
        }
        #endregion

        #region Constructor
        public FrmView()
        {
            InitializeComponent();
            Display = new SimuK8101();
        }
        #endregion

        /// <summary>
        /// Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            /*ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                ClientSocket.Connect(IPAddress.Parse("127.0.0.1"), 500);
                if (ClientSocket.Connected)
                {
                    this.SendMessage("Client connected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            this.Display = new SimuK8101();
        }

        /// <summary>
        /// Send message throw socket
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            /*byte[] msg = Encoding.UTF8.GetBytes(message);
            int DtSent = ClientSocket.Send(msg, msg.Length, SocketFlags.None);
            if (DtSent == 0)
            {
                MessageBox.Show("Aucune donnée n'a été envoyée");
            }*/
        }

        /// <summary>
        /// Send message event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            //this.SendMessage(tbxMessage.Text);
        }

        /// <summary>
        /// Draw text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Display.DrawText("salut", SimuK8101.TextSize.Small, 10, 10, 10);

        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            this.Display.Connect();
        }
    }
}
