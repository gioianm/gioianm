using System;
using System.Collections.Generic;
using System.Text;

using BlocksLibrary.Interfaces;

namespace BlocksLibrary.Blocks
{
    public class AperiodicBlock : IBlock, IRefreshable
    {
        private double m_prev = 0; 
        private double m_T;
        private double m_dt;
        
        public AperiodicBlock(double dt, double T)
        {
            m_dt = dt;
            m_T = T;
        }

        public virtual double Calculate(double input)
        {
            var output = (input * m_dt + m_T * m_prev) / (m_T + m_dt);
            m_prev = output;
            return output;
        }

        public void Refresh()
        {
            m_prev = 0;
        }
    }
}