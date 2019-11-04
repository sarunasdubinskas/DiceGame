using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame.Enums
{
    //susiaurintas ConsoleKey enumeratorius
    enum Navigation
    {
        Left = ConsoleKey.LeftArrow,
        Right = ConsoleKey.RightArrow,
        Up = ConsoleKey.UpArrow,
        Down = ConsoleKey.DownArrow,
        Enter = ConsoleKey.Enter,
        NumPadPlus = ConsoleKey.Add,
        NumPadMinus = ConsoleKey.Subtract,
        R = ConsoleKey.R,
        Q = ConsoleKey.Q
    }
}
