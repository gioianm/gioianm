using System;
using System.Collections.Generic;
using System.Text;

using BlocksLibrary.Interfaces;

namespace BlocksLibrary.Blocks
{
    public class GainBlock : IBlock
    {
        public double Gain { get; set; }
        public GainBlock(double gain)
        {
            Gain = gain;
        }

        public virtual double Calculate(double input)
        { 
            return input * Gain;
        }
    }
}