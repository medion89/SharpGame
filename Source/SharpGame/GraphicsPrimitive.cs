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
        public ConsoleColor foreground { get; set; }
        public ConsoleColor background { get; set; }
        public float depth { get; set; }

        public GraphicsPrimitive(char symbol, ConsoleColor foreground, ConsoleColor background, float depth)
            : this()
        {
            this.symbol = symbol;
            this.foreground = foreground;
            this.background = background;
            this.depth = depth;
        }

       public static readonly GraphicsPrimitive BlackSpace = new GraphicsPrimitive(' ', ConsoleColor.Black, ConsoleColor.Black, 0);

    }
}
