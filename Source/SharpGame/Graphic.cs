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
            buff1 = new GraphicsPrimitive[20, 20];
            for (int j = 0; j < buff1.GetLength(0); j++)
                for (int k = 0; k < buff1.GetLength(1); k++)
                    buff1[j, k] = GraphicsPrimitive.BlackSpace;

            buff2 = new GraphicsPrimitive[20, 20];
            for (int j = 0; j < buff2.GetLength(0); j++)
                for (int k = 0; k < buff2.GetLength(1); k++)
                    buff2[j, k] = GraphicsPrimitive.BlackSpace;
        }
        public void SetSymbol(int x, int y, GraphicsPrimitive symbol)
        {
            if (buff2[x, y].depth > symbol.depth || buff2[x, y].symbol == '#')
                buff2[x, y] = symbol;
        }
        public void DrawCell()
        {
            buff1 = buff2.Clone() as GraphicsPrimitive[,];

            for (int i = 0; i < buff1.GetLength(0); i++)
            {
                for (int j = 0; j < buff1.GetLength(1); j++)
                {
                    if (buff1[i, j].symbol == '#')
                        Console.Write(' ');
                    else
                    {
                        Console.BackgroundColor = buff1[i, j].background;
                        Console.ForegroundColor = buff1[i, j].foreground;
                        Console.Write(buff1[i, j].symbol);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
