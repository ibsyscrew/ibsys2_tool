using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Waitingliststock //Warteliste Material
    {
        public Waitingliststock(string id, string period, string order, string firstbatch, string lastbatch, string item, string amount)
        {
            this.id = id;
            this.period = period;
            this.order = order;
            this.firstbatch = firstbatch;
            this.lastbatch = lastbatch;
            this.item = item;
            this.amount = amount;
        }

        public String id { set; get; }
        public String period { set; get; }
        public String order { set; get; }
        public String firstbatch { set; get; }
        public String lastbatch { set; get; }
        public String item { set; get; }
        public String amount { set; get; }


    }
}
