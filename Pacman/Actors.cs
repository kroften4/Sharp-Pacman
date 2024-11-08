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
            this.list = new List<Actor>();
        }
        public Actors(List<Actor> actorsList)
        {
            this.list = actorsList;
        }
        public Actors(List<Vector2D> actorsPositions)
        {
            this.list = new List<Actor>();
            foreach (Vector2D position in actorsPositions)
            {
                this.list.Add(new Actor(position));
            }
        }

        virtual public Actors Update(GameState gameState)
        {
            List<Actor> newActorsList = new List<Actor>();
            foreach(Actor actor in this.list)
            {
                var newActor = actor.Update(gameState);
                if (newActor != null)
                    newActorsList.Add(newActor);
            }
            return new Actors(newActorsList);
        }

        public void Add(Actor actor)
        {
            this.list.Add(actor);
        }

        public bool Contains(Actor actor)
        {
            return this.list.Contains(actor);
        }
        public bool Contains(Vector2D position)
        {
            foreach (Actor actor in this.list)
            {
                if (actor.position.x == position.x && actor.position.y == position.y)
                    return true;
            }
            return false;
        }
    }
}
