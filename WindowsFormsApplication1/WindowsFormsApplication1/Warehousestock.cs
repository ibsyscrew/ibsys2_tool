using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Warehousestock  // Lagerbestand aktuell
    {
        public String id { set; get; }
        public String amount { set; get; }
        public String startamount { set; get; }
        public String pct { set; get; }
        public String price { set; get; }
        public String stockvalue { set; get; }

        public Warehousestock(string i, string s, string st, string pc, string p, string la)
        {
            id = i;
            amount = s;
            startamount = st;
            pct = pc;
            price = p;
            stockvalue = la;
        }
    }

}
