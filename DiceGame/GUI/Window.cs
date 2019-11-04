using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame.GUI
{
    class Window : GuiObject
    {
        private char _frameChar;
        Frame frame;
        public Window (int x, int y, int width, int height, char frameChar):base(x, y, width, height)
        {
            _frameChar = frameChar;
            frame = new Frame(x, y, width, height, frameChar);
        }
        public override void Render()
        {
            frame.Render();
        }
    }
}
