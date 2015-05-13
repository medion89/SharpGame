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

        public GraphicsPrimitive(char sy, ConsoleColor f, ConsoleColor b, float d)
            : this()
        {
            this.symbol = sy;
            this.foreground = f;
            this.background = b;
            this.depth = d;
        }

       public static readonly GraphicsPrimitive BlackSpace = new GraphicsPrimitive(' ', ConsoleColor.Black, ConsoleColor.Black, 0);

       public static bool operator ==(GraphicsPrimitive a, GraphicsPrimitive b)
       {
           return a.symbol == b.symbol &&
                  a.foreground == b.foreground &&
                  a.background == b.background &&
                  a.depth == b.depth;
       }
       public static bool operator !=(GraphicsPrimitive a, GraphicsPrimitive b)
       {
           return !(a == b);
       }
    }
}
