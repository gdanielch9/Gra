using System;
using System.Collections.Generic;
using System.Linq;
using Akademia5Gra.Creatures;

namespace Akademia5Gra
{
    public class World
    {
        private Random _rnd;                                        // Random - klasa do losowania liczb
        private int _windowsHeight;
        private int _windowsWidth;
        private List<Creature> _creatureList;

        public World(int windowsHeight = 20, int windowsWidth = 40) // parametry domyślne, jeśli nie prześlemy parametrów do funkcji to będą one miały takie wartości. Jeśli prześlemy to wartości te się zmienią
        {
            _rnd = new Random();
            Console.WindowHeight = windowsHeight;
            Console.WindowWidth = windowsWidth;
            _windowsHeight = windowsHeight - 1;
            _windowsWidth = windowsWidth;
            CreateCreatureList();
        }

        private void CreateCreatureList()
        {
            _creatureList = new List<Creature>();
            int amountOfCreatures = _windowsHeight*_windowsWidth*15/100;

            for (int i = 0; i < amountOfCreatures / 3; i++)         // całe piękno dziedziczenia, czyli do listy zawierającej obiekty klasy Creature dodajemy obiekty klas dziedziczących po Creature
            {                                                       // ma to sens, ponieważ klasy te muszą zawierać to samo wnętrze co Creature, a są jeszcze dodatkowo wzbogacone
                _creatureList.Add(new Thief(_windowsWidth,_windowsHeight));
                _creatureList.Add(new Wizard(_windowsWidth,_windowsHeight));
                _creatureList.Add(new Warrior(_windowsWidth,_windowsHeight)); 
            }
            
            foreach (var creature in _creatureList)
            {
                RandAndSetCoordinates(creature);
            }
        }

        private void RandAndSetCoordinates(Creature creature)
        {
            int coordX, coordY;

            do
            {
                coordX = _rnd.Next(0, _windowsWidth);
                coordY = _rnd.Next(0, _windowsHeight);
            } while (_creatureList.Exists(x => x.XCoordinate == coordX && x.YCoordinate == coordY));    // przerażające LINQ, sprawdzamy, czy w liście istnieje elementy o zadanych wspórzędnych

            creature.XCoordinate = coordX;
            creature.YCoordinate = coordY;
        }

        public void RunWorld()
        {
            WriteWorldToConsole();

            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                EditWorld();
            }
        }

        private void EditWorld()
        {
            foreach (var creature in _creatureList)
            {
                creature.Move();
                FightIfConflict(creature);
            }

            RemoveDeadCreatures();
            WriteWorldToConsole();
        }

        private void RemoveDeadCreatures()
        {
            var deadCollection = _creatureList.Where(x => x.IsAlive() == false).ToList();   // tworzymy nową listę 

            foreach (var deadCreature in deadCollection)
            {
                _creatureList.Remove(deadCreature);
            }
        }

        private void FightIfConflict(Creature creature)
        {
            var creatureToFight = _creatureList.FirstOrDefault(x => creature.XCoordinate == x.XCoordinate
                                                                    && creature.YCoordinate == x.YCoordinate
                                                                    && x.GetType() != creature.GetType()
                                                                    && x.IsAlive());
            if (creatureToFight != null)
            {
                Fight(creature,creatureToFight);
            }
        }

        private void Fight(Creature creature, Creature creatureToFight)
        {
            while (creature.IsAlive() && creatureToFight.IsAlive())
            {
                creatureToFight.GetDamage(creature.Attack());
                creature.GetDamage(creatureToFight.Attack());
            }
        }

        private void WriteWorldToConsole()
        {
            foreach (var creature in _creatureList)
            {
                WriteCreatureToConsole(creature);
            }

            WriteStatsToConsole();

        }

        private void WriteStatsToConsole()
        {
            Console.CursorTop = Console.WindowHeight;                   // ustawienie kursora na dolną linię
            Console.CursorLeft = 1;
            Console.ForegroundColor = ConsoleColor.White;
            
            int wizardCount = _creatureList.Count(w => w.Symbol == 'W');            // to jest to samo co to niżej
            int warriorCount = _creatureList.Where(r => r.Symbol == 'R').Count();   // wybierz elementy z listy, których symbolem jest 'R' następnie je policz
            int thiefCount = _creatureList.Where(t => t.Symbol == 'T').Count();

            Console.Write($"W: {wizardCount}, R: {warriorCount}, T: " + thiefCount);}

        private void WriteCreatureToConsole(Creature creature)
        {
            Console.CursorTop = creature.YCoordinate;
            Console.CursorLeft = creature.XCoordinate;
            Console.ForegroundColor = creature.Color;
            Console.Write(creature.Symbol);
        }
    }
}
