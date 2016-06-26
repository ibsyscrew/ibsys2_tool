using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Warehousestock  // Lagerbestand aktuell
    {
        public String id { set; get; }
        
        public String startamount { set; get; }
        public String pct { set; get; }
        public String price { set; get; }
        public String stockvalue { set; get; }
        public String delivery_deadline { set; get; }
        public String difference { set; get; }
        public String useP1 { set; get; }
        public String useP2 { set; get; }
        public String useP3 { set; get; }
        public String discont { set; get; }
        public String amount { set; get; }
        public String amountnext2 { set; get; }
        public String amountnext3 { set; get; }
        public String amountnext4 { set; get; }
        public String needs1 { set; get; }
        public String needs2 { set; get; }
        public String needs3 { set; get; }
        public String needs4 { set; get; }
        public String amount_order { set; get; }
        public String NE { set; get; }


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
