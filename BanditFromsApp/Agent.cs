using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BanditFromsApp
{
    class Agent
    {
        //agents risk factor between 0(risk averse) and 1(risk taker)
        private double riskFactor;
        public int gameCount;

        private double[] observedMean = new double[1];
        private int[] playCount = new int[1];

        

        public void Initiate()
        {
            Array.Resize(ref observedMean, gameCount);
            Array.Resize(ref playCount, gameCount);

        }


        public void MemoryUpdate(int banditNumber, double reward)
        {
            observedMean[banditNumber] = (observedMean[banditNumber] * playCount[banditNumber] + reward) / (playCount[banditNumber] + 1);
            playCount[banditNumber] += 1;
        }

        public int Decide()
        {
            if (riskFactor == 0) return ChooseBest();

            Random rng = new Random();
            double dice = rng.NextDouble();
            if (dice <= riskFactor)
            {
                return rng.Next(gameCount);
            }
            else
            {
                return ChooseBest();
            }


        }

        private int ChooseBest()
        {
            return Array.IndexOf(observedMean, observedMean.Max());
        }
        public Agent(int n)
        {
            gameCount = n;
            riskFactor = 0.1;

        }
        public Agent(double risk, int n)
        {
            gameCount = n;
            riskFactor = risk;

        }
    }
    
}
