using System;
using System.Collections.Generic;
using GameFramework.Internal;

namespace GameFramework
{
    public class Scene : GameEntityContainer<Actor>
    {
        public Game Game { get; set; }

        public override void AddChild(Actor actor)
        {
            actor.scene = this;
            base.AddChild(actor);
        }




        public WeakReference<Actor> GetActor(string name)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].Name == name)
                    return new WeakReference<Actor>(children[i]);
            }

            return new WeakReference<Actor>(null);
        }

        public List<WeakReference<Actor>> GetAllActors(string name)
        {
            var foundActors = new List<WeakReference<Actor>>();

            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].Name == name)
                    foundActors.Add(new WeakReference<Actor>(children[i]));
            }

            return foundActors;
        }
    }
}
