using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Vector2D
    {
        public int x;
        public int y;

        public Vector2D(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
        public Vector2D() 
        {
            this.x = 0;
            this.y = 0;
        }
    }
}
