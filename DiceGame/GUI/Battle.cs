using System;
using System.Collections.Generic;
using System.Text;
using DiceGame.Play;
using DiceGame.Enums;

namespace DiceGame.GUI
{
    class Battle
    {
        private List<Player> players = new List<Player>();
        private List<Player> winners = new List<Player>();
        private Player player;
        private Dice die;
        private int rolls;
        private int maxRoll = 0;
        private bool needToReroll = false;
        private bool isPicking = true;
        public Battle(int playerCount, Dice typeOfDie, int countOfDices)
        {
            Console.Clear();
            for (int i = 0; i < playerCount; i++)
            {
                player = new Player("Player " + (i + 1));
                players.Add(player);
            }

            rolls = countOfDices;

            die = typeOfDie;
            
        }

        public int Roll()
        {
            foreach(Player gamer in players)
            {
                die.Roll(rolls);
                gamer.RolledDicesCount = die.Sum();
                Console.WriteLine(gamer.Name + " rolled: " + gamer.RolledDicesCount);
                CheckIfSameCountOfScore(gamer);
                die.ResetSum();
            }
            PickWinners();
            AnnounceWinners();
            return winners.Count;
        }

        private void AnnounceWinners()
        {
            Console.WriteLine("Winners:");
            foreach(Player player in winners)
            {
                Console.WriteLine(player.Name);
            }
            if (winners.Count>1)
            {
                Console.WriteLine("Need to reroll. Press any key...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("To Replay press R" +
                    "\nTo Quit press Q");
                while (isPicking)
                {
                    ConsoleKeyInfo key;
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case (ConsoleKey)Navigation.R:
                            {
                                isPicking = false;
                                break;
                            }
                        case (ConsoleKey)Navigation.Q:
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            { break; }
                    }
                }
            }
        }

        private void PickWinners()
        {
            winners = players;
            winners.RemoveAll(player => player.RolledDicesCount < maxRoll);
        }

        private void CheckIfSameCountOfScore(Player gamer)
        {
            if (maxRoll < gamer.RolledDicesCount)
            {
                needToReroll = false;
                maxRoll = gamer.RolledDicesCount;
            }
            else if (maxRoll == gamer.RolledDicesCount)
            {
                needToReroll = true;
            }
        }
    }
}
