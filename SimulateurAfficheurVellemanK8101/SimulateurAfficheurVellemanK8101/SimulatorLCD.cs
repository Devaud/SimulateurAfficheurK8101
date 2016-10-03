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
        private static Size DEFAULT_SIZE = new Size(150, 100);
        private static Color DEFAULT_PEN_COLOR = Color.Black;
        private static Color DEFAULT_BRUSH_COLOR = Color.White;

        private const float DEFAULT_PEN_WIDTH = 1f; 
        #endregion
        
        #region Fields
        private Rectangle _lcd;
        private Pen _pen;
        private Brush _brush;
        #endregion

        #region Properties
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
        #endregion

        #region Constructor
        public SimulatorLCD() : this(DEFAULT_LOCATION)
        {

        }

        public SimulatorLCD(Point location) :this(location, DEFAULT_SIZE)
        {

        }

        public SimulatorLCD(Point location, Size size)
        {
            this.Lcd = new Rectangle(location, size);
            this.Pen = new Pen(DEFAULT_PEN_COLOR, DEFAULT_PEN_WIDTH);
            this.Brush = new SolidBrush(DEFAULT_BRUSH_COLOR);
        }
        #endregion

        #region Methods
        public void Draw(PaintEventArgs pe)
        {
            pe.Graphics.FillRectangle(this.Brush, this.Lcd);
            pe.Graphics.DrawRectangle(this.Pen, this.Lcd);
        }
        #endregion
    }
}
