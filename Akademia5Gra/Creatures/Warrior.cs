using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akademia5Gra.Creatures
{
    public class Warrior : Creature
    {
        public Warrior(int xLimit, int yLimit) 
            : base(xLimit, yLimit, 'R', ConsoleColor.White)
        {
            _health += _health/10;
        }

        public override int Attack()
        {
            AdrenalineRush();
            return _power;
        }

        private void AdrenalineRush()
        {
            _power += 3;
        }
    }
}
