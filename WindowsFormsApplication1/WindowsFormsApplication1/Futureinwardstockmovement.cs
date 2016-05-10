using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace WindowsFormsApplication1
{
    class Futureinwardstockmovement //Ausstehende Bestellungen
    {
        public String orderperiod { set; get; }
        public String id { set; get; } 
        public String mode { set; get; } 
        public String article { set; get; } 
        public String amount { set; get; }

        public Futureinwardstockmovement() { }
        
        public Futureinwardstockmovement(String orderperiod, String id, String mode, String article, String amount)
        {
            this.orderperiod = orderperiod;
            this.id = id;
            this.mode = mode;
            this.article = article;
            this.amount = amount;
          }


    }
}


