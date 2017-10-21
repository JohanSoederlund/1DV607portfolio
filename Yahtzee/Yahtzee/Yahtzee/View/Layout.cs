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
            //Console.WriteLine("Hello " + name + ", new round!\nRoll die enter (Y):");

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

        public bool[] GetDieToRoll()
        {
            bool[] dieToRoll = { };
            bool getInput = true;
            while (getInput)
            {
                dieToRoll = new bool[]{ false, false, false, false, false };
                Console.WriteLine("Select die to roll på entering the id numbers of your choosen die e.g.(1 2 3 5), or (0) to stand");
                string input = Console.ReadLine();
                string[] dieNumbers = input.Split(' ');
                getInput = false;
                //Check if player stand
                if (Int32.TryParse(dieNumbers[0], out int val) && val == 0)
                {
                    return dieToRoll;
                }
                for (int i = 0; i < dieNumbers.Length; i++)
                {
                    Console.WriteLine(dieNumbers[i]);
                    if (Int32.TryParse(dieNumbers[i], out int index) && index >= 1 && index <= 5)
                    {
                        dieToRoll[index-1] = true;
                    } else
                    {
                        Console.WriteLine("Invalid input");
                        getInput = true;
                        break;
                    }
                }
            }
            return dieToRoll;
        }

        public Categorie RenderCategorie(bool[] usedCategories)
        {
            int enumLength = Enum.GetNames(typeof(Categorie)).Length;
            string output = "Select number categorie from this list e.g.(3): \n";
            for (int i = 0; i < enumLength; i++)
            {
                output += "(" + i + ") " + Enum.GetName(typeof(Categorie), i) + "\n";
            }
            while(true)
            {
                Console.WriteLine(output);
                if (Int32.TryParse(Console.ReadLine(), out int value) && value >= 0 && value < enumLength)
                {
                    return (Categorie)value;
                }
                Console.WriteLine("Invalid input");
            }
        }

    }
}
