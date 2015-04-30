namespace GameFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor actor = new Actor();
            ColoredText ct = new ColoredText();
            ct.Text = new char[,] {
                { '#', '#', '#'},
                { '#', '@', '#'},
                { '#', '#', '#'}
            };
            ct.ForegroundColor = System.ConsoleColor.Cyan;
            ct.BackgroundColor = System.ConsoleColor.DarkGray;

            TestComponentB testComp = new TestComponentB();
            testComp.Direction = new Vector3(1, 1, 0).Normalized;
            testComp.Speed = 1f;

            actor.AddEntity(ct);
            actor.AddEntity(testComp);
            actor.Position = new Vector3(5, 5, 0);

            Scene scene = new Scene();
            scene.AddEntity(actor);

            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
        }
    }
}
