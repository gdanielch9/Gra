using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akademia5Gra.Creatures
{
    public class Thief : Creature
    {
        public Thief(int xLimit, int yLimit) 
            : base(xLimit, yLimit, 'T', ConsoleColor.Yellow)
        {
            _power /= 2;
        }

        public override int Attack()
        {
            double probabilityForImmediateKill = 0.2;

            if (_rnd.NextDouble() < probabilityForImmediateKill)
            {
                return StabInTheBack();
            }
            else
            {
                return _power;
            }
        }

        private int StabInTheBack()
        {
            return Int32.MaxValue;
        }
    }
}
