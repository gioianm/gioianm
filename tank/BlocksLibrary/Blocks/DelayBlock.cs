using System;
using System.Collections.Generic;
using System.Text;

using BlocksLibrary.Interfaces;

namespace BlocksLibrary.Blocks
{
    public class DelayBlock : IBlock
    {
        private Queue<double> m_inputValuesQue;
        private long m_capacity;

        public DelayBlock(double dt, double delayTime)
        {
            m_capacity = Convert.ToInt64(delayTime / dt);
            m_inputValuesQue = new Queue<double>();
        }

        public double Calculate(double input)
        {
            m_inputValuesQue.Enqueue(input);

            if (m_inputValuesQue.Count == m_capacity + 1)
            {
                return m_inputValuesQue.Dequeue();
            }

            return 0;
        }
    }
}
