/* *
 * Project     : SimulatorK8101
 * Description : Simulate the Velleman K8101
 * Author      : Alan Devaud & Dylan Wacker
 * Date        : 3.10.2016
 * Version     : 1.0
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorK8101
{
    public partial class FrmView : Form
    {
        #region Fields
        private SimulatorK8101 _sk;
        private Timer _updater;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the updater timer
        /// </summary>
        public Timer Updater
        {
            get { return _updater; }
            set { _updater = value; }
        }

        /// <summary>
        /// Get or set the simulatorK8101
        /// </summary>
        public  SimulatorK8101 Sk
        {
            get { return _sk; }
            set { _sk = value; }
        }
        #endregion

        #region Constructor
        public FrmView()
        {
            InitializeComponent();
        }
        #endregion

        #region Personal Methods
        private void InitApplication()
        {
            Point location = new Point(DynamiqueLocation(this.Size.Width, 5), DynamiqueLocation(this.Size.Height, 20));
            Size size = new Size(DynamiqueLocation(this.Size.Width, 85), DynamiqueLocation(this.Size.Height, 65));
            this.Sk = new SimulatorK8101(location, size);

            this.Updater = new Timer();
            this.Updater.Interval = 1;
            this.Updater.Tick += UpdaterTick;
        }

        private int DynamiqueLocation(int start, int perCentUsed)
        {
            return (start * perCentUsed) / 100;
        }

        private void UpdaterTick(object sender, EventArgs e)
        {
            Refresh();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitApplication();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.Sk.Draw(e);
        }

        private void TSMIQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
