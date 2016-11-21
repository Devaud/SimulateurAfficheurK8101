/*
 * Projet      : SimulatorDisplayerK8101
 * Description : Simulate fonctionnalities of the Velleman K8101 display.
 * Author      : Devaud Alan & Dylan Wacker
 * Date        : 21.11.2016
 * Version     : 1.0
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorDisplayerK8101
{
    public class SDK8101Controller
    {
        #region Fields
        private SimuDisplayK8101 _sdk8101;
        private SDK8101MainView _view;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set SimuDisplayK8101
        /// </summary>
        public SimuDisplayK8101 Sdk8101
        {
            get { return _sdk8101; }
            set { _sdk8101 = value; }
        }

        /// <summary>
        /// Get or set the View
        /// </summary>
        public SDK8101MainView View
        {
            get { return _view; }
            set { _view = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create new controller
        /// </summary>
        /// <param name="param_view">View</param>
        public SDK8101Controller(SDK8101MainView param_view)
        {
            this.View = param_view;
            this.Sdk8101 = new SimuDisplayK8101(new Point(100, 100), new Size(293, 229));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Draw element
        /// </summary>
        /// <param name="g"></param>
        public void Draw(PaintEventArgs g)
        {
            this.Sdk8101.Draw(g);
        }

        /// <summary>
        /// Click event
        /// </summary>
        /// <param name="mousePosition"></param>
        public void Clicked(Point mousePosition)
        {
            this.Sdk8101.Clicked(mousePosition);
        }

        /// <summary>
        /// Connect the simulator to a client
        /// </summary>
        public void Connect()
        {
            this.Sdk8101.Connect();
        }

        /// <summary>
        /// Get if the sdkDisplay is connected
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return this.Sdk8101.IsConnected;
        }

        /// <summary>
        /// Disconnect the sdk8101
        /// </summary>
        public void Disconnect()
        {
            this.Sdk8101.Disconnect();
        }
        #endregion
    }
}
