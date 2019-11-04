using System;
using System.Collections.Generic;
using System.Text;
using DiceGame.GUI;
using DiceGame.Play;
using DiceGame.Enums;

namespace DiceGame.Controls
{
    class GameController
    {
        private int winnersCount = 0;
        private Scenes _scene;
        private int playersCount;
        private int diceSides;
        private int diceCount;

        public void Start()
        {
            _scene = Scenes.PlayerCountSelection;
            LoadScene(_scene);
        }

        public void LoadScene(Scenes scene)
        {
            switch (scene)
            {
                case Scenes.PlayerCountSelection:
                    {
                        PlayerCountSelection mainMenu = new PlayerCountSelection(0, 0, 45, 35, '#');
                        playersCount = mainMenu.Start() + 2;
                        LoadScene(Scenes.DiceSelection);
                        break;
                    }
                case Scenes.DiceSelection:
                    {
                        DiceSelection diceSelection = new DiceSelection(0, 0, 45, 35, '#');
                        diceSides = diceSelection.Start();
                        LoadScene(Scenes.DiceCountSelection);
                        break;
                    }
                case Scenes.DiceCountSelection:
                    {
                        DiceCountSelection diceCountSelection = new DiceCountSelection(0, 0, 45, 35, '#');
                        diceCount = diceCountSelection.Start();
                        LoadScene(Scenes.Play);
                        break;
                    }
                case Scenes.Play:
                    {
                        Dice typeOfDie = new Dice(diceSides);
                        Battle battle = new Battle(playersCount, typeOfDie, diceCount);
                        winnersCount = battle.Roll();
                        if (winnersCount>1)
                        {
                            playersCount = winnersCount;
                            LoadScene(Scenes.DiceSelection);
                        }
                        else
                        {
                            LoadScene(Scenes.PlayerCountSelection);
                        }                        
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unknow Scene");
                        break;
                    }

            }
        }
    }
}
