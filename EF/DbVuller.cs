using BosApen.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace BosApen.EF
{
    class DbVuller
    {
        Context ctx = new Context();

        public void vulAapRecordsOp(List<Bos> bossen)
        {
            /*   ,[id]
        ,[x]
        ,[y]
        ,[naam]
        ,[BosID]
        ,[seqnr]
        ,[boomID]*/
           int teller = 0;
          foreach(Bos b in bossen)
            {
                foreach(Aap a in b.listApen)
                {
                    foreach (Boom bo in b.listBomen)
                    {
                        ctx.AapRecords.Add(new Aap(a.id, a.naam, b.bosID, teller, bo.id, bo.x, bo.y));
                        ctx.SaveChanges();
                        teller++;
                    }
                }
            }
        }
        public void vulBosRecordsOp(List<Bos> bossen)
        {
            /*          ,[bosID]
          ,[boomID]
          ,[x]
          ,[y]*/
            foreach (Bos b in bossen)
            {

                    foreach (Boom bo in b.listBomen)
                    {
                    ctx.BosRecords.Add(new Bos(b.bosID, bo.id, bo.x, bo.y));
                    ctx.SaveChanges();
                }
                
            }
        }
    }
}
