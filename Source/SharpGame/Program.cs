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
            
            Racket turr = new Racket();
            
            actor.Position = new Vector3(5, 5, 0);
            
            ColoredText rocket1 = new ColoredText();
            rocket1.text = new char[,]
           {{'#'},
            {'#'},
            {'#'},
            {'#'},
            {'#'}};
            rocket1.Background = ConsoleColor.Blue;
            rocket1.Foreground = ConsoleColor.Cyan;



            Actor actor2 = new Actor();
            actor2.Position = new Vector3(5, 40, 0);
            ColoredText rocket2 = new ColoredText();
            rocket2.text = new char[,]
             {{'#'},
             {'#'},
             {'#'},
             {'#'},
             {'#'}};
            rocket2.Background = ConsoleColor.White;
            rocket2.Foreground = ConsoleColor.DarkCyan;


            Actor actor3 = new Actor();
            actor3.Position = new Vector3(10, 15, 0);
            Ball move = new Ball();
            ColoredText Ball = new ColoredText();
            Ball.text = new char[,] 
             {{ 'O' }};
            Ball.Background=ConsoleColor.Red;
            Ball.Foreground = ConsoleColor.Black;
            move.speed = 2f;
            move.direction = new Vector3(1, 1, 0);



            actor.AddEntity(rocket1);
            actor2.AddEntity(rocket2);
            actor.AddEntity(turr);
            actor3.AddEntity(Ball);
            actor3.AddEntity(move);

            Scene scene = new Scene();
            scene.AddEntity(actor);
            scene.AddEntity(actor2);
            scene.AddEntity(actor3);

            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
        }
    }
}
