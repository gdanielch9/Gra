using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akademia5Gra.Creatures
{
    public abstract class Creature
    {
        public int XCoordinate { get; set; }                // ważna konwencja - to co publiczne jest propercją i jest pisane z dużej litery
        public int YCoordinate { get; set; }
        public readonly char Symbol;                        // no chyba, że ma modyfikator static to musi być polem
        public readonly ConsoleColor Color;                 // readonly, czyli zmienna jest tak naprawdę stałą. Wartość możemy do niej przypisać tylko w konstruktorze, potem jej już nie można zmienić
        protected int _health;                              // to co protected jest polem, z konwencją rozpoczynającą się znakiem _ i małą literą
        protected int _power;                               // protected, czyli widzialne w klasach dziedziczących, ale nie można się do tego odwołać spoza obiektu
        protected static Random _rnd = new Random();        // tu zaszło wiele wyjątków i ciężko to wytłumaczyć. Generalnie pole static jest współdzielone przez wszystkie obiekty tej klasy.
        private int _xLimit;                                // to co prywatne jest polem rozpoczynającym się znakiem _ i małą literą i WAŻNE
        private int _yLimit;

        protected Creature(int xLimit, int yLimit, char symbol, ConsoleColor color)
        {
            _health = 100;
            _power = 10;
            _xLimit = xLimit;
            _yLimit = yLimit;
            Symbol = symbol;
            Color = color;
        }

        public void Move()
        {
            MoveX();
            MoveY();
        }

        private void MoveY()
        {
            var rnd = _rnd.NextDouble();
            if (rnd < 0.50)
            {
                if (YCoordinate < _yLimit)
                {
                    YCoordinate++;
                }
            }
            else
            {
                if (YCoordinate > 1)
                {
                    YCoordinate--;
                }
            }
        }

        private void MoveX()
        {
            var rnd = _rnd.NextDouble();
            if (rnd < 0.50)
            {
                if (XCoordinate < _xLimit)
                {
                    XCoordinate++;
                }
            }
            else
            {
                if (XCoordinate > 1)
                {
                    XCoordinate--;
                }
            }
        }

        public abstract int Attack();                                   // to musi zaimplementować każdy obiekt dzidziczący osobno

        public virtual void GetDamage(int damage)                       // z tej metody może korzystać obiekt dziedziczący, ale może też ją też nadpisać (przesłonić)
        {
            _health -= damage;
        }

        public bool IsAlive()                                           // to będzie dostępne dla wszystkich klas dziedziczących i nie można tego nadpisać
        {
            if (_health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
