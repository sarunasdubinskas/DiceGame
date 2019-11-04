using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame.GUI
{
    class Frame : GuiObject
    {
        private char _frameChar;
        public Frame (int x, int y, int width, int height, char frameChar) : base (x, y, width, height)
        {
            _frameChar = frameChar;
        }
        public override void Render()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i==0||i==Height-1)
                    {
                        Console.SetCursorPosition(j+X, i+Y);
                        Console.Write(_frameChar);
                    }
                    else if (j==0||j==Width-1)
                    {
                        Console.SetCursorPosition(j+X, i+Y);
                        Console.Write(_frameChar);
                    }
                    else
                    {
                        Console.SetCursorPosition(j+X, i+Y);
                        Console.Write(" ");
                    }
                }
            }
        }
    }
}
