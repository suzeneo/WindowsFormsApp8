using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp8
{
    public partial class Form4 : Form
    {
        Thread watchThread = null;
        //SerialPort sPort = new SerialPort("COM6");
        List<SensorData> myData = new List<SensorData>();
        public Int32[] soil = new int[2];
        OleDbConnection conn = null;
        OleDbCommand comm = null;
        OleDbCommand comm2 = null;
        OleDbCommand comm3 = null;
        OleDbDataReader reader = null;

        SerialPort sPort;
        
        public Form4()
        {
            InitializeComponent();
        }
        void watch()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (; ; )
            {
                Thread.Sleep(1000); //1초

                TimeSpan ts = stopwatch.Elapsed;

                if (ts.Minutes > 59) //1시간 되면 DB 저장하고
                {
                    Program.xserial Xserial = new Program.xserial("1111");
                    int sv1 = Xserial.soil[0];
                    int sv2 = Xserial.soil[1];
                    string query = "INSER INTO SoilSendor (SN, SDate, SV, Moisture) VALUES (0,'" + Time + "','" + sv1 + "','" + Moisture + "')";


                    conn = new OleDbConnection(connStr);
                    conn.Open();
                    comm3 = new OleDbCommand(query, conn);
                    comm3.ExcuteNonQuery();
                    conn.Close();
                    conn = null;

                    stopwatch.Restart(); //시간 초기화
                }


            }
        }
    }

}