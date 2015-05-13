using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class Ball : ActorComponent
    {
        public Vector3 direction { get; set; }
        public float speed { get; set; }
        public override void Awake()
        {

        }

        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {
            

           Parent.Position += direction * speed * deltaTime;
               
            
        }

        public override void OnDestroy()
        {

        }

    }
}
