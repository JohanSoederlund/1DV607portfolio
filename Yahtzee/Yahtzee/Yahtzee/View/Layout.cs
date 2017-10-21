using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Yahtzee.Model;

namespace Yahtzee.View
{
    class Layout
    {
        //private bool restart = false;
        private readonly string mainMenu = "Welcome to Yahtzee! \nThe rules are ... \n";
        public Layout()
        {
            Restart = false;
            Console.WriteLine(mainMenu);
        }

        public bool Restart { get; private set; }

        public int NumberOfPlayers()
        {
            Console.WriteLine("How many players (1-5): ");
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int value) && value <= 5 && value >= 1)
                {
                    return value;
                }
                Console.WriteLine("Invalid input value, you need to give a value between 1 and 5.");
            }
        }

        public bool RenderRound(string name)
        {
            Console.WriteLine("Hello " + name + ", new round!\nRoll die enter (Y):");
            return Console.ReadLine().Equals("Y");
        }

        public void RenderScore(Score score)
        {

        }

        public void RenderTotalScore()
        {

        }

        public void RenderRoll(CollectionOfDice collectionOfDice)
        {
            string idAndValueOutput = "";
            if (collectionOfDice.Die == null)
            {
                throw new Exception("No die-list");
            }
            foreach (Dice dice in collectionOfDice.Die)
            {
                idAndValueOutput += "Dice number: " + dice.Id + "     Value: " + dice.Value + "\n";
            }
            Console.WriteLine(idAndValueOutput);
        }

    }
}
