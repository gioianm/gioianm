using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrilliantApplication.ControlSystems;
using BlocksLibrary.Blocks;

namespace BrilliantApplication.Regulators
{
    public class PIDRegulator
    {
        private GainBlock m_gainBlock;
        private RegIntegralBlock m_integralBlock;
        private DifferentialBlock m_diffBlock;
        private double m_regulatorTask = 0;

        public double Ki { get; set; }
        public double K { get { return m_gainBlock.Gain; } set { m_gainBlock.Gain = value; } }
        public double Ti { get { return 1 / Ki; } set { Ki = 1 / value; } }
        public double Kd { get; set; }

        public PIDRegulator(double dt, double K = 0, double Ki=0 , double Kd =0)
        {
            m_gainBlock = new GainBlock(K);
            m_integralBlock = new RegIntegralBlock(dt);
            m_diffBlock = new DifferentialBlock(dt);

            this.K = K;
            this.Ki = Ki;
            this.Kd = Kd;
        }

        public void RewriteConfig(double []P)
        {
            this.K = P[0];
            this.Ki = P[1];
            this.Kd = P[2];
        }
        public double[] GetConfig()
        {
            //return new double[] { Kp, Ti, Td };
            double[] ret = new double[3];
            ret[0] = K;
            ret[1] = Ki;
            ret[2] = Kd;
            return ret;
        }

        public double RegulatorTask
        {
            get { return m_regulatorTask; }
            set
            {
                if (value > SystemSettings.WaterLevelLimit)
                {
                    m_regulatorTask = SystemSettings.WaterLevelLimit;
                }
                else if (value < 0)
                {
                    m_regulatorTask = 0;
                }
                else
                {
                    m_regulatorTask = value-1;
                }
            }
        }

        public void RecalculationForShocklessMode(double u, double e)
        {
            m_integralBlock.RecalculationForShocklessMode(u, e, K, Ti, Kd);
        }

        public double Regulate(double x)
        {
            return m_gainBlock.Calculate(K*x + Ki * m_integralBlock.Calculate(x) + Kd * m_diffBlock.Calculate(x));
        }
    }
}
