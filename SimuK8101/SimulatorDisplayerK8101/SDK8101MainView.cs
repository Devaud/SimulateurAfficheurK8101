/*
 * Projet      : SimulatorDisplayerK8101
 * Description : Simulate fonctionnalities of the Velleman K8101 display.
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
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorDisplayerK8101
{
    public partial class SDK8101MainView : Form
    {
        #region Fields
        private const string STATE_CONNECTED = "Connected";
        private const string STATE_DISCONNECTED = "Disconnected";
        private const string STATE_WAITING = "Waiting connection...";

        private SDK8101Controller _sdk8101Ctrl;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the SDK8101Controller
        /// </summary>
        public SDK8101Controller Sdk8101Ctrl
        {
            get { return _sdk8101Ctrl; }
            set { _sdk8101Ctrl = value; }
        }
        #endregion

        public SDK8101MainView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Sdk8101Ctrl = new SDK8101Controller(this);
        }

        /// <summary>
        /// Paint event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.Sdk8101Ctrl.Draw(e);
        }

        /// <summary>
        /// Mouse click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Sdk8101Ctrl.Clicked(e.Location);
        }

        /// <summary>
        /// Quit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            if (this.Sdk8101Ctrl.IsConnected())
            {
                this.tsmiDisconnect_Click(sender, e);
            }
            Application.Exit();
        }

        /// <summary>
        /// Connect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiConnect_Click(object sender, EventArgs e)
        {
            this.tsslConnectInformation.Text = STATE_WAITING;
            this.Sdk8101Ctrl.Connect();
            this.CheckConnexionState();
        }

        /// <summary>
        /// Check the connection state and update the view
        /// </summary>
        private void CheckConnexionState()
        {
            this.tsmiConnect.Enabled = !this.Sdk8101Ctrl.IsConnected();
            this.tsmiDisconnect.Enabled = this.Sdk8101Ctrl.IsConnected();
            this.tsslConnectInformation.Text = (this.Sdk8101Ctrl.IsConnected()) ? STATE_CONNECTED : STATE_DISCONNECTED;
        }

        /// <summary>
        /// Disconnect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDisconnect_Click(object sender, EventArgs e)
        {
            this.Sdk8101Ctrl.Disconnect();
            this.CheckConnexionState();
        }
    }
}
