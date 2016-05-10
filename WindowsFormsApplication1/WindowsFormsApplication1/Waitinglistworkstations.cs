using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Waitinglistworkstations //Warteliste Arbeitsplatz
    {
        public Waitinglistworkstations(string id, string timeneed_complete, string period, string order, string firstbatch, string lastbatch, string item, string amount, string timeneed)
        {
            this.id = id;
            this.timeneed_complete = timeneed_complete;
            this.period = period;
            this.order = order;
            this.firstbatch = firstbatch;
            this.lastbatch = lastbatch;
            this.item = item;
            this.amount = amount;
            this.timeneed = timeneed;
        }

        //workplace
        public String  id { set; get; }
        public String timeneed_complete { set; get; }
        //waitinglist
        public String period { set; get; } 
        public String order { set; get; }
        public String firstbatch { set; get; }
        public String lastbatch { set; get; }
        public String item { set; get; }
        public String amount { set; get; }
        public String timeneed { set; get; } 
        

    }
}
