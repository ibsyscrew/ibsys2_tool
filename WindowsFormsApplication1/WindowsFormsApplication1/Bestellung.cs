using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Bestellung
    {
        public String id { set; get; }
        public String periode { set; get; }
        public String modus { set; get; }
        public String artikel { set; get; }
        public String menge { set; get; }

        public String zeit { set; get; }
        public String materialkosten { set; get; }
        public String bestellungskosten { set; get; }
        public String stückkosten { set; get; }
        public String gesamtkosten { set; get; }

        public Bestellung(string i, string s, string st, 
            string pc, string p, string la, 
            string mk, string bk, 
            string sk, string gk)
        {
            id = i;
            periode = s;
            modus = st;
            artikel = pc;
            menge = p;
            zeit = la;
            materialkosten = mk;
            bestellungskosten = bk;
            stückkosten = sk;
            gesamtkosten = gk;
        }
    }
}
