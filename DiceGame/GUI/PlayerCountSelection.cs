using System;
using System.Collections.Generic;
using System.Text;
using DiceGame.Controls;
using DiceGame.Enums;

namespace DiceGame.GUI
{
    class PlayerCountSelection : Window
    {
        List<Button> buttons = new List<Button>();
        private bool isPicking = true;
        private int activeButton;
        private int lastActiveButton;
        private string title = "Select player count:";
        public PlayerCountSelection(int x, int y, int width, int height, char frameChar) : base(x, y, width, height, frameChar)
        {
            Button button1 = new Button(4, 5, 15, 5, "2P", 0);
            Button button2 = new Button(25, 5, 15, 5, "3P", 1);
            Button button3 = new Button(4, 15, 15, 5, "4P", 2);
            Button button4 = new Button(25, 15, 15, 5, "5P", 3);
            Button button5 = new Button(4, 25, 15, 5, "6P", 4);
            Button button6 = new Button(25, 25, 15, 5, "7P", 5);

            activeButton = 0;
            lastActiveButton = 0;

            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);

            buttons[activeButton].IsActive = true;
            
        }        

        public int Start()
        {
            Render();
            foreach(Button button in buttons)
            {
                button.Render();
            }
            return Menu();
        }
        public override void Render()
        {
            base.Render();
            Console.SetCursorPosition(Width / 2 - title.Length / 2, Y + 2);
            Console.WriteLine(title);
        }

        private int Menu()
        {
            while (isPicking)
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case (ConsoleKey)Navigation.Left:
                        {
                            if(activeButton-1>=0)
                            {
                                SetInactive();
                                activeButton--;
                                SetActive();
                            }
                            else
                            {
                                break;
                            }
                            break;
                        }
                    case (ConsoleKey)Navigation.Right:
                        {
                            if (activeButton + 1 <= buttons.Count-1)
                            {
                                SetInactive();
                                activeButton++;
                                SetActive();
                            }
                            else
                            {
                                break;
                            }
                            break;
                        }
                    case (ConsoleKey)Navigation.Down:
                        {
                            if (activeButton + 2 <= buttons.Count-1)
                            {
                                SetInactive();
                                activeButton+=2;
                                SetActive();
                            }
                            else
                            {
                                break;
                            }
                            break;
                        }
                    case (ConsoleKey)Navigation.Up:
                        {
                            if (activeButton - 2 >= 0)
                            {
                                SetInactive();
                                activeButton-=2;
                                SetActive();
                            }
                            else
                            {
                                break;
                            }
                            break;
                        }
                    case (ConsoleKey)Navigation.Enter:
                        {
                            isPicking = false;
                            break;
                        }
                }
            }
            return activeButton;
        }

        private void SetActive()
        {
            buttons[activeButton].IsActive = true;
            buttons[activeButton].Render();
        }

        private void SetInactive()
        {
            lastActiveButton = activeButton;
            buttons[lastActiveButton].IsActive = false;
            buttons[lastActiveButton].Render();
        }
    }
}
