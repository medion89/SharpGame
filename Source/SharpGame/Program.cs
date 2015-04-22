namespace GameFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor actor = new Actor();
            Actor actor2 = new Actor();

            actor.Position = new Vector3(5, 5, 0);
            actor2.Position = new Vector3(5, 17, 0);

            ColoredText rocket1 = new ColoredText(System.ConsoleColor.Red, System.ConsoleColor.Blue);
            rocket1.text = new char[,]
            {{' ','#',' '},
             {' ','#',' '},
             {' ','#',' '},
             {' ','#',' '},
             {' ','#',' '}};

            ColoredText rocket2 = new ColoredText(System.ConsoleColor.Red, System.ConsoleColor.Blue);

            rocket2.text = new char[,]
            {{' ','#',' '},
             {' ','#',' '},
             {' ','#',' '},
             {' ','#',' '},
             {' ','#',' '}};
            Scene scene = new Scene();
            scene.AddEntity(Raketka1);

            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
        }
    }
}
