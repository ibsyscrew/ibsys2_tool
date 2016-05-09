using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Artikel
    {
        public String id { set; get; }
        public String lagerbestand { set; get; }
        public String startmenge { set; get; }
        public String pct { set; get; }
        public String preis { set; get; }
        public String lagerwert { set; get; }

        public Artikel(string i, string s, string st, string pc, string p, string la)
        {
            id = i;
            lagerbestand = s;
            startmenge = st;
            pct = pc;
            preis = p;
            lagerwert = la;
        }
    }
}
