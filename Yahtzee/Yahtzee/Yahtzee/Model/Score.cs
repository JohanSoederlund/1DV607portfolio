﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Model
{
    class Score
    {

        private int score;
        public Score()
        {
            UsedCategories = new bool[Enum.GetNames(typeof(Categorie)).Length];
            ScoreCard = new int[Enum.GetNames(typeof(Categorie)).Length];
            for (int i = 0; i < UsedCategories.Length; i++)
            {
                UsedCategories[i] = false;
                ScoreCard[i] = 0;
            }
        }

        public int[] ScoreCard { get; private set; }

        public bool[] UsedCategories { get; private set; }


    }
}


/*
 * 
 * public int Twos { get; private set; }

        public int Threes { get; private set; }

        public int Fours { get; private set; }

        public int Fives{ get; private set; }

        public int Sixes{ get; private set; }

        public int ThreeOfAKind { get; private set; }

        public int ThreOfAKind { get; private set; }

        public int ThreOfAKind { get; private set; }

        public int ThreOfAKind { get; private set; }

        public int ThreOfAKind { get; private set; }

        public int ThreOfAKind { get; private set; }

        public int ThreOfAKind { get; private set; }
*/