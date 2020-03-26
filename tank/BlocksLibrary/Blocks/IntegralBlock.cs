using System;
using System.Collections.Generic;
using System.Text;

using BlocksLibrary.Interfaces;

namespace BlocksLibrary.Blocks
{
    public class IntegralBlock : IBlock, IRefreshable
    {
        private double m_dt;
        private double m_prevOfPrev = 0;
        private double m_prevSum = 0;

        public double Prev { get; set; } = 0;
        public double Sum { get; set; } = 0;

        public IntegralBlock(double dt)
        {
            m_dt = dt;
        }

        public virtual double Calculate(double input)
        {
            m_prevSum = Sum;
            m_prevOfPrev = Prev;
            Sum += (input + Prev) * m_dt / 2;
            Prev = input;

            return Sum;
        }

        public void Refresh()
        {
            Sum = 0;
            Prev = 0;
        }

        public void StepBackAtLimitValue()
        {
            Sum = m_prevSum;
            Prev = m_prevOfPrev;
        }
    }
}