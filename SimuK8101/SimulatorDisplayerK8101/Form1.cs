using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        SimuDisplayK8101 sdk8101;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*IPAddress ip = IPAddress.Parse("127.0.0.1");
            this.tcpListener = new TcpListener(ip, 500);
            this.tcpListener.Start();

            Socket s = this.tcpListener.AcceptSocket();

            listBox1.Items.Add(s.RemoteEndPoint);*/
            sdk8101 = new SimuDisplayK8101(new Point(100, 100), new Size(293, 229));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            sdk8101.Draw(e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            sdk8101.Clicked(e.Location);
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
