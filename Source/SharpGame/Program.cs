using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            ColoredText rocket1 = new ColoredText(ConsoleColor.Red, ConsoleColor.Blue);
            rocket1.text = new char[,]
            {{' ','#',' '},
             {' ','#',' '},
             {' ','#',' '},
             {' ','#',' '},
             {' ','#',' '}};

            ColoredText rocket2 = new ColoredText(ConsoleColor.Red, ConsoleColor.Blue);

            rocket2.text = new char[,]
            {{' ','#',' '},
             {' ','#',' '},
             {' ','#',' '},
             {' ','#',' '},
             {' ','#',' '}};

            actor.AddEntity(rocket1);
            actor2.AddEntity(rocket2);

            Scene scene = new Scene();
            scene.AddEntity(actor);
            scene.AddEntity(actor2);

            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
        }
    }
}
