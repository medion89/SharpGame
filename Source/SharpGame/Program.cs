namespace GameFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //***** Actor A *****//
            Actor actorA = new Actor("ActorB");
            ColoredText coloredTextA = new ColoredText();
            coloredTextA.Text = new char[,] {
                { '#', '#', '#'},
                { '#', 'A', '#'},
                { '#', '#', '#'}
            };
            coloredTextA.ForegroundColor = System.ConsoleColor.Cyan;
            coloredTextA.BackgroundColor = System.ConsoleColor.DarkGray;

            TestComponentB testComponentA = new TestComponentB();
            testComponentA.Direction = new Vector3(1, 1, 0).Normalized;
            testComponentA.Speed = 1f;

            actorA.AddComponent(coloredTextA);
            actorA.AddComponent(testComponentA);
            actorA.LocalPosition = new Vector3(5, 5, 0);

            //***** Actor B *****//
            Actor actorB = new Actor("ActorB");
            ColoredText coloredTextB = new ColoredText();
            coloredTextB.Text = new char[,] {
                { '#', '#', '#'},
                { '#', 'B', '#'},
                { '#', '#', '#'}
            };
            coloredTextB.ForegroundColor = System.ConsoleColor.DarkGray;
            coloredTextB.BackgroundColor = System.ConsoleColor.Cyan;

            TestComponentB testComponentB = new TestComponentB();
            testComponentB.Direction = new Vector3(1, 1, 0).Normalized;
            testComponentB.Speed = 1f;

            actorB.AddComponent(coloredTextB);
            actorB.AddComponent(testComponentB);
            actorB.LocalPosition = new Vector3(10, 10, 0);

            //***** Scene Setup *****//
            Scene scene = new Scene();
            actorA.AddChild(actorB);
            scene.AddChild(actorA);

            //***** Game Setup *****//
            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
        }
    }
}
