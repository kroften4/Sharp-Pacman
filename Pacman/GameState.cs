using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class GameState
    {
        public Player player;
        public Actors walls;
        public Actors foods;
        public Actors monsters;
        public List<Actor> actors
        {
            get {
                return new List<Actor>()
                    .Concat(walls.list).Concat(foods.list).Concat(monsters.list)
                    .Append(player).ToList();
            }
        }

        public GameState(Player player, Actors walls, Actors foods, Actors monsters) {
            this.player = player;
            this.walls = walls;
            this.foods = foods;
            this.monsters = monsters;
        }

        static public GameState Create(char[,] level)
        {
            Player player = new Player(new Vector2D());
            Actors walls = new Actors();
            Actors foods = new Actors();
            Actors monsters = new Actors();
            Vector2D position;
            for (int x = 0; x < level.GetLength(0); x++)
            {
                for (int y = 0; y < level.GetLength(1); y++)
                {
                    position = new Vector2D(x, y);
                    switch (level[x, y])
                    {
                        case '#':
                            walls.Add(new Wall(position));
                            break;
                        case '@':
                            player = new Player(position);
                            break;
                        case '0':
                            foods.Add(new Food(position));
                            break;
                        case 'M':
                            monsters.Add(new Monster(position));
                            break;
                        default:
                            break;
                    }
                }
            }
            return new GameState(player, walls, foods, monsters);
        }

        public GameState Update(Queue<ConsoleKey> keyQueue)
        {
            return new GameState(player.Update(this, keyQueue), 
                walls.Update(this), foods.Update(this), monsters.Update(this));
        }
    }
}
