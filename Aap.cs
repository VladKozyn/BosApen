using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace BosApen
{
    public class Aap
    {
        [Key]
        public int recordID { get; set; }
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string naam { get; set; }
        public List<Boom> bezochteBomen { get; set; } = new List<Boom>();
        public int BosID { get; set; }
        public int seqnr { get; set; }
        public int boomID { get; set; }
    public Aap(int id,int x,int y, string naam)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.naam = naam;

        }
        public Aap(int id, string naam, int BosID, int seqnr,int boomID,int x,int y)
        {
            this.id = id;
            this.naam = naam;
            this.BosID = BosID;
            this.seqnr = seqnr;
            this.boomID = boomID;
            this.x = x;
            this.y = y;
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
