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
        
        public String startamount { set; get; }
        public String pct { set; get; }
        public String price { set; get; }
        public String stockvalue { set; get; }
        public String lieferfrist { set; get; }
        public String abweichung { set; get; }
        public String verwendungP1 { set; get; }
        public String verwendungP2 { set; get; }
        public String verwendungP3 { set; get; }
        public String diskontmenge { set; get; }
        public String amount { set; get; }
        public String amountnext2 { set; get; }
        public String amountnext3 { set; get; }
        public String amountnext4 { set; get; }
        public String bruttobedarfjetzt { set; get; }
        public String bruttobedarfnext1 { set; get; }
        public String bruttobedarfnext2 { set; get; }
        public String bruttobedarfnext3 { set; get; }
        public String mengebestellung { set; get; }
        public String normalEil { set; get; }


        public Warehousestock() { }

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
