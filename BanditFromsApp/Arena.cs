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
            Agent greedy = new Agent(0, banditCount);
            Agent risker = new Agent(0.2,banditCount);
            greedy.Initiate();
            risker.Initiate();
            for (int i = 0; i < banditCount; i++)
            {
                greedy.MemoryUpdate(i, games[i].Play());
                risker.MemoryUpdate(i, games[i].Play());

            }

            for (int i = banditCount; i < itr; i++)
            {
                greedy.MemoryUpdate(greedy.Decide(), games[greedy.Decide()].Play());
                risker.MemoryUpdate(risker.Decide(), games[risker.Decide()].Play());
            }
        }

        public Arena(int n)
        {
            banditCount = n;
        }
    }
}
