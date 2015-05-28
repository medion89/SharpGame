using System.Diagnostics;

namespace SharpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TestActorsSearching();
 
            Scene scene = new Scene();

            Actor player = new Actor();
            player.WorldPosition = new Vector3(5, 5, 0);

            ColoredText racket = new ColoredText();
            racket.text = new char [,]{
                           {'#'},
                           {'#'},
                           {'#'},
                           {'#'},
                           {'#'}};
            racket.Foreground = System.ConsoleColor.Blue;
            racket.Background = System.ConsoleColor.Cyan;
            Racket control = new Racket();


            Actor Ball = new Actor();
            Ball.WorldPosition = new Vector3(5, 40, 0);
            Ball move = new Ball();
            move.Speed = 2;
            move.Direction = new Vector3(0, -1, 0);
            ColoredText ball = new ColoredText();
            ball.text = new char[,] { {'O'} };
            ball.Background = System.ConsoleColor.DarkBlue;
            ball.Foreground = System.ConsoleColor.DarkCyan;
            
            



            // Resources res = new Resources();
            //res.RegisterLoader(".pong", new SceneLoader());
            //Scene testScene = res.Load<Scene>("game.pong");
            scene.AddActor(player);
            scene.AddActor(Ball);
            player.AddComponent(racket);
            player.AddComponent(control);
            Ball.AddComponent(ball);
            Ball.AddComponent(move);
            
            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
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
