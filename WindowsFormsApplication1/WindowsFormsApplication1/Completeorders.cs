using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Completeorders
    {
    }

    class Order
    {
        public String id { set; get; }
        public String period { set; get; }
        public String item { set; get; }
        public String quantity { set; get; }
        public String averageunitcosts { set; get; }
        public String cost { set; get; }
        public List<Batch> listbatch;

        public Order() { }

        public Order(String id, String period, String item, String quantity, String cost, String averageunitcosts) 
        {
            this.item = item;
            this.period = period;
            this.id = id;

            this.cost = cost;
            this.quantity = quantity;
            this.averageunitcosts = averageunitcosts;
        }
    }

    class Batch
    {
        public String id { set; get; }
        public String cost { set; get; }
        public String amount { set; get; }
        public String cicletime { set; get; }

        public Batch()
        {
        }

        public Batch(String id, String cost, String amount, String cicletime)
        {
            this.id = id;
            this.cost = cost;
            this.amount = amount;
            this.cicletime = cicletime;
        }

    }
}
