using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace BanditFromsApp
{
    class Bandit
    {
        public double banditMean;

        public double Play()
        {
            double a = Normal.Sample(banditMean, 1.0);
            return a;
        }


        public Bandit()
        {
            Random rng = new Random();
            banditMean = rng.NextDouble();

        }
        public Bandit(double mean)
        {
            banditMean = mean;
        }
    }
}
