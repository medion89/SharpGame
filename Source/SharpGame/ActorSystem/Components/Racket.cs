using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{
    public class Racket : ActorComponent
    {
        
        
        
        public override void Awake()
        {

        }

        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {


            if (Input.IsKeyDown(ConsoleKey.UpArrow)&&Actor.WorldPosition.x > 0)
            {

                Actor.WorldPosition = new Vector3(Actor.WorldPosition.x - 1, Actor.WorldPosition.y, Actor.WorldPosition.z);
                
            }

            if (Input.IsKeyDown(ConsoleKey.DownArrow) && Actor.WorldPosition.x <= Console.WindowHeight)
            {

                Actor.WorldPosition = new Vector3(Actor.WorldPosition.x + 1, Actor.WorldPosition.y, Actor.WorldPosition.z);
                
            }

        }

        public override void OnDestroy()
        {

        }
    }
}

