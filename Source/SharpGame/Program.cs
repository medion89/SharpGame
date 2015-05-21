using System.Diagnostics;

namespace SharpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ////***** Actor A *****//
            //Actor actorA = new Actor("ActorB");
            //ColoredText coloredTextA = new ColoredText();
            //coloredTextA.Text = new char[,] {
            //    { '#', '#', '#'},
            //    { '#', 'A', '#'},
            //    { '#', '#', '#'}
            //};
            //coloredTextA.ForegroundColor = System.ConsoleColor.Cyan;
            //coloredTextA.BackgroundColor = System.ConsoleColor.DarkGray;

            //TestComponentB testComponentA = new TestComponentB();
            //testComponentA.Direction = new Vector3(1, 1, 0).Normalized;
            //testComponentA.Speed = 1f;

            //actorA.AddComponent(coloredTextA);
            //actorA.AddComponent(testComponentA);
            //actorA.LocalPosition = new Vector3(5, 5, 0);

            ////***** Actor B *****//
            //Actor actorB = new Actor("ActorB");
            //ColoredText coloredTextB = new ColoredText();
            //coloredTextB.Text = new char[,] {
            //    { '#', '#', '#'},
            //    { '#', 'B', '#'},
            //    { '#', '#', '#'}
            //};
            //coloredTextB.ForegroundColor = System.ConsoleColor.DarkGray;
            //coloredTextB.BackgroundColor = System.ConsoleColor.Cyan;

            //TestComponentB testComponentB = new TestComponentB();
            //testComponentB.Direction = new Vector3(1, 1, 0).Normalized;
            //testComponentB.Speed = 1f;

            //actorB.AddComponent(coloredTextB);
            //actorB.AddComponent(testComponentB);
            //actorB.LocalPosition = new Vector3(10, 10, 0);

            ////***** Scene Setup *****//
            //Scene scene = new Scene();
            //actorA.AddChild(actorB);
            //scene.AddActor(actorA);

            //actorB.WorldPosition = Vector3.Zero;

            Resources res = new Resources();
            res.RegisterLoader(".scene", new SceneLoader());
            Scene testScene = res.Load<Scene>("test.scene");

            TestActorsSearching();

            //***** Game Setup *****//
            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(testScene);
        }

        public static void TestActorsSearching()
        {
            const int TEST_ACTORS_CNT = 5;
            Actor nodeI = new Actor("Node I");
            Actor nodeIIA = new Actor("Node II A");
            Actor nodeIIB = new Actor("Node II B");
            Actor nodeIIIA = new Actor("Node III A");
            Actor nodeIIIB = new Actor("Node III B");

            Scene scene = new Scene();

            nodeIIB.AddChild(nodeIIIA);
            nodeIIB.AddChild(nodeIIIB);
            nodeI.AddChild(nodeIIA);
            nodeI.AddChild(nodeIIB);
            scene.AddActor(nodeI);

            Debug.Assert(scene.FindActor(actor => actor.Name == nodeIIIB.Name) == nodeIIIB);
            Debug.Assert(scene.FindActor(actor => actor.Name == nodeIIA.Name) == nodeIIA);
            Debug.Assert(scene.FindAllActors(actor => actor.Name.Contains("Node")).Count == TEST_ACTORS_CNT);
            var foundActors = scene.FindAllActors(actor => actor.Name.Contains("A"));
            Debug.Assert(foundActors.Count == 2 && foundActors.Contains(nodeIIA) && foundActors.Contains(nodeIIIA));
        }
    }
}
