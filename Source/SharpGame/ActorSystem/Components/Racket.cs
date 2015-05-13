using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
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


            if (Input.IsKeyDown(ConsoleKey.UpArrow)&&Parent.Position.x > 0)
            {
                
                Parent.Position = new Vector3(Parent.Position.x-1, Parent.Position.y, Parent.Position.z);
                
            }

            if (Input.IsKeyDown(ConsoleKey.DownArrow) && Parent.Position.x <= Console.WindowHeight )
            {
                
                Parent.Position = new Vector3(Parent.Position.x + 1, Parent.Position.y, Parent.Position.z);
                
            }

        }

        public override void OnDestroy()
        {

        }
    }
}

