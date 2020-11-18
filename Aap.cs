using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace BosApen
{
    public class Aap
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string naam { get; set; }
        public List<Boom> bezochteBomen { get; set; } = new List<Boom>();
        
    public Aap(int id,int x,int y, string naam)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.naam = naam;

        }
       public bool heeftBoomBezocht(Boom boom)

        {
            return bezochteBomen.Any(bm => bm.x == boom.x
                                            && bm.y == boom.y);
        }
        public void spring(Boom boom)
        {
            bezochteBomen.Add(boom);
            this.x = boom.x;
            this.y = boom.y;
        }
        public Boom currentBoom()
        {
           
         return bezochteBomen.Last();
            
        }
    }

}
