﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrilliantApplication.Regulators;
using BlocksLibrary.Blocks;
using BlocksLibrary.Interfaces;

namespace BrilliantApplication.ControlSystems
{
    public enum WorkMode
    {
        Manual,
        Automatic
    }
    public class TankControlSystem : ObjectControlSystem
    {
        private double InputStream;
        private double m_outputStream = 0;
        public double m_regulatorTask = 0;
        private AperiodicBlock m_withoutHitBlock;
        private double m_valve = 0;
        private double m_inputgain = 0;
        private double m_outputgain = 0;


        public double OutputStream
        {
            get { return m_outputStream; }
            set
            {
                if (value < 0)
                {
                    m_outputStream = 0;
                }
                else if (value > SystemSettings.MaxOutputStream)
                {
                    m_outputStream = SystemSettings.MaxOutputStream;
                }
                else
                {
                    m_outputStream = value;
                }
            }
        }
        public double InputGain
        {
            get { return m_inputgain; }
            set
            {
                if (value < 0)
                {
                    m_inputgain = 0;
                }
                else if (value > SystemSettings.Gain1)
                {
                    m_inputgain = SystemSettings.Gain1;
                }
                else
                {
                    m_inputgain = value;
                }
            }
        }
        public double OutputGain
        {
            get { return m_outputgain; }
            set
            {
                if (value < 0)
                {
                    m_outputgain = 0;
                }
                else if (value > SystemSettings.MaxOutputStream)
                {
                    m_outputgain = SystemSettings.Gain2;
                }
                else
                {
                    m_outputgain = value;
                }
            }
        }

        public double Valve { get { return m_valve; } set { if (value > 1) m_valve = 1; else if (value < 0) m_valve = 0; else m_valve = value; } }
        public double WaterLevel { get; set; }
       
        public WorkMode WorkMode { get; set; } = WorkMode.Manual;
        public PIDRegulator Regulator { get; set; }
        public TankControlSystem(double dt) : base() 
        {
            DT = dt;
            Valve = 0;
            InputStream = SystemSettings.MaxInputStream;
            OutputStream = SystemSettings.MaxOutputStream;
            OutputGain = 0.2;
            m_withoutHitBlock = new AperiodicBlock(dt, SystemSettings.T);
            var blocks = new Queue<IBlock>();
            blocks.Enqueue(new DelayBlock(dt, SystemSettings.Delay));
            blocks.Enqueue(new AperiodicBlock(DT, SystemSettings.T));
            blocks.Enqueue(new GainBlock(SystemSettings.T));
            blocks.Enqueue(new InterferenceBlock(SystemSettings.Interference));
            Object = new ComplexBlock(blocks);
            Regulator = new PIDRegulator(dt);
        }
        public double CalculateWaterLevel()
        {
            var e = m_withoutHitBlock.Calculate(Regulator.RegulatorTask) - WaterLevel;


            if (WorkMode == WorkMode.Automatic)
            {
                 InputGain = Math.Round((Regulator.Regulate(e) / Regulator.Regulate(InputStream)), 2);         
            }
            else
            {
                Regulator.RecalculationForShocklessMode(InputStream, e);
            }

            var inputValue = InputGain*InputStream - OutputGain*OutputStream;
            var result = Object.Calculate(inputValue);

            


            if (result <= 0)
            {
                result = 0;
                inputValue = 0;
               foreach (var block in Object.Blocks)
                {
                    var integralBlock = block as IntegralBlock;

                    if (integralBlock != null)
                    {
                        integralBlock.StepBackAtLimitValue();
                    }
                }
            }

            if (result >= SystemSettings.WaterLevelLimit)
            {
                result = SystemSettings.WaterLevelLimit;

                foreach (var block in Object.Blocks)
                {
                    var integralBlock = block as IntegralBlock;

                    if (integralBlock != null)
                    {
                        integralBlock.StepBackAtLimitValue();
                    }
                }
            }
            WaterLevel = result;
            Time += DT;
            
            return WaterLevel;
        }

        public void RefreshSystem()
        {
            WaterLevel = 0;
            Time = 0;

            foreach(var block in Object.Blocks)
            {
                var temp = block as IRefreshable;
                if (temp != null)
                {
                    temp.Refresh();
                }
            }
        }
    }
}
