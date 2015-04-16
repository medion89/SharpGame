namespace GameFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor actor = new Actor();
            TestComponentA testCmpA = new TestComponentA();
            TestComponentB testCmpB = new TestComponentB();

            actor.AddEntity(testCmpA);
            actor.AddEntity(testCmpB);

            Scene scene = new Scene();
            scene.AddEntity(actor);

            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
        }
    }
}
