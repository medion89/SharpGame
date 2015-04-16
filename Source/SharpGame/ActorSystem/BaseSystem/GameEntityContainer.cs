using System.Collections.Generic;
using System.Diagnostics;

namespace GameFramework.Internal
{
    public abstract class GameEntityContainer<TGameEntity, TSelf> : IGameEntity 
        where TGameEntity : IGameEntity, IComposed<TSelf>
        where TSelf : GameEntityContainer<TGameEntity, TSelf>
    {
        protected List<TGameEntity> entities;

        protected bool GameStarted { get; private set; }

        public GameEntityContainer()
        {
            entities = new List<TGameEntity>();
            GameStarted = false;
        }

        public void AddEntity(TGameEntity entity)
        {
            entities.Add(entity);
            entity.Awake();

            TSelf self = this as TSelf;
            Debug.Assert(self != null, "Your class is ill-formed, TSelf should be the type of derrived class!");
            entity.Parent = self;

            if (GameStarted)
            {
                entity.Start();
            }
        }

        public virtual void Awake() { }

        public void Start()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Start();
            }

            GameStarted = true;
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update(deltaTime);
            }
        }

        public void OnDestroy()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnDestroy();
            }

            entities.Clear();
        }
    }
}
