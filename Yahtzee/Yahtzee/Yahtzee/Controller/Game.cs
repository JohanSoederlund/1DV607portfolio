using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yahtzee.Model;
using Yahtzee.View;

namespace Yahtzee.Controller
{
    class Game
    {
        private DataBase dataBase;
        private List<Player> players;
        private Rules rules;
        private CollectionOfDice collectionOfDice;

        private Layout layout;


        public Game()
        {
            
            InitGame();
            RunGame();
        }

        private bool[] DieToRoll { get; set; }

        private void InitGame()
        {
            dataBase = new DataBase();
            rules = new Rules();
            layout = new Layout();
            collectionOfDice = new CollectionOfDice();
            PlayerSetup();
        }

        private void PlayerSetup()
        {
            players = new List<Player>();
            int numberOfPlayers = layout.NumberOfPlayers();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player("Kalle"+i));
            }
        }

        private void RunGame()
        {
            foreach (Player player in players)
            {
                if (layout.RenderRound(player.Name))
                {
                    DieToRoll = new bool[] { true, true, true, true, true };

                    collectionOfDice.Roll(DieToRoll);
                    layout.RenderRoll(collectionOfDice);
                    DieToRoll = layout.GetDieToRoll();

                    collectionOfDice.Roll(DieToRoll);
                    layout.RenderRoll(collectionOfDice);
                    DieToRoll = layout.GetDieToRoll();

                    collectionOfDice.Roll(DieToRoll);
                    layout.RenderRoll(collectionOfDice);

                    Categorie categorieToUse = layout.RenderCategorie(player.Score.UsedCategories);
                    
                    if (categorieToUse == Categorie.ThreeOfAKind)
                    {
                        player.Score.ScoreCard[(int)categorieToUse] = rules.ThreeOfAKind(collectionOfDice);
                        player.Score.UsedCategories[(int)categorieToUse] = true;
                        //layout.RenderScore(player.Score.GetTotalScore());
                    }

                    

                }
            }

            dataBase.SaveToFile(players);
            players = dataBase.GetFromFile();

        }
    }
}


