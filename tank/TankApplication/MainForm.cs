using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BrilliantApplication.ControlSystems;
using BlocksLibrary.Blocks;
using BlocksLibrary.Interfaces;

namespace BrilliantApplication
{
    public partial class MainForm : Form
    {
        private TankControlSystem controlSystem;
        private const double dt = 0.5;
        private double m_inputStreamStep = 0.1;
        private double m_outputStreamStep = 0.1;
        private int m_roundCof = 5;
        
        
        public MainForm()
        {
            InitializeComponent();
            valveCoefficientLabel.Text = ControlSystems.SystemSettings.Interference.ToString();
            controlSystem = new TankControlSystem(dt);
        }

      

        private void reducePreasureButton_Click(object sender, EventArgs e)
        {
            controlSystem.InputStream -= m_inputStreamStep;
            preasureLabel.Text = Math.Round(controlSystem.InputStream, m_roundCof).ToString();
        }

        private void increasePreasureButton_Click(object sender, EventArgs e)
        {
            controlSystem.InputStream += m_inputStreamStep;
            preasureLabel.Text = Math.Round(controlSystem.InputStream, m_roundCof).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            controlSystem.CalculateWaterLevel();

            waterLevelLabel.Text = Math.Round(controlSystem.WaterLevel, m_roundCof).ToString();
            waterLimitStateChart.Series[0].Points.AddXY(controlSystem.Time, controlSystem.WaterLevel);

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            controlSystem.RefreshSystem();
            waterLevelLabel.Text = "0";
            

            foreach (var series in waterLimitStateChart.Series)
            {
                series.Points.Clear();
            }
        }

        private void x10Button_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        private void x1Button_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            controlSystem.OutputStream -= m_outputStreamStep;
            label2.Text = Math.Round(controlSystem.OutputStream, m_roundCof).ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            controlSystem.OutputStream += m_outputStreamStep;
            label2.Text = Math.Round(controlSystem.OutputStream, m_roundCof).ToString();
        }
    }
}
