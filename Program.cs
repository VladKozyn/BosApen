using BosApen.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BosApen
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            DbVuller dbv = new DbVuller();
            List<Bos> bossen = new List<Bos>();
            List<string> namen1 = new List<string>() { "marie", "jackie","Katrien","Marvel" };
            List<string> namen2 = new List<string>() { "paul", "keesje" };
            bossen.Add(new Bos(0,0, 0, 1000, 1000, 500));
            bossen[0].maakApen(4, namen1);
        //    Bitmap bm1 = new Bitmap((bossen[0].maxGrooteX - bossen[0].minGrooteX) * 2, (bossen[0].maxGrooteY - bossen[0].minGrooteY) * 2); ;
       //     bm1.Save(Path.Combine(@"C: \Users\lieke\OneDrive\scool\prog 4\BosApen\BosApen",bossen[0].bosID.ToString()+"_escapeRoutes.jpg"),ImageFormat.Jpeg)
            bossen.Add(new Bos(1,0, 0, 500, 500, 100));
            bossen[1].maakApen(2, namen2);
         //   Bitmap bm2 = new Bitmap((bossen[1].maxGrooteX - bossen[1].minGrooteX) * 2, (bossen[1].maxGrooteY - bossen[1].minGrooteY) * 2); ;
            dbv.vulAapRecordsOp(bossen);
            dbv.vulBosRecordsOp(bossen);
            for (int i = 0; i < bossen.Count; i++)
            {
                while (bossen[i].listApen.Any())
                {
                    for (int b = 0; b < bossen[i].listApen.Count; b++)
                    {
                        await bossen[i].AapSpring(bossen[i].listApen[b]);
                    }
                }
            }

        }


    }
}
