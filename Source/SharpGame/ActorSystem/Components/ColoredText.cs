using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class ColoredText : ActorComponent
    {
       
        public char[,] text;
       

        ConsoleColor Foreground;
        ConsoleColor Background;

        public ColoredText(ConsoleColor foreground, ConsoleColor background)
        {
            Foreground = foreground;
            Background = background;
            
        }
        public override void Awake()
        {

        }

        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {
            int centrx = (int)text.GetLength(0) / 2;
            int centry = (int)text.GetLength(1) / 2;

            int curentx = (int)Parent.Position.x - centrx;
            int curenty = (int)Parent.Position.y - centry;
            Console.SetCursorPosition(curentx, curenty);
            for (int y = 0; y < text.GetLength(0); y++)
            {
                for (int x = 0; x < text.GetLength(1); x++)
                {
                    Console.WriteLine(text[curenty, curentx]);
                }
            }
        }

    }


}

