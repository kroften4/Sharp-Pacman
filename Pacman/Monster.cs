using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Monster: Actor {
        public Direction direction;
        public override char Character => 'M';
        public override ConsoleColor Color => ConsoleColor.Magenta;
        public Monster(Vector2D position) : base(position) { }
        public Monster(Vector2D position, Direction direction) : base(position)
        {
            this.direction = direction;
        }

        public Direction? ChooseDirection(GameState gameState)
        {
            // TODO: fix shitty code, add an option to select algorythm
            List<Direction> allDirections = new List<Direction> { 
                Direction.Right, Direction.Left, Direction.Up, Direction.Down 
            };
            List<Direction> availableDirections = new List<Direction> { 
                Direction.Right, Direction.Left, Direction.Up, Direction.Down 
            };
            foreach (Direction possibleDirection in allDirections)
            {
                Monster newMonster = Turn(possibleDirection).Move();
                if (gameState.Walls.HasActorAt(newMonster.position))
                    availableDirections.Remove(possibleDirection);
            }

            int minDistX = int.MaxValue;
            int minDistY = int.MaxValue;
            Direction? chosenDirectionY = null;
            Direction? chosenDirectionX = null;
            foreach (Direction possibleDirection in availableDirections)
            {
                Vector2D newPos = Turn(possibleDirection).Move().position;
                Vector2D playerPos = gameState.Player.position;
                switch (possibleDirection)
                {
                    case Direction.Left:
                    case Direction.Right:
                        int newDistX = Math.Abs(newPos.x - playerPos.x);
                        if (newDistX < minDistX)
                        {
                            chosenDirectionX = possibleDirection;
                            minDistX = newDistX;
                        }
                        break;
                    case Direction.Up:
                    case Direction.Down:
                        int newDistY = Math.Abs(newPos.y - playerPos.y);
                        if (newDistY < minDistY)
                        {
                            chosenDirectionY = possibleDirection;
                            minDistY = newDistY;
                        }
                        break;
                    default:
                        break;
                }
            }
            Random r = new Random();
            Direction?[] variants = { chosenDirectionX, chosenDirectionY };
            return variants[r.Next(0, variants.Length)];
        }
        public Monster Turn(Direction direction)
        {
            return new Monster(position, direction);
        }
        public Monster Move()
        {
            Vector2D newPos = new Vector2D(position.x, position.y);
            switch (direction)
            {
                case Direction.Left:
                    newPos.x -= 1;
                    break;
                case Direction.Right:
                    newPos.x += 1;
                    break;
                case Direction.Up:
                    newPos.y -= 1;
                    break;
                case Direction.Down:
                    newPos.y += 1;
                    break;
            }
            return new Monster(newPos, direction);
        }

        public override GameState Update(GameState gameState, Queue<ConsoleKey> keyQueue)
        {
            Vector2D playerPos = gameState.Player.position;
            if (playerPos.x == position.x && playerPos.y == position.y)
                return new GameState(GameStatus.Lost, gameState.actors);
            Direction? newDirection = ChooseDirection(gameState);
            Monster newMonster = this;
            if (newDirection is Direction)
                newMonster = Turn(newDirection.Value).Move();
            GameState newState = new GameState(gameState.status, gameState.actors.Removed(this));
            newState.actors.Add(newMonster);
            return newState;
        }
    }
}
