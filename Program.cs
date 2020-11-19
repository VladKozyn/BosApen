using BosApen.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BosApen
{
    class Program
    {
        static void Main(string[] args)
        {
            DbVuller dbv = new DbVuller();
            List<Bos> bossen = new List<Bos>();
            List<string> namen1 = new List<string>() { "marie", "jackie" };
            List<string> namen2 = new List<string>() { "paul", "keesje" };
            bossen.Add(new Bos(0,0, 0, 500, 500, 100));
            bossen[0].maakApen(2, namen1);
            bossen.Add(new Bos(1,0, 0, 500, 500, 100));
            bossen[1].maakApen(2, namen2);
            dbv.vulAapRecordsOp(bossen);
            dbv.vulBosRecordsOp(bossen);
            for (int i = 0; i < bossen.Count; i++)
            {
                while (bossen[i].listApen.Any())
                {
                    for (int b = 0; b < bossen[i].listApen.Count; b++)
                    {
                        bossen[i].AapSpring(bossen[i].listApen[b]);
                    }
                }
            }

        }
    }
}
