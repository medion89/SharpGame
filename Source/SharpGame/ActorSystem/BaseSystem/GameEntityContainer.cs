using System.Collections.Generic;
using System.Diagnostics;

namespace GameFramework.Internal
{
    public abstract class GameEntityContainer<TGameEntity> : IGameEntity 
        where TGameEntity : IGameEntity
         
    {
        protected List<TGameEntity> children;

        protected bool GameStarted { get; private set; }

        public GameEntityContainer()
        {
            children = new List<TGameEntity>();
            GameStarted = false;
        }

        public void AddChild(TGameEntity entity)
        {
            children.Add(entity);
            entity.Awake();
           // TSelf self = this as TSelf;
           // Debug.Assert(self != null, "Your class is ill-formed, TSelf should be the type of derrived class!");
            //entity.Parent = self;
            if (GameStarted)
            {
                entity.Start();
            }
        }

        public virtual void Awake() { }

        public void Start()
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].Start();
            }

            GameStarted = true;
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].Update(deltaTime);
            }
        }

        public void OnDestroy()
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].OnDestroy();
            }

            children.Clear();
        }
    }
}
