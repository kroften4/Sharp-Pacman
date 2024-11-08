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

        public override GameState Update(GameState gameState, Queue<ConsoleKey> keyQueue)
        {
            Vector2D playerPos = gameState.Player.position;
            if (playerPos.x == position.x && playerPos.y == position.y)
                return new GameState(GameStatus.Lost, gameState.actors);
            return gameState;
        }
    }
}
