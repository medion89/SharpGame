using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    
    public class Collider : ActorComponent
    {
        
        int[,] shape;

        public override void Awake()
        {
            
        }

        public override void Start()
        {
            
        }

        public override void Update(float deltaTime)
        {
            int centrx = (int)shape.GetLength(0) / 2;
            int centry = (int)shape.GetLength(1) / 2;

            int curentx = (int)Parent.Position.x - centrx;
            int curenty = (int)Parent.Position.y - centry;


            for (int x = 0; x < shape.GetLength(0); x++)
            {

                for (int y = 0; y < shape.GetLength(1); y++)
                {
                    if (curenty + y < 0 || curentx + x < 0)
                        continue;

                    // Game.Physic          //SetSymbol(curentx+x, curenty+y, new Physic());
                }
            }
        }

        public override void OnDestroy()
        {
            
        }
        public override void OnCollide(Actor C)
        {

        }
    }
}
