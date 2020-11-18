﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Bos(int minGrooteX, int minGrooteY, int maxGrooteX, int maxGrooteY, int amountBomen)
        {
            this.minGrooteX = minGrooteX;
            this.minGrooteY = minGrooteY;
            this.maxGrooteX = maxGrooteX;
            this.maxGrooteY = maxGrooteY;
            for (int i = 0; i < amountBomen; i++)
            {

                Boom t = new Boom(
                            random.Next(minGrooteX, maxGrooteX),
                            random.Next(minGrooteY, maxGrooteY), i);
                listBomen.Add(t);
            };
        }
        public void maakApen(int hoeveelheid, List<string> namen)
        {
            for (int i = 0; i < hoeveelheid; i++)
            {
                Aap app = new Aap(i, listBomen[i].x, listBomen[i].y, namen[i]);
                listApen.Add(app);
            }
        }
        private double AfstandTussenTweeBomen(Boom t1, Boom t2)
        {
            double d = Math.Sqrt(Math.Pow(t1.x - t2.x, 2) + Math.Pow(t1.y - t2.y, 2));
            return d;
        }
        private double AfstandBerekenenBorder(Boom b)
        {
            double d = (new List<double>()
            {
                 b.x - minGrooteX,
                    maxGrooteX - b.x,
                  b.x - minGrooteY,
                    maxGrooteY - b.x,
            }.Min());

            return d;
        }
        private Boom KortsteBoom(Aap a)
        {
            List<Boom> ZonderBezochteBomen = listBomen.Except(a.bezochteBomen).ToList();
            Boom dichtsteBoom = ZonderBezochteBomen.OrderBy(ZBB => AfstandTussenTweeBomen(a.currentBoom(), ZBB)).FirstOrDefault();
            return dichtsteBoom;
        }
        public  void AapSpring(Aap a)
        {
            if (a.bezochteBomen.Count() == 0)
            {
                a.bezochteBomen.Add( listBomen[(random.Next(listBomen.Count))]);
            }

                Boom currentBoomMetAap = a.currentBoom();
            
            Boom kortsteBoom = KortsteBoom(a);
            double checkBoom = AfstandTussenTweeBomen(a.currentBoom(), kortsteBoom);
            double checkRand = AfstandBerekenenBorder(a.currentBoom());

            if (checkRand < checkBoom)
            {
                a.currentBoom().setzitErEenAapOpDezeBoom(false);

                Console.WriteLine("Aap:{0} is uit het bos", a.naam);
                System.IO.File.AppendAllText(@"C:\Users\lieke\OneDrive\scool\prog 4\BosApen\BosApen\test.txt", $"Aap:{a.naam} is uit het bos\n");
                
                // System.IO.File.WriteAllText(@"C:\Users\lieke\OneDrive\scool\prog 4\BosApen\BosApen\test.txt", $"Aap:{a.naam} is uit het bos");

                //  using (StreamWriter outputFile = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 4\BosApen\BosApen\test.txt"))
                //   {
                //       await outputFile.WriteAsync($"Aap:{a.naam} is uit het bos");
                //   }

                listApen.Remove(a);

            }
            else
            {
                a.currentBoom().setzitErEenAapOpDezeBoom(false);
                a.bezochteBomen.Add(kortsteBoom);
                a.currentBoom().setzitErEenAapOpDezeBoom(true);
                Console.WriteLine("Aap:{0} BoomId:{1} Coordinaten:({2},{3})", a.naam, a.currentBoom().id, a.currentBoom().x, a.currentBoom().y);
                System.IO.File.AppendAllText(@"C:\Users\lieke\OneDrive\scool\prog 4\BosApen\BosApen\test.txt", $"Aap:{a.naam} BoomId:{a.currentBoom().id} Coordinaten:({a.currentBoom().x},{a.currentBoom().y})\n");

                // System.IO.File.WriteAllText(@"C:\Users\lieke\OneDrive\scool\prog 4\BosApen\BosApen\test.txt", $"Aap:{a.naam} BoomId:{a.currentBoom().id} Coordinaten:({a.currentBoom().x},{a.currentBoom().y})");

                //    using (StreamWriter outputFile = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 4\BosApen\BosApen\test.txt"))
                //      {
                //         await outputFile.WriteAsync($"Aap:{a.naam} BoomId:{a.currentBoom().id} Coordinaten:({a.currentBoom().x},{a.currentBoom().y})");
                //  }
            }
        }
    }
}
