using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Model
{
    class Rules
    {
        //private int[] dieValues = { 0, 0, 0, 0, 0, 0 };
        public Rules()
        {
        }

        

        public int ThreeOfAKind(CollectionOfDice collectionOfDice)
        {
            
            if (collectionOfDice.GetMaxNumberOfSameValues() >= 3)
            {
                return collectionOfDice.GetSum();
            }
            return 0;
        }
    }
}
