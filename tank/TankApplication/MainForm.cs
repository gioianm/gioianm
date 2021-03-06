﻿using System;
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
        private TankControlSystem controlSystem2;
        private NelderMeadMethod optimization;
        private const double dt = 0.5;
        
        
        private int m_roundCof = 5;
        
        
        public MainForm()
        {

            InitializeComponent();
            valveCoefficientLabel.Text = ControlSystems.SystemSettings.Interference.ToString();
            kTextBox.Text = SystemSettings.DefaultK.ToString();
            kiTextBox.Text = SystemSettings.DefaultKi.ToString();
           
            kdTextBox.Text = SystemSettings.DefaultK.ToString();
            controlSystem = new TankControlSystem(dt);
            controlSystem2 = new TankControlSystem(dt);
            optimization = new NelderMeadMethod();
            double[] X = controlSystem.Regulator.GetConfig();
            controlSystem2.Regulator.RewriteConfig(optimization.nelMead(ref X));

            Optimal.Text += string.Format("\nK = {0}\nKi = {1}\nKd = {2}", controlSystem2.Regulator.K, controlSystem2.Regulator.Ki, controlSystem.Regulator.Kd);

        }


        private void reducePreasureButton_Click(object sender, EventArgs e)
        {
            if (controlSystem.WorkMode == WorkMode.Manual)
            {
                controlSystem.InputGain -= SystemSettings.MaxGainStep;
                preasureLabel.Text = Math.Round(controlSystem.InputGain, m_roundCof).ToString();
            }
        }

        private void increasePreasureButton_Click(object sender, EventArgs e)
        {
            if (controlSystem.WorkMode == WorkMode.Manual)
            {
                controlSystem.InputGain += SystemSettings.MaxGainStep;
                preasureLabel.Text = Math.Round(controlSystem.InputGain, m_roundCof).ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            controlSystem.CalculateWaterLevel();

            waterLevelLabel.Text = Math.Round(controlSystem.WaterLevel, m_roundCof).ToString();
            waterLimitStateChart.Series[0].Points.AddXY(controlSystem.Time, controlSystem.WaterLevel);
            preasureLabel.Text = Math.Round(controlSystem.InputGain, m_roundCof).ToString();
            label2.Text = Math.Round(controlSystem.OutputGain, m_roundCof).ToString();
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
            
            
            controlSystem.OutputGain -= SystemSettings.MaxGainStep;
            label2.Text = Math.Round(controlSystem.OutputGain, m_roundCof).ToString();
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
          
            
                controlSystem.OutputGain += SystemSettings.MaxGainStep;
                label2.Text = Math.Round(controlSystem.OutputGain, m_roundCof).ToString();
            
        }
       
              
        private void SendRegulatorTaskButton_Click_1(object sender, EventArgs e)
        {
            controlSystem.Regulator.RegulatorTask = Convert.ToDouble(regulatorTaskTextBox.Text);
            currentRegulatorTaskLabel.Text = (controlSystem.Regulator.RegulatorTask+1).ToString();
        }

        private void AutomaticControlButton_Click_1(object sender, EventArgs e)
        {
            controlSystem.WorkMode = WorkMode.Automatic;
            workStateLabel.Text = "Automatic";
        }

        private void SendSettingsButton_Click_1(object sender, EventArgs e)
        {
            controlSystem.Regulator.K = Convert.ToDouble(kTextBox.Text);
            controlSystem.Regulator.Ki = Convert.ToDouble(kiTextBox.Text);
            controlSystem.Regulator.Kd = Convert.ToDouble(kdTextBox.Text);

            kLabel.Text = controlSystem.Regulator.K.ToString();
            kiLabel.Text = controlSystem.Regulator.Ki.ToString();
            kdLabel.Text = controlSystem.Regulator.Kd.ToString();
        }

        private void ManualControlButton_Click_1(object sender, EventArgs e)
        {
            controlSystem.WorkMode = WorkMode.Manual;
            workStateLabel.Text = "Manual";
        }
    }
}
