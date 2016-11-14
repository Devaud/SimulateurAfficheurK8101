using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorDisplayerK8101
{
    public partial class Form1 : Form
    {
        TcpListener tcpListener;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            this.tcpListener = new TcpListener(ip, 500);
            this.tcpListener.Start();

            Socket s = this.tcpListener.AcceptSocket();

            listBox1.Items.Add(s.RemoteEndPoint);
        }
    }
}
