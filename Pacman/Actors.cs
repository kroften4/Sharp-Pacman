using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Actors
    {
        public List<Actor> list;

        public Actors()
        {
            list = new List<Actor>();
        }
        public Actors(List<Actor> actorsList)
        {
            list = actorsList;
        }

        virtual public GameState Update(GameState gameState, Queue<ConsoleKey> keyQueue)
        {
            GameState newState = gameState;
            foreach(Actor actor in list)
            {
                newState = actor.Update(newState, keyQueue);
            }
            return newState ?? gameState;
        }

        public void Add(Actor actor)
        {
            list.Add(actor);
        }
        public Actors Removed(Actor actor)
        {
            List<Actor> newList = new List<Actor>(list);
            newList.Remove(actor);
            return new Actors(newList);
        }

        public bool Contains(Actor actor)
        {
            return list.Contains(actor);
        }
        public bool HasActorAt(Vector2D position)
        {
            foreach (Actor actor in list)
            {
                if (actor.position.x == position.x && actor.position.y == position.y)
                    return true;
            }
            return false;
        }
    }
}
