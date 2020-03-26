using System;
using System.Collections.Generic;
using System.Text;

using BlocksLibrary.Interfaces;

namespace BlocksLibrary.Blocks
{
    public class InterferenceBlock : IBlock
    {
        private double m_interferencePercentage;

        public InterferenceBlock(double interferencePercentage)
        {
            m_interferencePercentage = interferencePercentage;
        }

        public double Calculate(double input)
        {
            var randomizer = new Random();

            return input + ((randomizer.NextDouble() - randomizer.NextDouble()) * input) * m_interferencePercentage;
        }
    }
}
