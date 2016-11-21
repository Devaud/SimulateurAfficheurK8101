/* Project : SimulatorK8101
*  Author : DEVAUD - WACKER
*  Date : 11.2016
*  Class : SimuK8101
*  Description :  Simulation of the LCD of the K8101
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
    public class SDKLCDK8101
    {
        #region const
        // It's constant but can't be declared constant
        private static Point DEFAULT_LOCATION = new Point(145, 200);
        // Real size of the K8101 -> (128x64)
        private static Size DEFAULT_SIZE = new Size(202, 106); // x1.5 of the real size
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
        public SDKLCDK8101()
            : this(DEFAULT_LOCATION)
        {

        }

        /// <summary>
        /// Create new SimulatorLCD with location and default size
        /// </summary>
        /// <param name="location"></param>
        public SDKLCDK8101(Point location)
            : this(location, DEFAULT_SIZE)
        {

        }

        /// <summary>
        /// Create new SimulatorLCD with location and size
        /// </summary>
        /// <param name="location"></param>
        /// <param name="size"></param>
        public SDKLCDK8101(Point location, Size size)
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
