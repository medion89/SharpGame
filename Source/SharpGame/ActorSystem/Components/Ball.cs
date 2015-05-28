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

    }
}
