using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{
    public class Physic
    {
        List<Actor>[,] CollussionSpace;

        public Physic()
        {
            CollussionSpace = new List<Actor>[50, 45];
            for (int i = 0; i < CollussionSpace.GetLength(0); i++)
                for (int j = 0; j < CollussionSpace.GetLength(1); j++)
                    CollussionSpace[i, j] = new List<Actor>();
        }

        public void ToCollSpace(Vector3 Position, Actor Actor)
        {
            int y = (int)Position.y;
            int x = (int)Position.x;


            CollussionSpace[x, y].Add(Actor);
            if (CollussionSpace[x, y].Count > 1)
            {
                foreach (Actor Act in CollussionSpace[x, y])
                {
                    Actor.OnCollide(Act);
                }
            }
        }
        public void BuffClear()
        {
            for (int j = 0; j < CollussionSpace.GetLength(0); j++)
            {
                for (int k = 0; k < CollussionSpace.GetLength(1); k++)
                {
                    CollussionSpace[j, k].Clear();
                }
            }
        }
    }
}
