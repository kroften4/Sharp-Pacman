using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Wall : Actor
    {
        public override char Character => '#';
        public override ConsoleColor Color => ConsoleColor.Blue;
        public Wall(Vector2D position) : base(position) { }
    }
}
