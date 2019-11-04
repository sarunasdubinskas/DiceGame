using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame.Play
{
    class Player
    {
        private string _name;
        private int rolledDicesCount;

        public Player(string name)
        {
            _name = name;
        }
        public string Name { get => _name; set => _name = value; }
        public int RolledDicesCount { get => rolledDicesCount; set => rolledDicesCount = value; }


    }
}
