﻿/* Project : SimulatorK8101
*  Author : DEVAUD - WACKER
*  Date : 11.2016
*  Class : SimuK8101
*  Description : Library for simulation of the K8101
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Net;

namespace SimuVelleman.Kits
{
    public class SimuK8101
    {
        #region Fields
        private const string IP_SERVE = "127.0.0.1";
        private const int PORT_SERVE = 500;

        private Socket _socketClient = null;
        private Thread _dataReceived = null;
        private long _sequence = 0;

        private Thread Flasht = null;


        //// Get a client stream for reading and writing.
        private Stream _stream;
        private StreamWriter _sw;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the SocketClient
        /// </summary>
        public Socket SocketClient
        {
            get { return _socketClient; }
            set { _socketClient = value; }
        }


        /// <summary>
        /// Get or set the DataReceived
        /// </summary>
        public Thread DataReceived
        {
            get { return _dataReceived; }
            set { _dataReceived = value; }
        }

        public long Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }

        public Stream Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        public StreamWriter Sw
        {
            get { return _sw; }
            set { _sw = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new SimuK8101
        /// </summary>
        public SimuK8101()
        {
            this.SocketClient = new Socket();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Connect the SimuK8101
        /// </summary>
        public void Connect()
        {
            try
            {
                this.SocketClient.Connect(IP_SERVE, PORT_SERVE);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Indicate if the TCP connection is made between the display and the client
        /// </summary>
        /// <returns>True if connected</returns>
        public bool Connected()
        {
            return this.SocketClient.Connected;
        }

        /// <summary>
        /// Disconnect the SimuK8101
        /// </summary>
        public void Disconnect()
        {
            try
            {
                this.SocketClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        /// <summary>
        /// Send the data to the server
        /// </summary>
        /// <param name="message"></param>
        void SendMsg(string data)
        {
            byte[] msg = System.Text.Encoding.UTF8.GetBytes(data);
            int DtSent = SocketClient.Send(msg, msg.Length, SocketFlags.None);
            if (DtSent == 0)
            {
                Console.WriteLine("Aucune donnée n'a été envoyée");
            }
        }


        /// <summary>
        /// Process the data to be sent to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SendMessage(object sender, System.EventArgs e, string msgArea)
        {
            //On vérifie que le client est bien connecté
            if (SocketClient == null || !SocketClient.Connected)
            {
                Console.WriteLine("Vous n'êtes pas connecté");
                return;
            }
            try
            {
                if (msgArea != "")
                {
                    //Etant donné qu'on travaille en RTF, on échappe les caractères
                    //spéciaux avant de les envoyer sur le serveur qui nous renverra
                    //le message ainsi qu'aux autres clients connectés
                    //Si vous travaillez en mode texte, vous n'aurez pas à vous soucier
                    //de tout cela
                    string reformattedBuffer = msgArea.Replace("}", "\\}");
                    reformattedBuffer = reformattedBuffer.Replace("\n", "\\par\r\n");
                    //Chaque message est précédé d'un numéro de séquence, ce qui permet
                    //de vérifier si le client vient de se connecter ou non
                    SendMsg(GetSequence() + reformattedBuffer.Replace("{", "\\{"));
                    msgArea = "";
                }

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }


        //Cette méthode génère le numéro de séquence collé en
        //entte du message envoyé au serveur
        string GetSequence()
        {
            Sequence++;
            string msgSeq = Convert.ToString(Sequence);
            char pad = Convert.ToChar("0");
            msgSeq = msgSeq.PadLeft(6, pad);
            return msgSeq;
        }

        /// <summary>
        /// Get IP adress of the server we want to connect
        /// </summary>
        /// <returns></returns>
        private String GetAdr()
        {
            try
            {
                IPHostEntry iphostentry = Dns.GetHostByName(IP_SERVE);
                String IPStr = "";
                foreach (IPAddress ipaddress in iphostentry.AddressList)
                {
                    IPStr = ipaddress.ToString();
                    return IPStr;
                }
            }
            catch (SocketException E)
            {
                Console.WriteLine(E);
            }

            return "";
        }


        private void CheckData()
        {
            try
            {
                while (true)
                {
                    if (SocketClient.Connected)
                    {
                        if (SocketClient.Poll(10, SelectMode.SelectRead) && SocketClient.Available == 0)
                        {
                            //La connexion a été clturée par le serveur ou bien un problème
                            //réseau est apparu
                            Console.WriteLine("La connexion au serveur est interrompue. Essayez avec un autre pseudo");
                            Thread.CurrentThread.Abort();
                        }
                        //Si la socket a des données à lire
                        if (SocketClient.Available > 0)
                        {
                            string messageReceived = null;
                            if (Flasht == null)
                            {
                                if (allowBlink && Notif.Checked)
                                {
                                    Flasht = new Thread(new ThreadStart(Flash));
                                    Flasht.Start();
                                }
                            }
                            else
                            {
                                if (allowBlink && Notif.Checked && Flasht.IsAlive == false)
                                {
                                    Flasht = new Thread(new ThreadStart(Flash));
                                    Flasht.Start();
                                }
                            }
                            while (ClientSocket.Available > 0)
                            {
                                try
                                {
                                    byte[] msg = new Byte[ClientSocket.Available];
                                    //Réception des données
                                    ClientSocket.Receive(msg, 0, ClientSocket.Available, SocketFlags.None);
                                    messageReceived = System.Text.Encoding.UTF8.GetString(msg).Trim();
                                    //On concatène les données reues(max 4ko) dans
                                    //une variable de la classe
                                    rtfContent += messageReceived;
                                }
                                catch (SocketException E)
                                {
                                    MessageBox.Show("CheckData read" + E.Message);
                                }
                            }
                            try
                            {
                                //On remplit le richtextbox avec les données reues 
                                //lorsqu'on a tout réceptionné
                                chatBody.Rtf = rtfStart + rtfContent;
                                this.BringToFront();
                            }
                            catch (Exception E)
                            {
                                MessageBox.Show(E.Message);
                            }

                        }
                    }
                    //On temporise pendant 10 millisecondes, ceci pour éviter
                    //que le micro processeur s'emballe
                    Thread.Sleep(10);
                }
            }
            catch
            {
                //Ce thread étant susceptible d'tre arrté à tout moment
                //on catch l'exception afin de ne pas afficher un message à l'utilisateur
                Thread.ResetAbort();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">The string you want write</param>
        /// <param name="size">Size of the text</param>
        /// <param name="x1">position x</param>
        /// <param name="y1">position y</param>
        /// <param name="x2">position x2</param>
        public void DrawText(string str, SimuK8101.TextSize size, byte x1, byte y1, byte x2)
        {
            // Gets an encoding for the ASCII (7-bit) character set.
            ASCIIEncoding asen = new ASCIIEncoding();
            // encodes a set of characters into a sequence of bytes.
            byte[] ba = asen.GetBytes(str + x1 + y1 + x2);
            // Transmitting the text
            Stream.Write(ba, 0, ba.Length);


            byte[] bb = new byte[100];
            int k = Stream.Read(bb, 0, 100);

            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(bb[i]));

            Stream.Close();
        }

        public void DrawLine(byte x1, byte y1, byte x2, byte y2)
        {
            byte[] buffer = new byte[10]
      {
        (byte) 170,
        (byte) 16,
        (byte) 0,
        (byte) 18,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 85
      };
            byte num = 0;
            buffer[4] = x1;
            buffer[5] = y1;
            buffer[6] = x2;
            buffer[7] = y2;
            int index = 1;
            do
            {
                num = checked((byte)unchecked((int)checked((short)unchecked((int)Convert.ToInt16((short)buffer[index]) + (int)num)) % 256));
                checked { ++index; }
            }
            while (index <= 7);
            buffer[8] = num;
            if (!this.Connected())
                return;

            Stream.Write(buffer, 0, 10);
        }

        #endregion
        public enum TextSize
        {
            Small,
            Large,
        }
    }
}
