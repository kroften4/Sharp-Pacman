using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal abstract class Actor
    {
        virtual public char Character { get => ' '; }
        virtual public ConsoleColor Color { get => ConsoleColor.White; }
        public Vector2D position;

        public Actor(Vector2D position)
        {
            this.position = position;
        }

        abstract public GameState Update(GameState gameState, Queue<ConsoleKey> keyQueue);
    }
}
