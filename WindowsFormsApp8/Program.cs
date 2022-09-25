using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    class Program
    {
        internal static object form1;

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

          public class xserial
        {
            private SerialPort sPort = null;
            public Int32[] soil = new int[2];
            public xserial(string port)
            {
                sPort = new SerialPort(port);
                Open();

                sPort.DataReceived += SPort_DataReceived;
            }

            public void Close()
            {
                sPort.Close();
            }

            public void Open()
            {
                sPort.Open();
            }

            public void SPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {

                byte[] buffer8 = new byte[8];
                int totalRead = 0;
                int readCnt = 0;
                while (totalRead < 8)
                {
                    readCnt = sPort.Read(buffer8, totalRead, 8 - totalRead);
                    totalRead += readCnt;
                }
                soil[0] = BitConverter.ToInt32(buffer8, 0);
                soil[1] = BitConverter.ToInt32(buffer8, 4);
                
            }

        }
}}
