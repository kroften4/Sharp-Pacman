using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Food : Actor
    {
        public override char Character => '0';
        public override ConsoleColor Color => ConsoleColor.Red;
        public Food(Vector2D position) : base(position) { }

        override public Actor Update(GameState gameState)
        {
            Vector2D playerPos = gameState.player.position;
            if (playerPos.x == position.x && playerPos.y == position.y)
                // TODO: add points here (should provide access to game state somehow
                return null;
            return this;
        }
    }
}
