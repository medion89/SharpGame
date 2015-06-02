using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{
    public class Ball : ActorComponent
    {
        public Vector3 Direction { get; set; }
        public float Speed { get; set; }
        public override void Awake()
        {

        }

        public override void Start()
        {
            
        }

        public override void Update(float deltaTime)
        {  
           Actor.WorldPosition += Direction * Speed * deltaTime;

        }

        public override void OnDestroy()
        {

        }

        public override void OnCollide(Actor C)
        {
            Actor.WorldPosition = new Vector3(Actor.WorldPosition.x, Actor.WorldPosition.y * -1,Actor.WorldPosition.z);
        }

    }
}
