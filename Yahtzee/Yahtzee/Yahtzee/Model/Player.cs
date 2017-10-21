using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Model
{
    class Player
    {
        public Player()
        {
            Score = new Score();
        }
        public Player(string name)
        {
            Name = name;
            Score = new Score();
        }

        public Player(string name, int[] scores, bool[] usedCategories)
        {
            Name = name;
            Score = new Score(scores, usedCategories);
        }

        public string Name { get; set; }

        public Score Score { get; private set; }
    }
}
