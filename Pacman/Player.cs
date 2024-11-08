﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Player : Actor
    {
        public override char Character => '@';
        public override ConsoleColor Color => ConsoleColor.DarkYellow;
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }
        public Direction direction;

        public Player(Vector2D position): base(position)
        {
            this.position = position;
            this.direction = Direction.Up;
        }
        public Player(Vector2D position, Direction direction) : base(position)
        {
            this.position = position;
            this.direction = direction;
        }
        
        public Player Move()
        {
            Vector2D newPos = new Vector2D(this.position.x, this.position.y);
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
            return new Player(newPos, this.direction);
        }

        public Player Turn(Direction direction)
        {
            return new Player(this.position, direction);
        }

        public Player Update(GameState gameState, Queue<ConsoleKey> keyQueue)
        {
            Direction newDirection = this.direction;
            if (keyQueue.Count() != 0)
            {
                switch (keyQueue.Dequeue())
                {
                    case ConsoleKey.DownArrow:
                        newDirection = Direction.Down;
                        break;
                    case ConsoleKey.UpArrow:
                        newDirection = Direction.Up;
                        break;
                    case ConsoleKey.LeftArrow:
                        newDirection = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        newDirection = Direction.Right;
                        break;
                }
            }
            Player newPlayer = this.Turn(newDirection);
            newPlayer = newPlayer.Move();
            if (gameState.walls.Contains(newPlayer.position))
            {
                newPlayer = this.Move();
                if (gameState.walls.Contains(newPlayer.position))
                    newPlayer = this;
            }

            return newPlayer;
        }
    }
}