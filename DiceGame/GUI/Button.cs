using System;
using System.Collections.Generic;
using System.Text;
using DiceGame.Events;

namespace DiceGame.GUI
{
    class Button : GuiObject
    {
        private bool isActive = false;
        private char activeFrameChar = '+';
        private char inactiveFrameChar = '-';
        private char _frameChar;
        private string _textLine;
        private int _value;

        public event OnButtonEvent OnPick;

        public int Value { get => _value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public string TextLine { get => _textLine; set => _textLine = value; }

        public Button (int x, int y, int width, int height, string textLine, int value):base(x, y, width, height)
        {
            TextLine = textLine;
            _value = value;
        }

        public void SetFrameChar()
        {
            if (IsActive)
            {
                _frameChar = activeFrameChar;
            }
            else
            {
                _frameChar = inactiveFrameChar;
            }
        }

        private void RenderTextLine()
        {
            Console.SetCursorPosition(X + Width / 2, Y + Height / 2);
            Console.Write(TextLine);
        }

        public override void Render()
        {
            SetFrameChar();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i == 0 || i == Height - 1)
                    {
                        Console.SetCursorPosition(j + X, i + Y);
                        Console.Write(_frameChar);
                    }
                    else if (j == 0 || j == Width - 1)
                    {
                        Console.SetCursorPosition(j + X, i + Y);
                        Console.Write(_frameChar);
                    }
                    else
                    {
                        Console.SetCursorPosition(j + X, i + Y);
                        Console.Write(" ");
                    }
                }
            }
            RenderTextLine();
        }
    }
}
