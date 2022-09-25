using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        //SerialPort sPort;
        private double xCount = 10;
        List<SensorData> mydata = new List<SensorData>();
        public Form2()
        {
            InitializeComponent();
            groupBox1.Text = "도깨비고비";
            foreach (var Ports in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(Ports);
            }
            comboBox1.Text = "Select Port";
            DisConnect.Enabled = true;

            chartsetting();
        }

        private void chartsetting()
        {
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("draw");
            chart1.ChartAreas["draw"].AxisX.Minimum = 0;
            chart1.ChartAreas["draw"].AxisX.Maximum = xCount;
            chart1.ChartAreas["draw"].AxisX.Interval = 2;
            chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
            chart1.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas["draw"].AxisY.Minimum = 0;
            chart1.ChartAreas["draw"].AxisY.Maximum = 1050;
            chart1.ChartAreas["draw"].AxisY.Interval = 200;
            chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
            chart1.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas["draw"].BackColor = Color.Navy;

            chart1.ChartAreas["draw"].CursorX.AutoScroll = true;
            chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;

            chart1.Series.Clear();
            chart1.Series.Add("s[0]");
            chart1.Series["s[0]"].ChartType = SeriesChartType.Line;
            chart1.Series["s[0]"].Color = Color.Yellow;
            chart1.Series["s[0]"].BorderWidth = 3;
            if (chart1.Legends.Count > 0)
                chart1.Legends.RemoveAt(0);
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Program.xserial Xserial = new Program.xserial("1111");
            Xserial.Open();
            Connect.Enabled = false;
            DisConnect.Enabled = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.xserial Xserial = new Program.xserial("1111");
            Xserial.Open();
            ComboBox cb = sender as ComboBox;
        }

        private void DisConnect_Click(object sender, EventArgs e)
        {
            Program.xserial Xserial = new Program.xserial("1111");
            Xserial.Close();
            DisConnect.Enabled = false;
            Connect.Enabled = true;
 
        }
    }
}
