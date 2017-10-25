using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.Model;

namespace Yahtzee.View
{
    class RoundView
    {

        public void RenderRound(string name, int roundNumber)
        {
            Console.WriteLine("\nRound number " + roundNumber);
            Console.WriteLine(name + " time to play!");
        }
        public void RenderDie(CollectionOfDice collectionOfDice)
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

        public void RenderDieToRoll(bool[] dieToRoll, string decision)
        {
            Console.Write("\n" + decision + " - Decided to reroll: ");
            for (int i = 0;i < dieToRoll.Length; i++)
            {
                if(dieToRoll[i])
                {
                    Console.Write(i+1 + " ");
                }
            }
            Console.WriteLine("");
        }

        public bool[] GetDieToRoll()
        {
            bool[] dieToRoll = { };
            bool getInput = true;
            while (getInput)
            {
                dieToRoll = new bool[] { false, false, false, false, false };
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
                        dieToRoll[index - 1] = true;
                    }
                    else
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
            while (true)
            {
                Console.WriteLine(output);
                if (Int32.TryParse(Console.ReadLine(), out int value) && value >= 0 && value < enumLength)
                {
                    return (Categorie)value;
                }
                Console.WriteLine("Invalid input");
            }
        }

        public void RenderRoundScore(int roundScore, int usedCategorie)
        {
            Console.WriteLine("Recieved " + roundScore + " points for categorie " + CategorieModel.GetName(usedCategorie));
        }
    }
}
