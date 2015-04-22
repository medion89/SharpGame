using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Graphic
    {
        GraphicsPrimitive[,] buff;

        Graphic()
        {
            buff = new GraphicsPrimitive [80, 80];
            for(int j=0;j<buff.GetLength(0);j++)
               for(int k=0;k<buff.GetLength(1);k++)
                    buff[j,k] = GraphicsPrimitive.BlackSpace;
        }

        public void add(int x, int y, GraphicsPrimitive symb)
    {
        for( int i=0; i<buff.GetLength(0);i++)
            for(int  j=0;j<buff.GetLength(1);j++)
            {
                if( )
            }
    }
    }
}
