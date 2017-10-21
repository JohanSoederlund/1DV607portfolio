using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yahtzee.Model
{
    class CollectionOfDice
    {
        //private List<Dice> die;
        public CollectionOfDice()
        {
            Die = new List<Dice>();
            for (int i = 1; i < 6; i++)
            {
                Thread.Sleep(20);
                Die.Add(new Dice(i));
            }
        }

        public List<Dice> Die { get; private set; }


        public void Roll(bool[] dieToRoll)
        {
            foreach (Dice dice in Die)
            {
                if (dieToRoll[dice.Id-1])
                {
                    dice.Roll();
                }
            }
        }
        public int GetMaxNumberOfSameValues()
        {
            int[] dieValues = { 0, 0, 0, 0, 0, 0 };
            foreach (Dice dice in Die)
            {
                dieValues[dice.Value - 1]++;
            }
            // Return totsl value if at kleast three dice of same, else 0
            int highestNumberOfSame = 0;
            for (int i = 0; i < 6; i++)
            {
                if (dieValues[i] > highestNumberOfSame)
                    highestNumberOfSame = dieValues[i];
            }
            return highestNumberOfSame;
        }

        public int GetSum()
        {
            int sum = 0;
            foreach (Dice dice in Die)
            {
                sum += dice.Value;


            }
            return sum;
        }

        public int GetSumOfSame(int value)
        {
            int sum = 0;
            foreach (Dice dice in Die)
            {
                if (dice.Value == value)
                {
                    sum += dice.Value;
                }
            }
            return sum;
        }

    }
}
