using GameFramework.Internal;

namespace GameFramework
{
    public abstract class ActorComponent : IGameEntity, IComposed<Actor>
    {
        public Actor Parent { get; set; }

        public Game Game
        {
            get
            {
                // the game is a parent of the scene, which is a parent of an actor, which is our parent :)
                Game game = Parent.Parent.Parent;
                return game;
            }
        }

        public virtual void Awake() { }

        public virtual void Start() { }

        public virtual void Update(float deltaTime) { }

        public virtual void OnDestroy() { }

        public virtual void OnCollide(Actor C)
        {

        }
    }
}
