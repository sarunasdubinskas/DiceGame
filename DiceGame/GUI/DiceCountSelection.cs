using System;
using System.Collections.Generic;
using System.Text;
using DiceGame.Controls;
using DiceGame.Enums;

namespace DiceGame.GUI
{
    class DiceCountSelection : Window
    {
        Button button;
        private bool isPicking = true;
        private int diceCount = 1;
        private string title1 = "Select how many dices will be rolled";
        private string title2 = "Use '-' or '+' to select";
        public DiceCountSelection(int x, int y, int width, int height, char frameChar) : base(x, y, width, height, frameChar)
        {
            button = new Button(15, 10, 15, 5, Convert.ToString(diceCount), diceCount);                       
        }

        public int Start()
        {
            Render();
            button.Render();
            Menu();
            return diceCount;
        }
        public override void Render()
        {
            base.Render();
            Console.SetCursorPosition(Width / 2 - title1.Length / 2, Y + 2);
            Console.WriteLine(title1);
            Console.SetCursorPosition(Width / 2 - title2.Length / 2, Y + 4);
            Console.WriteLine(title2);
        }

        private void Menu()
        {
            while (isPicking)
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case (ConsoleKey)Navigation.NumPadPlus:
                        {
                            diceCount++;
                            button.TextLine = Convert.ToString(diceCount);
                            button.Render();
                            break;
                        }
                    case (ConsoleKey)Navigation.NumPadMinus:
                        {
                            if (diceCount-1 >=1)
                            {
                                diceCount--;
                                button.TextLine = Convert.ToString(diceCount);
                                button.Render();
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case (ConsoleKey)Navigation.Enter:
                        {
                            isPicking = false;
                            break;

                        }
                }
            }
        }
    }
}
