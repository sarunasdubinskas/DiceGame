using System;
using System.Collections.Generic;
using System.Text;
using DiceGame.Controls;
using DiceGame.Enums;

namespace DiceGame.GUI
{
    class DiceSelection : Window
    {
        List<Button> buttons = new List<Button>();
        private bool isPicking = true;
        private int activeButton;
        private int lastActiveButton;
        private string title = "Select dice type";
        public DiceSelection(int x, int y, int width, int height, char frameChar) : base(x, y, width, height, frameChar)
        {
            Button d4 = new Button(4, 5, 15, 5, "d4",(int)Dices.d4);
            Button d6 = new Button(25, 5, 15, 5, "d6", (int)Dices.d6);
            Button d8 = new Button(4, 15, 15, 5, "d8", (int)Dices.d8);
            Button d10 = new Button(25, 15, 15, 5, "d10", (int)Dices.d10);
            Button d12 = new Button(4, 25, 15, 5, "d12", (int)Dices.d12);
            Button d20 = new Button(25, 25, 15, 5, "d20", (int)Dices.d20);

            activeButton = 0;
            lastActiveButton = 0;

            buttons.Add(d4);
            buttons.Add(d6);
            buttons.Add(d8);
            buttons.Add(d10);
            buttons.Add(d12);
            buttons.Add(d20);

            buttons[activeButton].IsActive = true;

        }

        public int Start()
        {
            Render();
            foreach (Button button in buttons)
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
                            if (activeButton - 1 >= 0)
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
                            if (activeButton + 1 <= buttons.Count - 1)
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
                            if (activeButton + 2 <= buttons.Count - 1)
                            {
                                SetInactive();
                                activeButton += 2;
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
                                activeButton -= 2;
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
            return buttons[activeButton].Value;
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
