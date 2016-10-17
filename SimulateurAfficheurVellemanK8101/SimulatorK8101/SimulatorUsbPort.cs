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
using System.Windows.Forms;
using System.Management;

namespace SimulatorK8101
{
    public class SimulatorUsbPort
    {
        #region const
        // set the serial baud rate.
        private const int DEFAULT_BAUDRATE = 0x2580; // 9600
        // set the standard number of stopbits per byte.
        private const StopBits DEFAULT_STOPBITS = StopBits.One;
        // set the standard data bits
        private const int DEFAULT_VALUE_DATABITS = 8;
        // set the number of milliseconds before a timeout occurs when a read operation does not finish.
        private const int DEFAULT_READTIMEOUT = 100; // miliseconds
        private const Parity DEFAULT_PARITY = Parity.None;
        private const int START_BUFFER = 170;
        private const int END_BUFFER = 0x55;
        private const string PATH_MANAGEMENT_SCOPE = @"root\CIMV2";
        #endregion

        #region Fields
        private SerialPort _sp;
        private ManagementClass _osClass;
        private ManagementScope _manageScope;
        #endregion

        #region Properties
        public SerialPort Sp
        {
            get { return _sp; }
            set { _sp = value; }
        }

        public ManagementClass OsClass
        {
            get { return _osClass; }
            set { _osClass = value; }
        }

        public ManagementScope ManageScope
        {
            get { return _manageScope; }
            set { _manageScope = value; }
        }
        #endregion

        #region Constructor
        public SimulatorUsbPort()
        {
            this.Sp = new SerialPort();
            this.ManageScope = new ManagementScope(PATH_MANAGEMENT_SCOPE);
            ObjectGetOptions o = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);
            ManagementPath p = new ManagementPath("Win32_SerialPort");
            this.OsClass = new ManagementClass(this.ManageScope, p, o);
        }

        #endregion

        #region Methods
        public void Disconnect()
        {
            this.Sp.Close();
        }

        public void Connect()
        {
            try
            {
                this.Sp.BaudRate = DEFAULT_BAUDRATE;
                this.Sp.Parity = DEFAULT_PARITY;
                this.Sp.StopBits = DEFAULT_STOPBITS;
                this.Sp.DataBits = DEFAULT_VALUE_DATABITS;
                this.Sp.PortName = this.ConnectToPort();
                this.Sp.Open();
                this.Sp.Write("VID_10CF&PID_8101");
                MessageBox.Show("Connected");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            PropertyDataCollection properties = this.OsClass.Properties;
            properties["PNPDeviceID"].Value = "VID_10CF&PID_8101";
            properties["DeviceID"].Value = this.Sp.PortName;
            /*Console.WriteLine("Properties : ");
            foreach (PropertyData property in properties)
            {
                Console.WriteLine(property.Name + " : " + property.Value);
            }
            Console.WriteLine("----------------------------------");*/

        }

        public bool Connected()
        {
            return this.Sp.IsOpen;
        }

        /// <summary>
        /// Search a free COM PORT and create one
        /// </summary>
        private string ConnectToPort()
        {
            int NumberComPort = 1; // COM port begins at 1
            // search all port and add them to a list
            List<String> allPorts = new List<String>();
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                allPorts.Add(portName);
            }

            string comPortUse = String.Empty;
            // create a port to a COM free
            foreach (string item in allPorts)
            {
                comPortUse = "COM" + NumberComPort;
                if (comPortUse == item)
                    break;
                NumberComPort++;
            }

            return comPortUse;
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
