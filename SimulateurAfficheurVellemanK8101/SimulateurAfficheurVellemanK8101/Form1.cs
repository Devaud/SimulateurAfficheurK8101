using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateurAfficheurVellemanK8101
{
    public partial class Form1 : Form
    {
        SimulatorButton sb;
        SimulatorLCD lcd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sb = new SimulatorButton(new Point(10, 10), new Size(32, 32));
            lcd = new SimulatorLCD(new Point(20, 10));
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            sb.Draw(e);
            lcd.Draw(e);
        }
    }
}
