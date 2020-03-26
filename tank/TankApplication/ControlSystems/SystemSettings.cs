using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantApplication.ControlSystems
{
    public static class SystemSettings
    {
        static public double T { get; } = 60;
        static public double Gain1 { get; } = 1;
        static public double Gain2 { get; } = 1;
        static public double WaterLevelLimit { get; } = 10;
        static public double MaxInputStream { get; } = 1;
        static public double RecommendedStep { get; } = 0.01;
        static public double MaxOutputStream { get; } = 2;
        static public double Delay { get; } = 2;
        static public double Interference { get; } = 0.06;
    }
}
