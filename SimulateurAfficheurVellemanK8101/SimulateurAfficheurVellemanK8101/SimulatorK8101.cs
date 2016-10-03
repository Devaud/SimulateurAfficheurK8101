using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateurAfficheurVellemanK8101
{
    class SimulatorK8101
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
        #endregion

        #region Properties
        public SimulatorLCD SimLCD
        {
            get { return _simLCD; }
            set { _simLCD = value; }
        }

        public SimulatorButton SimButton
        {
            get { return _simButton; }
            set { _simButton = value; }
        }

        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }

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
        #endregion

        #region Constructor
        public SimulatorK8101(Point location)
            : this(location, DEFAULT_SIZE)
        {

        }
        public SimulatorK8101(Point location, Size size)
        {
            this.Rect = new Rectangle(location, size);
            this.Pen = new Pen(Color.Black, 2);
            this.Brush = new SolidBrush(Color.Gray);
            this.SimButton = new SimulatorButton(new Point(location.X + (size.Width / 2) - 16, location.Y + size.Height * 5 / 100), 
                                                 new Size(size.Width * 10 / 100, size.Height * 10 / 100));

            this.SimLCD = new SimulatorLCD(new Point(location.X + (size.Width * 5 / 100), location.Y + size.Height * 20 / 100),
                                           new Size(size.Width * 90 / 100, size.Height * 75 / 100));
        }
        #endregion

        #region Methods
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
