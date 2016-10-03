using System.Drawing;
using System.Windows.Forms;

namespace SimulateurAfficheurVellemanK8101
{
    class SimulatorButton
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
        public Brush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        public Pen Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }

        public Color Color
        {
            get { return _pen.Color; }
        }

        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }

        public Point Location
        {
            get { return _rect.Location; }
        }

        public Size Size
        {
            get { return _rect.Size; }
        }
        #endregion

        #region Constructor
        public SimulatorButton()
            : this(DEFAULT_LOCATION)
        {

        }

        public SimulatorButton(Point location)
            : this(location, DEFAULT_SIZE)
        {

        }

        public SimulatorButton(Point location, Size size)
        {
            this.Rect = new Rectangle(location, size);
            this.Pen = new Pen(DEFAULT_PEN_COLOR, DEFAULT_PEN_WIDTH);
            this.Brush = new SolidBrush(DEFAULT_BRUSH_COLOR);
        }
        #endregion

        #region Methods
        public void Draw(PaintEventArgs pe)
        {
            pe.Graphics.DrawEllipse(this.Pen, this.Rect);
            pe.Graphics.FillEllipse(this.Brush, this.Rect);
        }
        #endregion
    }
}
