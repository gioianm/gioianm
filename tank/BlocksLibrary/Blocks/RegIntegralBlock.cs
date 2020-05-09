using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksLibrary.Blocks
{
    public class RegIntegralBlock : IntegralBlock
    {
        public DifferentialBlock DiffBlock { get; set; }

        public RegIntegralBlock(double dt) : base(dt)
        {
            DiffBlock = new DifferentialBlock(dt);
        }

        public void RecalculationForShocklessMode(double u,
                                                  double e,
                                                  double K,
                                                  double Ti,
                                                  double Kd)
        {
            Prev = u;
            Sum = (u / K - (e + Kd * DiffBlock.Calculate(e))) * Ti;
        }
    }
}
