using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class SymbolDrawer : ActorComponent
    {
        public char[,] desk { get; set; }

        public override void Awake()
        {

        }

        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {
            
            int curentx = (int)Parent.Position.x;
            int curenty = (int)Parent.Position.y;
            Console.SetCursorPosition(curentx,curenty);
            for(int y = 0;y<desk.GetLength(0);y++)
            {
                for(int x=0;x<desk.GetLength(1);x++)
                {
                    foreach (char des in desk)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.WriteLine(desk[curenty, curentx]);
                }
            }
        }

        public override void OnDestroy()
        {

        }
    }
}
