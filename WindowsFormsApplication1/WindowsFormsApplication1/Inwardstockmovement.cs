using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Inwardstockmovement //Aktueller Lagerzugang Bestellungen
    {
      
        public String orderperiod { set; get; }
        public String id { set; get; }
        public String mode { set; get; }
        public String article { set; get; }
        public String amount { set; get; }
        public String time { set; get; }
        public String materialcosts { set; get; }
        public String ordercosts { set; get; }
        public String entirecosts { set; get; }
        public String piececosts { set; get; }

        public Inwardstockmovement(string orderperiod, string id, string mode, string article, string amount, string time, string materialcosts, string ordercosts, string entirecosts, string piececosts)
        {
            this.orderperiod = orderperiod;
            this.id = id;
            this.mode = mode;
            this.article = article;
            this.amount = amount;
            this.time = time;
            this.materialcosts = materialcosts;
            this.ordercosts = ordercosts;
            this.entirecosts = entirecosts;
            this.piececosts = piececosts;
        }

    }
}
