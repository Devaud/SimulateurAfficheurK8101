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
    public partial class FrmView : Form
    {
        SimulatorK8101 sk;

        public FrmView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Point location = new Point(DynamiqueLocation(this.Size.Width, 5), DynamiqueLocation(this.Size.Height, 45));
            Size size = new Size(DynamiqueLocation(this.Size.Width, 85), DynamiqueLocation(this.Size.Height, 45));
            sk = new SimulatorK8101(location, size);
            Refresh();
        }

        private int DynamiqueLocation(int start, int perCentUsed)
        {
            return (start * perCentUsed) / 100;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            sk.Draw(e);
        }

    }
}
