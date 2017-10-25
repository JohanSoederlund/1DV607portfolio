﻿using System;
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
            //todo: change 13 to const var 13var
            for (int i = 1; i <= CategorieModel.GetSize(); i++)
            {
                RunRound(i);
            }
        }

        private bool[] DieToRoll { get; set; }

        private void InitGame()
        {
            dataBase = new DataBase();
            collectionOfDice = new CollectionOfDice();
            rules = new Rules(collectionOfDice);
            layout = new Layout();
            PlayerSetup();
        }

        private void PlayerSetup()
        {
            bool robot;
            players = new List<Player>();
            int numberOfPlayers = layout.NumberOfPlayers();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                string name = layout.PlayerName(out robot);
                if (robot)
                {
                    players.Add(new Robot(GetNumberOfRobots(), rules));

                } else
                {
                    players.Add(new Player(name));
                }
                
            }
        }

        private int GetNumberOfRobots()
        {
            int numberOfRobots = 0;
            foreach(Player player in players)
            {
                if (player.IsRobot)
                {
                    numberOfRobots++;
                }
            }
            return numberOfRobots;
        }

        private void RunRound(int roundNumber)
        {
            foreach (Player player in players)
            {
                DieToRoll = new bool[] { true, true, true, true, true };
                if (player.IsRobot)
                {
                    RobotRound((Robot)player, roundNumber);
                } else
                {
                    PlayerRound(player, roundNumber);
                }

            }
            layout.RenderScoreBoard(players);
        }

        private void RobotRound(Robot robot, int roundNumber)
        {
            layout.RenderRound(robot.Name, roundNumber);
            collectionOfDice.Roll(DieToRoll);

            layout.RenderDie(collectionOfDice);
            Thread.Sleep(2000);
            DieToRoll = robot.DecideDiceToRoll(collectionOfDice.GetNumberOfDiceFaceValue(), collectionOfDice.GetDie());
            layout.RenderDieToRoll(DieToRoll, robot.Decision);
            Thread.Sleep(2000);
            collectionOfDice.Roll(DieToRoll);

            layout.RenderDie(collectionOfDice);
            Thread.Sleep(2000);
            DieToRoll = robot.DecideDiceToRoll(collectionOfDice.GetNumberOfDiceFaceValue(), collectionOfDice.GetDie());
            layout.RenderDieToRoll(DieToRoll, robot.Decision);
            Thread.Sleep(2000);
            collectionOfDice.Roll(DieToRoll);
            layout.RenderDie(collectionOfDice);

            int usedCategorie = robot.CalcBestValue();
            int roundScore = robot.Score.ScoreCard[usedCategorie];
            layout.RenderRoundScore(roundScore, usedCategorie);
            Thread.Sleep(2000);
        }

        private void PlayerRound(Player player, int roundNumber)
        {
            layout.RenderRound(player.Name, roundNumber);
            collectionOfDice.Roll(DieToRoll);

            layout.RenderDie(collectionOfDice);
            DieToRoll = layout.GetDieToRoll();
            collectionOfDice.Roll(DieToRoll);

            layout.RenderDie(collectionOfDice);
            DieToRoll = layout.GetDieToRoll();
            collectionOfDice.Roll(DieToRoll);

            Categorie categorieToUse = layout.RenderCategorie(player.Score.UsedCategories);

            if (categorieToUse == Categorie.ThreeOfAKind)
            {
                player.Score.ScoreCard[(int)categorieToUse] = rules.ThreeOfAKind();
                player.Score.UsedCategories[(int)categorieToUse] = true;
            }
        }


    }



    //dataBase.SaveToFile(players);
    //players = dataBase.GetFromFile();

}


