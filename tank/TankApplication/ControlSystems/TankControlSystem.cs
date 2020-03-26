﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlocksLibrary.Blocks;
using BlocksLibrary.Interfaces;

namespace BrilliantApplication.ControlSystems
{
    public class TankControlSystem : ObjectControlSystem
    {
        private double m_inputStream = 0;
        private double m_outputStream = 0;
        private double m_valve = 0;
        public double InputStream
        {
            get { return m_inputStream; }
            set
            {
                if (value < 0)
                {
                    m_inputStream = 0;
                }
                else if (value > SystemSettings.MaxInputStream)
                {
                    m_inputStream = SystemSettings.MaxInputStream;
                }
                else
                {
                    m_inputStream = value;
                }
            }
        }
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

        public double Valve { get { return m_valve; } set { if (value > 1) m_valve = 1; else if (value < 0) m_valve = 0; else m_valve = value; } }
        public double WaterLevel { get; set; }

        public TankControlSystem(double dt) : base() 
        {
            DT = dt;
            InputStream = 0;
            Valve = 0;

            var blocks = new Queue<IBlock>();
            blocks.Enqueue(new DelayBlock(dt, SystemSettings.Delay));
            blocks.Enqueue(new AperiodicBlock(DT, SystemSettings.T));
            blocks.Enqueue(new GainBlock(SystemSettings.T));
            blocks.Enqueue(new InterferenceBlock(SystemSettings.Interference));
            Object = new ComplexBlock(blocks);
        }

        public double CalculateWaterLevel()
        {
            var inputValue = InputStream - OutputStream;
            var result = Object.Calculate(inputValue)-inputValue;

            WaterLevel = result;

            if (WaterLevel <= 0 && inputValue < 0)
            {
                WaterLevel = 0;

                foreach (var block in Object.Blocks)
                {
                    var integralBlock = block as IntegralBlock;

                    if (integralBlock != null)
                    {
                        integralBlock.StepBackAtLimitValue();
                    }
                }
            }

            if (WaterLevel >= SystemSettings.WaterLevelLimit && inputValue > 0)
            {
                WaterLevel = SystemSettings.WaterLevelLimit;

                foreach (var block in Object.Blocks)
                {
                    var integralBlock = block as IntegralBlock;

                    if (integralBlock != null)
                    {
                        integralBlock.StepBackAtLimitValue();
                    }
                }
            }

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