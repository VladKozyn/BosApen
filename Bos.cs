using System;
using System.Collections.Generic;
using System.Text;

namespace BosApen
{
    public class Bos
    {
        public int minGrooteX { get; set; }
        public int minGrooteY { get; set; }
        public int maxGrooteX { get; set; }
        public int maxGrooteY { get; set; }
        public List<Boom> listBomen = new List<Boom>();
        public List<Aap> listApen = new List<Aap>();
        Random random = new Random();
        public Bos(int minGrooteX, int minGrooteY, int maxGrooteX, int maxGrooteY,int amount)
        {
            this.minGrooteX = minGrooteX;
            this.minGrooteY = minGrooteY;
            this.maxGrooteX = maxGrooteX;
            this.maxGrooteY = maxGrooteY;
            for (int i = 0; i < amount; i++)
            {
             
                Boom t = new Boom(
                            random.Next(minGrooteX, maxGrooteX),
                            random.Next(minGrooteY, maxGrooteY),i);
                listBomen.Add(t);
            };
        }
        public void maakApen(int hoeveelheid,List<string> namen)
        {
            for (int i = 0; i < hoeveelheid; i++)
            {
                Aap app = new Aap(i, listBomen[i].x, listBomen[i].y, namen[i]);
                listApen.Add(app);
            }
        }
       
    }
}
