using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{
    public class ColoredText : ActorComponent
    {

        public char[,] text { get; set; }

        public ConsoleColor Background { get; set; }
        public ConsoleColor Foreground { get; set; }


        public override void Awake()
        {

        }

        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {

            if (text == null)
                return;
            Vector3 actorPosition = Actor.WorldPosition;
            int centrx = (int)text.GetLength(0)/2;
            int centry = (int)text.GetLength(1)/2;

            int curentx = (int)Actor.WorldPosition.x - centrx;
            int curenty = (int)Actor.WorldPosition.y - centry;

            
            for (int x = 0; x < text.GetLength(0); x++)            
            {
                for (int y = 0; y < text.GetLength(1); y++)
                {                    
                    Game.Graphic.SetSymbol(curentx+x, curenty+y, 
                        new GraphicsPrimitive(text[x, y],  Foreground, Background,Actor.WorldPosition.z));
                }
            } 
        }
        public override void OnDestroy()
        {
           
        }
    }
}

