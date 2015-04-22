using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
   public struct GraphicsPrimitive
    {
        public char symbol {get;set;}
        public ConsoleColor foregrcolor { get; set; }
        public ConsoleColor backgrcolor { get; set; }
        public float depth { get; set; }

       public GraphicsPrimitive(char symbol, ConsoleColor foregrcolor, ConsoleColor backgrcolor, float depth)
            : this()
        {
            this.symbol = symbol;
            this.foregrcolor = foregrcolor;
            this.backgrcolor = backgrcolor;
            this.depth = depth;
        }

       public static readonly GraphicsPrimitive BlackSpace = new GraphicsPrimitive(' ', ConsoleColor.Black, ConsoleColor.Black, 0);

    }
}
