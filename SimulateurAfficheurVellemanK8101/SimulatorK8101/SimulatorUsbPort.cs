/* *
 * Project     : SimulatorK8101
 * Class       : SimulatorUsbPort
 * Description : Manage the Usb Port
 * Author      : Alan Devaud & Dylan Wacker
 * Date        : 10.10.2016
 * Version     : 1.0
 * */
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorK8101
{
    class SimulatorUsbPort
    {
        #region const
        // set the serial baud rate.
        private const int DEFAULT_BAUDRATE = 9600;
        // set the standard number of stopbits per byte.
        private const StopBits DEFAULT_STOPBITS = StopBits.One;//
        // set the standard data bits
        private const byte DEFAULT_VALUE_DATABITS = 8;
        // set the number of milliseconds before a timeout occurs when a read operation does not finish.
        private const int DEFAULT_READTIMEOUT = 100; // miliseconds
        #endregion

        #region Fields
        private SerialPort _sp;
        private string _comPortUse;
        #endregion

        #region Properties
        public SerialPort Sp
        {
            get { return _sp; }
            set { _sp = value; }
        }

        public string ComPortUse
        {
            get { return _comPortUse; }
            set { _comPortUse = value; }
        }
        #endregion

        #region Constructor
        public SimulatorUsbPort()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Search a free COM PORT and create one
        /// </summary>
        public void CreateSerialPort()
        {
            int NumberComPort = 1;
            // search all port and add them to a list
            List<String> allPorts = new List<String>();
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                allPorts.Add(portName);
            }

            // create a port to a COM free
            foreach (string item in allPorts)
            {
                ComPortUse = "COM" + NumberComPort;
                if (ComPortUse != item)
                {
                    break;
                }
                NumberComPort++;
            }
            this.Sp = new SerialPort(ComPortUse,DEFAULT_BAUDRATE);
            Sp.StopBits = DEFAULT_STOPBITS;
            Sp.DataBits = DEFAULT_VALUE_DATABITS;
            if (Sp.IsOpen == false) 
                Sp.Open();
            Sp.Close();
        }

        /// <summary>
        /// Send data to the serial frame
        /// </summary>
        public void SendData()
        {

        }

        /// <summary>
        /// Receive data from a serial frame
        /// </summary>
        public void ReceiveData()
        {
            
        }

        #endregion
    }
}
