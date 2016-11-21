using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorDisplayerK8101
{
    class SimuDisplayK8101
    {
        #region Fields
        private Rectangle _rect;
        private Brush _brush;
        private Pen _pen;
        private SimuDisplayButtonK8101 _simuButton;
        private SDKLCDK8101 _simuLCD;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the SimuLCD
        /// </summary>
        public SDKLCDK8101 SimuLCD
        {
            get { return _simuLCD; }
            set { _simuLCD = value; }
        }

        /// <summary>
        /// Get or set the SimuButton
        /// </summary>
        public SimuDisplayButtonK8101 SimuButton
        {
            get { return _simuButton; }
            set { _simuButton = value; }
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
        /// Get or set the Brush
        /// </summary>
        public Brush Brush
        {
            get { return _brush; }
            set { _brush = value; }
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
        /// Create new SimuDisplayK8101
        /// </summary>
        /// <param name="location">Position in x, y</param>
        /// <param name="size">Size of the SimuDisplayK8101</param>
        public SimuDisplayK8101(Point location, Size size)
        {
            this.Rect = new Rectangle(location, size);
            this.Pen = new Pen(Color.Black, 2);
            this.Brush = new SolidBrush(Color.Gray);
            Point locationButton = new Point(location.X + (size.Width / 2 - SimuDisplayButtonK8101.DEFAULT_SIZE.Width / 2), location.Y + 10);
            this.SimuButton = new SimuDisplayButtonK8101(locationButton);
            this.SimuLCD = new SDKLCDK8101();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Draw the SimuDisplayK8101
        /// </summary>
        /// <param name="pe"></param>
        public void Draw(PaintEventArgs pe)
        {
            pe.Graphics.FillRectangle(this.Brush, this.Rect);
            pe.Graphics.DrawRectangle(this.Pen, this.Rect);
            this.SimuButton.Draw(pe);
            this.SimuLCD.Draw(pe);
        }

        /// <summary>
        /// When mouse click on the Simulator
        /// </summary>
        /// <param name="mousePosition">Mouse Position in X, Y</param>
        public void Clicked(Point mousePosition)
        {
            this.SimuButton.Clicked(mousePosition);
        }
        #endregion
    }
}
