using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlocksLibrary.Blocks;

namespace BrilliantApplication
{
    public class ObjectControlSystem
    {
        public ComplexBlock Object { get; set; }
        public double Time { get; set; } = 0;
        public double DT { get; set; } = 0;
    }
}
