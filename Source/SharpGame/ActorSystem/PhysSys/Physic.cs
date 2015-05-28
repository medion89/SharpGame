using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{
    public class Physic
    {
        List<Actor>[,] collussionSpace;
         
         public Physic()
         {
             collussionSpace = new List<Actor>[50, 45];
                for(int i=0;i<collussionSpace.GetLength(0);i++)
                    for(int j=0;j<collussionSpace.GetLength(1);j++)
                        collussionSpace[i,j]= new List<Actor>();
         }

         public void checkin()
         {
             for(int i=0; i<collussionSpace.GetLength(0);i++)
                 for(int j=0; j<collussionSpace.GetLength(1);j++)
                     if(collussionSpace[i,j].Count>1)
                     {
                         foreach (Actor Actor in collussionSpace[i,j])
                         {
                             Actor.OnCollide(Actor);
                         }
                     }

                    
         }

    }
}
