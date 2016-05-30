using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Waitinglist2
    {
        String period { set; get; }
        String order { set; get; }
        String firstbatch { set; get; }
        String lastbatch { set; get; }
        String item { set; get; }
        String amount { set; get; }

        public Waitinglist2()
        { }

        public Waitinglist2(String period, String order, String firstbatch, String lastbatch, String item, String amount)
        {
            this.period = period;
            this.order = order;
            this.firstbatch = firstbatch;
            this.lastbatch = lastbatch;
            this.item = item;
            this.amount = amount;
        }
    }
}
