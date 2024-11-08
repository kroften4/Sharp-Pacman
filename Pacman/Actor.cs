using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Actor
    {
        virtual public Char Character { get => ' '; }
        virtual public ConsoleColor Color { get => ConsoleColor.White; }
        public Vector2D position;


        public Actor()
        {
            this.position = new Vector2D();
        }
        public Actor(Vector2D position)
        {
            this.position = position;
        }

        virtual public Actor Update(GameState gameState)
        {
            return this;
        }
    }
}
