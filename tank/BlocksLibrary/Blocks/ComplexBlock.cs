using System;
using System.Collections.Generic;
using System.Text;

using BlocksLibrary.Interfaces;

namespace BlocksLibrary.Blocks
{
    public class ComplexBlock
    {
        public Queue<IBlock> Blocks { get; set; }

        public ComplexBlock()
        {
            Blocks = new Queue<IBlock>();
        }

        public ComplexBlock(Queue<IBlock> blocks)
        {
            Blocks = blocks;
        }

        public virtual double Calculate(double input)
        {
            var result = input;

            if (Blocks == null)
            {
                throw new Exception("Null reference in ComplexBlock.");
            }

            foreach(var block in Blocks)
            {
                result = block.Calculate(result);
            }
            return result;
        }

        public void AddBlock(IBlock block)
        {
            Blocks.Enqueue(block);
        }
    }
}
