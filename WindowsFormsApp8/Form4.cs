using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form4 : Form
    {
        Thread watchThread = null;

        SerialPort sPort;
        List<SensorData> myData = new List<SensorData>();
        public Form4()
        {
            InitializeComponent();
        }
    }
}
