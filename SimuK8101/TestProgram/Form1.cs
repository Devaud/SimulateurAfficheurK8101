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

namespace TestProgram
{
    public partial class Form1 : Form
    {
        SimuK8101 display;

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
            try
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
            }
        }
    }
}
