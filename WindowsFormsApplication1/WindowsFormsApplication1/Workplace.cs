using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Workplace
    {
        public String id { set; get; }
        public String period { set; get; }
        public String order { set; get; }
        public String batch { set; get; }
        public String item { set; get; }
        public String amount { set; get; }
        public String timeneed { set; get; }

        public Workplace() { }

        public Workplace(String id, String period, String order, String batch, String item, String amount, String timeneed)
        {
            this.id = id;
            this.period = period;
            this.order = order;
            this.batch = batch;
            this.item = item;
            this.amount = amount;
            this.timeneed = timeneed;
        }
    }
}
