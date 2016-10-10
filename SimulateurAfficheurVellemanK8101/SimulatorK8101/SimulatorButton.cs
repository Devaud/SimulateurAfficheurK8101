/* *
 * Project     : SimulatorK8101
 * Class       : SimulatorButton
 * Description : Manage the button
 * Author      : Alan Devaud
 * Date        : 3.10.2016
 * Version     : 1.0
 * */

using System.Drawing;
using System.Windows.Forms;

namespace SimulatorK8101
{
    public class SimulatorButton
    {
        #region Const
        // It's constant but can't be declared constant
        private static Point DEFAULT_LOCATION = new Point(0, 0);
        private static Size DEFAULT_SIZE = new Size(32, 32);
        private static Color DEFAULT_PEN_COLOR = Color.Black;
        private static Color DEFAULT_BRUSH_COLOR = Color.Gray;

        private const float DEFAULT_PEN_WIDTH = 3f;
        #endregion

        #region Fields
        private Rectangle _rect;
        private Pen _pen;
        private Brush _brush;
        #endregion

        #region Properties
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

        /// <summary>
        /// Get the pen color
        /// </summary>
        public Color Color
        {
            get { return _pen.Color; }
        }
        
        /// <summary>
        /// Get or set the rectangle
        /// </summary>
        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }

        /// <summary>
        /// Get the location
        /// </summary>
        public Point Location
        {
            get { return _rect.Location; }
        }

        /// <summary>
        /// Get the size
        /// </summary>
        public Size Size
        {
            get { return _rect.Size; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create new button with default location and default size
        /// </summary>
        public SimulatorButton()
            : this(DEFAULT_LOCATION)
        {

        }

        /// <summary>
        /// Create new button with location and default size
        /// </summary>
        /// <param name="location">Button location</param>
        public SimulatorButton(Point location)
            : this(location, DEFAULT_SIZE)
        {

        }

        /// <summary>
        /// Create new button with location and size
        /// </summary>
        /// <param name="location">Button location</param>
        /// <param name="size">Button size</param>
        public SimulatorButton(Point location, Size size)
        {
            this.Rect = new Rectangle(location, size);
            this.Pen = new Pen(DEFAULT_PEN_COLOR, DEFAULT_PEN_WIDTH);
            this.Brush = new SolidBrush(DEFAULT_BRUSH_COLOR);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Draw the button
        /// </summary>
        /// <param name="pe"></param>
        public void Draw(PaintEventArgs pe)
        {
            pe.Graphics.DrawEllipse(this.Pen, this.Rect);
            pe.Graphics.FillEllipse(this.Brush, this.Rect);
        }
        #endregion
    }
}
