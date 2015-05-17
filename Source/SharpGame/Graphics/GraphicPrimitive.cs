using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{
    public struct GraphicPrimitive
    {
        public char symbol;
        public ConsoleColor foregroundColor;
        public ConsoleColor backgroundColor;
        public float depth;

        public GraphicPrimitive(char symbol, ConsoleColor foregroundColor, ConsoleColor backgroundColor, float depth)
        {
            this.symbol = symbol;
            this.foregroundColor = foregroundColor;
            this.backgroundColor = backgroundColor;
            this.depth = depth;
        }

        public static bool operator ==(GraphicPrimitive a, GraphicPrimitive b)
        {
            return a.symbol == b.symbol &&
                   a.foregroundColor == b.foregroundColor &&
                   a.backgroundColor == b.backgroundColor &&
                   a.depth == b.depth;
        }

        public static bool operator !=(GraphicPrimitive a, GraphicPrimitive b)
        {
            return !(a == b);
        }
    }
}
