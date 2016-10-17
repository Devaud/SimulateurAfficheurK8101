/* *
 * Project     : SimulatorK8101
 * Class       : SimulatorK8101
 * Description : This class is the simulator. It's compose by SimulatorButton and SimulatorLCD and manage it.
 * Author      : Alan Devaud
 * Date        : 3.10.2016
 * Version     : 1.0
 * */
using System.Drawing;
using System.Windows.Forms;

namespace SimulatorK8101
{
    public class SimulatorK8101
    {
        #region Const
        public static Size DEFAULT_SIZE = new Size(337, 380);
        #endregion

        #region Fields
        private Rectangle _rect;
        private Brush _brush;
        private Pen _pen;
        private SimulatorButton _simButton;
        private SimulatorLCD _simLCD;
        private SimulatorUsbPort _simUsbPort;
        #endregion

        #region Properties
        public SimulatorUsbPort SimUsbPort
        {
            get { return _simUsbPort; }
            set { _simUsbPort = value; }
        }

        /// <summary>
        /// Get or set the Simulator LCD
        /// </summary>
        public SimulatorLCD SimLCD
        {
            get { return _simLCD; }
            set { _simLCD = value; }
        }

        /// <summary>
        /// Get or set the Simulator button
        /// </summary>
        public SimulatorButton SimButton
        {
            get { return _simButton; }
            set { _simButton = value; }
        }

        /// <summary>
        /// Get the rectangle properties 
        /// </summary>
        public Rectangle Rect
        {
            get { return _rect; }
        }

        /// <summary>
        /// Get or set the brush
        /// </summary>
        public Brush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        /// <summary>
        /// Get or set the pen
        /// </summary>
        public Pen Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create new Simulator with a location and a default size
        /// </summary>
        /// <param name="location">Simulator location</param>
        public SimulatorK8101(Point location)
            : this(location, DEFAULT_SIZE)
        {

        }

        /// <summary>
        /// Create new Simulator with a position and a size
        /// </summary>
        /// <param name="location">Simulator position</param>
        /// <param name="size">Simulator size</param>
        public SimulatorK8101(Point location, Size size)
        {
            this._rect = new Rectangle(location, size);
            this.Pen = new Pen(Color.Black, 2);
            this.Brush = new SolidBrush(Color.Gray);
            // Place and resize the simulator button with "dynamique" coordonate
            this.SimButton = new SimulatorButton(new Point(location.X + (size.Width / 2) - 16, location.Y + size.Height * 5 / 100), 
                                                 new Size(size.Width * 10 / 100, size.Height * 10 / 100));
            // Place and resize the simulator LCDk with "dynamique" coordonate
            this.SimLCD = new SimulatorLCD(new Point(location.X + (size.Width * 5 / 100), location.Y + size.Height * 20 / 100),
                                           new Size(size.Width * 90 / 100, size.Height * 75 / 100));

            this.SimUsbPort = new SimulatorUsbPort();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Draw the simulator
        /// </summary>
        /// <param name="pe"></param>
        public void Draw(PaintEventArgs pe)
        {
            pe.Graphics.FillRectangle(this.Brush, this.Rect);
            pe.Graphics.DrawRectangle(this.Pen, this.Rect);
            this.SimButton.Draw(pe);
            this.SimLCD.Draw(pe);
        }
        #endregion
    }
}
