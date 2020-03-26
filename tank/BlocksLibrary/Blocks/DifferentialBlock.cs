using System;
using System.Collections.Generic;
using System.Text;

using BlocksLibrary.Interfaces;

namespace BlocksLibrary.Blocks
{
    public class DifferentialBlock : IBlock, IRefreshable
    {
        private double m_prev = 0;
        private double m_dt;

        public DifferentialBlock(double dt)
        {
            m_dt = dt;
        }

        public virtual double Calculate(double input)
        {
            var output = (input - m_prev) / m_dt;
            m_prev = input;

            return output;
        }

        public void Refresh()
        {
            m_prev = 0;
        }
    }
}