using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame.Play
{
    class Dice
    {
        private int diceSides;
        int[] rolls;
        private Random rnd = new Random();
        private int _sum = 0;
        
        public Dice (int sides)
        {
            diceSides = sides;
        }

        public int Roll()
        {
            return rnd.Next(1, diceSides + 1);
        }

        public int[] Roll(int count)
        {
            rolls = new int[count];
            for (int i = 0; i < count; i++)
            {
                rolls[i] = rnd.Next(1, diceSides + 1);
            }
            return rolls;
        }

        public int Sum()
        {
            foreach(int number in rolls)
            {
                _sum += number;
            }
            return _sum;
        }

        public void ResetSum()
        {
            _sum = 0;
        }
    }
}
