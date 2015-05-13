using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class Graphic
    {
        GraphicsPrimitive[,] buff1;
        GraphicsPrimitive[,] buff2;
        public Graphic()
        {
            buff1 = new GraphicsPrimitive[50, 45];
            /*for (int j = 0; j < buff1.GetLength(0); j++)
                for (int k = 0; k < buff1.GetLength(1); k++)
                    buff1[j, k] = GraphicsPrimitive.BlackSpace;*/

            buff2 = new GraphicsPrimitive[50,45];
           /* for (int j = 0; j < buff2.GetLength(0); j++)
                for (int k = 0; k < buff2.GetLength(1); k++)
                    buff2[j, k] = GraphicsPrimitive.BlackSpace;*/

            Console.CursorVisible = false;
        }
        public void BuffClear()
        {
            for (int j = 0; j < buff1.GetLength(0); j++)
            {
                for (int k = 0; k < buff1.GetLength(1); k++)
                {
                    buff1[j, k] = new GraphicsPrimitive(' ', ConsoleColor.White, ConsoleColor.Black, float.MinValue);
                }
            }
        }
        public void DrawonScreen()
        {
            for (int i = 0; i < buff1.GetLength(0); i++)
            {
                for (int j = 0; j < buff1.GetLength(1); j++)
                {
                    if (buff1[i, j] != buff2[i, j])
                        DrawCell(i, j, buff1[i, j]);
                }
            }
        }
        public void BuffClone()
        {
            var tmp = buff1;
            buff1 = buff2;
            buff2 = tmp;
        }

        public void SetSymbol(int x, int y, GraphicsPrimitive primitive)
        {
            if (x < 0 || x >= buff1.GetLength(0) || y < 0 || y >= buff1.GetLength(1))
                return;

            if (buff1[y, x].depth < primitive.depth)
                buff1[y, x] = primitive;
        }
        private void DrawCell(int i, int j, GraphicsPrimitive primitive)
        {
                    Console.SetCursorPosition(i, j);    
                    Console.BackgroundColor = primitive.background;
                    Console.ForegroundColor = primitive.foreground;                    
                    Console.Write(primitive.symbol);  
        }
        
    }
}

