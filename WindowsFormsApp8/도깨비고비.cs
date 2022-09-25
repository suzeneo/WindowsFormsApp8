using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp8
{
    internal class 도깨비고비
    {
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
