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
        static public double MaxGainStep { get; } = 0.1;
        static public double RecommendedStep { get; } = 0.01;
        static public double MaxOutputStream { get; } = 1;
        static public double Delay { get; } = 2;
        static public double TForValve { get; } = 0.5;
        static public double Interference { get; } = 0.06;
        static public double DefaultKd { get; } = 0;
        static public double DefaultK { get; } = 1;
        static public double DefaultKi { get; } = 0.1;
    }
}
