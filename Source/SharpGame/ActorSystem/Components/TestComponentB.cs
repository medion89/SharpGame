using System;

namespace GameFramework
{
    public class TestComponentB : ActorComponent
    {
        public Vector3 Direction { get; set; }
        public float Speed { get; set; }

        public override void Update(float deltaTime)
        {
            Parent.Position += Direction * Speed * deltaTime;
        }
    }
}
