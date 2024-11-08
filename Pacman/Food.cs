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

        override public GameState Update(GameState gameState, Queue<ConsoleKey> keyQueue)
        {
            Vector2D playerPos = gameState.Player.position;
            if (playerPos.x == position.x && playerPos.y == position.y)
                return new GameState(gameState.status, gameState.actors.Removed(this));
            return gameState;
        }
    }
}
