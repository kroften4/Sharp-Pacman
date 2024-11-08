using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Monster: Actor {
        public override char Character => 'M';
        public override ConsoleColor Color => ConsoleColor.Magenta;
        public Monster(Vector2D position) : base(position) { }
    }
}
