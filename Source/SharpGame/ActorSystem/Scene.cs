using System;
using System.Collections.Generic;
using GameFramework.Internal;

namespace GameFramework
{
    public class Scene : GameEntityContainer<Actor, Scene>, IComposed<Game>
    {
        public Game Parent { get; set; }

        public WeakReference<Actor> GetActor(string name)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Name == name)
                    return new WeakReference<Actor>(entities[i]);
            }

            return new WeakReference<Actor>(null);
        }

        public List<WeakReference<Actor>> GetAllActors(string name)
        {
            var foundActors = new List<WeakReference<Actor>>();

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Name == name)
                    foundActors.Add(new WeakReference<Actor>(entities[i]));
            }

            return foundActors;
        }
    }
}
