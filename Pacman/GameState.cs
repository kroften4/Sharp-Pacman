using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public enum GameStatus
    {
        Playing,
        Won,
        Lost
    }
    internal class GameState
    {
        public GameStatus status;
        public Actors actors;
        public Player Player
        {
            get
            {
                return (Player)actors.list.Find(a => a is Player);
            }

            set
            {
                actors = actors.Removed(Player);
                actors.Add(value);
            }
        }
        public Actors Foods
        {
            get
            {
                return new Actors(actors.list.FindAll(a => a is Food));
            }
        }
        public Actors Walls
        {
            get
            {
                return new Actors(actors.list.FindAll(a => a is Wall));
            }
        }

        public GameState(GameStatus status, Actors actors) {
            this.status = status;
            this.actors = actors;
        }

        static public GameState Create(char[,] level)
        {
            Actors actors = new Actors();
            for (int x = 0; x < level.GetLength(0); x++)
            {
                for (int y = 0; y < level.GetLength(1); y++)
                {
                    Actor newActor = null;
                    Vector2D actorPos = new Vector2D(x, y);
                    switch (level[x, y])
                    {
                        case '#':
                            newActor = new Wall(actorPos);
                            break;
                        case '@':
                            newActor = new Player(actorPos);
                            break;
                        case '0':
                            newActor = new Food(actorPos);
                            break;
                        case 'M':
                            newActor = new Monster(actorPos);
                            break;
                        default:
                            break;
                    }
                    if (newActor != null)
                        actors.Add(newActor);
                }
            }
            return new GameState(GameStatus.Playing, actors);
        }

        public GameState Update(Queue<ConsoleKey> keyQueue)
        {
            GameState newState = actors.Update(this, keyQueue);
            if (newState.Foods.list.Count() == 0)
                newState.status = GameStatus.Won;
            return newState;
        }
    }
}
