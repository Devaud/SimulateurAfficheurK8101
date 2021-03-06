﻿/*
 * Projet      : SimulatorDisplayerK8101
 * Description : Simulate fonctionnalities of the Velleman K8101 display.
 * Author      : Devaud Alan & Dylan Wacker
 * Date        : 21.11.2016
 * Version     : 1.0
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
    public class SimuDisplayK8101
    {
        #region Fields
        private Rectangle _rect;
        private Brush _brush;
        private Pen _pen;
        private SDK8101Button _simuButton;
        private SDK8101Usb _simuUsb;
        private SDK8101Lcd _simuLCD;
        #endregion

        #region Properties
        /// <summary>
        /// Get if the client is connected
        /// </summary>
        public bool IsConnected
        {
            get { return this.SimuUsb.IsConnected; }
        }

        /// <summary>
        /// Get or set the SimuLCD
        /// </summary>
        public SDK8101Lcd SimuLCD
        {
            get { return _simuLCD; }
            set { _simuLCD = value; }
        }

        /// <summary>
        /// Get or set the SimuUsb
        /// </summary>
        public SDK8101Usb SimuUsb
        {
            get { return _simuUsb; }
            set { _simuUsb = value; }
        }

        /// <summary>
        /// Get or set the SimuButton
        /// </summary>
        public SDK8101Button SimuButton
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
            Point locationButton = new Point(location.X + (size.Width / 2 - SDK8101Button.DEFAULT_SIZE.Width / 2), location.Y + 10);
            this.SimuButton = new SDK8101Button(locationButton);
            this.SimuLCD = new SDK8101Lcd();
            this.SimuUsb = new SDK8101Usb();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Connect the simuUsb
        /// </summary>
        public void Connect()
        {
            this.SimuUsb.Connect();
        }

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

        /// <summary>
        /// Disconnect the sdk8101
        /// </summary>
        public void Disconnect()
        {
            this.SimuUsb.Disconnect();
        }
        #endregion
    }
}
