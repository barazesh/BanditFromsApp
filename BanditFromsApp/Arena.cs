using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanditFromsApp
{
    class Arena
    {
        private int banditCount;
        public Bandit[] games = new Bandit[1];
        public int[] selectHistory = new int[1];
        public double[] rewardHistory = new double[1];


        // initiation of the arena with the selected number of bandits
        private Random rnd = new Random();
        public void Initiate()
        {
            Array.Resize(ref games, banditCount);
            for (int i = 0; i < banditCount; i++)
            {
                games[i] = new Bandit(2 * rnd.NextDouble() - 1);
            }
        }

        public void RunGame(int itr)
        {
            Array.Resize(ref selectHistory, itr);
            Array.Resize(ref rewardHistory, itr);
            //Agent greedy = new Agent(0, banditCount);
            Agent risker = new Agent(0.2, banditCount);
            //greedy.Initiate();
            risker.Initiate();
            for (int i = 0; i < banditCount; i++)
            {
                selectHistory[i] = i;
                rewardHistory[i] = games[i].Play();
                risker.MemoryUpdate(i, rewardHistory[i]);
            }

            for (int i = banditCount; i < itr; i++)
            {
                //greedy.MemoryUpdate(greedy.Decide(), games[greedy.Decide()].Play());
                selectHistory[i] = risker.Decide();
                rewardHistory[i] = games[selectHistory[i]].Play();
                risker.MemoryUpdate(risker.Decide(), rewardHistory[i]);
            }
        }

        public Arena(int n)
        {
            banditCount = n;
        }
    }
}
