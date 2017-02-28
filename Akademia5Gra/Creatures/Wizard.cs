using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akademia5Gra.Creatures
{
    public class Wizard : Creature
    {
        public Wizard(int xLimit, int yLimit) 
            : base(xLimit, yLimit, 'W', ConsoleColor.Red)
        {
        }

        public override int Attack()                        // własna implementacja ataku (obowiązkowa)
        {
            MagicRegeneration();
            return _power;
        }

        private void MagicRegeneration()                    // własna metoda prywatna (klasy Warrior i Thief jej nie mają)
        {
            _health++;
        }

        public override void GetDamage(int damage)          // zmieniamy (przesłaniamy) metodę i dajemy jej własną implementacje 
        {
            double immortalProbability = 0.50;

            if (_rnd.NextDouble() < immortalProbability)
            {
                ActivateMagicalBarrier();
            }
            else
            {
                base.GetDamage(damage);                     // wywołujemy oryginalną metodę GetDamage z klasy Creature (czyli odejmujemy obrażenia od zdrowia)
            }
        }

        private void ActivateMagicalBarrier()
        {
        }
    }
}
