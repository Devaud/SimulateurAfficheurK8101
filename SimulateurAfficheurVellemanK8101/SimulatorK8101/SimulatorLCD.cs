/* *
 * Project     : SimulatorK8101
 * Class       : SimulatorLCD
 * Description : Manage the lCD
 * Author      : Alan Devaud
 * Date        : 3.10.2016
 * Version     : 1.0
 * */
using System.Drawing;
using System.Windows.Forms;

namespace SimulatorK8101
{
    public class SimulatorLCD
    {
        #region const
        // It's constant but can't be declared constant
        private static Point DEFAULT_LOCATION = new Point(0, 0);
        private static Size DEFAULT_SIZE = new Size(138, 74);
        private static Color DEFAULT_PEN_COLOR = Color.Black;
        private static Color DEFAULT_BRUSH_COLOR = Color.White;

        private const float DEFAULT_PEN_WIDTH = 1f;
        private const int ADAPTIF_RATER = 5;
        #endregion

        #region Fields
        private Rectangle _lcd;
        private Rectangle _backColorLcd;
        private Pen _pen;
        private Brush _brush;
        private Brush _brushBackColor;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the brush background color
        /// </summary>
        public Brush BrushBackColor
        {
            get { return _brushBackColor; }
            set { _brushBackColor = value; }
        }

        /// <summary>
        /// Get or set the lcd rectangle
        /// </summary>
        public Rectangle Lcd
        {
            get { return _lcd; }
            set { _lcd = value; }
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
        /// Get or set the brush
        /// </summary>
        public Brush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        /// <summary>
        /// Get or set the background lcd color
        /// </summary>
        public Rectangle BackColorLcd
        {
            get { return _backColorLcd; }
            set { _backColorLcd = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create new SimulatorLCD with default location and default size
        /// </summary>
        public SimulatorLCD()
            : this(DEFAULT_LOCATION)
        {

        }

        /// <summary>
        /// Create new SimulatorLCD with location and default size
        /// </summary>
        /// <param name="location"></param>
        public SimulatorLCD(Point location)
            : this(location, DEFAULT_SIZE)
        {

        }

        /// <summary>
        /// Create new SimulatorLCD with location and size
        /// </summary>
        /// <param name="location"></param>
        /// <param name="size"></param>
        public SimulatorLCD(Point location, Size size)
        {
            this.BackColorLcd = new Rectangle(location, size);
            this.Lcd = new Rectangle(new Point(location.X + ADAPTIF_RATER, location.Y + ADAPTIF_RATER), new Size(size.Width - ADAPTIF_RATER * 2, size.Height - ADAPTIF_RATER * 2));
            this.Pen = new Pen(DEFAULT_PEN_COLOR, DEFAULT_PEN_WIDTH);
            this.Brush = new SolidBrush(DEFAULT_BRUSH_COLOR);
            this.BrushBackColor = new SolidBrush(DEFAULT_BRUSH_COLOR);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Draw the LCD
        /// </summary>
        /// <param name="pe"></param>
        public void Draw(PaintEventArgs pe)
        {
            pe.Graphics.FillRectangle(this.BrushBackColor, this.BackColorLcd);
            pe.Graphics.DrawRectangle(this.Pen, this.BackColorLcd);
            pe.Graphics.FillRectangle(this.Brush, this.Lcd);
            pe.Graphics.DrawRectangle(this.Pen, this.Lcd);
        }
        #endregion
    }
}
