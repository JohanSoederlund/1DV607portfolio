using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Model
{
    class Player
    {

        public Player(string name)
        {
            Name = name;
            Score = new Score();
        }

        public string Name { get; set; }

        public Score Score { get; private set; }
    }
}
