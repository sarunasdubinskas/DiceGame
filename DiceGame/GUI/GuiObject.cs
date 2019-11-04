using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame.GUI
{
    abstract class GuiObject
    {
        private int _x;
        private int _y;
        private int _width;
        private int _height;

        public GuiObject(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public abstract void Render();
    }
}
