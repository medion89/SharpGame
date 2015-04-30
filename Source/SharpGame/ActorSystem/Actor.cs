using System;
using System.Collections.Generic;
using GameFramework.Internal;

namespace GameFramework
{
    public class Actor : GameEntityContainer<ActorComponent, Actor>, IComposed<Scene>
    {
        public Scene Parent { get; set; }

        public string Name { get; set; }

        public Vector3 Position { get; set; }

        public WeakReference<TComponent> GetComponent<TComponent>() where TComponent : class
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i] is TComponent)
                    return new WeakReference<TComponent>(entities[i] as TComponent);
            }

            return new WeakReference<TComponent>(null);
        }

        public List<WeakReference<TComponent>> GetAllComponents<TComponent>() where TComponent : class
        {
            List<WeakReference<TComponent>> foundComponents = new List<WeakReference<TComponent>>();

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i] is TComponent)
                    foundComponents.Add(new WeakReference<TComponent>(entities[i] as TComponent));
            }

            return foundComponents;
        }
        
        public void OnCollide(Actor CollisionActor) 
        { 
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnCollide(CollisionActor);   
            }

        }

        internal static void OnCollide()
        {
            throw new NotImplementedException();
        }
    }
}
