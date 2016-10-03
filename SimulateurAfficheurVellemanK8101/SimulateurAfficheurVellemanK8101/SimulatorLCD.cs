using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateurAfficheurVellemanK8101
{
    class SimulatorLCD
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
        public Brush BrushBackColor
        {
            get { return _brushBackColor; }
            set { _brushBackColor = value; }
        }

        public Rectangle Lcd
        {
            get { return _lcd; }
            set { _lcd = value; }
        }

        public Pen Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }

        public Brush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        public Rectangle BackColorLcd
        {
            get { return _backColorLcd; }
            set { _backColorLcd = value; }
        }
        #endregion

        #region Constructor
        public SimulatorLCD()
            : this(DEFAULT_LOCATION)
        {

        }

        public SimulatorLCD(Point location)
            : this(location, DEFAULT_SIZE)
        {

        }

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
