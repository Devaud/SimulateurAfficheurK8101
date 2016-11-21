using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velleman.Kits;
using SimuVelleman.Kits;
using System.Net.Sockets;
using System.Net;

namespace TestProgram
{
    public partial class Form1 : Form
    {
        SimuK8101 display;
        Socket ClientSocket;

        public SimuK8101 Display
        {
            get { return display; }
            set { display = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Display = new SimuK8101();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* try
             {
                 Display.Connect();
                 if (display.Connected())
                 {
                     MessageBox.Show("Connected");
                 }
             } 
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }*/
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
            }
        }

        private void SendMessage(string message)
        {
            byte[] msg = Encoding.UTF8.GetBytes(message);
            int DtSent = ClientSocket.Send(msg, msg.Length, SocketFlags.None);
            if (DtSent == 0)
            {
                MessageBox.Show("Aucune donnée n'a été envoyée");
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            /*this.Display.DrawText(tbxMessage.Text, SimuK8101.TextSize.Small, 0, 0, 10);*/
            this.SendMessage(tbxMessage.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display.DrawText("salut", SimuK8101.TextSize.Small, 10, 10, 10);

        }
    }
}
