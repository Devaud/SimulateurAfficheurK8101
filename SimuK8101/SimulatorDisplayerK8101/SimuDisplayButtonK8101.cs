using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorDisplayerK8101
{
    class SimuDisplayButtonK8101
    {
        #region Const
        // Can't be declared const
        private static Size _DEFAULT_SIZE = new Size(32, 32);
        private static Color DEFAULT_PEN_COLOR = Color.Black;
        private static Color DEFAULT_BRUSH_COLOR = Color.Black;

        private const float DEFAULT_PEN_WIDTH = 3f;
        #endregion

        #region Fields
        private Rectangle _rect;
        private Pen _pen;
        private Brush _brush;
        #endregion

        #region Properties
        /// <summary>
        /// Get the DEFAULT_SIZE
        /// </summary>
        public static Size DEFAULT_SIZE
        {
            get { return SimuDisplayButtonK8101._DEFAULT_SIZE; }
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

        /// <summary>
        /// Get or set the rectangle
        /// </summary>
        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create new button with personnal location and DEFAULT_SIZE
        /// </summary>
        /// <param name="location">Button position</param>
        public SimuDisplayButtonK8101(Point location)
            : this(location, DEFAULT_SIZE)
        {

        }

        /// <summary>
        /// Create new button with personnal location and size
        /// </summary>
        /// <param name="location">Button position</param>
        /// <param name="size">Button size</param>
        public SimuDisplayButtonK8101(Point location, Size size)
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
            pe.Graphics.DrawRectangle(this.Pen, this.Rect);
            pe.Graphics.FillRectangle(this.Brush, this.Rect);
        }

        /// <summary>
        /// When mouse click on the button
        /// </summary>
        /// <param name="mousePosition">Mouse Position in X, Y</param>
        public void Clicked(Point mousePosition)
        {
            if (this.Rect.Location.X <= mousePosition.X && this.Rect.Location.X + this.Rect.Size.Width >= mousePosition.X &&
                this.Rect.Location.Y <= mousePosition.Y && this.Rect.Location.Y + this.Rect.Size.Height >= mousePosition.Y)
            {
                MessageBox.Show("Clicked on the button");
            }
        }
        #endregion

    }
}
