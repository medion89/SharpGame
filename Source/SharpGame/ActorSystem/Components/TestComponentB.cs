using System;

namespace GameFramework
{
    public class TestComponentB : ActorComponent
    {
        public override void Awake()
        {
            Console.WriteLine("TestComponentB Awake()");
        }

        public override void Start()
        {
            Console.WriteLine("TestComponentB Start()");
        }

        public override void Update(float deltaTime)
        {
            Console.WriteLine("TestComponentB Update({0})", deltaTime);
        }

        public override void OnDestroy()
        {
            Console.WriteLine("TestComponentB OnDestroy()");
        }
    }
}
