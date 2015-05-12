﻿using GameFramework.Internal;

namespace GameFramework
{
    public abstract class ActorComponent : IGameEntity
    {
        public Actor Actor { get; set; }

        public Game Game
        {
            get
            {
                Game game = Actor.Scene.Game;
                return game;
            }
        }

        public virtual void Awake() { }

        public virtual void Start() { }

        public virtual void Update(float deltaTime) { }

        public virtual void OnDestroy() { }
    }
}
