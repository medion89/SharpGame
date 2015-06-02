using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{

    public class Collider : ActorComponent
    {

        private List<Vector3> ColliderList;
        

        public override void Awake()
        {

        }

        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {
            foreach (Vector3 Vec in ColliderList)
                Game.Physic.ToCollSpace(Actor.WorldPosition, Actor);
        }

        public override void OnDestroy()
        {

        }
        public override void OnCollide(Actor C)
        {

        }
    }
}
    

