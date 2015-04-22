using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    struct GraphicsPrimitive
    {
        char symbol{get;set;}
        ConsoleColor foregrcolor { get; set; }
        ConsoleColor backgrcolor { get; set; }
        float depth { get; set; }

        GraphicsPrimitive(char symbol, ConsoleColor foregrcolor, ConsoleColor backgrcolor, float depth)
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
