using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BosApen
{
    public class Boom
    {
        public int x { get; set; }
        public int y { get; set; }
        public int id { get; set; }

        private bool zitErEenAapOpDezeBoom;




        public Boom(int coordinaatX, int coordinaatY, int id)
        {
            this.x = coordinaatX;
            this.y = coordinaatY;
            this.id = id;

        }


        public bool getzitErEenAapOpDezeBoom()
        {
            return zitErEenAapOpDezeBoom;
        }
        public void setzitErEenAapOpDezeBoom(bool boolwaarde)
        {
            zitErEenAapOpDezeBoom = boolwaarde;
        }

    }
}
